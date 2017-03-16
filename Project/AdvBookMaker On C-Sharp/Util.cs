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



			private void ProjectInit() {
				
			}

			public void Open() {
				
			}

			public void Create() {
				Directory.CreateDirectory(Directory.GetParent(this.Path).FullName);
				File.Create(this.Path);

				this.ProjectInit();
			}

			public void Delete() {
				File.Delete(this.Path);
			}



			public void setPath(String FilePath) { this.Path = FilePath; }
			public String getPath() { return this.Path; }

			public void setData(DataGridView View) { this.Data = View; }
			public DataGridView getData() { return this.Data; }
		}
	}
}
