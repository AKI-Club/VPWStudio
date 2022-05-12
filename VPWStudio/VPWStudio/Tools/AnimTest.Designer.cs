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
			this.menuStrip1 = new System.Windows.Forms.MenuStrip();
			this.copyHexToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.tlpFrame = new System.Windows.Forms.TableLayoutPanel();
			this.gbToki1 = new System.Windows.Forms.GroupBox();
			this.tbToki1Index = new System.Windows.Forms.TextBox();
			this.btnViewToki1 = new System.Windows.Forms.Button();
			this.gbToki2.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.dgvFrameData)).BeginInit();
			this.menuStrip1.SuspendLayout();
			this.tlpFrame.SuspendLayout();
			this.gbToki1.SuspendLayout();
			this.SuspendLayout();
			// 
			// cbFrames
			// 
			this.cbFrames.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
			this.cbFrames.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cbFrames.FormattingEnabled = true;
			this.cbFrames.Location = new System.Drawing.Point(53, 4);
			this.cbFrames.Name = "cbFrames";
			this.cbFrames.Size = new System.Drawing.Size(144, 21);
			this.cbFrames.TabIndex = 6;
			this.cbFrames.SelectedIndexChanged += new System.EventHandler(this.cbFrames_SelectedIndexChanged);
			// 
			// labelFrame
			// 
			this.labelFrame.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
			this.labelFrame.AutoSize = true;
			this.labelFrame.Location = new System.Drawing.Point(3, 8);
			this.labelFrame.Name = "labelFrame";
			this.labelFrame.Size = new System.Drawing.Size(44, 13);
			this.labelFrame.TabIndex = 5;
			this.labelFrame.Text = "&Frame";
			// 
			// gbToki2
			// 
			this.gbToki2.Anchor = System.Windows.Forms.AnchorStyles.Top;
			this.gbToki2.Controls.Add(this.tbToki2);
			this.gbToki2.Location = new System.Drawing.Point(177, 27);
			this.gbToki2.Name = "gbToki2";
			this.gbToki2.Size = new System.Drawing.Size(188, 50);
			this.gbToki2.TabIndex = 2;
			this.gbToki2.TabStop = false;
			this.gbToki2.Text = "Toki2 &Values";
			// 
			// tbToki2
			// 
			this.tbToki2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
			this.tbToki2.Location = new System.Drawing.Point(6, 19);
			this.tbToki2.Name = "tbToki2";
			this.tbToki2.ReadOnly = true;
			this.tbToki2.Size = new System.Drawing.Size(176, 20);
			this.tbToki2.TabIndex = 3;
			// 
			// dgvFrameData
			// 
			this.dgvFrameData.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.dgvFrameData.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dgvFrameData.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ItemName,
            this.Value1,
            this.Value2,
            this.Value3});
			this.dgvFrameData.Location = new System.Drawing.Point(12, 83);
			this.dgvFrameData.Name = "dgvFrameData";
			this.dgvFrameData.Size = new System.Drawing.Size(560, 314);
			this.dgvFrameData.TabIndex = 7;
			// 
			// ItemName
			// 
			this.ItemName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
			this.ItemName.HeaderText = "Name";
			this.ItemName.Name = "ItemName";
			this.ItemName.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
			// 
			// Value1
			// 
			this.Value1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
			this.Value1.HeaderText = "Value 1";
			this.Value1.Name = "Value1";
			this.Value1.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
			// 
			// Value2
			// 
			this.Value2.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
			this.Value2.HeaderText = "Value 2";
			this.Value2.Name = "Value2";
			this.Value2.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
			// 
			// Value3
			// 
			this.Value3.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
			this.Value3.HeaderText = "Value 3";
			this.Value3.Name = "Value3";
			this.Value3.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
			// 
			// menuStrip1
			// 
			this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.copyHexToolStripMenuItem});
			this.menuStrip1.Location = new System.Drawing.Point(0, 0);
			this.menuStrip1.Name = "menuStrip1";
			this.menuStrip1.Size = new System.Drawing.Size(584, 24);
			this.menuStrip1.TabIndex = 4;
			this.menuStrip1.Text = "menuStrip1";
			// 
			// copyHexToolStripMenuItem
			// 
			this.copyHexToolStripMenuItem.Name = "copyHexToolStripMenuItem";
			this.copyHexToolStripMenuItem.Size = new System.Drawing.Size(71, 20);
			this.copyHexToolStripMenuItem.Text = "&Copy Hex";
			this.copyHexToolStripMenuItem.Click += new System.EventHandler(this.copyHexToolStripMenuItem_Click);
			// 
			// tlpFrame
			// 
			this.tlpFrame.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.tlpFrame.ColumnCount = 2;
			this.tlpFrame.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
			this.tlpFrame.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 75F));
			this.tlpFrame.Controls.Add(this.labelFrame, 0, 0);
			this.tlpFrame.Controls.Add(this.cbFrames, 1, 0);
			this.tlpFrame.Location = new System.Drawing.Point(372, 37);
			this.tlpFrame.Name = "tlpFrame";
			this.tlpFrame.RowCount = 1;
			this.tlpFrame.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.tlpFrame.Size = new System.Drawing.Size(200, 29);
			this.tlpFrame.TabIndex = 4;
			// 
			// gbToki1
			// 
			this.gbToki1.Controls.Add(this.btnViewToki1);
			this.gbToki1.Controls.Add(this.tbToki1Index);
			this.gbToki1.Location = new System.Drawing.Point(12, 27);
			this.gbToki1.Name = "gbToki1";
			this.gbToki1.Size = new System.Drawing.Size(158, 50);
			this.gbToki1.TabIndex = 0;
			this.gbToki1.TabStop = false;
			this.gbToki1.Text = "Toki1 &Index";
			// 
			// tbToki1Index
			// 
			this.tbToki1Index.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
			this.tbToki1Index.Location = new System.Drawing.Point(6, 19);
			this.tbToki1Index.Name = "tbToki1Index";
			this.tbToki1Index.ReadOnly = true;
			this.tbToki1Index.Size = new System.Drawing.Size(66, 20);
			this.tbToki1Index.TabIndex = 1;
			// 
			// btnViewToki1
			// 
			this.btnViewToki1.Location = new System.Drawing.Point(77, 18);
			this.btnViewToki1.Name = "btnViewToki1";
			this.btnViewToki1.Size = new System.Drawing.Size(75, 23);
			this.btnViewToki1.TabIndex = 2;
			this.btnViewToki1.Text = "&View...";
			this.btnViewToki1.UseVisualStyleBackColor = true;
			this.btnViewToki1.Click += new System.EventHandler(this.btnViewToki1_Click);
			// 
			// AnimTest
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(584, 409);
			this.Controls.Add(this.gbToki1);
			this.Controls.Add(this.tlpFrame);
			this.Controls.Add(this.dgvFrameData);
			this.Controls.Add(this.gbToki2);
			this.Controls.Add(this.menuStrip1);
			this.KeyPreview = true;
			this.MainMenuStrip = this.menuStrip1;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.MinimumSize = new System.Drawing.Size(600, 448);
			this.Name = "AnimTest";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "AnimTest";
			this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.AnimTest_KeyDown);
			this.gbToki2.ResumeLayout(false);
			this.gbToki2.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.dgvFrameData)).EndInit();
			this.menuStrip1.ResumeLayout(false);
			this.menuStrip1.PerformLayout();
			this.tlpFrame.ResumeLayout(false);
			this.tlpFrame.PerformLayout();
			this.gbToki1.ResumeLayout(false);
			this.gbToki1.PerformLayout();
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
		private System.Windows.Forms.MenuStrip menuStrip1;
		private System.Windows.Forms.ToolStripMenuItem copyHexToolStripMenuItem;
		private System.Windows.Forms.TableLayoutPanel tlpFrame;
		private System.Windows.Forms.GroupBox gbToki1;
		private System.Windows.Forms.TextBox tbToki1Index;
		private System.Windows.Forms.Button btnViewToki1;
	}
}