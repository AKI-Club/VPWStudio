
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
			this.components = new System.ComponentModel.Container();
			this.pictureBox1 = new System.Windows.Forms.PictureBox();
			this.imageContextMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
			this.savePNGToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.menuStrip1 = new System.Windows.Forms.MenuStrip();
			this.timToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.loadTIMToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.tsSepTim = new System.Windows.Forms.ToolStripSeparator();
			this.nextTIMToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.previousTIMToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.cLUTToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.nextPaletteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.previousPaletteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.tsSepClut = new System.Windows.Forms.ToolStripSeparator();
			this.exportPaletteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.infoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.statusStrip1 = new System.Windows.Forms.StatusStrip();
			this.timStatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
			this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
			this.exportToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
			this.imageContextMenu.SuspendLayout();
			this.menuStrip1.SuspendLayout();
			this.statusStrip1.SuspendLayout();
			this.SuspendLayout();
			// 
			// pictureBox1
			// 
			this.pictureBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.pictureBox1.ContextMenuStrip = this.imageContextMenu;
			this.pictureBox1.Location = new System.Drawing.Point(12, 27);
			this.pictureBox1.MaximumSize = new System.Drawing.Size(1024, 1024);
			this.pictureBox1.Name = "pictureBox1";
			this.pictureBox1.Size = new System.Drawing.Size(290, 257);
			this.pictureBox1.TabIndex = 0;
			this.pictureBox1.TabStop = false;
			// 
			// imageContextMenu
			// 
			this.imageContextMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.savePNGToolStripMenuItem});
			this.imageContextMenu.Name = "imageContextMenu";
			this.imageContextMenu.Size = new System.Drawing.Size(135, 26);
			// 
			// savePNGToolStripMenuItem
			// 
			this.savePNGToolStripMenuItem.Image = global::VPWStudio.Properties.Resources.MenuIcon16_Save;
			this.savePNGToolStripMenuItem.Name = "savePNGToolStripMenuItem";
			this.savePNGToolStripMenuItem.Size = new System.Drawing.Size(134, 22);
			this.savePNGToolStripMenuItem.Text = "Save PNG...";
			this.savePNGToolStripMenuItem.Click += new System.EventHandler(this.savePNGToolStripMenuItem_Click);
			// 
			// menuStrip1
			// 
			this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.timToolStripMenuItem,
            this.cLUTToolStripMenuItem,
            this.infoToolStripMenuItem});
			this.menuStrip1.Location = new System.Drawing.Point(0, 0);
			this.menuStrip1.Name = "menuStrip1";
			this.menuStrip1.Size = new System.Drawing.Size(314, 24);
			this.menuStrip1.TabIndex = 1;
			this.menuStrip1.Text = "menuStrip1";
			// 
			// timToolStripMenuItem
			// 
			this.timToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.loadTIMToolStripMenuItem,
            this.tsSepTim,
            this.nextTIMToolStripMenuItem,
            this.previousTIMToolStripMenuItem,
            this.toolStripSeparator1,
            this.exportToolStripMenuItem});
			this.timToolStripMenuItem.Name = "timToolStripMenuItem";
			this.timToolStripMenuItem.Size = new System.Drawing.Size(39, 20);
			this.timToolStripMenuItem.Text = "&TIM";
			// 
			// loadTIMToolStripMenuItem
			// 
			this.loadTIMToolStripMenuItem.Name = "loadTIMToolStripMenuItem";
			this.loadTIMToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
			this.loadTIMToolStripMenuItem.Text = "&Load...";
			this.loadTIMToolStripMenuItem.Click += new System.EventHandler(this.loadTIMToolStripMenuItem_Click);
			// 
			// tsSepTim
			// 
			this.tsSepTim.Name = "tsSepTim";
			this.tsSepTim.Size = new System.Drawing.Size(177, 6);
			// 
			// nextTIMToolStripMenuItem
			// 
			this.nextTIMToolStripMenuItem.Name = "nextTIMToolStripMenuItem";
			this.nextTIMToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
			this.nextTIMToolStripMenuItem.Text = "&Next TIM";
			this.nextTIMToolStripMenuItem.Click += new System.EventHandler(this.nextTIMToolStripMenuItem_Click);
			// 
			// previousTIMToolStripMenuItem
			// 
			this.previousTIMToolStripMenuItem.Name = "previousTIMToolStripMenuItem";
			this.previousTIMToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
			this.previousTIMToolStripMenuItem.Text = "&Previous TIM";
			this.previousTIMToolStripMenuItem.Click += new System.EventHandler(this.previousTIMToolStripMenuItem_Click);
			// 
			// cLUTToolStripMenuItem
			// 
			this.cLUTToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.nextPaletteToolStripMenuItem,
            this.previousPaletteToolStripMenuItem,
            this.tsSepClut,
            this.exportPaletteToolStripMenuItem});
			this.cLUTToolStripMenuItem.Name = "cLUTToolStripMenuItem";
			this.cLUTToolStripMenuItem.Size = new System.Drawing.Size(47, 20);
			this.cLUTToolStripMenuItem.Text = "&CLUT";
			// 
			// nextPaletteToolStripMenuItem
			// 
			this.nextPaletteToolStripMenuItem.Name = "nextPaletteToolStripMenuItem";
			this.nextPaletteToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
			this.nextPaletteToolStripMenuItem.Text = "&Next Palette";
			this.nextPaletteToolStripMenuItem.Click += new System.EventHandler(this.nextPaletteToolStripMenuItem_Click);
			// 
			// previousPaletteToolStripMenuItem
			// 
			this.previousPaletteToolStripMenuItem.Name = "previousPaletteToolStripMenuItem";
			this.previousPaletteToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
			this.previousPaletteToolStripMenuItem.Text = "&Previous Palette";
			this.previousPaletteToolStripMenuItem.Click += new System.EventHandler(this.previousPaletteToolStripMenuItem_Click);
			// 
			// tsSepClut
			// 
			this.tsSepClut.Name = "tsSepClut";
			this.tsSepClut.Size = new System.Drawing.Size(177, 6);
			// 
			// exportPaletteToolStripMenuItem
			// 
			this.exportPaletteToolStripMenuItem.Name = "exportPaletteToolStripMenuItem";
			this.exportPaletteToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
			this.exportPaletteToolStripMenuItem.Text = "&Export Palette...";
			this.exportPaletteToolStripMenuItem.Click += new System.EventHandler(this.exportPaletteToolStripMenuItem_Click);
			// 
			// infoToolStripMenuItem
			// 
			this.infoToolStripMenuItem.Name = "infoToolStripMenuItem";
			this.infoToolStripMenuItem.Size = new System.Drawing.Size(49, 20);
			this.infoToolStripMenuItem.Text = "&Info...";
			this.infoToolStripMenuItem.Click += new System.EventHandler(this.infoToolStripMenuItem_Click);
			// 
			// statusStrip1
			// 
			this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.timStatusLabel});
			this.statusStrip1.Location = new System.Drawing.Point(0, 287);
			this.statusStrip1.Name = "statusStrip1";
			this.statusStrip1.Size = new System.Drawing.Size(314, 22);
			this.statusStrip1.TabIndex = 2;
			this.statusStrip1.Text = "statusStrip1";
			// 
			// timStatusLabel
			// 
			this.timStatusLabel.Name = "timStatusLabel";
			this.timStatusLabel.Size = new System.Drawing.Size(85, 17);
			this.timStatusLabel.Text = "No TIM loaded";
			// 
			// toolStripSeparator1
			// 
			this.toolStripSeparator1.Name = "toolStripSeparator1";
			this.toolStripSeparator1.Size = new System.Drawing.Size(177, 6);
			// 
			// exportToolStripMenuItem
			// 
			this.exportToolStripMenuItem.Name = "exportToolStripMenuItem";
			this.exportToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
			this.exportToolStripMenuItem.Text = "&Export...";
			this.exportToolStripMenuItem.Click += new System.EventHandler(this.exportToolStripMenuItem_Click);
			// 
			// TimTester
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(314, 309);
			this.Controls.Add(this.statusStrip1);
			this.Controls.Add(this.pictureBox1);
			this.Controls.Add(this.menuStrip1);
			this.KeyPreview = true;
			this.MainMenuStrip = this.menuStrip1;
			this.MaximizeBox = false;
			this.MaximumSize = new System.Drawing.Size(1064, 1104);
			this.MinimizeBox = false;
			this.MinimumSize = new System.Drawing.Size(330, 348);
			this.Name = "TimTester";
			this.ShowInTaskbar = false;
			this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Show;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "TIM Tester";
			this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TimTester_KeyDown);
			((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
			this.imageContextMenu.ResumeLayout(false);
			this.menuStrip1.ResumeLayout(false);
			this.menuStrip1.PerformLayout();
			this.statusStrip1.ResumeLayout(false);
			this.statusStrip1.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.PictureBox pictureBox1;
		private System.Windows.Forms.MenuStrip menuStrip1;
		private System.Windows.Forms.ToolStripMenuItem timToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem cLUTToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem nextPaletteToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem previousPaletteToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem infoToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem loadTIMToolStripMenuItem;
		private System.Windows.Forms.ToolStripSeparator tsSepTim;
		private System.Windows.Forms.ToolStripMenuItem nextTIMToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem previousTIMToolStripMenuItem;
		private System.Windows.Forms.StatusStrip statusStrip1;
		private System.Windows.Forms.ToolStripStatusLabel timStatusLabel;
		private System.Windows.Forms.ContextMenuStrip imageContextMenu;
		private System.Windows.Forms.ToolStripMenuItem savePNGToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem exportPaletteToolStripMenuItem;
		private System.Windows.Forms.ToolStripSeparator tsSepClut;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
		private System.Windows.Forms.ToolStripMenuItem exportToolStripMenuItem;
	}
}