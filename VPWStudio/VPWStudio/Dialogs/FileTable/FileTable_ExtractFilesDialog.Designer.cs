namespace VPWStudio
{
	partial class FileTable_ExtractFilesDialog
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
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
			this.dgvFiles = new System.Windows.Forms.DataGridView();
			this.EnableExport = new System.Windows.Forms.DataGridViewCheckBoxColumn();
			this.FileID = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.FileType = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.Comment = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.OutFilename = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.buttonOK = new System.Windows.Forms.Button();
			this.buttonCancel = new System.Windows.Forms.Button();
			((System.ComponentModel.ISupportInitialize)(this.dgvFiles)).BeginInit();
			this.SuspendLayout();
			// 
			// dgvFiles
			// 
			this.dgvFiles.AllowUserToAddRows = false;
			this.dgvFiles.AllowUserToDeleteRows = false;
			dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
			this.dgvFiles.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
			this.dgvFiles.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.dgvFiles.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.ColumnHeader;
			this.dgvFiles.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dgvFiles.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.EnableExport,
            this.FileID,
            this.FileType,
            this.Comment,
            this.OutFilename});
			this.dgvFiles.Location = new System.Drawing.Point(12, 12);
			this.dgvFiles.Name = "dgvFiles";
			this.dgvFiles.RowHeadersVisible = false;
			this.dgvFiles.RowHeadersWidth = 16;
			this.dgvFiles.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
			this.dgvFiles.Size = new System.Drawing.Size(468, 240);
			this.dgvFiles.TabIndex = 0;
			// 
			// EnableExport
			// 
			this.EnableExport.Frozen = true;
			this.EnableExport.HeaderText = "Export";
			this.EnableExport.Name = "EnableExport";
			this.EnableExport.Width = 43;
			// 
			// FileID
			// 
			this.FileID.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
			this.FileID.FillWeight = 12F;
			this.FileID.HeaderText = "File ID";
			this.FileID.Name = "FileID";
			this.FileID.ReadOnly = true;
			// 
			// FileType
			// 
			this.FileType.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
			this.FileType.FillWeight = 17.58117F;
			this.FileType.HeaderText = "FileType";
			this.FileType.Name = "FileType";
			this.FileType.ReadOnly = true;
			// 
			// Comment
			// 
			this.Comment.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
			this.Comment.FillWeight = 26.37175F;
			this.Comment.HeaderText = "Comment";
			this.Comment.Name = "Comment";
			this.Comment.ReadOnly = true;
			// 
			// OutFilename
			// 
			this.OutFilename.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
			this.OutFilename.FillWeight = 26.37175F;
			this.OutFilename.HeaderText = "Export Filename";
			this.OutFilename.Name = "OutFilename";
			// 
			// buttonOK
			// 
			this.buttonOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.buttonOK.Location = new System.Drawing.Point(324, 258);
			this.buttonOK.Name = "buttonOK";
			this.buttonOK.Size = new System.Drawing.Size(75, 23);
			this.buttonOK.TabIndex = 1;
			this.buttonOK.Text = "&OK";
			this.buttonOK.UseVisualStyleBackColor = true;
			this.buttonOK.Click += new System.EventHandler(this.buttonOK_Click);
			// 
			// buttonCancel
			// 
			this.buttonCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.buttonCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.buttonCancel.Location = new System.Drawing.Point(405, 258);
			this.buttonCancel.Name = "buttonCancel";
			this.buttonCancel.Size = new System.Drawing.Size(75, 23);
			this.buttonCancel.TabIndex = 2;
			this.buttonCancel.Text = "&Cancel";
			this.buttonCancel.UseVisualStyleBackColor = true;
			this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
			// 
			// FileTable_ExtractFilesDialog
			// 
			this.AcceptButton = this.buttonOK;
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.CancelButton = this.buttonCancel;
			this.ClientSize = new System.Drawing.Size(492, 293);
			this.Controls.Add(this.buttonCancel);
			this.Controls.Add(this.buttonOK);
			this.Controls.Add(this.dgvFiles);
			this.MaximizeBox = false;
			this.Name = "FileTable_ExtractFilesDialog";
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "Extract Files";
			((System.ComponentModel.ISupportInitialize)(this.dgvFiles)).EndInit();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.DataGridView dgvFiles;
		private System.Windows.Forms.Button buttonOK;
		private System.Windows.Forms.Button buttonCancel;
		private System.Windows.Forms.DataGridViewCheckBoxColumn EnableExport;
		private System.Windows.Forms.DataGridViewTextBoxColumn FileID;
		private System.Windows.Forms.DataGridViewTextBoxColumn FileType;
		private System.Windows.Forms.DataGridViewTextBoxColumn Comment;
		private System.Windows.Forms.DataGridViewTextBoxColumn OutFilename;
	}
}