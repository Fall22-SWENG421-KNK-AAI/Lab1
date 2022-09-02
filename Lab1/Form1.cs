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

		// To hold shape switch statement cases and color values.
		int type, red, blue, green;
		// To hold Shape to invoke method for.
		Shape shape;

		// These two are the image Graphics are drawn onto.
		Bitmap bg, fg; // bg is current state of panel images.
			       // fg is new state of panel images.
		// These are the where shapes are drawn onto.
		Graphics bgg, fgg; // bgg corresponds to bg Bitmap (current state image).
				   // fgg corresponds to fg Bitmap (new state image).
		Point start, end; // point for shape start and end
		bool down = false; // indicates if mouse is pressed down.

		// Get screen size to make size of buffer for shape drawing.
		// Found this code here: https://realmpkdotnet.wordpress.com/2014/01/05/get-the-current-screen-size-for-winforms-c/
		readonly int screenWidth = Screen.PrimaryScreen.Bounds.Width;
		readonly int screenHeight = Screen.PrimaryScreen.Bounds.Height;
		
		// On mouse click, initialize shape, and panel.
		private void panel1_MouseDown(object sender, MouseEventArgs e)
		{
			// Record starting Point of cursor when mouse clicked in Panel.
			start = e.Location;
			// Save current RGB slider values.
			PenColor pc = new PenColor(red, green, blue);
			// Determine which Shape button has been pressed.
			switch (type)
			{
				case 0: // Line
					// Initialize Line
					shape = new Line(pc, start);
					break;
				case 1: // Rectangle
					shape = new Rectangle(pc, start);
					break;
				case 2:  // Ellipse
					 // Initialize Ellipse
					shape = new Ellipse(pc, start);
					break;
				default:
					break;
			}

			down = true; // Set mouse to down.
			if (bg == null) // Background on Panel needs to be initialized.
			{
				// Set buffers equal to width of monitor.
				bg = new Bitmap(screenWidth, screenHeight); // Current panel state buffer.
				fg = new Bitmap(screenWidth, screenHeight); // New panel state buffer.

				// Create current state layer graphic based on the empty Bitmap image bg.
				bgg = Graphics.FromImage(bg);
				// C# idiosyncrasy to make sure panel shows blank.
				bgg.FillRectangle(Brushes.White, 0, 0, screenWidth, screenHeight);
				// Create new state layer graphic based on empty Bitmap image fg.
				fgg = Graphics.FromImage(fg);
			}
		}
		// Mouse moving, draw shape along with mouse movements.
		private void panel1_MouseMove(object sender, MouseEventArgs e)
		{
			if (down) // Mouse is pressed down.
			{
				// Draw the current image of the background Bitmap to the
				// foreground Graphics buffer.
				fgg.DrawImage(bg, 0, 0);
				// Record current position of mouse cursor.
				end = e.Location;
				if (shape != null)
				{
					shape.SetEndPoint(end);
				}
				// Call polymorphic method to draw appropiate shape in foreground.
				shape.DrawColoredShape(fgg);
				// Create a new graphics drawing object to draw with.
				Graphics g = panel1.CreateGraphics();
				// Draw the current foreground Bitmap to the new graphics object.
				g.DrawImage(fg, 0, 0);
			}
		}
		// Mouse released, draw last state of panel to background.
		private void panel1_MouseUp(object sender, MouseEventArgs e)
		{
			down = false; // Mouse click released.
			if (down == false)
			{       // Draw most up-to-date image (foreground image fg) Bitmap
				// to the Background Graphic (making it the most current image).
				bgg.DrawImage(fg, 0, 0);
			}
		}
		
		private void Form1_Resize(object sender, EventArgs e)
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
		// Each shape will be drawn with a color.
		private Color color;
		// Pen used to draw shapes.
		protected Pen pen;

		public Shape(PenColor c, Point start)
		{
			// Set start and end points for shape.
			this.start = start;

			// Set color to be used for drawing.
			SetColor(c);
			CreatePen();
		}
		// Required method from lab instructions which
		// each shape will implement.
		// Draws line by default.
		public virtual void DrawColoredShape(Graphics g)
		{
			Console.WriteLine("Drawing shape.");
		}
		// Setter for end point which is determined after initialization of shape.
		public void SetEndPoint(Point p)
		{
			end = p;
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
		// Getter and setter for RGB color.
		public void SetColor(PenColor c)
		{
			color = Color.FromArgb(c.Red, c.Green, c.Blue);
		}
		// Create pen for drawing.
		public void CreatePen()
		{
			pen = new Pen(color);
		}
	}

	public class Line : Shape
	{
		// Constructor
		public Line(PenColor c, Point s) : base(c, s)
		{
			Console.WriteLine("Initializing line.");
		}
		// Draw Line
		public override void DrawColoredShape(Graphics g)
		{
			g.DrawLine(pen, start, end);
		}
	}

	public class Rectangle : Shape
	{
		// Constructor
		public Rectangle(PenColor c, Point s) : base( c, s)
		{
			Console.WriteLine("Initializing rectangle.");
		}
		// Draw Rectangle.
		// Note: because of how DrawRectangle is implemented, it is only
		//	 possible to draw down and/or to the right of where the click
		//	 is initiated.
		public override void DrawColoredShape(Graphics g)
		{
			g.DrawRectangle(pen, start.X, start.Y, (int)GetWidth(), (int)GetHeight());
		}
	}

	public class Ellipse : Shape
	{
		// Constructor
		public Ellipse(PenColor c, Point s) : base( c, s)
		{
			Console.WriteLine("Initializing ellipse.");
		}
		// Draw Ellipse
		public override void DrawColoredShape(Graphics g)
		{
			g.DrawEllipse(pen, start.X, start.Y, (int)GetWidth(), (int)GetHeight());
		}
	}
}
