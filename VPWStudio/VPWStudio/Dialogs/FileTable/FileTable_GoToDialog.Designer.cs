namespace VPWStudio
{
	partial class FileTable_GoToDialog
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
			this.buttonOK = new System.Windows.Forms.Button();
			this.buttonCancel = new System.Windows.Forms.Button();
			this.labelFileID = new System.Windows.Forms.Label();
			this.nudFileID = new System.Windows.Forms.NumericUpDown();
			((System.ComponentModel.ISupportInitialize)(this.nudFileID)).BeginInit();
			this.SuspendLayout();
			// 
			// buttonOK
			// 
			this.buttonOK.Location = new System.Drawing.Point(12, 38);
			this.buttonOK.Name = "buttonOK";
			this.buttonOK.Size = new System.Drawing.Size(75, 23);
			this.buttonOK.TabIndex = 1;
			this.buttonOK.Text = "&OK";
			this.buttonOK.UseVisualStyleBackColor = true;
			this.buttonOK.Click += new System.EventHandler(this.buttonOK_Click);
			// 
			// buttonCancel
			// 
			this.buttonCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.buttonCancel.Location = new System.Drawing.Point(99, 38);
			this.buttonCancel.Name = "buttonCancel";
			this.buttonCancel.Size = new System.Drawing.Size(75, 23);
			this.buttonCancel.TabIndex = 2;
			this.buttonCancel.Text = "&Cancel";
			this.buttonCancel.UseVisualStyleBackColor = true;
			this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
			// 
			// labelFileID
			// 
			this.labelFileID.AutoSize = true;
			this.labelFileID.Location = new System.Drawing.Point(9, 14);
			this.labelFileID.Name = "labelFileID";
			this.labelFileID.Size = new System.Drawing.Size(63, 13);
			this.labelFileID.TabIndex = 0;
			this.labelFileID.Text = "File &ID (hex)";
			// 
			// nudFileID
			// 
			this.nudFileID.Hexadecimal = true;
			this.nudFileID.Location = new System.Drawing.Point(78, 12);
			this.nudFileID.Maximum = new decimal(new int[] {
            65535,
            0,
            0,
            0});
			this.nudFileID.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
			this.nudFileID.Name = "nudFileID";
			this.nudFileID.Size = new System.Drawing.Size(96, 20);
			this.nudFileID.TabIndex = 0;
			this.nudFileID.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
			// 
			// FileTable_GoToDialog
			// 
			this.AcceptButton = this.buttonOK;
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.CancelButton = this.buttonCancel;
			this.ClientSize = new System.Drawing.Size(186, 73);
			this.Controls.Add(this.nudFileID);
			this.Controls.Add(this.labelFileID);
			this.Controls.Add(this.buttonCancel);
			this.Controls.Add(this.buttonOK);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "FileTable_GoToDialog";
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "Go To...";
			((System.ComponentModel.ISupportInitialize)(this.nudFileID)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Button buttonOK;
		private System.Windows.Forms.Button buttonCancel;
		private System.Windows.Forms.Label labelFileID;
		private System.Windows.Forms.NumericUpDown nudFileID;
	}
}