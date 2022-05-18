
namespace VPWStudio
{
	partial class TimTester
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
			this.pictureBox1 = new System.Windows.Forms.PictureBox();
			this.menuStrip1 = new System.Windows.Forms.MenuStrip();
			this.loadTIMToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.cLUTToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.nextPaletteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.previousPaletteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
			this.menuStrip1.SuspendLayout();
			this.SuspendLayout();
			// 
			// pictureBox1
			// 
			this.pictureBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.pictureBox1.Location = new System.Drawing.Point(12, 27);
			this.pictureBox1.MaximumSize = new System.Drawing.Size(1024, 1024);
			this.pictureBox1.Name = "pictureBox1";
			this.pictureBox1.Size = new System.Drawing.Size(256, 257);
			this.pictureBox1.TabIndex = 0;
			this.pictureBox1.TabStop = false;
			// 
			// menuStrip1
			// 
			this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.loadTIMToolStripMenuItem,
            this.cLUTToolStripMenuItem});
			this.menuStrip1.Location = new System.Drawing.Point(0, 0);
			this.menuStrip1.Name = "menuStrip1";
			this.menuStrip1.Size = new System.Drawing.Size(280, 24);
			this.menuStrip1.TabIndex = 1;
			this.menuStrip1.Text = "menuStrip1";
			// 
			// loadTIMToolStripMenuItem
			// 
			this.loadTIMToolStripMenuItem.Name = "loadTIMToolStripMenuItem";
			this.loadTIMToolStripMenuItem.Size = new System.Drawing.Size(77, 20);
			this.loadTIMToolStripMenuItem.Text = "&Load TIM...";
			this.loadTIMToolStripMenuItem.Click += new System.EventHandler(this.loadTIMToolStripMenuItem_Click);
			// 
			// cLUTToolStripMenuItem
			// 
			this.cLUTToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.nextPaletteToolStripMenuItem,
            this.previousPaletteToolStripMenuItem});
			this.cLUTToolStripMenuItem.Name = "cLUTToolStripMenuItem";
			this.cLUTToolStripMenuItem.Size = new System.Drawing.Size(47, 20);
			this.cLUTToolStripMenuItem.Text = "&CLUT";
			// 
			// nextPaletteToolStripMenuItem
			// 
			this.nextPaletteToolStripMenuItem.Name = "nextPaletteToolStripMenuItem";
			this.nextPaletteToolStripMenuItem.Size = new System.Drawing.Size(158, 22);
			this.nextPaletteToolStripMenuItem.Text = "&Next Palette";
			this.nextPaletteToolStripMenuItem.Click += new System.EventHandler(this.nextPaletteToolStripMenuItem_Click);
			// 
			// previousPaletteToolStripMenuItem
			// 
			this.previousPaletteToolStripMenuItem.Name = "previousPaletteToolStripMenuItem";
			this.previousPaletteToolStripMenuItem.Size = new System.Drawing.Size(158, 22);
			this.previousPaletteToolStripMenuItem.Text = "&Previous Palette";
			this.previousPaletteToolStripMenuItem.Click += new System.EventHandler(this.previousPaletteToolStripMenuItem_Click);
			// 
			// TimTester
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(280, 297);
			this.Controls.Add(this.pictureBox1);
			this.Controls.Add(this.menuStrip1);
			this.MainMenuStrip = this.menuStrip1;
			this.MaximizeBox = false;
			this.MaximumSize = new System.Drawing.Size(1064, 1104);
			this.MinimizeBox = false;
			this.MinimumSize = new System.Drawing.Size(296, 336);
			this.Name = "TimTester";
			this.ShowInTaskbar = false;
			this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Show;
			this.Text = "TIM Tester";
			((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
			this.menuStrip1.ResumeLayout(false);
			this.menuStrip1.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.PictureBox pictureBox1;
		private System.Windows.Forms.MenuStrip menuStrip1;
		private System.Windows.Forms.ToolStripMenuItem loadTIMToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem cLUTToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem nextPaletteToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem previousPaletteToolStripMenuItem;
	}
}