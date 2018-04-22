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
			this.labelModelScale = new System.Windows.Forms.Label();
			this.labelNumVerts = new System.Windows.Forms.Label();
			this.labelNumFaces = new System.Windows.Forms.Label();
			this.labelUnknown = new System.Windows.Forms.Label();
			this.labelOffsetX = new System.Windows.Forms.Label();
			this.labelOffsetY = new System.Windows.Forms.Label();
			this.labelOffsetZ = new System.Windows.Forms.Label();
			this.labelTextureOffset = new System.Windows.Forms.Label();
			this.tbModelScale = new System.Windows.Forms.TextBox();
			this.tbNumVerts = new System.Windows.Forms.TextBox();
			this.tbNumFaces = new System.Windows.Forms.TextBox();
			this.tbUnknown = new System.Windows.Forms.TextBox();
			this.tbOffsetX = new System.Windows.Forms.TextBox();
			this.tbOffsetY = new System.Windows.Forms.TextBox();
			this.tbOffsetZ = new System.Windows.Forms.TextBox();
			this.tbOffsetUV = new System.Windows.Forms.TextBox();
			this.labelFileID = new System.Windows.Forms.Label();
			this.tbFileID = new System.Windows.Forms.TextBox();
			((System.ComponentModel.ISupportInitialize)(this.pbPreview)).BeginInit();
			this.gbModelInfo.SuspendLayout();
			this.tlpModelInfo.SuspendLayout();
			this.SuspendLayout();
			// 
			// pbPreview
			// 
			this.pbPreview.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
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
			this.tlpModelInfo.Controls.Add(this.tbOffsetUV, 1, 8);
			this.tlpModelInfo.Controls.Add(this.labelTextureOffset, 0, 8);
			this.tlpModelInfo.Controls.Add(this.labelOffsetZ, 0, 7);
			this.tlpModelInfo.Controls.Add(this.tbOffsetZ, 1, 7);
			this.tlpModelInfo.Controls.Add(this.tbOffsetY, 1, 6);
			this.tlpModelInfo.Controls.Add(this.labelOffsetY, 0, 6);
			this.tlpModelInfo.Controls.Add(this.labelOffsetX, 0, 5);
			this.tlpModelInfo.Controls.Add(this.tbOffsetX, 1, 5);
			this.tlpModelInfo.Controls.Add(this.labelUnknown, 0, 4);
			this.tlpModelInfo.Controls.Add(this.tbUnknown, 1, 4);
			this.tlpModelInfo.Controls.Add(this.labelNumFaces, 0, 3);
			this.tlpModelInfo.Controls.Add(this.tbNumFaces, 1, 3);
			this.tlpModelInfo.Controls.Add(this.tbNumVerts, 1, 2);
			this.tlpModelInfo.Controls.Add(this.labelNumVerts, 0, 2);
			this.tlpModelInfo.Controls.Add(this.tbModelScale, 1, 1);
			this.tlpModelInfo.Controls.Add(this.labelModelScale, 0, 1);
			this.tlpModelInfo.Controls.Add(this.labelFileID, 0, 0);
			this.tlpModelInfo.Controls.Add(this.tbFileID, 1, 0);
			this.tlpModelInfo.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tlpModelInfo.Location = new System.Drawing.Point(3, 16);
			this.tlpModelInfo.Name = "tlpModelInfo";
			this.tlpModelInfo.RowCount = 9;
			this.tlpModelInfo.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 11.11111F));
			this.tlpModelInfo.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 11.11111F));
			this.tlpModelInfo.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 11.11111F));
			this.tlpModelInfo.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 11.11111F));
			this.tlpModelInfo.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 11.11111F));
			this.tlpModelInfo.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 11.11111F));
			this.tlpModelInfo.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 11.11111F));
			this.tlpModelInfo.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 11.11111F));
			this.tlpModelInfo.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 11.11111F));
			this.tlpModelInfo.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
			this.tlpModelInfo.Size = new System.Drawing.Size(342, 237);
			this.tlpModelInfo.TabIndex = 0;
			// 
			// labelModelScale
			// 
			this.labelModelScale.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
			this.labelModelScale.AutoSize = true;
			this.labelModelScale.Location = new System.Drawing.Point(3, 32);
			this.labelModelScale.Name = "labelModelScale";
			this.labelModelScale.Size = new System.Drawing.Size(100, 13);
			this.labelModelScale.TabIndex = 1;
			this.labelModelScale.Text = "Scale";
			// 
			// labelNumVerts
			// 
			this.labelNumVerts.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
			this.labelNumVerts.AutoSize = true;
			this.labelNumVerts.Location = new System.Drawing.Point(3, 58);
			this.labelNumVerts.Name = "labelNumVerts";
			this.labelNumVerts.Size = new System.Drawing.Size(100, 13);
			this.labelNumVerts.TabIndex = 2;
			this.labelNumVerts.Text = "Number of Vertices";
			// 
			// labelNumFaces
			// 
			this.labelNumFaces.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
			this.labelNumFaces.AutoSize = true;
			this.labelNumFaces.Location = new System.Drawing.Point(3, 84);
			this.labelNumFaces.Name = "labelNumFaces";
			this.labelNumFaces.Size = new System.Drawing.Size(100, 13);
			this.labelNumFaces.TabIndex = 3;
			this.labelNumFaces.Text = "Number of Faces";
			// 
			// labelUnknown
			// 
			this.labelUnknown.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
			this.labelUnknown.AutoSize = true;
			this.labelUnknown.Location = new System.Drawing.Point(3, 110);
			this.labelUnknown.Name = "labelUnknown";
			this.labelUnknown.Size = new System.Drawing.Size(100, 13);
			this.labelUnknown.TabIndex = 4;
			this.labelUnknown.Text = "(unknown)";
			// 
			// labelOffsetX
			// 
			this.labelOffsetX.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
			this.labelOffsetX.AutoSize = true;
			this.labelOffsetX.Location = new System.Drawing.Point(3, 136);
			this.labelOffsetX.Name = "labelOffsetX";
			this.labelOffsetX.Size = new System.Drawing.Size(100, 13);
			this.labelOffsetX.TabIndex = 5;
			this.labelOffsetX.Text = "Offset X";
			// 
			// labelOffsetY
			// 
			this.labelOffsetY.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
			this.labelOffsetY.AutoSize = true;
			this.labelOffsetY.Location = new System.Drawing.Point(3, 162);
			this.labelOffsetY.Name = "labelOffsetY";
			this.labelOffsetY.Size = new System.Drawing.Size(100, 13);
			this.labelOffsetY.TabIndex = 6;
			this.labelOffsetY.Text = "Offset Y";
			// 
			// labelOffsetZ
			// 
			this.labelOffsetZ.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
			this.labelOffsetZ.AutoSize = true;
			this.labelOffsetZ.Location = new System.Drawing.Point(3, 188);
			this.labelOffsetZ.Name = "labelOffsetZ";
			this.labelOffsetZ.Size = new System.Drawing.Size(100, 13);
			this.labelOffsetZ.TabIndex = 7;
			this.labelOffsetZ.Text = "Offset Z";
			// 
			// labelTextureOffset
			// 
			this.labelTextureOffset.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
			this.labelTextureOffset.AutoSize = true;
			this.labelTextureOffset.Location = new System.Drawing.Point(3, 216);
			this.labelTextureOffset.Name = "labelTextureOffset";
			this.labelTextureOffset.Size = new System.Drawing.Size(100, 13);
			this.labelTextureOffset.TabIndex = 8;
			this.labelTextureOffset.Text = "Texture Offset";
			// 
			// tbModelScale
			// 
			this.tbModelScale.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
			this.tbModelScale.Location = new System.Drawing.Point(109, 29);
			this.tbModelScale.Name = "tbModelScale";
			this.tbModelScale.ReadOnly = true;
			this.tbModelScale.Size = new System.Drawing.Size(230, 20);
			this.tbModelScale.TabIndex = 1;
			// 
			// tbNumVerts
			// 
			this.tbNumVerts.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
			this.tbNumVerts.Location = new System.Drawing.Point(109, 55);
			this.tbNumVerts.Name = "tbNumVerts";
			this.tbNumVerts.ReadOnly = true;
			this.tbNumVerts.Size = new System.Drawing.Size(230, 20);
			this.tbNumVerts.TabIndex = 2;
			// 
			// tbNumFaces
			// 
			this.tbNumFaces.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
			this.tbNumFaces.Location = new System.Drawing.Point(109, 81);
			this.tbNumFaces.Name = "tbNumFaces";
			this.tbNumFaces.ReadOnly = true;
			this.tbNumFaces.Size = new System.Drawing.Size(230, 20);
			this.tbNumFaces.TabIndex = 3;
			// 
			// tbUnknown
			// 
			this.tbUnknown.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
			this.tbUnknown.Location = new System.Drawing.Point(109, 107);
			this.tbUnknown.Name = "tbUnknown";
			this.tbUnknown.ReadOnly = true;
			this.tbUnknown.Size = new System.Drawing.Size(230, 20);
			this.tbUnknown.TabIndex = 4;
			// 
			// tbOffsetX
			// 
			this.tbOffsetX.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
			this.tbOffsetX.Location = new System.Drawing.Point(109, 133);
			this.tbOffsetX.Name = "tbOffsetX";
			this.tbOffsetX.ReadOnly = true;
			this.tbOffsetX.Size = new System.Drawing.Size(230, 20);
			this.tbOffsetX.TabIndex = 5;
			// 
			// tbOffsetY
			// 
			this.tbOffsetY.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
			this.tbOffsetY.Location = new System.Drawing.Point(109, 159);
			this.tbOffsetY.Name = "tbOffsetY";
			this.tbOffsetY.ReadOnly = true;
			this.tbOffsetY.Size = new System.Drawing.Size(230, 20);
			this.tbOffsetY.TabIndex = 6;
			// 
			// tbOffsetZ
			// 
			this.tbOffsetZ.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
			this.tbOffsetZ.Location = new System.Drawing.Point(109, 185);
			this.tbOffsetZ.Name = "tbOffsetZ";
			this.tbOffsetZ.ReadOnly = true;
			this.tbOffsetZ.Size = new System.Drawing.Size(230, 20);
			this.tbOffsetZ.TabIndex = 7;
			// 
			// tbOffsetUV
			// 
			this.tbOffsetUV.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
			this.tbOffsetUV.Location = new System.Drawing.Point(109, 212);
			this.tbOffsetUV.Name = "tbOffsetUV";
			this.tbOffsetUV.ReadOnly = true;
			this.tbOffsetUV.Size = new System.Drawing.Size(230, 20);
			this.tbOffsetUV.TabIndex = 8;
			// 
			// labelFileID
			// 
			this.labelFileID.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
			this.labelFileID.AutoSize = true;
			this.labelFileID.Location = new System.Drawing.Point(3, 6);
			this.labelFileID.Name = "labelFileID";
			this.labelFileID.Size = new System.Drawing.Size(100, 13);
			this.labelFileID.TabIndex = 0;
			this.labelFileID.Text = "File ID";
			// 
			// tbFileID
			// 
			this.tbFileID.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
			this.tbFileID.Location = new System.Drawing.Point(109, 3);
			this.tbFileID.Name = "tbFileID";
			this.tbFileID.ReadOnly = true;
			this.tbFileID.Size = new System.Drawing.Size(230, 20);
			this.tbFileID.TabIndex = 0;
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
		private System.Windows.Forms.Label labelModelScale;
		private System.Windows.Forms.Label labelNumVerts;
		private System.Windows.Forms.Label labelNumFaces;
		private System.Windows.Forms.Label labelUnknown;
		private System.Windows.Forms.Label labelOffsetX;
		private System.Windows.Forms.Label labelOffsetY;
		private System.Windows.Forms.Label labelOffsetZ;
		private System.Windows.Forms.Label labelTextureOffset;
		private System.Windows.Forms.TextBox tbModelScale;
		private System.Windows.Forms.TextBox tbNumVerts;
		private System.Windows.Forms.TextBox tbNumFaces;
		private System.Windows.Forms.TextBox tbUnknown;
		private System.Windows.Forms.TextBox tbOffsetX;
		private System.Windows.Forms.TextBox tbOffsetY;
		private System.Windows.Forms.TextBox tbOffsetZ;
		private System.Windows.Forms.TextBox tbOffsetUV;
		private System.Windows.Forms.Label labelFileID;
		private System.Windows.Forms.TextBox tbFileID;
	}
}