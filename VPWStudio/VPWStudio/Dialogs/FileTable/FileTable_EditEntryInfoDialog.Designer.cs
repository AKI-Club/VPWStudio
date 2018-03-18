namespace VPWStudio
{
	partial class FileTableEditEntryInfoDialog
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
			this.labelEditingEntry = new System.Windows.Forms.Label();
			this.buttonOK = new System.Windows.Forms.Button();
			this.buttonCancel = new System.Windows.Forms.Button();
			this.tlpEntryInfo = new System.Windows.Forms.TableLayoutPanel();
			this.tbComment = new System.Windows.Forms.TextBox();
			this.labelComment = new System.Windows.Forms.Label();
			this.labelFileType = new System.Windows.Forms.Label();
			this.cbFileTypes = new System.Windows.Forms.ComboBox();
			this.labelReplaceEncoding = new System.Windows.Forms.Label();
			this.labelReplaceFilePath = new System.Windows.Forms.Label();
			this.tlpReplaceFilePath = new System.Windows.Forms.TableLayoutPanel();
			this.buttonReplaceFileBrowse = new System.Windows.Forms.Button();
			this.tbReplaceFilePath = new System.Windows.Forms.TextBox();
			this.cbReplaceEncoding = new System.Windows.Forms.ComboBox();
			this.tlpEntryInfo.SuspendLayout();
			this.tlpReplaceFilePath.SuspendLayout();
			this.SuspendLayout();
			// 
			// labelEditingEntry
			// 
			this.labelEditingEntry.AutoSize = true;
			this.labelEditingEntry.Location = new System.Drawing.Point(12, 9);
			this.labelEditingEntry.Name = "labelEditingEntry";
			this.labelEditingEntry.Size = new System.Drawing.Size(151, 13);
			this.labelEditingEntry.TabIndex = 0;
			this.labelEditingEntry.Text = "Editing File Table Entry ID {ID}";
			// 
			// buttonOK
			// 
			this.buttonOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.buttonOK.Location = new System.Drawing.Point(318, 167);
			this.buttonOK.Name = "buttonOK";
			this.buttonOK.Size = new System.Drawing.Size(75, 23);
			this.buttonOK.TabIndex = 5;
			this.buttonOK.Text = "&OK";
			this.buttonOK.UseVisualStyleBackColor = true;
			this.buttonOK.Click += new System.EventHandler(this.buttonOK_Click);
			// 
			// buttonCancel
			// 
			this.buttonCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.buttonCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.buttonCancel.Location = new System.Drawing.Point(399, 167);
			this.buttonCancel.Name = "buttonCancel";
			this.buttonCancel.Size = new System.Drawing.Size(75, 23);
			this.buttonCancel.TabIndex = 6;
			this.buttonCancel.Text = "&Cancel";
			this.buttonCancel.UseVisualStyleBackColor = true;
			this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
			// 
			// tlpEntryInfo
			// 
			this.tlpEntryInfo.ColumnCount = 2;
			this.tlpEntryInfo.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 30F));
			this.tlpEntryInfo.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 70F));
			this.tlpEntryInfo.Controls.Add(this.tbComment, 1, 1);
			this.tlpEntryInfo.Controls.Add(this.labelComment, 0, 1);
			this.tlpEntryInfo.Controls.Add(this.labelFileType, 0, 0);
			this.tlpEntryInfo.Controls.Add(this.cbFileTypes, 1, 0);
			this.tlpEntryInfo.Controls.Add(this.labelReplaceEncoding, 0, 2);
			this.tlpEntryInfo.Controls.Add(this.labelReplaceFilePath, 0, 3);
			this.tlpEntryInfo.Controls.Add(this.tlpReplaceFilePath, 1, 3);
			this.tlpEntryInfo.Controls.Add(this.cbReplaceEncoding, 1, 2);
			this.tlpEntryInfo.Location = new System.Drawing.Point(12, 25);
			this.tlpEntryInfo.Name = "tlpEntryInfo";
			this.tlpEntryInfo.RowCount = 4;
			this.tlpEntryInfo.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
			this.tlpEntryInfo.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
			this.tlpEntryInfo.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
			this.tlpEntryInfo.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
			this.tlpEntryInfo.Size = new System.Drawing.Size(462, 136);
			this.tlpEntryInfo.TabIndex = 7;
			// 
			// tbComment
			// 
			this.tbComment.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
			this.tbComment.Location = new System.Drawing.Point(141, 41);
			this.tbComment.Name = "tbComment";
			this.tbComment.Size = new System.Drawing.Size(318, 20);
			this.tbComment.TabIndex = 1;
			// 
			// labelComment
			// 
			this.labelComment.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
			this.labelComment.AutoSize = true;
			this.labelComment.Location = new System.Drawing.Point(3, 44);
			this.labelComment.Name = "labelComment";
			this.labelComment.Size = new System.Drawing.Size(132, 13);
			this.labelComment.TabIndex = 1;
			this.labelComment.Text = "C&omment";
			// 
			// labelFileType
			// 
			this.labelFileType.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
			this.labelFileType.AutoSize = true;
			this.labelFileType.Location = new System.Drawing.Point(3, 10);
			this.labelFileType.Name = "labelFileType";
			this.labelFileType.Size = new System.Drawing.Size(132, 13);
			this.labelFileType.TabIndex = 0;
			this.labelFileType.Text = "&File Type";
			// 
			// cbFileTypes
			// 
			this.cbFileTypes.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
			this.cbFileTypes.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cbFileTypes.FormattingEnabled = true;
			this.cbFileTypes.Location = new System.Drawing.Point(141, 6);
			this.cbFileTypes.Name = "cbFileTypes";
			this.cbFileTypes.Size = new System.Drawing.Size(318, 21);
			this.cbFileTypes.TabIndex = 0;
			// 
			// labelReplaceEncoding
			// 
			this.labelReplaceEncoding.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
			this.labelReplaceEncoding.AutoSize = true;
			this.labelReplaceEncoding.Location = new System.Drawing.Point(3, 78);
			this.labelReplaceEncoding.Name = "labelReplaceEncoding";
			this.labelReplaceEncoding.Size = new System.Drawing.Size(132, 13);
			this.labelReplaceEncoding.TabIndex = 2;
			this.labelReplaceEncoding.Text = "Replacement &Encoding";
			// 
			// labelReplaceFilePath
			// 
			this.labelReplaceFilePath.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
			this.labelReplaceFilePath.AutoSize = true;
			this.labelReplaceFilePath.Location = new System.Drawing.Point(3, 112);
			this.labelReplaceFilePath.Name = "labelReplaceFilePath";
			this.labelReplaceFilePath.Size = new System.Drawing.Size(132, 13);
			this.labelReplaceFilePath.TabIndex = 3;
			this.labelReplaceFilePath.Text = "&Replacement File Path";
			// 
			// tlpReplaceFilePath
			// 
			this.tlpReplaceFilePath.ColumnCount = 2;
			this.tlpReplaceFilePath.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 75F));
			this.tlpReplaceFilePath.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
			this.tlpReplaceFilePath.Controls.Add(this.buttonReplaceFileBrowse, 1, 0);
			this.tlpReplaceFilePath.Controls.Add(this.tbReplaceFilePath, 0, 0);
			this.tlpReplaceFilePath.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tlpReplaceFilePath.Location = new System.Drawing.Point(141, 105);
			this.tlpReplaceFilePath.Name = "tlpReplaceFilePath";
			this.tlpReplaceFilePath.RowCount = 1;
			this.tlpReplaceFilePath.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.tlpReplaceFilePath.Size = new System.Drawing.Size(318, 28);
			this.tlpReplaceFilePath.TabIndex = 4;
			// 
			// buttonReplaceFileBrowse
			// 
			this.buttonReplaceFileBrowse.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
			this.buttonReplaceFileBrowse.Location = new System.Drawing.Point(241, 3);
			this.buttonReplaceFileBrowse.Name = "buttonReplaceFileBrowse";
			this.buttonReplaceFileBrowse.Size = new System.Drawing.Size(74, 22);
			this.buttonReplaceFileBrowse.TabIndex = 0;
			this.buttonReplaceFileBrowse.Text = "Browse...";
			this.buttonReplaceFileBrowse.UseVisualStyleBackColor = true;
			// 
			// tbReplaceFilePath
			// 
			this.tbReplaceFilePath.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
			this.tbReplaceFilePath.Location = new System.Drawing.Point(3, 4);
			this.tbReplaceFilePath.Name = "tbReplaceFilePath";
			this.tbReplaceFilePath.Size = new System.Drawing.Size(232, 20);
			this.tbReplaceFilePath.TabIndex = 1;
			// 
			// cbReplaceEncoding
			// 
			this.cbReplaceEncoding.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
			this.cbReplaceEncoding.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cbReplaceEncoding.FormattingEnabled = true;
			this.cbReplaceEncoding.Items.AddRange(new object[] {
            "Pick Best",
            "Force Raw",
            "Force LZSS"});
			this.cbReplaceEncoding.Location = new System.Drawing.Point(141, 74);
			this.cbReplaceEncoding.Name = "cbReplaceEncoding";
			this.cbReplaceEncoding.Size = new System.Drawing.Size(318, 21);
			this.cbReplaceEncoding.TabIndex = 2;
			// 
			// FileTableEditEntryInfoDialog
			// 
			this.AcceptButton = this.buttonOK;
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.CancelButton = this.buttonCancel;
			this.ClientSize = new System.Drawing.Size(486, 202);
			this.Controls.Add(this.tlpEntryInfo);
			this.Controls.Add(this.labelEditingEntry);
			this.Controls.Add(this.buttonCancel);
			this.Controls.Add(this.buttonOK);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "FileTableEditEntryInfoDialog";
			this.ShowIcon = false;
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "File Table Entry Information";
			this.tlpEntryInfo.ResumeLayout(false);
			this.tlpEntryInfo.PerformLayout();
			this.tlpReplaceFilePath.ResumeLayout(false);
			this.tlpReplaceFilePath.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion
		private System.Windows.Forms.Label labelEditingEntry;
		private System.Windows.Forms.Button buttonOK;
		private System.Windows.Forms.Button buttonCancel;
		private System.Windows.Forms.TableLayoutPanel tlpEntryInfo;
		private System.Windows.Forms.TextBox tbComment;
		private System.Windows.Forms.Label labelComment;
		private System.Windows.Forms.Label labelFileType;
		private System.Windows.Forms.ComboBox cbFileTypes;
		private System.Windows.Forms.Label labelReplaceEncoding;
		private System.Windows.Forms.Label labelReplaceFilePath;
		private System.Windows.Forms.TableLayoutPanel tlpReplaceFilePath;
		private System.Windows.Forms.Button buttonReplaceFileBrowse;
		private System.Windows.Forms.TextBox tbReplaceFilePath;
		private System.Windows.Forms.ComboBox cbReplaceEncoding;
	}
}