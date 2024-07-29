namespace VPWStudio
{
	partial class GlobalTextEditor
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
			this.btnOK = new System.Windows.Forms.Button();
			this.btnCancel = new System.Windows.Forms.Button();
			this.tbOutputTemp = new System.Windows.Forms.TextBox();
			this.cbEntriesTemp = new System.Windows.Forms.ComboBox();
			this.lblEntry = new System.Windows.Forms.Label();
			this.SuspendLayout();
			// 
			// btnOK
			// 
			this.btnOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.btnOK.Location = new System.Drawing.Point(328, 166);
			this.btnOK.Name = "btnOK";
			this.btnOK.Size = new System.Drawing.Size(75, 23);
			this.btnOK.TabIndex = 3;
			this.btnOK.Text = "&OK";
			this.btnOK.UseVisualStyleBackColor = true;
			this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
			// 
			// btnCancel
			// 
			this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.btnCancel.Location = new System.Drawing.Point(409, 166);
			this.btnCancel.Name = "btnCancel";
			this.btnCancel.Size = new System.Drawing.Size(75, 23);
			this.btnCancel.TabIndex = 4;
			this.btnCancel.Text = "&Cancel";
			this.btnCancel.UseVisualStyleBackColor = true;
			this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
			// 
			// tbOutputTemp
			// 
			this.tbOutputTemp.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.tbOutputTemp.Location = new System.Drawing.Point(12, 39);
			this.tbOutputTemp.Multiline = true;
			this.tbOutputTemp.Name = "tbOutputTemp";
			this.tbOutputTemp.ReadOnly = true;
			this.tbOutputTemp.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			this.tbOutputTemp.Size = new System.Drawing.Size(472, 121);
			this.tbOutputTemp.TabIndex = 2;
			// 
			// cbEntriesTemp
			// 
			this.cbEntriesTemp.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.cbEntriesTemp.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cbEntriesTemp.Font = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.cbEntriesTemp.FormattingEnabled = true;
			this.cbEntriesTemp.Location = new System.Drawing.Point(49, 12);
			this.cbEntriesTemp.Name = "cbEntriesTemp";
			this.cbEntriesTemp.Size = new System.Drawing.Size(435, 23);
			this.cbEntriesTemp.TabIndex = 1;
			this.cbEntriesTemp.SelectedIndexChanged += new System.EventHandler(this.cbEntriesTemp_SelectedIndexChanged);
			// 
			// lblEntry
			// 
			this.lblEntry.AutoSize = true;
			this.lblEntry.Location = new System.Drawing.Point(12, 15);
			this.lblEntry.Name = "lblEntry";
			this.lblEntry.Size = new System.Drawing.Size(31, 13);
			this.lblEntry.TabIndex = 0;
			this.lblEntry.Text = "&Entry";
			// 
			// GlobalTextEditor
			// 
			this.AcceptButton = this.btnOK;
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.CancelButton = this.btnCancel;
			this.ClientSize = new System.Drawing.Size(496, 201);
			this.Controls.Add(this.lblEntry);
			this.Controls.Add(this.cbEntriesTemp);
			this.Controls.Add(this.tbOutputTemp);
			this.Controls.Add(this.btnCancel);
			this.Controls.Add(this.btnOK);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.MinimumSize = new System.Drawing.Size(512, 240);
			this.Name = "GlobalTextEditor";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "Global Text Editor";
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Button btnOK;
		private System.Windows.Forms.Button btnCancel;
		private System.Windows.Forms.TextBox tbOutputTemp;
		private System.Windows.Forms.ComboBox cbEntriesTemp;
		private System.Windows.Forms.Label lblEntry;
	}
}