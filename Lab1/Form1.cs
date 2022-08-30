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
			Console.WriteLine("Hello");
		}

		// Gradient of Red to add to color written to panel.
		private void trackBar1_ValueChanged(object sender, EventArgs e)
		{
			Console.WriteLine(trackBar1.Value);
		}
		
		// To hold the X and Y points recorded on first click inside panel.
		int startX, startY;

		private void panel1_MouseDown(object sender, MouseEventArgs e)
		{
			// Record X and Y point to start creating shape from.
			startX = e.X;
			startY = e.Y;
		}

		private void panel1_MouseUp(object sender, MouseEventArgs e)
		{
			// Object to draw a new shape inside the panel.
			Graphics g = panel1.CreateGraphics();

			Pen pen = new Pen(Color.Red);
			g.DrawLine(pen, startX, startY, e.X, e.Y);
		}

		private void panel1_MouseMove(object sender, MouseEventArgs e)
		{
			
		}
	}
}
