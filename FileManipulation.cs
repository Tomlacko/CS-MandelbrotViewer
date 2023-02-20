using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;
using System.Drawing.Imaging;
using System.IO;

namespace FinalProject
{
	static class FileManipulation
	{
		/*public static bool OpenImageDialog(out Bitmap img)
		{
			OpenFileDialog dlg = new OpenFileDialog();
			dlg.Filter = "images| *.jpg; *.png; *.bmp";

			if(dlg.ShowDialog() == DialogResult.OK) {
				img = new Bitmap(Image.FromFile(dlg.FileName));
				return true;
			}
			img = null;
			return false;
		}*/

		public static bool SaveImageDialog(Image img)
		{
			SaveFileDialog dlg = new SaveFileDialog();
			dlg.Filter = "images| *.bmp";

			if(dlg.ShowDialog() == DialogResult.OK) {
				img.Save(dlg.FileName, ImageFormat.Png);
				return true;
			}
			return false;
		}

		public static bool SaveTextFileDialog(string text)
		{
			SaveFileDialog dlg = new SaveFileDialog();
			dlg.Filter = "Config file| *.cfg";

			if (dlg.ShowDialog() == DialogResult.OK) {
				File.WriteAllText(dlg.FileName, text);
				return true;
			}
			return false;
		}

		public static string[] LoadTextFileDialog()
		{
			OpenFileDialog dlg = new OpenFileDialog();
			dlg.Filter = "Config file| *.cfg;";

			if (dlg.ShowDialog() == DialogResult.OK)
			{
				return File.ReadAllLines(dlg.FileName);
			}
			return new string[0];
		}
	}
}
