
namespace VPWStudio
{
	partial class TestScene3D
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
			this.gbItems = new System.Windows.Forms.GroupBox();
			this.lvSceneItems = new System.Windows.Forms.ListView();
			this.btnClear = new System.Windows.Forms.Button();
			this.btnRemove = new System.Windows.Forms.Button();
			this.btnAdd = new System.Windows.Forms.Button();
			this.gbPreview = new System.Windows.Forms.GroupBox();
			this.glControl1 = new OpenTK.GLControl();
			this.gbItemInfo = new System.Windows.Forms.GroupBox();
			this.tableLayoutPanel4 = new System.Windows.Forms.TableLayoutPanel();
			this.lblName = new System.Windows.Forms.Label();
			this.btnRename = new System.Windows.Forms.Button();
			this.tbObjectName = new System.Windows.Forms.TextBox();
			this.tcItemInfo = new System.Windows.Forms.TabControl();
			this.tpPosRot = new System.Windows.Forms.TabPage();
			this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
			this.btnUpdatePosRot = new System.Windows.Forms.Button();
			this.btnResetPosRot = new System.Windows.Forms.Button();
			this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
			this.lblPosX = new System.Windows.Forms.Label();
			this.lblPosY = new System.Windows.Forms.Label();
			this.lblPosZ = new System.Windows.Forms.Label();
			this.lblRotX = new System.Windows.Forms.Label();
			this.tbPosX = new System.Windows.Forms.TextBox();
			this.tbPosY = new System.Windows.Forms.TextBox();
			this.tbPosZ = new System.Windows.Forms.TextBox();
			this.tbRotX = new System.Windows.Forms.TextBox();
			this.lblRotY = new System.Windows.Forms.Label();
			this.lblRotZ = new System.Windows.Forms.Label();
			this.tbRotY = new System.Windows.Forms.TextBox();
			this.tbRotZ = new System.Windows.Forms.TextBox();
			this.tpFileID = new System.Windows.Forms.TabPage();
			this.cbEnableTexture = new System.Windows.Forms.CheckBox();
			this.btnEditModelFileID = new System.Windows.Forms.Button();
			this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
			this.tbTexFileID = new System.Windows.Forms.TextBox();
			this.tbPalFileID = new System.Windows.Forms.TextBox();
			this.tbModelFileID = new System.Windows.Forms.TextBox();
			this.lblModelID = new System.Windows.Forms.Label();
			this.lblPalID = new System.Windows.Forms.Label();
			this.lblTextureID = new System.Windows.Forms.Label();
			this.btnBackgroundColor = new System.Windows.Forms.Button();
			this.btnResetCamera = new System.Windows.Forms.Button();
			this.lblScaleX = new System.Windows.Forms.Label();
			this.lblScaleY = new System.Windows.Forms.Label();
			this.lblScaleZ = new System.Windows.Forms.Label();
			this.tbScaleX = new System.Windows.Forms.TextBox();
			this.tbScaleY = new System.Windows.Forms.TextBox();
			this.tbScaleZ = new System.Windows.Forms.TextBox();
			this.gbItems.SuspendLayout();
			this.gbPreview.SuspendLayout();
			this.gbItemInfo.SuspendLayout();
			this.tableLayoutPanel4.SuspendLayout();
			this.tcItemInfo.SuspendLayout();
			this.tpPosRot.SuspendLayout();
			this.tableLayoutPanel2.SuspendLayout();
			this.tableLayoutPanel1.SuspendLayout();
			this.tpFileID.SuspendLayout();
			this.tableLayoutPanel3.SuspendLayout();
			this.SuspendLayout();
			// 
			// gbItems
			// 
			this.gbItems.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
			this.gbItems.Controls.Add(this.lvSceneItems);
			this.gbItems.Controls.Add(this.btnClear);
			this.gbItems.Controls.Add(this.btnRemove);
			this.gbItems.Controls.Add(this.btnAdd);
			this.gbItems.Location = new System.Drawing.Point(12, 12);
			this.gbItems.Name = "gbItems";
			this.gbItems.Size = new System.Drawing.Size(245, 154);
			this.gbItems.TabIndex = 0;
			this.gbItems.TabStop = false;
			this.gbItems.Text = "&Items";
			// 
			// lvSceneItems
			// 
			this.lvSceneItems.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.lvSceneItems.CheckBoxes = true;
			this.lvSceneItems.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None;
			this.lvSceneItems.HideSelection = false;
			this.lvSceneItems.LabelWrap = false;
			this.lvSceneItems.Location = new System.Drawing.Point(6, 19);
			this.lvSceneItems.MultiSelect = false;
			this.lvSceneItems.Name = "lvSceneItems";
			this.lvSceneItems.ShowGroups = false;
			this.lvSceneItems.Size = new System.Drawing.Size(152, 129);
			this.lvSceneItems.TabIndex = 5;
			this.lvSceneItems.UseCompatibleStateImageBehavior = false;
			this.lvSceneItems.View = System.Windows.Forms.View.List;
			this.lvSceneItems.ItemChecked += new System.Windows.Forms.ItemCheckedEventHandler(this.lvSceneItems_ItemChecked);
			this.lvSceneItems.SelectedIndexChanged += new System.EventHandler(this.lvSceneItems_SelectedIndexChanged);
			// 
			// btnClear
			// 
			this.btnClear.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.btnClear.Location = new System.Drawing.Point(164, 77);
			this.btnClear.Name = "btnClear";
			this.btnClear.Size = new System.Drawing.Size(75, 23);
			this.btnClear.TabIndex = 3;
			this.btnClear.Text = "&Clear";
			this.btnClear.UseVisualStyleBackColor = true;
			this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
			// 
			// btnRemove
			// 
			this.btnRemove.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.btnRemove.Location = new System.Drawing.Point(164, 48);
			this.btnRemove.Name = "btnRemove";
			this.btnRemove.Size = new System.Drawing.Size(75, 23);
			this.btnRemove.TabIndex = 2;
			this.btnRemove.Text = "&Remove";
			this.btnRemove.UseVisualStyleBackColor = true;
			this.btnRemove.Click += new System.EventHandler(this.btnRemove_Click);
			// 
			// btnAdd
			// 
			this.btnAdd.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.btnAdd.Location = new System.Drawing.Point(164, 19);
			this.btnAdd.Name = "btnAdd";
			this.btnAdd.Size = new System.Drawing.Size(75, 23);
			this.btnAdd.TabIndex = 1;
			this.btnAdd.Text = "&Add...";
			this.btnAdd.UseVisualStyleBackColor = true;
			this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
			// 
			// gbPreview
			// 
			this.gbPreview.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.gbPreview.Controls.Add(this.glControl1);
			this.gbPreview.Location = new System.Drawing.Point(266, 12);
			this.gbPreview.Name = "gbPreview";
			this.gbPreview.Size = new System.Drawing.Size(606, 537);
			this.gbPreview.TabIndex = 1;
			this.gbPreview.TabStop = false;
			this.gbPreview.Text = "Preview";
			// 
			// glControl1
			// 
			this.glControl1.BackColor = System.Drawing.Color.Black;
			this.glControl1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.glControl1.Location = new System.Drawing.Point(3, 16);
			this.glControl1.Name = "glControl1";
			this.glControl1.Size = new System.Drawing.Size(600, 518);
			this.glControl1.TabIndex = 4;
			this.glControl1.VSync = false;
			this.glControl1.Load += new System.EventHandler(this.glControl1_Load);
			this.glControl1.Paint += new System.Windows.Forms.PaintEventHandler(this.glControl1_Paint);
			this.glControl1.Enter += new System.EventHandler(this.glControl1_Enter);
			this.glControl1.Leave += new System.EventHandler(this.glControl1_Leave);
			this.glControl1.MouseClick += new System.Windows.Forms.MouseEventHandler(this.glControl1_MouseClick);
			this.glControl1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.glControl1_MouseDown);
			this.glControl1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.glControl1_MouseMove);
			this.glControl1.MouseUp += new System.Windows.Forms.MouseEventHandler(this.glControl1_MouseUp);
			this.glControl1.Resize += new System.EventHandler(this.glControl1_Resize);
			// 
			// gbItemInfo
			// 
			this.gbItemInfo.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
			this.gbItemInfo.Controls.Add(this.tableLayoutPanel4);
			this.gbItemInfo.Controls.Add(this.tcItemInfo);
			this.gbItemInfo.Location = new System.Drawing.Point(12, 169);
			this.gbItemInfo.Name = "gbItemInfo";
			this.gbItemInfo.Size = new System.Drawing.Size(251, 351);
			this.gbItemInfo.TabIndex = 2;
			this.gbItemInfo.TabStop = false;
			this.gbItemInfo.Text = "Item I&nformation";
			// 
			// tableLayoutPanel4
			// 
			this.tableLayoutPanel4.ColumnCount = 3;
			this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
			this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
			this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 30F));
			this.tableLayoutPanel4.Controls.Add(this.lblName, 0, 0);
			this.tableLayoutPanel4.Controls.Add(this.btnRename, 2, 0);
			this.tableLayoutPanel4.Controls.Add(this.tbObjectName, 1, 0);
			this.tableLayoutPanel4.Location = new System.Drawing.Point(6, 19);
			this.tableLayoutPanel4.Name = "tableLayoutPanel4";
			this.tableLayoutPanel4.RowCount = 1;
			this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.tableLayoutPanel4.Size = new System.Drawing.Size(239, 31);
			this.tableLayoutPanel4.TabIndex = 1;
			// 
			// lblName
			// 
			this.lblName.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
			this.lblName.AutoSize = true;
			this.lblName.Location = new System.Drawing.Point(3, 9);
			this.lblName.Name = "lblName";
			this.lblName.Size = new System.Drawing.Size(41, 13);
			this.lblName.TabIndex = 0;
			this.lblName.Text = "&Name";
			// 
			// btnRename
			// 
			this.btnRename.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
			this.btnRename.Location = new System.Drawing.Point(169, 4);
			this.btnRename.Name = "btnRename";
			this.btnRename.Size = new System.Drawing.Size(67, 23);
			this.btnRename.TabIndex = 1;
			this.btnRename.Text = "Rename";
			this.btnRename.UseVisualStyleBackColor = true;
			this.btnRename.Click += new System.EventHandler(this.btnRename_Click);
			// 
			// tbObjectName
			// 
			this.tbObjectName.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
			this.tbObjectName.Location = new System.Drawing.Point(50, 5);
			this.tbObjectName.Name = "tbObjectName";
			this.tbObjectName.Size = new System.Drawing.Size(113, 20);
			this.tbObjectName.TabIndex = 2;
			// 
			// tcItemInfo
			// 
			this.tcItemInfo.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.tcItemInfo.Controls.Add(this.tpPosRot);
			this.tcItemInfo.Controls.Add(this.tpFileID);
			this.tcItemInfo.Location = new System.Drawing.Point(6, 56);
			this.tcItemInfo.Name = "tcItemInfo";
			this.tcItemInfo.SelectedIndex = 0;
			this.tcItemInfo.Size = new System.Drawing.Size(239, 289);
			this.tcItemInfo.TabIndex = 0;
			// 
			// tpPosRot
			// 
			this.tpPosRot.Controls.Add(this.tableLayoutPanel2);
			this.tpPosRot.Controls.Add(this.tableLayoutPanel1);
			this.tpPosRot.Location = new System.Drawing.Point(4, 22);
			this.tpPosRot.Name = "tpPosRot";
			this.tpPosRot.Padding = new System.Windows.Forms.Padding(3);
			this.tpPosRot.Size = new System.Drawing.Size(231, 263);
			this.tpPosRot.TabIndex = 0;
			this.tpPosRot.Text = "Position/Rotation";
			this.tpPosRot.UseVisualStyleBackColor = true;
			// 
			// tableLayoutPanel2
			// 
			this.tableLayoutPanel2.ColumnCount = 2;
			this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
			this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
			this.tableLayoutPanel2.Controls.Add(this.btnUpdatePosRot, 0, 0);
			this.tableLayoutPanel2.Controls.Add(this.btnResetPosRot, 1, 0);
			this.tableLayoutPanel2.Location = new System.Drawing.Point(6, 224);
			this.tableLayoutPanel2.Name = "tableLayoutPanel2";
			this.tableLayoutPanel2.RowCount = 1;
			this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
			this.tableLayoutPanel2.Size = new System.Drawing.Size(219, 33);
			this.tableLayoutPanel2.TabIndex = 4;
			// 
			// btnUpdatePosRot
			// 
			this.btnUpdatePosRot.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
			this.btnUpdatePosRot.Location = new System.Drawing.Point(3, 5);
			this.btnUpdatePosRot.Name = "btnUpdatePosRot";
			this.btnUpdatePosRot.Size = new System.Drawing.Size(103, 23);
			this.btnUpdatePosRot.TabIndex = 2;
			this.btnUpdatePosRot.Text = "&Update";
			this.btnUpdatePosRot.UseVisualStyleBackColor = true;
			this.btnUpdatePosRot.Click += new System.EventHandler(this.btnUpdatePosRot_Click);
			// 
			// btnResetPosRot
			// 
			this.btnResetPosRot.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
			this.btnResetPosRot.Location = new System.Drawing.Point(112, 5);
			this.btnResetPosRot.Name = "btnResetPosRot";
			this.btnResetPosRot.Size = new System.Drawing.Size(104, 23);
			this.btnResetPosRot.TabIndex = 3;
			this.btnResetPosRot.Text = "&Reset";
			this.btnResetPosRot.UseVisualStyleBackColor = true;
			this.btnResetPosRot.Click += new System.EventHandler(this.btnResetPosRot_Click);
			// 
			// tableLayoutPanel1
			// 
			this.tableLayoutPanel1.ColumnCount = 2;
			this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 30F));
			this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 70F));
			this.tableLayoutPanel1.Controls.Add(this.lblScaleZ, 0, 8);
			this.tableLayoutPanel1.Controls.Add(this.lblPosX, 0, 0);
			this.tableLayoutPanel1.Controls.Add(this.lblPosY, 0, 1);
			this.tableLayoutPanel1.Controls.Add(this.lblPosZ, 0, 2);
			this.tableLayoutPanel1.Controls.Add(this.lblRotX, 0, 3);
			this.tableLayoutPanel1.Controls.Add(this.tbPosX, 1, 0);
			this.tableLayoutPanel1.Controls.Add(this.tbPosY, 1, 1);
			this.tableLayoutPanel1.Controls.Add(this.tbPosZ, 1, 2);
			this.tableLayoutPanel1.Controls.Add(this.tbRotX, 1, 3);
			this.tableLayoutPanel1.Controls.Add(this.lblRotY, 0, 4);
			this.tableLayoutPanel1.Controls.Add(this.lblRotZ, 0, 5);
			this.tableLayoutPanel1.Controls.Add(this.tbRotY, 1, 4);
			this.tableLayoutPanel1.Controls.Add(this.tbRotZ, 1, 5);
			this.tableLayoutPanel1.Controls.Add(this.lblScaleX, 0, 6);
			this.tableLayoutPanel1.Controls.Add(this.lblScaleY, 0, 7);
			this.tableLayoutPanel1.Controls.Add(this.tbScaleX, 1, 6);
			this.tableLayoutPanel1.Controls.Add(this.tbScaleY, 1, 7);
			this.tableLayoutPanel1.Controls.Add(this.tbScaleZ, 1, 8);
			this.tableLayoutPanel1.Location = new System.Drawing.Point(6, 6);
			this.tableLayoutPanel1.Name = "tableLayoutPanel1";
			this.tableLayoutPanel1.RowCount = 9;
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 11.11111F));
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 11.11111F));
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 11.11111F));
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 11.11111F));
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 11.11111F));
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 11.11111F));
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 11.11111F));
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 11.11111F));
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 11.11111F));
			this.tableLayoutPanel1.Size = new System.Drawing.Size(219, 212);
			this.tableLayoutPanel1.TabIndex = 1;
			// 
			// lblPosX
			// 
			this.lblPosX.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
			this.lblPosX.AutoSize = true;
			this.lblPosX.Location = new System.Drawing.Point(3, 5);
			this.lblPosX.Name = "lblPosX";
			this.lblPosX.Size = new System.Drawing.Size(59, 13);
			this.lblPosX.TabIndex = 0;
			this.lblPosX.Text = "X Position";
			// 
			// lblPosY
			// 
			this.lblPosY.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
			this.lblPosY.AutoSize = true;
			this.lblPosY.Location = new System.Drawing.Point(3, 28);
			this.lblPosY.Name = "lblPosY";
			this.lblPosY.Size = new System.Drawing.Size(59, 13);
			this.lblPosY.TabIndex = 1;
			this.lblPosY.Text = "Y Position";
			// 
			// lblPosZ
			// 
			this.lblPosZ.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
			this.lblPosZ.AutoSize = true;
			this.lblPosZ.Location = new System.Drawing.Point(3, 51);
			this.lblPosZ.Name = "lblPosZ";
			this.lblPosZ.Size = new System.Drawing.Size(59, 13);
			this.lblPosZ.TabIndex = 2;
			this.lblPosZ.Text = "Z Position";
			// 
			// lblRotX
			// 
			this.lblRotX.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
			this.lblRotX.AutoSize = true;
			this.lblRotX.Location = new System.Drawing.Point(3, 74);
			this.lblRotX.Name = "lblRotX";
			this.lblRotX.Size = new System.Drawing.Size(59, 13);
			this.lblRotX.TabIndex = 3;
			this.lblRotX.Text = "X Rotation";
			// 
			// tbPosX
			// 
			this.tbPosX.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
			this.tbPosX.Location = new System.Drawing.Point(68, 3);
			this.tbPosX.Name = "tbPosX";
			this.tbPosX.Size = new System.Drawing.Size(148, 20);
			this.tbPosX.TabIndex = 7;
			this.tbPosX.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TextBoxNumeric_KeyPress);
			// 
			// tbPosY
			// 
			this.tbPosY.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
			this.tbPosY.Location = new System.Drawing.Point(68, 26);
			this.tbPosY.Name = "tbPosY";
			this.tbPosY.Size = new System.Drawing.Size(148, 20);
			this.tbPosY.TabIndex = 8;
			this.tbPosY.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TextBoxNumeric_KeyPress);
			// 
			// tbPosZ
			// 
			this.tbPosZ.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
			this.tbPosZ.Location = new System.Drawing.Point(68, 49);
			this.tbPosZ.Name = "tbPosZ";
			this.tbPosZ.Size = new System.Drawing.Size(148, 20);
			this.tbPosZ.TabIndex = 9;
			this.tbPosZ.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TextBoxNumeric_KeyPress);
			// 
			// tbRotX
			// 
			this.tbRotX.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
			this.tbRotX.Location = new System.Drawing.Point(68, 72);
			this.tbRotX.Name = "tbRotX";
			this.tbRotX.Size = new System.Drawing.Size(148, 20);
			this.tbRotX.TabIndex = 10;
			this.tbRotX.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TextBoxNumeric_KeyPress);
			// 
			// lblRotY
			// 
			this.lblRotY.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
			this.lblRotY.AutoSize = true;
			this.lblRotY.Location = new System.Drawing.Point(3, 97);
			this.lblRotY.Name = "lblRotY";
			this.lblRotY.Size = new System.Drawing.Size(59, 13);
			this.lblRotY.TabIndex = 11;
			this.lblRotY.Text = "Y Rotation";
			// 
			// lblRotZ
			// 
			this.lblRotZ.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
			this.lblRotZ.AutoSize = true;
			this.lblRotZ.Location = new System.Drawing.Point(3, 120);
			this.lblRotZ.Name = "lblRotZ";
			this.lblRotZ.Size = new System.Drawing.Size(59, 13);
			this.lblRotZ.TabIndex = 12;
			this.lblRotZ.Text = "Z Rotation";
			// 
			// tbRotY
			// 
			this.tbRotY.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
			this.tbRotY.Location = new System.Drawing.Point(68, 95);
			this.tbRotY.Name = "tbRotY";
			this.tbRotY.Size = new System.Drawing.Size(148, 20);
			this.tbRotY.TabIndex = 13;
			this.tbRotY.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TextBoxNumeric_KeyPress);
			// 
			// tbRotZ
			// 
			this.tbRotZ.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
			this.tbRotZ.Location = new System.Drawing.Point(68, 118);
			this.tbRotZ.Name = "tbRotZ";
			this.tbRotZ.Size = new System.Drawing.Size(148, 20);
			this.tbRotZ.TabIndex = 14;
			this.tbRotZ.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TextBoxNumeric_KeyPress);
			// 
			// tpFileID
			// 
			this.tpFileID.Controls.Add(this.cbEnableTexture);
			this.tpFileID.Controls.Add(this.btnEditModelFileID);
			this.tpFileID.Controls.Add(this.tableLayoutPanel3);
			this.tpFileID.Location = new System.Drawing.Point(4, 22);
			this.tpFileID.Name = "tpFileID";
			this.tpFileID.Padding = new System.Windows.Forms.Padding(3);
			this.tpFileID.Size = new System.Drawing.Size(231, 248);
			this.tpFileID.TabIndex = 1;
			this.tpFileID.Text = "File IDs";
			this.tpFileID.UseVisualStyleBackColor = true;
			// 
			// cbEnableTexture
			// 
			this.cbEnableTexture.AutoSize = true;
			this.cbEnableTexture.Checked = true;
			this.cbEnableTexture.CheckState = System.Windows.Forms.CheckState.Checked;
			this.cbEnableTexture.Location = new System.Drawing.Point(6, 141);
			this.cbEnableTexture.Name = "cbEnableTexture";
			this.cbEnableTexture.Size = new System.Drawing.Size(98, 17);
			this.cbEnableTexture.TabIndex = 2;
			this.cbEnableTexture.Text = "Enable Texture";
			this.cbEnableTexture.UseVisualStyleBackColor = true;
			this.cbEnableTexture.CheckedChanged += new System.EventHandler(this.cbEnableTexture_CheckedChanged);
			// 
			// btnEditModelFileID
			// 
			this.btnEditModelFileID.Location = new System.Drawing.Point(6, 112);
			this.btnEditModelFileID.Name = "btnEditModelFileID";
			this.btnEditModelFileID.Size = new System.Drawing.Size(219, 23);
			this.btnEditModelFileID.TabIndex = 1;
			this.btnEditModelFileID.Text = "&Modify...";
			this.btnEditModelFileID.UseVisualStyleBackColor = true;
			this.btnEditModelFileID.Click += new System.EventHandler(this.btnEditModelFileID_Click);
			// 
			// tableLayoutPanel3
			// 
			this.tableLayoutPanel3.ColumnCount = 2;
			this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
			this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 75F));
			this.tableLayoutPanel3.Controls.Add(this.tbTexFileID, 1, 2);
			this.tableLayoutPanel3.Controls.Add(this.tbPalFileID, 1, 1);
			this.tableLayoutPanel3.Controls.Add(this.tbModelFileID, 1, 0);
			this.tableLayoutPanel3.Controls.Add(this.lblModelID, 0, 0);
			this.tableLayoutPanel3.Controls.Add(this.lblPalID, 0, 1);
			this.tableLayoutPanel3.Controls.Add(this.lblTextureID, 0, 2);
			this.tableLayoutPanel3.Location = new System.Drawing.Point(6, 6);
			this.tableLayoutPanel3.Name = "tableLayoutPanel3";
			this.tableLayoutPanel3.RowCount = 3;
			this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
			this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
			this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
			this.tableLayoutPanel3.Size = new System.Drawing.Size(219, 100);
			this.tableLayoutPanel3.TabIndex = 0;
			// 
			// tbTexFileID
			// 
			this.tbTexFileID.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
			this.tbTexFileID.Location = new System.Drawing.Point(57, 73);
			this.tbTexFileID.Name = "tbTexFileID";
			this.tbTexFileID.ReadOnly = true;
			this.tbTexFileID.Size = new System.Drawing.Size(159, 20);
			this.tbTexFileID.TabIndex = 1;
			// 
			// tbPalFileID
			// 
			this.tbPalFileID.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
			this.tbPalFileID.Location = new System.Drawing.Point(57, 39);
			this.tbPalFileID.Name = "tbPalFileID";
			this.tbPalFileID.ReadOnly = true;
			this.tbPalFileID.Size = new System.Drawing.Size(159, 20);
			this.tbPalFileID.TabIndex = 1;
			// 
			// tbModelFileID
			// 
			this.tbModelFileID.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
			this.tbModelFileID.Location = new System.Drawing.Point(57, 6);
			this.tbModelFileID.Name = "tbModelFileID";
			this.tbModelFileID.ReadOnly = true;
			this.tbModelFileID.Size = new System.Drawing.Size(159, 20);
			this.tbModelFileID.TabIndex = 1;
			// 
			// lblModelID
			// 
			this.lblModelID.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
			this.lblModelID.AutoSize = true;
			this.lblModelID.Location = new System.Drawing.Point(3, 10);
			this.lblModelID.Name = "lblModelID";
			this.lblModelID.Size = new System.Drawing.Size(48, 13);
			this.lblModelID.TabIndex = 0;
			this.lblModelID.Text = "Model";
			// 
			// lblPalID
			// 
			this.lblPalID.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
			this.lblPalID.AutoSize = true;
			this.lblPalID.Location = new System.Drawing.Point(3, 43);
			this.lblPalID.Name = "lblPalID";
			this.lblPalID.Size = new System.Drawing.Size(48, 13);
			this.lblPalID.TabIndex = 1;
			this.lblPalID.Text = "Palette";
			// 
			// lblTextureID
			// 
			this.lblTextureID.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
			this.lblTextureID.AutoSize = true;
			this.lblTextureID.Location = new System.Drawing.Point(3, 76);
			this.lblTextureID.Name = "lblTextureID";
			this.lblTextureID.Size = new System.Drawing.Size(48, 13);
			this.lblTextureID.TabIndex = 2;
			this.lblTextureID.Text = "Texture";
			// 
			// btnBackgroundColor
			// 
			this.btnBackgroundColor.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.btnBackgroundColor.Location = new System.Drawing.Point(12, 526);
			this.btnBackgroundColor.Name = "btnBackgroundColor";
			this.btnBackgroundColor.Size = new System.Drawing.Size(122, 23);
			this.btnBackgroundColor.TabIndex = 4;
			this.btnBackgroundColor.Text = "Background &Color...";
			this.btnBackgroundColor.UseVisualStyleBackColor = true;
			this.btnBackgroundColor.Click += new System.EventHandler(this.btnBackgroundColor_Click);
			// 
			// btnResetCamera
			// 
			this.btnResetCamera.Location = new System.Drawing.Point(140, 526);
			this.btnResetCamera.Name = "btnResetCamera";
			this.btnResetCamera.Size = new System.Drawing.Size(120, 23);
			this.btnResetCamera.TabIndex = 5;
			this.btnResetCamera.Text = "Re&set Camera";
			this.btnResetCamera.UseVisualStyleBackColor = true;
			this.btnResetCamera.Click += new System.EventHandler(this.btnResetCamera_Click);
			// 
			// lblScaleX
			// 
			this.lblScaleX.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
			this.lblScaleX.AutoSize = true;
			this.lblScaleX.Location = new System.Drawing.Point(3, 143);
			this.lblScaleX.Name = "lblScaleX";
			this.lblScaleX.Size = new System.Drawing.Size(59, 13);
			this.lblScaleX.TabIndex = 15;
			this.lblScaleX.Text = "X Scale";
			// 
			// lblScaleY
			// 
			this.lblScaleY.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
			this.lblScaleY.AutoSize = true;
			this.lblScaleY.Location = new System.Drawing.Point(3, 166);
			this.lblScaleY.Name = "lblScaleY";
			this.lblScaleY.Size = new System.Drawing.Size(59, 13);
			this.lblScaleY.TabIndex = 16;
			this.lblScaleY.Text = "Y Scale";
			// 
			// lblScaleZ
			// 
			this.lblScaleZ.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
			this.lblScaleZ.AutoSize = true;
			this.lblScaleZ.Location = new System.Drawing.Point(3, 191);
			this.lblScaleZ.Name = "lblScaleZ";
			this.lblScaleZ.Size = new System.Drawing.Size(59, 13);
			this.lblScaleZ.TabIndex = 17;
			this.lblScaleZ.Text = "Z Scale";
			// 
			// tbScaleX
			// 
			this.tbScaleX.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
			this.tbScaleX.Location = new System.Drawing.Point(68, 141);
			this.tbScaleX.Name = "tbScaleX";
			this.tbScaleX.Size = new System.Drawing.Size(148, 20);
			this.tbScaleX.TabIndex = 18;
			this.tbScaleX.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TextBoxNumeric_KeyPress);
			// 
			// tbScaleY
			// 
			this.tbScaleY.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
			this.tbScaleY.Location = new System.Drawing.Point(68, 164);
			this.tbScaleY.Name = "tbScaleY";
			this.tbScaleY.Size = new System.Drawing.Size(148, 20);
			this.tbScaleY.TabIndex = 19;
			this.tbScaleY.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TextBoxNumeric_KeyPress);
			// 
			// tbScaleZ
			// 
			this.tbScaleZ.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
			this.tbScaleZ.Location = new System.Drawing.Point(68, 188);
			this.tbScaleZ.Name = "tbScaleZ";
			this.tbScaleZ.Size = new System.Drawing.Size(148, 20);
			this.tbScaleZ.TabIndex = 20;
			this.tbScaleZ.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TextBoxNumeric_KeyPress);
			// 
			// TestScene3D
			// 
			this.AcceptButton = this.btnUpdatePosRot;
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(884, 561);
			this.Controls.Add(this.btnResetCamera);
			this.Controls.Add(this.btnBackgroundColor);
			this.Controls.Add(this.gbItemInfo);
			this.Controls.Add(this.gbPreview);
			this.Controls.Add(this.gbItems);
			this.KeyPreview = true;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.MinimumSize = new System.Drawing.Size(900, 600);
			this.Name = "TestScene3D";
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "TestScene3D";
			this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.TestScene3D_FormClosing);
			this.Enter += new System.EventHandler(this.TestScene3D_Enter);
			this.Leave += new System.EventHandler(this.TestScene3D_Leave);
			this.gbItems.ResumeLayout(false);
			this.gbPreview.ResumeLayout(false);
			this.gbItemInfo.ResumeLayout(false);
			this.tableLayoutPanel4.ResumeLayout(false);
			this.tableLayoutPanel4.PerformLayout();
			this.tcItemInfo.ResumeLayout(false);
			this.tpPosRot.ResumeLayout(false);
			this.tableLayoutPanel2.ResumeLayout(false);
			this.tableLayoutPanel1.ResumeLayout(false);
			this.tableLayoutPanel1.PerformLayout();
			this.tpFileID.ResumeLayout(false);
			this.tpFileID.PerformLayout();
			this.tableLayoutPanel3.ResumeLayout(false);
			this.tableLayoutPanel3.PerformLayout();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.GroupBox gbItems;
		private System.Windows.Forms.GroupBox gbPreview;
		private OpenTK.GLControl glControl1;
		private System.Windows.Forms.GroupBox gbItemInfo;
		private System.Windows.Forms.Button btnClear;
		private System.Windows.Forms.Button btnRemove;
		private System.Windows.Forms.Button btnAdd;
		private System.Windows.Forms.TabControl tcItemInfo;
		private System.Windows.Forms.TabPage tpPosRot;
		private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
		private System.Windows.Forms.Button btnUpdatePosRot;
		private System.Windows.Forms.Button btnResetPosRot;
		private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
		private System.Windows.Forms.Label lblPosX;
		private System.Windows.Forms.Label lblPosY;
		private System.Windows.Forms.Label lblPosZ;
		private System.Windows.Forms.Label lblRotX;
		private System.Windows.Forms.TextBox tbPosX;
		private System.Windows.Forms.TextBox tbPosY;
		private System.Windows.Forms.TextBox tbPosZ;
		private System.Windows.Forms.TextBox tbRotX;
		private System.Windows.Forms.Label lblRotY;
		private System.Windows.Forms.Label lblRotZ;
		private System.Windows.Forms.TextBox tbRotY;
		private System.Windows.Forms.TextBox tbRotZ;
		private System.Windows.Forms.TabPage tpFileID;
		private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
		private System.Windows.Forms.Label lblModelID;
		private System.Windows.Forms.Label lblPalID;
		private System.Windows.Forms.Label lblTextureID;
		private System.Windows.Forms.TextBox tbModelFileID;
		private System.Windows.Forms.TextBox tbPalFileID;
		private System.Windows.Forms.TextBox tbTexFileID;
		private System.Windows.Forms.Button btnEditModelFileID;
		private System.Windows.Forms.CheckBox cbEnableTexture;
		private System.Windows.Forms.Button btnBackgroundColor;
		private System.Windows.Forms.TableLayoutPanel tableLayoutPanel4;
		private System.Windows.Forms.Label lblName;
		private System.Windows.Forms.Button btnRename;
		private System.Windows.Forms.TextBox tbObjectName;
		private System.Windows.Forms.ListView lvSceneItems;
		private System.Windows.Forms.Button btnResetCamera;
		private System.Windows.Forms.Label lblScaleZ;
		private System.Windows.Forms.Label lblScaleX;
		private System.Windows.Forms.Label lblScaleY;
		private System.Windows.Forms.TextBox tbScaleX;
		private System.Windows.Forms.TextBox tbScaleY;
		private System.Windows.Forms.TextBox tbScaleZ;
	}
}