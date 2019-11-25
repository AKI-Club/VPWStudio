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
			this.tabPage2 = new System.Windows.Forms.TabPage();
			this.tabPage3 = new System.Windows.Forms.TabPage();
			this.buttonOK = new System.Windows.Forms.Button();
			this.buttonCancel = new System.Windows.Forms.Button();
			this.dgvImages = new System.Windows.Forms.DataGridView();
			this.dgvAnimations = new System.Windows.Forms.DataGridView();
			this.dgvSequence = new System.Windows.Forms.DataGridView();
			this.fileID = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.width = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.height = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.vertDisplace = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.horizStretch = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.imageFlags = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.scrollSpeed = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.imgUnknown = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.wrestlerID4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.timingA = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.animID = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.timingB = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.xPos = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.yPos = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.zPos = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.rotation = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.animFlags = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.moveSpeed = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.animUnknown = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.costume = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.mainSequence = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.subSequence = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.seqFlags = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.transition = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.sceneTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.cameraMotion = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.seqUnknown = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.stageNum = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.pointer1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.pointer2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.pointer3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.pointer4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.tabControl1.SuspendLayout();
			this.tabPage1.SuspendLayout();
			this.tabPage2.SuspendLayout();
			this.tabPage3.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.dgvImages)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.dgvAnimations)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.dgvSequence)).BeginInit();
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
			this.tabControl1.Size = new System.Drawing.Size(730, 362);
			this.tabControl1.TabIndex = 0;
			// 
			// tabPage1
			// 
			this.tabPage1.Controls.Add(this.dgvAnimations);
			this.tabPage1.Location = new System.Drawing.Point(4, 22);
			this.tabPage1.Name = "tabPage1";
			this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
			this.tabPage1.Size = new System.Drawing.Size(722, 336);
			this.tabPage1.TabIndex = 0;
			this.tabPage1.Text = "Animations";
			this.tabPage1.UseVisualStyleBackColor = true;
			// 
			// tabPage2
			// 
			this.tabPage2.Controls.Add(this.dgvImages);
			this.tabPage2.Location = new System.Drawing.Point(4, 22);
			this.tabPage2.Name = "tabPage2";
			this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
			this.tabPage2.Size = new System.Drawing.Size(722, 336);
			this.tabPage2.TabIndex = 1;
			this.tabPage2.Text = "Images";
			this.tabPage2.UseVisualStyleBackColor = true;
			// 
			// tabPage3
			// 
			this.tabPage3.Controls.Add(this.dgvSequence);
			this.tabPage3.Location = new System.Drawing.Point(4, 22);
			this.tabPage3.Name = "tabPage3";
			this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
			this.tabPage3.Size = new System.Drawing.Size(722, 336);
			this.tabPage3.TabIndex = 2;
			this.tabPage3.Text = "Sequence";
			this.tabPage3.UseVisualStyleBackColor = true;
			// 
			// buttonOK
			// 
			this.buttonOK.Location = new System.Drawing.Point(586, 380);
			this.buttonOK.Name = "buttonOK";
			this.buttonOK.Size = new System.Drawing.Size(75, 23);
			this.buttonOK.TabIndex = 1;
			this.buttonOK.Text = "&OK";
			this.buttonOK.UseVisualStyleBackColor = true;
			this.buttonOK.Click += new System.EventHandler(this.buttonOK_Click);
			// 
			// buttonCancel
			// 
			this.buttonCancel.Location = new System.Drawing.Point(667, 380);
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
			this.dgvImages.AllowUserToResizeRows = false;
			this.dgvImages.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.ColumnHeader;
			this.dgvImages.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.EnableWithoutHeaderText;
			this.dgvImages.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dgvImages.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.fileID,
            this.width,
            this.height,
            this.vertDisplace,
            this.horizStretch,
            this.imageFlags,
            this.scrollSpeed,
            this.imgUnknown});
			this.dgvImages.Location = new System.Drawing.Point(6, 6);
			this.dgvImages.MultiSelect = false;
			this.dgvImages.Name = "dgvImages";
			this.dgvImages.RowHeadersVisible = false;
			this.dgvImages.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
			this.dgvImages.ShowEditingIcon = false;
			this.dgvImages.Size = new System.Drawing.Size(710, 324);
			this.dgvImages.TabIndex = 1;
			this.dgvImages.CellValidating += new System.Windows.Forms.DataGridViewCellValidatingEventHandler(this.dgvImages_CellValidating);
			// 
			// dgvAnimations
			// 
			this.dgvAnimations.AllowUserToAddRows = false;
			this.dgvAnimations.AllowUserToDeleteRows = false;
			this.dgvAnimations.AllowUserToResizeRows = false;
			this.dgvAnimations.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.EnableWithoutHeaderText;
			this.dgvAnimations.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dgvAnimations.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.wrestlerID4,
            this.timingA,
            this.animID,
            this.timingB,
            this.xPos,
            this.yPos,
            this.zPos,
            this.rotation,
            this.animFlags,
            this.moveSpeed,
            this.animUnknown,
            this.costume});
			this.dgvAnimations.Location = new System.Drawing.Point(3, 6);
			this.dgvAnimations.MultiSelect = false;
			this.dgvAnimations.Name = "dgvAnimations";
			this.dgvAnimations.RowHeadersVisible = false;
			this.dgvAnimations.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
			this.dgvAnimations.Size = new System.Drawing.Size(713, 324);
			this.dgvAnimations.TabIndex = 1;
			this.dgvAnimations.CellValidating += new System.Windows.Forms.DataGridViewCellValidatingEventHandler(this.dgvAnimations_CellValidating);
			// 
			// dgvSequence
			// 
			this.dgvSequence.AllowUserToAddRows = false;
			this.dgvSequence.AllowUserToDeleteRows = false;
			this.dgvSequence.AllowUserToResizeRows = false;
			this.dgvSequence.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.EnableWithoutHeaderText;
			this.dgvSequence.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dgvSequence.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.mainSequence,
            this.subSequence,
            this.seqFlags,
            this.transition,
            this.sceneTime,
            this.cameraMotion,
            this.seqUnknown,
            this.stageNum,
            this.pointer1,
            this.pointer2,
            this.pointer3,
            this.pointer4});
			this.dgvSequence.Location = new System.Drawing.Point(6, 6);
			this.dgvSequence.Name = "dgvSequence";
			this.dgvSequence.RowHeadersVisible = false;
			this.dgvSequence.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
			this.dgvSequence.Size = new System.Drawing.Size(710, 324);
			this.dgvSequence.TabIndex = 1;
			this.dgvSequence.CellValidating += new System.Windows.Forms.DataGridViewCellValidatingEventHandler(this.dgvSequence_CellValidating);
			// 
			// fileID
			// 
			this.fileID.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
			this.fileID.FillWeight = 20F;
			this.fileID.HeaderText = "File ID";
			this.fileID.MaxInputLength = 4;
			this.fileID.Name = "fileID";
			this.fileID.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
			this.fileID.ToolTipText = "File ID (hex)";
			// 
			// width
			// 
			this.width.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
			this.width.FillWeight = 20F;
			this.width.HeaderText = "Width";
			this.width.Name = "width";
			this.width.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
			this.width.ToolTipText = "Image Width";
			this.width.Width = 41;
			// 
			// height
			// 
			this.height.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
			this.height.FillWeight = 20F;
			this.height.HeaderText = "Height";
			this.height.Name = "height";
			this.height.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
			this.height.ToolTipText = "Image Height";
			this.height.Width = 44;
			// 
			// vertDisplace
			// 
			this.vertDisplace.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
			this.vertDisplace.FillWeight = 40F;
			this.vertDisplace.HeaderText = "Vertical Displacement";
			this.vertDisplace.Name = "vertDisplace";
			this.vertDisplace.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
			this.vertDisplace.Width = 115;
			// 
			// horizStretch
			// 
			this.horizStretch.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
			this.horizStretch.FillWeight = 30F;
			this.horizStretch.HeaderText = "Horiz. Stretch";
			this.horizStretch.Name = "horizStretch";
			this.horizStretch.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
			this.horizStretch.Width = 77;
			// 
			// imageFlags
			// 
			this.imageFlags.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
			this.imageFlags.FillWeight = 20F;
			this.imageFlags.HeaderText = "Flags";
			this.imageFlags.MaxInputLength = 4;
			this.imageFlags.Name = "imageFlags";
			this.imageFlags.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
			this.imageFlags.Width = 38;
			// 
			// scrollSpeed
			// 
			this.scrollSpeed.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
			this.scrollSpeed.FillWeight = 20F;
			this.scrollSpeed.HeaderText = "Scroll Speed";
			this.scrollSpeed.Name = "scrollSpeed";
			this.scrollSpeed.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
			this.scrollSpeed.Width = 73;
			// 
			// imgUnknown
			// 
			this.imgUnknown.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
			this.imgUnknown.FillWeight = 20F;
			this.imgUnknown.HeaderText = "Unknown";
			this.imgUnknown.Name = "imgUnknown";
			this.imgUnknown.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
			this.imgUnknown.Width = 59;
			// 
			// wrestlerID4
			// 
			this.wrestlerID4.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
			this.wrestlerID4.HeaderText = "Wrestler ID4";
			this.wrestlerID4.MaxInputLength = 4;
			this.wrestlerID4.Name = "wrestlerID4";
			this.wrestlerID4.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
			this.wrestlerID4.Width = 72;
			// 
			// timingA
			// 
			this.timingA.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
			this.timingA.HeaderText = "Timing A";
			this.timingA.Name = "timingA";
			this.timingA.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
			this.timingA.Width = 54;
			// 
			// animID
			// 
			this.animID.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
			this.animID.HeaderText = "Animation ID";
			this.animID.Name = "animID";
			this.animID.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
			this.animID.Width = 73;
			// 
			// timingB
			// 
			this.timingB.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
			this.timingB.HeaderText = "Timing B";
			this.timingB.Name = "timingB";
			this.timingB.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
			this.timingB.Width = 54;
			// 
			// xPos
			// 
			this.xPos.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
			this.xPos.HeaderText = "X Pos.";
			this.xPos.Name = "xPos";
			this.xPos.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
			this.xPos.Width = 44;
			// 
			// yPos
			// 
			this.yPos.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
			this.yPos.HeaderText = "Y Pos.";
			this.yPos.Name = "yPos";
			this.yPos.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
			this.yPos.Width = 44;
			// 
			// zPos
			// 
			this.zPos.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
			this.zPos.HeaderText = "Z Pos.";
			this.zPos.Name = "zPos";
			this.zPos.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
			this.zPos.Width = 44;
			// 
			// rotation
			// 
			this.rotation.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
			this.rotation.HeaderText = "Rotation";
			this.rotation.Name = "rotation";
			this.rotation.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
			this.rotation.Width = 53;
			// 
			// animFlags
			// 
			this.animFlags.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
			this.animFlags.HeaderText = "Flags";
			this.animFlags.Name = "animFlags";
			this.animFlags.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
			this.animFlags.Width = 38;
			// 
			// moveSpeed
			// 
			this.moveSpeed.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
			this.moveSpeed.HeaderText = "Move Speed";
			this.moveSpeed.Name = "moveSpeed";
			this.moveSpeed.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
			this.moveSpeed.Width = 74;
			// 
			// animUnknown
			// 
			this.animUnknown.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
			this.animUnknown.HeaderText = "Unknown";
			this.animUnknown.Name = "animUnknown";
			this.animUnknown.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
			this.animUnknown.Width = 59;
			// 
			// costume
			// 
			this.costume.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
			this.costume.HeaderText = "Costume";
			this.costume.Name = "costume";
			this.costume.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
			this.costume.Width = 54;
			// 
			// mainSequence
			// 
			this.mainSequence.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
			this.mainSequence.FillWeight = 15F;
			this.mainSequence.HeaderText = "Sequence";
			this.mainSequence.Name = "mainSequence";
			this.mainSequence.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
			this.mainSequence.Width = 62;
			// 
			// subSequence
			// 
			this.subSequence.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
			this.subSequence.FillWeight = 15F;
			this.subSequence.HeaderText = "Sub-Seq.";
			this.subSequence.Name = "subSequence";
			this.subSequence.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
			this.subSequence.Width = 57;
			// 
			// seqFlags
			// 
			this.seqFlags.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
			this.seqFlags.FillWeight = 10F;
			this.seqFlags.HeaderText = "Flags";
			this.seqFlags.Name = "seqFlags";
			this.seqFlags.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
			this.seqFlags.Width = 38;
			// 
			// transition
			// 
			this.transition.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
			this.transition.FillWeight = 10F;
			this.transition.HeaderText = "Transition";
			this.transition.Name = "transition";
			this.transition.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
			this.transition.Width = 59;
			// 
			// sceneTime
			// 
			this.sceneTime.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
			this.sceneTime.FillWeight = 10F;
			this.sceneTime.HeaderText = "Scene Time";
			this.sceneTime.Name = "sceneTime";
			this.sceneTime.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
			this.sceneTime.Width = 70;
			// 
			// cameraMotion
			// 
			this.cameraMotion.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
			this.cameraMotion.FillWeight = 10F;
			this.cameraMotion.HeaderText = "Camera";
			this.cameraMotion.Name = "cameraMotion";
			this.cameraMotion.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
			this.cameraMotion.Width = 49;
			// 
			// seqUnknown
			// 
			this.seqUnknown.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
			this.seqUnknown.FillWeight = 10F;
			this.seqUnknown.HeaderText = "Unknown";
			this.seqUnknown.Name = "seqUnknown";
			this.seqUnknown.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
			this.seqUnknown.Width = 59;
			// 
			// stageNum
			// 
			this.stageNum.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
			this.stageNum.FillWeight = 10F;
			this.stageNum.HeaderText = "Stage";
			this.stageNum.Name = "stageNum";
			this.stageNum.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
			this.stageNum.Width = 41;
			// 
			// pointer1
			// 
			this.pointer1.FillWeight = 20F;
			this.pointer1.HeaderText = "Pointer 1";
			this.pointer1.MaxInputLength = 8;
			this.pointer1.Name = "pointer1";
			this.pointer1.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
			this.pointer1.Width = 64;
			// 
			// pointer2
			// 
			this.pointer2.FillWeight = 20F;
			this.pointer2.HeaderText = "Pointer 2";
			this.pointer2.MaxInputLength = 8;
			this.pointer2.Name = "pointer2";
			this.pointer2.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
			this.pointer2.Width = 64;
			// 
			// pointer3
			// 
			this.pointer3.FillWeight = 20F;
			this.pointer3.HeaderText = "Pointer 3";
			this.pointer3.MaxInputLength = 8;
			this.pointer3.Name = "pointer3";
			this.pointer3.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
			this.pointer3.Width = 64;
			// 
			// pointer4
			// 
			this.pointer4.FillWeight = 20F;
			this.pointer4.HeaderText = "Pointer 4";
			this.pointer4.MaxInputLength = 8;
			this.pointer4.Name = "pointer4";
			this.pointer4.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
			this.pointer4.Width = 64;
			// 
			// GameIntroEditor_Later
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(754, 415);
			this.Controls.Add(this.buttonCancel);
			this.Controls.Add(this.buttonOK);
			this.Controls.Add(this.tabControl1);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "GameIntroEditor_Later";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "Game Introduction Editor";
			this.tabControl1.ResumeLayout(false);
			this.tabPage1.ResumeLayout(false);
			this.tabPage2.ResumeLayout(false);
			this.tabPage3.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.dgvImages)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.dgvAnimations)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.dgvSequence)).EndInit();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.TabControl tabControl1;
		private System.Windows.Forms.TabPage tabPage1;
		private System.Windows.Forms.TabPage tabPage2;
		private System.Windows.Forms.TabPage tabPage3;
		private System.Windows.Forms.Button buttonOK;
		private System.Windows.Forms.Button buttonCancel;
		private System.Windows.Forms.DataGridView dgvImages;
		private System.Windows.Forms.DataGridView dgvAnimations;
		private System.Windows.Forms.DataGridView dgvSequence;
		private System.Windows.Forms.DataGridViewTextBoxColumn fileID;
		private System.Windows.Forms.DataGridViewTextBoxColumn width;
		private System.Windows.Forms.DataGridViewTextBoxColumn height;
		private System.Windows.Forms.DataGridViewTextBoxColumn vertDisplace;
		private System.Windows.Forms.DataGridViewTextBoxColumn horizStretch;
		private System.Windows.Forms.DataGridViewTextBoxColumn imageFlags;
		private System.Windows.Forms.DataGridViewTextBoxColumn scrollSpeed;
		private System.Windows.Forms.DataGridViewTextBoxColumn imgUnknown;
		private System.Windows.Forms.DataGridViewTextBoxColumn wrestlerID4;
		private System.Windows.Forms.DataGridViewTextBoxColumn timingA;
		private System.Windows.Forms.DataGridViewTextBoxColumn animID;
		private System.Windows.Forms.DataGridViewTextBoxColumn timingB;
		private System.Windows.Forms.DataGridViewTextBoxColumn xPos;
		private System.Windows.Forms.DataGridViewTextBoxColumn yPos;
		private System.Windows.Forms.DataGridViewTextBoxColumn zPos;
		private System.Windows.Forms.DataGridViewTextBoxColumn rotation;
		private System.Windows.Forms.DataGridViewTextBoxColumn animFlags;
		private System.Windows.Forms.DataGridViewTextBoxColumn moveSpeed;
		private System.Windows.Forms.DataGridViewTextBoxColumn animUnknown;
		private System.Windows.Forms.DataGridViewTextBoxColumn costume;
		private System.Windows.Forms.DataGridViewTextBoxColumn mainSequence;
		private System.Windows.Forms.DataGridViewTextBoxColumn subSequence;
		private System.Windows.Forms.DataGridViewTextBoxColumn seqFlags;
		private System.Windows.Forms.DataGridViewTextBoxColumn transition;
		private System.Windows.Forms.DataGridViewTextBoxColumn sceneTime;
		private System.Windows.Forms.DataGridViewTextBoxColumn cameraMotion;
		private System.Windows.Forms.DataGridViewTextBoxColumn seqUnknown;
		private System.Windows.Forms.DataGridViewTextBoxColumn stageNum;
		private System.Windows.Forms.DataGridViewTextBoxColumn pointer1;
		private System.Windows.Forms.DataGridViewTextBoxColumn pointer2;
		private System.Windows.Forms.DataGridViewTextBoxColumn pointer3;
		private System.Windows.Forms.DataGridViewTextBoxColumn pointer4;
	}
}