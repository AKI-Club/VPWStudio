namespace VPWStudio.Editors.Revenge
{
	partial class StableDefs_Revenge
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
			this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
			this.tbHeaderGraphic = new System.Windows.Forms.TextBox();
			this.labelHeader = new System.Windows.Forms.Label();
			this.labelWresDefPointer = new System.Windows.Forms.Label();
			this.labelNumWrestlers = new System.Windows.Forms.Label();
			this.tbWrestlerDefPointer = new System.Windows.Forms.TextBox();
			this.tbNumWrestlers = new System.Windows.Forms.TextBox();
			this.pbHeaderGraphic = new System.Windows.Forms.PictureBox();
			this.gbStables = new System.Windows.Forms.GroupBox();
			this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
			this.lbWresPointers = new System.Windows.Forms.ListBox();
			this.buttonViewWrestler = new System.Windows.Forms.Button();
			this.buttonMoveUp = new System.Windows.Forms.Button();
			this.buttonMoveDown = new System.Windows.Forms.Button();
			this.buttonSwitchGroup = new System.Windows.Forms.Button();
			this.buttonSwapWres = new System.Windows.Forms.Button();
			this.gbWrestlers = new System.Windows.Forms.GroupBox();
			this.buttonOK = new System.Windows.Forms.Button();
			this.buttonCancel = new System.Windows.Forms.Button();
			this.tableLayoutPanel1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.pbHeaderGraphic)).BeginInit();
			this.gbStables.SuspendLayout();
			this.tableLayoutPanel3.SuspendLayout();
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
			// tableLayoutPanel1
			// 
			this.tableLayoutPanel1.ColumnCount = 2;
			this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 54.72637F));
			this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 45.27363F));
			this.tableLayoutPanel1.Controls.Add(this.tbHeaderGraphic, 1, 2);
			this.tableLayoutPanel1.Controls.Add(this.labelHeader, 0, 2);
			this.tableLayoutPanel1.Controls.Add(this.labelWresDefPointer, 0, 0);
			this.tableLayoutPanel1.Controls.Add(this.labelNumWrestlers, 0, 1);
			this.tableLayoutPanel1.Controls.Add(this.tbWrestlerDefPointer, 1, 0);
			this.tableLayoutPanel1.Controls.Add(this.tbNumWrestlers, 1, 1);
			this.tableLayoutPanel1.Location = new System.Drawing.Point(138, 12);
			this.tableLayoutPanel1.Name = "tableLayoutPanel1";
			this.tableLayoutPanel1.RowCount = 3;
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
			this.tableLayoutPanel1.Size = new System.Drawing.Size(223, 80);
			this.tableLayoutPanel1.TabIndex = 1;
			// 
			// tbHeaderGraphic
			// 
			this.tbHeaderGraphic.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
			this.tbHeaderGraphic.Location = new System.Drawing.Point(125, 56);
			this.tbHeaderGraphic.Name = "tbHeaderGraphic";
			this.tbHeaderGraphic.ReadOnly = true;
			this.tbHeaderGraphic.Size = new System.Drawing.Size(95, 20);
			this.tbHeaderGraphic.TabIndex = 5;
			// 
			// labelHeader
			// 
			this.labelHeader.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
			this.labelHeader.AutoSize = true;
			this.labelHeader.Location = new System.Drawing.Point(3, 59);
			this.labelHeader.Name = "labelHeader";
			this.labelHeader.Size = new System.Drawing.Size(116, 13);
			this.labelHeader.TabIndex = 2;
			this.labelHeader.Text = "Header Graphic";
			// 
			// labelWresDefPointer
			// 
			this.labelWresDefPointer.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
			this.labelWresDefPointer.AutoSize = true;
			this.labelWresDefPointer.Location = new System.Drawing.Point(3, 6);
			this.labelWresDefPointer.Name = "labelWresDefPointer";
			this.labelWresDefPointer.Size = new System.Drawing.Size(116, 13);
			this.labelWresDefPointer.TabIndex = 0;
			this.labelWresDefPointer.Text = "Wrestler Definitions";
			// 
			// labelNumWrestlers
			// 
			this.labelNumWrestlers.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
			this.labelNumWrestlers.AutoSize = true;
			this.labelNumWrestlers.Location = new System.Drawing.Point(3, 32);
			this.labelNumWrestlers.Name = "labelNumWrestlers";
			this.labelNumWrestlers.Size = new System.Drawing.Size(116, 13);
			this.labelNumWrestlers.TabIndex = 1;
			this.labelNumWrestlers.Text = "Wrestler Count";
			// 
			// tbWrestlerDefPointer
			// 
			this.tbWrestlerDefPointer.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
			this.tbWrestlerDefPointer.Location = new System.Drawing.Point(125, 3);
			this.tbWrestlerDefPointer.Name = "tbWrestlerDefPointer";
			this.tbWrestlerDefPointer.ReadOnly = true;
			this.tbWrestlerDefPointer.Size = new System.Drawing.Size(95, 20);
			this.tbWrestlerDefPointer.TabIndex = 3;
			// 
			// tbNumWrestlers
			// 
			this.tbNumWrestlers.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
			this.tbNumWrestlers.Location = new System.Drawing.Point(125, 29);
			this.tbNumWrestlers.Name = "tbNumWrestlers";
			this.tbNumWrestlers.ReadOnly = true;
			this.tbNumWrestlers.Size = new System.Drawing.Size(95, 20);
			this.tbNumWrestlers.TabIndex = 4;
			// 
			// pbHeaderGraphic
			// 
			this.pbHeaderGraphic.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
			this.pbHeaderGraphic.Location = new System.Drawing.Point(47, 3);
			this.pbHeaderGraphic.MaximumSize = new System.Drawing.Size(128, 16);
			this.pbHeaderGraphic.Name = "pbHeaderGraphic";
			this.pbHeaderGraphic.Size = new System.Drawing.Size(128, 16);
			this.pbHeaderGraphic.TabIndex = 2;
			this.pbHeaderGraphic.TabStop = false;
			// 
			// gbStables
			// 
			this.gbStables.Controls.Add(this.lbStables);
			this.gbStables.Location = new System.Drawing.Point(12, 12);
			this.gbStables.Name = "gbStables";
			this.gbStables.Size = new System.Drawing.Size(120, 280);
			this.gbStables.TabIndex = 3;
			this.gbStables.TabStop = false;
			this.gbStables.Text = "Stables";
			// 
			// tableLayoutPanel3
			// 
			this.tableLayoutPanel3.ColumnCount = 1;
			this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
			this.tableLayoutPanel3.Controls.Add(this.pbHeaderGraphic, 0, 0);
			this.tableLayoutPanel3.Location = new System.Drawing.Point(138, 98);
			this.tableLayoutPanel3.Name = "tableLayoutPanel3";
			this.tableLayoutPanel3.RowCount = 1;
			this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 13.93939F));
			this.tableLayoutPanel3.Size = new System.Drawing.Size(223, 22);
			this.tableLayoutPanel3.TabIndex = 6;
			// 
			// lbWresPointers
			// 
			this.lbWresPointers.FormattingEnabled = true;
			this.lbWresPointers.Location = new System.Drawing.Point(6, 16);
			this.lbWresPointers.Name = "lbWresPointers";
			this.lbWresPointers.Size = new System.Drawing.Size(116, 134);
			this.lbWresPointers.TabIndex = 7;
			// 
			// buttonViewWrestler
			// 
			this.buttonViewWrestler.Location = new System.Drawing.Point(128, 16);
			this.buttonViewWrestler.Name = "buttonViewWrestler";
			this.buttonViewWrestler.Size = new System.Drawing.Size(89, 23);
			this.buttonViewWrestler.TabIndex = 8;
			this.buttonViewWrestler.Text = "&View Wrestler";
			this.buttonViewWrestler.UseVisualStyleBackColor = true;
			this.buttonViewWrestler.Click += new System.EventHandler(this.buttonViewWrestler_Click);
			// 
			// buttonMoveUp
			// 
			this.buttonMoveUp.Location = new System.Drawing.Point(128, 45);
			this.buttonMoveUp.Name = "buttonMoveUp";
			this.buttonMoveUp.Size = new System.Drawing.Size(89, 23);
			this.buttonMoveUp.TabIndex = 10;
			this.buttonMoveUp.Text = "Move &Up";
			this.buttonMoveUp.UseVisualStyleBackColor = true;
			this.buttonMoveUp.Click += new System.EventHandler(this.buttonMoveUp_Click);
			// 
			// buttonMoveDown
			// 
			this.buttonMoveDown.Location = new System.Drawing.Point(128, 74);
			this.buttonMoveDown.Name = "buttonMoveDown";
			this.buttonMoveDown.Size = new System.Drawing.Size(89, 23);
			this.buttonMoveDown.TabIndex = 11;
			this.buttonMoveDown.Text = "Move &Down";
			this.buttonMoveDown.UseVisualStyleBackColor = true;
			this.buttonMoveDown.Click += new System.EventHandler(this.buttonMoveDown_Click);
			// 
			// buttonSwitchGroup
			// 
			this.buttonSwitchGroup.Location = new System.Drawing.Point(128, 103);
			this.buttonSwitchGroup.Name = "buttonSwitchGroup";
			this.buttonSwitchGroup.Size = new System.Drawing.Size(89, 23);
			this.buttonSwitchGroup.TabIndex = 12;
			this.buttonSwitchGroup.Text = "Switch &Group";
			this.buttonSwitchGroup.UseVisualStyleBackColor = true;
			this.buttonSwitchGroup.Click += new System.EventHandler(this.buttonSwitchGroup_Click);
			// 
			// buttonSwapWres
			// 
			this.buttonSwapWres.Location = new System.Drawing.Point(128, 132);
			this.buttonSwapWres.Name = "buttonSwapWres";
			this.buttonSwapWres.Size = new System.Drawing.Size(89, 23);
			this.buttonSwapWres.TabIndex = 17;
			this.buttonSwapWres.Text = "Swa&p Wrestler";
			this.buttonSwapWres.UseVisualStyleBackColor = true;
			this.buttonSwapWres.Click += new System.EventHandler(this.buttonSwapWres_Click);
			// 
			// gbWrestlers
			// 
			this.gbWrestlers.Controls.Add(this.lbWresPointers);
			this.gbWrestlers.Controls.Add(this.buttonSwapWres);
			this.gbWrestlers.Controls.Add(this.buttonSwitchGroup);
			this.gbWrestlers.Controls.Add(this.buttonViewWrestler);
			this.gbWrestlers.Controls.Add(this.buttonMoveUp);
			this.gbWrestlers.Controls.Add(this.buttonMoveDown);
			this.gbWrestlers.Location = new System.Drawing.Point(138, 126);
			this.gbWrestlers.Name = "gbWrestlers";
			this.gbWrestlers.Size = new System.Drawing.Size(223, 166);
			this.gbWrestlers.TabIndex = 18;
			this.gbWrestlers.TabStop = false;
			this.gbWrestlers.Text = "Wrestlers";
			// 
			// buttonOK
			// 
			this.buttonOK.Location = new System.Drawing.Point(205, 298);
			this.buttonOK.Name = "buttonOK";
			this.buttonOK.Size = new System.Drawing.Size(75, 23);
			this.buttonOK.TabIndex = 19;
			this.buttonOK.Text = "&OK";
			this.buttonOK.UseVisualStyleBackColor = true;
			this.buttonOK.Click += new System.EventHandler(this.buttonOK_Click);
			// 
			// buttonCancel
			// 
			this.buttonCancel.Location = new System.Drawing.Point(286, 298);
			this.buttonCancel.Name = "buttonCancel";
			this.buttonCancel.Size = new System.Drawing.Size(75, 23);
			this.buttonCancel.TabIndex = 20;
			this.buttonCancel.Text = "&Cancel";
			this.buttonCancel.UseVisualStyleBackColor = true;
			this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
			// 
			// StableDefs_Revenge
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(373, 333);
			this.Controls.Add(this.buttonCancel);
			this.Controls.Add(this.buttonOK);
			this.Controls.Add(this.gbWrestlers);
			this.Controls.Add(this.tableLayoutPanel3);
			this.Controls.Add(this.tableLayoutPanel1);
			this.Controls.Add(this.gbStables);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "StableDefs_Revenge";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "Stable Definitions";
			this.tableLayoutPanel1.ResumeLayout(false);
			this.tableLayoutPanel1.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.pbHeaderGraphic)).EndInit();
			this.gbStables.ResumeLayout(false);
			this.tableLayoutPanel3.ResumeLayout(false);
			this.gbWrestlers.ResumeLayout(false);
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.ListBox lbStables;
		private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
		private System.Windows.Forms.Label labelWresDefPointer;
		private System.Windows.Forms.Label labelNumWrestlers;
		private System.Windows.Forms.Label labelHeader;
		private System.Windows.Forms.TextBox tbWrestlerDefPointer;
		private System.Windows.Forms.TextBox tbNumWrestlers;
		private System.Windows.Forms.TextBox tbHeaderGraphic;
		private System.Windows.Forms.PictureBox pbHeaderGraphic;
		private System.Windows.Forms.GroupBox gbStables;
		private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
		private System.Windows.Forms.ListBox lbWresPointers;
		private System.Windows.Forms.Button buttonViewWrestler;
		private System.Windows.Forms.Button buttonMoveUp;
		private System.Windows.Forms.Button buttonMoveDown;
		private System.Windows.Forms.Button buttonSwitchGroup;
		private System.Windows.Forms.Button buttonSwapWres;
		private System.Windows.Forms.GroupBox gbWrestlers;
		private System.Windows.Forms.Button buttonOK;
		private System.Windows.Forms.Button buttonCancel;
	}
}