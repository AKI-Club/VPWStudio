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
			this.tlpProjectOptions = new System.Windows.Forms.TableLayoutPanel();
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
			this.tpOutputRom = new System.Windows.Forms.TabPage();
			this.tlpOutputRom = new System.Windows.Forms.TableLayoutPanel();
			this.labelOutROM = new System.Windows.Forms.Label();
			this.tlpOutROM = new System.Windows.Forms.TableLayoutPanel();
			this.buttonSetOutROM = new System.Windows.Forms.Button();
			this.tbOutROMPath = new System.Windows.Forms.TextBox();
			this.labelOutRomInternalName = new System.Windows.Forms.Label();
			this.tbOutRomInternalName = new System.Windows.Forms.TextBox();
			this.labelProductRegion = new System.Windows.Forms.Label();
			this.tlpRegion = new System.Windows.Forms.TableLayoutPanel();
			this.cbRegionCode = new System.Windows.Forms.ComboBox();
			this.tbRegionCode = new System.Windows.Forms.TextBox();
			this.tpOutputData = new System.Windows.Forms.TabPage();
			this.tlpOutData = new System.Windows.Forms.TableLayoutPanel();
			this.tlpInDataPath = new System.Windows.Forms.TableLayoutPanel();
			this.buttonSetInDataPath = new System.Windows.Forms.Button();
			this.tbInDataPath = new System.Windows.Forms.TextBox();
			this.labelInDataPath = new System.Windows.Forms.Label();
			this.labelOutDataPath = new System.Windows.Forms.Label();
			this.tlpOutDataPath = new System.Windows.Forms.TableLayoutPanel();
			this.tbOutDataPath = new System.Windows.Forms.TextBox();
			this.buttonSetOutDataPath = new System.Windows.Forms.Button();
			this.tpProjectFiles = new System.Windows.Forms.TabPage();
			this.tlpProjFilesTab = new System.Windows.Forms.TableLayoutPanel();
			this.tlpAssetFilesPath = new System.Windows.Forms.TableLayoutPanel();
			this.buttonSetAssetFilesPath = new System.Windows.Forms.Button();
			this.tbAssetFilesPath = new System.Windows.Forms.TextBox();
			this.tlpProjFilesPath = new System.Windows.Forms.TableLayoutPanel();
			this.buttonSetProjFilesPath = new System.Windows.Forms.Button();
			this.tbProjFilesPath = new System.Windows.Forms.TextBox();
			this.labelProjFilesPath = new System.Windows.Forms.Label();
			this.chbCustomLocation = new System.Windows.Forms.CheckBox();
			this.tlpCustomLoc = new System.Windows.Forms.TableLayoutPanel();
			this.buttonSetCustomLocFile = new System.Windows.Forms.Button();
			this.tbCustomLocationFile = new System.Windows.Forms.TextBox();
			this.labelAssetFilesPath = new System.Windows.Forms.Label();
			this.labelWrestlerNamesFile = new System.Windows.Forms.Label();
			this.tlpWrestlerNames = new System.Windows.Forms.TableLayoutPanel();
			this.buttonSetWrestlerNameFile = new System.Windows.Forms.Button();
			this.tbWrestlerNamesFile = new System.Windows.Forms.TextBox();
			this.chbCustomFileTableDB = new System.Windows.Forms.CheckBox();
			this.tlpCustomFileTableDB = new System.Windows.Forms.TableLayoutPanel();
			this.buttonSetCustomFileTableDBFile = new System.Windows.Forms.Button();
			this.tbCustomFileTableDBFile = new System.Windows.Forms.TextBox();
			this.tcProjectProperties.SuspendLayout();
			this.tpMainProperties.SuspendLayout();
			this.tlpProjectOptions.SuspendLayout();
			this.tlpBaseROM.SuspendLayout();
			this.tpOutputRom.SuspendLayout();
			this.tlpOutputRom.SuspendLayout();
			this.tlpOutROM.SuspendLayout();
			this.tlpRegion.SuspendLayout();
			this.tpOutputData.SuspendLayout();
			this.tlpOutData.SuspendLayout();
			this.tlpInDataPath.SuspendLayout();
			this.tlpOutDataPath.SuspendLayout();
			this.tpProjectFiles.SuspendLayout();
			this.tlpProjFilesTab.SuspendLayout();
			this.tlpAssetFilesPath.SuspendLayout();
			this.tlpProjFilesPath.SuspendLayout();
			this.tlpCustomLoc.SuspendLayout();
			this.tlpWrestlerNames.SuspendLayout();
			this.tlpCustomFileTableDB.SuspendLayout();
			this.SuspendLayout();
			// 
			// buttonOK
			// 
			this.buttonOK.Location = new System.Drawing.Point(366, 300);
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
			this.buttonCancel.Location = new System.Drawing.Point(447, 300);
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
			this.tcProjectProperties.Controls.Add(this.tpOutputData);
			this.tcProjectProperties.Controls.Add(this.tpProjectFiles);
			this.tcProjectProperties.Location = new System.Drawing.Point(12, 12);
			this.tcProjectProperties.Name = "tcProjectProperties";
			this.tcProjectProperties.SelectedIndex = 0;
			this.tcProjectProperties.Size = new System.Drawing.Size(510, 282);
			this.tcProjectProperties.TabIndex = 3;
			// 
			// tpMainProperties
			// 
			this.tpMainProperties.Controls.Add(this.tlpProjectOptions);
			this.tpMainProperties.Location = new System.Drawing.Point(4, 22);
			this.tpMainProperties.Name = "tpMainProperties";
			this.tpMainProperties.Padding = new System.Windows.Forms.Padding(3);
			this.tpMainProperties.Size = new System.Drawing.Size(502, 256);
			this.tpMainProperties.TabIndex = 0;
			this.tpMainProperties.Text = "Main";
			this.tpMainProperties.UseVisualStyleBackColor = true;
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
			this.tlpProjectOptions.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tlpProjectOptions.Location = new System.Drawing.Point(3, 3);
			this.tlpProjectOptions.Name = "tlpProjectOptions";
			this.tlpProjectOptions.RowCount = 4;
			this.tlpProjectOptions.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 14.28571F));
			this.tlpProjectOptions.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 14.28571F));
			this.tlpProjectOptions.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 14.28571F));
			this.tlpProjectOptions.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 14.28571F));
			this.tlpProjectOptions.Size = new System.Drawing.Size(496, 250);
			this.tlpProjectOptions.TabIndex = 3;
			// 
			// labelProjectName
			// 
			this.labelProjectName.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
			this.labelProjectName.AutoSize = true;
			this.labelProjectName.Location = new System.Drawing.Point(3, 24);
			this.labelProjectName.Name = "labelProjectName";
			this.labelProjectName.Size = new System.Drawing.Size(132, 13);
			this.labelProjectName.TabIndex = 2;
			this.labelProjectName.Text = "Project &Name";
			// 
			// labelAuthors
			// 
			this.labelAuthors.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
			this.labelAuthors.AutoSize = true;
			this.labelAuthors.Location = new System.Drawing.Point(3, 86);
			this.labelAuthors.Name = "labelAuthors";
			this.labelAuthors.Size = new System.Drawing.Size(132, 13);
			this.labelAuthors.TabIndex = 4;
			this.labelAuthors.Text = "&Author(s) (optional)";
			// 
			// labelGameType
			// 
			this.labelGameType.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
			this.labelGameType.AutoSize = true;
			this.labelGameType.Location = new System.Drawing.Point(3, 148);
			this.labelGameType.Name = "labelGameType";
			this.labelGameType.Size = new System.Drawing.Size(132, 13);
			this.labelGameType.TabIndex = 6;
			this.labelGameType.Text = "&Game Type";
			// 
			// labelBaseROM
			// 
			this.labelBaseROM.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
			this.labelBaseROM.AutoSize = true;
			this.labelBaseROM.Location = new System.Drawing.Point(3, 211);
			this.labelBaseROM.Name = "labelBaseROM";
			this.labelBaseROM.Size = new System.Drawing.Size(132, 13);
			this.labelBaseROM.TabIndex = 8;
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
			this.tlpBaseROM.Location = new System.Drawing.Point(141, 189);
			this.tlpBaseROM.Name = "tlpBaseROM";
			this.tlpBaseROM.RowCount = 1;
			this.tlpBaseROM.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.tlpBaseROM.Size = new System.Drawing.Size(352, 58);
			this.tlpBaseROM.TabIndex = 5;
			// 
			// buttonOpenBaseROM
			// 
			this.buttonOpenBaseROM.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
			this.buttonOpenBaseROM.Location = new System.Drawing.Point(319, 14);
			this.buttonOpenBaseROM.Name = "buttonOpenBaseROM";
			this.buttonOpenBaseROM.Size = new System.Drawing.Size(30, 30);
			this.buttonOpenBaseROM.TabIndex = 10;
			this.buttonOpenBaseROM.Text = "...";
			this.buttonOpenBaseROM.UseVisualStyleBackColor = true;
			this.buttonOpenBaseROM.Click += new System.EventHandler(this.buttonOpenBaseROM_Click);
			// 
			// tbBaseROMPath
			// 
			this.tbBaseROMPath.AllowDrop = true;
			this.tbBaseROMPath.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
			this.tbBaseROMPath.Location = new System.Drawing.Point(3, 19);
			this.tbBaseROMPath.Name = "tbBaseROMPath";
			this.tbBaseROMPath.Size = new System.Drawing.Size(310, 20);
			this.tbBaseROMPath.TabIndex = 9;
			this.tbBaseROMPath.DragDrop += new System.Windows.Forms.DragEventHandler(this.tbBaseROMPath_DragDrop);
			this.tbBaseROMPath.DragEnter += new System.Windows.Forms.DragEventHandler(this.tbBaseROMPath_DragEnter);
			// 
			// tbProjectName
			// 
			this.tbProjectName.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
			this.tbProjectName.Location = new System.Drawing.Point(141, 21);
			this.tbProjectName.Name = "tbProjectName";
			this.tbProjectName.Size = new System.Drawing.Size(352, 20);
			this.tbProjectName.TabIndex = 3;
			// 
			// tbAuthors
			// 
			this.tbAuthors.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
			this.tbAuthors.Location = new System.Drawing.Point(141, 83);
			this.tbAuthors.Name = "tbAuthors";
			this.tbAuthors.Size = new System.Drawing.Size(352, 20);
			this.tbAuthors.TabIndex = 5;
			// 
			// cbGameType
			// 
			this.cbGameType.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
			this.cbGameType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cbGameType.FormattingEnabled = true;
			this.cbGameType.Location = new System.Drawing.Point(141, 144);
			this.cbGameType.Name = "cbGameType";
			this.cbGameType.Size = new System.Drawing.Size(352, 21);
			this.cbGameType.TabIndex = 7;
			this.cbGameType.SelectedIndexChanged += new System.EventHandler(this.cbGameType_SelectedIndexChanged);
			// 
			// tpOutputRom
			// 
			this.tpOutputRom.Controls.Add(this.tlpOutputRom);
			this.tpOutputRom.Location = new System.Drawing.Point(4, 22);
			this.tpOutputRom.Name = "tpOutputRom";
			this.tpOutputRom.Padding = new System.Windows.Forms.Padding(3);
			this.tpOutputRom.Size = new System.Drawing.Size(502, 256);
			this.tpOutputRom.TabIndex = 1;
			this.tpOutputRom.Text = "Output ROM (N64)";
			this.tpOutputRom.UseVisualStyleBackColor = true;
			// 
			// tlpOutputRom
			// 
			this.tlpOutputRom.ColumnCount = 2;
			this.tlpOutputRom.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
			this.tlpOutputRom.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 75F));
			this.tlpOutputRom.Controls.Add(this.labelOutROM, 0, 0);
			this.tlpOutputRom.Controls.Add(this.tlpOutROM, 1, 0);
			this.tlpOutputRom.Controls.Add(this.labelOutRomInternalName, 0, 1);
			this.tlpOutputRom.Controls.Add(this.tbOutRomInternalName, 1, 1);
			this.tlpOutputRom.Controls.Add(this.labelProductRegion, 0, 2);
			this.tlpOutputRom.Controls.Add(this.tlpRegion, 1, 2);
			this.tlpOutputRom.Location = new System.Drawing.Point(3, 3);
			this.tlpOutputRom.Name = "tlpOutputRom";
			this.tlpOutputRom.RowCount = 3;
			this.tlpOutputRom.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
			this.tlpOutputRom.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
			this.tlpOutputRom.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
			this.tlpOutputRom.Size = new System.Drawing.Size(496, 247);
			this.tlpOutputRom.TabIndex = 0;
			// 
			// labelOutROM
			// 
			this.labelOutROM.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
			this.labelOutROM.AutoSize = true;
			this.labelOutROM.Location = new System.Drawing.Point(3, 34);
			this.labelOutROM.Name = "labelOutROM";
			this.labelOutROM.Size = new System.Drawing.Size(118, 13);
			this.labelOutROM.TabIndex = 2;
			this.labelOutROM.Text = "O&utput ROM File";
			// 
			// tlpOutROM
			// 
			this.tlpOutROM.ColumnCount = 2;
			this.tlpOutROM.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 90F));
			this.tlpOutROM.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10F));
			this.tlpOutROM.Controls.Add(this.buttonSetOutROM, 1, 0);
			this.tlpOutROM.Controls.Add(this.tbOutROMPath, 0, 0);
			this.tlpOutROM.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tlpOutROM.Location = new System.Drawing.Point(127, 3);
			this.tlpOutROM.Name = "tlpOutROM";
			this.tlpOutROM.RowCount = 1;
			this.tlpOutROM.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.tlpOutROM.Size = new System.Drawing.Size(366, 76);
			this.tlpOutROM.TabIndex = 7;
			// 
			// buttonSetOutROM
			// 
			this.buttonSetOutROM.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
			this.buttonSetOutROM.Location = new System.Drawing.Point(332, 23);
			this.buttonSetOutROM.Name = "buttonSetOutROM";
			this.buttonSetOutROM.Size = new System.Drawing.Size(31, 30);
			this.buttonSetOutROM.TabIndex = 4;
			this.buttonSetOutROM.Text = "...";
			this.buttonSetOutROM.UseVisualStyleBackColor = true;
			this.buttonSetOutROM.Click += new System.EventHandler(this.buttonSetOutROM_Click);
			// 
			// tbOutROMPath
			// 
			this.tbOutROMPath.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
			this.tbOutROMPath.Location = new System.Drawing.Point(3, 28);
			this.tbOutROMPath.Name = "tbOutROMPath";
			this.tbOutROMPath.Size = new System.Drawing.Size(323, 20);
			this.tbOutROMPath.TabIndex = 3;
			// 
			// labelOutRomInternalName
			// 
			this.labelOutRomInternalName.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
			this.labelOutRomInternalName.AutoSize = true;
			this.labelOutRomInternalName.Location = new System.Drawing.Point(3, 116);
			this.labelOutRomInternalName.Name = "labelOutRomInternalName";
			this.labelOutRomInternalName.Size = new System.Drawing.Size(118, 13);
			this.labelOutRomInternalName.TabIndex = 5;
			this.labelOutRomInternalName.Text = "Internal Game &Name";
			// 
			// tbOutRomInternalName
			// 
			this.tbOutRomInternalName.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
			this.tbOutRomInternalName.Location = new System.Drawing.Point(127, 113);
			this.tbOutRomInternalName.MaxLength = 20;
			this.tbOutRomInternalName.Name = "tbOutRomInternalName";
			this.tbOutRomInternalName.Size = new System.Drawing.Size(366, 20);
			this.tbOutRomInternalName.TabIndex = 6;
			// 
			// labelProductRegion
			// 
			this.labelProductRegion.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
			this.labelProductRegion.AutoSize = true;
			this.labelProductRegion.Location = new System.Drawing.Point(3, 199);
			this.labelProductRegion.Name = "labelProductRegion";
			this.labelProductRegion.Size = new System.Drawing.Size(118, 13);
			this.labelProductRegion.TabIndex = 9;
			this.labelProductRegion.Text = "Product &Region";
			// 
			// tlpRegion
			// 
			this.tlpRegion.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
			this.tlpRegion.ColumnCount = 2;
			this.tlpRegion.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 70F));
			this.tlpRegion.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 30F));
			this.tlpRegion.Controls.Add(this.cbRegionCode, 0, 0);
			this.tlpRegion.Controls.Add(this.tbRegionCode, 1, 0);
			this.tlpRegion.Location = new System.Drawing.Point(127, 179);
			this.tlpRegion.Name = "tlpRegion";
			this.tlpRegion.RowCount = 1;
			this.tlpRegion.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.tlpRegion.Size = new System.Drawing.Size(366, 53);
			this.tlpRegion.TabIndex = 1;
			// 
			// cbRegionCode
			// 
			this.cbRegionCode.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
			this.cbRegionCode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cbRegionCode.FormattingEnabled = true;
			this.cbRegionCode.Location = new System.Drawing.Point(3, 16);
			this.cbRegionCode.Name = "cbRegionCode";
			this.cbRegionCode.Size = new System.Drawing.Size(250, 21);
			this.cbRegionCode.TabIndex = 10;
			this.cbRegionCode.SelectedIndexChanged += new System.EventHandler(this.cbRegionCode_SelectedIndexChanged);
			// 
			// tbRegionCode
			// 
			this.tbRegionCode.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
			this.tbRegionCode.Location = new System.Drawing.Point(259, 16);
			this.tbRegionCode.MaxLength = 1;
			this.tbRegionCode.Name = "tbRegionCode";
			this.tbRegionCode.ReadOnly = true;
			this.tbRegionCode.Size = new System.Drawing.Size(104, 20);
			this.tbRegionCode.TabIndex = 11;
			// 
			// tpOutputData
			// 
			this.tpOutputData.Controls.Add(this.tlpOutData);
			this.tpOutputData.Location = new System.Drawing.Point(4, 22);
			this.tpOutputData.Name = "tpOutputData";
			this.tpOutputData.Padding = new System.Windows.Forms.Padding(3);
			this.tpOutputData.Size = new System.Drawing.Size(502, 256);
			this.tpOutputData.TabIndex = 3;
			this.tpOutputData.Text = "Output Data (PS1)";
			this.tpOutputData.UseVisualStyleBackColor = true;
			// 
			// tlpOutData
			// 
			this.tlpOutData.ColumnCount = 2;
			this.tlpOutData.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
			this.tlpOutData.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 75F));
			this.tlpOutData.Controls.Add(this.tlpInDataPath, 1, 0);
			this.tlpOutData.Controls.Add(this.labelInDataPath, 0, 0);
			this.tlpOutData.Controls.Add(this.labelOutDataPath, 0, 1);
			this.tlpOutData.Controls.Add(this.tlpOutDataPath, 1, 1);
			this.tlpOutData.Location = new System.Drawing.Point(3, 3);
			this.tlpOutData.Name = "tlpOutData";
			this.tlpOutData.RowCount = 2;
			this.tlpOutData.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
			this.tlpOutData.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
			this.tlpOutData.Size = new System.Drawing.Size(496, 250);
			this.tlpOutData.TabIndex = 0;
			// 
			// tlpInDataPath
			// 
			this.tlpInDataPath.ColumnCount = 2;
			this.tlpInDataPath.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 75F));
			this.tlpInDataPath.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
			this.tlpInDataPath.Controls.Add(this.buttonSetInDataPath, 1, 0);
			this.tlpInDataPath.Controls.Add(this.tbInDataPath, 0, 0);
			this.tlpInDataPath.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tlpInDataPath.Location = new System.Drawing.Point(127, 3);
			this.tlpInDataPath.Name = "tlpInDataPath";
			this.tlpInDataPath.RowCount = 1;
			this.tlpInDataPath.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.tlpInDataPath.Size = new System.Drawing.Size(366, 119);
			this.tlpInDataPath.TabIndex = 4;
			// 
			// buttonSetInDataPath
			// 
			this.buttonSetInDataPath.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
			this.buttonSetInDataPath.Location = new System.Drawing.Point(277, 48);
			this.buttonSetInDataPath.Name = "buttonSetInDataPath";
			this.buttonSetInDataPath.Size = new System.Drawing.Size(86, 23);
			this.buttonSetInDataPath.TabIndex = 0;
			this.buttonSetInDataPath.Text = "...";
			this.buttonSetInDataPath.UseVisualStyleBackColor = true;
			this.buttonSetInDataPath.Click += new System.EventHandler(this.buttonSetInDataPath_Click);
			// 
			// tbInDataPath
			// 
			this.tbInDataPath.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
			this.tbInDataPath.Location = new System.Drawing.Point(3, 49);
			this.tbInDataPath.Name = "tbInDataPath";
			this.tbInDataPath.Size = new System.Drawing.Size(268, 20);
			this.tbInDataPath.TabIndex = 2;
			// 
			// labelInDataPath
			// 
			this.labelInDataPath.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
			this.labelInDataPath.AutoSize = true;
			this.labelInDataPath.Location = new System.Drawing.Point(3, 56);
			this.labelInDataPath.Name = "labelInDataPath";
			this.labelInDataPath.Size = new System.Drawing.Size(118, 13);
			this.labelInDataPath.TabIndex = 0;
			this.labelInDataPath.Text = "&Input Data Path";
			// 
			// labelOutDataPath
			// 
			this.labelOutDataPath.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
			this.labelOutDataPath.AutoSize = true;
			this.labelOutDataPath.Location = new System.Drawing.Point(3, 181);
			this.labelOutDataPath.Name = "labelOutDataPath";
			this.labelOutDataPath.Size = new System.Drawing.Size(118, 13);
			this.labelOutDataPath.TabIndex = 1;
			this.labelOutDataPath.Text = "Ou&tput Data Path";
			// 
			// tlpOutDataPath
			// 
			this.tlpOutDataPath.ColumnCount = 2;
			this.tlpOutDataPath.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 75F));
			this.tlpOutDataPath.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
			this.tlpOutDataPath.Controls.Add(this.tbOutDataPath, 0, 0);
			this.tlpOutDataPath.Controls.Add(this.buttonSetOutDataPath, 1, 0);
			this.tlpOutDataPath.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tlpOutDataPath.Location = new System.Drawing.Point(127, 128);
			this.tlpOutDataPath.Name = "tlpOutDataPath";
			this.tlpOutDataPath.RowCount = 1;
			this.tlpOutDataPath.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.tlpOutDataPath.Size = new System.Drawing.Size(366, 119);
			this.tlpOutDataPath.TabIndex = 5;
			// 
			// tbOutDataPath
			// 
			this.tbOutDataPath.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
			this.tbOutDataPath.Location = new System.Drawing.Point(3, 49);
			this.tbOutDataPath.Name = "tbOutDataPath";
			this.tbOutDataPath.Size = new System.Drawing.Size(268, 20);
			this.tbOutDataPath.TabIndex = 3;
			// 
			// buttonSetOutDataPath
			// 
			this.buttonSetOutDataPath.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
			this.buttonSetOutDataPath.Location = new System.Drawing.Point(277, 48);
			this.buttonSetOutDataPath.Name = "buttonSetOutDataPath";
			this.buttonSetOutDataPath.Size = new System.Drawing.Size(86, 23);
			this.buttonSetOutDataPath.TabIndex = 4;
			this.buttonSetOutDataPath.Text = "...";
			this.buttonSetOutDataPath.UseVisualStyleBackColor = true;
			this.buttonSetOutDataPath.Click += new System.EventHandler(this.buttonSetOutDataPath_Click);
			// 
			// tpProjectFiles
			// 
			this.tpProjectFiles.Controls.Add(this.tlpProjFilesTab);
			this.tpProjectFiles.Location = new System.Drawing.Point(4, 22);
			this.tpProjectFiles.Name = "tpProjectFiles";
			this.tpProjectFiles.Padding = new System.Windows.Forms.Padding(3);
			this.tpProjectFiles.Size = new System.Drawing.Size(502, 256);
			this.tpProjectFiles.TabIndex = 2;
			this.tpProjectFiles.Text = "Project Files";
			this.tpProjectFiles.UseVisualStyleBackColor = true;
			// 
			// tlpProjFilesTab
			// 
			this.tlpProjFilesTab.ColumnCount = 2;
			this.tlpProjFilesTab.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 35F));
			this.tlpProjFilesTab.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 65F));
			this.tlpProjFilesTab.Controls.Add(this.tlpAssetFilesPath, 1, 1);
			this.tlpProjFilesTab.Controls.Add(this.tlpProjFilesPath, 1, 0);
			this.tlpProjFilesTab.Controls.Add(this.labelProjFilesPath, 0, 0);
			this.tlpProjFilesTab.Controls.Add(this.tlpWrestlerNames, 1, 4);
			this.tlpProjFilesTab.Controls.Add(this.labelWrestlerNamesFile, 0, 4);
			this.tlpProjFilesTab.Controls.Add(this.chbCustomLocation, 0, 2);
			this.tlpProjFilesTab.Controls.Add(this.tlpCustomLoc, 1, 2);
			this.tlpProjFilesTab.Controls.Add(this.labelAssetFilesPath, 0, 1);
			this.tlpProjFilesTab.Controls.Add(this.chbCustomFileTableDB, 0, 3);
			this.tlpProjFilesTab.Controls.Add(this.tlpCustomFileTableDB, 1, 3);
			this.tlpProjFilesTab.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tlpProjFilesTab.Location = new System.Drawing.Point(3, 3);
			this.tlpProjFilesTab.Name = "tlpProjFilesTab";
			this.tlpProjFilesTab.RowCount = 5;
			this.tlpProjFilesTab.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
			this.tlpProjFilesTab.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
			this.tlpProjFilesTab.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
			this.tlpProjFilesTab.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
			this.tlpProjFilesTab.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
			this.tlpProjFilesTab.Size = new System.Drawing.Size(496, 250);
			this.tlpProjFilesTab.TabIndex = 2;
			// 
			// tlpAssetFilesPath
			// 
			this.tlpAssetFilesPath.ColumnCount = 2;
			this.tlpAssetFilesPath.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 90F));
			this.tlpAssetFilesPath.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10F));
			this.tlpAssetFilesPath.Controls.Add(this.buttonSetAssetFilesPath, 1, 0);
			this.tlpAssetFilesPath.Controls.Add(this.tbAssetFilesPath, 0, 0);
			this.tlpAssetFilesPath.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tlpAssetFilesPath.Location = new System.Drawing.Point(176, 53);
			this.tlpAssetFilesPath.Name = "tlpAssetFilesPath";
			this.tlpAssetFilesPath.RowCount = 1;
			this.tlpAssetFilesPath.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.tlpAssetFilesPath.Size = new System.Drawing.Size(317, 44);
			this.tlpAssetFilesPath.TabIndex = 20;
			// 
			// buttonSetAssetFilesPath
			// 
			this.buttonSetAssetFilesPath.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
			this.buttonSetAssetFilesPath.Location = new System.Drawing.Point(288, 7);
			this.buttonSetAssetFilesPath.Name = "buttonSetAssetFilesPath";
			this.buttonSetAssetFilesPath.Size = new System.Drawing.Size(26, 29);
			this.buttonSetAssetFilesPath.TabIndex = 7;
			this.buttonSetAssetFilesPath.Text = "...";
			this.buttonSetAssetFilesPath.UseVisualStyleBackColor = true;
			this.buttonSetAssetFilesPath.Click += new System.EventHandler(this.buttonSetAssetFilesPath_Click);
			// 
			// tbAssetFilesPath
			// 
			this.tbAssetFilesPath.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
			this.tbAssetFilesPath.Location = new System.Drawing.Point(3, 12);
			this.tbAssetFilesPath.Name = "tbAssetFilesPath";
			this.tbAssetFilesPath.Size = new System.Drawing.Size(279, 20);
			this.tbAssetFilesPath.TabIndex = 6;
			// 
			// tlpProjFilesPath
			// 
			this.tlpProjFilesPath.ColumnCount = 2;
			this.tlpProjFilesPath.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 90F));
			this.tlpProjFilesPath.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10F));
			this.tlpProjFilesPath.Controls.Add(this.buttonSetProjFilesPath, 1, 0);
			this.tlpProjFilesPath.Controls.Add(this.tbProjFilesPath, 0, 0);
			this.tlpProjFilesPath.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tlpProjFilesPath.Location = new System.Drawing.Point(176, 3);
			this.tlpProjFilesPath.Name = "tlpProjFilesPath";
			this.tlpProjFilesPath.RowCount = 1;
			this.tlpProjFilesPath.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.tlpProjFilesPath.Size = new System.Drawing.Size(317, 44);
			this.tlpProjFilesPath.TabIndex = 18;
			// 
			// buttonSetProjFilesPath
			// 
			this.buttonSetProjFilesPath.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
			this.buttonSetProjFilesPath.Location = new System.Drawing.Point(288, 7);
			this.buttonSetProjFilesPath.Name = "buttonSetProjFilesPath";
			this.buttonSetProjFilesPath.Size = new System.Drawing.Size(26, 29);
			this.buttonSetProjFilesPath.TabIndex = 4;
			this.buttonSetProjFilesPath.Text = "...";
			this.buttonSetProjFilesPath.UseVisualStyleBackColor = true;
			this.buttonSetProjFilesPath.Click += new System.EventHandler(this.buttonSetProjFilesPath_Click);
			// 
			// tbProjFilesPath
			// 
			this.tbProjFilesPath.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
			this.tbProjFilesPath.Location = new System.Drawing.Point(3, 12);
			this.tbProjFilesPath.Name = "tbProjFilesPath";
			this.tbProjFilesPath.Size = new System.Drawing.Size(279, 20);
			this.tbProjFilesPath.TabIndex = 3;
			// 
			// labelProjFilesPath
			// 
			this.labelProjFilesPath.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
			this.labelProjFilesPath.AutoSize = true;
			this.labelProjFilesPath.Location = new System.Drawing.Point(3, 18);
			this.labelProjFilesPath.Name = "labelProjFilesPath";
			this.labelProjFilesPath.Size = new System.Drawing.Size(167, 13);
			this.labelProjFilesPath.TabIndex = 2;
			this.labelProjFilesPath.Text = "&Project Files Path";
			// 
			// chbCustomLocation
			// 
			this.chbCustomLocation.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
			this.chbCustomLocation.AutoSize = true;
			this.chbCustomLocation.Location = new System.Drawing.Point(3, 116);
			this.chbCustomLocation.Name = "chbCustomLocation";
			this.chbCustomLocation.Size = new System.Drawing.Size(167, 17);
			this.chbCustomLocation.TabIndex = 8;
			this.chbCustomLocation.Text = "Custom &Location File";
			this.chbCustomLocation.UseVisualStyleBackColor = true;
			this.chbCustomLocation.Click += new System.EventHandler(this.chbCustomLocation_Click);
			// 
			// tlpCustomLoc
			// 
			this.tlpCustomLoc.ColumnCount = 2;
			this.tlpCustomLoc.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 90F));
			this.tlpCustomLoc.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10F));
			this.tlpCustomLoc.Controls.Add(this.buttonSetCustomLocFile, 1, 0);
			this.tlpCustomLoc.Controls.Add(this.tbCustomLocationFile, 0, 0);
			this.tlpCustomLoc.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tlpCustomLoc.Location = new System.Drawing.Point(176, 103);
			this.tlpCustomLoc.Name = "tlpCustomLoc";
			this.tlpCustomLoc.RowCount = 1;
			this.tlpCustomLoc.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.tlpCustomLoc.Size = new System.Drawing.Size(317, 44);
			this.tlpCustomLoc.TabIndex = 16;
			// 
			// buttonSetCustomLocFile
			// 
			this.buttonSetCustomLocFile.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
			this.buttonSetCustomLocFile.Enabled = false;
			this.buttonSetCustomLocFile.Location = new System.Drawing.Point(288, 7);
			this.buttonSetCustomLocFile.Name = "buttonSetCustomLocFile";
			this.buttonSetCustomLocFile.Size = new System.Drawing.Size(26, 29);
			this.buttonSetCustomLocFile.TabIndex = 10;
			this.buttonSetCustomLocFile.Text = "...";
			this.buttonSetCustomLocFile.UseVisualStyleBackColor = true;
			this.buttonSetCustomLocFile.Click += new System.EventHandler(this.buttonSetCustomLocFile_Click);
			// 
			// tbCustomLocationFile
			// 
			this.tbCustomLocationFile.AllowDrop = true;
			this.tbCustomLocationFile.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
			this.tbCustomLocationFile.Enabled = false;
			this.tbCustomLocationFile.Location = new System.Drawing.Point(3, 12);
			this.tbCustomLocationFile.Name = "tbCustomLocationFile";
			this.tbCustomLocationFile.Size = new System.Drawing.Size(279, 20);
			this.tbCustomLocationFile.TabIndex = 9;
			this.tbCustomLocationFile.DragDrop += new System.Windows.Forms.DragEventHandler(this.tbCustomLocationFile_DragDrop);
			this.tbCustomLocationFile.DragEnter += new System.Windows.Forms.DragEventHandler(this.tbCustomLocationFile_DragEnter);
			// 
			// labelAssetFilesPath
			// 
			this.labelAssetFilesPath.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
			this.labelAssetFilesPath.AutoSize = true;
			this.labelAssetFilesPath.Location = new System.Drawing.Point(3, 68);
			this.labelAssetFilesPath.Name = "labelAssetFilesPath";
			this.labelAssetFilesPath.Size = new System.Drawing.Size(167, 13);
			this.labelAssetFilesPath.TabIndex = 5;
			this.labelAssetFilesPath.Text = "&Asset Files Path";
			// 
			// labelWrestlerNamesFile
			// 
			this.labelWrestlerNamesFile.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
			this.labelWrestlerNamesFile.AutoSize = true;
			this.labelWrestlerNamesFile.Location = new System.Drawing.Point(3, 218);
			this.labelWrestlerNamesFile.Name = "labelWrestlerNamesFile";
			this.labelWrestlerNamesFile.Size = new System.Drawing.Size(167, 13);
			this.labelWrestlerNamesFile.TabIndex = 22;
			this.labelWrestlerNamesFile.Text = "Wrestler &Names File";
			// 
			// tlpWrestlerNames
			// 
			this.tlpWrestlerNames.ColumnCount = 2;
			this.tlpWrestlerNames.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 90F));
			this.tlpWrestlerNames.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10F));
			this.tlpWrestlerNames.Controls.Add(this.buttonSetWrestlerNameFile, 1, 0);
			this.tlpWrestlerNames.Controls.Add(this.tbWrestlerNamesFile, 0, 0);
			this.tlpWrestlerNames.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tlpWrestlerNames.Location = new System.Drawing.Point(176, 203);
			this.tlpWrestlerNames.Name = "tlpWrestlerNames";
			this.tlpWrestlerNames.RowCount = 1;
			this.tlpWrestlerNames.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.tlpWrestlerNames.Size = new System.Drawing.Size(317, 44);
			this.tlpWrestlerNames.TabIndex = 23;
			// 
			// buttonSetWrestlerNameFile
			// 
			this.buttonSetWrestlerNameFile.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
			this.buttonSetWrestlerNameFile.Location = new System.Drawing.Point(288, 7);
			this.buttonSetWrestlerNameFile.Name = "buttonSetWrestlerNameFile";
			this.buttonSetWrestlerNameFile.Size = new System.Drawing.Size(26, 29);
			this.buttonSetWrestlerNameFile.TabIndex = 13;
			this.buttonSetWrestlerNameFile.Text = "...";
			this.buttonSetWrestlerNameFile.UseVisualStyleBackColor = true;
			this.buttonSetWrestlerNameFile.Click += new System.EventHandler(this.buttonSetWrestlerNameFile_Click);
			// 
			// tbWrestlerNamesFile
			// 
			this.tbWrestlerNamesFile.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
			this.tbWrestlerNamesFile.Location = new System.Drawing.Point(3, 12);
			this.tbWrestlerNamesFile.Name = "tbWrestlerNamesFile";
			this.tbWrestlerNamesFile.Size = new System.Drawing.Size(279, 20);
			this.tbWrestlerNamesFile.TabIndex = 12;
			// 
			// chbCustomFileTableDB
			// 
			this.chbCustomFileTableDB.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
			this.chbCustomFileTableDB.AutoSize = true;
			this.chbCustomFileTableDB.Location = new System.Drawing.Point(3, 166);
			this.chbCustomFileTableDB.Name = "chbCustomFileTableDB";
			this.chbCustomFileTableDB.Size = new System.Drawing.Size(167, 17);
			this.chbCustomFileTableDB.TabIndex = 24;
			this.chbCustomFileTableDB.Text = "Custom &FileTableDB File";
			this.chbCustomFileTableDB.UseVisualStyleBackColor = true;
			this.chbCustomFileTableDB.Click += new System.EventHandler(this.chbCustomFileTableDB_Click);
			// 
			// tlpCustomFileTableDB
			// 
			this.tlpCustomFileTableDB.ColumnCount = 2;
			this.tlpCustomFileTableDB.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 90F));
			this.tlpCustomFileTableDB.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10F));
			this.tlpCustomFileTableDB.Controls.Add(this.buttonSetCustomFileTableDBFile, 1, 0);
			this.tlpCustomFileTableDB.Controls.Add(this.tbCustomFileTableDBFile, 0, 0);
			this.tlpCustomFileTableDB.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tlpCustomFileTableDB.Location = new System.Drawing.Point(176, 153);
			this.tlpCustomFileTableDB.Name = "tlpCustomFileTableDB";
			this.tlpCustomFileTableDB.RowCount = 1;
			this.tlpCustomFileTableDB.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.tlpCustomFileTableDB.Size = new System.Drawing.Size(317, 44);
			this.tlpCustomFileTableDB.TabIndex = 25;
			// 
			// buttonSetCustomFileTableDBFile
			// 
			this.buttonSetCustomFileTableDBFile.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
			this.buttonSetCustomFileTableDBFile.Enabled = false;
			this.buttonSetCustomFileTableDBFile.Location = new System.Drawing.Point(288, 7);
			this.buttonSetCustomFileTableDBFile.Name = "buttonSetCustomFileTableDBFile";
			this.buttonSetCustomFileTableDBFile.Size = new System.Drawing.Size(26, 29);
			this.buttonSetCustomFileTableDBFile.TabIndex = 10;
			this.buttonSetCustomFileTableDBFile.Text = "...";
			this.buttonSetCustomFileTableDBFile.UseVisualStyleBackColor = true;
			this.buttonSetCustomFileTableDBFile.Click += new System.EventHandler(this.buttonSetCustomFileTableDBFile_Click);
			// 
			// tbCustomFileTableDBFile
			// 
			this.tbCustomFileTableDBFile.AllowDrop = true;
			this.tbCustomFileTableDBFile.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
			this.tbCustomFileTableDBFile.Enabled = false;
			this.tbCustomFileTableDBFile.Location = new System.Drawing.Point(3, 12);
			this.tbCustomFileTableDBFile.Name = "tbCustomFileTableDBFile";
			this.tbCustomFileTableDBFile.Size = new System.Drawing.Size(279, 20);
			this.tbCustomFileTableDBFile.TabIndex = 9;
			this.tbCustomFileTableDBFile.DragDrop += new System.Windows.Forms.DragEventHandler(this.tbCustomFileTableDBFile_DragDrop);
			this.tbCustomFileTableDBFile.DragEnter += new System.Windows.Forms.DragEventHandler(this.tbCustomFileTableDBFile_DragEnter);
			// 
			// ProjectPropertiesDialog
			// 
			this.AcceptButton = this.buttonOK;
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.CancelButton = this.buttonCancel;
			this.ClientSize = new System.Drawing.Size(534, 335);
			this.Controls.Add(this.tcProjectProperties);
			this.Controls.Add(this.buttonCancel);
			this.Controls.Add(this.buttonOK);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.MinimumSize = new System.Drawing.Size(500, 360);
			this.Name = "ProjectPropertiesDialog";
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "Project Properties";
			this.tcProjectProperties.ResumeLayout(false);
			this.tpMainProperties.ResumeLayout(false);
			this.tlpProjectOptions.ResumeLayout(false);
			this.tlpProjectOptions.PerformLayout();
			this.tlpBaseROM.ResumeLayout(false);
			this.tlpBaseROM.PerformLayout();
			this.tpOutputRom.ResumeLayout(false);
			this.tlpOutputRom.ResumeLayout(false);
			this.tlpOutputRom.PerformLayout();
			this.tlpOutROM.ResumeLayout(false);
			this.tlpOutROM.PerformLayout();
			this.tlpRegion.ResumeLayout(false);
			this.tlpRegion.PerformLayout();
			this.tpOutputData.ResumeLayout(false);
			this.tlpOutData.ResumeLayout(false);
			this.tlpOutData.PerformLayout();
			this.tlpInDataPath.ResumeLayout(false);
			this.tlpInDataPath.PerformLayout();
			this.tlpOutDataPath.ResumeLayout(false);
			this.tlpOutDataPath.PerformLayout();
			this.tpProjectFiles.ResumeLayout(false);
			this.tlpProjFilesTab.ResumeLayout(false);
			this.tlpProjFilesTab.PerformLayout();
			this.tlpAssetFilesPath.ResumeLayout(false);
			this.tlpAssetFilesPath.PerformLayout();
			this.tlpProjFilesPath.ResumeLayout(false);
			this.tlpProjFilesPath.PerformLayout();
			this.tlpCustomLoc.ResumeLayout(false);
			this.tlpCustomLoc.PerformLayout();
			this.tlpWrestlerNames.ResumeLayout(false);
			this.tlpWrestlerNames.PerformLayout();
			this.tlpCustomFileTableDB.ResumeLayout(false);
			this.tlpCustomFileTableDB.PerformLayout();
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
		private System.Windows.Forms.TabPage tpOutputRom;
		private System.Windows.Forms.TableLayoutPanel tlpOutputRom;
		private System.Windows.Forms.Label labelOutROM;
		private System.Windows.Forms.TableLayoutPanel tlpOutROM;
		private System.Windows.Forms.Button buttonSetOutROM;
		private System.Windows.Forms.TextBox tbOutROMPath;
		private System.Windows.Forms.Label labelOutRomInternalName;
		private System.Windows.Forms.TextBox tbOutRomInternalName;
		private System.Windows.Forms.TabPage tpProjectFiles;
		private System.Windows.Forms.TableLayoutPanel tlpProjFilesTab;
		private System.Windows.Forms.TableLayoutPanel tlpProjFilesPath;
		private System.Windows.Forms.Button buttonSetProjFilesPath;
		private System.Windows.Forms.TextBox tbProjFilesPath;
		private System.Windows.Forms.CheckBox chbCustomLocation;
		private System.Windows.Forms.TableLayoutPanel tlpCustomLoc;
		private System.Windows.Forms.Button buttonSetCustomLocFile;
		private System.Windows.Forms.TextBox tbCustomLocationFile;
		private System.Windows.Forms.Label labelProjFilesPath;
		private System.Windows.Forms.Label labelAssetFilesPath;
		private System.Windows.Forms.TableLayoutPanel tlpAssetFilesPath;
		private System.Windows.Forms.Button buttonSetAssetFilesPath;
		private System.Windows.Forms.TextBox tbAssetFilesPath;
		private System.Windows.Forms.TableLayoutPanel tlpRegion;
		private System.Windows.Forms.ComboBox cbRegionCode;
		private System.Windows.Forms.Label labelProductRegion;
		private System.Windows.Forms.TextBox tbRegionCode;
		private System.Windows.Forms.Label labelWrestlerNamesFile;
		private System.Windows.Forms.TableLayoutPanel tlpWrestlerNames;
		private System.Windows.Forms.Button buttonSetWrestlerNameFile;
		private System.Windows.Forms.TextBox tbWrestlerNamesFile;
		private System.Windows.Forms.TabPage tpOutputData;
		private System.Windows.Forms.TableLayoutPanel tlpOutData;
		private System.Windows.Forms.Label labelInDataPath;
		private System.Windows.Forms.Label labelOutDataPath;
		private System.Windows.Forms.TextBox tbInDataPath;
		private System.Windows.Forms.TextBox tbOutDataPath;
		private System.Windows.Forms.TableLayoutPanel tlpInDataPath;
		private System.Windows.Forms.Button buttonSetInDataPath;
		private System.Windows.Forms.TableLayoutPanel tlpOutDataPath;
		private System.Windows.Forms.Button buttonSetOutDataPath;
		private System.Windows.Forms.CheckBox chbCustomFileTableDB;
		private System.Windows.Forms.TableLayoutPanel tlpCustomFileTableDB;
		private System.Windows.Forms.Button buttonSetCustomFileTableDBFile;
		private System.Windows.Forms.TextBox tbCustomFileTableDBFile;
	}
}