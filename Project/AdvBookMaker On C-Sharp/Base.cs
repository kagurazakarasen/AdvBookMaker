using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static AdvBookMaker.Util;

namespace AdvBookMaker {
	public partial class Base : Form {
		private AdvBookMakerProject CurrentProjectData = new AdvBookMakerProject(Environment.CurrentDirectory + "/Projects");

		public Base() {
			InitializeComponent();
		}

		private void MenuBar_File_Open_Click(object sender, EventArgs e) {
			if (OpenAdvBookMakerProjectDialog.ShowDialog() == DialogResult.Cancel) {
				this.CurrentProjectData = new AdvBookMakerProject(OpenAdvBookMakerProjectDialog.FileName);
			} else {
				
			}
		}

		private void MenuBar_File_Save_Click(object sender, EventArgs e) {
			SaveAdvBookMakerProjectDialog.ShowDialog();
			AdvBookMakerProject Project = new AdvBookMakerProject();
		}

		private void Manager_Editor_AddScene_Click(object sender, EventArgs e) {

		}
	}
}
