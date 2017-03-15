using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AdvGameBookMaker {
	public partial class Base : Form {
		public Base() {
			InitializeComponent();
		}

		private void Manager_Editor_AddScene_Click(object Sender, EventArgs Event) {
			Console.WriteLine(this.Manager_Editor_SceneContent.Text);
		}
	}
}
