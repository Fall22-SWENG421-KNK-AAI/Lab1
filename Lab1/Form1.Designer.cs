
namespace Lab1
{
	partial class Form1
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
            this.LineButton = new System.Windows.Forms.Button();
            this.RecButton = new System.Windows.Forms.Button();
            this.RedBar = new System.Windows.Forms.TrackBar();
            this.GreenBar = new System.Windows.Forms.TrackBar();
            this.BlueBar = new System.Windows.Forms.TrackBar();
            this.panel1 = new System.Windows.Forms.Panel();
            this.EllipButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.RedBar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GreenBar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.BlueBar)).BeginInit();
            this.SuspendLayout();
            // 
            // LineButton
            // 
            this.LineButton.Location = new System.Drawing.Point(39, 39);
            this.LineButton.Margin = new System.Windows.Forms.Padding(4);
            this.LineButton.Name = "LineButton";
            this.LineButton.Size = new System.Drawing.Size(100, 28);
            this.LineButton.TabIndex = 0;
            this.LineButton.Text = "Line";
            this.LineButton.UseVisualStyleBackColor = true;
            this.LineButton.Click += new System.EventHandler(this.button1_Click);
            // 
            // RecButton
            // 
            this.RecButton.Location = new System.Drawing.Point(147, 39);
            this.RecButton.Margin = new System.Windows.Forms.Padding(4);
            this.RecButton.Name = "RecButton";
            this.RecButton.Size = new System.Drawing.Size(100, 28);
            this.RecButton.TabIndex = 1;
            this.RecButton.Text = "Rectangle";
            this.RecButton.UseVisualStyleBackColor = true;
            this.RecButton.Click += new System.EventHandler(this.RecButton_Click);
            // 
            // RedBar
            // 
            this.RedBar.BackColor = System.Drawing.Color.Red;
            this.RedBar.Location = new System.Drawing.Point(389, 23);
            this.RedBar.Margin = new System.Windows.Forms.Padding(4);
            this.RedBar.Maximum = 255;
            this.RedBar.Name = "RedBar";
            this.RedBar.Size = new System.Drawing.Size(136, 56);
            this.RedBar.TabIndex = 2;
            this.RedBar.Scroll += new System.EventHandler(this.RedBar_Scroll);
            this.RedBar.ValueChanged += new System.EventHandler(this.trackBar1_ValueChanged);
            // 
            // GreenBar
            // 
            this.GreenBar.BackColor = System.Drawing.Color.Green;
            this.GreenBar.Location = new System.Drawing.Point(533, 23);
            this.GreenBar.Margin = new System.Windows.Forms.Padding(4);
            this.GreenBar.Maximum = 255;
            this.GreenBar.Name = "GreenBar";
            this.GreenBar.Size = new System.Drawing.Size(129, 56);
            this.GreenBar.TabIndex = 3;
            this.GreenBar.Scroll += new System.EventHandler(this.GreenBar_Scroll);
            this.GreenBar.ValueChanged += new System.EventHandler(this.GreenBar_ValueChanged);
            // 
            // BlueBar
            // 
            this.BlueBar.BackColor = System.Drawing.Color.Blue;
            this.BlueBar.Location = new System.Drawing.Point(670, 23);
            this.BlueBar.Margin = new System.Windows.Forms.Padding(4);
            this.BlueBar.Maximum = 255;
            this.BlueBar.Name = "BlueBar";
            this.BlueBar.Size = new System.Drawing.Size(126, 56);
            this.BlueBar.TabIndex = 5;
            this.BlueBar.Scroll += new System.EventHandler(this.BlueBar_Scroll);
            this.BlueBar.ValueChanged += new System.EventHandler(this.BlueBar_ValueChanged);
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.panel1.Location = new System.Drawing.Point(13, 87);
            this.panel1.Margin = new System.Windows.Forms.Padding(4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(783, 340);
            this.panel1.TabIndex = 6;
            this.panel1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.panel1_MouseDown);
            this.panel1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.panel1_MouseMove);
            this.panel1.MouseUp += new System.Windows.Forms.MouseEventHandler(this.panel1_MouseUp);
            // 
            // EllipButton
            // 
            this.EllipButton.Location = new System.Drawing.Point(255, 39);
            this.EllipButton.Margin = new System.Windows.Forms.Padding(4);
            this.EllipButton.Name = "EllipButton";
            this.EllipButton.Size = new System.Drawing.Size(100, 28);
            this.EllipButton.TabIndex = 7;
            this.EllipButton.Text = "Ellipse";
            this.EllipButton.UseVisualStyleBackColor = true;
            this.EllipButton.Click += new System.EventHandler(this.EllipButton_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(809, 440);
            this.Controls.Add(this.EllipButton);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.BlueBar);
            this.Controls.Add(this.GreenBar);
            this.Controls.Add(this.RedBar);
            this.Controls.Add(this.RecButton);
            this.Controls.Add(this.LineButton);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.RedBar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GreenBar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.BlueBar)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Button LineButton;
		private System.Windows.Forms.Button RecButton;
		private System.Windows.Forms.TrackBar RedBar;
		private System.Windows.Forms.TrackBar GreenBar;
		private System.Windows.Forms.TrackBar BlueBar;
		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.Button EllipButton;
	}
}

