namespace VPWStudio.Editors
{
	partial class FontDialog
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
			this.gbCharacters = new System.Windows.Forms.GroupBox();
			this.lbCharacters = new System.Windows.Forms.ListBox();
			this.pbCharacterPreview = new System.Windows.Forms.PictureBox();
			this.gbCharacterPreview = new System.Windows.Forms.GroupBox();
			this.buttonExportFontGraphic = new System.Windows.Forms.Button();
			this.gbCharacters.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.pbCharacterPreview)).BeginInit();
			this.gbCharacterPreview.SuspendLayout();
			this.SuspendLayout();
			// 
			// gbCharacters
			// 
			this.gbCharacters.Controls.Add(this.lbCharacters);
			this.gbCharacters.Location = new System.Drawing.Point(12, 41);
			this.gbCharacters.Name = "gbCharacters";
			this.gbCharacters.Size = new System.Drawing.Size(109, 402);
			this.gbCharacters.TabIndex = 0;
			this.gbCharacters.TabStop = false;
			this.gbCharacters.Text = "Characters";
			// 
			// lbCharacters
			// 
			this.lbCharacters.FormattingEnabled = true;
			this.lbCharacters.Location = new System.Drawing.Point(6, 19);
			this.lbCharacters.Name = "lbCharacters";
			this.lbCharacters.ScrollAlwaysVisible = true;
			this.lbCharacters.Size = new System.Drawing.Size(97, 368);
			this.lbCharacters.TabIndex = 0;
			this.lbCharacters.SelectedIndexChanged += new System.EventHandler(this.lbCharacters_SelectedIndexChanged);
			// 
			// pbCharacterPreview
			// 
			this.pbCharacterPreview.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
			this.pbCharacterPreview.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.pbCharacterPreview.Location = new System.Drawing.Point(13, 19);
			this.pbCharacterPreview.Name = "pbCharacterPreview";
			this.pbCharacterPreview.Size = new System.Drawing.Size(84, 96);
			this.pbCharacterPreview.TabIndex = 1;
			this.pbCharacterPreview.TabStop = false;
			// 
			// gbCharacterPreview
			// 
			this.gbCharacterPreview.Controls.Add(this.pbCharacterPreview);
			this.gbCharacterPreview.Location = new System.Drawing.Point(127, 41);
			this.gbCharacterPreview.Name = "gbCharacterPreview";
			this.gbCharacterPreview.Size = new System.Drawing.Size(111, 121);
			this.gbCharacterPreview.TabIndex = 2;
			this.gbCharacterPreview.TabStop = false;
			this.gbCharacterPreview.Text = "Character Preview";
			// 
			// buttonExportFontGraphic
			// 
			this.buttonExportFontGraphic.Location = new System.Drawing.Point(127, 420);
			this.buttonExportFontGraphic.Name = "buttonExportFontGraphic";
			this.buttonExportFontGraphic.Size = new System.Drawing.Size(128, 23);
			this.buttonExportFontGraphic.TabIndex = 3;
			this.buttonExportFontGraphic.Text = "&Export Font Graphic...";
			this.buttonExportFontGraphic.UseVisualStyleBackColor = true;
			this.buttonExportFontGraphic.Click += new System.EventHandler(this.buttonExportFontGraphic_Click);
			// 
			// FontDialog
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(506, 455);
			this.Controls.Add(this.buttonExportFontGraphic);
			this.Controls.Add(this.gbCharacterPreview);
			this.Controls.Add(this.gbCharacters);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.Icon = global::VPWStudio.Properties.Resources.Font;
			this.MaximizeBox = false;
			this.Name = "FontDialog";
			this.Text = "Fonts";
			this.gbCharacters.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.pbCharacterPreview)).EndInit();
			this.gbCharacterPreview.ResumeLayout(false);
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.GroupBox gbCharacters;
		private System.Windows.Forms.ListBox lbCharacters;
		private System.Windows.Forms.PictureBox pbCharacterPreview;
		private System.Windows.Forms.GroupBox gbCharacterPreview;
		private System.Windows.Forms.Button buttonExportFontGraphic;
	}
}