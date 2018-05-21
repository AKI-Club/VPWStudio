namespace VPWStudio
{
	partial class AnimTest
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
			this.cbFrames = new System.Windows.Forms.ComboBox();
			this.labelFrame = new System.Windows.Forms.Label();
			this.gbToki2 = new System.Windows.Forms.GroupBox();
			this.tbToki2 = new System.Windows.Forms.TextBox();
			this.dgvFrameData = new System.Windows.Forms.DataGridView();
			this.ItemName = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.Value1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.Value2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.Value3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.gbToki2.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.dgvFrameData)).BeginInit();
			this.SuspendLayout();
			// 
			// cbFrames
			// 
			this.cbFrames.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cbFrames.FormattingEnabled = true;
			this.cbFrames.Location = new System.Drawing.Point(259, 31);
			this.cbFrames.Name = "cbFrames";
			this.cbFrames.Size = new System.Drawing.Size(311, 21);
			this.cbFrames.TabIndex = 0;
			this.cbFrames.SelectedIndexChanged += new System.EventHandler(this.cbFrames_SelectedIndexChanged);
			// 
			// labelFrame
			// 
			this.labelFrame.AutoSize = true;
			this.labelFrame.Location = new System.Drawing.Point(218, 34);
			this.labelFrame.Name = "labelFrame";
			this.labelFrame.Size = new System.Drawing.Size(36, 13);
			this.labelFrame.TabIndex = 1;
			this.labelFrame.Text = "Frame";
			// 
			// gbToki2
			// 
			this.gbToki2.Controls.Add(this.tbToki2);
			this.gbToki2.Location = new System.Drawing.Point(12, 12);
			this.gbToki2.Name = "gbToki2";
			this.gbToki2.Size = new System.Drawing.Size(200, 50);
			this.gbToki2.TabIndex = 2;
			this.gbToki2.TabStop = false;
			this.gbToki2.Text = "Toki2 Values";
			// 
			// tbToki2
			// 
			this.tbToki2.Location = new System.Drawing.Point(6, 19);
			this.tbToki2.Name = "tbToki2";
			this.tbToki2.ReadOnly = true;
			this.tbToki2.Size = new System.Drawing.Size(188, 20);
			this.tbToki2.TabIndex = 3;
			// 
			// dgvFrameData
			// 
			this.dgvFrameData.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dgvFrameData.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ItemName,
            this.Value1,
            this.Value2,
            this.Value3});
			this.dgvFrameData.Location = new System.Drawing.Point(12, 68);
			this.dgvFrameData.Name = "dgvFrameData";
			this.dgvFrameData.Size = new System.Drawing.Size(558, 307);
			this.dgvFrameData.TabIndex = 3;
			// 
			// ItemName
			// 
			this.ItemName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
			this.ItemName.HeaderText = "Name";
			this.ItemName.Name = "ItemName";
			// 
			// Value1
			// 
			this.Value1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
			this.Value1.HeaderText = "Value 1";
			this.Value1.Name = "Value1";
			// 
			// Value2
			// 
			this.Value2.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
			this.Value2.HeaderText = "Value 2";
			this.Value2.Name = "Value2";
			// 
			// Value3
			// 
			this.Value3.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
			this.Value3.HeaderText = "Value 3";
			this.Value3.Name = "Value3";
			// 
			// AnimTest
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(582, 387);
			this.Controls.Add(this.dgvFrameData);
			this.Controls.Add(this.gbToki2);
			this.Controls.Add(this.labelFrame);
			this.Controls.Add(this.cbFrames);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.MaximizeBox = false;
			this.Name = "AnimTest";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "AnimTest";
			this.gbToki2.ResumeLayout(false);
			this.gbToki2.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.dgvFrameData)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.ComboBox cbFrames;
		private System.Windows.Forms.Label labelFrame;
		private System.Windows.Forms.GroupBox gbToki2;
		private System.Windows.Forms.TextBox tbToki2;
		private System.Windows.Forms.DataGridView dgvFrameData;
		private System.Windows.Forms.DataGridViewTextBoxColumn ItemName;
		private System.Windows.Forms.DataGridViewTextBoxColumn Value1;
		private System.Windows.Forms.DataGridViewTextBoxColumn Value2;
		private System.Windows.Forms.DataGridViewTextBoxColumn Value3;
	}
}