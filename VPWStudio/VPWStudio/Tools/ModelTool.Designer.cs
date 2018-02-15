namespace VPWStudio
{
	partial class ModelTool
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
			this.tbInfoDump = new System.Windows.Forms.TextBox();
			this.label1 = new System.Windows.Forms.Label();
			this.buttonOpen = new System.Windows.Forms.Button();
			this.label2 = new System.Windows.Forms.Label();
			this.tbCurFile = new System.Windows.Forms.TextBox();
			this.gbVertices = new System.Windows.Forms.GroupBox();
			this.dgvVertices = new System.Windows.Forms.DataGridView();
			this.Number = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.XPos = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.YPos = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.ZPos = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.UPos = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.VPos = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.VertexColor = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.gbFaces = new System.Windows.Forms.GroupBox();
			this.dgvFaces = new System.Windows.Forms.DataGridView();
			this.FaceNum = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.Vertex1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.Vertex2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.Vertex3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.gbInformation = new System.Windows.Forms.GroupBox();
			this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
			this.label7 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.label4 = new System.Windows.Forms.Label();
			this.label5 = new System.Windows.Forms.Label();
			this.label6 = new System.Windows.Forms.Label();
			this.buttonExportOBJ = new System.Windows.Forms.Button();
			this.gbVertices.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.dgvVertices)).BeginInit();
			this.gbFaces.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.dgvFaces)).BeginInit();
			this.gbInformation.SuspendLayout();
			this.tableLayoutPanel1.SuspendLayout();
			this.SuspendLayout();
			// 
			// tbInfoDump
			// 
			this.tbInfoDump.Location = new System.Drawing.Point(12, 335);
			this.tbInfoDump.Multiline = true;
			this.tbInfoDump.Name = "tbInfoDump";
			this.tbInfoDump.ReadOnly = true;
			this.tbInfoDump.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			this.tbInfoDump.Size = new System.Drawing.Size(608, 106);
			this.tbInfoDump.TabIndex = 0;
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(12, 319);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(90, 13);
			this.label1.TabIndex = 1;
			this.label1.Text = "Information Dump";
			// 
			// buttonOpen
			// 
			this.buttonOpen.Location = new System.Drawing.Point(545, 12);
			this.buttonOpen.Name = "buttonOpen";
			this.buttonOpen.Size = new System.Drawing.Size(75, 23);
			this.buttonOpen.TabIndex = 2;
			this.buttonOpen.Text = "&Open...";
			this.buttonOpen.UseVisualStyleBackColor = true;
			this.buttonOpen.Click += new System.EventHandler(this.buttonOpen_Click);
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(12, 17);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(60, 13);
			this.label2.TabIndex = 3;
			this.label2.Text = "Current File";
			// 
			// tbCurFile
			// 
			this.tbCurFile.Location = new System.Drawing.Point(78, 14);
			this.tbCurFile.Name = "tbCurFile";
			this.tbCurFile.ReadOnly = true;
			this.tbCurFile.Size = new System.Drawing.Size(461, 20);
			this.tbCurFile.TabIndex = 4;
			// 
			// gbVertices
			// 
			this.gbVertices.Controls.Add(this.dgvVertices);
			this.gbVertices.Location = new System.Drawing.Point(12, 149);
			this.gbVertices.Name = "gbVertices";
			this.gbVertices.Size = new System.Drawing.Size(399, 167);
			this.gbVertices.TabIndex = 5;
			this.gbVertices.TabStop = false;
			this.gbVertices.Text = "&Vertices";
			// 
			// dgvVertices
			// 
			this.dgvVertices.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dgvVertices.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Number,
            this.XPos,
            this.YPos,
            this.ZPos,
            this.UPos,
            this.VPos,
            this.VertexColor});
			this.dgvVertices.Dock = System.Windows.Forms.DockStyle.Fill;
			this.dgvVertices.Location = new System.Drawing.Point(3, 16);
			this.dgvVertices.Name = "dgvVertices";
			this.dgvVertices.ReadOnly = true;
			this.dgvVertices.RowHeadersWidth = 24;
			this.dgvVertices.Size = new System.Drawing.Size(393, 148);
			this.dgvVertices.TabIndex = 0;
			// 
			// Number
			// 
			this.Number.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
			this.Number.HeaderText = "#";
			this.Number.Name = "Number";
			this.Number.ReadOnly = true;
			this.Number.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
			// 
			// XPos
			// 
			this.XPos.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
			this.XPos.HeaderText = "X";
			this.XPos.Name = "XPos";
			this.XPos.ReadOnly = true;
			this.XPos.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
			// 
			// YPos
			// 
			this.YPos.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
			this.YPos.HeaderText = "Y";
			this.YPos.Name = "YPos";
			this.YPos.ReadOnly = true;
			this.YPos.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
			// 
			// ZPos
			// 
			this.ZPos.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
			this.ZPos.HeaderText = "Z";
			this.ZPos.Name = "ZPos";
			this.ZPos.ReadOnly = true;
			this.ZPos.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
			// 
			// UPos
			// 
			this.UPos.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
			this.UPos.HeaderText = "U";
			this.UPos.Name = "UPos";
			this.UPos.ReadOnly = true;
			this.UPos.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
			// 
			// VPos
			// 
			this.VPos.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
			this.VPos.HeaderText = "V";
			this.VPos.Name = "VPos";
			this.VPos.ReadOnly = true;
			this.VPos.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
			// 
			// VertexColor
			// 
			this.VertexColor.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
			this.VertexColor.HeaderText = "Color";
			this.VertexColor.Name = "VertexColor";
			this.VertexColor.ReadOnly = true;
			this.VertexColor.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
			// 
			// gbFaces
			// 
			this.gbFaces.Controls.Add(this.dgvFaces);
			this.gbFaces.Location = new System.Drawing.Point(420, 149);
			this.gbFaces.Name = "gbFaces";
			this.gbFaces.Size = new System.Drawing.Size(200, 167);
			this.gbFaces.TabIndex = 6;
			this.gbFaces.TabStop = false;
			this.gbFaces.Text = "&Faces";
			// 
			// dgvFaces
			// 
			this.dgvFaces.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dgvFaces.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.FaceNum,
            this.Vertex1,
            this.Vertex2,
            this.Vertex3});
			this.dgvFaces.Dock = System.Windows.Forms.DockStyle.Fill;
			this.dgvFaces.Location = new System.Drawing.Point(3, 16);
			this.dgvFaces.Name = "dgvFaces";
			this.dgvFaces.ReadOnly = true;
			this.dgvFaces.RowHeadersWidth = 24;
			this.dgvFaces.Size = new System.Drawing.Size(194, 148);
			this.dgvFaces.TabIndex = 0;
			// 
			// FaceNum
			// 
			this.FaceNum.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
			this.FaceNum.HeaderText = "#";
			this.FaceNum.Name = "FaceNum";
			this.FaceNum.ReadOnly = true;
			this.FaceNum.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
			// 
			// Vertex1
			// 
			this.Vertex1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
			this.Vertex1.HeaderText = "V1";
			this.Vertex1.Name = "Vertex1";
			this.Vertex1.ReadOnly = true;
			this.Vertex1.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
			// 
			// Vertex2
			// 
			this.Vertex2.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
			this.Vertex2.HeaderText = "V2";
			this.Vertex2.Name = "Vertex2";
			this.Vertex2.ReadOnly = true;
			this.Vertex2.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
			// 
			// Vertex3
			// 
			this.Vertex3.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
			this.Vertex3.HeaderText = "V3";
			this.Vertex3.Name = "Vertex3";
			this.Vertex3.ReadOnly = true;
			this.Vertex3.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
			// 
			// gbInformation
			// 
			this.gbInformation.Controls.Add(this.tableLayoutPanel1);
			this.gbInformation.Location = new System.Drawing.Point(12, 41);
			this.gbInformation.Name = "gbInformation";
			this.gbInformation.Size = new System.Drawing.Size(419, 102);
			this.gbInformation.TabIndex = 7;
			this.gbInformation.TabStop = false;
			this.gbInformation.Text = "Header";
			// 
			// tableLayoutPanel1
			// 
			this.tableLayoutPanel1.ColumnCount = 4;
			this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
			this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 30F));
			this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
			this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 30F));
			this.tableLayoutPanel1.Controls.Add(this.label7, 0, 0);
			this.tableLayoutPanel1.Controls.Add(this.label3, 2, 0);
			this.tableLayoutPanel1.Controls.Add(this.label4, 0, 1);
			this.tableLayoutPanel1.Controls.Add(this.label5, 2, 1);
			this.tableLayoutPanel1.Controls.Add(this.label6, 0, 2);
			this.tableLayoutPanel1.Location = new System.Drawing.Point(6, 19);
			this.tableLayoutPanel1.Name = "tableLayoutPanel1";
			this.tableLayoutPanel1.RowCount = 3;
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
			this.tableLayoutPanel1.Size = new System.Drawing.Size(403, 75);
			this.tableLayoutPanel1.TabIndex = 0;
			// 
			// label7
			// 
			this.label7.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
			this.label7.AutoSize = true;
			this.label7.Location = new System.Drawing.Point(3, 6);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size(74, 13);
			this.label7.TabIndex = 4;
			this.label7.Text = "Scale";
			// 
			// label3
			// 
			this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(203, 6);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(74, 13);
			this.label3.TabIndex = 0;
			this.label3.Text = "X Offset";
			// 
			// label4
			// 
			this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
			this.label4.AutoSize = true;
			this.label4.Location = new System.Drawing.Point(3, 31);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(74, 13);
			this.label4.TabIndex = 1;
			this.label4.Text = "Y Offset";
			// 
			// label5
			// 
			this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
			this.label5.AutoSize = true;
			this.label5.Location = new System.Drawing.Point(203, 31);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(74, 13);
			this.label5.TabIndex = 2;
			this.label5.Text = "Z Offset";
			// 
			// label6
			// 
			this.label6.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
			this.label6.AutoSize = true;
			this.label6.Location = new System.Drawing.Point(3, 56);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(74, 13);
			this.label6.TabIndex = 3;
			this.label6.Text = "Texture Offset";
			// 
			// buttonExportOBJ
			// 
			this.buttonExportOBJ.Location = new System.Drawing.Point(529, 41);
			this.buttonExportOBJ.Name = "buttonExportOBJ";
			this.buttonExportOBJ.Size = new System.Drawing.Size(91, 23);
			this.buttonExportOBJ.TabIndex = 8;
			this.buttonExportOBJ.Text = "Export OBJ...";
			this.buttonExportOBJ.UseVisualStyleBackColor = true;
			this.buttonExportOBJ.Click += new System.EventHandler(this.buttonExportOBJ_Click);
			// 
			// ModelTool
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(632, 453);
			this.Controls.Add(this.buttonExportOBJ);
			this.Controls.Add(this.gbInformation);
			this.Controls.Add(this.gbFaces);
			this.Controls.Add(this.gbVertices);
			this.Controls.Add(this.tbCurFile);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.buttonOpen);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.tbInfoDump);
			this.MaximizeBox = false;
			this.Name = "ModelTool";
			this.Text = "Model Tool";
			this.gbVertices.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.dgvVertices)).EndInit();
			this.gbFaces.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.dgvFaces)).EndInit();
			this.gbInformation.ResumeLayout(false);
			this.tableLayoutPanel1.ResumeLayout(false);
			this.tableLayoutPanel1.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.TextBox tbInfoDump;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Button buttonOpen;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.TextBox tbCurFile;
		private System.Windows.Forms.GroupBox gbVertices;
		private System.Windows.Forms.GroupBox gbFaces;
		private System.Windows.Forms.GroupBox gbInformation;
		private System.Windows.Forms.DataGridView dgvVertices;
		private System.Windows.Forms.DataGridView dgvFaces;
		private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.Label label7;
		private System.Windows.Forms.DataGridViewTextBoxColumn FaceNum;
		private System.Windows.Forms.DataGridViewTextBoxColumn Vertex1;
		private System.Windows.Forms.DataGridViewTextBoxColumn Vertex2;
		private System.Windows.Forms.DataGridViewTextBoxColumn Vertex3;
		private System.Windows.Forms.DataGridViewTextBoxColumn Number;
		private System.Windows.Forms.DataGridViewTextBoxColumn XPos;
		private System.Windows.Forms.DataGridViewTextBoxColumn YPos;
		private System.Windows.Forms.DataGridViewTextBoxColumn ZPos;
		private System.Windows.Forms.DataGridViewTextBoxColumn UPos;
		private System.Windows.Forms.DataGridViewTextBoxColumn VPos;
		private System.Windows.Forms.DataGridViewTextBoxColumn VertexColor;
		private System.Windows.Forms.Button buttonExportOBJ;
	}
}