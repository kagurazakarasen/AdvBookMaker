<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form3
    Inherits System.Windows.Forms.Form

    'フォームがコンポーネントの一覧をクリーンアップするために dispose をオーバーライドします。
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Windows フォーム デザイナーで必要です。
    Private components As System.ComponentModel.IContainer

    'メモ: 以下のプロシージャは Windows フォーム デザイナーで必要です。
    'Windows フォーム デザイナーを使用して変更できます。  
    'コード エディターを使って変更しないでください。
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Form3))
        Me.ProgressBar1 = New System.Windows.Forms.ProgressBar()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.TextBox_Cover = New System.Windows.Forms.TextBox()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.TextBox_Title = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.TextBox_Author = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.TextBox_Publisher = New System.Windows.Forms.TextBox()
        Me.TextBox_uuid = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.TextBox_Info = New System.Windows.Forms.TextBox()
        Me.TextBox_date = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'ProgressBar1
        '
        Me.ProgressBar1.Location = New System.Drawing.Point(30, 360)
        Me.ProgressBar1.Name = "ProgressBar1"
        Me.ProgressBar1.Size = New System.Drawing.Size(433, 23)
        Me.ProgressBar1.TabIndex = 0
        '
        'PictureBox1
        '
        Me.PictureBox1.Image = CType(resources.GetObject("PictureBox1.Image"), System.Drawing.Image)
        Me.PictureBox1.Location = New System.Drawing.Point(34, 46)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(108, 144)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox1.TabIndex = 1
        Me.PictureBox1.TabStop = False
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(32, 31)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(69, 12)
        Me.Label1.TabIndex = 2
        Me.Label1.Text = "Cover Image"
        '
        'TextBox_Cover
        '
        Me.TextBox_Cover.Location = New System.Drawing.Point(156, 48)
        Me.TextBox_Cover.Name = "TextBox_Cover"
        Me.TextBox_Cover.Size = New System.Drawing.Size(306, 19)
        Me.TextBox_Cover.TabIndex = 3
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(436, 71)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(27, 19)
        Me.Button1.TabIndex = 4
        Me.Button1.Text = "..."
        Me.Button1.UseVisualStyleBackColor = True
        '
        'Button2
        '
        Me.Button2.Enabled = False
        Me.Button2.Location = New System.Drawing.Point(371, 311)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(91, 30)
        Me.Button2.TabIndex = 5
        Me.Button2.Text = "Epub作成実行"
        Me.Button2.UseVisualStyleBackColor = True
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(153, 31)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(92, 12)
        Me.Label2.TabIndex = 6
        Me.Label2.Text = "Cover Image File"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(155, 99)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(54, 12)
        Me.Label3.TabIndex = 7
        Me.Label3.Text = "BookTitle"
        '
        'TextBox_Title
        '
        Me.TextBox_Title.Location = New System.Drawing.Point(158, 117)
        Me.TextBox_Title.Name = "TextBox_Title"
        Me.TextBox_Title.Size = New System.Drawing.Size(305, 19)
        Me.TextBox_Title.TabIndex = 8
        Me.TextBox_Title.Text = "アドベンチャーゲーム・ブック・サンプル"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(153, 151)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(41, 12)
        Me.Label4.TabIndex = 9
        Me.Label4.Text = "著者名"
        '
        'TextBox_Author
        '
        Me.TextBox_Author.Location = New System.Drawing.Point(158, 169)
        Me.TextBox_Author.Name = "TextBox_Author"
        Me.TextBox_Author.Size = New System.Drawing.Size(304, 19)
        Me.TextBox_Author.TabIndex = 10
        Me.TextBox_Author.Text = "名無しさん"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(155, 201)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(53, 12)
        Me.Label5.TabIndex = 11
        Me.Label5.Text = "出版社名"
        '
        'TextBox_Publisher
        '
        Me.TextBox_Publisher.Location = New System.Drawing.Point(159, 219)
        Me.TextBox_Publisher.Name = "TextBox_Publisher"
        Me.TextBox_Publisher.Size = New System.Drawing.Size(302, 19)
        Me.TextBox_Publisher.TabIndex = 12
        Me.TextBox_Publisher.Text = "あのにます"
        '
        'TextBox_uuid
        '
        Me.TextBox_uuid.Location = New System.Drawing.Point(155, 272)
        Me.TextBox_uuid.Name = "TextBox_uuid"
        Me.TextBox_uuid.Size = New System.Drawing.Size(303, 19)
        Me.TextBox_uuid.TabIndex = 13
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(155, 254)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(26, 12)
        Me.Label6.TabIndex = 14
        Me.Label6.Text = "uuid"
        '
        'TextBox_Info
        '
        Me.TextBox_Info.Location = New System.Drawing.Point(30, 318)
        Me.TextBox_Info.Name = "TextBox_Info"
        Me.TextBox_Info.Size = New System.Drawing.Size(329, 19)
        Me.TextBox_Info.TabIndex = 15
        Me.TextBox_Info.Text = "Information"
        '
        'TextBox_date
        '
        Me.TextBox_date.Location = New System.Drawing.Point(30, 271)
        Me.TextBox_date.Name = "TextBox_date"
        Me.TextBox_date.Size = New System.Drawing.Size(116, 19)
        Me.TextBox_date.TabIndex = 16
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(32, 255)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(27, 12)
        Me.Label7.TabIndex = 17
        Me.Label7.Text = "date"
        '
        'Form3
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(506, 395)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.TextBox_date)
        Me.Controls.Add(Me.TextBox_Info)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.TextBox_uuid)
        Me.Controls.Add(Me.TextBox_Publisher)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.TextBox_Author)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.TextBox_Title)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Button2)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.TextBox_Cover)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.PictureBox1)
        Me.Controls.Add(Me.ProgressBar1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "Form3"
        Me.Text = "Data Set Form"
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents ProgressBar1 As ProgressBar
    Friend WithEvents PictureBox1 As PictureBox
    Friend WithEvents Label1 As Label
    Friend WithEvents TextBox_Cover As TextBox
    Friend WithEvents Button1 As Button
    Friend WithEvents Button2 As Button
    Friend WithEvents Label2 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents TextBox_Title As TextBox
    Friend WithEvents Label4 As Label
    Friend WithEvents TextBox_Author As TextBox
    Friend WithEvents Label5 As Label
    Friend WithEvents TextBox_Publisher As TextBox
    Friend WithEvents TextBox_uuid As TextBox
    Friend WithEvents Label6 As Label
    Friend WithEvents TextBox_Info As TextBox
    Friend WithEvents TextBox_date As TextBox
    Friend WithEvents Label7 As Label
End Class
