namespace VPWStudio.Controls
{
	partial class CostumeColorControl
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

		#region Component Designer generated code

		/// <summary> 
		/// Required method for Designer support - do not modify 
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
			this.nudColor = new System.Windows.Forms.NumericUpDown();
			this.panelColorPreview = new System.Windows.Forms.Panel();
			this.tableLayoutPanel1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.nudColor)).BeginInit();
			this.SuspendLayout();
			// 
			// tableLayoutPanel1
			// 
			this.tableLayoutPanel1.ColumnCount = 2;
			this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
			this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
			this.tableLayoutPanel1.Controls.Add(this.nudColor, 0, 0);
			this.tableLayoutPanel1.Controls.Add(this.panelColorPreview, 1, 0);
			this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
			this.tableLayoutPanel1.Name = "tableLayoutPanel1";
			this.tableLayoutPanel1.RowCount = 1;
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
			this.tableLayoutPanel1.Size = new System.Drawing.Size(150, 29);
			this.tableLayoutPanel1.TabIndex = 0;
			// 
			// nudColor
			// 
			this.nudColor.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
			this.nudColor.Location = new System.Drawing.Point(3, 4);
			this.nudColor.Maximum = new decimal(new int[] {
            31,
            0,
            0,
            0});
			this.nudColor.Name = "nudColor";
			this.nudColor.Size = new System.Drawing.Size(69, 20);
			this.nudColor.TabIndex = 0;
			this.nudColor.ValueChanged += new System.EventHandler(this.nudColor_ValueChanged);
			// 
			// panelColorPreview
			// 
			this.panelColorPreview.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.panelColorPreview.Dock = System.Windows.Forms.DockStyle.Fill;
			this.panelColorPreview.Location = new System.Drawing.Point(78, 3);
			this.panelColorPreview.Name = "panelColorPreview";
			this.panelColorPreview.Size = new System.Drawing.Size(69, 23);
			this.panelColorPreview.TabIndex = 1;
			this.panelColorPreview.MouseLeave += new System.EventHandler(this.panelColorPreview_MouseLeave);
			this.panelColorPreview.MouseHover += new System.EventHandler(this.panelColorPreview_MouseHover);
			// 
			// CostumeColorControl
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add(this.tableLayoutPanel1);
			this.Name = "CostumeColorControl";
			this.Size = new System.Drawing.Size(150, 29);
			this.tableLayoutPanel1.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.nudColor)).EndInit();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
		private System.Windows.Forms.Panel panelColorPreview;
		public System.Windows.Forms.NumericUpDown nudColor;
	}
}
