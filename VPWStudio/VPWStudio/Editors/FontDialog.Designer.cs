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
			this.buttonExportFontGraphic = new System.Windows.Forms.Button();
			this.gbFontInfo = new System.Windows.Forms.GroupBox();
			this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
			this.labelFontType = new System.Windows.Forms.Label();
			this.labelNumCharacters = new System.Windows.Forms.Label();
			this.labelFontTypeValue = new System.Windows.Forms.Label();
			this.labelNumCharsValue = new System.Windows.Forms.Label();
			this.labelCharWidth = new System.Windows.Forms.Label();
			this.labelCharWidthValue = new System.Windows.Forms.Label();
			this.labelCharHeight = new System.Windows.Forms.Label();
			this.labelCharHeightValue = new System.Windows.Forms.Label();
			this.gbCharacters.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.pbCharacterPreview)).BeginInit();
			this.gbFontInfo.SuspendLayout();
			this.tableLayoutPanel1.SuspendLayout();
			this.SuspendLayout();
			// 
			// gbCharacters
			// 
			this.gbCharacters.Controls.Add(this.lbCharacters);
			this.gbCharacters.Location = new System.Drawing.Point(224, 12);
			this.gbCharacters.Name = "gbCharacters";
			this.gbCharacters.Size = new System.Drawing.Size(83, 140);
			this.gbCharacters.TabIndex = 0;
			this.gbCharacters.TabStop = false;
			this.gbCharacters.Text = "Characters";
			// 
			// lbCharacters
			// 
			this.lbCharacters.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
			this.lbCharacters.FormattingEnabled = true;
			this.lbCharacters.Location = new System.Drawing.Point(6, 19);
			this.lbCharacters.Name = "lbCharacters";
			this.lbCharacters.ScrollAlwaysVisible = true;
			this.lbCharacters.Size = new System.Drawing.Size(71, 108);
			this.lbCharacters.TabIndex = 0;
			this.lbCharacters.SelectedIndexChanged += new System.EventHandler(this.lbCharacters_SelectedIndexChanged);
			// 
			// pbCharacterPreview
			// 
			this.pbCharacterPreview.Location = new System.Drawing.Point(313, 12);
			this.pbCharacterPreview.Name = "pbCharacterPreview";
			this.pbCharacterPreview.Size = new System.Drawing.Size(48, 48);
			this.pbCharacterPreview.TabIndex = 1;
			this.pbCharacterPreview.TabStop = false;
			// 
			// buttonExportFontGraphic
			// 
			this.buttonExportFontGraphic.Location = new System.Drawing.Point(12, 158);
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
			this.gbFontInfo.Size = new System.Drawing.Size(206, 140);
			this.gbFontInfo.TabIndex = 4;
			this.gbFontInfo.TabStop = false;
			this.gbFontInfo.Text = "Font Information";
			// 
			// tableLayoutPanel1
			// 
			this.tableLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.tableLayoutPanel1.ColumnCount = 2;
			this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 60F));
			this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 40F));
			this.tableLayoutPanel1.Controls.Add(this.labelFontType, 0, 0);
			this.tableLayoutPanel1.Controls.Add(this.labelNumCharacters, 0, 1);
			this.tableLayoutPanel1.Controls.Add(this.labelFontTypeValue, 1, 0);
			this.tableLayoutPanel1.Controls.Add(this.labelNumCharsValue, 1, 1);
			this.tableLayoutPanel1.Controls.Add(this.labelCharWidth, 0, 2);
			this.tableLayoutPanel1.Controls.Add(this.labelCharWidthValue, 1, 2);
			this.tableLayoutPanel1.Controls.Add(this.labelCharHeight, 0, 3);
			this.tableLayoutPanel1.Controls.Add(this.labelCharHeightValue, 1, 3);
			this.tableLayoutPanel1.Location = new System.Drawing.Point(6, 19);
			this.tableLayoutPanel1.Name = "tableLayoutPanel1";
			this.tableLayoutPanel1.RowCount = 4;
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
			this.tableLayoutPanel1.Size = new System.Drawing.Size(194, 115);
			this.tableLayoutPanel1.TabIndex = 0;
			// 
			// labelFontType
			// 
			this.labelFontType.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
			this.labelFontType.AutoSize = true;
			this.labelFontType.Location = new System.Drawing.Point(3, 7);
			this.labelFontType.Name = "labelFontType";
			this.labelFontType.Size = new System.Drawing.Size(110, 13);
			this.labelFontType.TabIndex = 0;
			this.labelFontType.Text = "Font Type";
			// 
			// labelNumCharacters
			// 
			this.labelNumCharacters.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
			this.labelNumCharacters.AutoSize = true;
			this.labelNumCharacters.Location = new System.Drawing.Point(3, 35);
			this.labelNumCharacters.Name = "labelNumCharacters";
			this.labelNumCharacters.Size = new System.Drawing.Size(110, 13);
			this.labelNumCharacters.TabIndex = 1;
			this.labelNumCharacters.Text = "Number of Characters";
			// 
			// labelFontTypeValue
			// 
			this.labelFontTypeValue.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
			this.labelFontTypeValue.AutoSize = true;
			this.labelFontTypeValue.Location = new System.Drawing.Point(119, 7);
			this.labelFontTypeValue.Name = "labelFontTypeValue";
			this.labelFontTypeValue.Size = new System.Drawing.Size(72, 13);
			this.labelFontTypeValue.TabIndex = 4;
			// 
			// labelNumCharsValue
			// 
			this.labelNumCharsValue.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
			this.labelNumCharsValue.AutoSize = true;
			this.labelNumCharsValue.Location = new System.Drawing.Point(119, 35);
			this.labelNumCharsValue.Name = "labelNumCharsValue";
			this.labelNumCharsValue.Size = new System.Drawing.Size(72, 13);
			this.labelNumCharsValue.TabIndex = 5;
			// 
			// labelCharWidth
			// 
			this.labelCharWidth.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
			this.labelCharWidth.AutoSize = true;
			this.labelCharWidth.Location = new System.Drawing.Point(3, 63);
			this.labelCharWidth.Name = "labelCharWidth";
			this.labelCharWidth.Size = new System.Drawing.Size(110, 13);
			this.labelCharWidth.TabIndex = 2;
			this.labelCharWidth.Text = "Character Width";
			// 
			// labelCharWidthValue
			// 
			this.labelCharWidthValue.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
			this.labelCharWidthValue.AutoSize = true;
			this.labelCharWidthValue.Location = new System.Drawing.Point(119, 63);
			this.labelCharWidthValue.Name = "labelCharWidthValue";
			this.labelCharWidthValue.Size = new System.Drawing.Size(72, 13);
			this.labelCharWidthValue.TabIndex = 6;
			// 
			// labelCharHeight
			// 
			this.labelCharHeight.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
			this.labelCharHeight.AutoSize = true;
			this.labelCharHeight.Location = new System.Drawing.Point(3, 93);
			this.labelCharHeight.Name = "labelCharHeight";
			this.labelCharHeight.Size = new System.Drawing.Size(110, 13);
			this.labelCharHeight.TabIndex = 3;
			this.labelCharHeight.Text = "Character Height";
			// 
			// labelCharHeightValue
			// 
			this.labelCharHeightValue.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
			this.labelCharHeightValue.AutoSize = true;
			this.labelCharHeightValue.Location = new System.Drawing.Point(119, 93);
			this.labelCharHeightValue.Name = "labelCharHeightValue";
			this.labelCharHeightValue.Size = new System.Drawing.Size(72, 13);
			this.labelCharHeightValue.TabIndex = 7;
			// 
			// FontDialog
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(373, 193);
			this.Controls.Add(this.pbCharacterPreview);
			this.Controls.Add(this.gbFontInfo);
			this.Controls.Add(this.buttonExportFontGraphic);
			this.Controls.Add(this.gbCharacters);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.Icon = global::VPWStudio.Properties.Resources.Font;
			this.KeyPreview = true;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "FontDialog";
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "Fonts";
			this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.FontDialog_KeyUp);
			this.gbCharacters.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.pbCharacterPreview)).EndInit();
			this.gbFontInfo.ResumeLayout(false);
			this.tableLayoutPanel1.ResumeLayout(false);
			this.tableLayoutPanel1.PerformLayout();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.GroupBox gbCharacters;
		private System.Windows.Forms.ListBox lbCharacters;
		private System.Windows.Forms.PictureBox pbCharacterPreview;
		private System.Windows.Forms.Button buttonExportFontGraphic;
		private System.Windows.Forms.GroupBox gbFontInfo;
		private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
		private System.Windows.Forms.Label labelFontType;
		private System.Windows.Forms.Label labelNumCharacters;
		private System.Windows.Forms.Label labelCharWidth;
		private System.Windows.Forms.Label labelCharHeight;
		private System.Windows.Forms.Label labelFontTypeValue;
		private System.Windows.Forms.Label labelNumCharsValue;
		private System.Windows.Forms.Label labelCharWidthValue;
		private System.Windows.Forms.Label labelCharHeightValue;
	}
}