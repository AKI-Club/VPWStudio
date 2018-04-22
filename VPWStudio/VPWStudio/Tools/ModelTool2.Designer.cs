namespace VPWStudio
{
	partial class ModelTool2
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
			this.pbPreview = new System.Windows.Forms.PictureBox();
			this.gbModelInfo = new System.Windows.Forms.GroupBox();
			this.tlpModelInfo = new System.Windows.Forms.TableLayoutPanel();
			this.label1 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.label4 = new System.Windows.Forms.Label();
			this.label5 = new System.Windows.Forms.Label();
			this.label6 = new System.Windows.Forms.Label();
			this.label7 = new System.Windows.Forms.Label();
			this.label8 = new System.Windows.Forms.Label();
			this.tbModelScale = new System.Windows.Forms.TextBox();
			this.tbNumVerts = new System.Windows.Forms.TextBox();
			this.tbNumFaces = new System.Windows.Forms.TextBox();
			this.tbUnknown = new System.Windows.Forms.TextBox();
			this.tbOffsetX = new System.Windows.Forms.TextBox();
			this.tbOffsetY = new System.Windows.Forms.TextBox();
			this.tbOffsetZ = new System.Windows.Forms.TextBox();
			this.tbOffsetUV = new System.Windows.Forms.TextBox();
			((System.ComponentModel.ISupportInitialize)(this.pbPreview)).BeginInit();
			this.gbModelInfo.SuspendLayout();
			this.tlpModelInfo.SuspendLayout();
			this.SuspendLayout();
			// 
			// pbPreview
			// 
			this.pbPreview.Location = new System.Drawing.Point(366, 12);
			this.pbPreview.Name = "pbPreview";
			this.pbPreview.Size = new System.Drawing.Size(256, 256);
			this.pbPreview.TabIndex = 0;
			this.pbPreview.TabStop = false;
			// 
			// gbModelInfo
			// 
			this.gbModelInfo.Controls.Add(this.tlpModelInfo);
			this.gbModelInfo.Location = new System.Drawing.Point(12, 12);
			this.gbModelInfo.Name = "gbModelInfo";
			this.gbModelInfo.Size = new System.Drawing.Size(348, 256);
			this.gbModelInfo.TabIndex = 1;
			this.gbModelInfo.TabStop = false;
			this.gbModelInfo.Text = "Model Information";
			// 
			// tlpModelInfo
			// 
			this.tlpModelInfo.ColumnCount = 2;
			this.tlpModelInfo.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 31F));
			this.tlpModelInfo.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 69F));
			this.tlpModelInfo.Controls.Add(this.label1, 0, 0);
			this.tlpModelInfo.Controls.Add(this.label2, 0, 1);
			this.tlpModelInfo.Controls.Add(this.label3, 0, 2);
			this.tlpModelInfo.Controls.Add(this.label4, 0, 3);
			this.tlpModelInfo.Controls.Add(this.label5, 0, 4);
			this.tlpModelInfo.Controls.Add(this.label6, 0, 5);
			this.tlpModelInfo.Controls.Add(this.label7, 0, 6);
			this.tlpModelInfo.Controls.Add(this.label8, 0, 7);
			this.tlpModelInfo.Controls.Add(this.tbModelScale, 1, 0);
			this.tlpModelInfo.Controls.Add(this.tbNumVerts, 1, 1);
			this.tlpModelInfo.Controls.Add(this.tbNumFaces, 1, 2);
			this.tlpModelInfo.Controls.Add(this.tbUnknown, 1, 3);
			this.tlpModelInfo.Controls.Add(this.tbOffsetX, 1, 4);
			this.tlpModelInfo.Controls.Add(this.tbOffsetY, 1, 5);
			this.tlpModelInfo.Controls.Add(this.tbOffsetZ, 1, 6);
			this.tlpModelInfo.Controls.Add(this.tbOffsetUV, 1, 7);
			this.tlpModelInfo.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tlpModelInfo.Location = new System.Drawing.Point(3, 16);
			this.tlpModelInfo.Name = "tlpModelInfo";
			this.tlpModelInfo.RowCount = 8;
			this.tlpModelInfo.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
			this.tlpModelInfo.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
			this.tlpModelInfo.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
			this.tlpModelInfo.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
			this.tlpModelInfo.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
			this.tlpModelInfo.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
			this.tlpModelInfo.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
			this.tlpModelInfo.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
			this.tlpModelInfo.Size = new System.Drawing.Size(342, 237);
			this.tlpModelInfo.TabIndex = 0;
			// 
			// label1
			// 
			this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(3, 8);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(100, 13);
			this.label1.TabIndex = 0;
			this.label1.Text = "Scale";
			// 
			// label2
			// 
			this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(3, 37);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(100, 13);
			this.label2.TabIndex = 1;
			this.label2.Text = "Number of Vertices";
			// 
			// label3
			// 
			this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(3, 66);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(100, 13);
			this.label3.TabIndex = 2;
			this.label3.Text = "Number of Faces";
			// 
			// label4
			// 
			this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
			this.label4.AutoSize = true;
			this.label4.Location = new System.Drawing.Point(3, 95);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(100, 13);
			this.label4.TabIndex = 3;
			this.label4.Text = "(unknown)";
			// 
			// label5
			// 
			this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
			this.label5.AutoSize = true;
			this.label5.Location = new System.Drawing.Point(3, 124);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(100, 13);
			this.label5.TabIndex = 4;
			this.label5.Text = "Offset X";
			// 
			// label6
			// 
			this.label6.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
			this.label6.AutoSize = true;
			this.label6.Location = new System.Drawing.Point(3, 153);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(100, 13);
			this.label6.TabIndex = 5;
			this.label6.Text = "Offset Y";
			// 
			// label7
			// 
			this.label7.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
			this.label7.AutoSize = true;
			this.label7.Location = new System.Drawing.Point(3, 182);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size(100, 13);
			this.label7.TabIndex = 6;
			this.label7.Text = "Offset Z";
			// 
			// label8
			// 
			this.label8.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
			this.label8.AutoSize = true;
			this.label8.Location = new System.Drawing.Point(3, 213);
			this.label8.Name = "label8";
			this.label8.Size = new System.Drawing.Size(100, 13);
			this.label8.TabIndex = 7;
			this.label8.Text = "Texture Offset";
			// 
			// tbModelScale
			// 
			this.tbModelScale.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
			this.tbModelScale.Location = new System.Drawing.Point(109, 4);
			this.tbModelScale.Name = "tbModelScale";
			this.tbModelScale.ReadOnly = true;
			this.tbModelScale.Size = new System.Drawing.Size(230, 20);
			this.tbModelScale.TabIndex = 8;
			// 
			// tbNumVerts
			// 
			this.tbNumVerts.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
			this.tbNumVerts.Location = new System.Drawing.Point(109, 33);
			this.tbNumVerts.Name = "tbNumVerts";
			this.tbNumVerts.ReadOnly = true;
			this.tbNumVerts.Size = new System.Drawing.Size(230, 20);
			this.tbNumVerts.TabIndex = 9;
			// 
			// tbNumFaces
			// 
			this.tbNumFaces.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
			this.tbNumFaces.Location = new System.Drawing.Point(109, 62);
			this.tbNumFaces.Name = "tbNumFaces";
			this.tbNumFaces.ReadOnly = true;
			this.tbNumFaces.Size = new System.Drawing.Size(230, 20);
			this.tbNumFaces.TabIndex = 10;
			// 
			// tbUnknown
			// 
			this.tbUnknown.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
			this.tbUnknown.Location = new System.Drawing.Point(109, 91);
			this.tbUnknown.Name = "tbUnknown";
			this.tbUnknown.ReadOnly = true;
			this.tbUnknown.Size = new System.Drawing.Size(230, 20);
			this.tbUnknown.TabIndex = 11;
			// 
			// tbOffsetX
			// 
			this.tbOffsetX.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
			this.tbOffsetX.Location = new System.Drawing.Point(109, 120);
			this.tbOffsetX.Name = "tbOffsetX";
			this.tbOffsetX.ReadOnly = true;
			this.tbOffsetX.Size = new System.Drawing.Size(230, 20);
			this.tbOffsetX.TabIndex = 12;
			// 
			// tbOffsetY
			// 
			this.tbOffsetY.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
			this.tbOffsetY.Location = new System.Drawing.Point(109, 149);
			this.tbOffsetY.Name = "tbOffsetY";
			this.tbOffsetY.ReadOnly = true;
			this.tbOffsetY.Size = new System.Drawing.Size(230, 20);
			this.tbOffsetY.TabIndex = 13;
			// 
			// tbOffsetZ
			// 
			this.tbOffsetZ.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
			this.tbOffsetZ.Location = new System.Drawing.Point(109, 178);
			this.tbOffsetZ.Name = "tbOffsetZ";
			this.tbOffsetZ.ReadOnly = true;
			this.tbOffsetZ.Size = new System.Drawing.Size(230, 20);
			this.tbOffsetZ.TabIndex = 14;
			// 
			// tbOffsetUV
			// 
			this.tbOffsetUV.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
			this.tbOffsetUV.Location = new System.Drawing.Point(109, 210);
			this.tbOffsetUV.Name = "tbOffsetUV";
			this.tbOffsetUV.ReadOnly = true;
			this.tbOffsetUV.Size = new System.Drawing.Size(230, 20);
			this.tbOffsetUV.TabIndex = 15;
			// 
			// ModelTool2
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(634, 280);
			this.Controls.Add(this.gbModelInfo);
			this.Controls.Add(this.pbPreview);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "ModelTool2";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "ModelTool2";
			((System.ComponentModel.ISupportInitialize)(this.pbPreview)).EndInit();
			this.gbModelInfo.ResumeLayout(false);
			this.tlpModelInfo.ResumeLayout(false);
			this.tlpModelInfo.PerformLayout();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.PictureBox pbPreview;
		private System.Windows.Forms.GroupBox gbModelInfo;
		private System.Windows.Forms.TableLayoutPanel tlpModelInfo;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.Label label7;
		private System.Windows.Forms.Label label8;
		private System.Windows.Forms.TextBox tbModelScale;
		private System.Windows.Forms.TextBox tbNumVerts;
		private System.Windows.Forms.TextBox tbNumFaces;
		private System.Windows.Forms.TextBox tbUnknown;
		private System.Windows.Forms.TextBox tbOffsetX;
		private System.Windows.Forms.TextBox tbOffsetY;
		private System.Windows.Forms.TextBox tbOffsetZ;
		private System.Windows.Forms.TextBox tbOffsetUV;
	}
}