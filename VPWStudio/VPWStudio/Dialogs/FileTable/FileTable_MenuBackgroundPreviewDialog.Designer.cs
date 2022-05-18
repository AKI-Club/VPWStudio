namespace VPWStudio
{
	partial class FileTable_MenuBackgoundPreviewDialog
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
			this.pbMenuBG = new System.Windows.Forms.PictureBox();
			this.cmsMenuBG = new System.Windows.Forms.ContextMenuStrip(this.components);
			this.exportPNGToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			((System.ComponentModel.ISupportInitialize)(this.pbMenuBG)).BeginInit();
			this.cmsMenuBG.SuspendLayout();
			this.SuspendLayout();
			// 
			// pbMenuBG
			// 
			this.pbMenuBG.ContextMenuStrip = this.cmsMenuBG;
			this.pbMenuBG.Location = new System.Drawing.Point(12, 12);
			this.pbMenuBG.MaximumSize = new System.Drawing.Size(320, 240);
			this.pbMenuBG.MinimumSize = new System.Drawing.Size(320, 240);
			this.pbMenuBG.Name = "pbMenuBG";
			this.pbMenuBG.Size = new System.Drawing.Size(320, 240);
			this.pbMenuBG.TabIndex = 0;
			this.pbMenuBG.TabStop = false;
			// 
			// cmsMenuBG
			// 
			this.cmsMenuBG.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.exportPNGToolStripMenuItem});
			this.cmsMenuBG.Name = "cmsMenuBG";
			this.cmsMenuBG.Size = new System.Drawing.Size(145, 26);
			// 
			// exportPNGToolStripMenuItem
			// 
			this.exportPNGToolStripMenuItem.Image = global::VPWStudio.Properties.Resources.MenuIcon16_Save;
			this.exportPNGToolStripMenuItem.Name = "exportPNGToolStripMenuItem";
			this.exportPNGToolStripMenuItem.Size = new System.Drawing.Size(144, 22);
			this.exportPNGToolStripMenuItem.Text = "&Export PNG...";
			this.exportPNGToolStripMenuItem.Click += new System.EventHandler(this.exportPNGToolStripMenuItem_Click);
			// 
			// FileTable_MenuBackgoundPreviewDialog
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(344, 264);
			this.Controls.Add(this.pbMenuBG);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.KeyPreview = true;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "FileTable_MenuBackgoundPreviewDialog";
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "Menu Background Preview";
			this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.FileTable_MenuBackgoundPreviewDialog_KeyDown);
			((System.ComponentModel.ISupportInitialize)(this.pbMenuBG)).EndInit();
			this.cmsMenuBG.ResumeLayout(false);
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.PictureBox pbMenuBG;
		private System.Windows.Forms.ContextMenuStrip cmsMenuBG;
		private System.Windows.Forms.ToolStripMenuItem exportPNGToolStripMenuItem;
	}
}