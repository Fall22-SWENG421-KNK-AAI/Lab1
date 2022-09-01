using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab1
{
	// Contains main logic of application.
	public partial class Form1 : Form
	{
		// Creates starting state of application GUI.
		public Form1()
		{
			InitializeComponent();
		}

		// Select line class and create line on mouse clicks inside panel.
		private void button1_Click(object sender, EventArgs e)
		{
			type = 0;
		}

		private void RecButton_Click(object sender, EventArgs e)
		{
			type = 1;
		}

		private void EllipButton_Click(object sender, EventArgs e)
		{
			type = 2;
		}

		// Gradient of Red to add to color written to panel.
		private void trackBar1_ValueChanged(object sender, EventArgs e)
		{
			red = RedBar.Value;
		}
		// Gradient of Blue to add to color written to panel.
		private void BlueBar_ValueChanged(object sender, EventArgs e)
		{
			blue = BlueBar.Value;
		}
		// Gradient of Green to add to color written to panel.
		private void GreenBar_ValueChanged(object sender, EventArgs e)
		{
			green = GreenBar.Value;
		}
		
		private void RedBar_Scroll(object sender, EventArgs e)
		{
			
		}

		private void BlueBar_Scroll(object sender, EventArgs e)
		{
			
		}

		private void GreenBar_Scroll(object sender, EventArgs e)
		{
			
		}

		// To hold the X and Y points recorded on first click inside panel and release.
		int startX, startY, endX, endY;
		// To hold switch cases and color values.
		int type, red, blue, green;


        private void panel1_MouseDown(object sender, MouseEventArgs e)
		{
			// Record X and Y point to start creating shape from.
			startX = e.X;
			startY = e.Y;
		}

		private void panel1_MouseUp(object sender, MouseEventArgs e)
		{
			// Record X and Y point at end of creating shape.
			endX = e.X;
			endY = e.Y;

			// Object to draw a new shape inside the panel.
			Graphics g = panel1.CreateGraphics();
			Pen pen = new Pen(Color.FromArgb(red, green, blue));

			// switch used for buttons
			switch (type)
			{
				case 0:  // draw line                 
					g.DrawLine(pen, startX, startY, endX, endY);
					break;
				case 1:  // draw rectangle
					g.DrawRectangle(pen, startX, startY, endX - startX, endY - startY);
					break;
				case 2:  // draw cirlce
					g.DrawEllipse(pen, startX, startY, endX - startX, endY - startY);
					break;
				default:
					break;
			}
		}
		private void panel1_MouseMove(object sender, MouseEventArgs e)
		{
			
		}
	}
}
