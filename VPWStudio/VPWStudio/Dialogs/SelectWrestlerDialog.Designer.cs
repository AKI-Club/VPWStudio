
namespace VPWStudio
{
	partial class SelectWrestlerDialog
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
			this.btnOK = new System.Windows.Forms.Button();
			this.btnCancel = new System.Windows.Forms.Button();
			this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
			this.lblWrestler = new System.Windows.Forms.Label();
			this.cbWrestlers = new System.Windows.Forms.ComboBox();
			this.tableLayoutPanel1.SuspendLayout();
			this.SuspendLayout();
			// 
			// btnOK
			// 
			this.btnOK.Location = new System.Drawing.Point(216, 54);
			this.btnOK.Name = "btnOK";
			this.btnOK.Size = new System.Drawing.Size(75, 23);
			this.btnOK.TabIndex = 2;
			this.btnOK.Text = "&OK";
			this.btnOK.UseVisualStyleBackColor = true;
			this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
			// 
			// btnCancel
			// 
			this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.btnCancel.Location = new System.Drawing.Point(297, 54);
			this.btnCancel.Name = "btnCancel";
			this.btnCancel.Size = new System.Drawing.Size(75, 23);
			this.btnCancel.TabIndex = 3;
			this.btnCancel.Text = "&Cancel";
			this.btnCancel.UseVisualStyleBackColor = true;
			this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
			// 
			// tableLayoutPanel1
			// 
			this.tableLayoutPanel1.ColumnCount = 2;
			this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
			this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 80F));
			this.tableLayoutPanel1.Controls.Add(this.lblWrestler, 0, 0);
			this.tableLayoutPanel1.Controls.Add(this.cbWrestlers, 1, 0);
			this.tableLayoutPanel1.Location = new System.Drawing.Point(12, 12);
			this.tableLayoutPanel1.Name = "tableLayoutPanel1";
			this.tableLayoutPanel1.RowCount = 1;
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.tableLayoutPanel1.Size = new System.Drawing.Size(360, 36);
			this.tableLayoutPanel1.TabIndex = 0;
			// 
			// lblWrestler
			// 
			this.lblWrestler.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
			this.lblWrestler.AutoSize = true;
			this.lblWrestler.Location = new System.Drawing.Point(3, 11);
			this.lblWrestler.Name = "lblWrestler";
			this.lblWrestler.Size = new System.Drawing.Size(66, 13);
			this.lblWrestler.TabIndex = 0;
			this.lblWrestler.Text = "&Wrestler";
			// 
			// cbWrestlers
			// 
			this.cbWrestlers.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
			this.cbWrestlers.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cbWrestlers.FormattingEnabled = true;
			this.cbWrestlers.Location = new System.Drawing.Point(75, 7);
			this.cbWrestlers.Name = "cbWrestlers";
			this.cbWrestlers.Size = new System.Drawing.Size(282, 21);
			this.cbWrestlers.TabIndex = 1;
			// 
			// SelectWrestlerDialog
			// 
			this.AcceptButton = this.btnOK;
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.CancelButton = this.btnCancel;
			this.ClientSize = new System.Drawing.Size(384, 89);
			this.Controls.Add(this.tableLayoutPanel1);
			this.Controls.Add(this.btnCancel);
			this.Controls.Add(this.btnOK);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.MinimumSize = new System.Drawing.Size(400, 128);
			this.Name = "SelectWrestlerDialog";
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "Select Wrestler";
			this.tableLayoutPanel1.ResumeLayout(false);
			this.tableLayoutPanel1.PerformLayout();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.Button btnOK;
		private System.Windows.Forms.Button btnCancel;
		private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
		private System.Windows.Forms.Label lblWrestler;
		private System.Windows.Forms.ComboBox cbWrestlers;
	}
}