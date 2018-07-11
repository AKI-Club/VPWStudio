namespace VPWStudio.Editors.NoMercy
{
	partial class StableDefs_NoMercy
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
			this.tbStableName = new System.Windows.Forms.TextBox();
			this.labelStableName = new System.Windows.Forms.Label();
			this.labelWresDefPointer = new System.Windows.Forms.Label();
			this.labelTextIndex = new System.Windows.Forms.Label();
			this.tbWrestlerDefPointer = new System.Windows.Forms.TextBox();
			this.tbTextIndex = new System.Windows.Forms.TextBox();
			this.lbWresID2s = new System.Windows.Forms.ListBox();
			this.buttonSwitchGroup = new System.Windows.Forms.Button();
			this.buttonMoveDown = new System.Windows.Forms.Button();
			this.buttonMoveUp = new System.Windows.Forms.Button();
			this.gbWrestlers = new System.Windows.Forms.GroupBox();
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
			this.lbStables.Size = new System.Drawing.Size(108, 225);
			this.lbStables.TabIndex = 0;
			this.lbStables.SelectedIndexChanged += new System.EventHandler(this.lbStables_SelectedIndexChanged);
			// 
			// gbStables
			// 
			this.gbStables.Controls.Add(this.lbStables);
			this.gbStables.Location = new System.Drawing.Point(12, 12);
			this.gbStables.Name = "gbStables";
			this.gbStables.Size = new System.Drawing.Size(120, 251);
			this.gbStables.TabIndex = 4;
			this.gbStables.TabStop = false;
			this.gbStables.Text = "&Stables";
			// 
			// tableLayoutPanel1
			// 
			this.tableLayoutPanel1.ColumnCount = 2;
			this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 52.73632F));
			this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 47.26368F));
			this.tableLayoutPanel1.Controls.Add(this.tbStableName, 1, 2);
			this.tableLayoutPanel1.Controls.Add(this.labelStableName, 0, 2);
			this.tableLayoutPanel1.Controls.Add(this.labelWresDefPointer, 0, 0);
			this.tableLayoutPanel1.Controls.Add(this.labelTextIndex, 0, 1);
			this.tableLayoutPanel1.Controls.Add(this.tbWrestlerDefPointer, 1, 0);
			this.tableLayoutPanel1.Controls.Add(this.tbTextIndex, 1, 1);
			this.tableLayoutPanel1.Location = new System.Drawing.Point(138, 12);
			this.tableLayoutPanel1.Name = "tableLayoutPanel1";
			this.tableLayoutPanel1.RowCount = 3;
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
			this.tableLayoutPanel1.Size = new System.Drawing.Size(201, 80);
			this.tableLayoutPanel1.TabIndex = 5;
			// 
			// tbStableName
			// 
			this.tbStableName.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
			this.tbStableName.Location = new System.Drawing.Point(109, 56);
			this.tbStableName.Name = "tbStableName";
			this.tbStableName.ReadOnly = true;
			this.tbStableName.Size = new System.Drawing.Size(89, 20);
			this.tbStableName.TabIndex = 5;
			// 
			// labelStableName
			// 
			this.labelStableName.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
			this.labelStableName.AutoSize = true;
			this.labelStableName.Location = new System.Drawing.Point(3, 59);
			this.labelStableName.Name = "labelStableName";
			this.labelStableName.Size = new System.Drawing.Size(100, 13);
			this.labelStableName.TabIndex = 2;
			this.labelStableName.Text = "Stable Name";
			// 
			// labelWresDefPointer
			// 
			this.labelWresDefPointer.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
			this.labelWresDefPointer.AutoSize = true;
			this.labelWresDefPointer.Location = new System.Drawing.Point(3, 6);
			this.labelWresDefPointer.Name = "labelWresDefPointer";
			this.labelWresDefPointer.Size = new System.Drawing.Size(100, 13);
			this.labelWresDefPointer.TabIndex = 0;
			this.labelWresDefPointer.Text = "Wrestler Definitions";
			// 
			// labelTextIndex
			// 
			this.labelTextIndex.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
			this.labelTextIndex.AutoSize = true;
			this.labelTextIndex.Location = new System.Drawing.Point(3, 32);
			this.labelTextIndex.Name = "labelTextIndex";
			this.labelTextIndex.Size = new System.Drawing.Size(100, 13);
			this.labelTextIndex.TabIndex = 1;
			this.labelTextIndex.Text = "Text Index";
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
			// tbTextIndex
			// 
			this.tbTextIndex.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
			this.tbTextIndex.Location = new System.Drawing.Point(109, 29);
			this.tbTextIndex.Name = "tbTextIndex";
			this.tbTextIndex.ReadOnly = true;
			this.tbTextIndex.Size = new System.Drawing.Size(89, 20);
			this.tbTextIndex.TabIndex = 4;
			// 
			// lbWresID2s
			// 
			this.lbWresID2s.FormattingEnabled = true;
			this.lbWresID2s.Location = new System.Drawing.Point(6, 19);
			this.lbWresID2s.Name = "lbWresID2s";
			this.lbWresID2s.Size = new System.Drawing.Size(94, 108);
			this.lbWresID2s.TabIndex = 8;
			// 
			// buttonSwitchGroup
			// 
			this.buttonSwitchGroup.Location = new System.Drawing.Point(106, 77);
			this.buttonSwitchGroup.Name = "buttonSwitchGroup";
			this.buttonSwitchGroup.Size = new System.Drawing.Size(89, 23);
			this.buttonSwitchGroup.TabIndex = 15;
			this.buttonSwitchGroup.Text = "Switch &Group";
			this.buttonSwitchGroup.UseVisualStyleBackColor = true;
			this.buttonSwitchGroup.Click += new System.EventHandler(this.buttonSwitchGroup_Click);
			// 
			// buttonMoveDown
			// 
			this.buttonMoveDown.Location = new System.Drawing.Point(106, 48);
			this.buttonMoveDown.Name = "buttonMoveDown";
			this.buttonMoveDown.Size = new System.Drawing.Size(89, 23);
			this.buttonMoveDown.TabIndex = 14;
			this.buttonMoveDown.Text = "Move &Down";
			this.buttonMoveDown.UseVisualStyleBackColor = true;
			this.buttonMoveDown.Click += new System.EventHandler(this.buttonMoveDown_Click);
			// 
			// buttonMoveUp
			// 
			this.buttonMoveUp.Location = new System.Drawing.Point(106, 19);
			this.buttonMoveUp.Name = "buttonMoveUp";
			this.buttonMoveUp.Size = new System.Drawing.Size(89, 23);
			this.buttonMoveUp.TabIndex = 13;
			this.buttonMoveUp.Text = "Move &Up";
			this.buttonMoveUp.UseVisualStyleBackColor = true;
			this.buttonMoveUp.Click += new System.EventHandler(this.buttonMoveUp_Click);
			// 
			// gbWrestlers
			// 
			this.gbWrestlers.Controls.Add(this.buttonSwapWres);
			this.gbWrestlers.Controls.Add(this.lbWresID2s);
			this.gbWrestlers.Controls.Add(this.buttonSwitchGroup);
			this.gbWrestlers.Controls.Add(this.buttonMoveUp);
			this.gbWrestlers.Controls.Add(this.buttonMoveDown);
			this.gbWrestlers.Location = new System.Drawing.Point(144, 98);
			this.gbWrestlers.Name = "gbWrestlers";
			this.gbWrestlers.Size = new System.Drawing.Size(200, 136);
			this.gbWrestlers.TabIndex = 16;
			this.gbWrestlers.TabStop = false;
			this.gbWrestlers.Text = "&Wrestlers";
			// 
			// buttonOK
			// 
			this.buttonOK.Location = new System.Drawing.Point(144, 240);
			this.buttonOK.Name = "buttonOK";
			this.buttonOK.Size = new System.Drawing.Size(75, 23);
			this.buttonOK.TabIndex = 17;
			this.buttonOK.Text = "&OK";
			this.buttonOK.UseVisualStyleBackColor = true;
			this.buttonOK.Click += new System.EventHandler(this.buttonOK_Click);
			// 
			// buttonCancel
			// 
			this.buttonCancel.Location = new System.Drawing.Point(269, 240);
			this.buttonCancel.Name = "buttonCancel";
			this.buttonCancel.Size = new System.Drawing.Size(75, 23);
			this.buttonCancel.TabIndex = 18;
			this.buttonCancel.Text = "&Cancel";
			this.buttonCancel.UseVisualStyleBackColor = true;
			this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
			// 
			// buttonSwapWres
			// 
			this.buttonSwapWres.Location = new System.Drawing.Point(106, 104);
			this.buttonSwapWres.Name = "buttonSwapWres";
			this.buttonSwapWres.Size = new System.Drawing.Size(89, 23);
			this.buttonSwapWres.TabIndex = 16;
			this.buttonSwapWres.Text = "Swa&p Wrestler";
			this.buttonSwapWres.UseVisualStyleBackColor = true;
			this.buttonSwapWres.Click += new System.EventHandler(this.buttonSwapWres_Click);
			// 
			// StableDefs_NoMercy
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(351, 275);
			this.Controls.Add(this.buttonCancel);
			this.Controls.Add(this.buttonOK);
			this.Controls.Add(this.gbWrestlers);
			this.Controls.Add(this.tableLayoutPanel1);
			this.Controls.Add(this.gbStables);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "StableDefs_NoMercy";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
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
		private System.Windows.Forms.Label labelTextIndex;
		private System.Windows.Forms.TextBox tbWrestlerDefPointer;
		private System.Windows.Forms.TextBox tbTextIndex;
		private System.Windows.Forms.ListBox lbWresID2s;
		private System.Windows.Forms.Button buttonSwitchGroup;
		private System.Windows.Forms.Button buttonMoveDown;
		private System.Windows.Forms.Button buttonMoveUp;
		private System.Windows.Forms.GroupBox gbWrestlers;
		private System.Windows.Forms.Button buttonOK;
		private System.Windows.Forms.Button buttonCancel;
		private System.Windows.Forms.Button buttonSwapWres;
	}
}