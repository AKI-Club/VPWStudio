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
			this.cbPalettes = new System.Windows.Forms.ComboBox();
			this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
			this.labelPaletteSet = new System.Windows.Forms.Label();
			this.gbPalettePreview.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.pbPalettePreview)).BeginInit();
			this.tlpColorValues.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.nudRed)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.nudGreen)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.nudBlue)).BeginInit();
			this.tableLayoutPanel1.SuspendLayout();
			this.SuspendLayout();
			// 
			// buttonOK
			// 
			this.buttonOK.Location = new System.Drawing.Point(348, 410);
			this.buttonOK.Name = "buttonOK";
			this.buttonOK.Size = new System.Drawing.Size(75, 23);
			this.buttonOK.TabIndex = 0;
			this.buttonOK.Text = "&OK";
			this.buttonOK.UseVisualStyleBackColor = true;
			this.buttonOK.Click += new System.EventHandler(this.buttonOK_Click);
			// 
			// buttonCancel
			// 
			this.buttonCancel.Location = new System.Drawing.Point(429, 410);
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
			this.gbPalettePreview.Location = new System.Drawing.Point(12, 118);
			this.gbPalettePreview.Name = "gbPalettePreview";
			this.gbPalettePreview.Size = new System.Drawing.Size(492, 286);
			this.gbPalettePreview.TabIndex = 2;
			this.gbPalettePreview.TabStop = false;
			this.gbPalettePreview.Text = "Palette Preview";
			// 
			// pbPalettePreview
			// 
			this.pbPalettePreview.Location = new System.Drawing.Point(6, 19);
			this.pbPalettePreview.Name = "pbPalettePreview";
			this.pbPalettePreview.Size = new System.Drawing.Size(480, 256);
			this.pbPalettePreview.TabIndex = 0;
			this.pbPalettePreview.TabStop = false;
			this.pbPalettePreview.MouseClick += new System.Windows.Forms.MouseEventHandler(this.pbPalettePreview_MouseClick);
			// 
			// tlpColorValues
			// 
			this.tlpColorValues.ColumnCount = 2;
			this.tlpColorValues.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
			this.tlpColorValues.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
			this.tlpColorValues.Controls.Add(this.nudRed, 1, 0);
			this.tlpColorValues.Controls.Add(this.nudGreen, 1, 1);
			this.tlpColorValues.Controls.Add(this.nudBlue, 1, 2);
			this.tlpColorValues.Controls.Add(this.labelRed, 0, 0);
			this.tlpColorValues.Controls.Add(this.labelGreen, 0, 1);
			this.tlpColorValues.Controls.Add(this.labelBlue, 0, 2);
			this.tlpColorValues.Controls.Add(this.labelTransparent, 0, 3);
			this.tlpColorValues.Controls.Add(this.cbTransparent, 1, 3);
			this.tlpColorValues.Location = new System.Drawing.Point(212, 12);
			this.tlpColorValues.Name = "tlpColorValues";
			this.tlpColorValues.RowCount = 4;
			this.tlpColorValues.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
			this.tlpColorValues.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
			this.tlpColorValues.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
			this.tlpColorValues.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
			this.tlpColorValues.Size = new System.Drawing.Size(186, 100);
			this.tlpColorValues.TabIndex = 3;
			// 
			// nudRed
			// 
			this.nudRed.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
			this.nudRed.Location = new System.Drawing.Point(96, 3);
			this.nudRed.Maximum = new decimal(new int[] {
            31,
            0,
            0,
            0});
			this.nudRed.Name = "nudRed";
			this.nudRed.Size = new System.Drawing.Size(87, 20);
			this.nudRed.TabIndex = 0;
			this.nudRed.ValueChanged += new System.EventHandler(this.nudRed_ValueChanged);
			// 
			// nudGreen
			// 
			this.nudGreen.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
			this.nudGreen.Location = new System.Drawing.Point(96, 28);
			this.nudGreen.Maximum = new decimal(new int[] {
            31,
            0,
            0,
            0});
			this.nudGreen.Name = "nudGreen";
			this.nudGreen.Size = new System.Drawing.Size(87, 20);
			this.nudGreen.TabIndex = 1;
			this.nudGreen.ValueChanged += new System.EventHandler(this.nudGreen_ValueChanged);
			// 
			// nudBlue
			// 
			this.nudBlue.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
			this.nudBlue.Location = new System.Drawing.Point(96, 53);
			this.nudBlue.Maximum = new decimal(new int[] {
            31,
            0,
            0,
            0});
			this.nudBlue.Name = "nudBlue";
			this.nudBlue.Size = new System.Drawing.Size(87, 20);
			this.nudBlue.TabIndex = 2;
			this.nudBlue.ValueChanged += new System.EventHandler(this.nudBlue_ValueChanged);
			// 
			// labelRed
			// 
			this.labelRed.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
			this.labelRed.AutoSize = true;
			this.labelRed.Location = new System.Drawing.Point(3, 6);
			this.labelRed.Name = "labelRed";
			this.labelRed.Size = new System.Drawing.Size(87, 13);
			this.labelRed.TabIndex = 3;
			this.labelRed.Text = "&Red";
			// 
			// labelGreen
			// 
			this.labelGreen.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
			this.labelGreen.AutoSize = true;
			this.labelGreen.Location = new System.Drawing.Point(3, 31);
			this.labelGreen.Name = "labelGreen";
			this.labelGreen.Size = new System.Drawing.Size(87, 13);
			this.labelGreen.TabIndex = 4;
			this.labelGreen.Text = "&Green";
			// 
			// labelBlue
			// 
			this.labelBlue.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
			this.labelBlue.AutoSize = true;
			this.labelBlue.Location = new System.Drawing.Point(3, 56);
			this.labelBlue.Name = "labelBlue";
			this.labelBlue.Size = new System.Drawing.Size(87, 13);
			this.labelBlue.TabIndex = 5;
			this.labelBlue.Text = "&Blue";
			// 
			// labelTransparent
			// 
			this.labelTransparent.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
			this.labelTransparent.AutoSize = true;
			this.labelTransparent.Location = new System.Drawing.Point(3, 81);
			this.labelTransparent.Name = "labelTransparent";
			this.labelTransparent.Size = new System.Drawing.Size(87, 13);
			this.labelTransparent.TabIndex = 6;
			this.labelTransparent.Text = "&Transparent";
			// 
			// cbTransparent
			// 
			this.cbTransparent.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
			this.cbTransparent.AutoSize = true;
			this.cbTransparent.Location = new System.Drawing.Point(96, 79);
			this.cbTransparent.Name = "cbTransparent";
			this.cbTransparent.Size = new System.Drawing.Size(87, 17);
			this.cbTransparent.TabIndex = 7;
			this.cbTransparent.Text = "Transparent";
			this.cbTransparent.UseVisualStyleBackColor = true;
			this.cbTransparent.Click += new System.EventHandler(this.cbTransparent_Click);
			// 
			// cbColorEntries
			// 
			this.cbColorEntries.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
			this.cbColorEntries.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cbColorEntries.FormattingEnabled = true;
			this.cbColorEntries.Location = new System.Drawing.Point(78, 64);
			this.cbColorEntries.MaxDropDownItems = 16;
			this.cbColorEntries.Name = "cbColorEntries";
			this.cbColorEntries.Size = new System.Drawing.Size(113, 21);
			this.cbColorEntries.TabIndex = 4;
			this.cbColorEntries.SelectionChangeCommitted += new System.EventHandler(this.cbColorEntries_SelectionChangeCommitted);
			// 
			// labelCurColor
			// 
			this.labelCurColor.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
			this.labelCurColor.AutoSize = true;
			this.labelCurColor.Location = new System.Drawing.Point(3, 68);
			this.labelCurColor.Name = "labelCurColor";
			this.labelCurColor.Size = new System.Drawing.Size(69, 13);
			this.labelCurColor.TabIndex = 5;
			this.labelCurColor.Text = "Current C&olor";
			// 
			// panelCurColor
			// 
			this.panelCurColor.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.panelCurColor.Location = new System.Drawing.Point(404, 12);
			this.panelCurColor.Name = "panelCurColor";
			this.panelCurColor.Size = new System.Drawing.Size(100, 100);
			this.panelCurColor.TabIndex = 6;
			// 
			// buttonImport
			// 
			this.buttonImport.Location = new System.Drawing.Point(12, 410);
			this.buttonImport.Name = "buttonImport";
			this.buttonImport.Size = new System.Drawing.Size(100, 23);
			this.buttonImport.TabIndex = 7;
			this.buttonImport.Text = "&Import Palette...";
			this.buttonImport.UseVisualStyleBackColor = true;
			this.buttonImport.Click += new System.EventHandler(this.buttonImport_Click);
			// 
			// buttonExport
			// 
			this.buttonExport.Location = new System.Drawing.Point(118, 410);
			this.buttonExport.Name = "buttonExport";
			this.buttonExport.Size = new System.Drawing.Size(100, 23);
			this.buttonExport.TabIndex = 8;
			this.buttonExport.Text = "&Export Palette...";
			this.buttonExport.UseVisualStyleBackColor = true;
			this.buttonExport.Click += new System.EventHandler(this.buttonExport_Click);
			// 
			// cbPalettes
			// 
			this.cbPalettes.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
			this.cbPalettes.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cbPalettes.FormattingEnabled = true;
			this.cbPalettes.Location = new System.Drawing.Point(78, 14);
			this.cbPalettes.Name = "cbPalettes";
			this.cbPalettes.Size = new System.Drawing.Size(113, 21);
			this.cbPalettes.TabIndex = 9;
			this.cbPalettes.SelectionChangeCommitted += new System.EventHandler(this.cbPalettes_SelectionChangeCommitted);
			// 
			// tableLayoutPanel1
			// 
			this.tableLayoutPanel1.ColumnCount = 2;
			this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 39F));
			this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 61F));
			this.tableLayoutPanel1.Controls.Add(this.cbColorEntries, 1, 1);
			this.tableLayoutPanel1.Controls.Add(this.cbPalettes, 1, 0);
			this.tableLayoutPanel1.Controls.Add(this.labelCurColor, 0, 1);
			this.tableLayoutPanel1.Controls.Add(this.labelPaletteSet, 0, 0);
			this.tableLayoutPanel1.Location = new System.Drawing.Point(12, 12);
			this.tableLayoutPanel1.Name = "tableLayoutPanel1";
			this.tableLayoutPanel1.RowCount = 2;
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
			this.tableLayoutPanel1.Size = new System.Drawing.Size(194, 100);
			this.tableLayoutPanel1.TabIndex = 10;
			// 
			// labelPaletteSet
			// 
			this.labelPaletteSet.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
			this.labelPaletteSet.AutoSize = true;
			this.labelPaletteSet.Location = new System.Drawing.Point(3, 18);
			this.labelPaletteSet.Name = "labelPaletteSet";
			this.labelPaletteSet.Size = new System.Drawing.Size(69, 13);
			this.labelPaletteSet.TabIndex = 10;
			this.labelPaletteSet.Text = "&Palette Set";
			// 
			// CiPaletteEditor
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(516, 445);
			this.Controls.Add(this.tableLayoutPanel1);
			this.Controls.Add(this.buttonExport);
			this.Controls.Add(this.panelCurColor);
			this.Controls.Add(this.buttonImport);
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
			this.tableLayoutPanel1.ResumeLayout(false);
			this.tableLayoutPanel1.PerformLayout();
			this.ResumeLayout(false);

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
		private System.Windows.Forms.ComboBox cbPalettes;
		private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
		private System.Windows.Forms.Label labelPaletteSet;
	}
}