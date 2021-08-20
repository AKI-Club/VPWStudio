namespace VPWStudio
{
	partial class ModelTool2
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
			this.gbModelInfo = new System.Windows.Forms.GroupBox();
			this.tlpModelInfo = new System.Windows.Forms.TableLayoutPanel();
			this.tbNumFacesTopBit = new System.Windows.Forms.TextBox();
			this.tbNumVertsTopBit = new System.Windows.Forms.TextBox();
			this.tbNumVerts = new System.Windows.Forms.TextBox();
			this.labelNumVerts = new System.Windows.Forms.Label();
			this.tbModelScale = new System.Windows.Forms.TextBox();
			this.labelModelScale = new System.Windows.Forms.Label();
			this.labelFileID = new System.Windows.Forms.Label();
			this.tbFileID = new System.Windows.Forms.TextBox();
			this.tbNumFaces = new System.Windows.Forms.TextBox();
			this.labelNumVertsTopBit = new System.Windows.Forms.Label();
			this.tbTextureSize = new System.Windows.Forms.TextBox();
			this.labelTextureSize = new System.Windows.Forms.Label();
			this.tbOffsetZ = new System.Windows.Forms.TextBox();
			this.labelOffsetZ = new System.Windows.Forms.Label();
			this.labelOffsetY = new System.Windows.Forms.Label();
			this.tbOffsetY = new System.Windows.Forms.TextBox();
			this.tbOffsetX = new System.Windows.Forms.TextBox();
			this.labelOffsetX = new System.Windows.Forms.Label();
			this.labelUnknown = new System.Windows.Forms.Label();
			this.tbUnknown = new System.Windows.Forms.TextBox();
			this.labelNumFaces = new System.Windows.Forms.Label();
			this.labelNumFacesTopBit = new System.Windows.Forms.Label();
			this.glControl1 = new OpenTK.GLControl();
			this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
			this.menuStrip1 = new System.Windows.Forms.MenuStrip();
			this.exportWavefrontOBJToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.textureToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.loadTextureToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.textureEnabledToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
			this.horizontalMirrorToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.verticalMirrorToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.gbModelInfo.SuspendLayout();
			this.tlpModelInfo.SuspendLayout();
			this.tableLayoutPanel1.SuspendLayout();
			this.menuStrip1.SuspendLayout();
			this.SuspendLayout();
			// 
			// gbModelInfo
			// 
			this.gbModelInfo.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.gbModelInfo.Controls.Add(this.tlpModelInfo);
			this.gbModelInfo.Location = new System.Drawing.Point(3, 3);
			this.gbModelInfo.Name = "gbModelInfo";
			this.gbModelInfo.Size = new System.Drawing.Size(311, 309);
			this.gbModelInfo.TabIndex = 1;
			this.gbModelInfo.TabStop = false;
			this.gbModelInfo.Text = "Model Information";
			// 
			// tlpModelInfo
			// 
			this.tlpModelInfo.ColumnCount = 2;
			this.tlpModelInfo.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 35.08197F));
			this.tlpModelInfo.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 64.91803F));
			this.tlpModelInfo.Controls.Add(this.tbNumFacesTopBit, 1, 5);
			this.tlpModelInfo.Controls.Add(this.tbNumVertsTopBit, 1, 3);
			this.tlpModelInfo.Controls.Add(this.tbNumVerts, 1, 2);
			this.tlpModelInfo.Controls.Add(this.labelNumVerts, 0, 2);
			this.tlpModelInfo.Controls.Add(this.tbModelScale, 1, 1);
			this.tlpModelInfo.Controls.Add(this.labelModelScale, 0, 1);
			this.tlpModelInfo.Controls.Add(this.labelFileID, 0, 0);
			this.tlpModelInfo.Controls.Add(this.tbFileID, 1, 0);
			this.tlpModelInfo.Controls.Add(this.tbNumFaces, 1, 4);
			this.tlpModelInfo.Controls.Add(this.labelNumVertsTopBit, 0, 3);
			this.tlpModelInfo.Controls.Add(this.tbTextureSize, 1, 10);
			this.tlpModelInfo.Controls.Add(this.labelTextureSize, 0, 10);
			this.tlpModelInfo.Controls.Add(this.tbOffsetZ, 1, 9);
			this.tlpModelInfo.Controls.Add(this.labelOffsetZ, 0, 9);
			this.tlpModelInfo.Controls.Add(this.labelOffsetY, 0, 8);
			this.tlpModelInfo.Controls.Add(this.tbOffsetY, 1, 8);
			this.tlpModelInfo.Controls.Add(this.tbOffsetX, 1, 7);
			this.tlpModelInfo.Controls.Add(this.labelOffsetX, 0, 7);
			this.tlpModelInfo.Controls.Add(this.labelUnknown, 0, 6);
			this.tlpModelInfo.Controls.Add(this.tbUnknown, 1, 6);
			this.tlpModelInfo.Controls.Add(this.labelNumFaces, 0, 4);
			this.tlpModelInfo.Controls.Add(this.labelNumFacesTopBit, 0, 5);
			this.tlpModelInfo.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tlpModelInfo.Location = new System.Drawing.Point(3, 16);
			this.tlpModelInfo.Name = "tlpModelInfo";
			this.tlpModelInfo.RowCount = 11;
			this.tlpModelInfo.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 9.090909F));
			this.tlpModelInfo.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 9.090909F));
			this.tlpModelInfo.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 9.090909F));
			this.tlpModelInfo.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 9.090909F));
			this.tlpModelInfo.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 9.090909F));
			this.tlpModelInfo.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 9.090909F));
			this.tlpModelInfo.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 9.090909F));
			this.tlpModelInfo.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 9.090909F));
			this.tlpModelInfo.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 9.090909F));
			this.tlpModelInfo.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 9.090909F));
			this.tlpModelInfo.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 9.090909F));
			this.tlpModelInfo.Size = new System.Drawing.Size(305, 290);
			this.tlpModelInfo.TabIndex = 0;
			// 
			// tbNumFacesTopBit
			// 
			this.tbNumFacesTopBit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
			this.tbNumFacesTopBit.Location = new System.Drawing.Point(110, 133);
			this.tbNumFacesTopBit.Name = "tbNumFacesTopBit";
			this.tbNumFacesTopBit.ReadOnly = true;
			this.tbNumFacesTopBit.Size = new System.Drawing.Size(192, 20);
			this.tbNumFacesTopBit.TabIndex = 12;
			// 
			// tbNumVertsTopBit
			// 
			this.tbNumVertsTopBit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
			this.tbNumVertsTopBit.Location = new System.Drawing.Point(110, 81);
			this.tbNumVertsTopBit.Name = "tbNumVertsTopBit";
			this.tbNumVertsTopBit.ReadOnly = true;
			this.tbNumVertsTopBit.Size = new System.Drawing.Size(192, 20);
			this.tbNumVertsTopBit.TabIndex = 10;
			// 
			// tbNumVerts
			// 
			this.tbNumVerts.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
			this.tbNumVerts.Location = new System.Drawing.Point(110, 55);
			this.tbNumVerts.Name = "tbNumVerts";
			this.tbNumVerts.ReadOnly = true;
			this.tbNumVerts.Size = new System.Drawing.Size(192, 20);
			this.tbNumVerts.TabIndex = 2;
			// 
			// labelNumVerts
			// 
			this.labelNumVerts.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
			this.labelNumVerts.AutoSize = true;
			this.labelNumVerts.Location = new System.Drawing.Point(3, 58);
			this.labelNumVerts.Name = "labelNumVerts";
			this.labelNumVerts.Size = new System.Drawing.Size(101, 13);
			this.labelNumVerts.TabIndex = 2;
			this.labelNumVerts.Text = "Number of Vertices";
			// 
			// tbModelScale
			// 
			this.tbModelScale.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
			this.tbModelScale.Location = new System.Drawing.Point(110, 29);
			this.tbModelScale.Name = "tbModelScale";
			this.tbModelScale.ReadOnly = true;
			this.tbModelScale.Size = new System.Drawing.Size(192, 20);
			this.tbModelScale.TabIndex = 1;
			// 
			// labelModelScale
			// 
			this.labelModelScale.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
			this.labelModelScale.AutoSize = true;
			this.labelModelScale.Location = new System.Drawing.Point(3, 32);
			this.labelModelScale.Name = "labelModelScale";
			this.labelModelScale.Size = new System.Drawing.Size(101, 13);
			this.labelModelScale.TabIndex = 1;
			this.labelModelScale.Text = "Scale";
			// 
			// labelFileID
			// 
			this.labelFileID.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
			this.labelFileID.AutoSize = true;
			this.labelFileID.Location = new System.Drawing.Point(3, 6);
			this.labelFileID.Name = "labelFileID";
			this.labelFileID.Size = new System.Drawing.Size(101, 13);
			this.labelFileID.TabIndex = 0;
			this.labelFileID.Text = "File ID";
			// 
			// tbFileID
			// 
			this.tbFileID.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
			this.tbFileID.Location = new System.Drawing.Point(110, 3);
			this.tbFileID.Name = "tbFileID";
			this.tbFileID.ReadOnly = true;
			this.tbFileID.Size = new System.Drawing.Size(192, 20);
			this.tbFileID.TabIndex = 0;
			// 
			// tbNumFaces
			// 
			this.tbNumFaces.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
			this.tbNumFaces.Location = new System.Drawing.Point(110, 107);
			this.tbNumFaces.Name = "tbNumFaces";
			this.tbNumFaces.ReadOnly = true;
			this.tbNumFaces.Size = new System.Drawing.Size(192, 20);
			this.tbNumFaces.TabIndex = 3;
			// 
			// labelNumVertsTopBit
			// 
			this.labelNumVertsTopBit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
			this.labelNumVertsTopBit.AutoSize = true;
			this.labelNumVertsTopBit.Location = new System.Drawing.Point(3, 84);
			this.labelNumVertsTopBit.Name = "labelNumVertsTopBit";
			this.labelNumVertsTopBit.Size = new System.Drawing.Size(101, 13);
			this.labelNumVertsTopBit.TabIndex = 9;
			this.labelNumVertsTopBit.Text = "NumVerts Top Bit";
			// 
			// tbTextureSize
			// 
			this.tbTextureSize.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
			this.tbTextureSize.Location = new System.Drawing.Point(110, 265);
			this.tbTextureSize.Name = "tbTextureSize";
			this.tbTextureSize.ReadOnly = true;
			this.tbTextureSize.Size = new System.Drawing.Size(192, 20);
			this.tbTextureSize.TabIndex = 8;
			// 
			// labelTextureSize
			// 
			this.labelTextureSize.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
			this.labelTextureSize.AutoSize = true;
			this.labelTextureSize.Location = new System.Drawing.Point(3, 268);
			this.labelTextureSize.Name = "labelTextureSize";
			this.labelTextureSize.Size = new System.Drawing.Size(101, 13);
			this.labelTextureSize.TabIndex = 8;
			this.labelTextureSize.Text = "Texture Size";
			// 
			// tbOffsetZ
			// 
			this.tbOffsetZ.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
			this.tbOffsetZ.Location = new System.Drawing.Point(110, 237);
			this.tbOffsetZ.Name = "tbOffsetZ";
			this.tbOffsetZ.ReadOnly = true;
			this.tbOffsetZ.Size = new System.Drawing.Size(192, 20);
			this.tbOffsetZ.TabIndex = 7;
			// 
			// labelOffsetZ
			// 
			this.labelOffsetZ.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
			this.labelOffsetZ.AutoSize = true;
			this.labelOffsetZ.Location = new System.Drawing.Point(3, 240);
			this.labelOffsetZ.Name = "labelOffsetZ";
			this.labelOffsetZ.Size = new System.Drawing.Size(101, 13);
			this.labelOffsetZ.TabIndex = 7;
			this.labelOffsetZ.Text = "Offset Z";
			// 
			// labelOffsetY
			// 
			this.labelOffsetY.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
			this.labelOffsetY.AutoSize = true;
			this.labelOffsetY.Location = new System.Drawing.Point(3, 214);
			this.labelOffsetY.Name = "labelOffsetY";
			this.labelOffsetY.Size = new System.Drawing.Size(101, 13);
			this.labelOffsetY.TabIndex = 6;
			this.labelOffsetY.Text = "Offset Y";
			// 
			// tbOffsetY
			// 
			this.tbOffsetY.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
			this.tbOffsetY.Location = new System.Drawing.Point(110, 211);
			this.tbOffsetY.Name = "tbOffsetY";
			this.tbOffsetY.ReadOnly = true;
			this.tbOffsetY.Size = new System.Drawing.Size(192, 20);
			this.tbOffsetY.TabIndex = 6;
			// 
			// tbOffsetX
			// 
			this.tbOffsetX.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
			this.tbOffsetX.Location = new System.Drawing.Point(110, 185);
			this.tbOffsetX.Name = "tbOffsetX";
			this.tbOffsetX.ReadOnly = true;
			this.tbOffsetX.Size = new System.Drawing.Size(192, 20);
			this.tbOffsetX.TabIndex = 5;
			// 
			// labelOffsetX
			// 
			this.labelOffsetX.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
			this.labelOffsetX.AutoSize = true;
			this.labelOffsetX.Location = new System.Drawing.Point(3, 188);
			this.labelOffsetX.Name = "labelOffsetX";
			this.labelOffsetX.Size = new System.Drawing.Size(101, 13);
			this.labelOffsetX.TabIndex = 5;
			this.labelOffsetX.Text = "Offset X";
			// 
			// labelUnknown
			// 
			this.labelUnknown.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
			this.labelUnknown.AutoSize = true;
			this.labelUnknown.Location = new System.Drawing.Point(3, 162);
			this.labelUnknown.Name = "labelUnknown";
			this.labelUnknown.Size = new System.Drawing.Size(101, 13);
			this.labelUnknown.TabIndex = 4;
			this.labelUnknown.Text = "(unknown)";
			// 
			// tbUnknown
			// 
			this.tbUnknown.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
			this.tbUnknown.Location = new System.Drawing.Point(110, 159);
			this.tbUnknown.Name = "tbUnknown";
			this.tbUnknown.ReadOnly = true;
			this.tbUnknown.Size = new System.Drawing.Size(192, 20);
			this.tbUnknown.TabIndex = 4;
			// 
			// labelNumFaces
			// 
			this.labelNumFaces.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
			this.labelNumFaces.AutoSize = true;
			this.labelNumFaces.Location = new System.Drawing.Point(3, 110);
			this.labelNumFaces.Name = "labelNumFaces";
			this.labelNumFaces.Size = new System.Drawing.Size(101, 13);
			this.labelNumFaces.TabIndex = 3;
			this.labelNumFaces.Text = "Number of Faces";
			// 
			// labelNumFacesTopBit
			// 
			this.labelNumFacesTopBit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
			this.labelNumFacesTopBit.AutoSize = true;
			this.labelNumFacesTopBit.Location = new System.Drawing.Point(3, 136);
			this.labelNumFacesTopBit.Name = "labelNumFacesTopBit";
			this.labelNumFacesTopBit.Size = new System.Drawing.Size(101, 13);
			this.labelNumFacesTopBit.TabIndex = 11;
			this.labelNumFacesTopBit.Text = "NumFaces Top Bit";
			// 
			// glControl1
			// 
			this.glControl1.BackColor = System.Drawing.Color.Black;
			this.glControl1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.glControl1.Location = new System.Drawing.Point(320, 3);
			this.glControl1.Name = "glControl1";
			this.glControl1.Size = new System.Drawing.Size(311, 309);
			this.glControl1.TabIndex = 3;
			this.glControl1.VSync = false;
			this.glControl1.Load += new System.EventHandler(this.glControl1_Load);
			this.glControl1.Paint += new System.Windows.Forms.PaintEventHandler(this.glControl1_Paint);
			this.glControl1.Resize += new System.EventHandler(this.glControl1_Resize);
			// 
			// tableLayoutPanel1
			// 
			this.tableLayoutPanel1.ColumnCount = 2;
			this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
			this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
			this.tableLayoutPanel1.Controls.Add(this.gbModelInfo, 0, 0);
			this.tableLayoutPanel1.Controls.Add(this.glControl1, 1, 0);
			this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 24);
			this.tableLayoutPanel1.Name = "tableLayoutPanel1";
			this.tableLayoutPanel1.RowCount = 1;
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.tableLayoutPanel1.Size = new System.Drawing.Size(634, 315);
			this.tableLayoutPanel1.TabIndex = 4;
			// 
			// menuStrip1
			// 
			this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.exportWavefrontOBJToolStripMenuItem,
            this.textureToolStripMenuItem});
			this.menuStrip1.Location = new System.Drawing.Point(0, 0);
			this.menuStrip1.Name = "menuStrip1";
			this.menuStrip1.Size = new System.Drawing.Size(634, 24);
			this.menuStrip1.TabIndex = 5;
			this.menuStrip1.Text = "menuStrip1";
			// 
			// exportWavefrontOBJToolStripMenuItem
			// 
			this.exportWavefrontOBJToolStripMenuItem.Name = "exportWavefrontOBJToolStripMenuItem";
			this.exportWavefrontOBJToolStripMenuItem.Size = new System.Drawing.Size(143, 20);
			this.exportWavefrontOBJToolStripMenuItem.Text = "&Export Wavefront OBJ...";
			this.exportWavefrontOBJToolStripMenuItem.Click += new System.EventHandler(this.exportWavefrontOBJToolStripMenuItem_Click);
			// 
			// textureToolStripMenuItem
			// 
			this.textureToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.loadTextureToolStripMenuItem,
            this.textureEnabledToolStripMenuItem,
            this.toolStripSeparator1,
            this.horizontalMirrorToolStripMenuItem,
            this.verticalMirrorToolStripMenuItem});
			this.textureToolStripMenuItem.Name = "textureToolStripMenuItem";
			this.textureToolStripMenuItem.Size = new System.Drawing.Size(57, 20);
			this.textureToolStripMenuItem.Text = "&Texture";
			// 
			// loadTextureToolStripMenuItem
			// 
			this.loadTextureToolStripMenuItem.Name = "loadTextureToolStripMenuItem";
			this.loadTextureToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
			this.loadTextureToolStripMenuItem.Text = "&Load Texture...";
			this.loadTextureToolStripMenuItem.Click += new System.EventHandler(this.loadTextureToolStripMenuItem_Click);
			// 
			// textureEnabledToolStripMenuItem
			// 
			this.textureEnabledToolStripMenuItem.CheckOnClick = true;
			this.textureEnabledToolStripMenuItem.Name = "textureEnabledToolStripMenuItem";
			this.textureEnabledToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
			this.textureEnabledToolStripMenuItem.Text = "Texture Enabled";
			this.textureEnabledToolStripMenuItem.Click += new System.EventHandler(this.textureEnabledToolStripMenuItem_Click);
			// 
			// toolStripSeparator1
			// 
			this.toolStripSeparator1.Name = "toolStripSeparator1";
			this.toolStripSeparator1.Size = new System.Drawing.Size(177, 6);
			// 
			// horizontalMirrorToolStripMenuItem
			// 
			this.horizontalMirrorToolStripMenuItem.CheckOnClick = true;
			this.horizontalMirrorToolStripMenuItem.Name = "horizontalMirrorToolStripMenuItem";
			this.horizontalMirrorToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
			this.horizontalMirrorToolStripMenuItem.Text = "Horizontal Mirror";
			this.horizontalMirrorToolStripMenuItem.CheckedChanged += new System.EventHandler(this.horizontalMirrorToolStripMenuItem_CheckedChanged);
			// 
			// verticalMirrorToolStripMenuItem
			// 
			this.verticalMirrorToolStripMenuItem.CheckOnClick = true;
			this.verticalMirrorToolStripMenuItem.Name = "verticalMirrorToolStripMenuItem";
			this.verticalMirrorToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
			this.verticalMirrorToolStripMenuItem.Text = "Vertical Mirror";
			this.verticalMirrorToolStripMenuItem.CheckedChanged += new System.EventHandler(this.verticalMirrorToolStripMenuItem_CheckedChanged);
			// 
			// ModelTool2
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(634, 339);
			this.Controls.Add(this.tableLayoutPanel1);
			this.Controls.Add(this.menuStrip1);
			this.MainMenuStrip = this.menuStrip1;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.MinimumSize = new System.Drawing.Size(650, 378);
			this.Name = "ModelTool2";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "ModelTool2";
			this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ModelTool2_FormClosing);
			this.gbModelInfo.ResumeLayout(false);
			this.tlpModelInfo.ResumeLayout(false);
			this.tlpModelInfo.PerformLayout();
			this.tableLayoutPanel1.ResumeLayout(false);
			this.menuStrip1.ResumeLayout(false);
			this.menuStrip1.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion
		private System.Windows.Forms.GroupBox gbModelInfo;
		private System.Windows.Forms.TableLayoutPanel tlpModelInfo;
		private System.Windows.Forms.Label labelModelScale;
		private System.Windows.Forms.Label labelNumVerts;
		private System.Windows.Forms.Label labelNumFaces;
		private System.Windows.Forms.Label labelUnknown;
		private System.Windows.Forms.Label labelOffsetX;
		private System.Windows.Forms.Label labelOffsetY;
		private System.Windows.Forms.Label labelOffsetZ;
		private System.Windows.Forms.Label labelTextureSize;
		private System.Windows.Forms.TextBox tbModelScale;
		private System.Windows.Forms.TextBox tbNumVerts;
		private System.Windows.Forms.TextBox tbNumFaces;
		private System.Windows.Forms.TextBox tbUnknown;
		private System.Windows.Forms.TextBox tbOffsetX;
		private System.Windows.Forms.TextBox tbOffsetY;
		private System.Windows.Forms.TextBox tbOffsetZ;
		private System.Windows.Forms.TextBox tbTextureSize;
		private System.Windows.Forms.Label labelFileID;
		private System.Windows.Forms.TextBox tbFileID;
		private System.Windows.Forms.TextBox tbNumVertsTopBit;
		private System.Windows.Forms.Label labelNumVertsTopBit;
		private System.Windows.Forms.TextBox tbNumFacesTopBit;
		private System.Windows.Forms.Label labelNumFacesTopBit;
		private OpenTK.GLControl glControl1;
		private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
		private System.Windows.Forms.MenuStrip menuStrip1;
		private System.Windows.Forms.ToolStripMenuItem exportWavefrontOBJToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem textureToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem loadTextureToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem textureEnabledToolStripMenuItem;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
		private System.Windows.Forms.ToolStripMenuItem horizontalMirrorToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem verticalMirrorToolStripMenuItem;
	}
}