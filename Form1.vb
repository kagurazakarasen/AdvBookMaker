Imports NVelocity
Imports NVelocity.App
Imports NVelocity.Exception
Imports System.IO
Imports System.Text
Imports System.IO.Compression
Imports System.IO.Compression.ZipFile


'ひと様に見せるつもりじゃなかったのでソースぐちゃぐちゃだわ。

'ファイルタイプチェック用（結局使わなかったかも）
Public Enum FileSystemType
    None = 1
    File
    Directory
End Enum


Public Class form1

    '選択肢の元（質問数）デフォルトは４、円周率の時などは１０にする。
    Private QMAX As Integer = 4



    '選択肢数(x2) 選択肢（質問）数ｘ２です （質問と飛び先フォームの数）QMAXより自動計算 
    'Private SW_MAXx2 As Integer = 8
    Private SW_MAXx2 As Integer = QMAX * 2

    Private CSV_FILE_NAME_FULL As String = ""

    'コントロール配列のフィールドを作成
    Private TextForms() As System.Windows.Forms.TextBox
    Private BtnForms() As System.Windows.Forms.Button
    Private LblForms() As System.Windows.Forms.Label

    Private Sub FormInit()



        '選択肢フォーム自動生成
        'TextBoxコントロール配列の作成・選択枝ｘ２なので注意
        Me.TextForms = New System.Windows.Forms.TextBox(SW_MAXx2) {}

        Me.BtnForms = New System.Windows.Forms.Button(SW_MAXx2) {}

        Me.LblForms = New System.Windows.Forms.Label(SW_MAXx2 / 2) {}



        'コントロールのインスタンス作成し、プロパティを設定する
        Me.SuspendLayout()
        Dim i As Integer
        For i = 0 To Me.TextForms.Length - 3 Step 2

            'Label
            'インスタンス作成
            Me.LblForms(Int((i + 1) / 2)) = New System.Windows.Forms.Label
            Me.LblForms(Int((i + 1) / 2)).Name = "L" + Me.LblForms(Int((i + 1) / 2)).ToString
            Me.LblForms(Int((i + 1) / 2)).Text = (1 + Int((i + 1) / 2)).ToString
            Me.LblForms(Int((i + 1) / 2)).Size = New Size(19, 19)
            Me.LblForms(Int((i + 1) / 2)).Location = New Point(10, 10 + 29 + Int((i + 1) / 2) * 22)

            'TextForms
            'インスタンス作成
            Me.TextForms(i) = New System.Windows.Forms.TextBox
            'プロパティ設定
            Me.TextForms(i).Name = "TB_Text" + Int((i + 1) / 2).ToString()
            'Me.TextForms(i).Text = Int((i + 1) / 2).ToString()
            Me.TextForms(i).Size = New Size(160, 19)
            Me.TextForms(i).Location = New Point(30, 10 + 25 + Int((i + 1) / 2) * 22)
            'イベントハンドラに関連付け
            'AddHandler Me.TextForms(i).Click, AddressOf Me.TextForms_Click

            'インスタンス作成
            Me.TextForms(i + 1) = New System.Windows.Forms.TextBox
            'プロパティ設定
            Me.TextForms(i + 1).Name = "TB_GoTo" + Int((i + 1) / 2).ToString()
            'Me.TextForms(i + 1).Text = "G" + Int((i + 1) / 2).ToString()
            Me.TextForms(i + 1).Size = New Size(150, 19)
            Me.TextForms(i + 1).Location = New Point(200, 10 + 25 + Int((i + 1) / 2) * 22)
            'イベントハンドラに関連付け
            'AddHandler Me.TextForms(i).Click, AddressOf Me.TextForms_Click

            'BtnForms
            'インスタンス作成
            Me.BtnForms(i) = New System.Windows.Forms.Button
            'プロパティ設定
            Me.BtnForms(i).Name = "BtnPick" + Int((i + 1) / 2).ToString()
            Me.BtnForms(i).Text = "<"
            Me.BtnForms(i).Size = New Size(19, 19)
            Me.BtnForms(i).Location = New Point(360, 10 + 25 + Int((i + 1) / 2) * 22)
            'イベントハンドラに関連付け
            AddHandler Me.BtnForms(i).Click, AddressOf Me.BtnForms_Click

            'インスタンス作成
            Me.BtnForms(i + 1) = New System.Windows.Forms.Button
            'プロパティ設定
            Me.BtnForms(i + 1).Name = "BtnToGo" + Int((i + 1) / 2).ToString()
            Me.BtnForms(i + 1).Text = ">"
            Me.BtnForms(i + 1).Size = New Size(19, 19)
            Me.BtnForms(i + 1).Location = New Point(395, 10 + 25 + Int((i + 1) / 2) * 22)
            'イベントハンドラに関連付け
            AddHandler Me.BtnForms(i + 1).Click, AddressOf Me.BtnForms_Click



        Next i

        'フォームにコントロールを追加
        'Me.Controls.AddRange(Me.TextForms)


        'グループボックス
        '自動生成コントロールを追加
        Me.GroupBox1.Controls.AddRange(Me.TextForms)
        Me.GroupBox1.Controls.AddRange(Me.BtnForms)
        Me.GroupBox1.Controls.AddRange(Me.LblForms)

        'Form3 INIT （ここでやっちゃっていいのかしらん？）
        Form3.TextBox_Cover.Text = System.IO.Directory.GetCurrentDirectory() + "\cover.jpg"

        'Guid設定
        Dim guidValue As Guid = Guid.NewGuid()
        Form3.TextBox_uuid.Text = guidValue.ToString

        'date：2017-01-15 の書式に合わせる
        Dim dtNow As DateTime = DateTime.Now

        ' 指定した書式で日付を文字列に変換する
        Form3.TextBox_date.Text = dtNow.ToString("yyyy-MM-dd")


    End Sub


    'Buttonのクリックイベントハンドラ
    Private Sub BtnForms_Click(ByVal sender As Object, ByVal e As EventArgs)
        'クリックされたボタンのNameを表示する
        'MessageBox.Show(CType(sender, System.Windows.Forms.Button).Name)
        'Dim s As String
        's = CType(sender, System.Windows.Forms.Button).Name.ToString

        Dim ClickedIndex As Integer
        ClickedIndex = Array.IndexOf(BtnForms, sender)

        'MsgBox(ClickedIndex.ToString)
        If (ClickedIndex Mod 2 = 1) Then
            'MsgBox("奇数？: " + ClickedIndex.ToString)
            'ココに入るのはSendボタン
            If (TextForms(ClickedIndex).Text <> "") Then

                'MsgBox(TextForms(ClickedIndex).Text)
                Dim index As Integer = ListBox1.FindString(TextForms(ClickedIndex).Text)
                If (index <> -1) Then
                    'MsgBox("見つけた！")
                    '該当があったらそこを表示（あとで変更時自動セットするかどうか判定いれること！）
                    If (MsgBox(TextForms(ClickedIndex).Text + " に移動します", vbYesNo + vbQuestion) = MsgBoxResult.Yes) Then

                        ListBox1.SetSelected(index, True) '選択して
                        ListToEditor()  '読み込み

                    End If
                Else
                    If (MsgBox("移動の前にこのシーンを保存しますか？", vbYesNo + vbQuestion) = MsgBoxResult.Yes) Then
                        SetToGrid()

                    End If


                    NewScene(TextForms(ClickedIndex).Text)
                    'End If
                End If
            End If

        Else
            'Pickボタン
            If (ListBox1.SelectedIndex <> -1) Then
                TextForms(ClickedIndex + 1).Text = ListBox1.Text
            End If

        End If



    End Sub

    Private Sub NewScene(sn As String)
        TextBox_Scene.Text = sn
        TextBox_MainEditer.Text = ""
        For i = 0 To SW_MAXx2 - 1
            TextForms(i).Text = ""
            ' DataGridView1(i + 2, Index).Value = TextForms(i).Text
        Next
        SetToGrid()
    End Sub

    Private Sub CSV_Import(FN As String)

        'init
        '行を数えて、全行のデータを削除
        If Me.DataGridView1.Rows.Count > 0 Then
            '新規行の追加を許可している場合は、「Count - 1」を「Count - 2」に
            For i = 0 To Me.DataGridView1.Rows.Count - 2 Step 1
                Me.DataGridView1.Rows.RemoveAt(0)
            Next
        End If

        'リストボックスも初期化
        Me.ListBox1.Items.Clear()



        'CSVよりインポート http://blog.goo.ne.jp/ashm314/e/464c1063685c727230a13869420e00f1 からイタダキ
        Dim textFile As FileIO.TextFieldParser  ' -- 入力するファイル
        ' --- 入力ファイルを開く
        textFile = New FileIO.TextFieldParser(FN)   ' -- デフォルト encoding は UTF8
        ' --- デリミターをタブと定義する
        textFile.TextFieldType = FileIO.FieldType.Delimited
        textFile.SetDelimiters(vbTab)
        ' --- 行を文字型配列（currentRow）に読み込み、各列を DataGridView に格納する
        Dim currentRow As String()  ' -- 文字型配列
        Dim myRow As Integer = 0
        Dim myCol As Integer = 0
        ' ---▼▼ 行ループ
        While Not textFile.EndOfData
            Me.DataGridView1.Rows.Add() ' -- DataGridView に新規行を追加
            currentRow = textFile.ReadFields()  ' -- １行を文字型配列に格納
            Dim currentColumn As String
            ' ---▼ 列ループ：１行分の列を埋める
            For Each currentColumn In currentRow
                If (myCol = 0) Then
                    Me.ListBox1.Items.Add(currentColumn)
                End If

                If (myCol + 1 > DataGridView1.ColumnCount) Then
                    'MessageBox.Show(" DataGridViewに列(col）が足りないため追加 =" & myCol.ToString)
                    Console.WriteLine(" DataGridViewに列(col）が足りないため追加 =" & myCol.ToString)
                    DataGridView1.Columns.Add("col" + myCol.ToString, "COL" + myCol.ToString)
                End If

                Me.DataGridView1(myCol, myRow).Value = currentColumn
                myCol += 1
            Next    ' --▲ 列ループ
            myCol = 0
            myRow += 1
        End While   ' --▲▲ 行ループ
        ' --- 入力ファイルを閉じる
        textFile.Close()
        ' ---
        Me.DataGridView1.Rows.RemoveAt(0)   ' -- 先頭行は見出し行なので削除
        ListBox1.Items.RemoveAt(0)

        'リストの一番上をエディタへ
        ListBox1.SetSelected(0, True)
        ListToEditor()



    End Sub
    Private Sub ListBox1_MouseDoubleClick(sender As Object, e As MouseEventArgs) Handles ListBox1.MouseDoubleClick
        ListToEditor()
    End Sub

    Private Sub ListBox1_PreviewKeyDown(sender As Object, e As PreviewKeyDownEventArgs) Handles ListBox1.PreviewKeyDown
        If (e.KeyCode = Keys.Enter) Then
            ListToEditor()

        End If
    End Sub

    Sub ListToEditor()
        'ListBoxの項目をEditorに反映
        With ListBox1
            If .SelectedIndex <> -1 Then
                Dim si As String = .SelectedItem.ToString()
                Debug.WriteLine(si & "  Index=" & .SelectedIndex)
                'MsgBox(si)
                'エディターに反映
                TextBox_Scene.Text = Me.DataGridView1(0, .SelectedIndex).Value

                '置換用StringBuilderを作成する
                Dim s As String = Me.DataGridView1(1, .SelectedIndex).Value
                Dim sb As New System.Text.StringBuilder(s)
                sb.Replace("<BR/>", vbCrLf)     'BRを改行に変更
                sb.Replace("<br>", vbCrLf)     'BRを改行に変更
                sb.Replace("<br/>", vbCrLf)     'BRを改行に変更
                TextBox_MainEditer.Text = sb.ToString()

                'TextForms(0).Text = Me.DataGridView1(2, .SelectedIndex).Value
                'TextForms(1).Text = Me.DataGridView1(3, .SelectedIndex).Value

                Dim i As Integer
                For i = 0 To SW_MAXx2 - 1
                    TextForms(i).Text = ""
                Next i

                For i = 2 To SW_MAXx2 + 2
                    If (Me.DataGridView1(i, .SelectedIndex).Value = "") Then
                        Exit For
                    End If
                    TextForms(i - 2).Text = Me.DataGridView1(i, .SelectedIndex).Value
                Next i


                '                For i = 2 To DataGridView1.RowCount - 2 Step 2
                '               If (Me.DataGridView1(i, .SelectedIndex).Value = "") Then
                '              Exit For
                '         End If
                '            TextForms(i - 2).Text = Me.DataGridView1(i, .SelectedIndex).Value
                '           TextForms(i - 1).Text = Me.DataGridView1(i + 1, .SelectedIndex).Value
                '
                '           Next i

            End If
        End With

    End Sub


    Private Sub OpenToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles OpenToolStripMenuItem.Click

        'OpenFileDialogクラスのインスタンスを作成 http://dobon.net/vb/dotnet/form/openfiledialog.html 参考
        Dim ofd As New OpenFileDialog()

        'はじめのファイル名を指定する
        'はじめに「ファイル名」で表示される文字列を指定する
        ofd.FileName = "*.csv"
        'はじめに表示されるフォルダを指定する
        '指定しない（空の文字列）の時は、現在のディレクトリが表示される
        ofd.InitialDirectory = "C:\"
        '[ファイルの種類]に表示される選択肢を指定する
        '指定しないとすべてのファイルが表示される
        ofd.Filter = "CSVファイル(*.csv)|*.csv"
        '[ファイルの種類]ではじめに選択されるものを指定する
        '2番目の「すべてのファイル」が選択されているようにする
        'ofd.FilterIndex = 2
        'タイトルを設定する
        ofd.Title = "開くファイルを選択してください"
        'ダイアログボックスを閉じる前に現在のディレクトリを復元するようにする
        ofd.RestoreDirectory = True
        '存在しないファイルの名前が指定されたとき警告を表示する
        'デフォルトでTrueなので指定する必要はない
        ofd.CheckFileExists = True
        '存在しないパスが指定されたとき警告を表示する
        'デフォルトでTrueなので指定する必要はない
        ofd.CheckPathExists = True

        'ダイアログを表示する
        If ofd.ShowDialog() = DialogResult.OK Then
            'OKボタンがクリックされたとき、選択されたファイル名を表示する
            Console.WriteLine(ofd.FileName)
            CSV_FILE_NAME_FULL = ofd.FileName
            CSV_Import(ofd.FileName)
        End If

        'MsgBox("Open")
        'CSV_Import("C:\work\adv1\adv1.csv")

    End Sub

    Private Sub Btn_Import_Click(sender As Object, e As EventArgs)

        ' CSV_Import("C:\work\adv1\adv1.csv")

    End Sub

    Private Sub form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        FormInit()

        '自分自身のバージョン情報を取得する
        Dim ver As System.Diagnostics.FileVersionInfo =
        System.Diagnostics.FileVersionInfo.GetVersionInfo(
        System.Reflection.Assembly.GetExecutingAssembly().Location)
        '結果を表示
        Console.WriteLine(ver)

        Console.WriteLine(My.Application.Info.Version)
        Label_ver.Text = "Version:" + My.Application.Info.Version.ToString


        ' カレントディレクトリを取得する
        Dim stCurrentDir As String = System.IO.Directory.GetCurrentDirectory()

        ' カレントディレクトリを表示する
        '        MessageBox.Show(stCurrentDir)
        'styles_epub_rtl.cssある？
        ' ファイルが存在しているかどうか確認する
        If System.IO.File.Exists(stCurrentDir + "\styles_epub_rtl.css") Then
            'MessageBox.Show("styles_epub_rtl.cssファイルは存在します")
        Else
            MsgBox(stCurrentDir + "に styles_epub_rtl.cssファイルが存在しません", vbCritical)
        End If
    End Sub

    Private Sub save_csv(fn As String)
        'csv出力、http://blog.goo.ne.jp/ashm314/e/e79a8f2bd9c1b6f83df78d303d183f1c 参考
        Dim textFile As IO.StreamWriter ' -- 出力するファイル
        Dim textLine As String  ' -- 書き出す１行
        Dim cellData As String  ' -- セルのデータ
        ' --- ファイルのインスタンスを作る
        'textFile = New IO.StreamWriter("C:\temp\test.csv", False, System.Text.Encoding.UTF8)  ' -- ファイル名、上書き、エンコーディング
        textFile = New IO.StreamWriter(fn, False, System.Text.Encoding.UTF8)  ' -- ファイル名、上書き、エンコーディング
        ' ---① 列見出しを書き出す
        textLine = ""   ' -- 行の文字列をクリア
        ' --- １行目（列見出し）を書き出す
        For myCol As Integer = 0 To Me.DataGridView1.ColumnCount - 1
            If myCol = Me.DataGridView1.ColumnCount - 1 Then
                textLine += Me.DataGridView1.Columns(myCol).HeaderText  ' -- 最終列ならタブを付けない
            Else
                textLine += Me.DataGridView1.Columns(myCol).HeaderText & vbTab  ' -- 途中の列ならタブを付加
            End If
        Next
        textFile.WriteLine(textLine)    ' -- 終端文字付きで１行を書き出す
        ' ---② セルのデータを書き出す
        For myRow As Integer = 0 To Me.DataGridView1.RowCount - 1
            textLine = ""   ' -- 行の文字列をクリア
            For myCol As Integer = 0 To Me.DataGridView1.ColumnCount - 1
                If (Me.DataGridView1(myCol, myRow).Value = String.Empty) Then
                    cellData = ""
                Else
                    cellData = Me.DataGridView1(myCol, myRow).Value.ToString
                End If
                If (myCol = Me.DataGridView1.ColumnCount - 1) Then
                    textLine += cellData    ' -- 最終列ならタブを付けない
                Else
                    textLine += cellData & vbTab ' -- 途中の列には項目の後にタブを付加する
                End If
            Next
            textFile.WriteLine(textLine)    ' -- 終端文字付きで１行を書き出す
        Next
        ' ---
        textFile.Close()    ' -- StreamWriter を閉じて
        textFile.Dispose()  ' -- StreamWriter を解放
        ' ---
        MessageBox.Show("CSV ファイルを出力しました")

    End Sub

    Private Sub Button_SetToGrid_Click(sender As Object, e As EventArgs) Handles Button_SetToGrid.Click
        SetToGrid()

    End Sub

    Private Sub SetToGrid()
        If TextBox_Scene.Text <> String.Empty Then
            Dim NewFLG As Boolean = False
            Dim index As Integer = ListBox1.FindString(TextBox_Scene.Text)
            If (index <> -1) Then
                'あれば
                ListBox1.SetSelected(index, True)

            Else
                MsgBox("リストに該当するシーンがありません。新規作成になります")
                'グリッドの新規行を指定
                DataGridView1.Rows.Add()
                index = ListBox1.Items.Count
                ListBox1.Items.Add(TextBox_Scene.Text)
                ListBox1.SetSelected(index, True)

            End If


            '            If (DataGridView1.RowCount = index) Then
            'DataGridView1.Rows.Add()
            '               NewFLG = True
            '      End If
            DataGridView1(0, index).Value = TextBox_Scene.Text
            '置換用StringBuilderを作成する
            Dim sb As New System.Text.StringBuilder(TextBox_MainEditer.Text)
            sb.Replace(vbCrLf, "<BR/>")
            DataGridView1(1, index).Value = sb.ToString()

            Dim i As Integer
            For i = 0 To SW_MAXx2 - 1
                DataGridView1(i + 2, index).Value = TextForms(i).Text
            Next

            '         If (NewFLG = True) Then
            '        DataGridView1.Rows.Add()
            '        End If

            TextBox_MainEditer.Focus()
        End If

    End Sub

    Private Sub NewToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles NewToolStripMenuItem.Click
        TextBox_MainEditer.Enabled = True
        NewScene("Start")
    End Sub

    Private Sub SaveToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SaveToolStripMenuItem.Click
        ' SaveFileDialog の新しいインスタンスを生成する (デザイナから追加している場合は必要ない)
        Dim SaveFileDialog1 As New SaveFileDialog()

        If (CSV_FILE_NAME_FULL = "") Then CSV_FILE_NAME_FULL = "c:\tmp\tmp.csv"

        ' ダイアログのタイトルを設定する
        SaveFileDialog1.Title = "名前を付けてCSVを保存"

        ' 初期表示するディレクトリを設定する
        'SaveFileDialog1.InitialDirectory = "C:\"
        SaveFileDialog1.InitialDirectory = System.IO.Path.GetDirectoryName(CSV_FILE_NAME_FULL)

        ' 初期表示するファイル名を設定する
        SaveFileDialog1.FileName = System.IO.Path.GetFileName(CSV_FILE_NAME_FULL)

        ' ファイルのフィルタを設定する
        SaveFileDialog1.Filter = "CSVファイル(*.csv)|*.csv"

        ' ファイルの種類 の初期設定を 2 番目に設定する (初期値 1)
        'SaveFileDialog1.FilterIndex = 2

        ' ダイアログボックスを閉じる前に現在のディレクトリを復元する (初期値 False)
        SaveFileDialog1.RestoreDirectory = True

        ' [ヘルプ] ボタンを表示する (初期値 False)
        'SaveFileDialog1.ShowHelp = True

        ' 存在しないファイルを指定した場合は、
        ' 新しく作成するかどうかの問い合わせを表示する (初期値 False)
        'SaveFileDialog1.CreatePrompt = True

        ' 存在しているファイルを指定した場合は、
        ' 上書きするかどうかの問い合わせを表示する (初期値 True)
        'SaveFileDialog1.OverwritePrompt = True

        ' 存在しないファイル名を指定した場合は警告を表示する (初期値 False)
        'SaveFileDialog1.CheckFileExists = True

        ' 存在しないパスを指定した場合は警告を表示する (初期値 True)
        'SaveFileDialog1.CheckPathExists = True

        ' 拡張子を指定しない場合は自動的に拡張子を付加する (初期値 True)
        SaveFileDialog1.AddExtension = True

        ' 有効な Win32 ファイル名だけを受け入れるようにする (初期値 True)
        'SaveFileDialog1.ValidateNames = True

        ' ダイアログを表示し、戻り値が [OK] の場合は、選択したファイルを表示する
        If SaveFileDialog1.ShowDialog() = DialogResult.OK Then
            'MessageBox.Show(SaveFileDialog1.FileName)
            save_csv(SaveFileDialog1.FileName)
        End If

        ' 不要になった時点で破棄する (正しくは オブジェクトの破棄を保証する を参照)
        SaveFileDialog1.Dispose()
    End Sub

    Private Sub HTMLToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles HTMLToolStripMenuItem.Click
        'MsgBox("HTML版を出力します")
        Form3.TextBox_Info.Text = "HTML版を出力します"

        Dim title As String = "サンプルADV"
        Dim Path As String
        Dim PathHtml As String

        If (CSV_FILE_NAME_FULL = "") Then

            Path = "c:\tmp"
        Else
            Path = System.IO.Path.GetDirectoryName(CSV_FILE_NAME_FULL)
        End If


        'FolderBrowserDialogクラスのインスタンスを作成
        Dim fbd As New FolderBrowserDialog

        '上部に表示する説明テキストを指定する
        fbd.Description = "HTMLを出力するフォルダを指定してください。"
        'ルートフォルダを指定する
        'デフォルトでDesktop
        fbd.RootFolder = Environment.SpecialFolder.Desktop
        '最初に選択するフォルダを指定する
        'RootFolder以下にあるフォルダである必要がある
        fbd.SelectedPath = Path
        'ユーザーが新しいフォルダを作成できるようにする
        'デフォルトでTrue
        fbd.ShowNewFolderButton = False

        'ダイアログを表示する
        If fbd.ShowDialog(Me) = DialogResult.OK Then
            '選択されたフォルダを表示する
            Console.WriteLine(fbd.SelectedPath)
        End If
        Path = fbd.SelectedPath
        MsgBox(Path + "にhtmlフォルダを作成、HTML版を出力します")
        Form3.TextBox_Info.Text = Path + "にhtmlフォルダを作成、HTML版を出力します"



        'MsgBox(Path)
        PathHtml = Path + "\html"
        If System.IO.Directory.Exists(PathHtml) Then
            '存在する
        Else
            '無い
            MsgBox(PathHtml + "を生成します")
            System.IO.Directory.CreateDirectory(PathHtml)
        End If

        'StyleSheet

        'スタイルシートコピー(ディレクトリが無くても強制的に作成）
        'My.Computer.FileSystem.CopyFile(System.IO.Directory.GetCurrentDirectory() + "\styles_epub_rtl.css", Path + "\Styles\styles_epub_rtl.css", True)


        VeloScene(PathHtml)

        If (MsgBox("HTML作成完了。" + PathHtml + "\" + ListBox1.Items(0).ToString + "をブラウザテストしますか？", vbQuestion + vbYesNo) = MsgBoxResult.Yes) Then
            Form3.Hide()

            Form2.Show()
            Form2.WebBrowser1.Navigate(PathHtml + "\" + ListBox1.Items(0).ToString + ".xhtml")

        End If

    End Sub


    Private Sub VeloScene(path As String)
        ' テンプレートエンジン NVelocity　https://codezine.jp/article/detail/373 参考
        Dim SceneFN As String
        Dim Contents As String

        '質問用配列
        Dim qes(SW_MAXx2) As String

        'Epub作成フォーム
        Form3.Show()
        Form3.ProgressBar1.Maximum = DataGridView1.RowCount - 1


        For r As Integer = 0 To DataGridView1.RowCount - 1
            Form3.ProgressBar1.Value = r

            'シーン名とコンテンツ取得
            DataGridView1.CurrentCell = DataGridView1(0, r)
            If (DataGridView1.CurrentCell.Value = "") Then
                Exit For
            End If
            SceneFN = DataGridView1.CurrentCell.Value.ToString
            DataGridView1.CurrentCell = DataGridView1(1, r)
            Contents = DataGridView1.CurrentCell.Value.ToString

            '残りの質問たち
            For c As Integer = 2 To DataGridView1.ColumnCount - 1
                DataGridView1.CurrentCell = DataGridView1(c, r)
                If (DataGridView1.CurrentCell.Value = "") Then
                    Exit For
                End If

                '現在のセルの値を表示
                Console.WriteLine(DataGridView1.CurrentCell.Value)
            Next c


            '質問と飛び先
            For i = 0 To SW_MAXx2
                qes(i) = ""
                DataGridView1.CurrentCell = DataGridView1(i + 2, r)
                If (DataGridView1.CurrentCell.Value <> "") Then qes(i) = DataGridView1.CurrentCell.Value.ToString
            Next i


            Try
                'NVelocityの初期化
                Velocity.Init()
                'プロパティファイルの指定も可能（実行フォルダのNVelocity.propertiesがデフォルト）
                'Velocity.Init("../NVelocity.properties")

                'コンテキストの設定
                Dim ctx As VelocityContext = New VelocityContext

                'スタイルシートをセット
                ctx.Put("style", "../styles/styles_epub_rtl.css")

                'タイトルをセット   
                'ctx.Put("title", "サンプルタイトル")
                ctx.Put("title", Form3.TextBox_Title.Text)

                'コンテンツをセット
                ctx.Put("contents", Contents)

                For i = 0 To SW_MAXx2
                    ctx.Put("q" + i.ToString, qes(i))
                Next i

                '
                Try

                    '結果を格納するStringWriter
                    Dim resultWriter As System.IO.StringWriter = New System.IO.StringWriter
                    'テンプレートファイルを読み込み、コンテキストとマージ
                    'Velocity.MergeTemplate("../SceneXhtml.vm", "UTF-8", ctx, resultWriter)
                    Velocity.MergeTemplate("SceneXhtml.vm", "UTF-8", ctx, resultWriter)
                    '初期設定ファイルでデフォルトエンコーディング設定時は省略可
                    'Velocity.MergeTemplate("../mail.vm", ctx, resultWriter) 
                    '結果を画面に表示
                    'Me.TextBox_MainEditer.Text = resultWriter.GetStringBuilder().ToString()

                    '書き込み
                    Dim fileName As String = path + "\" + SceneFN + ".xhtml"
                    'Dim textToAdd As String = resultWriter.GetStringBuilder().ToString()
                    'Dim fs As FileStream = Nothing


                    'ファイルが存在しているときは、上書きする 
                    System.IO.File.WriteAllText(fileName, resultWriter.GetStringBuilder().ToString(), System.Text.Encoding.GetEncoding("UTF-8"))



                Catch ex As ResourceNotFoundException

                    MessageBox.Show("テンプレートファイルが見つかりませんでした", "エラー", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    Console.WriteLine("■テンプレートファイルが見つかりませんでした\n\n" + ex.ToString())

                Catch ex As ParseErrorException

                    MessageBox.Show("テンプレートの解析時にエラーが発生しました", "エラー", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    Console.WriteLine("■テンプレートの解析時にエラーが発生しました\n\n" + ex.ToString())

                End Try

            Catch ex As System.Exception
                MessageBox.Show("その他のエラーが発生しました", "エラー", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                Console.WriteLine("■その他のエラーが発生しました\n\n" + ex.ToString())
            End Try

        Next r


    End Sub

    Private Sub TextBox_Scene_TextChanged(sender As Object, e As EventArgs) Handles TextBox_Scene.TextChanged
        If (Me.Text <> "") Then
            TextBox_MainEditer.Enabled = True
        End If
    End Sub

    Public Sub EpubMake()

        Dim title As String = "サンプルADV"
        Dim Path As String
        Dim PathEPUB As String

        If (CSV_FILE_NAME_FULL = "") Then
            Path = "c:\tmp"
        Else
            Path = System.IO.Path.GetDirectoryName(CSV_FILE_NAME_FULL)
        End If


        'FolderBrowserDialogクラスのインスタンスを作成
        Dim fbd As New FolderBrowserDialog

        '上部に表示する説明テキストを指定する
        fbd.Description = "Epub構造を出力するフォルダを指定してください。"
        'ルートフォルダを指定する
        'デフォルトでDesktop
        fbd.RootFolder = Environment.SpecialFolder.Desktop
        '最初に選択するフォルダを指定する
        'RootFolder以下にあるフォルダである必要がある
        fbd.SelectedPath = Path
        'ユーザーが新しいフォルダを作成できるようにする
        'デフォルトでTrue
        fbd.ShowNewFolderButton = False

        'ダイアログを表示する
        If fbd.ShowDialog(Me) = DialogResult.OK Then
            '選択されたフォルダを表示する
            Console.WriteLine(fbd.SelectedPath)
        End If
        Path = fbd.SelectedPath
        MsgBox(Path + "にepubフォルダを作成、Epubファイル構造を出力します")
        Form3.TextBox_Info.Text = Path + "にepubフォルダを作成、Epubファイル構造を出力します"
        Form3.TextBox_Info.Update()



        'MsgBox(Path)
        PathEPUB = Path + "\epub"

        'mimetype
        My.Computer.FileSystem.CopyFile(System.IO.Directory.GetCurrentDirectory() + "\mimetype", PathEPUB + "\mimetype", True)

        'container.xml
        My.Computer.FileSystem.CopyFile(System.IO.Directory.GetCurrentDirectory() + "\container.xml", PathEPUB + "\META-INF\container.xml", True)

        'Cover
        'My.Computer.FileSystem.CopyFile(System.IO.Directory.GetCurrentDirectory() + "\cover.jpg", PathEPUB + "\OEBPS\Images\cover.jpg", True)
        My.Computer.FileSystem.CopyFile(Form3.TextBox_Cover.Text, PathEPUB + "\OEBPS\Images\cover.jpg", True)

        'スタイルシートコピー(ディレクトリが無くても強制的に作成）
        My.Computer.FileSystem.CopyFile(System.IO.Directory.GetCurrentDirectory() + "\styles_epub_rtl.css", PathEPUB + "\OEBPS\styles\styles_epub_rtl.css", True)




        'MsgBox(Path)
        If System.IO.Directory.Exists(PathEPUB + "\OEBPS\Text") Then
            '存在する
        Else
            '無い
            'MsgBox(PathEPUB + "\OEBPS\Text" + "を生成します")
            System.IO.Directory.CreateDirectory(PathEPUB + "\OEBPS\Text")
        End If


        'content.opf 作成
        ContentOpf(PathEPUB + "\OEBPS")
        TocNcx(PathEPUB + "\OEBPS")

        VeloScene(PathEPUB + "\OEBPS\Text")

        'cover.xhtmlコピー
        My.Computer.FileSystem.CopyFile(System.IO.Directory.GetCurrentDirectory() + "\cover.xhtml", PathEPUB + "\OEBPS\Text\cover.xhtml", True)



        Form3.TextBox_Info.Text = PathEPUB + ".epubファイルを作成します"
        Form3.TextBox_Info.Update()

        'ZIP書庫を作成
        'mimetypeだけを無圧縮でまず保存 ー＞やってみたがNG　なぜ？
        'System.IO.Compression.ZipFile.CreateFromDirectory(PathEPUB + "\mimetype", PathEPUB + "_VB.zip", System.IO.Compression.CompressionLevel.NoCompression, False, System.Text.Encoding.GetEncoding("UTF-8"))


        Using a As ZipArchive = ZipFile.Open(PathEPUB + ".epub", ZipArchiveMode.Update)

            Dim files As New ArrayList

            'mimetypeだけ無圧縮
            a.CreateEntryFromFile(PathEPUB + "\mimetype", "mimetype", CompressionLevel.NoCompression)
            'ファイル追加テスト----とちゅう
            'Dim e As ZipArchiveEntry = a.CreateEntryFromFile(PathEPUB + "\META-INF", PathEPUB + "\META-INF")
            a.CreateEntry("META-INF\")
            'a.CreateEntryFromFile(PathEPUB + "\META-INF\container.xml", "META-INF\container.xml", CompressionLevel.NoCompression) 'これはOKなのだけれど、なぜかBiBiとSigilで読めず。（KindleはOK）
            GetAllFilesAndArcive(PathEPUB + "\META-INF", "*.*", files, a, PathEPUB + "\META-INF")
            'ListBox2.Items.AddRange(files.ToArray())


            a.CreateEntry("OEBPS\")


            'test
            'Dim files As String() = System.IO.Directory.GetFileSystemEntries(PathEPUB, "*", System.IO.SearchOption.AllDirectories)

            'ListBox1に結果を表示する
            'ListBox2.Items.AddRange(files)

            'これに時間かかるけれどゲージ変化させにくいので今はやめとく
            GetAllFilesAndArcive(PathEPUB + "\OEBPS", "*.*", files, a, PathEPUB + "\OEBPS")
            'ListBox2.Items.AddRange(files.ToArray())
        End Using


        'ZIP書庫を作成、フォルダ内一括になってしまうのでNG（KindleならOK）
        '        System.IO.Compression.ZipFile.CreateFromDirectory(PathEPUB, PathEPUB + ".zip", System.IO.Compression.CompressionLevel.NoCompression, False, System.Text.Encoding.GetEncoding("UTF-8"))

        MsgBox(PathEPUB + ".epubファイルを作成完了。" + vbCrLf + vbCrLf + "※現状このファイルはKindlePreviewer用です。他の環境用にはePubPack等を利用してパックしなおしてください。")

        Form3.Hide()
        Form3.Button2.Enabled = False


    End Sub

    Private Sub Epub作成ToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles Epub作成ToolStripMenuItem.Click
        'Epub作成（あれ、Sub以下に漢字はいってるけどいいの？　良いらしい。
        ' MsgBox("Epubいきます")

        'Epub作成フォーム
        Form3.Show()
        Form3.Button2.Enabled = True



    End Sub

    '指定したパス情報がファイル名かフォルダ名か判断する　http://d.hatena.ne.jp/tekk/20091205/1259988284
    Public Function GetFileSystemType(ByVal path As String) As FileSystemType

        If System.IO.File.Exists(path) = True Then
            Return FileSystemType.File
        ElseIf System.IO.Directory.Exists(path) = True Then
            Return FileSystemType.Directory
        Else
            Return FileSystemType.None
        End If

    End Function

    'VBでZipがまともに動かなかったので再帰的にフォルダ内を取得しつつzip化する。 http://dobon.net/vb/dotnet/file/getfiles.html 参考＋Zip部分改造
    ''' <summary>
    ''' 指定されたフォルダ以下にあるすべてのファイルを取得する
    ''' </summary>
    ''' <param name="folder">ファイルを検索するフォルダ名。</param>
    ''' <param name="searchPattern">ファイル名検索文字列
    ''' ワイルドカード指定子(*, ?)を使用する。</param>
    ''' <param name="files">見つかったファイル名のリスト</param>
    Public Sub GetAllFilesAndArcive(ByVal folder As String,
        ByVal searchPattern As String, ByRef files As ArrayList, arc As ZipArchive, EntryPath As String)
        'folderにあるファイルを取得する
        Dim fs As String() =
        System.IO.Directory.GetFiles(folder, searchPattern)
        'ArrayListに追加する
        files.AddRange(fs)

        'アーカイブ内にセット
        Dim d0 As String
        For Each d0 In fs
            If (GetFileSystemType(d0) = FileSystemType.Directory) Then
            Else
                Console.WriteLine("File:  " + d0)

                Dim dpm As String
                dpm = Path.GetDirectoryName(d0).Substring(Path.GetDirectoryName(EntryPath).Length)

                Console.WriteLine("親ディレクトリ名: " + dpm)
                Form3.TextBox_Info.Text = "Zip CreateEntryFromFile:" + dpm
                Form3.TextBox_Info.Update()

                arc.CreateEntryFromFile(d0, dpm.Substring(1) + "\" + Path.GetFileName(d0), CompressionLevel.NoCompression)

            End If
        Next d0



        'folderのサブフォルダを取得する
        Dim ds As String() = System.IO.Directory.GetDirectories(folder)
        'サブフォルダにあるファイルも調べる
        Dim d As String
        For Each d In ds
            Console.WriteLine("ArcFolder: " + d)
            Dim dpm As String
            'dpm = Path.GetFileName(Path.GetDirectoryName(d)) '一つ上のディレクトリ名
            'dpm = Path.GetDirectoryName(d).Substring(EntryPath.Length + 1)
            dpm = Path.GetDirectoryName(d).Substring(Path.GetDirectoryName(EntryPath).Length)
            Console.WriteLine("ArcFolderDpm: " + dpm.Substring(1))
            Console.WriteLine("CreateEntry: " + dpm.Substring(1) + "\" + Path.GetFileName(d) + "\")

            Form3.TextBox_Info.Text = "Zip CreateEntry:" + dpm
            Form3.TextBox_Info.Update()

            arc.CreateEntry(dpm.Substring(1) + "\" + Path.GetFileName(d) + "\")
            GetAllFilesAndArcive(d, searchPattern, files, arc, EntryPath)
        Next d
    End Sub


    Private Sub ContentOpf(dir As String)
        'content.opf 作成



        Try


            'NVelocityの初期化
            Velocity.Init()
            'プロパティファイルの指定も可能（実行フォルダのNVelocity.propertiesがデフォルト）
            'Velocity.Init("../NVelocity.properties")

            'コンテキストの設定
            Dim ctx As VelocityContext = New VelocityContext

            'スタイルシートをセット
            ctx.Put("style", "../styles/styles_epub_rtl.css")

            'タイトルをセット   
            'ctx.Put("title", "ザ・アドベンチャー")
            ctx.Put("title", Form3.TextBox_Title.Text)
            '著者をセット   
            ctx.Put("creator", Form3.TextBox_Author.Text)
            '出版をセット   
            ctx.Put("publisher", Form3.TextBox_Publisher.Text)

            '日付Form3.TextBox_date.Text
            ctx.Put("date", Form3.TextBox_date.Text)

            'uuid
            'ctx.Put("uuid", "1268e311-af06-411f-bb5f-187be54ccbaa")
            ctx.Put("uuid", Form3.TextBox_uuid.Text)

            'Listセット
            Dim list As ArrayList = New ArrayList
            For Each item As String In ListBox1.Items
                list.Add(item)
            Next
            ctx.Put("scenelist", list)



            Try

                '結果を格納するStringWriter
                Dim resultWriter As System.IO.StringWriter = New System.IO.StringWriter
                'テンプレートファイルを読み込み、コンテキストとマージ
                'Velocity.MergeTemplate("../SceneXhtml.vm", "UTF-8", ctx, resultWriter)
                Velocity.MergeTemplate("content.opf.vm", "UTF-8", ctx, resultWriter)
                '初期設定ファイルでデフォルトエンコーディング設定時は省略可
                'Velocity.MergeTemplate("../mail.vm", ctx, resultWriter) 
                '結果を画面に表示
                'Me.TextBox_MainEditer.Text = resultWriter.GetStringBuilder().ToString()

                '書き込み
                Dim fileName As String = dir + "\content.opf"
                'Dim textToAdd As String = resultWriter.GetStringBuilder().ToString()
                'Dim fs As FileStream = Nothing


                'ファイルが存在しているときは、上書きする 
                System.IO.File.WriteAllText(fileName, resultWriter.GetStringBuilder().ToString(), System.Text.Encoding.GetEncoding("UTF-8"))



            Catch ex As ResourceNotFoundException

                MessageBox.Show("テンプレートファイルが見つかりませんでした", "エラー", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Console.WriteLine("■テンプレートファイルが見つかりませんでした\n\n" + ex.ToString())

            Catch ex As ParseErrorException

                MessageBox.Show("テンプレートの解析時にエラーが発生しました", "エラー", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Console.WriteLine("■テンプレートの解析時にエラーが発生しました\n\n" + ex.ToString())

            End Try

        Catch ex As System.Exception
            MessageBox.Show("その他のエラーが発生しました", "エラー", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Console.WriteLine("■その他のエラーが発生しました\n\n" + ex.ToString())
        End Try


    End Sub

    Private Sub TocNcx(dir As String)
        Try


            'NVelocityの初期化
            Velocity.Init()
            'プロパティファイルの指定も可能（実行フォルダのNVelocity.propertiesがデフォルト）
            'Velocity.Init("../NVelocity.properties")

            'コンテキストの設定
            Dim ctx As VelocityContext = New VelocityContext

            'スタイルシートをセット
            ctx.Put("style", "../styles/styles_epub_rtl.css")

            'タイトルをセット   
            'ctx.Put("title", "サンプルタイトル")
            ctx.Put("title", Form3.TextBox_Title.Text)

            'uuid
            'ctx.Put("uuid", "1268e311-af06-411f-bb5f-187be54ccbaa")
            ctx.Put("uuid", Form3.TextBox_uuid.Text)

            'シーンセット
            ctx.Put("scn", ListBox1.Items(0).ToString)



            Try

                '結果を格納するStringWriter
                Dim resultWriter As System.IO.StringWriter = New System.IO.StringWriter
                'テンプレートファイルを読み込み、コンテキストとマージ
                'Velocity.MergeTemplate("../SceneXhtml.vm", "UTF-8", ctx, resultWriter)
                Velocity.MergeTemplate("toc.ncx.vm", "UTF-8", ctx, resultWriter)
                '初期設定ファイルでデフォルトエンコーディング設定時は省略可
                'Velocity.MergeTemplate("../mail.vm", ctx, resultWriter) 
                '結果を画面に表示
                'Me.TextBox_MainEditer.Text = resultWriter.GetStringBuilder().ToString()

                '書き込み
                Dim fileName As String = dir + "\toc.ncx"
                'Dim textToAdd As String = resultWriter.GetStringBuilder().ToString()
                'Dim fs As FileStream = Nothing


                'ファイルが存在しているときは、上書きする 
                System.IO.File.WriteAllText(fileName, resultWriter.GetStringBuilder().ToString(), System.Text.Encoding.GetEncoding("UTF-8"))



            Catch ex As ResourceNotFoundException

                MessageBox.Show("テンプレートファイルが見つかりませんでした", "エラー", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Console.WriteLine("■テンプレートファイルが見つかりませんでした\n\n" + ex.ToString())

            Catch ex As ParseErrorException

                MessageBox.Show("テンプレートの解析時にエラーが発生しました", "エラー", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Console.WriteLine("■テンプレートの解析時にエラーが発生しました\n\n" + ex.ToString())

            End Try

        Catch ex As System.Exception
            MessageBox.Show("その他のエラーが発生しました", "エラー", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Console.WriteLine("■その他のエラーが発生しました\n\n" + ex.ToString())
        End Try


    End Sub


End Class

'memo アイコン使用イラストーいらすとや：http://www.irasutoya.com/2016/05/blog-post_74.html