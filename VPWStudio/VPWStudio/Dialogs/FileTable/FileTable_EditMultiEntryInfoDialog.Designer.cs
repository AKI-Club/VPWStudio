namespace VPWStudio
{
	partial class FileTable_EditMultiEntryInfoDialog
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
			this.buttonOK = new System.Windows.Forms.Button();
			this.buttonCancel = new System.Windows.Forms.Button();
			this.dgvEditEntries = new System.Windows.Forms.DataGridView();
			this.FileID = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.FileType = new System.Windows.Forms.DataGridViewComboBoxColumn();
			this.Encoding = new System.Windows.Forms.DataGridViewComboBoxColumn();
			this.Comment = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.ProjComment = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.ReplaceFile = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.Browse = new System.Windows.Forms.DataGridViewButtonColumn();
			((System.ComponentModel.ISupportInitialize)(this.dgvEditEntries)).BeginInit();
			this.SuspendLayout();
			// 
			// buttonOK
			// 
			this.buttonOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.buttonOK.Location = new System.Drawing.Point(616, 246);
			this.buttonOK.Name = "buttonOK";
			this.buttonOK.Size = new System.Drawing.Size(75, 23);
			this.buttonOK.TabIndex = 0;
			this.buttonOK.Text = "&OK";
			this.buttonOK.UseVisualStyleBackColor = true;
			this.buttonOK.Click += new System.EventHandler(this.buttonOK_Click);
			// 
			// buttonCancel
			// 
			this.buttonCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.buttonCancel.Location = new System.Drawing.Point(697, 246);
			this.buttonCancel.Name = "buttonCancel";
			this.buttonCancel.Size = new System.Drawing.Size(75, 23);
			this.buttonCancel.TabIndex = 1;
			this.buttonCancel.Text = "&Cancel";
			this.buttonCancel.UseVisualStyleBackColor = true;
			this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
			// 
			// dgvEditEntries
			// 
			this.dgvEditEntries.AllowUserToAddRows = false;
			this.dgvEditEntries.AllowUserToDeleteRows = false;
			this.dgvEditEntries.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.dgvEditEntries.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.EnableWithoutHeaderText;
			this.dgvEditEntries.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dgvEditEntries.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.FileID,
            this.FileType,
            this.Encoding,
            this.Comment,
            this.ProjComment,
            this.ReplaceFile,
            this.Browse});
			this.dgvEditEntries.Location = new System.Drawing.Point(12, 12);
			this.dgvEditEntries.Name = "dgvEditEntries";
			this.dgvEditEntries.Size = new System.Drawing.Size(760, 228);
			this.dgvEditEntries.TabIndex = 2;
			this.dgvEditEntries.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvEditEntries_CellContentClick);
			// 
			// FileID
			// 
			this.FileID.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCellsExceptHeader;
			dataGridViewCellStyle1.Font = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
			this.FileID.DefaultCellStyle = dataGridViewCellStyle1;
			this.FileID.FillWeight = 21.69601F;
			this.FileID.HeaderText = "File ID";
			this.FileID.MaxInputLength = 4;
			this.FileID.MinimumWidth = 16;
			this.FileID.Name = "FileID";
			this.FileID.ReadOnly = true;
			this.FileID.Width = 16;
			// 
			// FileType
			// 
			this.FileType.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCellsExceptHeader;
			this.FileType.FillWeight = 40.06592F;
			this.FileType.HeaderText = "File Type";
			this.FileType.MinimumWidth = 48;
			this.FileType.Name = "FileType";
			this.FileType.Resizable = System.Windows.Forms.DataGridViewTriState.True;
			this.FileType.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
			this.FileType.Width = 48;
			// 
			// Encoding
			// 
			this.Encoding.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCellsExceptHeader;
			this.Encoding.FillWeight = 30.10762F;
			this.Encoding.HeaderText = "Encoding";
			this.Encoding.MinimumWidth = 32;
			this.Encoding.Name = "Encoding";
			this.Encoding.Resizable = System.Windows.Forms.DataGridViewTriState.True;
			this.Encoding.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
			this.Encoding.Width = 32;
			// 
			// Comment
			// 
			this.Comment.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
			this.Comment.FillWeight = 74.44243F;
			this.Comment.HeaderText = "Comment";
			this.Comment.MinimumWidth = 32;
			this.Comment.Name = "Comment";
			// 
			// ProjComment
			// 
			this.ProjComment.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
			this.ProjComment.FillWeight = 95.51581F;
			this.ProjComment.HeaderText = "Project-Specific Comment";
			this.ProjComment.MinimumWidth = 32;
			this.ProjComment.Name = "ProjComment";
			// 
			// ReplaceFile
			// 
			this.ReplaceFile.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
			this.ReplaceFile.FillWeight = 87.30928F;
			this.ReplaceFile.HeaderText = "Replacement File";
			this.ReplaceFile.MinimumWidth = 32;
			this.ReplaceFile.Name = "ReplaceFile";
			// 
			// Browse
			// 
			this.Browse.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
			this.Browse.FillWeight = 30.86294F;
			this.Browse.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.Browse.HeaderText = "Browse";
			this.Browse.MinimumWidth = 48;
			this.Browse.Name = "Browse";
			this.Browse.ReadOnly = true;
			this.Browse.Resizable = System.Windows.Forms.DataGridViewTriState.True;
			this.Browse.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
			this.Browse.Text = "Browse...";
			// 
			// FileTable_EditMultiEntryInfoDialog
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(784, 281);
			this.Controls.Add(this.dgvEditEntries);
			this.Controls.Add(this.buttonCancel);
			this.Controls.Add(this.buttonOK);
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.MinimumSize = new System.Drawing.Size(720, 320);
			this.Name = "FileTable_EditMultiEntryInfoDialog";
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "File Table Entry Information";
			((System.ComponentModel.ISupportInitialize)(this.dgvEditEntries)).EndInit();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.Button buttonOK;
		private System.Windows.Forms.Button buttonCancel;
		private System.Windows.Forms.DataGridView dgvEditEntries;
		private System.Windows.Forms.DataGridViewTextBoxColumn FileID;
		private System.Windows.Forms.DataGridViewComboBoxColumn FileType;
		private System.Windows.Forms.DataGridViewComboBoxColumn Encoding;
		private System.Windows.Forms.DataGridViewTextBoxColumn Comment;
		private System.Windows.Forms.DataGridViewTextBoxColumn ProjComment;
		private System.Windows.Forms.DataGridViewTextBoxColumn ReplaceFile;
		private System.Windows.Forms.DataGridViewButtonColumn Browse;
	}
}