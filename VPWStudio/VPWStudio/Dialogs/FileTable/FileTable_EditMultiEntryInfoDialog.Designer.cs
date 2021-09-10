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
			this.buttonOK = new System.Windows.Forms.Button();
			this.buttonCancel = new System.Windows.Forms.Button();
			this.dgvEditEntries = new System.Windows.Forms.DataGridView();
			this.FileID = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.FileType = new System.Windows.Forms.DataGridViewComboBoxColumn();
			this.Encoding = new System.Windows.Forms.DataGridViewComboBoxColumn();
			this.Comment = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.ReplaceFile = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.Browse = new System.Windows.Forms.DataGridViewButtonColumn();
			((System.ComponentModel.ISupportInitialize)(this.dgvEditEntries)).BeginInit();
			this.SuspendLayout();
			// 
			// buttonOK
			// 
			this.buttonOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.buttonOK.Location = new System.Drawing.Point(464, 238);
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
			this.buttonCancel.Location = new System.Drawing.Point(545, 238);
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
            this.ReplaceFile,
            this.Browse});
			this.dgvEditEntries.Location = new System.Drawing.Point(12, 12);
			this.dgvEditEntries.Name = "dgvEditEntries";
			this.dgvEditEntries.Size = new System.Drawing.Size(608, 220);
			this.dgvEditEntries.TabIndex = 2;
			this.dgvEditEntries.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvEditEntries_CellContentClick);
			// 
			// FileID
			// 
			this.FileID.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
			this.FileID.FillWeight = 65F;
			this.FileID.HeaderText = "File ID";
			this.FileID.Name = "FileID";
			this.FileID.ReadOnly = true;
			// 
			// FileType
			// 
			this.FileType.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
			this.FileType.HeaderText = "File Type";
			this.FileType.Name = "FileType";
			this.FileType.Resizable = System.Windows.Forms.DataGridViewTriState.True;
			this.FileType.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
			// 
			// Encoding
			// 
			this.Encoding.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
			this.Encoding.HeaderText = "Encoding";
			this.Encoding.Name = "Encoding";
			this.Encoding.Resizable = System.Windows.Forms.DataGridViewTriState.True;
			this.Encoding.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
			// 
			// Comment
			// 
			this.Comment.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
			this.Comment.HeaderText = "Comment";
			this.Comment.Name = "Comment";
			// 
			// ReplaceFile
			// 
			this.ReplaceFile.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
			this.ReplaceFile.HeaderText = "Replacement File";
			this.ReplaceFile.Name = "ReplaceFile";
			// 
			// Browse
			// 
			this.Browse.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
			this.Browse.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.Browse.HeaderText = "Browse";
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
			this.ClientSize = new System.Drawing.Size(632, 273);
			this.Controls.Add(this.dgvEditEntries);
			this.Controls.Add(this.buttonCancel);
			this.Controls.Add(this.buttonOK);
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.MinimumSize = new System.Drawing.Size(640, 300);
			this.Name = "FileTable_EditMultiEntryInfoDialog";
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
		private System.Windows.Forms.DataGridViewTextBoxColumn ReplaceFile;
		private System.Windows.Forms.DataGridViewButtonColumn Browse;
	}
}