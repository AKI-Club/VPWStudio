
namespace VPWStudio.Editors
{
	partial class StableDefs_Early
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
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.lbStables = new System.Windows.Forms.ListBox();
			this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
			this.tbWrestlerCount = new System.Windows.Forms.TextBox();
			this.tbChampTextPointer = new System.Windows.Forms.TextBox();
			this.tbChampionshipCount = new System.Windows.Forms.TextBox();
			this.label1 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.groupBox2 = new System.Windows.Forms.GroupBox();
			this.buttonSwapWrestler = new System.Windows.Forms.Button();
			this.buttonSwitchGroup = new System.Windows.Forms.Button();
			this.buttonMoveDown = new System.Windows.Forms.Button();
			this.buttonMoveUp = new System.Windows.Forms.Button();
			this.buttonViewWrestler = new System.Windows.Forms.Button();
			this.lbWresPointers = new System.Windows.Forms.ListBox();
			this.buttonOK = new System.Windows.Forms.Button();
			this.buttonCancel = new System.Windows.Forms.Button();
			this.label4 = new System.Windows.Forms.Label();
			this.tbWrestlerDefPointer = new System.Windows.Forms.TextBox();
			this.groupBox1.SuspendLayout();
			this.tableLayoutPanel1.SuspendLayout();
			this.groupBox2.SuspendLayout();
			this.SuspendLayout();
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.lbStables);
			this.groupBox1.Location = new System.Drawing.Point(12, 12);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(127, 308);
			this.groupBox1.TabIndex = 0;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "&Stables";
			// 
			// lbStables
			// 
			this.lbStables.FormattingEnabled = true;
			this.lbStables.Location = new System.Drawing.Point(6, 19);
			this.lbStables.Name = "lbStables";
			this.lbStables.Size = new System.Drawing.Size(115, 277);
			this.lbStables.TabIndex = 0;
			this.lbStables.SelectedIndexChanged += new System.EventHandler(this.lbStables_SelectedIndexChanged);
			// 
			// tableLayoutPanel1
			// 
			this.tableLayoutPanel1.ColumnCount = 2;
			this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
			this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
			this.tableLayoutPanel1.Controls.Add(this.label3, 0, 3);
			this.tableLayoutPanel1.Controls.Add(this.tbChampionshipCount, 1, 3);
			this.tableLayoutPanel1.Controls.Add(this.label2, 0, 2);
			this.tableLayoutPanel1.Controls.Add(this.tbChampTextPointer, 1, 2);
			this.tableLayoutPanel1.Controls.Add(this.tbWrestlerCount, 1, 1);
			this.tableLayoutPanel1.Controls.Add(this.label1, 0, 1);
			this.tableLayoutPanel1.Controls.Add(this.label4, 0, 0);
			this.tableLayoutPanel1.Controls.Add(this.tbWrestlerDefPointer, 1, 0);
			this.tableLayoutPanel1.Location = new System.Drawing.Point(145, 12);
			this.tableLayoutPanel1.Name = "tableLayoutPanel1";
			this.tableLayoutPanel1.RowCount = 4;
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
			this.tableLayoutPanel1.Size = new System.Drawing.Size(247, 109);
			this.tableLayoutPanel1.TabIndex = 1;
			// 
			// tbWrestlerCount
			// 
			this.tbWrestlerCount.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
			this.tbWrestlerCount.Location = new System.Drawing.Point(126, 30);
			this.tbWrestlerCount.Name = "tbWrestlerCount";
			this.tbWrestlerCount.ReadOnly = true;
			this.tbWrestlerCount.Size = new System.Drawing.Size(118, 20);
			this.tbWrestlerCount.TabIndex = 0;
			// 
			// tbChampTextPointer
			// 
			this.tbChampTextPointer.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
			this.tbChampTextPointer.Location = new System.Drawing.Point(126, 57);
			this.tbChampTextPointer.Name = "tbChampTextPointer";
			this.tbChampTextPointer.ReadOnly = true;
			this.tbChampTextPointer.Size = new System.Drawing.Size(118, 20);
			this.tbChampTextPointer.TabIndex = 1;
			// 
			// tbChampionshipCount
			// 
			this.tbChampionshipCount.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
			this.tbChampionshipCount.Location = new System.Drawing.Point(126, 85);
			this.tbChampionshipCount.Name = "tbChampionshipCount";
			this.tbChampionshipCount.ReadOnly = true;
			this.tbChampionshipCount.Size = new System.Drawing.Size(118, 20);
			this.tbChampionshipCount.TabIndex = 2;
			// 
			// label1
			// 
			this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(3, 34);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(117, 13);
			this.label1.TabIndex = 3;
			this.label1.Text = "Wrestler Count";
			// 
			// label2
			// 
			this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(3, 54);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(117, 26);
			this.label2.TabIndex = 4;
			this.label2.Text = "Championship Text Pointer";
			// 
			// label3
			// 
			this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(3, 88);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(117, 13);
			this.label3.TabIndex = 5;
			this.label3.Text = "Championship Count";
			// 
			// groupBox2
			// 
			this.groupBox2.Controls.Add(this.buttonSwapWrestler);
			this.groupBox2.Controls.Add(this.buttonSwitchGroup);
			this.groupBox2.Controls.Add(this.buttonMoveDown);
			this.groupBox2.Controls.Add(this.buttonMoveUp);
			this.groupBox2.Controls.Add(this.buttonViewWrestler);
			this.groupBox2.Controls.Add(this.lbWresPointers);
			this.groupBox2.Location = new System.Drawing.Point(150, 127);
			this.groupBox2.Name = "groupBox2";
			this.groupBox2.Size = new System.Drawing.Size(242, 193);
			this.groupBox2.TabIndex = 2;
			this.groupBox2.TabStop = false;
			this.groupBox2.Text = "&Wrestlers";
			// 
			// buttonSwapWrestler
			// 
			this.buttonSwapWrestler.Location = new System.Drawing.Point(117, 135);
			this.buttonSwapWrestler.Name = "buttonSwapWrestler";
			this.buttonSwapWrestler.Size = new System.Drawing.Size(119, 23);
			this.buttonSwapWrestler.TabIndex = 5;
			this.buttonSwapWrestler.Text = "Swap Wrestler";
			this.buttonSwapWrestler.UseVisualStyleBackColor = true;
			this.buttonSwapWrestler.Click += new System.EventHandler(this.buttonSwapWrestler_Click);
			// 
			// buttonSwitchGroup
			// 
			this.buttonSwitchGroup.Location = new System.Drawing.Point(117, 106);
			this.buttonSwitchGroup.Name = "buttonSwitchGroup";
			this.buttonSwitchGroup.Size = new System.Drawing.Size(119, 23);
			this.buttonSwitchGroup.TabIndex = 4;
			this.buttonSwitchGroup.Text = "Switch Group";
			this.buttonSwitchGroup.UseVisualStyleBackColor = true;
			this.buttonSwitchGroup.Click += new System.EventHandler(this.buttonSwitchGroup_Click);
			// 
			// buttonMoveDown
			// 
			this.buttonMoveDown.Location = new System.Drawing.Point(117, 77);
			this.buttonMoveDown.Name = "buttonMoveDown";
			this.buttonMoveDown.Size = new System.Drawing.Size(119, 23);
			this.buttonMoveDown.TabIndex = 3;
			this.buttonMoveDown.Text = "Move Down";
			this.buttonMoveDown.UseVisualStyleBackColor = true;
			this.buttonMoveDown.Click += new System.EventHandler(this.buttonMoveDown_Click);
			// 
			// buttonMoveUp
			// 
			this.buttonMoveUp.Location = new System.Drawing.Point(117, 48);
			this.buttonMoveUp.Name = "buttonMoveUp";
			this.buttonMoveUp.Size = new System.Drawing.Size(119, 23);
			this.buttonMoveUp.TabIndex = 2;
			this.buttonMoveUp.Text = "Move Up";
			this.buttonMoveUp.UseVisualStyleBackColor = true;
			this.buttonMoveUp.Click += new System.EventHandler(this.buttonMoveUp_Click);
			// 
			// buttonViewWrestler
			// 
			this.buttonViewWrestler.Location = new System.Drawing.Point(117, 19);
			this.buttonViewWrestler.Name = "buttonViewWrestler";
			this.buttonViewWrestler.Size = new System.Drawing.Size(119, 23);
			this.buttonViewWrestler.TabIndex = 1;
			this.buttonViewWrestler.Text = "View Wrestler";
			this.buttonViewWrestler.UseVisualStyleBackColor = true;
			this.buttonViewWrestler.Click += new System.EventHandler(this.buttonViewWrestler_Click);
			// 
			// lbWresPointers
			// 
			this.lbWresPointers.FormattingEnabled = true;
			this.lbWresPointers.Location = new System.Drawing.Point(6, 19);
			this.lbWresPointers.Name = "lbWresPointers";
			this.lbWresPointers.Size = new System.Drawing.Size(105, 160);
			this.lbWresPointers.TabIndex = 0;
			// 
			// buttonOK
			// 
			this.buttonOK.Location = new System.Drawing.Point(236, 326);
			this.buttonOK.Name = "buttonOK";
			this.buttonOK.Size = new System.Drawing.Size(75, 23);
			this.buttonOK.TabIndex = 3;
			this.buttonOK.Text = "&OK";
			this.buttonOK.UseVisualStyleBackColor = true;
			this.buttonOK.Click += new System.EventHandler(this.buttonOK_Click);
			// 
			// buttonCancel
			// 
			this.buttonCancel.Location = new System.Drawing.Point(317, 326);
			this.buttonCancel.Name = "buttonCancel";
			this.buttonCancel.Size = new System.Drawing.Size(75, 23);
			this.buttonCancel.TabIndex = 4;
			this.buttonCancel.Text = "&Cancel";
			this.buttonCancel.UseVisualStyleBackColor = true;
			this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
			// 
			// label4
			// 
			this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
			this.label4.AutoSize = true;
			this.label4.Location = new System.Drawing.Point(3, 7);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(117, 13);
			this.label4.TabIndex = 6;
			this.label4.Text = "Wrestler Definitions";
			// 
			// tbWrestlerDefPointer
			// 
			this.tbWrestlerDefPointer.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
			this.tbWrestlerDefPointer.Location = new System.Drawing.Point(126, 3);
			this.tbWrestlerDefPointer.Name = "tbWrestlerDefPointer";
			this.tbWrestlerDefPointer.ReadOnly = true;
			this.tbWrestlerDefPointer.Size = new System.Drawing.Size(118, 20);
			this.tbWrestlerDefPointer.TabIndex = 7;
			// 
			// StableDefs_Early
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(404, 361);
			this.Controls.Add(this.buttonCancel);
			this.Controls.Add(this.buttonOK);
			this.Controls.Add(this.groupBox2);
			this.Controls.Add(this.tableLayoutPanel1);
			this.Controls.Add(this.groupBox1);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "StableDefs_Early";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "Stable Definitions";
			this.groupBox1.ResumeLayout(false);
			this.tableLayoutPanel1.ResumeLayout(false);
			this.tableLayoutPanel1.PerformLayout();
			this.groupBox2.ResumeLayout(false);
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
		private System.Windows.Forms.GroupBox groupBox2;
		private System.Windows.Forms.Button buttonOK;
		private System.Windows.Forms.Button buttonCancel;
		private System.Windows.Forms.ListBox lbStables;
		private System.Windows.Forms.ListBox lbWresPointers;
		private System.Windows.Forms.TextBox tbWrestlerCount;
		private System.Windows.Forms.TextBox tbChampTextPointer;
		private System.Windows.Forms.TextBox tbChampionshipCount;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Button buttonSwitchGroup;
		private System.Windows.Forms.Button buttonMoveDown;
		private System.Windows.Forms.Button buttonMoveUp;
		private System.Windows.Forms.Button buttonViewWrestler;
		private System.Windows.Forms.Button buttonSwapWrestler;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.TextBox tbWrestlerDefPointer;
	}
}