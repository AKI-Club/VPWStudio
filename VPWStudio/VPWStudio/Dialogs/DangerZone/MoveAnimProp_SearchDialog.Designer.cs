namespace VPWStudio
{
	partial class MoveAnimProp_SearchDialog
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
			this.lblNumber = new System.Windows.Forms.Label();
			this.nudSearchNum = new System.Windows.Forms.NumericUpDown();
			this.gbSearchType = new System.Windows.Forms.GroupBox();
			this.rbDamageIndex = new System.Windows.Forms.RadioButton();
			this.rbAnimOffset = new System.Windows.Forms.RadioButton();
			this.rbAnimID = new System.Windows.Forms.RadioButton();
			this.btnOK = new System.Windows.Forms.Button();
			this.btnCancel = new System.Windows.Forms.Button();
			this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
			((System.ComponentModel.ISupportInitialize)(this.nudSearchNum)).BeginInit();
			this.gbSearchType.SuspendLayout();
			this.flowLayoutPanel1.SuspendLayout();
			this.SuspendLayout();
			// 
			// lblNumber
			// 
			this.lblNumber.AutoSize = true;
			this.lblNumber.Location = new System.Drawing.Point(12, 14);
			this.lblNumber.Name = "lblNumber";
			this.lblNumber.Size = new System.Drawing.Size(34, 13);
			this.lblNumber.TabIndex = 0;
			this.lblNumber.Text = "&Value";
			// 
			// nudSearchNum
			// 
			this.nudSearchNum.Hexadecimal = true;
			this.nudSearchNum.Location = new System.Drawing.Point(52, 12);
			this.nudSearchNum.Maximum = new decimal(new int[] {
            65535,
            0,
            0,
            0});
			this.nudSearchNum.Name = "nudSearchNum";
			this.nudSearchNum.Size = new System.Drawing.Size(260, 20);
			this.nudSearchNum.TabIndex = 1;
			// 
			// gbSearchType
			// 
			this.gbSearchType.Controls.Add(this.flowLayoutPanel1);
			this.gbSearchType.Location = new System.Drawing.Point(12, 38);
			this.gbSearchType.Name = "gbSearchType";
			this.gbSearchType.Size = new System.Drawing.Size(300, 47);
			this.gbSearchType.TabIndex = 2;
			this.gbSearchType.TabStop = false;
			this.gbSearchType.Text = "&Search Type";
			// 
			// rbDamageIndex
			// 
			this.rbDamageIndex.AutoSize = true;
			this.rbDamageIndex.Location = new System.Drawing.Point(181, 3);
			this.rbDamageIndex.Name = "rbDamageIndex";
			this.rbDamageIndex.Size = new System.Drawing.Size(94, 17);
			this.rbDamageIndex.TabIndex = 2;
			this.rbDamageIndex.Text = "&Damage Index";
			this.rbDamageIndex.UseVisualStyleBackColor = true;
			// 
			// rbAnimOffset
			// 
			this.rbAnimOffset.AutoSize = true;
			this.rbAnimOffset.Location = new System.Drawing.Point(93, 3);
			this.rbAnimOffset.Name = "rbAnimOffset";
			this.rbAnimOffset.Size = new System.Drawing.Size(82, 17);
			this.rbAnimOffset.TabIndex = 1;
			this.rbAnimOffset.Text = "Anim. O&ffset";
			this.rbAnimOffset.UseVisualStyleBackColor = true;
			// 
			// rbAnimID
			// 
			this.rbAnimID.AutoSize = true;
			this.rbAnimID.Checked = true;
			this.rbAnimID.Location = new System.Drawing.Point(3, 3);
			this.rbAnimID.Name = "rbAnimID";
			this.rbAnimID.Size = new System.Drawing.Size(84, 17);
			this.rbAnimID.TabIndex = 0;
			this.rbAnimID.TabStop = true;
			this.rbAnimID.Text = "Anim. File &ID";
			this.rbAnimID.UseVisualStyleBackColor = true;
			// 
			// btnOK
			// 
			this.btnOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.btnOK.Location = new System.Drawing.Point(12, 91);
			this.btnOK.Name = "btnOK";
			this.btnOK.Size = new System.Drawing.Size(146, 23);
			this.btnOK.TabIndex = 3;
			this.btnOK.Text = "&OK";
			this.btnOK.UseVisualStyleBackColor = true;
			this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
			// 
			// btnCancel
			// 
			this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.btnCancel.Location = new System.Drawing.Point(166, 91);
			this.btnCancel.Name = "btnCancel";
			this.btnCancel.Size = new System.Drawing.Size(146, 23);
			this.btnCancel.TabIndex = 4;
			this.btnCancel.Text = "&Cancel";
			this.btnCancel.UseVisualStyleBackColor = true;
			this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
			// 
			// flowLayoutPanel1
			// 
			this.flowLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.flowLayoutPanel1.Controls.Add(this.rbAnimID);
			this.flowLayoutPanel1.Controls.Add(this.rbAnimOffset);
			this.flowLayoutPanel1.Controls.Add(this.rbDamageIndex);
			this.flowLayoutPanel1.Location = new System.Drawing.Point(6, 19);
			this.flowLayoutPanel1.Name = "flowLayoutPanel1";
			this.flowLayoutPanel1.Size = new System.Drawing.Size(288, 22);
			this.flowLayoutPanel1.TabIndex = 3;
			// 
			// MoveAnimProp_SearchDialog
			// 
			this.AcceptButton = this.btnOK;
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.CancelButton = this.btnCancel;
			this.ClientSize = new System.Drawing.Size(324, 126);
			this.Controls.Add(this.btnCancel);
			this.Controls.Add(this.btnOK);
			this.Controls.Add(this.gbSearchType);
			this.Controls.Add(this.nudSearchNum);
			this.Controls.Add(this.lblNumber);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "MoveAnimProp_SearchDialog";
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "Search Move Animation/Properties";
			((System.ComponentModel.ISupportInitialize)(this.nudSearchNum)).EndInit();
			this.gbSearchType.ResumeLayout(false);
			this.flowLayoutPanel1.ResumeLayout(false);
			this.flowLayoutPanel1.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Label lblNumber;
		private System.Windows.Forms.NumericUpDown nudSearchNum;
		private System.Windows.Forms.GroupBox gbSearchType;
		private System.Windows.Forms.RadioButton rbDamageIndex;
		private System.Windows.Forms.RadioButton rbAnimOffset;
		private System.Windows.Forms.RadioButton rbAnimID;
		private System.Windows.Forms.Button btnOK;
		private System.Windows.Forms.Button btnCancel;
		private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
	}
}