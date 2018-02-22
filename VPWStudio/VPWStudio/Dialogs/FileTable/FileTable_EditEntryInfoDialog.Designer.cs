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
			this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
			this.labelEditingEntry = new System.Windows.Forms.Label();
			this.tbComment = new System.Windows.Forms.TextBox();
			this.buttonOK = new System.Windows.Forms.Button();
			this.buttonCancel = new System.Windows.Forms.Button();
			this.labelComment = new System.Windows.Forms.Label();
			this.labelFileType = new System.Windows.Forms.Label();
			this.cbFileTypes = new System.Windows.Forms.ComboBox();
			this.tableLayoutPanel1.SuspendLayout();
			this.SuspendLayout();
			// 
			// tableLayoutPanel1
			// 
			this.tableLayoutPanel1.ColumnCount = 2;
			this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 30F));
			this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 70F));
			this.tableLayoutPanel1.Controls.Add(this.tbComment, 1, 1);
			this.tableLayoutPanel1.Controls.Add(this.labelComment, 0, 1);
			this.tableLayoutPanel1.Controls.Add(this.labelFileType, 0, 0);
			this.tableLayoutPanel1.Controls.Add(this.cbFileTypes, 1, 0);
			this.tableLayoutPanel1.Location = new System.Drawing.Point(12, 25);
			this.tableLayoutPanel1.Name = "tableLayoutPanel1";
			this.tableLayoutPanel1.RowCount = 2;
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
			this.tableLayoutPanel1.Size = new System.Drawing.Size(420, 78);
			this.tableLayoutPanel1.TabIndex = 0;
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
			// tbComment
			// 
			this.tbComment.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
			this.tbComment.Location = new System.Drawing.Point(129, 48);
			this.tbComment.Name = "tbComment";
			this.tbComment.Size = new System.Drawing.Size(288, 20);
			this.tbComment.TabIndex = 1;
			// 
			// buttonOK
			// 
			this.buttonOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.buttonOK.Location = new System.Drawing.Point(276, 109);
			this.buttonOK.Name = "buttonOK";
			this.buttonOK.Size = new System.Drawing.Size(75, 23);
			this.buttonOK.TabIndex = 2;
			this.buttonOK.Text = "&OK";
			this.buttonOK.UseVisualStyleBackColor = true;
			this.buttonOK.Click += new System.EventHandler(this.buttonOK_Click);
			// 
			// buttonCancel
			// 
			this.buttonCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.buttonCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.buttonCancel.Location = new System.Drawing.Point(357, 109);
			this.buttonCancel.Name = "buttonCancel";
			this.buttonCancel.Size = new System.Drawing.Size(75, 23);
			this.buttonCancel.TabIndex = 3;
			this.buttonCancel.Text = "&Cancel";
			this.buttonCancel.UseVisualStyleBackColor = true;
			this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
			// 
			// labelComment
			// 
			this.labelComment.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
			this.labelComment.AutoSize = true;
			this.labelComment.Location = new System.Drawing.Point(3, 52);
			this.labelComment.Name = "labelComment";
			this.labelComment.Size = new System.Drawing.Size(120, 13);
			this.labelComment.TabIndex = 1;
			this.labelComment.Text = "C&omment";
			// 
			// labelFileType
			// 
			this.labelFileType.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
			this.labelFileType.AutoSize = true;
			this.labelFileType.Location = new System.Drawing.Point(3, 13);
			this.labelFileType.Name = "labelFileType";
			this.labelFileType.Size = new System.Drawing.Size(120, 13);
			this.labelFileType.TabIndex = 0;
			this.labelFileType.Text = "&File Type";
			// 
			// cbFileTypes
			// 
			this.cbFileTypes.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
			this.cbFileTypes.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cbFileTypes.FormattingEnabled = true;
			this.cbFileTypes.Location = new System.Drawing.Point(129, 9);
			this.cbFileTypes.Name = "cbFileTypes";
			this.cbFileTypes.Size = new System.Drawing.Size(288, 21);
			this.cbFileTypes.TabIndex = 0;
			this.cbFileTypes.SelectionChangeCommitted += new System.EventHandler(this.cbFileTypes_SelectionChangeCommitted);
			// 
			// FileTableEditEntryInfoDialog
			// 
			this.AcceptButton = this.buttonOK;
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.CancelButton = this.buttonCancel;
			this.ClientSize = new System.Drawing.Size(444, 144);
			this.Controls.Add(this.labelEditingEntry);
			this.Controls.Add(this.buttonCancel);
			this.Controls.Add(this.buttonOK);
			this.Controls.Add(this.tableLayoutPanel1);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "FileTableEditEntryInfoDialog";
			this.ShowIcon = false;
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "File Table Entry Information";
			this.tableLayoutPanel1.ResumeLayout(false);
			this.tableLayoutPanel1.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
		private System.Windows.Forms.Label labelEditingEntry;
		private System.Windows.Forms.TextBox tbComment;
		private System.Windows.Forms.Button buttonOK;
		private System.Windows.Forms.Button buttonCancel;
		private System.Windows.Forms.Label labelComment;
		private System.Windows.Forms.Label labelFileType;
		private System.Windows.Forms.ComboBox cbFileTypes;
	}
}