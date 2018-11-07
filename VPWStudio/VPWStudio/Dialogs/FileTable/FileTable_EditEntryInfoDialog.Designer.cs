namespace VPWStudio
{
	partial class FileTableEditEntryInfoDialog
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
			this.labelEditingEntry = new System.Windows.Forms.Label();
			this.buttonOK = new System.Windows.Forms.Button();
			this.buttonCancel = new System.Windows.Forms.Button();
			this.tlpEntryInfo = new System.Windows.Forms.TableLayoutPanel();
			this.tbComment = new System.Windows.Forms.TextBox();
			this.labelComment = new System.Windows.Forms.Label();
			this.labelFileType = new System.Windows.Forms.Label();
			this.labelReplaceEncoding = new System.Windows.Forms.Label();
			this.labelReplaceFilePath = new System.Windows.Forms.Label();
			this.tlpReplaceFilePath = new System.Windows.Forms.TableLayoutPanel();
			this.buttonReplaceFileBrowse = new System.Windows.Forms.Button();
			this.tbReplaceFilePath = new System.Windows.Forms.TextBox();
			this.cbReplaceEncoding = new System.Windows.Forms.ComboBox();
			this.tlpFileType = new System.Windows.Forms.TableLayoutPanel();
			this.cbFileTypes = new System.Windows.Forms.ComboBox();
			this.cbForceFileType = new System.Windows.Forms.CheckBox();
			this.tcEntryPages = new System.Windows.Forms.TabControl();
			this.tpMain = new System.Windows.Forms.TabPage();
			this.tpExtra = new System.Windows.Forms.TabPage();
			this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
			this.labelImageHeight = new System.Windows.Forms.Label();
			this.labelImageWidth = new System.Windows.Forms.Label();
			this.labelTransparentColorIndex = new System.Windows.Forms.Label();
			this.labelDefaultPaletteID = new System.Windows.Forms.Label();
			this.nudTransparentIndex = new System.Windows.Forms.NumericUpDown();
			this.nudDefaultPaletteID = new System.Windows.Forms.NumericUpDown();
			this.nudImageWidth = new System.Windows.Forms.NumericUpDown();
			this.nudImageHeight = new System.Windows.Forms.NumericUpDown();
			this.cbHorizMirror = new System.Windows.Forms.CheckBox();
			this.cbVertMirror = new System.Windows.Forms.CheckBox();
			this.labelHorizMirror = new System.Windows.Forms.Label();
			this.labelVerticalMirror = new System.Windows.Forms.Label();
			this.tlpEntryInfo.SuspendLayout();
			this.tlpReplaceFilePath.SuspendLayout();
			this.tlpFileType.SuspendLayout();
			this.tcEntryPages.SuspendLayout();
			this.tpMain.SuspendLayout();
			this.tpExtra.SuspendLayout();
			this.tableLayoutPanel1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.nudTransparentIndex)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.nudDefaultPaletteID)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.nudImageWidth)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.nudImageHeight)).BeginInit();
			this.SuspendLayout();
			// 
			// labelEditingEntry
			// 
			this.labelEditingEntry.AutoSize = true;
			this.labelEditingEntry.Location = new System.Drawing.Point(12, 9);
			this.labelEditingEntry.Name = "labelEditingEntry";
			this.labelEditingEntry.Size = new System.Drawing.Size(151, 13);
			this.labelEditingEntry.TabIndex = 0;
			this.labelEditingEntry.Text = "Editing File Table Entry ID {ID}";
			// 
			// buttonOK
			// 
			this.buttonOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.buttonOK.Location = new System.Drawing.Point(346, 260);
			this.buttonOK.Name = "buttonOK";
			this.buttonOK.Size = new System.Drawing.Size(75, 23);
			this.buttonOK.TabIndex = 10;
			this.buttonOK.Text = "&OK";
			this.buttonOK.UseVisualStyleBackColor = true;
			this.buttonOK.Click += new System.EventHandler(this.buttonOK_Click);
			// 
			// buttonCancel
			// 
			this.buttonCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.buttonCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.buttonCancel.Location = new System.Drawing.Point(427, 260);
			this.buttonCancel.Name = "buttonCancel";
			this.buttonCancel.Size = new System.Drawing.Size(75, 23);
			this.buttonCancel.TabIndex = 11;
			this.buttonCancel.Text = "&Cancel";
			this.buttonCancel.UseVisualStyleBackColor = true;
			this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
			// 
			// tlpEntryInfo
			// 
			this.tlpEntryInfo.ColumnCount = 2;
			this.tlpEntryInfo.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 30F));
			this.tlpEntryInfo.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 70F));
			this.tlpEntryInfo.Controls.Add(this.tbComment, 1, 1);
			this.tlpEntryInfo.Controls.Add(this.labelComment, 0, 1);
			this.tlpEntryInfo.Controls.Add(this.labelFileType, 0, 0);
			this.tlpEntryInfo.Controls.Add(this.labelReplaceEncoding, 0, 2);
			this.tlpEntryInfo.Controls.Add(this.labelReplaceFilePath, 0, 3);
			this.tlpEntryInfo.Controls.Add(this.tlpReplaceFilePath, 1, 3);
			this.tlpEntryInfo.Controls.Add(this.cbReplaceEncoding, 1, 2);
			this.tlpEntryInfo.Controls.Add(this.tlpFileType, 1, 0);
			this.tlpEntryInfo.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tlpEntryInfo.Location = new System.Drawing.Point(3, 3);
			this.tlpEntryInfo.Name = "tlpEntryInfo";
			this.tlpEntryInfo.RowCount = 4;
			this.tlpEntryInfo.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
			this.tlpEntryInfo.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
			this.tlpEntryInfo.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
			this.tlpEntryInfo.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
			this.tlpEntryInfo.Size = new System.Drawing.Size(476, 197);
			this.tlpEntryInfo.TabIndex = 7;
			// 
			// tbComment
			// 
			this.tbComment.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
			this.tbComment.Location = new System.Drawing.Point(145, 63);
			this.tbComment.Name = "tbComment";
			this.tbComment.Size = new System.Drawing.Size(328, 20);
			this.tbComment.TabIndex = 4;
			// 
			// labelComment
			// 
			this.labelComment.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
			this.labelComment.AutoSize = true;
			this.labelComment.Location = new System.Drawing.Point(3, 67);
			this.labelComment.Name = "labelComment";
			this.labelComment.Size = new System.Drawing.Size(136, 13);
			this.labelComment.TabIndex = 3;
			this.labelComment.Text = "C&omment";
			// 
			// labelFileType
			// 
			this.labelFileType.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
			this.labelFileType.AutoSize = true;
			this.labelFileType.Location = new System.Drawing.Point(3, 18);
			this.labelFileType.Name = "labelFileType";
			this.labelFileType.Size = new System.Drawing.Size(136, 13);
			this.labelFileType.TabIndex = 0;
			this.labelFileType.Text = "&File Type";
			// 
			// labelReplaceEncoding
			// 
			this.labelReplaceEncoding.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
			this.labelReplaceEncoding.AutoSize = true;
			this.labelReplaceEncoding.Location = new System.Drawing.Point(3, 116);
			this.labelReplaceEncoding.Name = "labelReplaceEncoding";
			this.labelReplaceEncoding.Size = new System.Drawing.Size(136, 13);
			this.labelReplaceEncoding.TabIndex = 5;
			this.labelReplaceEncoding.Text = "Replacement &Encoding";
			// 
			// labelReplaceFilePath
			// 
			this.labelReplaceFilePath.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
			this.labelReplaceFilePath.AutoSize = true;
			this.labelReplaceFilePath.Location = new System.Drawing.Point(3, 165);
			this.labelReplaceFilePath.Name = "labelReplaceFilePath";
			this.labelReplaceFilePath.Size = new System.Drawing.Size(136, 13);
			this.labelReplaceFilePath.TabIndex = 7;
			this.labelReplaceFilePath.Text = "&Replacement File Path";
			// 
			// tlpReplaceFilePath
			// 
			this.tlpReplaceFilePath.ColumnCount = 2;
			this.tlpReplaceFilePath.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 75F));
			this.tlpReplaceFilePath.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
			this.tlpReplaceFilePath.Controls.Add(this.buttonReplaceFileBrowse, 1, 0);
			this.tlpReplaceFilePath.Controls.Add(this.tbReplaceFilePath, 0, 0);
			this.tlpReplaceFilePath.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tlpReplaceFilePath.Location = new System.Drawing.Point(145, 150);
			this.tlpReplaceFilePath.Name = "tlpReplaceFilePath";
			this.tlpReplaceFilePath.RowCount = 1;
			this.tlpReplaceFilePath.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.tlpReplaceFilePath.Size = new System.Drawing.Size(328, 44);
			this.tlpReplaceFilePath.TabIndex = 4;
			// 
			// buttonReplaceFileBrowse
			// 
			this.buttonReplaceFileBrowse.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
			this.buttonReplaceFileBrowse.Location = new System.Drawing.Point(249, 11);
			this.buttonReplaceFileBrowse.Name = "buttonReplaceFileBrowse";
			this.buttonReplaceFileBrowse.Size = new System.Drawing.Size(76, 22);
			this.buttonReplaceFileBrowse.TabIndex = 9;
			this.buttonReplaceFileBrowse.Text = "Browse...";
			this.buttonReplaceFileBrowse.UseVisualStyleBackColor = true;
			this.buttonReplaceFileBrowse.Click += new System.EventHandler(this.buttonReplaceFileBrowse_Click);
			// 
			// tbReplaceFilePath
			// 
			this.tbReplaceFilePath.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
			this.tbReplaceFilePath.Location = new System.Drawing.Point(3, 12);
			this.tbReplaceFilePath.Name = "tbReplaceFilePath";
			this.tbReplaceFilePath.Size = new System.Drawing.Size(240, 20);
			this.tbReplaceFilePath.TabIndex = 8;
			// 
			// cbReplaceEncoding
			// 
			this.cbReplaceEncoding.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
			this.cbReplaceEncoding.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cbReplaceEncoding.FormattingEnabled = true;
			this.cbReplaceEncoding.Items.AddRange(new object[] {
            "Pick Best",
            "Force Raw",
            "Force LZSS"});
			this.cbReplaceEncoding.Location = new System.Drawing.Point(145, 112);
			this.cbReplaceEncoding.Name = "cbReplaceEncoding";
			this.cbReplaceEncoding.Size = new System.Drawing.Size(328, 21);
			this.cbReplaceEncoding.TabIndex = 6;
			// 
			// tlpFileType
			// 
			this.tlpFileType.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
			this.tlpFileType.ColumnCount = 2;
			this.tlpFileType.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 60F));
			this.tlpFileType.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 40F));
			this.tlpFileType.Controls.Add(this.cbFileTypes, 0, 0);
			this.tlpFileType.Controls.Add(this.cbForceFileType, 1, 0);
			this.tlpFileType.Location = new System.Drawing.Point(145, 7);
			this.tlpFileType.Name = "tlpFileType";
			this.tlpFileType.RowCount = 1;
			this.tlpFileType.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.tlpFileType.Size = new System.Drawing.Size(328, 35);
			this.tlpFileType.TabIndex = 7;
			// 
			// cbFileTypes
			// 
			this.cbFileTypes.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
			this.cbFileTypes.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cbFileTypes.FormattingEnabled = true;
			this.cbFileTypes.Location = new System.Drawing.Point(3, 7);
			this.cbFileTypes.Name = "cbFileTypes";
			this.cbFileTypes.Size = new System.Drawing.Size(190, 21);
			this.cbFileTypes.TabIndex = 1;
			// 
			// cbForceFileType
			// 
			this.cbForceFileType.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
			this.cbForceFileType.AutoSize = true;
			this.cbForceFileType.Location = new System.Drawing.Point(199, 9);
			this.cbForceFileType.Name = "cbForceFileType";
			this.cbForceFileType.Size = new System.Drawing.Size(126, 17);
			this.cbForceFileType.TabIndex = 2;
			this.cbForceFileType.Text = "Force File&Type";
			this.cbForceFileType.UseVisualStyleBackColor = true;
			// 
			// tcEntryPages
			// 
			this.tcEntryPages.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.tcEntryPages.Controls.Add(this.tpMain);
			this.tcEntryPages.Controls.Add(this.tpExtra);
			this.tcEntryPages.Location = new System.Drawing.Point(12, 25);
			this.tcEntryPages.Name = "tcEntryPages";
			this.tcEntryPages.SelectedIndex = 0;
			this.tcEntryPages.Size = new System.Drawing.Size(490, 229);
			this.tcEntryPages.TabIndex = 12;
			// 
			// tpMain
			// 
			this.tpMain.Controls.Add(this.tlpEntryInfo);
			this.tpMain.Location = new System.Drawing.Point(4, 22);
			this.tpMain.Name = "tpMain";
			this.tpMain.Padding = new System.Windows.Forms.Padding(3);
			this.tpMain.Size = new System.Drawing.Size(482, 203);
			this.tpMain.TabIndex = 0;
			this.tpMain.Text = "Main";
			this.tpMain.UseVisualStyleBackColor = true;
			// 
			// tpExtra
			// 
			this.tpExtra.Controls.Add(this.tableLayoutPanel1);
			this.tpExtra.Location = new System.Drawing.Point(4, 22);
			this.tpExtra.Name = "tpExtra";
			this.tpExtra.Padding = new System.Windows.Forms.Padding(3);
			this.tpExtra.Size = new System.Drawing.Size(482, 203);
			this.tpExtra.TabIndex = 1;
			this.tpExtra.Text = "Extra";
			this.tpExtra.UseVisualStyleBackColor = true;
			// 
			// tableLayoutPanel1
			// 
			this.tableLayoutPanel1.ColumnCount = 2;
			this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 30F));
			this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 70F));
			this.tableLayoutPanel1.Controls.Add(this.labelImageHeight, 0, 1);
			this.tableLayoutPanel1.Controls.Add(this.labelImageWidth, 0, 0);
			this.tableLayoutPanel1.Controls.Add(this.labelTransparentColorIndex, 0, 2);
			this.tableLayoutPanel1.Controls.Add(this.labelDefaultPaletteID, 0, 3);
			this.tableLayoutPanel1.Controls.Add(this.nudTransparentIndex, 1, 2);
			this.tableLayoutPanel1.Controls.Add(this.nudDefaultPaletteID, 1, 3);
			this.tableLayoutPanel1.Controls.Add(this.nudImageWidth, 1, 0);
			this.tableLayoutPanel1.Controls.Add(this.nudImageHeight, 1, 1);
			this.tableLayoutPanel1.Controls.Add(this.cbHorizMirror, 1, 4);
			this.tableLayoutPanel1.Controls.Add(this.cbVertMirror, 1, 5);
			this.tableLayoutPanel1.Controls.Add(this.labelHorizMirror, 0, 4);
			this.tableLayoutPanel1.Controls.Add(this.labelVerticalMirror, 0, 5);
			this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tableLayoutPanel1.Location = new System.Drawing.Point(3, 3);
			this.tableLayoutPanel1.Name = "tableLayoutPanel1";
			this.tableLayoutPanel1.RowCount = 6;
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
			this.tableLayoutPanel1.Size = new System.Drawing.Size(476, 197);
			this.tableLayoutPanel1.TabIndex = 8;
			// 
			// labelImageHeight
			// 
			this.labelImageHeight.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
			this.labelImageHeight.AutoSize = true;
			this.labelImageHeight.Location = new System.Drawing.Point(3, 41);
			this.labelImageHeight.Name = "labelImageHeight";
			this.labelImageHeight.Size = new System.Drawing.Size(136, 13);
			this.labelImageHeight.TabIndex = 3;
			this.labelImageHeight.Text = "Image Height";
			// 
			// labelImageWidth
			// 
			this.labelImageWidth.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
			this.labelImageWidth.AutoSize = true;
			this.labelImageWidth.Location = new System.Drawing.Point(3, 9);
			this.labelImageWidth.Name = "labelImageWidth";
			this.labelImageWidth.Size = new System.Drawing.Size(136, 13);
			this.labelImageWidth.TabIndex = 0;
			this.labelImageWidth.Text = "Image Width";
			// 
			// labelTransparentColorIndex
			// 
			this.labelTransparentColorIndex.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
			this.labelTransparentColorIndex.AutoSize = true;
			this.labelTransparentColorIndex.Location = new System.Drawing.Point(3, 73);
			this.labelTransparentColorIndex.Name = "labelTransparentColorIndex";
			this.labelTransparentColorIndex.Size = new System.Drawing.Size(136, 13);
			this.labelTransparentColorIndex.TabIndex = 5;
			this.labelTransparentColorIndex.Text = "Transparent Color Index";
			// 
			// labelDefaultPaletteID
			// 
			this.labelDefaultPaletteID.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
			this.labelDefaultPaletteID.AutoSize = true;
			this.labelDefaultPaletteID.Location = new System.Drawing.Point(3, 105);
			this.labelDefaultPaletteID.Name = "labelDefaultPaletteID";
			this.labelDefaultPaletteID.Size = new System.Drawing.Size(136, 13);
			this.labelDefaultPaletteID.TabIndex = 7;
			this.labelDefaultPaletteID.Text = "Default Palette ID";
			// 
			// nudTransparentIndex
			// 
			this.nudTransparentIndex.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
			this.nudTransparentIndex.Location = new System.Drawing.Point(145, 70);
			this.nudTransparentIndex.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
			this.nudTransparentIndex.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            -2147483648});
			this.nudTransparentIndex.Name = "nudTransparentIndex";
			this.nudTransparentIndex.Size = new System.Drawing.Size(328, 20);
			this.nudTransparentIndex.TabIndex = 9;
			// 
			// nudDefaultPaletteID
			// 
			this.nudDefaultPaletteID.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
			this.nudDefaultPaletteID.Hexadecimal = true;
			this.nudDefaultPaletteID.Location = new System.Drawing.Point(145, 102);
			this.nudDefaultPaletteID.Maximum = new decimal(new int[] {
            65535,
            0,
            0,
            0});
			this.nudDefaultPaletteID.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            -2147483648});
			this.nudDefaultPaletteID.Name = "nudDefaultPaletteID";
			this.nudDefaultPaletteID.Size = new System.Drawing.Size(328, 20);
			this.nudDefaultPaletteID.TabIndex = 10;
			// 
			// nudImageWidth
			// 
			this.nudImageWidth.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
			this.nudImageWidth.Location = new System.Drawing.Point(145, 6);
			this.nudImageWidth.Maximum = new decimal(new int[] {
            640,
            0,
            0,
            0});
			this.nudImageWidth.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            -2147483648});
			this.nudImageWidth.Name = "nudImageWidth";
			this.nudImageWidth.Size = new System.Drawing.Size(328, 20);
			this.nudImageWidth.TabIndex = 11;
			// 
			// nudImageHeight
			// 
			this.nudImageHeight.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
			this.nudImageHeight.Location = new System.Drawing.Point(145, 38);
			this.nudImageHeight.Maximum = new decimal(new int[] {
            480,
            0,
            0,
            0});
			this.nudImageHeight.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            -2147483648});
			this.nudImageHeight.Name = "nudImageHeight";
			this.nudImageHeight.Size = new System.Drawing.Size(328, 20);
			this.nudImageHeight.TabIndex = 12;
			// 
			// cbHorizMirror
			// 
			this.cbHorizMirror.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
			this.cbHorizMirror.AutoSize = true;
			this.cbHorizMirror.Location = new System.Drawing.Point(145, 135);
			this.cbHorizMirror.Name = "cbHorizMirror";
			this.cbHorizMirror.Size = new System.Drawing.Size(328, 17);
			this.cbHorizMirror.TabIndex = 13;
			this.cbHorizMirror.Text = "Horizontal Mirroring";
			this.cbHorizMirror.UseVisualStyleBackColor = true;
			// 
			// cbVertMirror
			// 
			this.cbVertMirror.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
			this.cbVertMirror.AutoSize = true;
			this.cbVertMirror.Location = new System.Drawing.Point(145, 170);
			this.cbVertMirror.Name = "cbVertMirror";
			this.cbVertMirror.Size = new System.Drawing.Size(328, 17);
			this.cbVertMirror.TabIndex = 14;
			this.cbVertMirror.Text = "Vertical Mirroring";
			this.cbVertMirror.UseVisualStyleBackColor = true;
			// 
			// labelHorizMirror
			// 
			this.labelHorizMirror.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
			this.labelHorizMirror.AutoSize = true;
			this.labelHorizMirror.Location = new System.Drawing.Point(3, 137);
			this.labelHorizMirror.Name = "labelHorizMirror";
			this.labelHorizMirror.Size = new System.Drawing.Size(136, 13);
			this.labelHorizMirror.TabIndex = 15;
			this.labelHorizMirror.Text = "Horizontal Mirror";
			// 
			// labelVerticalMirror
			// 
			this.labelVerticalMirror.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
			this.labelVerticalMirror.AutoSize = true;
			this.labelVerticalMirror.Location = new System.Drawing.Point(3, 172);
			this.labelVerticalMirror.Name = "labelVerticalMirror";
			this.labelVerticalMirror.Size = new System.Drawing.Size(136, 13);
			this.labelVerticalMirror.TabIndex = 16;
			this.labelVerticalMirror.Text = "Vertical Mirror";
			// 
			// FileTableEditEntryInfoDialog
			// 
			this.AcceptButton = this.buttonOK;
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.CancelButton = this.buttonCancel;
			this.ClientSize = new System.Drawing.Size(514, 295);
			this.Controls.Add(this.tcEntryPages);
			this.Controls.Add(this.labelEditingEntry);
			this.Controls.Add(this.buttonCancel);
			this.Controls.Add(this.buttonOK);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "FileTableEditEntryInfoDialog";
			this.ShowIcon = false;
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "File Table Entry Information";
			this.tlpEntryInfo.ResumeLayout(false);
			this.tlpEntryInfo.PerformLayout();
			this.tlpReplaceFilePath.ResumeLayout(false);
			this.tlpReplaceFilePath.PerformLayout();
			this.tlpFileType.ResumeLayout(false);
			this.tlpFileType.PerformLayout();
			this.tcEntryPages.ResumeLayout(false);
			this.tpMain.ResumeLayout(false);
			this.tpExtra.ResumeLayout(false);
			this.tableLayoutPanel1.ResumeLayout(false);
			this.tableLayoutPanel1.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.nudTransparentIndex)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.nudDefaultPaletteID)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.nudImageWidth)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.nudImageHeight)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion
		private System.Windows.Forms.Label labelEditingEntry;
		private System.Windows.Forms.Button buttonOK;
		private System.Windows.Forms.Button buttonCancel;
		private System.Windows.Forms.TableLayoutPanel tlpEntryInfo;
		private System.Windows.Forms.TextBox tbComment;
		private System.Windows.Forms.Label labelComment;
		private System.Windows.Forms.Label labelFileType;
		private System.Windows.Forms.Label labelReplaceEncoding;
		private System.Windows.Forms.Label labelReplaceFilePath;
		private System.Windows.Forms.TableLayoutPanel tlpReplaceFilePath;
		private System.Windows.Forms.Button buttonReplaceFileBrowse;
		private System.Windows.Forms.TextBox tbReplaceFilePath;
		private System.Windows.Forms.ComboBox cbReplaceEncoding;
		private System.Windows.Forms.TableLayoutPanel tlpFileType;
		private System.Windows.Forms.ComboBox cbFileTypes;
		private System.Windows.Forms.CheckBox cbForceFileType;
		private System.Windows.Forms.TabControl tcEntryPages;
		private System.Windows.Forms.TabPage tpMain;
		private System.Windows.Forms.TabPage tpExtra;
		private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
		private System.Windows.Forms.Label labelImageHeight;
		private System.Windows.Forms.Label labelImageWidth;
		private System.Windows.Forms.Label labelTransparentColorIndex;
		private System.Windows.Forms.Label labelDefaultPaletteID;
		private System.Windows.Forms.NumericUpDown nudTransparentIndex;
		private System.Windows.Forms.NumericUpDown nudDefaultPaletteID;
		private System.Windows.Forms.NumericUpDown nudImageWidth;
		private System.Windows.Forms.NumericUpDown nudImageHeight;
		private System.Windows.Forms.CheckBox cbHorizMirror;
		private System.Windows.Forms.CheckBox cbVertMirror;
		private System.Windows.Forms.Label labelHorizMirror;
		private System.Windows.Forms.Label labelVerticalMirror;
	}
}