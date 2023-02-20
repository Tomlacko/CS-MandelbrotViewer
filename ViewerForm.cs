using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static FinalProject.MandelbrotRenderer;

namespace FinalProject
{
	public partial class ViewerForm : Form
	{
		private bool stopped = true;
		private bool firstImageGenerated = false;

		private int width;
		private int height;


		private MandelbrotRenderer mandel;




		private void SetStoppedState(bool stop)
		{
			if(stop==stopped) return;

			if(stop) {// stop rendering
				btnRender.Text = "Render";
			}
			else {// start rendering
				btnRender.Text = "Stop";
			}

			stopped = stop;

			btnLoadCfg.Enabled = stop;
			btnSaveCfg.Enabled = stop;
			btnSaveImg.Enabled = stop && firstImageGenerated;
			inputX.Enabled = stop;
			inputY.Enabled = stop;
			inputZoom.Enabled = stop;
		}


		//runs in mandel's thread
		public void OnRenderFinished(object sender, RenderEventArgs e)
		{
			//runs on form's thread
			BeginInvoke(new Action( () => {
				imgBox.Image = e.result;
				firstImageGenerated = true;
				SetStoppedState(true);
			}));
		}



		public ViewerForm()
		{
			InitializeComponent();

			width = imgBox.Width;
			height = imgBox.Height;
			mandel = new MandelbrotRenderer(width, height);
			mandel.RenderFinished += OnRenderFinished;
		}

		private void Form1_Load(object sender, EventArgs e)
		{
			
		}

		private void btnRender_Click(object sender, EventArgs e)
		{
			if(stopped) {// start rendering
				double x, y, zoom;
				if(Double.TryParse(inputX.Text, out x) && Double.TryParse(inputY.Text, out y) && Double.TryParse(inputZoom.Text, out zoom)) {
					SetStoppedState(false);
					mandel.Render(x, y, zoom);
				}
			}
			else {// stop rendering
				SetStoppedState(true);
				mandel.Abort();
			}

			
			
		}

		private void btnSaveImg_Click(object sender, EventArgs e)
		{
			FileManipulation.SaveImageDialog(imgBox.Image);
		}

		private void btnSaveCfg_Click(object sender, EventArgs e)
		{
			FileManipulation.SaveTextFileDialog(inputX.Text + "\n" + inputY.Text + "\n" + inputZoom.Text);
		}

		private void btnLoadCfg_Click(object sender, EventArgs e)
		{
			string[] vals = FileManipulation.LoadTextFileDialog();
			if(vals.Length == 3) {
				inputX.Text = vals[0];
				inputY.Text = vals[1];
				inputZoom.Text = vals[2];
			}
		}
	}
}
