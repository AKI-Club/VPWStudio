namespace VPWStudio
{
	partial class FaceTester
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
			this.gbPreview = new System.Windows.Forms.GroupBox();
			this.pbFacePreview = new System.Windows.Forms.PictureBox();
			this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
			this.cbHairColor = new System.Windows.Forms.ComboBox();
			this.labelSkinColor = new System.Windows.Forms.Label();
			this.labelFaceNum = new System.Windows.Forms.Label();
			this.cbSkinColor = new System.Windows.Forms.ComboBox();
			this.cbFace = new System.Windows.Forms.ComboBox();
			this.labelAccessory = new System.Windows.Forms.Label();
			this.cbAccessory = new System.Windows.Forms.ComboBox();
			this.cbPaint = new System.Windows.Forms.ComboBox();
			this.labelPaint = new System.Windows.Forms.Label();
			this.cbFacialHair = new System.Windows.Forms.ComboBox();
			this.labelFacialHair = new System.Windows.Forms.Label();
			this.cbFrontHair = new System.Windows.Forms.ComboBox();
			this.labelFrontHair = new System.Windows.Forms.Label();
			this.labelHairColor = new System.Windows.Forms.Label();
			this.labelDValue = new System.Windows.Forms.Label();
			this.label1 = new System.Windows.Forms.Label();
			this.labelAValue = new System.Windows.Forms.Label();
			this.labelFValue = new System.Windows.Forms.Label();
			this.label9 = new System.Windows.Forms.Label();
			this.label8 = new System.Windows.Forms.Label();
			this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
			this.gbPreview.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.pbFacePreview)).BeginInit();
			this.tableLayoutPanel1.SuspendLayout();
			this.tableLayoutPanel2.SuspendLayout();
			this.SuspendLayout();
			// 
			// gbPreview
			// 
			this.gbPreview.Controls.Add(this.pbFacePreview);
			this.gbPreview.Location = new System.Drawing.Point(398, 12);
			this.gbPreview.Name = "gbPreview";
			this.gbPreview.Size = new System.Drawing.Size(62, 100);
			this.gbPreview.TabIndex = 0;
			this.gbPreview.TabStop = false;
			this.gbPreview.Text = "Preview";
			// 
			// pbFacePreview
			// 
			this.pbFacePreview.Location = new System.Drawing.Point(15, 19);
			this.pbFacePreview.Name = "pbFacePreview";
			this.pbFacePreview.Size = new System.Drawing.Size(32, 64);
			this.pbFacePreview.TabIndex = 0;
			this.pbFacePreview.TabStop = false;
			// 
			// tableLayoutPanel1
			// 
			this.tableLayoutPanel1.ColumnCount = 2;
			this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 30F));
			this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 70F));
			this.tableLayoutPanel1.Controls.Add(this.cbHairColor, 1, 2);
			this.tableLayoutPanel1.Controls.Add(this.labelSkinColor, 0, 0);
			this.tableLayoutPanel1.Controls.Add(this.labelFaceNum, 0, 1);
			this.tableLayoutPanel1.Controls.Add(this.cbSkinColor, 1, 0);
			this.tableLayoutPanel1.Controls.Add(this.cbFace, 1, 1);
			this.tableLayoutPanel1.Controls.Add(this.labelAccessory, 0, 6);
			this.tableLayoutPanel1.Controls.Add(this.cbAccessory, 1, 6);
			this.tableLayoutPanel1.Controls.Add(this.cbPaint, 1, 5);
			this.tableLayoutPanel1.Controls.Add(this.labelPaint, 0, 5);
			this.tableLayoutPanel1.Controls.Add(this.cbFacialHair, 1, 4);
			this.tableLayoutPanel1.Controls.Add(this.labelFacialHair, 0, 4);
			this.tableLayoutPanel1.Controls.Add(this.cbFrontHair, 1, 3);
			this.tableLayoutPanel1.Controls.Add(this.labelFrontHair, 0, 3);
			this.tableLayoutPanel1.Controls.Add(this.labelHairColor, 0, 2);
			this.tableLayoutPanel1.Location = new System.Drawing.Point(12, 12);
			this.tableLayoutPanel1.Name = "tableLayoutPanel1";
			this.tableLayoutPanel1.RowCount = 7;
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 14.28571F));
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 14.28571F));
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 14.28571F));
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 14.28571F));
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 14.28571F));
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 14.28571F));
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 14.28571F));
			this.tableLayoutPanel1.Size = new System.Drawing.Size(380, 179);
			this.tableLayoutPanel1.TabIndex = 1;
			// 
			// cbHairColor
			// 
			this.cbHairColor.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
			this.cbHairColor.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cbHairColor.FormattingEnabled = true;
			this.cbHairColor.Items.AddRange(new object[] {
            "0",
            "1",
            "2",
            "3",
            "4",
            "5",
            "6",
            "7"});
			this.cbHairColor.Location = new System.Drawing.Point(117, 53);
			this.cbHairColor.Name = "cbHairColor";
			this.cbHairColor.Size = new System.Drawing.Size(260, 21);
			this.cbHairColor.TabIndex = 13;
			this.cbHairColor.SelectedIndexChanged += new System.EventHandler(this.cbHairColor_SelectedIndexChanged);
			// 
			// labelSkinColor
			// 
			this.labelSkinColor.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
			this.labelSkinColor.AutoSize = true;
			this.labelSkinColor.Location = new System.Drawing.Point(3, 6);
			this.labelSkinColor.Name = "labelSkinColor";
			this.labelSkinColor.Size = new System.Drawing.Size(108, 13);
			this.labelSkinColor.TabIndex = 0;
			this.labelSkinColor.Text = "Skin Color";
			// 
			// labelFaceNum
			// 
			this.labelFaceNum.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
			this.labelFaceNum.AutoSize = true;
			this.labelFaceNum.Location = new System.Drawing.Point(3, 31);
			this.labelFaceNum.Name = "labelFaceNum";
			this.labelFaceNum.Size = new System.Drawing.Size(108, 13);
			this.labelFaceNum.TabIndex = 1;
			this.labelFaceNum.Text = "Face";
			// 
			// cbSkinColor
			// 
			this.cbSkinColor.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
			this.cbSkinColor.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cbSkinColor.FormattingEnabled = true;
			this.cbSkinColor.Items.AddRange(new object[] {
            "0",
            "1",
            "2",
            "3"});
			this.cbSkinColor.Location = new System.Drawing.Point(117, 3);
			this.cbSkinColor.Name = "cbSkinColor";
			this.cbSkinColor.Size = new System.Drawing.Size(260, 21);
			this.cbSkinColor.TabIndex = 6;
			this.cbSkinColor.SelectedIndexChanged += new System.EventHandler(this.cbSkinColor_SelectedIndexChanged);
			// 
			// cbFace
			// 
			this.cbFace.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
			this.cbFace.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cbFace.FormattingEnabled = true;
			this.cbFace.Location = new System.Drawing.Point(117, 28);
			this.cbFace.Name = "cbFace";
			this.cbFace.Size = new System.Drawing.Size(260, 21);
			this.cbFace.TabIndex = 7;
			this.cbFace.SelectedIndexChanged += new System.EventHandler(this.cbFace_SelectedIndexChanged);
			// 
			// labelAccessory
			// 
			this.labelAccessory.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
			this.labelAccessory.AutoSize = true;
			this.labelAccessory.Location = new System.Drawing.Point(3, 158);
			this.labelAccessory.Name = "labelAccessory";
			this.labelAccessory.Size = new System.Drawing.Size(108, 13);
			this.labelAccessory.TabIndex = 5;
			this.labelAccessory.Text = "Accessory";
			// 
			// cbAccessory
			// 
			this.cbAccessory.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
			this.cbAccessory.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cbAccessory.FormattingEnabled = true;
			this.cbAccessory.Items.AddRange(new object[] {
            "None",
            "01",
            "02",
            "03",
            "04",
            "05",
            "06",
            "07",
            "08",
            "09",
            "10",
            "11",
            "12",
            "13",
            "14",
            "15",
            "16",
            "17",
            "18",
            "19",
            "20",
            "21",
            "22",
            "23",
            "24",
            "25",
            "26",
            "27",
            "28",
            "29",
            "30",
            "31"});
			this.cbAccessory.Location = new System.Drawing.Point(117, 154);
			this.cbAccessory.Name = "cbAccessory";
			this.cbAccessory.Size = new System.Drawing.Size(260, 21);
			this.cbAccessory.TabIndex = 11;
			this.cbAccessory.SelectedIndexChanged += new System.EventHandler(this.cbAccessory_SelectedIndexChanged);
			// 
			// cbPaint
			// 
			this.cbPaint.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
			this.cbPaint.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cbPaint.FormattingEnabled = true;
			this.cbPaint.Items.AddRange(new object[] {
            "None",
            "01",
            "02",
            "03",
            "04",
            "05",
            "06",
            "07",
            "08",
            "09",
            "10",
            "11",
            "12",
            "13",
            "14",
            "15",
            "16",
            "17",
            "18",
            "19",
            "20",
            "21",
            "22",
            "23",
            "24",
            "25",
            "26",
            "27",
            "28",
            "29",
            "30",
            "31"});
			this.cbPaint.Location = new System.Drawing.Point(117, 128);
			this.cbPaint.Name = "cbPaint";
			this.cbPaint.Size = new System.Drawing.Size(260, 21);
			this.cbPaint.TabIndex = 10;
			this.cbPaint.SelectedIndexChanged += new System.EventHandler(this.cbPaint_SelectedIndexChanged);
			// 
			// labelPaint
			// 
			this.labelPaint.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
			this.labelPaint.AutoSize = true;
			this.labelPaint.Location = new System.Drawing.Point(3, 131);
			this.labelPaint.Name = "labelPaint";
			this.labelPaint.Size = new System.Drawing.Size(108, 13);
			this.labelPaint.TabIndex = 4;
			this.labelPaint.Text = "Paint";
			// 
			// cbFacialHair
			// 
			this.cbFacialHair.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
			this.cbFacialHair.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cbFacialHair.FormattingEnabled = true;
			this.cbFacialHair.Items.AddRange(new object[] {
            "None",
            "01",
            "02",
            "03",
            "04",
            "05",
            "06",
            "07",
            "08",
            "09",
            "10",
            "11",
            "12",
            "13",
            "14",
            "15",
            "16",
            "17",
            "18",
            "19",
            "20",
            "21",
            "22",
            "23",
            "24",
            "25",
            "26",
            "27",
            "28",
            "29",
            "30",
            "31"});
			this.cbFacialHair.Location = new System.Drawing.Point(117, 103);
			this.cbFacialHair.Name = "cbFacialHair";
			this.cbFacialHair.Size = new System.Drawing.Size(260, 21);
			this.cbFacialHair.TabIndex = 9;
			this.cbFacialHair.SelectedIndexChanged += new System.EventHandler(this.cbFacialHair_SelectedIndexChanged);
			// 
			// labelFacialHair
			// 
			this.labelFacialHair.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
			this.labelFacialHair.AutoSize = true;
			this.labelFacialHair.Location = new System.Drawing.Point(3, 106);
			this.labelFacialHair.Name = "labelFacialHair";
			this.labelFacialHair.Size = new System.Drawing.Size(108, 13);
			this.labelFacialHair.TabIndex = 3;
			this.labelFacialHair.Text = "Facial Hair";
			// 
			// cbFrontHair
			// 
			this.cbFrontHair.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
			this.cbFrontHair.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cbFrontHair.FormattingEnabled = true;
			this.cbFrontHair.Location = new System.Drawing.Point(117, 78);
			this.cbFrontHair.Name = "cbFrontHair";
			this.cbFrontHair.Size = new System.Drawing.Size(260, 21);
			this.cbFrontHair.TabIndex = 8;
			this.cbFrontHair.SelectedIndexChanged += new System.EventHandler(this.cbFrontHair_SelectedIndexChanged);
			// 
			// labelFrontHair
			// 
			this.labelFrontHair.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
			this.labelFrontHair.AutoSize = true;
			this.labelFrontHair.Location = new System.Drawing.Point(3, 81);
			this.labelFrontHair.Name = "labelFrontHair";
			this.labelFrontHair.Size = new System.Drawing.Size(108, 13);
			this.labelFrontHair.TabIndex = 2;
			this.labelFrontHair.Text = "Front Hair";
			// 
			// labelHairColor
			// 
			this.labelHairColor.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
			this.labelHairColor.AutoSize = true;
			this.labelHairColor.Location = new System.Drawing.Point(3, 56);
			this.labelHairColor.Name = "labelHairColor";
			this.labelHairColor.Size = new System.Drawing.Size(108, 13);
			this.labelHairColor.TabIndex = 12;
			this.labelHairColor.Text = "Hair Color";
			// 
			// labelDValue
			// 
			this.labelDValue.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
			this.labelDValue.AutoSize = true;
			this.labelDValue.Location = new System.Drawing.Point(21, 54);
			this.labelDValue.Name = "labelDValue";
			this.labelDValue.Size = new System.Drawing.Size(38, 13);
			this.labelDValue.TabIndex = 5;
			this.labelDValue.Text = "0";
			// 
			// label1
			// 
			this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(3, 54);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(12, 13);
			this.label1.TabIndex = 4;
			this.label1.Text = "D";
			// 
			// labelAValue
			// 
			this.labelAValue.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
			this.labelAValue.AutoSize = true;
			this.labelAValue.Location = new System.Drawing.Point(21, 29);
			this.labelAValue.Name = "labelAValue";
			this.labelAValue.Size = new System.Drawing.Size(38, 13);
			this.labelAValue.TabIndex = 3;
			this.labelAValue.Text = "0";
			// 
			// labelFValue
			// 
			this.labelFValue.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
			this.labelFValue.AutoSize = true;
			this.labelFValue.Location = new System.Drawing.Point(21, 5);
			this.labelFValue.Name = "labelFValue";
			this.labelFValue.Size = new System.Drawing.Size(38, 13);
			this.labelFValue.TabIndex = 2;
			this.labelFValue.Text = "0";
			// 
			// label9
			// 
			this.label9.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
			this.label9.AutoSize = true;
			this.label9.Location = new System.Drawing.Point(3, 29);
			this.label9.Name = "label9";
			this.label9.Size = new System.Drawing.Size(12, 13);
			this.label9.TabIndex = 1;
			this.label9.Text = "A";
			// 
			// label8
			// 
			this.label8.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
			this.label8.AutoSize = true;
			this.label8.Location = new System.Drawing.Point(3, 5);
			this.label8.Name = "label8";
			this.label8.Size = new System.Drawing.Size(12, 13);
			this.label8.TabIndex = 0;
			this.label8.Text = "F";
			// 
			// tableLayoutPanel2
			// 
			this.tableLayoutPanel2.ColumnCount = 2;
			this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 30F));
			this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 70F));
			this.tableLayoutPanel2.Controls.Add(this.label8, 0, 0);
			this.tableLayoutPanel2.Controls.Add(this.label9, 0, 1);
			this.tableLayoutPanel2.Controls.Add(this.labelFValue, 1, 0);
			this.tableLayoutPanel2.Controls.Add(this.labelAValue, 1, 1);
			this.tableLayoutPanel2.Controls.Add(this.label1, 0, 2);
			this.tableLayoutPanel2.Controls.Add(this.labelDValue, 1, 2);
			this.tableLayoutPanel2.Location = new System.Drawing.Point(398, 118);
			this.tableLayoutPanel2.Name = "tableLayoutPanel2";
			this.tableLayoutPanel2.RowCount = 3;
			this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
			this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
			this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
			this.tableLayoutPanel2.Size = new System.Drawing.Size(62, 73);
			this.tableLayoutPanel2.TabIndex = 2;
			// 
			// FaceTester
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(472, 203);
			this.Controls.Add(this.tableLayoutPanel2);
			this.Controls.Add(this.tableLayoutPanel1);
			this.Controls.Add(this.gbPreview);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "FaceTester";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "VPW2 Face Tester";
			this.gbPreview.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.pbFacePreview)).EndInit();
			this.tableLayoutPanel1.ResumeLayout(false);
			this.tableLayoutPanel1.PerformLayout();
			this.tableLayoutPanel2.ResumeLayout(false);
			this.tableLayoutPanel2.PerformLayout();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.GroupBox gbPreview;
		private System.Windows.Forms.PictureBox pbFacePreview;
		private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
		private System.Windows.Forms.Label labelSkinColor;
		private System.Windows.Forms.Label labelFaceNum;
		private System.Windows.Forms.Label labelFrontHair;
		private System.Windows.Forms.Label labelFacialHair;
		private System.Windows.Forms.Label labelPaint;
		private System.Windows.Forms.Label labelAccessory;
		private System.Windows.Forms.ComboBox cbSkinColor;
		private System.Windows.Forms.ComboBox cbFace;
		private System.Windows.Forms.ComboBox cbFrontHair;
		private System.Windows.Forms.ComboBox cbFacialHair;
		private System.Windows.Forms.ComboBox cbPaint;
		private System.Windows.Forms.ComboBox cbAccessory;
		private System.Windows.Forms.ComboBox cbHairColor;
		private System.Windows.Forms.Label labelHairColor;
		private System.Windows.Forms.Label labelDValue;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label labelAValue;
		private System.Windows.Forms.Label labelFValue;
		private System.Windows.Forms.Label label9;
		private System.Windows.Forms.Label label8;
		private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
	}
}