using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AdvBookMaker {
	public class Util {
		protected internal class AdvBookMakerProject {
			private String Path = Directory.GetCurrentDirectory() + "/Untitled.project";
			private DataGridView Data = new DataGridView();



			public AdvBookMakerProject() {
				
			}

			public AdvBookMakerProject(String FilePath) {
				this.Path = FilePath;
			}

			public AdvBookMakerProject(String FilePath, DataGridView View) {
				this.Path = FilePath;
				this.Data = View;
			}
			


			public void Create() {
				Directory.CreateDirectory(this.Path);
				File.Create(Path);
			}

			public void setData(DataGridView View) {
				this.Data = View;
			}
		}
	}
}
