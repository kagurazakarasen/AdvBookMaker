using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AdvBookMaker {
	public static class AdvBookMakerProject {
		public static void Get(String Path) {
			String Raw = File.ReadAllText(Path, Encoding.UTF8);

			Array[,] Data = {
				{
					
				}
			};

			for (int i = 0; i < Raw.Split('\t').Length; i++) {
				Console.WriteLine("☮==========☮");
				Console.WriteLine(Raw.Split('\t')[i].Replace("<BR/>", "\n"));
			}
		}

		public static void Create(String Path) {
			File.Create(Path);
		}
	}
}
