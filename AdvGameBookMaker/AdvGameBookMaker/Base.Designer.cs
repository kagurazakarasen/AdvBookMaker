namespace AdvGameBookMaker {
	partial class Base {
		/// <summary>
		/// 必要なデザイナー変数です。
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// 使用中のリソースをすべてクリーンアップします。
		/// </summary>
		/// <param name="disposing">マネージ リソースを破棄する場合は true を指定し、その他の場合は false を指定します。</param>
		protected override void Dispose(bool disposing) {
			if (disposing && (components != null)) {
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows フォーム デザイナーで生成されたコード

		/// <summary>
		/// デザイナー サポートに必要なメソッドです。このメソッドの内容を
		/// コード エディターで変更しないでください。
		/// </summary>
		private void InitializeComponent() {
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Base));
			this.MenuBar = new System.Windows.Forms.MenuStrip();
			this.MenuBar_File = new System.Windows.Forms.ToolStripMenuItem();
			this.MenuBar_File_New = new System.Windows.Forms.ToolStripMenuItem();
			this.MenuBar_File_Open = new System.Windows.Forms.ToolStripMenuItem();
			this.MenuBar_File_Save = new System.Windows.Forms.ToolStripMenuItem();
			this.MenuBar_Publish = new System.Windows.Forms.ToolStripMenuItem();
			this.MenuBar_Publish_HTML = new System.Windows.Forms.ToolStripMenuItem();
			this.MenuBar_Publish_ePubFormat = new System.Windows.Forms.ToolStripMenuItem();
			this.Manager = new System.Windows.Forms.TabControl();
			this.Manager_Editor = new System.Windows.Forms.TabPage();
			this.Manager_Editor_AddScene = new System.Windows.Forms.Button();
			this.Manager_Editor_SceneList_L = new System.Windows.Forms.Label();
			this.Manager_Editor_Choices = new System.Windows.Forms.GroupBox();
			this.Manager_Editor_SceneList = new System.Windows.Forms.ListBox();
			this.Manager_Editor_SceneContent = new System.Windows.Forms.TextBox();
			this.Manager_Editor_SceneName_L = new System.Windows.Forms.Label();
			this.Manager_Editor_SceneName = new System.Windows.Forms.TextBox();
			this.Manager_Scenes = new System.Windows.Forms.TabPage();
			this.Data = new System.Windows.Forms.DataGridView();
			this.Manager_Scenes_Data_Scene = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.Manager_Scenes_Data_Contents = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.Manager_Scenes_Data_Choice1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.Manager_Scenes_Data_Choice1_Link = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.Version = new System.Windows.Forms.Label();
			this.MenuBar.SuspendLayout();
			this.Manager.SuspendLayout();
			this.Manager_Editor.SuspendLayout();
			this.Manager_Scenes.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.Data)).BeginInit();
			this.SuspendLayout();
			// 
			// MenuBar
			// 
			this.MenuBar.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MenuBar_File,
            this.MenuBar_Publish});
			resources.ApplyResources(this.MenuBar, "MenuBar");
			this.MenuBar.Name = "MenuBar";
			// 
			// MenuBar_File
			// 
			this.MenuBar_File.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MenuBar_File_New,
            this.MenuBar_File_Open,
            this.MenuBar_File_Save});
			this.MenuBar_File.Name = "MenuBar_File";
			resources.ApplyResources(this.MenuBar_File, "MenuBar_File");
			// 
			// MenuBar_File_New
			// 
			this.MenuBar_File_New.Name = "MenuBar_File_New";
			resources.ApplyResources(this.MenuBar_File_New, "MenuBar_File_New");
			// 
			// MenuBar_File_Open
			// 
			this.MenuBar_File_Open.Name = "MenuBar_File_Open";
			resources.ApplyResources(this.MenuBar_File_Open, "MenuBar_File_Open");
			// 
			// MenuBar_File_Save
			// 
			this.MenuBar_File_Save.Name = "MenuBar_File_Save";
			resources.ApplyResources(this.MenuBar_File_Save, "MenuBar_File_Save");
			this.MenuBar_File_Save.Click += new System.EventHandler(this.MenuBar_File_Save_Click);
			// 
			// MenuBar_Publish
			// 
			this.MenuBar_Publish.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MenuBar_Publish_HTML,
            this.MenuBar_Publish_ePubFormat});
			this.MenuBar_Publish.Name = "MenuBar_Publish";
			resources.ApplyResources(this.MenuBar_Publish, "MenuBar_Publish");
			// 
			// MenuBar_Publish_HTML
			// 
			this.MenuBar_Publish_HTML.Image = global::AdvGameBookMaker.Properties.Resources.MenuBar_Publish_HTMLFormat;
			this.MenuBar_Publish_HTML.Name = "MenuBar_Publish_HTML";
			resources.ApplyResources(this.MenuBar_Publish_HTML, "MenuBar_Publish_HTML");
			// 
			// MenuBar_Publish_ePubFormat
			// 
			this.MenuBar_Publish_ePubFormat.Image = global::AdvGameBookMaker.Properties.Resources.MenuBar_Publish_ePubFormat;
			this.MenuBar_Publish_ePubFormat.Name = "MenuBar_Publish_ePubFormat";
			resources.ApplyResources(this.MenuBar_Publish_ePubFormat, "MenuBar_Publish_ePubFormat");
			// 
			// Manager
			// 
			resources.ApplyResources(this.Manager, "Manager");
			this.Manager.Controls.Add(this.Manager_Editor);
			this.Manager.Controls.Add(this.Manager_Scenes);
			this.Manager.Name = "Manager";
			this.Manager.SelectedIndex = 0;
			// 
			// Manager_Editor
			// 
			this.Manager_Editor.Controls.Add(this.Manager_Editor_AddScene);
			this.Manager_Editor.Controls.Add(this.Manager_Editor_SceneList_L);
			this.Manager_Editor.Controls.Add(this.Manager_Editor_Choices);
			this.Manager_Editor.Controls.Add(this.Manager_Editor_SceneList);
			this.Manager_Editor.Controls.Add(this.Manager_Editor_SceneContent);
			this.Manager_Editor.Controls.Add(this.Manager_Editor_SceneName_L);
			this.Manager_Editor.Controls.Add(this.Manager_Editor_SceneName);
			resources.ApplyResources(this.Manager_Editor, "Manager_Editor");
			this.Manager_Editor.Name = "Manager_Editor";
			this.Manager_Editor.UseVisualStyleBackColor = true;
			// 
			// Manager_Editor_AddScene
			// 
			resources.ApplyResources(this.Manager_Editor_AddScene, "Manager_Editor_AddScene");
			this.Manager_Editor_AddScene.Name = "Manager_Editor_AddScene";
			this.Manager_Editor_AddScene.UseVisualStyleBackColor = true;
			this.Manager_Editor_AddScene.Click += new System.EventHandler(this.Manager_Editor_AddScene_Click);
			// 
			// Manager_Editor_SceneList_L
			// 
			resources.ApplyResources(this.Manager_Editor_SceneList_L, "Manager_Editor_SceneList_L");
			this.Manager_Editor_SceneList_L.Name = "Manager_Editor_SceneList_L";
			// 
			// Manager_Editor_Choices
			// 
			resources.ApplyResources(this.Manager_Editor_Choices, "Manager_Editor_Choices");
			this.Manager_Editor_Choices.Name = "Manager_Editor_Choices";
			this.Manager_Editor_Choices.TabStop = false;
			// 
			// Manager_Editor_SceneList
			// 
			resources.ApplyResources(this.Manager_Editor_SceneList, "Manager_Editor_SceneList");
			this.Manager_Editor_SceneList.FormattingEnabled = true;
			this.Manager_Editor_SceneList.Name = "Manager_Editor_SceneList";
			// 
			// Manager_Editor_SceneContent
			// 
			resources.ApplyResources(this.Manager_Editor_SceneContent, "Manager_Editor_SceneContent");
			this.Manager_Editor_SceneContent.Name = "Manager_Editor_SceneContent";
			// 
			// Manager_Editor_SceneName_L
			// 
			resources.ApplyResources(this.Manager_Editor_SceneName_L, "Manager_Editor_SceneName_L");
			this.Manager_Editor_SceneName_L.Name = "Manager_Editor_SceneName_L";
			// 
			// Manager_Editor_SceneName
			// 
			resources.ApplyResources(this.Manager_Editor_SceneName, "Manager_Editor_SceneName");
			this.Manager_Editor_SceneName.Name = "Manager_Editor_SceneName";
			// 
			// Manager_Scenes
			// 
			this.Manager_Scenes.Controls.Add(this.Data);
			resources.ApplyResources(this.Manager_Scenes, "Manager_Scenes");
			this.Manager_Scenes.Name = "Manager_Scenes";
			this.Manager_Scenes.UseVisualStyleBackColor = true;
			// 
			// Data
			// 
			this.Data.AllowUserToOrderColumns = true;
			resources.ApplyResources(this.Data, "Data");
			this.Data.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.Data.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Manager_Scenes_Data_Scene,
            this.Manager_Scenes_Data_Contents,
            this.Manager_Scenes_Data_Choice1,
            this.Manager_Scenes_Data_Choice1_Link});
			this.Data.Name = "Data";
			this.Data.RowTemplate.Height = 21;
			// 
			// Manager_Scenes_Data_Scene
			// 
			resources.ApplyResources(this.Manager_Scenes_Data_Scene, "Manager_Scenes_Data_Scene");
			this.Manager_Scenes_Data_Scene.Name = "Manager_Scenes_Data_Scene";
			// 
			// Manager_Scenes_Data_Contents
			// 
			resources.ApplyResources(this.Manager_Scenes_Data_Contents, "Manager_Scenes_Data_Contents");
			this.Manager_Scenes_Data_Contents.Name = "Manager_Scenes_Data_Contents";
			// 
			// Manager_Scenes_Data_Choice1
			// 
			resources.ApplyResources(this.Manager_Scenes_Data_Choice1, "Manager_Scenes_Data_Choice1");
			this.Manager_Scenes_Data_Choice1.Name = "Manager_Scenes_Data_Choice1";
			// 
			// Manager_Scenes_Data_Choice1_Link
			// 
			resources.ApplyResources(this.Manager_Scenes_Data_Choice1_Link, "Manager_Scenes_Data_Choice1_Link");
			this.Manager_Scenes_Data_Choice1_Link.Name = "Manager_Scenes_Data_Choice1_Link";
			// 
			// Version
			// 
			resources.ApplyResources(this.Version, "Version");
			this.Version.Name = "Version";
			// 
			// Base
			// 
			resources.ApplyResources(this, "$this");
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add(this.Version);
			this.Controls.Add(this.Manager);
			this.Controls.Add(this.MenuBar);
			this.MainMenuStrip = this.MenuBar;
			this.Name = "Base";
			this.MenuBar.ResumeLayout(false);
			this.MenuBar.PerformLayout();
			this.Manager.ResumeLayout(false);
			this.Manager_Editor.ResumeLayout(false);
			this.Manager_Editor.PerformLayout();
			this.Manager_Scenes.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.Data)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.MenuStrip MenuBar;
		private System.Windows.Forms.ToolStripMenuItem MenuBar_File;
		private System.Windows.Forms.ToolStripMenuItem MenuBar_Publish;
		private System.Windows.Forms.TabControl Manager;
		private System.Windows.Forms.TabPage Manager_Editor;
		private System.Windows.Forms.TabPage Manager_Scenes;
		private System.Windows.Forms.Label Manager_Editor_SceneName_L;
		private System.Windows.Forms.TextBox Manager_Editor_SceneName;
		private System.Windows.Forms.TextBox Manager_Editor_SceneContent;
		private System.Windows.Forms.ListBox Manager_Editor_SceneList;
		private System.Windows.Forms.ToolStripMenuItem MenuBar_File_New;
		private System.Windows.Forms.ToolStripMenuItem MenuBar_File_Open;
		private System.Windows.Forms.ToolStripMenuItem MenuBar_File_Save;
		private System.Windows.Forms.ToolStripMenuItem MenuBar_Publish_HTML;
		private System.Windows.Forms.ToolStripMenuItem MenuBar_Publish_ePubFormat;
		private System.Windows.Forms.GroupBox Manager_Editor_Choices;
		private System.Windows.Forms.Label Manager_Editor_SceneList_L;
		private System.Windows.Forms.DataGridView Data;
		private System.Windows.Forms.Label Version;
		private System.Windows.Forms.Button Manager_Editor_AddScene;
		private System.Windows.Forms.DataGridViewTextBoxColumn Manager_Scenes_Data_Scene;
		private System.Windows.Forms.DataGridViewTextBoxColumn Manager_Scenes_Data_Contents;
		private System.Windows.Forms.DataGridViewTextBoxColumn Manager_Scenes_Data_Choice1;
		private System.Windows.Forms.DataGridViewTextBoxColumn Manager_Scenes_Data_Choice1_Link;
	}
}

