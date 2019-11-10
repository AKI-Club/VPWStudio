namespace VPWStudio
{
	partial class GameIntroEditor_Later
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
			this.tabControl1 = new System.Windows.Forms.TabControl();
			this.tabPage1 = new System.Windows.Forms.TabPage();
			this.tbAnimations = new System.Windows.Forms.TextBox();
			this.tabPage2 = new System.Windows.Forms.TabPage();
			this.tbImages = new System.Windows.Forms.TextBox();
			this.tabPage3 = new System.Windows.Forms.TabPage();
			this.tbSequence = new System.Windows.Forms.TextBox();
			this.buttonOK = new System.Windows.Forms.Button();
			this.buttonCancel = new System.Windows.Forms.Button();
			this.dgvImages = new System.Windows.Forms.DataGridView();
			this.fileID = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.width = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.height = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.vertDisplace = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.horizStretch = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.flags = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.scrollSpeed = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.unknown = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.tabControl1.SuspendLayout();
			this.tabPage1.SuspendLayout();
			this.tabPage2.SuspendLayout();
			this.tabPage3.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.dgvImages)).BeginInit();
			this.SuspendLayout();
			// 
			// tabControl1
			// 
			this.tabControl1.Controls.Add(this.tabPage1);
			this.tabControl1.Controls.Add(this.tabPage2);
			this.tabControl1.Controls.Add(this.tabPage3);
			this.tabControl1.Location = new System.Drawing.Point(12, 12);
			this.tabControl1.Name = "tabControl1";
			this.tabControl1.SelectedIndex = 0;
			this.tabControl1.Size = new System.Drawing.Size(568, 320);
			this.tabControl1.TabIndex = 0;
			// 
			// tabPage1
			// 
			this.tabPage1.Controls.Add(this.tbAnimations);
			this.tabPage1.Location = new System.Drawing.Point(4, 22);
			this.tabPage1.Name = "tabPage1";
			this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
			this.tabPage1.Size = new System.Drawing.Size(560, 294);
			this.tabPage1.TabIndex = 0;
			this.tabPage1.Text = "Animations";
			this.tabPage1.UseVisualStyleBackColor = true;
			// 
			// tbAnimations
			// 
			this.tbAnimations.Font = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.tbAnimations.Location = new System.Drawing.Point(6, 6);
			this.tbAnimations.Multiline = true;
			this.tbAnimations.Name = "tbAnimations";
			this.tbAnimations.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			this.tbAnimations.Size = new System.Drawing.Size(548, 282);
			this.tbAnimations.TabIndex = 0;
			// 
			// tabPage2
			// 
			this.tabPage2.Controls.Add(this.dgvImages);
			this.tabPage2.Controls.Add(this.tbImages);
			this.tabPage2.Location = new System.Drawing.Point(4, 22);
			this.tabPage2.Name = "tabPage2";
			this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
			this.tabPage2.Size = new System.Drawing.Size(560, 294);
			this.tabPage2.TabIndex = 1;
			this.tabPage2.Text = "Images";
			this.tabPage2.UseVisualStyleBackColor = true;
			// 
			// tbImages
			// 
			this.tbImages.Font = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.tbImages.Location = new System.Drawing.Point(6, 6);
			this.tbImages.Multiline = true;
			this.tbImages.Name = "tbImages";
			this.tbImages.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			this.tbImages.Size = new System.Drawing.Size(548, 108);
			this.tbImages.TabIndex = 0;
			// 
			// tabPage3
			// 
			this.tabPage3.Controls.Add(this.tbSequence);
			this.tabPage3.Location = new System.Drawing.Point(4, 22);
			this.tabPage3.Name = "tabPage3";
			this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
			this.tabPage3.Size = new System.Drawing.Size(560, 294);
			this.tabPage3.TabIndex = 2;
			this.tabPage3.Text = "Sequence";
			this.tabPage3.UseVisualStyleBackColor = true;
			// 
			// tbSequence
			// 
			this.tbSequence.Font = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.tbSequence.Location = new System.Drawing.Point(6, 6);
			this.tbSequence.Multiline = true;
			this.tbSequence.Name = "tbSequence";
			this.tbSequence.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			this.tbSequence.Size = new System.Drawing.Size(548, 282);
			this.tbSequence.TabIndex = 0;
			// 
			// buttonOK
			// 
			this.buttonOK.Location = new System.Drawing.Point(424, 338);
			this.buttonOK.Name = "buttonOK";
			this.buttonOK.Size = new System.Drawing.Size(75, 23);
			this.buttonOK.TabIndex = 1;
			this.buttonOK.Text = "&OK";
			this.buttonOK.UseVisualStyleBackColor = true;
			this.buttonOK.Click += new System.EventHandler(this.buttonOK_Click);
			// 
			// buttonCancel
			// 
			this.buttonCancel.Location = new System.Drawing.Point(505, 338);
			this.buttonCancel.Name = "buttonCancel";
			this.buttonCancel.Size = new System.Drawing.Size(75, 23);
			this.buttonCancel.TabIndex = 2;
			this.buttonCancel.Text = "&Cancel";
			this.buttonCancel.UseVisualStyleBackColor = true;
			this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
			// 
			// dgvImages
			// 
			this.dgvImages.AllowUserToAddRows = false;
			this.dgvImages.AllowUserToDeleteRows = false;
			this.dgvImages.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.ColumnHeader;
			this.dgvImages.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.EnableWithoutHeaderText;
			this.dgvImages.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dgvImages.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.fileID,
            this.width,
            this.height,
            this.vertDisplace,
            this.horizStretch,
            this.flags,
            this.scrollSpeed,
            this.unknown});
			this.dgvImages.Location = new System.Drawing.Point(6, 120);
			this.dgvImages.MultiSelect = false;
			this.dgvImages.Name = "dgvImages";
			this.dgvImages.RowHeadersVisible = false;
			this.dgvImages.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
			this.dgvImages.ShowEditingIcon = false;
			this.dgvImages.Size = new System.Drawing.Size(548, 168);
			this.dgvImages.TabIndex = 1;
			// 
			// fileID
			// 
			this.fileID.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
			this.fileID.HeaderText = "File ID";
			this.fileID.MaxInputLength = 4;
			this.fileID.Name = "fileID";
			this.fileID.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
			this.fileID.ToolTipText = "File ID (hex)";
			this.fileID.Width = 43;
			// 
			// width
			// 
			this.width.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
			this.width.HeaderText = "Width";
			this.width.Name = "width";
			this.width.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
			this.width.ToolTipText = "Image Width";
			this.width.Width = 41;
			// 
			// height
			// 
			this.height.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
			this.height.HeaderText = "Height";
			this.height.Name = "height";
			this.height.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
			this.height.ToolTipText = "Image Height";
			this.height.Width = 44;
			// 
			// vertDisplace
			// 
			this.vertDisplace.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
			this.vertDisplace.HeaderText = "Vertical Displacement";
			this.vertDisplace.Name = "vertDisplace";
			this.vertDisplace.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
			this.vertDisplace.Width = 104;
			// 
			// horizStretch
			// 
			this.horizStretch.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
			this.horizStretch.HeaderText = "Horiz. Stretch";
			this.horizStretch.Name = "horizStretch";
			this.horizStretch.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
			this.horizStretch.Width = 69;
			// 
			// flags
			// 
			this.flags.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
			this.flags.HeaderText = "Flags";
			this.flags.MaxInputLength = 4;
			this.flags.Name = "flags";
			this.flags.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
			this.flags.Width = 38;
			// 
			// scrollSpeed
			// 
			this.scrollSpeed.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
			this.scrollSpeed.HeaderText = "Scroll Speed";
			this.scrollSpeed.Name = "scrollSpeed";
			this.scrollSpeed.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
			this.scrollSpeed.Width = 66;
			// 
			// unknown
			// 
			this.unknown.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
			this.unknown.HeaderText = "Unknown";
			this.unknown.Name = "unknown";
			this.unknown.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
			this.unknown.Width = 59;
			// 
			// GameIntroEditor_Later
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(592, 373);
			this.Controls.Add(this.buttonCancel);
			this.Controls.Add(this.buttonOK);
			this.Controls.Add(this.tabControl1);
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "GameIntroEditor_Later";
			this.Text = "Game Introduction Editor";
			this.tabControl1.ResumeLayout(false);
			this.tabPage1.ResumeLayout(false);
			this.tabPage1.PerformLayout();
			this.tabPage2.ResumeLayout(false);
			this.tabPage2.PerformLayout();
			this.tabPage3.ResumeLayout(false);
			this.tabPage3.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.dgvImages)).EndInit();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.TabControl tabControl1;
		private System.Windows.Forms.TabPage tabPage1;
		private System.Windows.Forms.TabPage tabPage2;
		private System.Windows.Forms.TabPage tabPage3;
		private System.Windows.Forms.Button buttonOK;
		private System.Windows.Forms.Button buttonCancel;
		private System.Windows.Forms.TextBox tbAnimations;
		private System.Windows.Forms.TextBox tbImages;
		private System.Windows.Forms.TextBox tbSequence;
		private System.Windows.Forms.DataGridView dgvImages;
		private System.Windows.Forms.DataGridViewTextBoxColumn fileID;
		private System.Windows.Forms.DataGridViewTextBoxColumn width;
		private System.Windows.Forms.DataGridViewTextBoxColumn height;
		private System.Windows.Forms.DataGridViewTextBoxColumn vertDisplace;
		private System.Windows.Forms.DataGridViewTextBoxColumn horizStretch;
		private System.Windows.Forms.DataGridViewTextBoxColumn flags;
		private System.Windows.Forms.DataGridViewTextBoxColumn scrollSpeed;
		private System.Windows.Forms.DataGridViewTextBoxColumn unknown;
	}
}