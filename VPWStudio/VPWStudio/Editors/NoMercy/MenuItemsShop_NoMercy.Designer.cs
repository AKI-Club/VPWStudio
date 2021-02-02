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
			this.tbHeaderData = new System.Windows.Forms.TextBox();
			this.cbEntries = new System.Windows.Forms.ComboBox();
			this.label1 = new System.Windows.Forms.Label();
			this.lblName = new System.Windows.Forms.Label();
			this.lblDescription = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.SuspendLayout();
			// 
			// tbName
			// 
			this.tbName.Location = new System.Drawing.Point(86, 65);
			this.tbName.Name = "tbName";
			this.tbName.Size = new System.Drawing.Size(381, 20);
			this.tbName.TabIndex = 0;
			// 
			// tbDescription
			// 
			this.tbDescription.Location = new System.Drawing.Point(86, 91);
			this.tbDescription.Name = "tbDescription";
			this.tbDescription.Size = new System.Drawing.Size(381, 20);
			this.tbDescription.TabIndex = 1;
			// 
			// tbHeaderData
			// 
			this.tbHeaderData.Location = new System.Drawing.Point(86, 39);
			this.tbHeaderData.Name = "tbHeaderData";
			this.tbHeaderData.ReadOnly = true;
			this.tbHeaderData.Size = new System.Drawing.Size(381, 20);
			this.tbHeaderData.TabIndex = 2;
			// 
			// cbEntries
			// 
			this.cbEntries.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cbEntries.FormattingEnabled = true;
			this.cbEntries.Location = new System.Drawing.Point(53, 12);
			this.cbEntries.Name = "cbEntries";
			this.cbEntries.Size = new System.Drawing.Size(414, 21);
			this.cbEntries.TabIndex = 3;
			this.cbEntries.SelectedIndexChanged += new System.EventHandler(this.cbEntries_SelectedIndexChanged);
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(12, 15);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(31, 13);
			this.label1.TabIndex = 4;
			this.label1.Text = "Entry";
			// 
			// lblName
			// 
			this.lblName.AutoSize = true;
			this.lblName.Location = new System.Drawing.Point(12, 68);
			this.lblName.Name = "lblName";
			this.lblName.Size = new System.Drawing.Size(35, 13);
			this.lblName.TabIndex = 5;
			this.lblName.Text = "Name";
			// 
			// lblDescription
			// 
			this.lblDescription.AutoSize = true;
			this.lblDescription.Location = new System.Drawing.Point(12, 94);
			this.lblDescription.Name = "lblDescription";
			this.lblDescription.Size = new System.Drawing.Size(60, 13);
			this.lblDescription.TabIndex = 6;
			this.lblDescription.Text = "Description";
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(12, 42);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(68, 13);
			this.label2.TabIndex = 7;
			this.label2.Text = "Header Data";
			// 
			// MenuItemsShop_NoMercy
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(479, 129);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.lblDescription);
			this.Controls.Add(this.lblName);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.cbEntries);
			this.Controls.Add(this.tbHeaderData);
			this.Controls.Add(this.tbDescription);
			this.Controls.Add(this.tbName);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "MenuItemsShop_NoMercy";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "MenuItemsShop_NoMercy";
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.TextBox tbName;
		private System.Windows.Forms.TextBox tbDescription;
		private System.Windows.Forms.TextBox tbHeaderData;
		private System.Windows.Forms.ComboBox cbEntries;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label lblName;
		private System.Windows.Forms.Label lblDescription;
		private System.Windows.Forms.Label label2;
	}
}