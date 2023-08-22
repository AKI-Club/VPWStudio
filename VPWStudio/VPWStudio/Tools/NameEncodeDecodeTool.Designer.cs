namespace VPWStudio
{
	partial class NameEncodeDecodeTool
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
			this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
			this.labelFull = new System.Windows.Forms.Label();
			this.labelLong = new System.Windows.Forms.Label();
			this.labelShort = new System.Windows.Forms.Label();
			this.tbFull = new System.Windows.Forms.TextBox();
			this.tbLong = new System.Windows.Forms.TextBox();
			this.tbShort = new System.Windows.Forms.TextBox();
			this.buttonEncode = new System.Windows.Forms.Button();
			this.buttonDecode = new System.Windows.Forms.Button();
			this.lblInfo = new System.Windows.Forms.Label();
			this.tableLayoutPanel1.SuspendLayout();
			this.SuspendLayout();
			// 
			// tableLayoutPanel1
			// 
			this.tableLayoutPanel1.ColumnCount = 2;
			this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 30F));
			this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 70F));
			this.tableLayoutPanel1.Controls.Add(this.labelFull, 0, 0);
			this.tableLayoutPanel1.Controls.Add(this.labelLong, 0, 1);
			this.tableLayoutPanel1.Controls.Add(this.labelShort, 0, 2);
			this.tableLayoutPanel1.Controls.Add(this.tbFull, 1, 0);
			this.tableLayoutPanel1.Controls.Add(this.tbLong, 1, 1);
			this.tableLayoutPanel1.Controls.Add(this.tbShort, 1, 2);
			this.tableLayoutPanel1.Location = new System.Drawing.Point(12, 12);
			this.tableLayoutPanel1.Name = "tableLayoutPanel1";
			this.tableLayoutPanel1.RowCount = 3;
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
			this.tableLayoutPanel1.Size = new System.Drawing.Size(300, 100);
			this.tableLayoutPanel1.TabIndex = 1;
			// 
			// labelFull
			// 
			this.labelFull.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
			this.labelFull.AutoSize = true;
			this.labelFull.Location = new System.Drawing.Point(3, 10);
			this.labelFull.Name = "labelFull";
			this.labelFull.Size = new System.Drawing.Size(84, 13);
			this.labelFull.TabIndex = 0;
			this.labelFull.Text = "&Full";
			// 
			// labelLong
			// 
			this.labelLong.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
			this.labelLong.AutoSize = true;
			this.labelLong.Location = new System.Drawing.Point(3, 43);
			this.labelLong.Name = "labelLong";
			this.labelLong.Size = new System.Drawing.Size(84, 13);
			this.labelLong.TabIndex = 1;
			this.labelLong.Text = "&Long";
			// 
			// labelShort
			// 
			this.labelShort.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
			this.labelShort.AutoSize = true;
			this.labelShort.Location = new System.Drawing.Point(3, 76);
			this.labelShort.Name = "labelShort";
			this.labelShort.Size = new System.Drawing.Size(84, 13);
			this.labelShort.TabIndex = 2;
			this.labelShort.Text = "&Short";
			// 
			// tbFull
			// 
			this.tbFull.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
			this.tbFull.Location = new System.Drawing.Point(93, 6);
			this.tbFull.Name = "tbFull";
			this.tbFull.Size = new System.Drawing.Size(204, 20);
			this.tbFull.TabIndex = 0;
			// 
			// tbLong
			// 
			this.tbLong.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
			this.tbLong.Location = new System.Drawing.Point(93, 39);
			this.tbLong.Name = "tbLong";
			this.tbLong.Size = new System.Drawing.Size(204, 20);
			this.tbLong.TabIndex = 1;
			// 
			// tbShort
			// 
			this.tbShort.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
			this.tbShort.Location = new System.Drawing.Point(93, 73);
			this.tbShort.Name = "tbShort";
			this.tbShort.Size = new System.Drawing.Size(204, 20);
			this.tbShort.TabIndex = 2;
			// 
			// buttonEncode
			// 
			this.buttonEncode.Location = new System.Drawing.Point(12, 131);
			this.buttonEncode.Name = "buttonEncode";
			this.buttonEncode.Size = new System.Drawing.Size(120, 23);
			this.buttonEncode.TabIndex = 3;
			this.buttonEncode.Text = "&Encode Long/Short";
			this.buttonEncode.UseVisualStyleBackColor = true;
			this.buttonEncode.Click += new System.EventHandler(this.buttonEncode_Click);
			// 
			// buttonDecode
			// 
			this.buttonDecode.Location = new System.Drawing.Point(222, 131);
			this.buttonDecode.Name = "buttonDecode";
			this.buttonDecode.Size = new System.Drawing.Size(90, 23);
			this.buttonDecode.TabIndex = 4;
			this.buttonDecode.Text = "&Decode Full";
			this.buttonDecode.UseVisualStyleBackColor = true;
			this.buttonDecode.Click += new System.EventHandler(this.buttonDecode_Click);
			// 
			// lblInfo
			// 
			this.lblInfo.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.lblInfo.AutoSize = true;
			this.lblInfo.Location = new System.Drawing.Point(12, 115);
			this.lblInfo.Name = "lblInfo";
			this.lblInfo.Size = new System.Drawing.Size(276, 13);
			this.lblInfo.TabIndex = 5;
			this.lblInfo.Text = "Legend: <Short and Long>; {Short only}; results may vary";
			this.lblInfo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// NameEncodeDecodeTool
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(324, 166);
			this.Controls.Add(this.lblInfo);
			this.Controls.Add(this.buttonDecode);
			this.Controls.Add(this.buttonEncode);
			this.Controls.Add(this.tableLayoutPanel1);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.KeyPreview = true;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "NameEncodeDecodeTool";
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "Name Encode/Decode Tool (\"Ned\")";
			this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.NameEncodeDecodeTool_KeyDown);
			this.tableLayoutPanel1.ResumeLayout(false);
			this.tableLayoutPanel1.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion
		private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
		private System.Windows.Forms.Label labelFull;
		private System.Windows.Forms.Label labelLong;
		private System.Windows.Forms.Label labelShort;
		private System.Windows.Forms.TextBox tbFull;
		private System.Windows.Forms.TextBox tbLong;
		private System.Windows.Forms.TextBox tbShort;
		private System.Windows.Forms.Button buttonEncode;
		private System.Windows.Forms.Button buttonDecode;
		private System.Windows.Forms.Label lblInfo;
	}
}