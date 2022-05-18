namespace VPWStudio
{
	partial class StableDefParseTest
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
			this.tbInput = new System.Windows.Forms.TextBox();
			this.labelInput = new System.Windows.Forms.Label();
			this.buttonParse = new System.Windows.Forms.Button();
			this.gbOutput = new System.Windows.Forms.GroupBox();
			this.tbOutput = new System.Windows.Forms.TextBox();
			this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
			this.lblGameType = new System.Windows.Forms.Label();
			this.cbGameType = new System.Windows.Forms.ComboBox();
			this.gbOutput.SuspendLayout();
			this.tableLayoutPanel1.SuspendLayout();
			this.SuspendLayout();
			// 
			// tbInput
			// 
			this.tbInput.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
			this.tbInput.Location = new System.Drawing.Point(90, 31);
			this.tbInput.Name = "tbInput";
			this.tbInput.Size = new System.Drawing.Size(197, 20);
			this.tbInput.TabIndex = 0;
			// 
			// labelInput
			// 
			this.labelInput.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
			this.labelInput.AutoSize = true;
			this.labelInput.Location = new System.Drawing.Point(3, 34);
			this.labelInput.Name = "labelInput";
			this.labelInput.Size = new System.Drawing.Size(81, 13);
			this.labelInput.TabIndex = 1;
			this.labelInput.Text = "&Input";
			// 
			// buttonParse
			// 
			this.buttonParse.Location = new System.Drawing.Point(12, 71);
			this.buttonParse.Name = "buttonParse";
			this.buttonParse.Size = new System.Drawing.Size(290, 23);
			this.buttonParse.TabIndex = 2;
			this.buttonParse.Text = "&Parse";
			this.buttonParse.UseVisualStyleBackColor = true;
			this.buttonParse.Click += new System.EventHandler(this.buttonParse_Click);
			// 
			// gbOutput
			// 
			this.gbOutput.Controls.Add(this.tbOutput);
			this.gbOutput.Location = new System.Drawing.Point(12, 100);
			this.gbOutput.Name = "gbOutput";
			this.gbOutput.Size = new System.Drawing.Size(290, 163);
			this.gbOutput.TabIndex = 3;
			this.gbOutput.TabStop = false;
			this.gbOutput.Text = "Output";
			// 
			// tbOutput
			// 
			this.tbOutput.Location = new System.Drawing.Point(6, 19);
			this.tbOutput.Multiline = true;
			this.tbOutput.Name = "tbOutput";
			this.tbOutput.ReadOnly = true;
			this.tbOutput.Size = new System.Drawing.Size(278, 138);
			this.tbOutput.TabIndex = 0;
			// 
			// tableLayoutPanel1
			// 
			this.tableLayoutPanel1.ColumnCount = 2;
			this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 30F));
			this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 70F));
			this.tableLayoutPanel1.Controls.Add(this.labelInput, 0, 1);
			this.tableLayoutPanel1.Controls.Add(this.tbInput, 1, 1);
			this.tableLayoutPanel1.Controls.Add(this.lblGameType, 0, 0);
			this.tableLayoutPanel1.Controls.Add(this.cbGameType, 1, 0);
			this.tableLayoutPanel1.Location = new System.Drawing.Point(12, 10);
			this.tableLayoutPanel1.Name = "tableLayoutPanel1";
			this.tableLayoutPanel1.RowCount = 2;
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
			this.tableLayoutPanel1.Size = new System.Drawing.Size(290, 55);
			this.tableLayoutPanel1.TabIndex = 4;
			// 
			// lblGameType
			// 
			this.lblGameType.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
			this.lblGameType.AutoSize = true;
			this.lblGameType.Location = new System.Drawing.Point(3, 7);
			this.lblGameType.Name = "lblGameType";
			this.lblGameType.Size = new System.Drawing.Size(81, 13);
			this.lblGameType.TabIndex = 2;
			this.lblGameType.Text = "&Game Type";
			// 
			// cbGameType
			// 
			this.cbGameType.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
			this.cbGameType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cbGameType.FormattingEnabled = true;
			this.cbGameType.Items.AddRange(new object[] {
            "Revenge",
            "WM2K",
            "VPW2",
            "NoMercy"});
			this.cbGameType.Location = new System.Drawing.Point(90, 3);
			this.cbGameType.Name = "cbGameType";
			this.cbGameType.Size = new System.Drawing.Size(197, 21);
			this.cbGameType.TabIndex = 3;
			// 
			// StableDefParseTest
			// 
			this.AcceptButton = this.buttonParse;
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(314, 275);
			this.Controls.Add(this.tableLayoutPanel1);
			this.Controls.Add(this.gbOutput);
			this.Controls.Add(this.buttonParse);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.KeyPreview = true;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "StableDefParseTest";
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "StableDefParseTest";
			this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.StableDefParseTest_KeyDown);
			this.gbOutput.ResumeLayout(false);
			this.gbOutput.PerformLayout();
			this.tableLayoutPanel1.ResumeLayout(false);
			this.tableLayoutPanel1.PerformLayout();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.TextBox tbInput;
		private System.Windows.Forms.Label labelInput;
		private System.Windows.Forms.Button buttonParse;
		private System.Windows.Forms.GroupBox gbOutput;
		private System.Windows.Forms.TextBox tbOutput;
		private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
		private System.Windows.Forms.Label lblGameType;
		private System.Windows.Forms.ComboBox cbGameType;
	}
}