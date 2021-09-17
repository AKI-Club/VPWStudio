
namespace VPWStudio.Editors.VPW64
{
	partial class StableDefs_VPW64
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
			this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
			this.groupBox2 = new System.Windows.Forms.GroupBox();
			this.buttonOK = new System.Windows.Forms.Button();
			this.buttonCancel = new System.Windows.Forms.Button();
			this.lbStables = new System.Windows.Forms.ListBox();
			this.lbWresPointers = new System.Windows.Forms.ListBox();
			this.tbWrestlerCount = new System.Windows.Forms.TextBox();
			this.tbChampTextPointer = new System.Windows.Forms.TextBox();
			this.tbChampionshipCount = new System.Windows.Forms.TextBox();
			this.label1 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
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
			this.groupBox1.Size = new System.Drawing.Size(127, 268);
			this.groupBox1.TabIndex = 0;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "&Stables";
			// 
			// tableLayoutPanel1
			// 
			this.tableLayoutPanel1.ColumnCount = 2;
			this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
			this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
			this.tableLayoutPanel1.Controls.Add(this.tbWrestlerCount, 1, 0);
			this.tableLayoutPanel1.Controls.Add(this.tbChampTextPointer, 1, 1);
			this.tableLayoutPanel1.Controls.Add(this.tbChampionshipCount, 1, 2);
			this.tableLayoutPanel1.Controls.Add(this.label1, 0, 0);
			this.tableLayoutPanel1.Controls.Add(this.label2, 0, 1);
			this.tableLayoutPanel1.Controls.Add(this.label3, 0, 2);
			this.tableLayoutPanel1.Location = new System.Drawing.Point(145, 12);
			this.tableLayoutPanel1.Name = "tableLayoutPanel1";
			this.tableLayoutPanel1.RowCount = 3;
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
			this.tableLayoutPanel1.Size = new System.Drawing.Size(247, 100);
			this.tableLayoutPanel1.TabIndex = 1;
			// 
			// groupBox2
			// 
			this.groupBox2.Controls.Add(this.lbWresPointers);
			this.groupBox2.Location = new System.Drawing.Point(150, 127);
			this.groupBox2.Name = "groupBox2";
			this.groupBox2.Size = new System.Drawing.Size(242, 153);
			this.groupBox2.TabIndex = 2;
			this.groupBox2.TabStop = false;
			this.groupBox2.Text = "&Wrestlers";
			// 
			// buttonOK
			// 
			this.buttonOK.Location = new System.Drawing.Point(236, 286);
			this.buttonOK.Name = "buttonOK";
			this.buttonOK.Size = new System.Drawing.Size(75, 23);
			this.buttonOK.TabIndex = 3;
			this.buttonOK.Text = "&OK";
			this.buttonOK.UseVisualStyleBackColor = true;
			this.buttonOK.Click += new System.EventHandler(this.buttonOK_Click);
			// 
			// buttonCancel
			// 
			this.buttonCancel.Location = new System.Drawing.Point(317, 286);
			this.buttonCancel.Name = "buttonCancel";
			this.buttonCancel.Size = new System.Drawing.Size(75, 23);
			this.buttonCancel.TabIndex = 4;
			this.buttonCancel.Text = "&Cancel";
			this.buttonCancel.UseVisualStyleBackColor = true;
			this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
			// 
			// lbStables
			// 
			this.lbStables.FormattingEnabled = true;
			this.lbStables.Location = new System.Drawing.Point(6, 19);
			this.lbStables.Name = "lbStables";
			this.lbStables.Size = new System.Drawing.Size(115, 238);
			this.lbStables.TabIndex = 0;
			this.lbStables.SelectedIndexChanged += new System.EventHandler(this.lbStables_SelectedIndexChanged);
			// 
			// lbWresPointers
			// 
			this.lbWresPointers.FormattingEnabled = true;
			this.lbWresPointers.Location = new System.Drawing.Point(6, 19);
			this.lbWresPointers.Name = "lbWresPointers";
			this.lbWresPointers.Size = new System.Drawing.Size(105, 121);
			this.lbWresPointers.TabIndex = 0;
			// 
			// tbWrestlerCount
			// 
			this.tbWrestlerCount.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
			this.tbWrestlerCount.Location = new System.Drawing.Point(126, 6);
			this.tbWrestlerCount.Name = "tbWrestlerCount";
			this.tbWrestlerCount.ReadOnly = true;
			this.tbWrestlerCount.Size = new System.Drawing.Size(118, 20);
			this.tbWrestlerCount.TabIndex = 0;
			// 
			// tbChampTextPointer
			// 
			this.tbChampTextPointer.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
			this.tbChampTextPointer.Location = new System.Drawing.Point(126, 39);
			this.tbChampTextPointer.Name = "tbChampTextPointer";
			this.tbChampTextPointer.ReadOnly = true;
			this.tbChampTextPointer.Size = new System.Drawing.Size(118, 20);
			this.tbChampTextPointer.TabIndex = 1;
			// 
			// tbChampionshipCount
			// 
			this.tbChampionshipCount.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
			this.tbChampionshipCount.Location = new System.Drawing.Point(126, 73);
			this.tbChampionshipCount.Name = "tbChampionshipCount";
			this.tbChampionshipCount.ReadOnly = true;
			this.tbChampionshipCount.Size = new System.Drawing.Size(118, 20);
			this.tbChampionshipCount.TabIndex = 2;
			// 
			// label1
			// 
			this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(3, 10);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(117, 13);
			this.label1.TabIndex = 3;
			this.label1.Text = "Wrestler Count";
			// 
			// label2
			// 
			this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(3, 36);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(117, 26);
			this.label2.TabIndex = 4;
			this.label2.Text = "Championship Text Pointer";
			// 
			// label3
			// 
			this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(3, 76);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(117, 13);
			this.label3.TabIndex = 5;
			this.label3.Text = "Championship Count";
			// 
			// StableDefs_VPW64
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(404, 321);
			this.Controls.Add(this.buttonCancel);
			this.Controls.Add(this.buttonOK);
			this.Controls.Add(this.groupBox2);
			this.Controls.Add(this.tableLayoutPanel1);
			this.Controls.Add(this.groupBox1);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "StableDefs_VPW64";
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
	}
}