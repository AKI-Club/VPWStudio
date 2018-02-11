namespace VPWStudio
{
	partial class GameSharkTool
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
			this.components = new System.ComponentModel.Container();
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(GameSharkTool));
			this.buttonSave = new System.Windows.Forms.Button();
			this.buttonLoad = new System.Windows.Forms.Button();
			this.lbCodes = new System.Windows.Forms.ListBox();
			this.gbNewCode = new System.Windows.Forms.GroupBox();
			this.buttonModifyCode = new System.Windows.Forms.Button();
			this.buttonAddCode = new System.Windows.Forms.Button();
			this.tbCodeValue = new System.Windows.Forms.TextBox();
			this.labelValue = new System.Windows.Forms.Label();
			this.labelAddress = new System.Windows.Forms.Label();
			this.tbCodeAddress = new System.Windows.Forms.TextBox();
			this.buttonMoveCodeUp = new System.Windows.Forms.Button();
			this.buttonDeleteCode = new System.Windows.Forms.Button();
			this.buttonMoveCodeDown = new System.Windows.Forms.Button();
			this.buttonImport = new System.Windows.Forms.Button();
			this.tvCodeExaminer = new System.Windows.Forms.TreeView();
			this.cboxCodeSets = new System.Windows.Forms.ComboBox();
			this.buttonNewCodeSet = new System.Windows.Forms.Button();
			this.label1 = new System.Windows.Forms.Label();
			this.tbCodeFilePath = new System.Windows.Forms.TextBox();
			this.buttonRenameCodeSet = new System.Windows.Forms.Button();
			this.labelCodeSetName = new System.Windows.Forms.Label();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
			this.tbCodeSetName = new System.Windows.Forms.TextBox();
			this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
			this.buttonDelCodeSet = new System.Windows.Forms.Button();
			this.buttonExport = new System.Windows.Forms.Button();
			this.gbNewCode.SuspendLayout();
			this.groupBox1.SuspendLayout();
			this.tableLayoutPanel1.SuspendLayout();
			this.SuspendLayout();
			// 
			// buttonSave
			// 
			this.buttonSave.Location = new System.Drawing.Point(367, 10);
			this.buttonSave.Name = "buttonSave";
			this.buttonSave.Size = new System.Drawing.Size(56, 23);
			this.buttonSave.TabIndex = 0;
			this.buttonSave.Text = "&Save";
			this.buttonSave.UseVisualStyleBackColor = true;
			this.buttonSave.Click += new System.EventHandler(this.buttonSave_Click);
			// 
			// buttonLoad
			// 
			this.buttonLoad.Location = new System.Drawing.Point(305, 10);
			this.buttonLoad.Name = "buttonLoad";
			this.buttonLoad.Size = new System.Drawing.Size(56, 23);
			this.buttonLoad.TabIndex = 1;
			this.buttonLoad.Text = "&Load";
			this.buttonLoad.UseVisualStyleBackColor = true;
			this.buttonLoad.Click += new System.EventHandler(this.buttonLoad_Click);
			// 
			// lbCodes
			// 
			this.lbCodes.FormattingEnabled = true;
			this.lbCodes.Location = new System.Drawing.Point(6, 19);
			this.lbCodes.Name = "lbCodes";
			this.lbCodes.Size = new System.Drawing.Size(188, 316);
			this.lbCodes.TabIndex = 3;
			this.lbCodes.SelectedIndexChanged += new System.EventHandler(this.lbCodes_SelectedIndexChanged);
			// 
			// gbNewCode
			// 
			this.gbNewCode.Controls.Add(this.buttonModifyCode);
			this.gbNewCode.Controls.Add(this.buttonAddCode);
			this.gbNewCode.Controls.Add(this.tbCodeValue);
			this.gbNewCode.Controls.Add(this.labelValue);
			this.gbNewCode.Controls.Add(this.labelAddress);
			this.gbNewCode.Controls.Add(this.tbCodeAddress);
			this.gbNewCode.Location = new System.Drawing.Point(218, 90);
			this.gbNewCode.Name = "gbNewCode";
			this.gbNewCode.Size = new System.Drawing.Size(217, 104);
			this.gbNewCode.TabIndex = 4;
			this.gbNewCode.TabStop = false;
			this.gbNewCode.Text = "Code";
			// 
			// buttonModifyCode
			// 
			this.buttonModifyCode.Location = new System.Drawing.Point(136, 71);
			this.buttonModifyCode.Name = "buttonModifyCode";
			this.buttonModifyCode.Size = new System.Drawing.Size(75, 27);
			this.buttonModifyCode.TabIndex = 6;
			this.buttonModifyCode.Text = "Modify Code";
			this.buttonModifyCode.UseVisualStyleBackColor = true;
			this.buttonModifyCode.Click += new System.EventHandler(this.buttonModifyCode_Click);
			// 
			// buttonAddCode
			// 
			this.buttonAddCode.Location = new System.Drawing.Point(6, 71);
			this.buttonAddCode.Name = "buttonAddCode";
			this.buttonAddCode.Size = new System.Drawing.Size(75, 27);
			this.buttonAddCode.TabIndex = 5;
			this.buttonAddCode.Text = "Add Code";
			this.buttonAddCode.UseVisualStyleBackColor = true;
			this.buttonAddCode.Click += new System.EventHandler(this.buttonAddCode_Click);
			// 
			// tbCodeValue
			// 
			this.tbCodeValue.Location = new System.Drawing.Point(57, 45);
			this.tbCodeValue.MaxLength = 4;
			this.tbCodeValue.Name = "tbCodeValue";
			this.tbCodeValue.Size = new System.Drawing.Size(80, 20);
			this.tbCodeValue.TabIndex = 4;
			// 
			// labelValue
			// 
			this.labelValue.AutoSize = true;
			this.labelValue.Location = new System.Drawing.Point(17, 48);
			this.labelValue.Name = "labelValue";
			this.labelValue.Size = new System.Drawing.Size(34, 13);
			this.labelValue.TabIndex = 3;
			this.labelValue.Text = "Value";
			// 
			// labelAddress
			// 
			this.labelAddress.AutoSize = true;
			this.labelAddress.Location = new System.Drawing.Point(6, 22);
			this.labelAddress.Name = "labelAddress";
			this.labelAddress.Size = new System.Drawing.Size(45, 13);
			this.labelAddress.TabIndex = 2;
			this.labelAddress.Text = "Address";
			// 
			// tbCodeAddress
			// 
			this.tbCodeAddress.Location = new System.Drawing.Point(57, 19);
			this.tbCodeAddress.MaxLength = 8;
			this.tbCodeAddress.Name = "tbCodeAddress";
			this.tbCodeAddress.Size = new System.Drawing.Size(148, 20);
			this.tbCodeAddress.TabIndex = 1;
			// 
			// buttonMoveCodeUp
			// 
			this.buttonMoveCodeUp.Location = new System.Drawing.Point(6, 345);
			this.buttonMoveCodeUp.Name = "buttonMoveCodeUp";
			this.buttonMoveCodeUp.Size = new System.Drawing.Size(48, 23);
			this.buttonMoveCodeUp.TabIndex = 5;
			this.buttonMoveCodeUp.Text = "↑";
			this.toolTip1.SetToolTip(this.buttonMoveCodeUp, "Move Selected Code Up");
			this.buttonMoveCodeUp.UseVisualStyleBackColor = true;
			this.buttonMoveCodeUp.Click += new System.EventHandler(this.buttonMoveCodeUp_Click);
			// 
			// buttonDeleteCode
			// 
			this.buttonDeleteCode.Location = new System.Drawing.Point(60, 345);
			this.buttonDeleteCode.Name = "buttonDeleteCode";
			this.buttonDeleteCode.Size = new System.Drawing.Size(80, 23);
			this.buttonDeleteCode.TabIndex = 6;
			this.buttonDeleteCode.Text = "Delete";
			this.toolTip1.SetToolTip(this.buttonDeleteCode, "Delete Selected Code");
			this.buttonDeleteCode.UseVisualStyleBackColor = true;
			this.buttonDeleteCode.Click += new System.EventHandler(this.buttonDeleteCode_Click);
			// 
			// buttonMoveCodeDown
			// 
			this.buttonMoveCodeDown.Location = new System.Drawing.Point(146, 345);
			this.buttonMoveCodeDown.Name = "buttonMoveCodeDown";
			this.buttonMoveCodeDown.Size = new System.Drawing.Size(48, 23);
			this.buttonMoveCodeDown.TabIndex = 7;
			this.buttonMoveCodeDown.Text = "↓";
			this.toolTip1.SetToolTip(this.buttonMoveCodeDown, "Move Selected Code Down");
			this.buttonMoveCodeDown.UseVisualStyleBackColor = true;
			this.buttonMoveCodeDown.Click += new System.EventHandler(this.buttonMoveCodeDown_Click);
			// 
			// buttonImport
			// 
			this.buttonImport.Location = new System.Drawing.Point(429, 10);
			this.buttonImport.Name = "buttonImport";
			this.buttonImport.Size = new System.Drawing.Size(70, 23);
			this.buttonImport.TabIndex = 8;
			this.buttonImport.Text = "&Import...";
			this.buttonImport.UseVisualStyleBackColor = true;
			this.buttonImport.Click += new System.EventHandler(this.buttonImport_Click);
			// 
			// tvCodeExaminer
			// 
			this.tvCodeExaminer.Location = new System.Drawing.Point(217, 200);
			this.tvCodeExaminer.Name = "tvCodeExaminer";
			this.tvCodeExaminer.Size = new System.Drawing.Size(363, 241);
			this.tvCodeExaminer.TabIndex = 9;
			// 
			// cboxCodeSets
			// 
			this.cboxCodeSets.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cboxCodeSets.FormattingEnabled = true;
			this.cboxCodeSets.Location = new System.Drawing.Point(12, 38);
			this.cboxCodeSets.Name = "cboxCodeSets";
			this.cboxCodeSets.Size = new System.Drawing.Size(131, 21);
			this.cboxCodeSets.TabIndex = 10;
			this.cboxCodeSets.SelectedIndexChanged += new System.EventHandler(this.cboxCodeSets_SelectedIndexChanged);
			// 
			// buttonNewCodeSet
			// 
			this.buttonNewCodeSet.Location = new System.Drawing.Point(149, 38);
			this.buttonNewCodeSet.Name = "buttonNewCodeSet";
			this.buttonNewCodeSet.Size = new System.Drawing.Size(29, 23);
			this.buttonNewCodeSet.TabIndex = 11;
			this.buttonNewCodeSet.Text = "+";
			this.buttonNewCodeSet.UseVisualStyleBackColor = true;
			this.buttonNewCodeSet.Click += new System.EventHandler(this.buttonNewCodeSet_Click);
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(12, 15);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(51, 13);
			this.label1.TabIndex = 12;
			this.label1.Text = "Code &File";
			// 
			// tbCodeFilePath
			// 
			this.tbCodeFilePath.Location = new System.Drawing.Point(67, 12);
			this.tbCodeFilePath.Name = "tbCodeFilePath";
			this.tbCodeFilePath.ReadOnly = true;
			this.tbCodeFilePath.Size = new System.Drawing.Size(232, 20);
			this.tbCodeFilePath.TabIndex = 13;
			// 
			// buttonRenameCodeSet
			// 
			this.buttonRenameCodeSet.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
			this.buttonRenameCodeSet.Location = new System.Drawing.Point(236, 11);
			this.buttonRenameCodeSet.Name = "buttonRenameCodeSet";
			this.buttonRenameCodeSet.Size = new System.Drawing.Size(123, 23);
			this.buttonRenameCodeSet.TabIndex = 14;
			this.buttonRenameCodeSet.Text = "Rename CodeSet";
			this.buttonRenameCodeSet.UseVisualStyleBackColor = true;
			this.buttonRenameCodeSet.Click += new System.EventHandler(this.buttonRenameCodeSet_Click);
			// 
			// labelCodeSetName
			// 
			this.labelCodeSetName.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
			this.labelCodeSetName.AutoSize = true;
			this.labelCodeSetName.Location = new System.Drawing.Point(3, 16);
			this.labelCodeSetName.Name = "labelCodeSetName";
			this.labelCodeSetName.Size = new System.Drawing.Size(38, 13);
			this.labelCodeSetName.TabIndex = 15;
			this.labelCodeSetName.Text = "&Name";
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.buttonMoveCodeUp);
			this.groupBox1.Controls.Add(this.buttonDeleteCode);
			this.groupBox1.Controls.Add(this.buttonMoveCodeDown);
			this.groupBox1.Controls.Add(this.lbCodes);
			this.groupBox1.Location = new System.Drawing.Point(12, 67);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(200, 374);
			this.groupBox1.TabIndex = 16;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "CodeSet Codes";
			// 
			// tableLayoutPanel1
			// 
			this.tableLayoutPanel1.ColumnCount = 3;
			this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 12.1547F));
			this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 52.20995F));
			this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 35.35912F));
			this.tableLayoutPanel1.Controls.Add(this.buttonRenameCodeSet, 2, 0);
			this.tableLayoutPanel1.Controls.Add(this.labelCodeSetName, 0, 0);
			this.tableLayoutPanel1.Controls.Add(this.tbCodeSetName, 1, 0);
			this.tableLayoutPanel1.Location = new System.Drawing.Point(218, 39);
			this.tableLayoutPanel1.Name = "tableLayoutPanel1";
			this.tableLayoutPanel1.RowCount = 1;
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.tableLayoutPanel1.Size = new System.Drawing.Size(362, 45);
			this.tableLayoutPanel1.TabIndex = 17;
			// 
			// tbCodeSetName
			// 
			this.tbCodeSetName.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
			this.tbCodeSetName.Location = new System.Drawing.Point(47, 12);
			this.tbCodeSetName.Name = "tbCodeSetName";
			this.tbCodeSetName.Size = new System.Drawing.Size(183, 20);
			this.tbCodeSetName.TabIndex = 16;
			// 
			// buttonDelCodeSet
			// 
			this.buttonDelCodeSet.Location = new System.Drawing.Point(184, 38);
			this.buttonDelCodeSet.Name = "buttonDelCodeSet";
			this.buttonDelCodeSet.Size = new System.Drawing.Size(29, 23);
			this.buttonDelCodeSet.TabIndex = 18;
			this.buttonDelCodeSet.Text = "X";
			this.buttonDelCodeSet.UseVisualStyleBackColor = true;
			this.buttonDelCodeSet.Click += new System.EventHandler(this.buttonDelCodeSet_Click);
			// 
			// buttonExport
			// 
			this.buttonExport.Location = new System.Drawing.Point(505, 9);
			this.buttonExport.Name = "buttonExport";
			this.buttonExport.Size = new System.Drawing.Size(75, 23);
			this.buttonExport.TabIndex = 19;
			this.buttonExport.Text = "&Export...";
			this.buttonExport.UseVisualStyleBackColor = true;
			this.buttonExport.Click += new System.EventHandler(this.buttonExport_Click);
			// 
			// GameSharkTool
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(592, 453);
			this.Controls.Add(this.buttonExport);
			this.Controls.Add(this.buttonDelCodeSet);
			this.Controls.Add(this.tableLayoutPanel1);
			this.Controls.Add(this.groupBox1);
			this.Controls.Add(this.tbCodeFilePath);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.buttonNewCodeSet);
			this.Controls.Add(this.cboxCodeSets);
			this.Controls.Add(this.tvCodeExaminer);
			this.Controls.Add(this.buttonImport);
			this.Controls.Add(this.gbNewCode);
			this.Controls.Add(this.buttonLoad);
			this.Controls.Add(this.buttonSave);
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MaximizeBox = false;
			this.Name = "GameSharkTool";
			this.Text = "GameShark Tool";
			this.gbNewCode.ResumeLayout(false);
			this.gbNewCode.PerformLayout();
			this.groupBox1.ResumeLayout(false);
			this.tableLayoutPanel1.ResumeLayout(false);
			this.tableLayoutPanel1.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Button buttonSave;
		private System.Windows.Forms.Button buttonLoad;
		private System.Windows.Forms.ListBox lbCodes;
		private System.Windows.Forms.GroupBox gbNewCode;
		private System.Windows.Forms.Button buttonAddCode;
		private System.Windows.Forms.TextBox tbCodeValue;
		private System.Windows.Forms.Label labelValue;
		private System.Windows.Forms.Label labelAddress;
		private System.Windows.Forms.TextBox tbCodeAddress;
		private System.Windows.Forms.Button buttonMoveCodeUp;
		private System.Windows.Forms.Button buttonDeleteCode;
		private System.Windows.Forms.Button buttonMoveCodeDown;
		private System.Windows.Forms.Button buttonModifyCode;
		private System.Windows.Forms.Button buttonImport;
		private System.Windows.Forms.TreeView tvCodeExaminer;
		private System.Windows.Forms.ComboBox cboxCodeSets;
		private System.Windows.Forms.Button buttonNewCodeSet;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.TextBox tbCodeFilePath;
		private System.Windows.Forms.Button buttonRenameCodeSet;
		private System.Windows.Forms.Label labelCodeSetName;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.ToolTip toolTip1;
		private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
		private System.Windows.Forms.TextBox tbCodeSetName;
		private System.Windows.Forms.Button buttonDelCodeSet;
		private System.Windows.Forms.Button buttonExport;
	}
}