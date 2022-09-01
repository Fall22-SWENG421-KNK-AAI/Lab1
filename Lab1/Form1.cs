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

			// Set start and end Points
			Point start = new Point(startX, startY);
			Point end = new Point(endX, endY);
			// Create color
			PenColor pc = new PenColor(red, green, blue);

			// switch used for buttons
			switch (type)
			{
				case 0: // Line
					// Initialize Line
					Line line = new Line(panel1, pc, start, end);
					// Draw line
					line.DrawColoredShape();
					break;
				case 1: // Rectangle
					Rectangle rect = new Rectangle(panel1, pc, start, end);
					// Draw rectangle
					rect.DrawColoredShape();
					break;
				case 2:  // Ellipse
					 // Initialize Ellipse
					Ellipse ell = new Ellipse(panel1, pc, start, end);
					// Draw Ellipse
					ell.DrawColoredShape();
					break;
				default:
					break;
			}
		}
		private void panel1_MouseMove(object sender, MouseEventArgs e)
		{
			
		}
	}

	// Struct for color to be used with pen and Shape.
	public struct PenColor
	{
		public PenColor(int r, int g, int b)
		{
			Red = r;
			Green = g;
			Blue = b;
		}
		
		public int Red { get; }
		public int Green { get;  }
		public int Blue { get; }
	}
	
	// The base class that Line, Rectangle, and Ellipse inherit from.
	public class Shape
	{
		// Raw coordinates of shapes.
		protected Point start, end;
		// For area calculations of shapes.
		private double height, width;
		// To represent the object to be drawn on the screen.
		protected Graphics shape;
		// Each shape will be drawn with a color.
		private Color color;
		// Pen used to draw shapes.
		protected Pen pen;

		public Shape(Panel p, PenColor c, Point start, Point end)
		{
			// Set color to be used for drawing.
			SetColor(c);
			// Set start and end points for shape.
			this.start = start;
			this.end = end;
			CreatePen();
			// Create graphics object to place on canvas.
			CreateGraphic(p);
		}

		// Computes area of shape and depends on shape.
		// Generic action is to return area of rectangle.
		public virtual double Area()
		{
			return height * width;
		}
		// Required method from lab instructions which
		// each shape will implement.
		public virtual void DrawColoredShape()
		{
			Console.WriteLine("Drawing shape.");
		}
		// Setter for points to use when drawing shape.
		public void SetStartPoint(int x, int y)
		{
			start.X = x;
			start.Y = y;
		}
		public void SetEndPoint(int x, int y)
		{
			end.X = x;
			end.Y = y;
		}
		// Both of the methods below are used to calculate the Area
		// of shapes.
		public double GetHeight()
		{
			return end.Y - start.Y;
		}
		public double GetWidth()
		{
			return end.X - start.X;
		}
		public void SetHeight()
		{
			height = GetHeight();
		}
		public void SetWidth()
		{
			width = GetWidth();
		}
		// Getter and setter for RGB color.
		public Color GetColor()
		{
			return color;
		}
		public void SetColor(PenColor c)
		{
			color = Color.FromArgb(c.Red, c.Green, c.Blue);
		}
		// Create pen for drawing.
		public void CreatePen()
		{
			pen = new Pen(color);
		}
		// Create graphic for placing on canvas.
		public void CreateGraphic(Panel panel)
		{
			shape = panel.CreateGraphics();
		}
	}

	public class Line : Shape
	{
		// Constructor
		public Line(Panel p, PenColor c, Point s, Point e) : base(p, c, s, e)
		{
			Console.WriteLine("Initializing line.");
		}
		// Calculate length of line (area of line).
		public override double Area()
		{
			// Use pythagorean theorem to calculate hypotenuse.
			// If line is on a slant this will return correct.
			// If line is vertical or horizontal it will still return correct.
			double c = Math.Sqrt(Math.Pow(GetHeight(), 2) + Math.Pow(GetWidth(), 2));
			// Line has width of 1 so just return it's length.
			return c;
		}

		// Draw Line
		public override void DrawColoredShape()
		{
			shape.DrawLine(pen, start, end);
		}
	}

	public class Rectangle : Shape
	{
		// Constructor
		public Rectangle(Panel p, PenColor c, Point s, Point e) : base(p, c, s, e)
		{
			Console.WriteLine("Initializing rectangle.");
		}
		// Calculate area of rectangular shape.
		public override double Area()
		{
			// Rectangle area formula.
			return GetHeight() * GetWidth();
		}
		// Draw Rectangle
		public override void DrawColoredShape()
		{
			shape.DrawRectangle(pen, start.X, start.Y, (int)GetWidth(), (int)GetHeight());
		}
	}

	public class Ellipse : Shape
	{
		// Constructor
		public Ellipse(Panel p, PenColor c, Point s, Point e) : base(p, c, s, e)
		{
			Console.WriteLine("Initializing ellipse.");
		}
		// Calculate area of elliptical shape.
		public override double Area()
		{
			// Ellipse area formula taken from: https://math.hmc.edu/funfacts/area-of-an-ellipse/
			double halfHeight = GetHeight() / 2;
			double halfWidth = GetWidth() / 2;
			return Math.PI * halfHeight * halfWidth;
		}
		// Draw Ellipse
		public override void DrawColoredShape()
		{
			shape.DrawEllipse(pen, start.X, start.Y, (int)GetWidth(), (int)GetHeight());
		}
	}
}
