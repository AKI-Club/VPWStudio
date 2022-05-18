namespace VPWStudio.Editors.NoMercy
{
	partial class WrestlerMain_NoMercy
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
			this.lbWrestlers = new System.Windows.Forms.ListBox();
			this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
			this.tlpHeight = new System.Windows.Forms.TableLayoutPanel();
			this.nudHeight = new System.Windows.Forms.NumericUpDown();
			this.labelHeightValue = new System.Windows.Forms.Label();
			this.cbEntranceVideo = new System.Windows.Forms.ComboBox();
			this.cbThemeMusic = new System.Windows.Forms.ComboBox();
			this.tbUnknown = new System.Windows.Forms.TextBox();
			this.tbWrestlerID4 = new System.Windows.Forms.TextBox();
			this.tbWrestlerID2 = new System.Windows.Forms.TextBox();
			this.labelWrestlerID4 = new System.Windows.Forms.Label();
			this.labelWrestlerID2 = new System.Windows.Forms.Label();
			this.labelEntranceVideo = new System.Windows.Forms.Label();
			this.labelHeight = new System.Windows.Forms.Label();
			this.labelUnknown = new System.Windows.Forms.Label();
			this.labelWeight = new System.Windows.Forms.Label();
			this.labelMovesetIndex = new System.Windows.Forms.Label();
			this.labelParamsIndex = new System.Windows.Forms.Label();
			this.tlpParams = new System.Windows.Forms.TableLayoutPanel();
			this.buttonParams = new System.Windows.Forms.Button();
			this.tbParamsIndex = new System.Windows.Forms.TextBox();
			this.tlpMoveset = new System.Windows.Forms.TableLayoutPanel();
			this.tbMovesetIndex = new System.Windows.Forms.TextBox();
			this.buttonMoveset = new System.Windows.Forms.Button();
			this.labelAppearanceIndex = new System.Windows.Forms.Label();
			this.labelProfileIndex = new System.Windows.Forms.Label();
			this.tlpProfile = new System.Windows.Forms.TableLayoutPanel();
			this.nudProfileIndex = new System.Windows.Forms.NumericUpDown();
			this.buttonProfile = new System.Windows.Forms.Button();
			this.tlpAppearance = new System.Windows.Forms.TableLayoutPanel();
			this.buttonAppearance = new System.Windows.Forms.Button();
			this.tbAppearanceIndex = new System.Windows.Forms.TextBox();
			this.labelThemeMusic = new System.Windows.Forms.Label();
			this.tlpWeight = new System.Windows.Forms.TableLayoutPanel();
			this.labelWeightValue = new System.Windows.Forms.Label();
			this.nudWeight = new System.Windows.Forms.NumericUpDown();
			this.gbWrestlers = new System.Windows.Forms.GroupBox();
			this.buttonOK = new System.Windows.Forms.Button();
			this.buttonCancel = new System.Windows.Forms.Button();
			this.buttonRefreshList = new System.Windows.Forms.Button();
			this.tableLayoutPanel1.SuspendLayout();
			this.tlpHeight.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.nudHeight)).BeginInit();
			this.tlpParams.SuspendLayout();
			this.tlpMoveset.SuspendLayout();
			this.tlpProfile.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.nudProfileIndex)).BeginInit();
			this.tlpAppearance.SuspendLayout();
			this.tlpWeight.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.nudWeight)).BeginInit();
			this.gbWrestlers.SuspendLayout();
			this.SuspendLayout();
			// 
			// lbWrestlers
			// 
			this.lbWrestlers.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
			this.lbWrestlers.FormattingEnabled = true;
			this.lbWrestlers.Location = new System.Drawing.Point(6, 19);
			this.lbWrestlers.Name = "lbWrestlers";
			this.lbWrestlers.ScrollAlwaysVisible = true;
			this.lbWrestlers.Size = new System.Drawing.Size(134, 342);
			this.lbWrestlers.TabIndex = 0;
			this.lbWrestlers.SelectedIndexChanged += new System.EventHandler(this.lbWrestlers_SelectedIndexChanged);
			// 
			// tableLayoutPanel1
			// 
			this.tableLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.tableLayoutPanel1.ColumnCount = 2;
			this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 31.40244F));
			this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 68.59756F));
			this.tableLayoutPanel1.Controls.Add(this.tlpHeight, 1, 4);
			this.tableLayoutPanel1.Controls.Add(this.cbEntranceVideo, 1, 3);
			this.tableLayoutPanel1.Controls.Add(this.cbThemeMusic, 1, 2);
			this.tableLayoutPanel1.Controls.Add(this.tbUnknown, 1, 5);
			this.tableLayoutPanel1.Controls.Add(this.tbWrestlerID4, 1, 0);
			this.tableLayoutPanel1.Controls.Add(this.tbWrestlerID2, 1, 1);
			this.tableLayoutPanel1.Controls.Add(this.labelWrestlerID4, 0, 0);
			this.tableLayoutPanel1.Controls.Add(this.labelWrestlerID2, 0, 1);
			this.tableLayoutPanel1.Controls.Add(this.labelEntranceVideo, 0, 3);
			this.tableLayoutPanel1.Controls.Add(this.labelHeight, 0, 4);
			this.tableLayoutPanel1.Controls.Add(this.labelUnknown, 0, 5);
			this.tableLayoutPanel1.Controls.Add(this.labelWeight, 0, 6);
			this.tableLayoutPanel1.Controls.Add(this.labelMovesetIndex, 0, 7);
			this.tableLayoutPanel1.Controls.Add(this.labelParamsIndex, 0, 8);
			this.tableLayoutPanel1.Controls.Add(this.tlpParams, 1, 8);
			this.tableLayoutPanel1.Controls.Add(this.tlpMoveset, 1, 7);
			this.tableLayoutPanel1.Controls.Add(this.labelAppearanceIndex, 0, 9);
			this.tableLayoutPanel1.Controls.Add(this.labelProfileIndex, 0, 10);
			this.tableLayoutPanel1.Controls.Add(this.tlpProfile, 1, 10);
			this.tableLayoutPanel1.Controls.Add(this.tlpAppearance, 1, 9);
			this.tableLayoutPanel1.Controls.Add(this.labelThemeMusic, 0, 2);
			this.tableLayoutPanel1.Controls.Add(this.tlpWeight, 1, 6);
			this.tableLayoutPanel1.Location = new System.Drawing.Point(164, 12);
			this.tableLayoutPanel1.Name = "tableLayoutPanel1";
			this.tableLayoutPanel1.RowCount = 11;
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 9.09091F));
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 9.09091F));
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 9.09091F));
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 9.09091F));
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 9.09091F));
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 9.09091F));
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 9.09091F));
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 9.09091F));
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 9.09091F));
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 9.09091F));
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 9.09091F));
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
			this.tableLayoutPanel1.Size = new System.Drawing.Size(328, 375);
			this.tableLayoutPanel1.TabIndex = 1;
			// 
			// tlpHeight
			// 
			this.tlpHeight.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
			this.tlpHeight.ColumnCount = 2;
			this.tlpHeight.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 40F));
			this.tlpHeight.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 60F));
			this.tlpHeight.Controls.Add(this.nudHeight, 0, 0);
			this.tlpHeight.Controls.Add(this.labelHeightValue, 1, 0);
			this.tlpHeight.Location = new System.Drawing.Point(106, 139);
			this.tlpHeight.Name = "tlpHeight";
			this.tlpHeight.RowCount = 1;
			this.tlpHeight.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.tlpHeight.Size = new System.Drawing.Size(219, 28);
			this.tlpHeight.TabIndex = 4;
			// 
			// nudHeight
			// 
			this.nudHeight.Hexadecimal = true;
			this.nudHeight.Location = new System.Drawing.Point(3, 3);
			this.nudHeight.Maximum = new decimal(new int[] {
            39,
            0,
            0,
            0});
			this.nudHeight.Name = "nudHeight";
			this.nudHeight.Size = new System.Drawing.Size(81, 20);
			this.nudHeight.TabIndex = 4;
			this.nudHeight.ValueChanged += new System.EventHandler(this.nudHeight_ValueChanged);
			this.nudHeight.Validating += new System.ComponentModel.CancelEventHandler(this.nudHeight_Validating);
			// 
			// labelHeightValue
			// 
			this.labelHeightValue.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
			this.labelHeightValue.AutoSize = true;
			this.labelHeightValue.Location = new System.Drawing.Point(90, 7);
			this.labelHeightValue.Name = "labelHeightValue";
			this.labelHeightValue.Size = new System.Drawing.Size(126, 13);
			this.labelHeightValue.TabIndex = 11;
			this.labelHeightValue.Text = "(height)";
			// 
			// cbEntranceVideo
			// 
			this.cbEntranceVideo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
			this.cbEntranceVideo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cbEntranceVideo.FormattingEnabled = true;
			this.cbEntranceVideo.Items.AddRange(new object[] {
            "00 (None?)",
            "01 APA",
            "02 Al Snow",
            "03 Angle",
            "04 Austin",
            "05 (formerly big show?)",
            "06 Blackman",
            "07 Bossman",
            "08 Bulldog",
            "09 Cactus",
            "0A Chyna",
            "0B Corporate",
            "0C D\'Lo",
            "0D Dudleyz",
            "0E DX",
            "0F Edge",
            "10 Rios",
            "11 Godfather",
            "12 Hardyz",
            "13 HBK",
            "14 HHH",
            "15 Hollys",
            "16 Jericho",
            "17 Kane",
            "18 Mankind",
            "19 Mark Henry",
            "1A Mr. Ass",
            "1B NAO",
            "1C Malenko",
            "1D The Rock",
            "1E Shamrock",
            "1F Taka",
            "20 Tazz",
            "21 Too Cool",
            "22 Venis",
            "23 Viscera",
            "24 X-Pac",
            "25 (Y2J Countdown)",
            "26 Undertaker",
            "27 Benoit",
            "28 T&A",
            "29 Eddy",
            "2A Saturn",
            "2B Right to Censor"});
			this.cbEntranceVideo.Location = new System.Drawing.Point(106, 108);
			this.cbEntranceVideo.Name = "cbEntranceVideo";
			this.cbEntranceVideo.Size = new System.Drawing.Size(219, 21);
			this.cbEntranceVideo.TabIndex = 8;
			this.cbEntranceVideo.SelectionChangeCommitted += new System.EventHandler(this.cbEntranceVideo_SelectionChangeCommitted);
			// 
			// cbThemeMusic
			// 
			this.cbThemeMusic.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
			this.cbThemeMusic.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cbThemeMusic.FormattingEnabled = true;
			this.cbThemeMusic.Items.AddRange(new object[] {
            "00 (None?)",
            "01 Kane",
            "02 ???",
            "03 N.A.O.",
            "04 Shamrock",
            "05 Venis",
            "06 X-Pac",
            "07 ???",
            "08 Al Snow",
            "09 Boss Man",
            "0A Steve Blackman",
            "0B ???",
            "0C Corporate",
            "0D D\'Lo",
            "0E DX",
            "0F Edge",
            "10 Godfather",
            "11 Mark Henry",
            "12 Right to Censor",
            "13 Raw",
            "14 Mr. Ass",
            "15 Hardy Boyz",
            "16 Hardcore Holly",
            "17 ???",
            "18 Dudleys",
            "19 British Bulldog",
            "1A Viscera",
            "1B Essa Rios",
            "1C Chyna",
            "1D ???",
            "1E Malenko",
            "1F ???",
            "20 TAKA",
            "21 Tazz",
            "22 Real American",
            "23 HHH",
            "24 Austin",
            "25 The Rock",
            "26 APA",
            "27 Mankind/Mick",
            "28 Too Cool",
            "29 Cactus",
            "2A HBK",
            "2B (Y2J Countdown)",
            "2C Jericho",
            "2D Angle",
            "2E ???",
            "2F Benoit",
            "30 T&A",
            "31 Guerrero",
            "32 Saturn",
            "33 Original 1",
            "34 Original 2",
            "35 Original 3",
            "36 Original 4",
            "37 Original 5",
            "38 Original 6",
            "39 Original 7"});
			this.cbThemeMusic.Location = new System.Drawing.Point(106, 74);
			this.cbThemeMusic.Name = "cbThemeMusic";
			this.cbThemeMusic.Size = new System.Drawing.Size(219, 21);
			this.cbThemeMusic.TabIndex = 6;
			this.cbThemeMusic.SelectionChangeCommitted += new System.EventHandler(this.cbThemeMusic_SelectionChangeCommitted);
			// 
			// tbUnknown
			// 
			this.tbUnknown.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
			this.tbUnknown.Location = new System.Drawing.Point(106, 177);
			this.tbUnknown.Name = "tbUnknown";
			this.tbUnknown.ReadOnly = true;
			this.tbUnknown.Size = new System.Drawing.Size(219, 20);
			this.tbUnknown.TabIndex = 12;
			// 
			// tbWrestlerID4
			// 
			this.tbWrestlerID4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
			this.tbWrestlerID4.Location = new System.Drawing.Point(106, 7);
			this.tbWrestlerID4.Name = "tbWrestlerID4";
			this.tbWrestlerID4.ReadOnly = true;
			this.tbWrestlerID4.Size = new System.Drawing.Size(219, 20);
			this.tbWrestlerID4.TabIndex = 2;
			// 
			// tbWrestlerID2
			// 
			this.tbWrestlerID2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
			this.tbWrestlerID2.Location = new System.Drawing.Point(106, 41);
			this.tbWrestlerID2.Name = "tbWrestlerID2";
			this.tbWrestlerID2.ReadOnly = true;
			this.tbWrestlerID2.Size = new System.Drawing.Size(219, 20);
			this.tbWrestlerID2.TabIndex = 4;
			// 
			// labelWrestlerID4
			// 
			this.labelWrestlerID4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
			this.labelWrestlerID4.AutoSize = true;
			this.labelWrestlerID4.Location = new System.Drawing.Point(3, 10);
			this.labelWrestlerID4.Name = "labelWrestlerID4";
			this.labelWrestlerID4.Size = new System.Drawing.Size(97, 13);
			this.labelWrestlerID4.TabIndex = 1;
			this.labelWrestlerID4.Text = "Wrestler ID&4";
			// 
			// labelWrestlerID2
			// 
			this.labelWrestlerID2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
			this.labelWrestlerID2.AutoSize = true;
			this.labelWrestlerID2.Location = new System.Drawing.Point(3, 44);
			this.labelWrestlerID2.Name = "labelWrestlerID2";
			this.labelWrestlerID2.Size = new System.Drawing.Size(97, 13);
			this.labelWrestlerID2.TabIndex = 3;
			this.labelWrestlerID2.Text = "Wrestler ID&2";
			// 
			// labelEntranceVideo
			// 
			this.labelEntranceVideo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
			this.labelEntranceVideo.AutoSize = true;
			this.labelEntranceVideo.Location = new System.Drawing.Point(3, 112);
			this.labelEntranceVideo.Name = "labelEntranceVideo";
			this.labelEntranceVideo.Size = new System.Drawing.Size(97, 13);
			this.labelEntranceVideo.TabIndex = 7;
			this.labelEntranceVideo.Text = "Entrance &Video";
			// 
			// labelHeight
			// 
			this.labelHeight.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
			this.labelHeight.AutoSize = true;
			this.labelHeight.Location = new System.Drawing.Point(3, 146);
			this.labelHeight.Name = "labelHeight";
			this.labelHeight.Size = new System.Drawing.Size(97, 13);
			this.labelHeight.TabIndex = 9;
			this.labelHeight.Text = "&Height";
			// 
			// labelUnknown
			// 
			this.labelUnknown.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
			this.labelUnknown.AutoSize = true;
			this.labelUnknown.Location = new System.Drawing.Point(3, 180);
			this.labelUnknown.Name = "labelUnknown";
			this.labelUnknown.Size = new System.Drawing.Size(97, 13);
			this.labelUnknown.TabIndex = 11;
			this.labelUnknown.Text = "&Unknown";
			// 
			// labelWeight
			// 
			this.labelWeight.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
			this.labelWeight.AutoSize = true;
			this.labelWeight.Location = new System.Drawing.Point(3, 214);
			this.labelWeight.Name = "labelWeight";
			this.labelWeight.Size = new System.Drawing.Size(97, 13);
			this.labelWeight.TabIndex = 13;
			this.labelWeight.Text = "W&eight";
			// 
			// labelMovesetIndex
			// 
			this.labelMovesetIndex.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
			this.labelMovesetIndex.AutoSize = true;
			this.labelMovesetIndex.Location = new System.Drawing.Point(3, 248);
			this.labelMovesetIndex.Name = "labelMovesetIndex";
			this.labelMovesetIndex.Size = new System.Drawing.Size(97, 13);
			this.labelMovesetIndex.TabIndex = 15;
			this.labelMovesetIndex.Text = "Move&set Index";
			// 
			// labelParamsIndex
			// 
			this.labelParamsIndex.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
			this.labelParamsIndex.AutoSize = true;
			this.labelParamsIndex.Location = new System.Drawing.Point(3, 282);
			this.labelParamsIndex.Name = "labelParamsIndex";
			this.labelParamsIndex.Size = new System.Drawing.Size(97, 13);
			this.labelParamsIndex.TabIndex = 18;
			this.labelParamsIndex.Text = "&Params Index";
			// 
			// tlpParams
			// 
			this.tlpParams.ColumnCount = 2;
			this.tlpParams.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 68F));
			this.tlpParams.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 32F));
			this.tlpParams.Controls.Add(this.buttonParams, 0, 0);
			this.tlpParams.Controls.Add(this.tbParamsIndex, 0, 0);
			this.tlpParams.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tlpParams.Location = new System.Drawing.Point(106, 275);
			this.tlpParams.Name = "tlpParams";
			this.tlpParams.RowCount = 1;
			this.tlpParams.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.tlpParams.Size = new System.Drawing.Size(219, 28);
			this.tlpParams.TabIndex = 21;
			// 
			// buttonParams
			// 
			this.buttonParams.Dock = System.Windows.Forms.DockStyle.Fill;
			this.buttonParams.Location = new System.Drawing.Point(151, 3);
			this.buttonParams.Name = "buttonParams";
			this.buttonParams.Size = new System.Drawing.Size(65, 22);
			this.buttonParams.TabIndex = 20;
			this.buttonParams.Text = "View/Edit";
			this.buttonParams.UseVisualStyleBackColor = true;
			this.buttonParams.Click += new System.EventHandler(this.buttonParams_Click);
			// 
			// tbParamsIndex
			// 
			this.tbParamsIndex.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
			this.tbParamsIndex.Location = new System.Drawing.Point(3, 4);
			this.tbParamsIndex.Name = "tbParamsIndex";
			this.tbParamsIndex.ReadOnly = true;
			this.tbParamsIndex.Size = new System.Drawing.Size(142, 20);
			this.tbParamsIndex.TabIndex = 19;
			// 
			// tlpMoveset
			// 
			this.tlpMoveset.ColumnCount = 2;
			this.tlpMoveset.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 68F));
			this.tlpMoveset.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 32F));
			this.tlpMoveset.Controls.Add(this.tbMovesetIndex, 0, 0);
			this.tlpMoveset.Controls.Add(this.buttonMoveset, 1, 0);
			this.tlpMoveset.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tlpMoveset.Location = new System.Drawing.Point(106, 241);
			this.tlpMoveset.Name = "tlpMoveset";
			this.tlpMoveset.RowCount = 1;
			this.tlpMoveset.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.tlpMoveset.Size = new System.Drawing.Size(219, 28);
			this.tlpMoveset.TabIndex = 20;
			// 
			// tbMovesetIndex
			// 
			this.tbMovesetIndex.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
			this.tbMovesetIndex.Location = new System.Drawing.Point(3, 4);
			this.tbMovesetIndex.Name = "tbMovesetIndex";
			this.tbMovesetIndex.ReadOnly = true;
			this.tbMovesetIndex.Size = new System.Drawing.Size(142, 20);
			this.tbMovesetIndex.TabIndex = 16;
			// 
			// buttonMoveset
			// 
			this.buttonMoveset.Dock = System.Windows.Forms.DockStyle.Fill;
			this.buttonMoveset.Location = new System.Drawing.Point(151, 3);
			this.buttonMoveset.Name = "buttonMoveset";
			this.buttonMoveset.Size = new System.Drawing.Size(65, 22);
			this.buttonMoveset.TabIndex = 17;
			this.buttonMoveset.Text = "View/Edit";
			this.buttonMoveset.UseVisualStyleBackColor = true;
			this.buttonMoveset.Click += new System.EventHandler(this.buttonMoveset_Click);
			// 
			// labelAppearanceIndex
			// 
			this.labelAppearanceIndex.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
			this.labelAppearanceIndex.AutoSize = true;
			this.labelAppearanceIndex.Location = new System.Drawing.Point(3, 316);
			this.labelAppearanceIndex.Name = "labelAppearanceIndex";
			this.labelAppearanceIndex.Size = new System.Drawing.Size(97, 13);
			this.labelAppearanceIndex.TabIndex = 21;
			this.labelAppearanceIndex.Text = "Appea&rance Index";
			// 
			// labelProfileIndex
			// 
			this.labelProfileIndex.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
			this.labelProfileIndex.AutoSize = true;
			this.labelProfileIndex.Location = new System.Drawing.Point(3, 351);
			this.labelProfileIndex.Name = "labelProfileIndex";
			this.labelProfileIndex.Size = new System.Drawing.Size(97, 13);
			this.labelProfileIndex.TabIndex = 23;
			this.labelProfileIndex.Text = "Pro&file Index";
			// 
			// tlpProfile
			// 
			this.tlpProfile.ColumnCount = 2;
			this.tlpProfile.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 68F));
			this.tlpProfile.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 32F));
			this.tlpProfile.Controls.Add(this.nudProfileIndex, 0, 0);
			this.tlpProfile.Controls.Add(this.buttonProfile, 1, 0);
			this.tlpProfile.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tlpProfile.Location = new System.Drawing.Point(106, 343);
			this.tlpProfile.Name = "tlpProfile";
			this.tlpProfile.RowCount = 1;
			this.tlpProfile.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.tlpProfile.Size = new System.Drawing.Size(219, 29);
			this.tlpProfile.TabIndex = 28;
			// 
			// nudProfileIndex
			// 
			this.nudProfileIndex.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
			this.nudProfileIndex.Hexadecimal = true;
			this.nudProfileIndex.Increment = new decimal(new int[] {
            3,
            0,
            0,
            0});
			this.nudProfileIndex.Location = new System.Drawing.Point(3, 4);
			this.nudProfileIndex.Maximum = new decimal(new int[] {
            291,
            0,
            0,
            0});
			this.nudProfileIndex.Name = "nudProfileIndex";
			this.nudProfileIndex.Size = new System.Drawing.Size(142, 20);
			this.nudProfileIndex.TabIndex = 4;
			this.nudProfileIndex.ValueChanged += new System.EventHandler(this.nudProfileIndex_ValueChanged);
			this.nudProfileIndex.Validating += new System.ComponentModel.CancelEventHandler(this.nudProfileIndex_Validating);
			// 
			// buttonProfile
			// 
			this.buttonProfile.Dock = System.Windows.Forms.DockStyle.Fill;
			this.buttonProfile.Location = new System.Drawing.Point(151, 3);
			this.buttonProfile.Name = "buttonProfile";
			this.buttonProfile.Size = new System.Drawing.Size(65, 23);
			this.buttonProfile.TabIndex = 25;
			this.buttonProfile.Text = "View/Edit";
			this.buttonProfile.UseVisualStyleBackColor = true;
			this.buttonProfile.Click += new System.EventHandler(this.buttonProfile_Click);
			// 
			// tlpAppearance
			// 
			this.tlpAppearance.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
			this.tlpAppearance.ColumnCount = 2;
			this.tlpAppearance.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 68F));
			this.tlpAppearance.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 32F));
			this.tlpAppearance.Controls.Add(this.buttonAppearance, 0, 0);
			this.tlpAppearance.Controls.Add(this.tbAppearanceIndex, 0, 0);
			this.tlpAppearance.Location = new System.Drawing.Point(106, 309);
			this.tlpAppearance.Name = "tlpAppearance";
			this.tlpAppearance.RowCount = 1;
			this.tlpAppearance.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.tlpAppearance.Size = new System.Drawing.Size(219, 27);
			this.tlpAppearance.TabIndex = 29;
			// 
			// buttonAppearance
			// 
			this.buttonAppearance.Dock = System.Windows.Forms.DockStyle.Fill;
			this.buttonAppearance.Location = new System.Drawing.Point(151, 3);
			this.buttonAppearance.Name = "buttonAppearance";
			this.buttonAppearance.Size = new System.Drawing.Size(65, 21);
			this.buttonAppearance.TabIndex = 24;
			this.buttonAppearance.Text = "View/Edit";
			this.buttonAppearance.UseVisualStyleBackColor = true;
			this.buttonAppearance.Click += new System.EventHandler(this.buttonAppearance_Click);
			// 
			// tbAppearanceIndex
			// 
			this.tbAppearanceIndex.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
			this.tbAppearanceIndex.Location = new System.Drawing.Point(3, 3);
			this.tbAppearanceIndex.Name = "tbAppearanceIndex";
			this.tbAppearanceIndex.ReadOnly = true;
			this.tbAppearanceIndex.Size = new System.Drawing.Size(142, 20);
			this.tbAppearanceIndex.TabIndex = 23;
			// 
			// labelThemeMusic
			// 
			this.labelThemeMusic.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
			this.labelThemeMusic.AutoSize = true;
			this.labelThemeMusic.Location = new System.Drawing.Point(3, 78);
			this.labelThemeMusic.Name = "labelThemeMusic";
			this.labelThemeMusic.Size = new System.Drawing.Size(97, 13);
			this.labelThemeMusic.TabIndex = 5;
			this.labelThemeMusic.Text = "Theme &Music";
			// 
			// tlpWeight
			// 
			this.tlpWeight.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
			this.tlpWeight.ColumnCount = 2;
			this.tlpWeight.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 40F));
			this.tlpWeight.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 60F));
			this.tlpWeight.Controls.Add(this.labelWeightValue, 1, 0);
			this.tlpWeight.Controls.Add(this.nudWeight, 0, 0);
			this.tlpWeight.Location = new System.Drawing.Point(106, 207);
			this.tlpWeight.Name = "tlpWeight";
			this.tlpWeight.RowCount = 1;
			this.tlpWeight.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.tlpWeight.Size = new System.Drawing.Size(219, 28);
			this.tlpWeight.TabIndex = 30;
			// 
			// labelWeightValue
			// 
			this.labelWeightValue.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
			this.labelWeightValue.AutoSize = true;
			this.labelWeightValue.Location = new System.Drawing.Point(90, 7);
			this.labelWeightValue.Name = "labelWeightValue";
			this.labelWeightValue.Size = new System.Drawing.Size(126, 13);
			this.labelWeightValue.TabIndex = 15;
			this.labelWeightValue.Text = "(weight)";
			// 
			// nudWeight
			// 
			this.nudWeight.Hexadecimal = true;
			this.nudWeight.Location = new System.Drawing.Point(3, 3);
			this.nudWeight.Maximum = new decimal(new int[] {
            503,
            0,
            0,
            0});
			this.nudWeight.Name = "nudWeight";
			this.nudWeight.Size = new System.Drawing.Size(81, 20);
			this.nudWeight.TabIndex = 4;
			this.nudWeight.ValueChanged += new System.EventHandler(this.nudWeight_ValueChanged);
			this.nudWeight.Validating += new System.ComponentModel.CancelEventHandler(this.nudWeight_Validating);
			// 
			// gbWrestlers
			// 
			this.gbWrestlers.Controls.Add(this.lbWrestlers);
			this.gbWrestlers.Location = new System.Drawing.Point(12, 12);
			this.gbWrestlers.Name = "gbWrestlers";
			this.gbWrestlers.Size = new System.Drawing.Size(146, 372);
			this.gbWrestlers.TabIndex = 0;
			this.gbWrestlers.TabStop = false;
			this.gbWrestlers.Text = "&Wrestlers";
			// 
			// buttonOK
			// 
			this.buttonOK.Location = new System.Drawing.Point(336, 393);
			this.buttonOK.Name = "buttonOK";
			this.buttonOK.Size = new System.Drawing.Size(75, 23);
			this.buttonOK.TabIndex = 2;
			this.buttonOK.Text = "&OK";
			this.buttonOK.UseVisualStyleBackColor = true;
			this.buttonOK.Click += new System.EventHandler(this.buttonOK_Click);
			// 
			// buttonCancel
			// 
			this.buttonCancel.Location = new System.Drawing.Point(417, 393);
			this.buttonCancel.Name = "buttonCancel";
			this.buttonCancel.Size = new System.Drawing.Size(75, 23);
			this.buttonCancel.TabIndex = 3;
			this.buttonCancel.Text = "&Cancel";
			this.buttonCancel.UseVisualStyleBackColor = true;
			this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
			// 
			// buttonRefreshList
			// 
			this.buttonRefreshList.Location = new System.Drawing.Point(12, 393);
			this.buttonRefreshList.Name = "buttonRefreshList";
			this.buttonRefreshList.Size = new System.Drawing.Size(146, 23);
			this.buttonRefreshList.TabIndex = 4;
			this.buttonRefreshList.Text = "Refresh &List";
			this.buttonRefreshList.UseVisualStyleBackColor = true;
			this.buttonRefreshList.Click += new System.EventHandler(this.buttonRefreshList_Click);
			// 
			// WrestlerMain_NoMercy
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(504, 428);
			this.Controls.Add(this.buttonRefreshList);
			this.Controls.Add(this.buttonCancel);
			this.Controls.Add(this.buttonOK);
			this.Controls.Add(this.gbWrestlers);
			this.Controls.Add(this.tableLayoutPanel1);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "WrestlerMain_NoMercy";
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "Wrestler Editor (WWF No Mercy)";
			this.tableLayoutPanel1.ResumeLayout(false);
			this.tableLayoutPanel1.PerformLayout();
			this.tlpHeight.ResumeLayout(false);
			this.tlpHeight.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.nudHeight)).EndInit();
			this.tlpParams.ResumeLayout(false);
			this.tlpParams.PerformLayout();
			this.tlpMoveset.ResumeLayout(false);
			this.tlpMoveset.PerformLayout();
			this.tlpProfile.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.nudProfileIndex)).EndInit();
			this.tlpAppearance.ResumeLayout(false);
			this.tlpAppearance.PerformLayout();
			this.tlpWeight.ResumeLayout(false);
			this.tlpWeight.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.nudWeight)).EndInit();
			this.gbWrestlers.ResumeLayout(false);
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.ListBox lbWrestlers;
		private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
		private System.Windows.Forms.TextBox tbWrestlerID4;
		private System.Windows.Forms.TextBox tbWrestlerID2;
		private System.Windows.Forms.Label labelWrestlerID4;
		private System.Windows.Forms.Label labelWrestlerID2;
		private System.Windows.Forms.Label labelThemeMusic;
		private System.Windows.Forms.Label labelEntranceVideo;
		private System.Windows.Forms.Label labelMovesetIndex;
		private System.Windows.Forms.Label labelParamsIndex;
		private System.Windows.Forms.Label labelAppearanceIndex;
		private System.Windows.Forms.Label labelProfileIndex;
		private System.Windows.Forms.ComboBox cbEntranceVideo;
		private System.Windows.Forms.TableLayoutPanel tlpMoveset;
		private System.Windows.Forms.TextBox tbMovesetIndex;
		private System.Windows.Forms.Button buttonMoveset;
		private System.Windows.Forms.TableLayoutPanel tlpParams;
		private System.Windows.Forms.Button buttonParams;
		private System.Windows.Forms.TextBox tbParamsIndex;
		private System.Windows.Forms.Label labelHeight;
		private System.Windows.Forms.Label labelUnknown;
		private System.Windows.Forms.Label labelWeight;
		private System.Windows.Forms.TextBox tbUnknown;
		private System.Windows.Forms.TableLayoutPanel tlpProfile;
		private System.Windows.Forms.Button buttonProfile;
		private System.Windows.Forms.GroupBox gbWrestlers;
		private System.Windows.Forms.TableLayoutPanel tlpAppearance;
		private System.Windows.Forms.Button buttonAppearance;
		private System.Windows.Forms.TextBox tbAppearanceIndex;
		private System.Windows.Forms.Button buttonOK;
		private System.Windows.Forms.Button buttonCancel;
		private System.Windows.Forms.ComboBox cbThemeMusic;
		private System.Windows.Forms.NumericUpDown nudProfileIndex;
		private System.Windows.Forms.TableLayoutPanel tlpHeight;
		private System.Windows.Forms.Label labelHeightValue;
		private System.Windows.Forms.TableLayoutPanel tlpWeight;
		private System.Windows.Forms.Label labelWeightValue;
		private System.Windows.Forms.NumericUpDown nudHeight;
		private System.Windows.Forms.NumericUpDown nudWeight;
		private System.Windows.Forms.Button buttonRefreshList;
	}
}