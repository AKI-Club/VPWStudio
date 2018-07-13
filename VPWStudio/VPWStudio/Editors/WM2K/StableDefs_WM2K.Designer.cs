namespace VPWStudio.Editors.WM2K
{
	partial class StableDefs_WM2K
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
			this.lbStables = new System.Windows.Forms.ListBox();
			this.gbStables = new System.Windows.Forms.GroupBox();
			this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
			this.tbNamePointer = new System.Windows.Forms.TextBox();
			this.labelWresDefPointer = new System.Windows.Forms.Label();
			this.tbWrestlerDefPointer = new System.Windows.Forms.TextBox();
			this.tbNumWrestlers = new System.Windows.Forms.TextBox();
			this.labelNumWrestlers = new System.Windows.Forms.Label();
			this.tbStableName = new System.Windows.Forms.TextBox();
			this.labelStableName = new System.Windows.Forms.Label();
			this.labelNamePointer = new System.Windows.Forms.Label();
			this.lbWresID2s = new System.Windows.Forms.ListBox();
			this.gbWrestlers = new System.Windows.Forms.GroupBox();
			this.buttonSwitchGroup = new System.Windows.Forms.Button();
			this.buttonMoveUp = new System.Windows.Forms.Button();
			this.buttonMoveDown = new System.Windows.Forms.Button();
			this.buttonOK = new System.Windows.Forms.Button();
			this.buttonCancel = new System.Windows.Forms.Button();
			this.buttonSwapWres = new System.Windows.Forms.Button();
			this.gbStables.SuspendLayout();
			this.tableLayoutPanel1.SuspendLayout();
			this.gbWrestlers.SuspendLayout();
			this.SuspendLayout();
			// 
			// lbStables
			// 
			this.lbStables.FormattingEnabled = true;
			this.lbStables.Location = new System.Drawing.Point(6, 19);
			this.lbStables.Name = "lbStables";
			this.lbStables.Size = new System.Drawing.Size(108, 251);
			this.lbStables.TabIndex = 0;
			this.lbStables.SelectedIndexChanged += new System.EventHandler(this.lbStables_SelectedIndexChanged);
			// 
			// gbStables
			// 
			this.gbStables.Controls.Add(this.lbStables);
			this.gbStables.Location = new System.Drawing.Point(12, 12);
			this.gbStables.Name = "gbStables";
			this.gbStables.Size = new System.Drawing.Size(120, 275);
			this.gbStables.TabIndex = 4;
			this.gbStables.TabStop = false;
			this.gbStables.Text = "Stables";
			// 
			// tableLayoutPanel1
			// 
			this.tableLayoutPanel1.ColumnCount = 2;
			this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 52.73632F));
			this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 47.26368F));
			this.tableLayoutPanel1.Controls.Add(this.tbNamePointer, 1, 1);
			this.tableLayoutPanel1.Controls.Add(this.labelWresDefPointer, 0, 0);
			this.tableLayoutPanel1.Controls.Add(this.tbWrestlerDefPointer, 1, 0);
			this.tableLayoutPanel1.Controls.Add(this.tbNumWrestlers, 1, 3);
			this.tableLayoutPanel1.Controls.Add(this.labelNumWrestlers, 0, 3);
			this.tableLayoutPanel1.Controls.Add(this.tbStableName, 1, 2);
			this.tableLayoutPanel1.Controls.Add(this.labelStableName, 0, 2);
			this.tableLayoutPanel1.Controls.Add(this.labelNamePointer, 0, 1);
			this.tableLayoutPanel1.Location = new System.Drawing.Point(138, 12);
			this.tableLayoutPanel1.Name = "tableLayoutPanel1";
			this.tableLayoutPanel1.RowCount = 4;
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
			this.tableLayoutPanel1.Size = new System.Drawing.Size(201, 98);
			this.tableLayoutPanel1.TabIndex = 5;
			// 
			// tbNamePointer
			// 
			this.tbNamePointer.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
			this.tbNamePointer.Location = new System.Drawing.Point(109, 27);
			this.tbNamePointer.Name = "tbNamePointer";
			this.tbNamePointer.ReadOnly = true;
			this.tbNamePointer.Size = new System.Drawing.Size(89, 20);
			this.tbNamePointer.TabIndex = 9;
			// 
			// labelWresDefPointer
			// 
			this.labelWresDefPointer.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
			this.labelWresDefPointer.AutoSize = true;
			this.labelWresDefPointer.Location = new System.Drawing.Point(3, 5);
			this.labelWresDefPointer.Name = "labelWresDefPointer";
			this.labelWresDefPointer.Size = new System.Drawing.Size(100, 13);
			this.labelWresDefPointer.TabIndex = 0;
			this.labelWresDefPointer.Text = "Wrestler Definitions";
			// 
			// tbWrestlerDefPointer
			// 
			this.tbWrestlerDefPointer.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
			this.tbWrestlerDefPointer.Location = new System.Drawing.Point(109, 3);
			this.tbWrestlerDefPointer.Name = "tbWrestlerDefPointer";
			this.tbWrestlerDefPointer.ReadOnly = true;
			this.tbWrestlerDefPointer.Size = new System.Drawing.Size(89, 20);
			this.tbWrestlerDefPointer.TabIndex = 3;
			// 
			// tbNumWrestlers
			// 
			this.tbNumWrestlers.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
			this.tbNumWrestlers.Location = new System.Drawing.Point(109, 75);
			this.tbNumWrestlers.Name = "tbNumWrestlers";
			this.tbNumWrestlers.ReadOnly = true;
			this.tbNumWrestlers.Size = new System.Drawing.Size(89, 20);
			this.tbNumWrestlers.TabIndex = 7;
			// 
			// labelNumWrestlers
			// 
			this.labelNumWrestlers.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
			this.labelNumWrestlers.AutoSize = true;
			this.labelNumWrestlers.Location = new System.Drawing.Point(3, 78);
			this.labelNumWrestlers.Name = "labelNumWrestlers";
			this.labelNumWrestlers.Size = new System.Drawing.Size(100, 13);
			this.labelNumWrestlers.TabIndex = 6;
			this.labelNumWrestlers.Text = "Num. Wrestlers";
			// 
			// tbStableName
			// 
			this.tbStableName.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
			this.tbStableName.Location = new System.Drawing.Point(109, 51);
			this.tbStableName.Name = "tbStableName";
			this.tbStableName.ReadOnly = true;
			this.tbStableName.Size = new System.Drawing.Size(89, 20);
			this.tbStableName.TabIndex = 5;
			// 
			// labelStableName
			// 
			this.labelStableName.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
			this.labelStableName.AutoSize = true;
			this.labelStableName.Location = new System.Drawing.Point(3, 53);
			this.labelStableName.Name = "labelStableName";
			this.labelStableName.Size = new System.Drawing.Size(100, 13);
			this.labelStableName.TabIndex = 2;
			this.labelStableName.Text = "Stable Name";
			// 
			// labelNamePointer
			// 
			this.labelNamePointer.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
			this.labelNamePointer.AutoSize = true;
			this.labelNamePointer.Location = new System.Drawing.Point(3, 29);
			this.labelNamePointer.Name = "labelNamePointer";
			this.labelNamePointer.Size = new System.Drawing.Size(100, 13);
			this.labelNamePointer.TabIndex = 8;
			this.labelNamePointer.Text = "Name Pointer";
			// 
			// lbWresID2s
			// 
			this.lbWresID2s.FormattingEnabled = true;
			this.lbWresID2s.Location = new System.Drawing.Point(6, 19);
			this.lbWresID2s.Name = "lbWresID2s";
			this.lbWresID2s.Size = new System.Drawing.Size(93, 108);
			this.lbWresID2s.TabIndex = 8;
			// 
			// gbWrestlers
			// 
			this.gbWrestlers.Controls.Add(this.buttonSwapWres);
			this.gbWrestlers.Controls.Add(this.buttonSwitchGroup);
			this.gbWrestlers.Controls.Add(this.buttonMoveUp);
			this.gbWrestlers.Controls.Add(this.buttonMoveDown);
			this.gbWrestlers.Controls.Add(this.lbWresID2s);
			this.gbWrestlers.Location = new System.Drawing.Point(138, 116);
			this.gbWrestlers.Name = "gbWrestlers";
			this.gbWrestlers.Size = new System.Drawing.Size(201, 142);
			this.gbWrestlers.TabIndex = 9;
			this.gbWrestlers.TabStop = false;
			this.gbWrestlers.Text = "Wrestlers";
			// 
			// buttonSwitchGroup
			// 
			this.buttonSwitchGroup.Location = new System.Drawing.Point(105, 77);
			this.buttonSwitchGroup.Name = "buttonSwitchGroup";
			this.buttonSwitchGroup.Size = new System.Drawing.Size(89, 23);
			this.buttonSwitchGroup.TabIndex = 18;
			this.buttonSwitchGroup.Text = "Switch &Group";
			this.buttonSwitchGroup.UseVisualStyleBackColor = true;
			this.buttonSwitchGroup.Click += new System.EventHandler(this.buttonSwitchGroup_Click);
			// 
			// buttonMoveUp
			// 
			this.buttonMoveUp.Location = new System.Drawing.Point(105, 19);
			this.buttonMoveUp.Name = "buttonMoveUp";
			this.buttonMoveUp.Size = new System.Drawing.Size(89, 23);
			this.buttonMoveUp.TabIndex = 16;
			this.buttonMoveUp.Text = "Move &Up";
			this.buttonMoveUp.UseVisualStyleBackColor = true;
			this.buttonMoveUp.Click += new System.EventHandler(this.buttonMoveUp_Click);
			// 
			// buttonMoveDown
			// 
			this.buttonMoveDown.Location = new System.Drawing.Point(105, 48);
			this.buttonMoveDown.Name = "buttonMoveDown";
			this.buttonMoveDown.Size = new System.Drawing.Size(89, 23);
			this.buttonMoveDown.TabIndex = 17;
			this.buttonMoveDown.Text = "Move &Down";
			this.buttonMoveDown.UseVisualStyleBackColor = true;
			this.buttonMoveDown.Click += new System.EventHandler(this.buttonMoveDown_Click);
			// 
			// buttonOK
			// 
			this.buttonOK.Location = new System.Drawing.Point(138, 264);
			this.buttonOK.Name = "buttonOK";
			this.buttonOK.Size = new System.Drawing.Size(75, 23);
			this.buttonOK.TabIndex = 10;
			this.buttonOK.Text = "&OK";
			this.buttonOK.UseVisualStyleBackColor = true;
			this.buttonOK.Click += new System.EventHandler(this.buttonOK_Click);
			// 
			// buttonCancel
			// 
			this.buttonCancel.Location = new System.Drawing.Point(264, 264);
			this.buttonCancel.Name = "buttonCancel";
			this.buttonCancel.Size = new System.Drawing.Size(75, 23);
			this.buttonCancel.TabIndex = 11;
			this.buttonCancel.Text = "&Cancel";
			this.buttonCancel.UseVisualStyleBackColor = true;
			this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
			// 
			// buttonSwapWres
			// 
			this.buttonSwapWres.Location = new System.Drawing.Point(105, 106);
			this.buttonSwapWres.Name = "buttonSwapWres";
			this.buttonSwapWres.Size = new System.Drawing.Size(89, 23);
			this.buttonSwapWres.TabIndex = 19;
			this.buttonSwapWres.Text = "Swa&p Wrestler";
			this.buttonSwapWres.UseVisualStyleBackColor = true;
			this.buttonSwapWres.Click += new System.EventHandler(this.buttonSwapWres_Click);
			// 
			// StableDefs_WM2K
			// 
			this.AcceptButton = this.buttonOK;
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.CancelButton = this.buttonCancel;
			this.ClientSize = new System.Drawing.Size(351, 299);
			this.Controls.Add(this.buttonCancel);
			this.Controls.Add(this.buttonOK);
			this.Controls.Add(this.gbWrestlers);
			this.Controls.Add(this.tableLayoutPanel1);
			this.Controls.Add(this.gbStables);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.MaximizeBox = false;
			this.Name = "StableDefs_WM2K";
			this.Text = "Stable Definitions";
			this.gbStables.ResumeLayout(false);
			this.tableLayoutPanel1.ResumeLayout(false);
			this.tableLayoutPanel1.PerformLayout();
			this.gbWrestlers.ResumeLayout(false);
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.ListBox lbStables;
		private System.Windows.Forms.GroupBox gbStables;
		private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
		private System.Windows.Forms.TextBox tbStableName;
		private System.Windows.Forms.Label labelStableName;
		private System.Windows.Forms.Label labelWresDefPointer;
		private System.Windows.Forms.TextBox tbWrestlerDefPointer;
		private System.Windows.Forms.ListBox lbWresID2s;
		private System.Windows.Forms.TextBox tbNumWrestlers;
		private System.Windows.Forms.Label labelNumWrestlers;
		private System.Windows.Forms.Label labelNamePointer;
		private System.Windows.Forms.TextBox tbNamePointer;
		private System.Windows.Forms.GroupBox gbWrestlers;
		private System.Windows.Forms.Button buttonSwitchGroup;
		private System.Windows.Forms.Button buttonMoveUp;
		private System.Windows.Forms.Button buttonMoveDown;
		private System.Windows.Forms.Button buttonOK;
		private System.Windows.Forms.Button buttonCancel;
		private System.Windows.Forms.Button buttonSwapWres;
	}
}