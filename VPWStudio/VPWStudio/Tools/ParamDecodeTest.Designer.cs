
namespace VPWStudio
{
	partial class ParamDecodeTest
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
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.tbParamsOut = new System.Windows.Forms.TextBox();
			this.nudParamID = new System.Windows.Forms.NumericUpDown();
			this.btnTryParse = new System.Windows.Forms.Button();
			this.label1 = new System.Windows.Forms.Label();
			this.groupBox1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.nudParamID)).BeginInit();
			this.SuspendLayout();
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.tbParamsOut);
			this.groupBox1.Location = new System.Drawing.Point(12, 41);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(472, 292);
			this.groupBox1.TabIndex = 3;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "Params, maybe";
			// 
			// tbParamsOut
			// 
			this.tbParamsOut.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tbParamsOut.Location = new System.Drawing.Point(3, 16);
			this.tbParamsOut.MaxLength = 65535;
			this.tbParamsOut.Multiline = true;
			this.tbParamsOut.Name = "tbParamsOut";
			this.tbParamsOut.ReadOnly = true;
			this.tbParamsOut.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			this.tbParamsOut.Size = new System.Drawing.Size(466, 273);
			this.tbParamsOut.TabIndex = 3;
			// 
			// nudParamID
			// 
			this.nudParamID.Hexadecimal = true;
			this.nudParamID.Location = new System.Drawing.Point(106, 15);
			this.nudParamID.Maximum = new decimal(new int[] {
            32768,
            0,
            0,
            0});
			this.nudParamID.Name = "nudParamID";
			this.nudParamID.Size = new System.Drawing.Size(297, 20);
			this.nudParamID.TabIndex = 1;
			// 
			// btnTryParse
			// 
			this.btnTryParse.Location = new System.Drawing.Point(409, 12);
			this.btnTryParse.Name = "btnTryParse";
			this.btnTryParse.Size = new System.Drawing.Size(75, 23);
			this.btnTryParse.TabIndex = 2;
			this.btnTryParse.Text = "&Try it";
			this.btnTryParse.UseVisualStyleBackColor = true;
			this.btnTryParse.Click += new System.EventHandler(this.btnTryParse_Click);
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(12, 17);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(88, 13);
			this.label1.TabIndex = 0;
			this.label1.Text = "Parameter File &ID";
			// 
			// ParamDecodeTest
			// 
			this.AcceptButton = this.btnTryParse;
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(496, 345);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.btnTryParse);
			this.Controls.Add(this.nudParamID);
			this.Controls.Add(this.groupBox1);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.MinimumSize = new System.Drawing.Size(512, 384);
			this.Name = "ParamDecodeTest";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "Wrestler Parameter Decode Test";
			this.groupBox1.ResumeLayout(false);
			this.groupBox1.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.nudParamID)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.TextBox tbParamsOut;
		private System.Windows.Forms.NumericUpDown nudParamID;
		private System.Windows.Forms.Button btnTryParse;
		private System.Windows.Forms.Label label1;
	}
}