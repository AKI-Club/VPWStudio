namespace VPWStudio
{
	partial class FileTable_SearchDialog
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
			this.tbSearchText = new System.Windows.Forms.TextBox();
			this.labelText = new System.Windows.Forms.Label();
			this.SuspendLayout();
			// 
			// buttonOK
			// 
			this.buttonOK.Location = new System.Drawing.Point(146, 38);
			this.buttonOK.Name = "buttonOK";
			this.buttonOK.Size = new System.Drawing.Size(75, 23);
			this.buttonOK.TabIndex = 2;
			this.buttonOK.Text = "&OK";
			this.buttonOK.UseVisualStyleBackColor = true;
			this.buttonOK.Click += new System.EventHandler(this.buttonOK_Click);
			// 
			// buttonCancel
			// 
			this.buttonCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.buttonCancel.Location = new System.Drawing.Point(227, 38);
			this.buttonCancel.Name = "buttonCancel";
			this.buttonCancel.Size = new System.Drawing.Size(75, 23);
			this.buttonCancel.TabIndex = 3;
			this.buttonCancel.Text = "&Cancel";
			this.buttonCancel.UseVisualStyleBackColor = true;
			this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
			// 
			// tbSearchText
			// 
			this.tbSearchText.Location = new System.Drawing.Point(46, 12);
			this.tbSearchText.Name = "tbSearchText";
			this.tbSearchText.Size = new System.Drawing.Size(254, 20);
			this.tbSearchText.TabIndex = 1;
			// 
			// labelText
			// 
			this.labelText.AutoSize = true;
			this.labelText.Location = new System.Drawing.Point(12, 15);
			this.labelText.Name = "labelText";
			this.labelText.Size = new System.Drawing.Size(28, 13);
			this.labelText.TabIndex = 0;
			this.labelText.Text = "&Text";
			// 
			// FileTable_SearchDialog
			// 
			this.AcceptButton = this.buttonOK;
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.CancelButton = this.buttonCancel;
			this.ClientSize = new System.Drawing.Size(314, 73);
			this.Controls.Add(this.labelText);
			this.Controls.Add(this.tbSearchText);
			this.Controls.Add(this.buttonCancel);
			this.Controls.Add(this.buttonOK);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "FileTable_SearchDialog";
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "Search";
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Button buttonOK;
		private System.Windows.Forms.Button buttonCancel;
		private System.Windows.Forms.TextBox tbSearchText;
		private System.Windows.Forms.Label labelText;
	}
}