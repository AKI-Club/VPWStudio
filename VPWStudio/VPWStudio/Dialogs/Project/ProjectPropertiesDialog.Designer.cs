namespace VPWStudio
{
	partial class ProjectPropertiesDialog
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
			this.tcProjectProperties = new System.Windows.Forms.TabControl();
			this.tpMainProperties = new System.Windows.Forms.TabPage();
			this.tpOutputRom = new System.Windows.Forms.TabPage();
			this.tlpProjectOptions = new System.Windows.Forms.TableLayoutPanel();
			this.tlpGameSharkCodeFile = new System.Windows.Forms.TableLayoutPanel();
			this.buttonSetGSCodefile = new System.Windows.Forms.Button();
			this.tbGSCodeFile = new System.Windows.Forms.TextBox();
			this.labelProjectName = new System.Windows.Forms.Label();
			this.labelAuthors = new System.Windows.Forms.Label();
			this.labelGameType = new System.Windows.Forms.Label();
			this.labelBaseROM = new System.Windows.Forms.Label();
			this.tlpBaseROM = new System.Windows.Forms.TableLayoutPanel();
			this.buttonOpenBaseROM = new System.Windows.Forms.Button();
			this.tbBaseROMPath = new System.Windows.Forms.TextBox();
			this.tbProjectName = new System.Windows.Forms.TextBox();
			this.tbAuthors = new System.Windows.Forms.TextBox();
			this.cbGameType = new System.Windows.Forms.ComboBox();
			this.tlpCustomLoc = new System.Windows.Forms.TableLayoutPanel();
			this.buttonSetCustomLocFile = new System.Windows.Forms.Button();
			this.tbCustomLocationFile = new System.Windows.Forms.TextBox();
			this.chbCustomLocation = new System.Windows.Forms.CheckBox();
			this.labelGSCodeFile = new System.Windows.Forms.Label();
			this.tlpOutputRom = new System.Windows.Forms.TableLayoutPanel();
			this.labelOutROM = new System.Windows.Forms.Label();
			this.tlpOutROM = new System.Windows.Forms.TableLayoutPanel();
			this.buttonSetOutROM = new System.Windows.Forms.Button();
			this.tbOutROMPath = new System.Windows.Forms.TextBox();
			this.labelOutRomInternalName = new System.Windows.Forms.Label();
			this.tbOutRomInternalName = new System.Windows.Forms.TextBox();
			this.labelOutRomGameCode = new System.Windows.Forms.Label();
			this.tbOutRomProductCode = new System.Windows.Forms.TextBox();
			this.tcProjectProperties.SuspendLayout();
			this.tpMainProperties.SuspendLayout();
			this.tpOutputRom.SuspendLayout();
			this.tlpProjectOptions.SuspendLayout();
			this.tlpGameSharkCodeFile.SuspendLayout();
			this.tlpBaseROM.SuspendLayout();
			this.tlpCustomLoc.SuspendLayout();
			this.tlpOutputRom.SuspendLayout();
			this.tlpOutROM.SuspendLayout();
			this.SuspendLayout();
			// 
			// buttonOK
			// 
			this.buttonOK.Location = new System.Drawing.Point(366, 260);
			this.buttonOK.Name = "buttonOK";
			this.buttonOK.Size = new System.Drawing.Size(75, 23);
			this.buttonOK.TabIndex = 0;
			this.buttonOK.Text = "&OK";
			this.buttonOK.UseVisualStyleBackColor = true;
			this.buttonOK.Click += new System.EventHandler(this.buttonOK_Click);
			// 
			// buttonCancel
			// 
			this.buttonCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.buttonCancel.Location = new System.Drawing.Point(447, 260);
			this.buttonCancel.Name = "buttonCancel";
			this.buttonCancel.Size = new System.Drawing.Size(75, 23);
			this.buttonCancel.TabIndex = 1;
			this.buttonCancel.Text = "&Cancel";
			this.buttonCancel.UseVisualStyleBackColor = true;
			this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
			// 
			// tcProjectProperties
			// 
			this.tcProjectProperties.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.tcProjectProperties.Controls.Add(this.tpMainProperties);
			this.tcProjectProperties.Controls.Add(this.tpOutputRom);
			this.tcProjectProperties.Location = new System.Drawing.Point(12, 12);
			this.tcProjectProperties.Name = "tcProjectProperties";
			this.tcProjectProperties.SelectedIndex = 0;
			this.tcProjectProperties.Size = new System.Drawing.Size(510, 242);
			this.tcProjectProperties.TabIndex = 3;
			// 
			// tpMainProperties
			// 
			this.tpMainProperties.Controls.Add(this.tlpProjectOptions);
			this.tpMainProperties.Location = new System.Drawing.Point(4, 22);
			this.tpMainProperties.Name = "tpMainProperties";
			this.tpMainProperties.Padding = new System.Windows.Forms.Padding(3);
			this.tpMainProperties.Size = new System.Drawing.Size(502, 216);
			this.tpMainProperties.TabIndex = 0;
			this.tpMainProperties.Text = "Main";
			this.tpMainProperties.UseVisualStyleBackColor = true;
			// 
			// tpOutputRom
			// 
			this.tpOutputRom.Controls.Add(this.tlpOutputRom);
			this.tpOutputRom.Location = new System.Drawing.Point(4, 22);
			this.tpOutputRom.Name = "tpOutputRom";
			this.tpOutputRom.Padding = new System.Windows.Forms.Padding(3);
			this.tpOutputRom.Size = new System.Drawing.Size(502, 216);
			this.tpOutputRom.TabIndex = 1;
			this.tpOutputRom.Text = "Output ROM";
			this.tpOutputRom.UseVisualStyleBackColor = true;
			// 
			// tlpProjectOptions
			// 
			this.tlpProjectOptions.ColumnCount = 2;
			this.tlpProjectOptions.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 28F));
			this.tlpProjectOptions.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 72F));
			this.tlpProjectOptions.Controls.Add(this.labelProjectName, 0, 0);
			this.tlpProjectOptions.Controls.Add(this.labelAuthors, 0, 1);
			this.tlpProjectOptions.Controls.Add(this.labelGameType, 0, 2);
			this.tlpProjectOptions.Controls.Add(this.labelBaseROM, 0, 3);
			this.tlpProjectOptions.Controls.Add(this.tlpBaseROM, 1, 3);
			this.tlpProjectOptions.Controls.Add(this.tbProjectName, 1, 0);
			this.tlpProjectOptions.Controls.Add(this.tbAuthors, 1, 1);
			this.tlpProjectOptions.Controls.Add(this.cbGameType, 1, 2);
			this.tlpProjectOptions.Controls.Add(this.labelGSCodeFile, 0, 4);
			this.tlpProjectOptions.Controls.Add(this.tlpGameSharkCodeFile, 1, 4);
			this.tlpProjectOptions.Controls.Add(this.tlpCustomLoc, 1, 5);
			this.tlpProjectOptions.Controls.Add(this.chbCustomLocation, 0, 5);
			this.tlpProjectOptions.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tlpProjectOptions.Location = new System.Drawing.Point(3, 3);
			this.tlpProjectOptions.Name = "tlpProjectOptions";
			this.tlpProjectOptions.RowCount = 6;
			this.tlpProjectOptions.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 14.28571F));
			this.tlpProjectOptions.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 14.28571F));
			this.tlpProjectOptions.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 14.28571F));
			this.tlpProjectOptions.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 14.28571F));
			this.tlpProjectOptions.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 14.28571F));
			this.tlpProjectOptions.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 14.28571F));
			this.tlpProjectOptions.Size = new System.Drawing.Size(496, 210);
			this.tlpProjectOptions.TabIndex = 3;
			// 
			// tlpGameSharkCodeFile
			// 
			this.tlpGameSharkCodeFile.ColumnCount = 2;
			this.tlpGameSharkCodeFile.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 90F));
			this.tlpGameSharkCodeFile.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10F));
			this.tlpGameSharkCodeFile.Controls.Add(this.buttonSetGSCodefile, 1, 0);
			this.tlpGameSharkCodeFile.Controls.Add(this.tbGSCodeFile, 0, 0);
			this.tlpGameSharkCodeFile.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tlpGameSharkCodeFile.Location = new System.Drawing.Point(141, 139);
			this.tlpGameSharkCodeFile.Name = "tlpGameSharkCodeFile";
			this.tlpGameSharkCodeFile.RowCount = 1;
			this.tlpGameSharkCodeFile.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.tlpGameSharkCodeFile.Size = new System.Drawing.Size(352, 28);
			this.tlpGameSharkCodeFile.TabIndex = 13;
			// 
			// buttonSetGSCodefile
			// 
			this.buttonSetGSCodefile.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
			this.buttonSetGSCodefile.Location = new System.Drawing.Point(319, 4);
			this.buttonSetGSCodefile.Name = "buttonSetGSCodefile";
			this.buttonSetGSCodefile.Size = new System.Drawing.Size(30, 19);
			this.buttonSetGSCodefile.TabIndex = 1;
			this.buttonSetGSCodefile.Text = "...";
			this.buttonSetGSCodefile.UseVisualStyleBackColor = true;
			// 
			// tbGSCodeFile
			// 
			this.tbGSCodeFile.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
			this.tbGSCodeFile.Location = new System.Drawing.Point(3, 4);
			this.tbGSCodeFile.Name = "tbGSCodeFile";
			this.tbGSCodeFile.Size = new System.Drawing.Size(310, 20);
			this.tbGSCodeFile.TabIndex = 2;
			// 
			// labelProjectName
			// 
			this.labelProjectName.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
			this.labelProjectName.AutoSize = true;
			this.labelProjectName.Location = new System.Drawing.Point(3, 10);
			this.labelProjectName.Name = "labelProjectName";
			this.labelProjectName.Size = new System.Drawing.Size(132, 13);
			this.labelProjectName.TabIndex = 0;
			this.labelProjectName.Text = "Project &Name";
			// 
			// labelAuthors
			// 
			this.labelAuthors.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
			this.labelAuthors.AutoSize = true;
			this.labelAuthors.Location = new System.Drawing.Point(3, 44);
			this.labelAuthors.Name = "labelAuthors";
			this.labelAuthors.Size = new System.Drawing.Size(132, 13);
			this.labelAuthors.TabIndex = 1;
			this.labelAuthors.Text = "&Author(s) (optional)";
			// 
			// labelGameType
			// 
			this.labelGameType.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
			this.labelGameType.AutoSize = true;
			this.labelGameType.Location = new System.Drawing.Point(3, 78);
			this.labelGameType.Name = "labelGameType";
			this.labelGameType.Size = new System.Drawing.Size(132, 13);
			this.labelGameType.TabIndex = 2;
			this.labelGameType.Text = "&Game Type";
			// 
			// labelBaseROM
			// 
			this.labelBaseROM.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
			this.labelBaseROM.AutoSize = true;
			this.labelBaseROM.Location = new System.Drawing.Point(3, 112);
			this.labelBaseROM.Name = "labelBaseROM";
			this.labelBaseROM.Size = new System.Drawing.Size(132, 13);
			this.labelBaseROM.TabIndex = 3;
			this.labelBaseROM.Text = "&Base ROM File";
			// 
			// tlpBaseROM
			// 
			this.tlpBaseROM.ColumnCount = 2;
			this.tlpBaseROM.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 90F));
			this.tlpBaseROM.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10F));
			this.tlpBaseROM.Controls.Add(this.buttonOpenBaseROM, 1, 0);
			this.tlpBaseROM.Controls.Add(this.tbBaseROMPath, 0, 0);
			this.tlpBaseROM.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tlpBaseROM.Location = new System.Drawing.Point(141, 105);
			this.tlpBaseROM.Name = "tlpBaseROM";
			this.tlpBaseROM.RowCount = 1;
			this.tlpBaseROM.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.tlpBaseROM.Size = new System.Drawing.Size(352, 28);
			this.tlpBaseROM.TabIndex = 5;
			// 
			// buttonOpenBaseROM
			// 
			this.buttonOpenBaseROM.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
			this.buttonOpenBaseROM.Location = new System.Drawing.Point(319, 4);
			this.buttonOpenBaseROM.Name = "buttonOpenBaseROM";
			this.buttonOpenBaseROM.Size = new System.Drawing.Size(30, 19);
			this.buttonOpenBaseROM.TabIndex = 0;
			this.buttonOpenBaseROM.Text = "...";
			this.buttonOpenBaseROM.UseVisualStyleBackColor = true;
			// 
			// tbBaseROMPath
			// 
			this.tbBaseROMPath.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
			this.tbBaseROMPath.Location = new System.Drawing.Point(3, 4);
			this.tbBaseROMPath.Name = "tbBaseROMPath";
			this.tbBaseROMPath.Size = new System.Drawing.Size(310, 20);
			this.tbBaseROMPath.TabIndex = 1;
			// 
			// tbProjectName
			// 
			this.tbProjectName.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
			this.tbProjectName.Location = new System.Drawing.Point(141, 7);
			this.tbProjectName.Name = "tbProjectName";
			this.tbProjectName.Size = new System.Drawing.Size(352, 20);
			this.tbProjectName.TabIndex = 7;
			// 
			// tbAuthors
			// 
			this.tbAuthors.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
			this.tbAuthors.Location = new System.Drawing.Point(141, 41);
			this.tbAuthors.Name = "tbAuthors";
			this.tbAuthors.Size = new System.Drawing.Size(352, 20);
			this.tbAuthors.TabIndex = 8;
			// 
			// cbGameType
			// 
			this.cbGameType.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
			this.cbGameType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cbGameType.FormattingEnabled = true;
			this.cbGameType.Location = new System.Drawing.Point(141, 74);
			this.cbGameType.Name = "cbGameType";
			this.cbGameType.Size = new System.Drawing.Size(352, 21);
			this.cbGameType.TabIndex = 9;
			// 
			// tlpCustomLoc
			// 
			this.tlpCustomLoc.ColumnCount = 2;
			this.tlpCustomLoc.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 90F));
			this.tlpCustomLoc.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10F));
			this.tlpCustomLoc.Controls.Add(this.buttonSetCustomLocFile, 1, 0);
			this.tlpCustomLoc.Controls.Add(this.tbCustomLocationFile, 0, 0);
			this.tlpCustomLoc.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tlpCustomLoc.Location = new System.Drawing.Point(141, 173);
			this.tlpCustomLoc.Name = "tlpCustomLoc";
			this.tlpCustomLoc.RowCount = 1;
			this.tlpCustomLoc.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.tlpCustomLoc.Size = new System.Drawing.Size(352, 34);
			this.tlpCustomLoc.TabIndex = 11;
			// 
			// buttonSetCustomLocFile
			// 
			this.buttonSetCustomLocFile.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
			this.buttonSetCustomLocFile.Enabled = false;
			this.buttonSetCustomLocFile.Location = new System.Drawing.Point(319, 6);
			this.buttonSetCustomLocFile.Name = "buttonSetCustomLocFile";
			this.buttonSetCustomLocFile.Size = new System.Drawing.Size(30, 22);
			this.buttonSetCustomLocFile.TabIndex = 1;
			this.buttonSetCustomLocFile.Text = "...";
			this.buttonSetCustomLocFile.UseVisualStyleBackColor = true;
			// 
			// tbCustomLocationFile
			// 
			this.tbCustomLocationFile.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
			this.tbCustomLocationFile.Enabled = false;
			this.tbCustomLocationFile.Location = new System.Drawing.Point(3, 7);
			this.tbCustomLocationFile.Name = "tbCustomLocationFile";
			this.tbCustomLocationFile.Size = new System.Drawing.Size(310, 20);
			this.tbCustomLocationFile.TabIndex = 2;
			// 
			// chbCustomLocation
			// 
			this.chbCustomLocation.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
			this.chbCustomLocation.AutoSize = true;
			this.chbCustomLocation.Location = new System.Drawing.Point(3, 181);
			this.chbCustomLocation.Name = "chbCustomLocation";
			this.chbCustomLocation.Size = new System.Drawing.Size(132, 17);
			this.chbCustomLocation.TabIndex = 10;
			this.chbCustomLocation.Text = "Custom &Location File";
			this.chbCustomLocation.UseVisualStyleBackColor = true;
			// 
			// labelGSCodeFile
			// 
			this.labelGSCodeFile.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
			this.labelGSCodeFile.AutoSize = true;
			this.labelGSCodeFile.Location = new System.Drawing.Point(3, 146);
			this.labelGSCodeFile.Name = "labelGSCodeFile";
			this.labelGSCodeFile.Size = new System.Drawing.Size(132, 13);
			this.labelGSCodeFile.TabIndex = 12;
			this.labelGSCodeFile.Text = "Game&Shark Code File";
			// 
			// tlpOutputRom
			// 
			this.tlpOutputRom.ColumnCount = 2;
			this.tlpOutputRom.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
			this.tlpOutputRom.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 75F));
			this.tlpOutputRom.Controls.Add(this.tbOutRomProductCode, 1, 2);
			this.tlpOutputRom.Controls.Add(this.labelOutROM, 0, 0);
			this.tlpOutputRom.Controls.Add(this.tlpOutROM, 1, 0);
			this.tlpOutputRom.Controls.Add(this.labelOutRomInternalName, 0, 1);
			this.tlpOutputRom.Controls.Add(this.tbOutRomInternalName, 1, 1);
			this.tlpOutputRom.Controls.Add(this.labelOutRomGameCode, 0, 2);
			this.tlpOutputRom.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tlpOutputRom.Location = new System.Drawing.Point(3, 3);
			this.tlpOutputRom.Name = "tlpOutputRom";
			this.tlpOutputRom.RowCount = 3;
			this.tlpOutputRom.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
			this.tlpOutputRom.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
			this.tlpOutputRom.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
			this.tlpOutputRom.Size = new System.Drawing.Size(496, 210);
			this.tlpOutputRom.TabIndex = 0;
			// 
			// labelOutROM
			// 
			this.labelOutROM.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
			this.labelOutROM.AutoSize = true;
			this.labelOutROM.Location = new System.Drawing.Point(3, 28);
			this.labelOutROM.Name = "labelOutROM";
			this.labelOutROM.Size = new System.Drawing.Size(118, 13);
			this.labelOutROM.TabIndex = 5;
			this.labelOutROM.Text = "O&utput ROM File";
			// 
			// tlpOutROM
			// 
			this.tlpOutROM.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
			this.tlpOutROM.ColumnCount = 2;
			this.tlpOutROM.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 90F));
			this.tlpOutROM.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10F));
			this.tlpOutROM.Controls.Add(this.buttonSetOutROM, 1, 0);
			this.tlpOutROM.Controls.Add(this.tbOutROMPath, 0, 0);
			this.tlpOutROM.Location = new System.Drawing.Point(127, 23);
			this.tlpOutROM.Name = "tlpOutROM";
			this.tlpOutROM.RowCount = 1;
			this.tlpOutROM.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.tlpOutROM.Size = new System.Drawing.Size(366, 23);
			this.tlpOutROM.TabIndex = 7;
			// 
			// buttonSetOutROM
			// 
			this.buttonSetOutROM.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
			this.buttonSetOutROM.Location = new System.Drawing.Point(332, 3);
			this.buttonSetOutROM.Name = "buttonSetOutROM";
			this.buttonSetOutROM.Size = new System.Drawing.Size(31, 17);
			this.buttonSetOutROM.TabIndex = 1;
			this.buttonSetOutROM.Text = "...";
			this.buttonSetOutROM.UseVisualStyleBackColor = true;
			// 
			// tbOutROMPath
			// 
			this.tbOutROMPath.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
			this.tbOutROMPath.Location = new System.Drawing.Point(3, 3);
			this.tbOutROMPath.Name = "tbOutROMPath";
			this.tbOutROMPath.Size = new System.Drawing.Size(323, 20);
			this.tbOutROMPath.TabIndex = 2;
			// 
			// labelOutRomInternalName
			// 
			this.labelOutRomInternalName.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
			this.labelOutRomInternalName.AutoSize = true;
			this.labelOutRomInternalName.Location = new System.Drawing.Point(3, 97);
			this.labelOutRomInternalName.Name = "labelOutRomInternalName";
			this.labelOutRomInternalName.Size = new System.Drawing.Size(118, 13);
			this.labelOutRomInternalName.TabIndex = 8;
			this.labelOutRomInternalName.Text = "Internal Game &Name";
			// 
			// tbOutRomInternalName
			// 
			this.tbOutRomInternalName.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
			this.tbOutRomInternalName.Location = new System.Drawing.Point(127, 93);
			this.tbOutRomInternalName.MaxLength = 20;
			this.tbOutRomInternalName.Name = "tbOutRomInternalName";
			this.tbOutRomInternalName.Size = new System.Drawing.Size(366, 20);
			this.tbOutRomInternalName.TabIndex = 9;
			// 
			// labelOutRomGameCode
			// 
			this.labelOutRomGameCode.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
			this.labelOutRomGameCode.AutoSize = true;
			this.labelOutRomGameCode.Location = new System.Drawing.Point(3, 167);
			this.labelOutRomGameCode.Name = "labelOutRomGameCode";
			this.labelOutRomGameCode.Size = new System.Drawing.Size(118, 13);
			this.labelOutRomGameCode.TabIndex = 10;
			this.labelOutRomGameCode.Text = "&Product Code";
			// 
			// tbOutRomProductCode
			// 
			this.tbOutRomProductCode.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
			this.tbOutRomProductCode.Location = new System.Drawing.Point(127, 164);
			this.tbOutRomProductCode.MaxLength = 4;
			this.tbOutRomProductCode.Name = "tbOutRomProductCode";
			this.tbOutRomProductCode.Size = new System.Drawing.Size(366, 20);
			this.tbOutRomProductCode.TabIndex = 11;
			// 
			// ProjectPropertiesDialog
			// 
			this.AcceptButton = this.buttonOK;
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.CancelButton = this.buttonCancel;
			this.ClientSize = new System.Drawing.Size(534, 295);
			this.Controls.Add(this.tcProjectProperties);
			this.Controls.Add(this.buttonCancel);
			this.Controls.Add(this.buttonOK);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.MinimumSize = new System.Drawing.Size(500, 300);
			this.Name = "ProjectPropertiesDialog";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "Project Properties";
			this.tcProjectProperties.ResumeLayout(false);
			this.tpMainProperties.ResumeLayout(false);
			this.tpOutputRom.ResumeLayout(false);
			this.tlpProjectOptions.ResumeLayout(false);
			this.tlpProjectOptions.PerformLayout();
			this.tlpGameSharkCodeFile.ResumeLayout(false);
			this.tlpGameSharkCodeFile.PerformLayout();
			this.tlpBaseROM.ResumeLayout(false);
			this.tlpBaseROM.PerformLayout();
			this.tlpCustomLoc.ResumeLayout(false);
			this.tlpCustomLoc.PerformLayout();
			this.tlpOutputRom.ResumeLayout(false);
			this.tlpOutputRom.PerformLayout();
			this.tlpOutROM.ResumeLayout(false);
			this.tlpOutROM.PerformLayout();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.Button buttonOK;
		private System.Windows.Forms.Button buttonCancel;
		private System.Windows.Forms.TabControl tcProjectProperties;
		private System.Windows.Forms.TabPage tpMainProperties;
		private System.Windows.Forms.TableLayoutPanel tlpProjectOptions;
		private System.Windows.Forms.Label labelProjectName;
		private System.Windows.Forms.Label labelAuthors;
		private System.Windows.Forms.Label labelGameType;
		private System.Windows.Forms.Label labelBaseROM;
		private System.Windows.Forms.TableLayoutPanel tlpBaseROM;
		private System.Windows.Forms.Button buttonOpenBaseROM;
		private System.Windows.Forms.TextBox tbBaseROMPath;
		private System.Windows.Forms.TextBox tbProjectName;
		private System.Windows.Forms.TextBox tbAuthors;
		private System.Windows.Forms.ComboBox cbGameType;
		private System.Windows.Forms.Label labelGSCodeFile;
		private System.Windows.Forms.TableLayoutPanel tlpGameSharkCodeFile;
		private System.Windows.Forms.Button buttonSetGSCodefile;
		private System.Windows.Forms.TextBox tbGSCodeFile;
		private System.Windows.Forms.TableLayoutPanel tlpCustomLoc;
		private System.Windows.Forms.Button buttonSetCustomLocFile;
		private System.Windows.Forms.TextBox tbCustomLocationFile;
		private System.Windows.Forms.CheckBox chbCustomLocation;
		private System.Windows.Forms.TabPage tpOutputRom;
		private System.Windows.Forms.TableLayoutPanel tlpOutputRom;
		private System.Windows.Forms.Label labelOutROM;
		private System.Windows.Forms.TableLayoutPanel tlpOutROM;
		private System.Windows.Forms.Button buttonSetOutROM;
		private System.Windows.Forms.TextBox tbOutROMPath;
		private System.Windows.Forms.Label labelOutRomInternalName;
		private System.Windows.Forms.TextBox tbOutRomInternalName;
		private System.Windows.Forms.TextBox tbOutRomProductCode;
		private System.Windows.Forms.Label labelOutRomGameCode;
	}
}