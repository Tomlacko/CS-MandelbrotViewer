using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FinalProject
{
	public class MandelbrotRenderer
	{
		public class RenderEventArgs : EventArgs
		{
			public readonly Bitmap result;

			public RenderEventArgs(Bitmap img)
			{
				result = img;
			}
		}



		private int width;
		private int height;

		private int midX;
		private int midY;


		private double zoom;
		private double xPos;
		private double yPos;


		bool running = false;

		private Thread thr;



		public MandelbrotRenderer(int width, int height)
		{
			this.width = width;
			this.height = height;
			midX = width/2;
			midY = height/2;
		}



		private void MultiRender()
		{
			Bitmap img = new Bitmap(width, height, PixelFormat.Format24bppRgb);

			unsafe
			{
				BitmapData data = img.LockBits(new Rectangle(0, 0, width, height), ImageLockMode.WriteOnly, img.PixelFormat);

				int bytesPerPixel = Bitmap.GetPixelFormatSize(img.PixelFormat) / 8; //3
				int dataHeight = data.Height;
				int widthInBytes = data.Width * bytesPerPixel;

				byte* begin = (byte*)data.Scan0;


				Parallel.For(0, dataHeight, y => {
					byte* line = begin + y*data.Stride;

					for(int x = 0; x < widthInBytes; x += bytesPerPixel) {
						double x0 = (x/bytesPerPixel - midX)/zoom + xPos;
						double y0 = (y - midY)/zoom + yPos;

						(int r, int g, int b) = ComputePosition(x0, y0);

						line[x+2] = (byte)r;
						line[x+1] = (byte)g;
						line[x] = (byte)b;
					}
				});


				img.UnlockBits(data);
			}


			OnRenderFinished(img);
		}


		public void Render(double _x, double _y, double zoom)
		{
			if(running) return;
			running = true;

			xPos = _x;
			yPos = _y;
			this.zoom = zoom;

			thr = new Thread(new ThreadStart(MultiRender));
			thr.Start();
		}

		public void Abort()
		{
			if(!running) return;
			thr.Abort();
			running = false;
		}


		//Event handler delegate
		public event EventHandler<RenderEventArgs> RenderFinished;

		//Event publisher
		protected virtual void OnRenderFinished(Bitmap img)
		{
			running = false;
			RenderFinished?.Invoke(this, new RenderEventArgs(img));
		}





		
		private const int MAX_ITER_COUNT = 1024;

		private static (int, int, int) ComputePosition(double x, double y)
		{
			double a = 0;
			double b = 0;
			double rx = 0;
			double ry = 0;
			int iters = 0;

			while((iters < MAX_ITER_COUNT) && (rx*rx + ry*ry <= 4))
			{
				rx = a*a - b*b + x;
				ry = 2*a*b + y;
				a = rx;
				b = ry;

				iters++;
			}
			
			return GetColoring(iters);
		}




		//there seems to be some error that produces somewhat wrong colors, but don't have any more time to fix it :/

		private const int COLOR_JUMP = 4;

		private static (int, int, int) GetColoring(int iters)
		{
			int colorVal = 255 - Math.Abs(256 - (((iters/COLOR_JUMP)*COLOR_JUMP)%512)); //make the colors wrap back and forth
			float h = (iters - 1) / (MAX_ITER_COUNT/COLOR_JUMP - 1); //fit to 0-1 range
			float sv = (float)colorVal/255;

			return HSVtoRGB(h, sv, sv);
		}
		
		private static (int, int, int) HSVtoRGB(float h, float s, float val) //ranges 0-1
		{
			int v = (int)Math.Round(val*255);

			int k = (int)Math.Floor(h*6);
			float f = h*6 - k;
			
			int p = (int)Math.Round(v*(1 - s));
			int q = (int)Math.Round(v*(1 - f*s));
			int t = (int)Math.Round(v*(1 - (1-f)*s));

			switch(k%6)
			{
				case 0:
					return (v, t, p);
				case 1:
					return (q, v, p);
				case 2:
					return (p, v, t);
				case 3:
					return (p, q, v);
				case 4:
					return (t, p, v);
				default:
					return (v, p, q);
			}
		}
	}
}
