namespace VPWStudio.Editors
{
	partial class CiPaletteEditor
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
			this.buttonOK = new System.Windows.Forms.Button();
			this.buttonCancel = new System.Windows.Forms.Button();
			this.gbPalettePreview = new System.Windows.Forms.GroupBox();
			this.pbPalettePreview = new System.Windows.Forms.PictureBox();
			this.tlpColorValues = new System.Windows.Forms.TableLayoutPanel();
			this.nudRed = new System.Windows.Forms.NumericUpDown();
			this.nudGreen = new System.Windows.Forms.NumericUpDown();
			this.nudBlue = new System.Windows.Forms.NumericUpDown();
			this.labelRed = new System.Windows.Forms.Label();
			this.labelGreen = new System.Windows.Forms.Label();
			this.labelBlue = new System.Windows.Forms.Label();
			this.labelTransparent = new System.Windows.Forms.Label();
			this.cbTransparent = new System.Windows.Forms.CheckBox();
			this.cbColorEntries = new System.Windows.Forms.ComboBox();
			this.labelCurColor = new System.Windows.Forms.Label();
			this.panelCurColor = new System.Windows.Forms.Panel();
			this.buttonImport = new System.Windows.Forms.Button();
			this.buttonExport = new System.Windows.Forms.Button();
			this.gbPalettePreview.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.pbPalettePreview)).BeginInit();
			this.tlpColorValues.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.nudRed)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.nudGreen)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.nudBlue)).BeginInit();
			this.SuspendLayout();
			// 
			// buttonOK
			// 
			this.buttonOK.Location = new System.Drawing.Point(314, 307);
			this.buttonOK.Name = "buttonOK";
			this.buttonOK.Size = new System.Drawing.Size(75, 23);
			this.buttonOK.TabIndex = 0;
			this.buttonOK.Text = "&OK";
			this.buttonOK.UseVisualStyleBackColor = true;
			this.buttonOK.Click += new System.EventHandler(this.buttonOK_Click);
			// 
			// buttonCancel
			// 
			this.buttonCancel.Location = new System.Drawing.Point(395, 307);
			this.buttonCancel.Name = "buttonCancel";
			this.buttonCancel.Size = new System.Drawing.Size(75, 23);
			this.buttonCancel.TabIndex = 1;
			this.buttonCancel.Text = "&Cancel";
			this.buttonCancel.UseVisualStyleBackColor = true;
			this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
			// 
			// gbPalettePreview
			// 
			this.gbPalettePreview.Controls.Add(this.pbPalettePreview);
			this.gbPalettePreview.Location = new System.Drawing.Point(12, 145);
			this.gbPalettePreview.Name = "gbPalettePreview";
			this.gbPalettePreview.Size = new System.Drawing.Size(458, 156);
			this.gbPalettePreview.TabIndex = 2;
			this.gbPalettePreview.TabStop = false;
			this.gbPalettePreview.Text = "Palette Preview";
			// 
			// pbPalettePreview
			// 
			this.pbPalettePreview.Location = new System.Drawing.Point(6, 19);
			this.pbPalettePreview.Name = "pbPalettePreview";
			this.pbPalettePreview.Size = new System.Drawing.Size(448, 128);
			this.pbPalettePreview.TabIndex = 0;
			this.pbPalettePreview.TabStop = false;
			this.pbPalettePreview.MouseClick += new System.Windows.Forms.MouseEventHandler(this.pbPalettePreview_MouseClick);
			// 
			// tlpColorValues
			// 
			this.tlpColorValues.ColumnCount = 2;
			this.tlpColorValues.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 40F));
			this.tlpColorValues.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 60F));
			this.tlpColorValues.Controls.Add(this.nudRed, 1, 0);
			this.tlpColorValues.Controls.Add(this.nudGreen, 1, 1);
			this.tlpColorValues.Controls.Add(this.nudBlue, 1, 2);
			this.tlpColorValues.Controls.Add(this.labelRed, 0, 0);
			this.tlpColorValues.Controls.Add(this.labelGreen, 0, 1);
			this.tlpColorValues.Controls.Add(this.labelBlue, 0, 2);
			this.tlpColorValues.Controls.Add(this.labelTransparent, 0, 3);
			this.tlpColorValues.Controls.Add(this.cbTransparent, 1, 3);
			this.tlpColorValues.Location = new System.Drawing.Point(12, 39);
			this.tlpColorValues.Name = "tlpColorValues";
			this.tlpColorValues.RowCount = 4;
			this.tlpColorValues.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
			this.tlpColorValues.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
			this.tlpColorValues.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
			this.tlpColorValues.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
			this.tlpColorValues.Size = new System.Drawing.Size(352, 100);
			this.tlpColorValues.TabIndex = 3;
			// 
			// nudRed
			// 
			this.nudRed.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
			this.nudRed.Location = new System.Drawing.Point(143, 3);
			this.nudRed.Maximum = new decimal(new int[] {
            31,
            0,
            0,
            0});
			this.nudRed.Name = "nudRed";
			this.nudRed.Size = new System.Drawing.Size(206, 20);
			this.nudRed.TabIndex = 0;
			this.nudRed.ValueChanged += new System.EventHandler(this.nudRed_ValueChanged);
			// 
			// nudGreen
			// 
			this.nudGreen.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
			this.nudGreen.Location = new System.Drawing.Point(143, 28);
			this.nudGreen.Maximum = new decimal(new int[] {
            31,
            0,
            0,
            0});
			this.nudGreen.Name = "nudGreen";
			this.nudGreen.Size = new System.Drawing.Size(206, 20);
			this.nudGreen.TabIndex = 1;
			this.nudGreen.ValueChanged += new System.EventHandler(this.nudGreen_ValueChanged);
			// 
			// nudBlue
			// 
			this.nudBlue.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
			this.nudBlue.Location = new System.Drawing.Point(143, 53);
			this.nudBlue.Maximum = new decimal(new int[] {
            31,
            0,
            0,
            0});
			this.nudBlue.Name = "nudBlue";
			this.nudBlue.Size = new System.Drawing.Size(206, 20);
			this.nudBlue.TabIndex = 2;
			this.nudBlue.ValueChanged += new System.EventHandler(this.nudBlue_ValueChanged);
			// 
			// labelRed
			// 
			this.labelRed.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
			this.labelRed.AutoSize = true;
			this.labelRed.Location = new System.Drawing.Point(3, 6);
			this.labelRed.Name = "labelRed";
			this.labelRed.Size = new System.Drawing.Size(134, 13);
			this.labelRed.TabIndex = 3;
			this.labelRed.Text = "&Red";
			// 
			// labelGreen
			// 
			this.labelGreen.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
			this.labelGreen.AutoSize = true;
			this.labelGreen.Location = new System.Drawing.Point(3, 31);
			this.labelGreen.Name = "labelGreen";
			this.labelGreen.Size = new System.Drawing.Size(134, 13);
			this.labelGreen.TabIndex = 4;
			this.labelGreen.Text = "&Green";
			// 
			// labelBlue
			// 
			this.labelBlue.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
			this.labelBlue.AutoSize = true;
			this.labelBlue.Location = new System.Drawing.Point(3, 56);
			this.labelBlue.Name = "labelBlue";
			this.labelBlue.Size = new System.Drawing.Size(134, 13);
			this.labelBlue.TabIndex = 5;
			this.labelBlue.Text = "&Blue";
			// 
			// labelTransparent
			// 
			this.labelTransparent.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
			this.labelTransparent.AutoSize = true;
			this.labelTransparent.Location = new System.Drawing.Point(3, 81);
			this.labelTransparent.Name = "labelTransparent";
			this.labelTransparent.Size = new System.Drawing.Size(134, 13);
			this.labelTransparent.TabIndex = 6;
			this.labelTransparent.Text = "&Transparent";
			// 
			// cbTransparent
			// 
			this.cbTransparent.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
			this.cbTransparent.AutoSize = true;
			this.cbTransparent.Location = new System.Drawing.Point(143, 79);
			this.cbTransparent.Name = "cbTransparent";
			this.cbTransparent.Size = new System.Drawing.Size(206, 17);
			this.cbTransparent.TabIndex = 7;
			this.cbTransparent.Text = "Transparent";
			this.cbTransparent.UseVisualStyleBackColor = true;
			this.cbTransparent.Click += new System.EventHandler(this.cbTransparent_Click);
			// 
			// cbColorEntries
			// 
			this.cbColorEntries.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cbColorEntries.FormattingEnabled = true;
			this.cbColorEntries.Location = new System.Drawing.Point(86, 12);
			this.cbColorEntries.MaxDropDownItems = 16;
			this.cbColorEntries.Name = "cbColorEntries";
			this.cbColorEntries.Size = new System.Drawing.Size(384, 21);
			this.cbColorEntries.TabIndex = 4;
			this.cbColorEntries.SelectionChangeCommitted += new System.EventHandler(this.cbColorEntries_SelectionChangeCommitted);
			// 
			// labelCurColor
			// 
			this.labelCurColor.AutoSize = true;
			this.labelCurColor.Location = new System.Drawing.Point(12, 15);
			this.labelCurColor.Name = "labelCurColor";
			this.labelCurColor.Size = new System.Drawing.Size(68, 13);
			this.labelCurColor.TabIndex = 5;
			this.labelCurColor.Text = "Current C&olor";
			// 
			// panelCurColor
			// 
			this.panelCurColor.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.panelCurColor.Location = new System.Drawing.Point(370, 39);
			this.panelCurColor.Name = "panelCurColor";
			this.panelCurColor.Size = new System.Drawing.Size(100, 100);
			this.panelCurColor.TabIndex = 6;
			// 
			// buttonImport
			// 
			this.buttonImport.Location = new System.Drawing.Point(12, 307);
			this.buttonImport.Name = "buttonImport";
			this.buttonImport.Size = new System.Drawing.Size(75, 23);
			this.buttonImport.TabIndex = 7;
			this.buttonImport.Text = "&Import...";
			this.buttonImport.UseVisualStyleBackColor = true;
			this.buttonImport.Click += new System.EventHandler(this.buttonImport_Click);
			// 
			// buttonExport
			// 
			this.buttonExport.Location = new System.Drawing.Point(93, 307);
			this.buttonExport.Name = "buttonExport";
			this.buttonExport.Size = new System.Drawing.Size(75, 23);
			this.buttonExport.TabIndex = 8;
			this.buttonExport.Text = "&Export...";
			this.buttonExport.UseVisualStyleBackColor = true;
			this.buttonExport.Click += new System.EventHandler(this.buttonExport_Click);
			// 
			// CiPaletteEditor
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(482, 342);
			this.Controls.Add(this.buttonExport);
			this.Controls.Add(this.buttonImport);
			this.Controls.Add(this.panelCurColor);
			this.Controls.Add(this.labelCurColor);
			this.Controls.Add(this.cbColorEntries);
			this.Controls.Add(this.tlpColorValues);
			this.Controls.Add(this.gbPalettePreview);
			this.Controls.Add(this.buttonCancel);
			this.Controls.Add(this.buttonOK);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "CiPaletteEditor";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "CI* Palette Editor";
			this.gbPalettePreview.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.pbPalettePreview)).EndInit();
			this.tlpColorValues.ResumeLayout(false);
			this.tlpColorValues.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.nudRed)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.nudGreen)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.nudBlue)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Button buttonOK;
		private System.Windows.Forms.Button buttonCancel;
		private System.Windows.Forms.GroupBox gbPalettePreview;
		private System.Windows.Forms.PictureBox pbPalettePreview;
		private System.Windows.Forms.TableLayoutPanel tlpColorValues;
		private System.Windows.Forms.NumericUpDown nudRed;
		private System.Windows.Forms.NumericUpDown nudGreen;
		private System.Windows.Forms.NumericUpDown nudBlue;
		private System.Windows.Forms.Label labelRed;
		private System.Windows.Forms.Label labelGreen;
		private System.Windows.Forms.Label labelBlue;
		private System.Windows.Forms.Label labelTransparent;
		private System.Windows.Forms.CheckBox cbTransparent;
		private System.Windows.Forms.ComboBox cbColorEntries;
		private System.Windows.Forms.Label labelCurColor;
		private System.Windows.Forms.Panel panelCurColor;
		private System.Windows.Forms.Button buttonImport;
		private System.Windows.Forms.Button buttonExport;
	}
}