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
			this.gbFontInfo = new System.Windows.Forms.GroupBox();
			this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
			this.labelFontType = new System.Windows.Forms.Label();
			this.labelNumCharacters = new System.Windows.Forms.Label();
			this.labelCharWidth = new System.Windows.Forms.Label();
			this.labelCharHeight = new System.Windows.Forms.Label();
			this.gbCharacters.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.pbCharacterPreview)).BeginInit();
			this.gbCharacterPreview.SuspendLayout();
			this.gbFontInfo.SuspendLayout();
			this.tableLayoutPanel1.SuspendLayout();
			this.SuspendLayout();
			// 
			// gbCharacters
			// 
			this.gbCharacters.Controls.Add(this.lbCharacters);
			this.gbCharacters.Location = new System.Drawing.Point(12, 103);
			this.gbCharacters.Name = "gbCharacters";
			this.gbCharacters.Size = new System.Drawing.Size(109, 340);
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
			this.lbCharacters.Size = new System.Drawing.Size(97, 316);
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
			this.gbCharacterPreview.Location = new System.Drawing.Point(127, 103);
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
			// gbFontInfo
			// 
			this.gbFontInfo.Controls.Add(this.tableLayoutPanel1);
			this.gbFontInfo.Location = new System.Drawing.Point(12, 12);
			this.gbFontInfo.Name = "gbFontInfo";
			this.gbFontInfo.Size = new System.Drawing.Size(482, 85);
			this.gbFontInfo.TabIndex = 4;
			this.gbFontInfo.TabStop = false;
			this.gbFontInfo.Text = "Font Information";
			// 
			// tableLayoutPanel1
			// 
			this.tableLayoutPanel1.ColumnCount = 4;
			this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
			this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
			this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
			this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
			this.tableLayoutPanel1.Controls.Add(this.labelFontType, 0, 0);
			this.tableLayoutPanel1.Controls.Add(this.labelNumCharacters, 0, 1);
			this.tableLayoutPanel1.Controls.Add(this.labelCharWidth, 2, 0);
			this.tableLayoutPanel1.Controls.Add(this.labelCharHeight, 2, 1);
			this.tableLayoutPanel1.Location = new System.Drawing.Point(6, 19);
			this.tableLayoutPanel1.Name = "tableLayoutPanel1";
			this.tableLayoutPanel1.RowCount = 2;
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
			this.tableLayoutPanel1.Size = new System.Drawing.Size(470, 60);
			this.tableLayoutPanel1.TabIndex = 0;
			// 
			// labelFontType
			// 
			this.labelFontType.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
			this.labelFontType.AutoSize = true;
			this.labelFontType.Location = new System.Drawing.Point(3, 8);
			this.labelFontType.Name = "labelFontType";
			this.labelFontType.Size = new System.Drawing.Size(111, 13);
			this.labelFontType.TabIndex = 0;
			this.labelFontType.Text = "Font Type";
			// 
			// labelNumCharacters
			// 
			this.labelNumCharacters.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
			this.labelNumCharacters.AutoSize = true;
			this.labelNumCharacters.Location = new System.Drawing.Point(3, 38);
			this.labelNumCharacters.Name = "labelNumCharacters";
			this.labelNumCharacters.Size = new System.Drawing.Size(111, 13);
			this.labelNumCharacters.TabIndex = 1;
			this.labelNumCharacters.Text = "Number of Characters";
			// 
			// labelCharWidth
			// 
			this.labelCharWidth.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
			this.labelCharWidth.AutoSize = true;
			this.labelCharWidth.Location = new System.Drawing.Point(237, 8);
			this.labelCharWidth.Name = "labelCharWidth";
			this.labelCharWidth.Size = new System.Drawing.Size(111, 13);
			this.labelCharWidth.TabIndex = 2;
			this.labelCharWidth.Text = "Character Width";
			// 
			// labelCharHeight
			// 
			this.labelCharHeight.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
			this.labelCharHeight.AutoSize = true;
			this.labelCharHeight.Location = new System.Drawing.Point(237, 38);
			this.labelCharHeight.Name = "labelCharHeight";
			this.labelCharHeight.Size = new System.Drawing.Size(111, 13);
			this.labelCharHeight.TabIndex = 3;
			this.labelCharHeight.Text = "Character Height";
			// 
			// FontDialog
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(506, 455);
			this.Controls.Add(this.gbFontInfo);
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
			this.gbFontInfo.ResumeLayout(false);
			this.tableLayoutPanel1.ResumeLayout(false);
			this.tableLayoutPanel1.PerformLayout();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.GroupBox gbCharacters;
		private System.Windows.Forms.ListBox lbCharacters;
		private System.Windows.Forms.PictureBox pbCharacterPreview;
		private System.Windows.Forms.GroupBox gbCharacterPreview;
		private System.Windows.Forms.Button buttonExportFontGraphic;
		private System.Windows.Forms.GroupBox gbFontInfo;
		private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
		private System.Windows.Forms.Label labelFontType;
		private System.Windows.Forms.Label labelNumCharacters;
		private System.Windows.Forms.Label labelCharWidth;
		private System.Windows.Forms.Label labelCharHeight;
	}
}