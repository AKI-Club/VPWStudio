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
			this.tbStableName = new System.Windows.Forms.TextBox();
			this.labelStableName = new System.Windows.Forms.Label();
			this.labelWresDefPointer = new System.Windows.Forms.Label();
			this.tbWrestlerDefPointer = new System.Windows.Forms.TextBox();
			this.lbWresID2s = new System.Windows.Forms.ListBox();
			this.label1 = new System.Windows.Forms.Label();
			this.tbNumWrestlers = new System.Windows.Forms.TextBox();
			this.gbStables.SuspendLayout();
			this.tableLayoutPanel1.SuspendLayout();
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
			this.gbStables.Size = new System.Drawing.Size(120, 249);
			this.gbStables.TabIndex = 4;
			this.gbStables.TabStop = false;
			this.gbStables.Text = "Stables";
			// 
			// tableLayoutPanel1
			// 
			this.tableLayoutPanel1.ColumnCount = 2;
			this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 52.73632F));
			this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 47.26368F));
			this.tableLayoutPanel1.Controls.Add(this.labelWresDefPointer, 0, 0);
			this.tableLayoutPanel1.Controls.Add(this.tbWrestlerDefPointer, 1, 0);
			this.tableLayoutPanel1.Controls.Add(this.labelStableName, 0, 1);
			this.tableLayoutPanel1.Controls.Add(this.tbStableName, 1, 1);
			this.tableLayoutPanel1.Controls.Add(this.tbNumWrestlers, 1, 2);
			this.tableLayoutPanel1.Controls.Add(this.label1, 0, 2);
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
			this.tbStableName.Location = new System.Drawing.Point(109, 29);
			this.tbStableName.Name = "tbStableName";
			this.tbStableName.ReadOnly = true;
			this.tbStableName.Size = new System.Drawing.Size(89, 20);
			this.tbStableName.TabIndex = 5;
			// 
			// labelStableName
			// 
			this.labelStableName.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
			this.labelStableName.AutoSize = true;
			this.labelStableName.Location = new System.Drawing.Point(3, 32);
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
			// tbWrestlerDefPointer
			// 
			this.tbWrestlerDefPointer.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
			this.tbWrestlerDefPointer.Location = new System.Drawing.Point(109, 3);
			this.tbWrestlerDefPointer.Name = "tbWrestlerDefPointer";
			this.tbWrestlerDefPointer.ReadOnly = true;
			this.tbWrestlerDefPointer.Size = new System.Drawing.Size(89, 20);
			this.tbWrestlerDefPointer.TabIndex = 3;
			// 
			// lbWresID2s
			// 
			this.lbWresID2s.FormattingEnabled = true;
			this.lbWresID2s.Location = new System.Drawing.Point(138, 127);
			this.lbWresID2s.Name = "lbWresID2s";
			this.lbWresID2s.Size = new System.Drawing.Size(106, 134);
			this.lbWresID2s.TabIndex = 8;
			// 
			// label1
			// 
			this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(3, 59);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(100, 13);
			this.label1.TabIndex = 6;
			this.label1.Text = "Num. Wrestlers";
			// 
			// tbNumWrestlers
			// 
			this.tbNumWrestlers.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
			this.tbNumWrestlers.Location = new System.Drawing.Point(109, 56);
			this.tbNumWrestlers.Name = "tbNumWrestlers";
			this.tbNumWrestlers.ReadOnly = true;
			this.tbNumWrestlers.Size = new System.Drawing.Size(89, 20);
			this.tbNumWrestlers.TabIndex = 7;
			// 
			// StableDefs_WM2K
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(349, 273);
			this.Controls.Add(this.lbWresID2s);
			this.Controls.Add(this.tableLayoutPanel1);
			this.Controls.Add(this.gbStables);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.MaximizeBox = false;
			this.Name = "StableDefs_WM2K";
			this.Text = "Stable Definitions";
			this.gbStables.ResumeLayout(false);
			this.tableLayoutPanel1.ResumeLayout(false);
			this.tableLayoutPanel1.PerformLayout();
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
		private System.Windows.Forms.Label label1;
	}
}