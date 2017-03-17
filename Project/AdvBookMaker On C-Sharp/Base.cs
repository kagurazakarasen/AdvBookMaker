using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AdvBookMaker {
	public partial class Base : Form {
		public Base() {
			InitializeComponent();

			Version.Text += System.Reflection.Assembly.GetExecutingAssembly().GetName().Version.ToString();
		}

		private void MenuBar_File_Open_Click(object sender, EventArgs e) {
			if (OpenAdvBookMakerProjectDialog.ShowDialog() == DialogResult.OK) {
				AdvBookMakerProject.Get(OpenAdvBookMakerProjectDialog.FileName);
			}
		}

		private void MenuBar_File_Save_Click(object sender, EventArgs e) {
			if (SaveAdvBookMakerProjectDialog.ShowDialog() == DialogResult.OK) {
				AdvBookMakerProject.Create(SaveAdvBookMakerProjectDialog.FileName);
			}
		}

		private void Manager_Editor_AddScene_Click(object sender, EventArgs e) {
			if (Manager_Editor_SceneName.Text != "") {
				SceneData.Add(Manager_Editor_SceneName.Text);
			}
		}
	}
}
