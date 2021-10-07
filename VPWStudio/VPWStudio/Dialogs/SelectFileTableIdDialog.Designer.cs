
namespace VPWStudio
{
	partial class SelectFileTableIdDialog
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
			this.buttonSelect = new System.Windows.Forms.Button();
			this.buttonCancel = new System.Windows.Forms.Button();
			this.lvFileTableEntries = new System.Windows.Forms.ListView();
			this.cbFileTypeFilter = new System.Windows.Forms.ComboBox();
			this.labelFileTypeFilter = new System.Windows.Forms.Label();
			this.gbFileTableEntries = new System.Windows.Forms.GroupBox();
			this.chFileID = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.chComment = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.chFileType = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.gbFileTableEntries.SuspendLayout();
			this.SuspendLayout();
			// 
			// buttonSelect
			// 
			this.buttonSelect.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.buttonSelect.Location = new System.Drawing.Point(456, 310);
			this.buttonSelect.Name = "buttonSelect";
			this.buttonSelect.Size = new System.Drawing.Size(75, 23);
			this.buttonSelect.TabIndex = 4;
			this.buttonSelect.Text = "&Select";
			this.buttonSelect.UseVisualStyleBackColor = true;
			this.buttonSelect.Click += new System.EventHandler(this.buttonSelect_Click);
			// 
			// buttonCancel
			// 
			this.buttonCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.buttonCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.buttonCancel.Location = new System.Drawing.Point(537, 310);
			this.buttonCancel.Name = "buttonCancel";
			this.buttonCancel.Size = new System.Drawing.Size(75, 23);
			this.buttonCancel.TabIndex = 5;
			this.buttonCancel.Text = "Cancel";
			this.buttonCancel.UseVisualStyleBackColor = true;
			this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
			// 
			// lvFileTableEntries
			// 
			this.lvFileTableEntries.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.chFileID,
            this.chFileType,
            this.chComment});
			this.lvFileTableEntries.Dock = System.Windows.Forms.DockStyle.Fill;
			this.lvFileTableEntries.GridLines = true;
			this.lvFileTableEntries.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
			this.lvFileTableEntries.HideSelection = false;
			this.lvFileTableEntries.Location = new System.Drawing.Point(3, 16);
			this.lvFileTableEntries.MultiSelect = false;
			this.lvFileTableEntries.Name = "lvFileTableEntries";
			this.lvFileTableEntries.ShowGroups = false;
			this.lvFileTableEntries.Size = new System.Drawing.Size(594, 246);
			this.lvFileTableEntries.TabIndex = 3;
			this.lvFileTableEntries.UseCompatibleStateImageBehavior = false;
			this.lvFileTableEntries.View = System.Windows.Forms.View.Details;
			// 
			// cbFileTypeFilter
			// 
			this.cbFileTypeFilter.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.cbFileTypeFilter.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cbFileTypeFilter.FormattingEnabled = true;
			this.cbFileTypeFilter.Location = new System.Drawing.Point(115, 12);
			this.cbFileTypeFilter.Name = "cbFileTypeFilter";
			this.cbFileTypeFilter.Size = new System.Drawing.Size(497, 21);
			this.cbFileTypeFilter.TabIndex = 1;
			this.cbFileTypeFilter.SelectedIndexChanged += new System.EventHandler(this.cbFileTypeFilter_SelectedIndexChanged);
			// 
			// labelFileTypeFilter
			// 
			this.labelFileTypeFilter.AutoSize = true;
			this.labelFileTypeFilter.Location = new System.Drawing.Point(12, 15);
			this.labelFileTypeFilter.Name = "labelFileTypeFilter";
			this.labelFileTypeFilter.Size = new System.Drawing.Size(97, 13);
			this.labelFileTypeFilter.TabIndex = 0;
			this.labelFileTypeFilter.Text = "Show Files of &Type";
			// 
			// gbFileTableEntries
			// 
			this.gbFileTableEntries.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.gbFileTableEntries.Controls.Add(this.lvFileTableEntries);
			this.gbFileTableEntries.Location = new System.Drawing.Point(12, 39);
			this.gbFileTableEntries.Name = "gbFileTableEntries";
			this.gbFileTableEntries.Size = new System.Drawing.Size(600, 265);
			this.gbFileTableEntries.TabIndex = 2;
			this.gbFileTableEntries.TabStop = false;
			this.gbFileTableEntries.Text = "File Table &Entries";
			// 
			// chFileID
			// 
			this.chFileID.Text = "File ID";
			// 
			// chComment
			// 
			this.chComment.Text = "Comment";
			this.chComment.Width = 440;
			// 
			// chFileType
			// 
			this.chFileType.Text = "File Type";
			this.chFileType.Width = 90;
			// 
			// SelectFileTableIdDialog
			// 
			this.AcceptButton = this.buttonSelect;
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.CancelButton = this.buttonCancel;
			this.ClientSize = new System.Drawing.Size(624, 345);
			this.Controls.Add(this.gbFileTableEntries);
			this.Controls.Add(this.labelFileTypeFilter);
			this.Controls.Add(this.cbFileTypeFilter);
			this.Controls.Add(this.buttonCancel);
			this.Controls.Add(this.buttonSelect);
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.MinimumSize = new System.Drawing.Size(640, 384);
			this.Name = "SelectFileTableIdDialog";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "Select File Table ID";
			this.gbFileTableEntries.ResumeLayout(false);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Button buttonSelect;
		private System.Windows.Forms.Button buttonCancel;
		private System.Windows.Forms.ListView lvFileTableEntries;
		private System.Windows.Forms.ComboBox cbFileTypeFilter;
		private System.Windows.Forms.Label labelFileTypeFilter;
		private System.Windows.Forms.GroupBox gbFileTableEntries;
		private System.Windows.Forms.ColumnHeader chFileID;
		private System.Windows.Forms.ColumnHeader chComment;
		private System.Windows.Forms.ColumnHeader chFileType;
	}
}