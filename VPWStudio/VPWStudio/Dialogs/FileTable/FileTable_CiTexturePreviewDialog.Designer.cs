namespace VPWStudio
{
	partial class FileTable_CiTexturePreviewDialog
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
			this.gbPalette = new System.Windows.Forms.GroupBox();
			this.cbPalettes = new System.Windows.Forms.ComboBox();
			this.gbPreview = new System.Windows.Forms.GroupBox();
			this.pbPreview = new System.Windows.Forms.PictureBox();
			this.cmsImage = new System.Windows.Forms.ContextMenuStrip(this.components);
			this.savePNGToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.gbSubPalettes = new System.Windows.Forms.GroupBox();
			this.cbSubPalettes = new System.Windows.Forms.ComboBox();
			this.gbPalette.SuspendLayout();
			this.gbPreview.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.pbPreview)).BeginInit();
			this.cmsImage.SuspendLayout();
			this.gbSubPalettes.SuspendLayout();
			this.SuspendLayout();
			// 
			// gbPalette
			// 
			this.gbPalette.Controls.Add(this.cbPalettes);
			this.gbPalette.Location = new System.Drawing.Point(12, 12);
			this.gbPalette.Name = "gbPalette";
			this.gbPalette.Size = new System.Drawing.Size(181, 46);
			this.gbPalette.TabIndex = 0;
			this.gbPalette.TabStop = false;
			this.gbPalette.Text = "Palette";
			// 
			// cbPalettes
			// 
			this.cbPalettes.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
			this.cbPalettes.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cbPalettes.DropDownWidth = 256;
			this.cbPalettes.FormattingEnabled = true;
			this.cbPalettes.Location = new System.Drawing.Point(6, 19);
			this.cbPalettes.Name = "cbPalettes";
			this.cbPalettes.Size = new System.Drawing.Size(169, 21);
			this.cbPalettes.TabIndex = 0;
			this.cbPalettes.SelectedValueChanged += new System.EventHandler(this.cbPalettes_SelectedValueChanged);
			this.cbPalettes.KeyDown += new System.Windows.Forms.KeyEventHandler(this.FileTable_CiTexturePreviewDialog_KeyDown);
			// 
			// gbPreview
			// 
			this.gbPreview.Controls.Add(this.pbPreview);
			this.gbPreview.Location = new System.Drawing.Point(12, 64);
			this.gbPreview.Name = "gbPreview";
			this.gbPreview.Size = new System.Drawing.Size(368, 217);
			this.gbPreview.TabIndex = 1;
			this.gbPreview.TabStop = false;
			this.gbPreview.Text = "Preview";
			// 
			// pbPreview
			// 
			this.pbPreview.ContextMenuStrip = this.cmsImage;
			this.pbPreview.Dock = System.Windows.Forms.DockStyle.Fill;
			this.pbPreview.Location = new System.Drawing.Point(3, 16);
			this.pbPreview.Name = "pbPreview";
			this.pbPreview.Size = new System.Drawing.Size(362, 198);
			this.pbPreview.TabIndex = 0;
			this.pbPreview.TabStop = false;
			// 
			// cmsImage
			// 
			this.cmsImage.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.savePNGToolStripMenuItem});
			this.cmsImage.Name = "cmsImage";
			this.cmsImage.Size = new System.Drawing.Size(134, 26);
			// 
			// savePNGToolStripMenuItem
			// 
			this.savePNGToolStripMenuItem.Image = global::VPWStudio.Properties.Resources.MenuIcon16_Save;
			this.savePNGToolStripMenuItem.Name = "savePNGToolStripMenuItem";
			this.savePNGToolStripMenuItem.Size = new System.Drawing.Size(133, 22);
			this.savePNGToolStripMenuItem.Text = "Save PNG...";
			this.savePNGToolStripMenuItem.Click += new System.EventHandler(this.savePNGToolStripMenuItem_Click);
			// 
			// gbSubPalettes
			// 
			this.gbSubPalettes.Controls.Add(this.cbSubPalettes);
			this.gbSubPalettes.Location = new System.Drawing.Point(199, 12);
			this.gbSubPalettes.Name = "gbSubPalettes";
			this.gbSubPalettes.Size = new System.Drawing.Size(181, 46);
			this.gbSubPalettes.TabIndex = 2;
			this.gbSubPalettes.TabStop = false;
			this.gbSubPalettes.Text = "Sub-Palettes";
			// 
			// cbSubPalettes
			// 
			this.cbSubPalettes.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
			this.cbSubPalettes.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cbSubPalettes.Enabled = false;
			this.cbSubPalettes.FormattingEnabled = true;
			this.cbSubPalettes.Location = new System.Drawing.Point(6, 19);
			this.cbSubPalettes.Name = "cbSubPalettes";
			this.cbSubPalettes.Size = new System.Drawing.Size(169, 21);
			this.cbSubPalettes.TabIndex = 1;
			this.cbSubPalettes.SelectionChangeCommitted += new System.EventHandler(this.cbSubPalettes_SelectionChangeCommitted);
			this.cbSubPalettes.KeyDown += new System.Windows.Forms.KeyEventHandler(this.FileTable_CiTexturePreviewDialog_KeyDown);
			// 
			// FileTable_CiTexturePreviewDialog
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(392, 293);
			this.Controls.Add(this.gbSubPalettes);
			this.Controls.Add(this.gbPreview);
			this.Controls.Add(this.gbPalette);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "FileTable_CiTexturePreviewDialog";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "(CI* image preview)";
			this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.FileTable_CiTexturePreviewDialog_KeyDown);
			this.gbPalette.ResumeLayout(false);
			this.gbPreview.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.pbPreview)).EndInit();
			this.cmsImage.ResumeLayout(false);
			this.gbSubPalettes.ResumeLayout(false);
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.GroupBox gbPalette;
		private System.Windows.Forms.ComboBox cbPalettes;
		private System.Windows.Forms.GroupBox gbPreview;
		private System.Windows.Forms.PictureBox pbPreview;
		private System.Windows.Forms.ContextMenuStrip cmsImage;
		private System.Windows.Forms.ToolStripMenuItem savePNGToolStripMenuItem;
		private System.Windows.Forms.GroupBox gbSubPalettes;
		private System.Windows.Forms.ComboBox cbSubPalettes;
	}
}