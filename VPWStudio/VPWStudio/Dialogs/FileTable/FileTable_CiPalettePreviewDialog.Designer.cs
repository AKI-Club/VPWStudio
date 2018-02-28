namespace VPWStudio
{
	partial class FileTable_CiPalettePreviewDialog
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
			this.gbPaletteEntries = new System.Windows.Forms.GroupBox();
			this.pbPalettePreview = new System.Windows.Forms.PictureBox();
			this.cmsPalette = new System.Windows.Forms.ContextMenuStrip(this.components);
			this.exportJASCPaletteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.gbPaletteEntries.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.pbPalettePreview)).BeginInit();
			this.cmsPalette.SuspendLayout();
			this.SuspendLayout();
			// 
			// gbPaletteEntries
			// 
			this.gbPaletteEntries.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.gbPaletteEntries.Controls.Add(this.pbPalettePreview);
			this.gbPaletteEntries.Location = new System.Drawing.Point(12, 12);
			this.gbPaletteEntries.Name = "gbPaletteEntries";
			this.gbPaletteEntries.Size = new System.Drawing.Size(262, 275);
			this.gbPaletteEntries.TabIndex = 0;
			this.gbPaletteEntries.TabStop = false;
			this.gbPaletteEntries.Text = "Entries";
			// 
			// pbPalettePreview
			// 
			this.pbPalettePreview.ContextMenuStrip = this.cmsPalette;
			this.pbPalettePreview.Dock = System.Windows.Forms.DockStyle.Fill;
			this.pbPalettePreview.Location = new System.Drawing.Point(3, 16);
			this.pbPalettePreview.Name = "pbPalettePreview";
			this.pbPalettePreview.Size = new System.Drawing.Size(256, 256);
			this.pbPalettePreview.TabIndex = 0;
			this.pbPalettePreview.TabStop = false;
			// 
			// cmsPalette
			// 
			this.cmsPalette.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.exportJASCPaletteToolStripMenuItem});
			this.cmsPalette.Name = "cmsPalette";
			this.cmsPalette.Size = new System.Drawing.Size(184, 48);
			// 
			// exportJASCPaletteToolStripMenuItem
			// 
			this.exportJASCPaletteToolStripMenuItem.Image = global::VPWStudio.Properties.Resources.MenuIcon16_Save;
			this.exportJASCPaletteToolStripMenuItem.Name = "exportJASCPaletteToolStripMenuItem";
			this.exportJASCPaletteToolStripMenuItem.Size = new System.Drawing.Size(183, 22);
			this.exportJASCPaletteToolStripMenuItem.Text = "&Export JASC Palette...";
			this.exportJASCPaletteToolStripMenuItem.Click += new System.EventHandler(this.exportJASCPaletteToolStripMenuItem_Click);
			// 
			// FileTable_CiPalettePreviewDialog
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(280, 299);
			this.Controls.Add(this.gbPaletteEntries);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "FileTable_CiPalettePreviewDialog";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "(CI* palette preview)";
			this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.FileTable_CiPalettePreviewDialog_KeyDown);
			this.gbPaletteEntries.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.pbPalettePreview)).EndInit();
			this.cmsPalette.ResumeLayout(false);
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.GroupBox gbPaletteEntries;
		private System.Windows.Forms.PictureBox pbPalettePreview;
		private System.Windows.Forms.ContextMenuStrip cmsPalette;
		private System.Windows.Forms.ToolStripMenuItem exportJASCPaletteToolStripMenuItem;
	}
}