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
			this.gbPalette = new System.Windows.Forms.GroupBox();
			this.gbPreview = new System.Windows.Forms.GroupBox();
			this.cbPalettes = new System.Windows.Forms.ComboBox();
			this.pbPreview = new System.Windows.Forms.PictureBox();
			this.gbPalette.SuspendLayout();
			this.gbPreview.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.pbPreview)).BeginInit();
			this.SuspendLayout();
			// 
			// gbPalette
			// 
			this.gbPalette.Controls.Add(this.cbPalettes);
			this.gbPalette.Location = new System.Drawing.Point(12, 12);
			this.gbPalette.Name = "gbPalette";
			this.gbPalette.Size = new System.Drawing.Size(368, 46);
			this.gbPalette.TabIndex = 0;
			this.gbPalette.TabStop = false;
			this.gbPalette.Text = "Palette";
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
			// cbPalettes
			// 
			this.cbPalettes.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
			this.cbPalettes.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cbPalettes.FormattingEnabled = true;
			this.cbPalettes.Location = new System.Drawing.Point(6, 19);
			this.cbPalettes.Name = "cbPalettes";
			this.cbPalettes.Size = new System.Drawing.Size(356, 21);
			this.cbPalettes.TabIndex = 0;
			this.cbPalettes.SelectedValueChanged += new System.EventHandler(this.cbPalettes_SelectedValueChanged);
			// 
			// pbPreview
			// 
			this.pbPreview.Dock = System.Windows.Forms.DockStyle.Fill;
			this.pbPreview.Location = new System.Drawing.Point(3, 16);
			this.pbPreview.Name = "pbPreview";
			this.pbPreview.Size = new System.Drawing.Size(362, 198);
			this.pbPreview.TabIndex = 0;
			this.pbPreview.TabStop = false;
			// 
			// FileTable_CiPreviewDialog
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(392, 293);
			this.Controls.Add(this.gbPreview);
			this.Controls.Add(this.gbPalette);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "FileTable_CiPreviewDialog";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "(CI* image preview)";
			this.gbPalette.ResumeLayout(false);
			this.gbPreview.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.pbPreview)).EndInit();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.GroupBox gbPalette;
		private System.Windows.Forms.ComboBox cbPalettes;
		private System.Windows.Forms.GroupBox gbPreview;
		private System.Windows.Forms.PictureBox pbPreview;
	}
}