namespace VPWStudio.Editors.NoMercy
{
	partial class MenuItemsShop_NoMercy
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
			this.tbName = new System.Windows.Forms.TextBox();
			this.tbDescription = new System.Windows.Forms.TextBox();
			this.cbEntries = new System.Windows.Forms.ComboBox();
			this.label1 = new System.Windows.Forms.Label();
			this.lblName = new System.Windows.Forms.Label();
			this.lblDescription = new System.Windows.Forms.Label();
			this.buttonOK = new System.Windows.Forms.Button();
			this.buttonCancel = new System.Windows.Forms.Button();
			this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
			this.lblPrice = new System.Windows.Forms.Label();
			this.lblUnlockID = new System.Windows.Forms.Label();
			this.lblItemType = new System.Windows.Forms.Label();
			this.lblItemData = new System.Windows.Forms.Label();
			this.nudPrice = new System.Windows.Forms.NumericUpDown();
			this.tbUnlockID = new System.Windows.Forms.TextBox();
			this.tbItemType = new System.Windows.Forms.TextBox();
			this.tbItemData = new System.Windows.Forms.TextBox();
			this.btnUpdateEntry = new System.Windows.Forms.Button();
			this.tableLayoutPanel1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.nudPrice)).BeginInit();
			this.SuspendLayout();
			// 
			// tbName
			// 
			this.tbName.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
			this.tbName.Location = new System.Drawing.Point(139, 5);
			this.tbName.Name = "tbName";
			this.tbName.Size = new System.Drawing.Size(313, 20);
			this.tbName.TabIndex = 3;
			// 
			// tbDescription
			// 
			this.tbDescription.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
			this.tbDescription.Location = new System.Drawing.Point(139, 36);
			this.tbDescription.Name = "tbDescription";
			this.tbDescription.Size = new System.Drawing.Size(313, 20);
			this.tbDescription.TabIndex = 4;
			// 
			// cbEntries
			// 
			this.cbEntries.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cbEntries.FormattingEnabled = true;
			this.cbEntries.Location = new System.Drawing.Point(53, 12);
			this.cbEntries.Name = "cbEntries";
			this.cbEntries.Size = new System.Drawing.Size(414, 21);
			this.cbEntries.TabIndex = 1;
			this.cbEntries.SelectedIndexChanged += new System.EventHandler(this.cbEntries_SelectedIndexChanged);
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(12, 15);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(31, 13);
			this.label1.TabIndex = 1;
			this.label1.Text = "&Entry";
			// 
			// lblName
			// 
			this.lblName.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
			this.lblName.AutoSize = true;
			this.lblName.Location = new System.Drawing.Point(3, 9);
			this.lblName.Name = "lblName";
			this.lblName.Size = new System.Drawing.Size(130, 13);
			this.lblName.TabIndex = 3;
			this.lblName.Text = "&Name";
			// 
			// lblDescription
			// 
			this.lblDescription.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
			this.lblDescription.AutoSize = true;
			this.lblDescription.Location = new System.Drawing.Point(3, 40);
			this.lblDescription.Name = "lblDescription";
			this.lblDescription.Size = new System.Drawing.Size(130, 13);
			this.lblDescription.TabIndex = 4;
			this.lblDescription.Text = "&Description";
			// 
			// buttonOK
			// 
			this.buttonOK.Location = new System.Drawing.Point(311, 234);
			this.buttonOK.Name = "buttonOK";
			this.buttonOK.Size = new System.Drawing.Size(75, 23);
			this.buttonOK.TabIndex = 10;
			this.buttonOK.Text = "&OK";
			this.buttonOK.UseVisualStyleBackColor = true;
			this.buttonOK.Click += new System.EventHandler(this.buttonOK_Click);
			// 
			// buttonCancel
			// 
			this.buttonCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.buttonCancel.Location = new System.Drawing.Point(392, 234);
			this.buttonCancel.Name = "buttonCancel";
			this.buttonCancel.Size = new System.Drawing.Size(75, 23);
			this.buttonCancel.TabIndex = 11;
			this.buttonCancel.Text = "&Cancel";
			this.buttonCancel.UseVisualStyleBackColor = true;
			this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
			// 
			// tableLayoutPanel1
			// 
			this.tableLayoutPanel1.ColumnCount = 2;
			this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 30F));
			this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 70F));
			this.tableLayoutPanel1.Controls.Add(this.lblName, 0, 0);
			this.tableLayoutPanel1.Controls.Add(this.lblDescription, 0, 1);
			this.tableLayoutPanel1.Controls.Add(this.tbName, 1, 0);
			this.tableLayoutPanel1.Controls.Add(this.tbDescription, 1, 1);
			this.tableLayoutPanel1.Controls.Add(this.lblPrice, 0, 2);
			this.tableLayoutPanel1.Controls.Add(this.lblUnlockID, 0, 3);
			this.tableLayoutPanel1.Controls.Add(this.lblItemType, 0, 4);
			this.tableLayoutPanel1.Controls.Add(this.lblItemData, 0, 5);
			this.tableLayoutPanel1.Controls.Add(this.nudPrice, 1, 2);
			this.tableLayoutPanel1.Controls.Add(this.tbUnlockID, 1, 3);
			this.tableLayoutPanel1.Controls.Add(this.tbItemType, 1, 4);
			this.tableLayoutPanel1.Controls.Add(this.tbItemData, 1, 5);
			this.tableLayoutPanel1.Location = new System.Drawing.Point(12, 39);
			this.tableLayoutPanel1.Name = "tableLayoutPanel1";
			this.tableLayoutPanel1.RowCount = 6;
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
			this.tableLayoutPanel1.Size = new System.Drawing.Size(455, 189);
			this.tableLayoutPanel1.TabIndex = 2;
			// 
			// lblPrice
			// 
			this.lblPrice.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
			this.lblPrice.AutoSize = true;
			this.lblPrice.Location = new System.Drawing.Point(3, 71);
			this.lblPrice.Name = "lblPrice";
			this.lblPrice.Size = new System.Drawing.Size(130, 13);
			this.lblPrice.TabIndex = 5;
			this.lblPrice.Text = "&Price";
			// 
			// lblUnlockID
			// 
			this.lblUnlockID.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
			this.lblUnlockID.AutoSize = true;
			this.lblUnlockID.Location = new System.Drawing.Point(3, 102);
			this.lblUnlockID.Name = "lblUnlockID";
			this.lblUnlockID.Size = new System.Drawing.Size(130, 13);
			this.lblUnlockID.TabIndex = 6;
			this.lblUnlockID.Text = "Unlock &ID";
			// 
			// lblItemType
			// 
			this.lblItemType.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
			this.lblItemType.AutoSize = true;
			this.lblItemType.Location = new System.Drawing.Point(3, 133);
			this.lblItemType.Name = "lblItemType";
			this.lblItemType.Size = new System.Drawing.Size(130, 13);
			this.lblItemType.TabIndex = 7;
			this.lblItemType.Text = "Item &Type";
			// 
			// lblItemData
			// 
			this.lblItemData.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
			this.lblItemData.AutoSize = true;
			this.lblItemData.Location = new System.Drawing.Point(3, 165);
			this.lblItemData.Name = "lblItemData";
			this.lblItemData.Size = new System.Drawing.Size(130, 13);
			this.lblItemData.TabIndex = 8;
			this.lblItemData.Text = "Item D&ata";
			// 
			// nudPrice
			// 
			this.nudPrice.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
			this.nudPrice.Location = new System.Drawing.Point(139, 67);
			this.nudPrice.Maximum = new decimal(new int[] {
            -1,
            0,
            0,
            0});
			this.nudPrice.Name = "nudPrice";
			this.nudPrice.Size = new System.Drawing.Size(313, 20);
			this.nudPrice.TabIndex = 5;
			// 
			// tbUnlockID
			// 
			this.tbUnlockID.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
			this.tbUnlockID.Location = new System.Drawing.Point(139, 98);
			this.tbUnlockID.Name = "tbUnlockID";
			this.tbUnlockID.ReadOnly = true;
			this.tbUnlockID.Size = new System.Drawing.Size(313, 20);
			this.tbUnlockID.TabIndex = 6;
			// 
			// tbItemType
			// 
			this.tbItemType.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
			this.tbItemType.Location = new System.Drawing.Point(139, 129);
			this.tbItemType.Name = "tbItemType";
			this.tbItemType.ReadOnly = true;
			this.tbItemType.Size = new System.Drawing.Size(313, 20);
			this.tbItemType.TabIndex = 7;
			// 
			// tbItemData
			// 
			this.tbItemData.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
			this.tbItemData.Location = new System.Drawing.Point(139, 162);
			this.tbItemData.Name = "tbItemData";
			this.tbItemData.ReadOnly = true;
			this.tbItemData.Size = new System.Drawing.Size(313, 20);
			this.tbItemData.TabIndex = 8;
			// 
			// btnUpdateEntry
			// 
			this.btnUpdateEntry.Location = new System.Drawing.Point(12, 234);
			this.btnUpdateEntry.Name = "btnUpdateEntry";
			this.btnUpdateEntry.Size = new System.Drawing.Size(133, 23);
			this.btnUpdateEntry.TabIndex = 9;
			this.btnUpdateEntry.Text = "&Update Entry";
			this.btnUpdateEntry.UseVisualStyleBackColor = true;
			this.btnUpdateEntry.Click += new System.EventHandler(this.btnUpdateEntry_Click);
			// 
			// MenuItemsShop_NoMercy
			// 
			this.AcceptButton = this.buttonOK;
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.CancelButton = this.buttonCancel;
			this.ClientSize = new System.Drawing.Size(479, 269);
			this.Controls.Add(this.btnUpdateEntry);
			this.Controls.Add(this.tableLayoutPanel1);
			this.Controls.Add(this.buttonCancel);
			this.Controls.Add(this.buttonOK);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.cbEntries);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "MenuItemsShop_NoMercy";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "No Mercy Smackdown Mall Shop Items";
			this.tableLayoutPanel1.ResumeLayout(false);
			this.tableLayoutPanel1.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.nudPrice)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.TextBox tbName;
		private System.Windows.Forms.TextBox tbDescription;
		private System.Windows.Forms.ComboBox cbEntries;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label lblName;
		private System.Windows.Forms.Label lblDescription;
		private System.Windows.Forms.Button buttonOK;
		private System.Windows.Forms.Button buttonCancel;
		private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
		private System.Windows.Forms.Label lblPrice;
		private System.Windows.Forms.Label lblUnlockID;
		private System.Windows.Forms.Label lblItemType;
		private System.Windows.Forms.Label lblItemData;
		private System.Windows.Forms.NumericUpDown nudPrice;
		private System.Windows.Forms.TextBox tbUnlockID;
		private System.Windows.Forms.TextBox tbItemType;
		private System.Windows.Forms.TextBox tbItemData;
		private System.Windows.Forms.Button btnUpdateEntry;
	}
}