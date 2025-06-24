namespace VPWStudio
{
	partial class TexPreviewDialog
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
            this.pbPreview = new System.Windows.Forms.PictureBox();
            this.cmsPreview = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.savePNGToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.backgroundColorToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.pbPreview)).BeginInit();
            this.cmsPreview.SuspendLayout();
            this.SuspendLayout();
            // 
            // pbPreview
            // 
            this.pbPreview.BackColor = System.Drawing.SystemColors.Control;
            this.pbPreview.ContextMenuStrip = this.cmsPreview;
            this.pbPreview.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pbPreview.Location = new System.Drawing.Point(0, 0);
            this.pbPreview.Margin = new System.Windows.Forms.Padding(0);
            this.pbPreview.MinimumSize = new System.Drawing.Size(1, 1);
            this.pbPreview.Name = "pbPreview";
            this.pbPreview.Size = new System.Drawing.Size(248, 229);
            this.pbPreview.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pbPreview.TabIndex = 0;
            this.pbPreview.TabStop = false;
            // 
            // cmsPreview
            // 
            this.cmsPreview.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.savePNGToolStripMenuItem,
            this.backgroundColorToolStripMenuItem});
            this.cmsPreview.Name = "cmsPreview";
            this.cmsPreview.Size = new System.Drawing.Size(180, 48);
            // 
            // savePNGToolStripMenuItem
            // 
            this.savePNGToolStripMenuItem.Image = global::VPWStudio.Properties.Resources.MenuIcon16_Save;
            this.savePNGToolStripMenuItem.Name = "savePNGToolStripMenuItem";
            this.savePNGToolStripMenuItem.Size = new System.Drawing.Size(179, 22);
            this.savePNGToolStripMenuItem.Text = "Save &PNG...";
            this.savePNGToolStripMenuItem.Click += new System.EventHandler(this.savePNGToolStripMenuItem_Click);
            // 
            // backgroundColorToolStripMenuItem
            // 
            this.backgroundColorToolStripMenuItem.Name = "backgroundColorToolStripMenuItem";
            this.backgroundColorToolStripMenuItem.Size = new System.Drawing.Size(179, 22);
            this.backgroundColorToolStripMenuItem.Text = "&Background Color...";
            this.backgroundColorToolStripMenuItem.Click += new System.EventHandler(this.backgroundColorToolStripMenuItem_Click);
            // 
            // TexPreviewDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(248, 229);
            this.Controls.Add(this.pbPreview);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "TexPreviewDialog";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Preview";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.FileTable_TexPreviewDialog_KeyDown);
            this.MouseWheel += new System.Windows.Forms.MouseEventHandler(this.pbPreview_MouseWheel);
            ((System.ComponentModel.ISupportInitialize)(this.pbPreview)).EndInit();
            this.cmsPreview.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.PictureBox pbPreview;
		private System.Windows.Forms.ContextMenuStrip cmsPreview;
		private System.Windows.Forms.ToolStripMenuItem savePNGToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem backgroundColorToolStripMenuItem;
        private System.Windows.Forms.ToolTip toolTip1;
    }
}