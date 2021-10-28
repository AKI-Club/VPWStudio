
namespace VPWStudio.Dialogs.FileTable
{
	partial class FileTable_SearchFileTypeDialog
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
			this.labelFileType = new System.Windows.Forms.Label();
			this.cbFileTypes = new System.Windows.Forms.ComboBox();
			this.SuspendLayout();
			// 
			// buttonOK
			// 
			this.buttonOK.Location = new System.Drawing.Point(146, 39);
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
			this.buttonCancel.Location = new System.Drawing.Point(227, 39);
			this.buttonCancel.Name = "buttonCancel";
			this.buttonCancel.Size = new System.Drawing.Size(75, 23);
			this.buttonCancel.TabIndex = 3;
			this.buttonCancel.Text = "&Cancel";
			this.buttonCancel.UseVisualStyleBackColor = true;
			this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
			// 
			// labelFileType
			// 
			this.labelFileType.AutoSize = true;
			this.labelFileType.Location = new System.Drawing.Point(12, 15);
			this.labelFileType.Name = "labelFileType";
			this.labelFileType.Size = new System.Drawing.Size(50, 13);
			this.labelFileType.TabIndex = 0;
			this.labelFileType.Text = "&File Type";
			// 
			// cbFileTypes
			// 
			this.cbFileTypes.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cbFileTypes.FormattingEnabled = true;
			this.cbFileTypes.Location = new System.Drawing.Point(68, 12);
			this.cbFileTypes.Name = "cbFileTypes";
			this.cbFileTypes.Size = new System.Drawing.Size(234, 21);
			this.cbFileTypes.TabIndex = 1;
			// 
			// FileTable_SearchFileTypeDialog
			// 
			this.AcceptButton = this.buttonOK;
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.CancelButton = this.buttonCancel;
			this.ClientSize = new System.Drawing.Size(314, 74);
			this.Controls.Add(this.cbFileTypes);
			this.Controls.Add(this.labelFileType);
			this.Controls.Add(this.buttonCancel);
			this.Controls.Add(this.buttonOK);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "FileTable_SearchFileTypeDialog";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "Search for File Type";
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Button buttonOK;
		private System.Windows.Forms.Button buttonCancel;
		private System.Windows.Forms.Label labelFileType;
		private System.Windows.Forms.ComboBox cbFileTypes;
	}
}