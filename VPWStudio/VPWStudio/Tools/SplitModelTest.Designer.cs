namespace VPWStudio
{
	partial class SplitModelTest
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
			this.lblVtxFile = new System.Windows.Forms.Label();
			this.tbVertexFile = new System.Windows.Forms.TextBox();
			this.lblFaceFile = new System.Windows.Forms.Label();
			this.tbFaceFile = new System.Windows.Forms.TextBox();
			this.btnVertexFile = new System.Windows.Forms.Button();
			this.btnFaceFile = new System.Windows.Forms.Button();
			this.btnConvert = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// lblVtxFile
			// 
			this.lblVtxFile.AutoSize = true;
			this.lblVtxFile.Location = new System.Drawing.Point(12, 15);
			this.lblVtxFile.Name = "lblVtxFile";
			this.lblVtxFile.Size = new System.Drawing.Size(56, 13);
			this.lblVtxFile.TabIndex = 0;
			this.lblVtxFile.Text = "&Vertex File";
			// 
			// tbVertexFile
			// 
			this.tbVertexFile.Location = new System.Drawing.Point(74, 12);
			this.tbVertexFile.Name = "tbVertexFile";
			this.tbVertexFile.Size = new System.Drawing.Size(329, 20);
			this.tbVertexFile.TabIndex = 1;
			// 
			// lblFaceFile
			// 
			this.lblFaceFile.AutoSize = true;
			this.lblFaceFile.Location = new System.Drawing.Point(12, 47);
			this.lblFaceFile.Name = "lblFaceFile";
			this.lblFaceFile.Size = new System.Drawing.Size(50, 13);
			this.lblFaceFile.TabIndex = 3;
			this.lblFaceFile.Text = "&Face File";
			// 
			// tbFaceFile
			// 
			this.tbFaceFile.Location = new System.Drawing.Point(74, 44);
			this.tbFaceFile.Name = "tbFaceFile";
			this.tbFaceFile.Size = new System.Drawing.Size(329, 20);
			this.tbFaceFile.TabIndex = 4;
			// 
			// btnVertexFile
			// 
			this.btnVertexFile.Location = new System.Drawing.Point(409, 12);
			this.btnVertexFile.Name = "btnVertexFile";
			this.btnVertexFile.Size = new System.Drawing.Size(75, 23);
			this.btnVertexFile.TabIndex = 2;
			this.btnVertexFile.Text = "Load...";
			this.btnVertexFile.UseVisualStyleBackColor = true;
			this.btnVertexFile.Click += new System.EventHandler(this.btnVertexFile_Click);
			// 
			// btnFaceFile
			// 
			this.btnFaceFile.Location = new System.Drawing.Point(409, 41);
			this.btnFaceFile.Name = "btnFaceFile";
			this.btnFaceFile.Size = new System.Drawing.Size(75, 23);
			this.btnFaceFile.TabIndex = 5;
			this.btnFaceFile.Text = "Load...";
			this.btnFaceFile.UseVisualStyleBackColor = true;
			this.btnFaceFile.Click += new System.EventHandler(this.btnFaceFile_Click);
			// 
			// btnConvert
			// 
			this.btnConvert.Location = new System.Drawing.Point(12, 70);
			this.btnConvert.Name = "btnConvert";
			this.btnConvert.Size = new System.Drawing.Size(472, 23);
			this.btnConvert.TabIndex = 6;
			this.btnConvert.Text = "&Convert to Wavefront OBJ...";
			this.btnConvert.UseVisualStyleBackColor = true;
			this.btnConvert.Click += new System.EventHandler(this.btnConvert_Click);
			// 
			// SplitModelTest
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(496, 105);
			this.Controls.Add(this.btnConvert);
			this.Controls.Add(this.btnFaceFile);
			this.Controls.Add(this.btnVertexFile);
			this.Controls.Add(this.tbFaceFile);
			this.Controls.Add(this.lblFaceFile);
			this.Controls.Add(this.tbVertexFile);
			this.Controls.Add(this.lblVtxFile);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "SplitModelTest";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "Split Model Test";
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Label lblVtxFile;
		private System.Windows.Forms.TextBox tbVertexFile;
		private System.Windows.Forms.Label lblFaceFile;
		private System.Windows.Forms.TextBox tbFaceFile;
		private System.Windows.Forms.Button btnVertexFile;
		private System.Windows.Forms.Button btnFaceFile;
		private System.Windows.Forms.Button btnConvert;
	}
}