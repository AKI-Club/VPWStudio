namespace VPWStudio
{
	partial class GoToDialog
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
			this.lblEntry = new System.Windows.Forms.Label();
			this.nudEntry = new System.Windows.Forms.NumericUpDown();
			this.btnOK = new System.Windows.Forms.Button();
			this.btnCancel = new System.Windows.Forms.Button();
			((System.ComponentModel.ISupportInitialize)(this.nudEntry)).BeginInit();
			this.SuspendLayout();
			// 
			// lblEntry
			// 
			this.lblEntry.AutoSize = true;
			this.lblEntry.Location = new System.Drawing.Point(12, 14);
			this.lblEntry.Name = "lblEntry";
			this.lblEntry.Size = new System.Drawing.Size(31, 13);
			this.lblEntry.TabIndex = 0;
			this.lblEntry.Text = "&Entry";
			// 
			// nudEntry
			// 
			this.nudEntry.Location = new System.Drawing.Point(49, 12);
			this.nudEntry.Name = "nudEntry";
			this.nudEntry.Size = new System.Drawing.Size(179, 20);
			this.nudEntry.TabIndex = 1;
			// 
			// btnOK
			// 
			this.btnOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.btnOK.Location = new System.Drawing.Point(72, 38);
			this.btnOK.Name = "btnOK";
			this.btnOK.Size = new System.Drawing.Size(75, 23);
			this.btnOK.TabIndex = 2;
			this.btnOK.Text = "&OK";
			this.btnOK.UseVisualStyleBackColor = true;
			this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
			// 
			// btnCancel
			// 
			this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.btnCancel.Location = new System.Drawing.Point(153, 38);
			this.btnCancel.Name = "btnCancel";
			this.btnCancel.Size = new System.Drawing.Size(75, 23);
			this.btnCancel.TabIndex = 3;
			this.btnCancel.Text = "&Cancel";
			this.btnCancel.UseVisualStyleBackColor = true;
			this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
			// 
			// GoToDialog
			// 
			this.AcceptButton = this.btnOK;
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.CancelButton = this.btnCancel;
			this.ClientSize = new System.Drawing.Size(240, 73);
			this.Controls.Add(this.btnCancel);
			this.Controls.Add(this.btnOK);
			this.Controls.Add(this.nudEntry);
			this.Controls.Add(this.lblEntry);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "GoToDialog";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "Go To...";
			((System.ComponentModel.ISupportInitialize)(this.nudEntry)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Label lblEntry;
		private System.Windows.Forms.NumericUpDown nudEntry;
		private System.Windows.Forms.Button btnOK;
		private System.Windows.Forms.Button btnCancel;
	}
}