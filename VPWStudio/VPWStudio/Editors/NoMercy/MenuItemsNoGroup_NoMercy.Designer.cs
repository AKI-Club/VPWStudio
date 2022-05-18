namespace VPWStudio.Editors.NoMercy
{
	partial class MenuItemsNoGroup_NoMercy
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
			this.dgvMenuItems = new System.Windows.Forms.DataGridView();
			this.ItemValue = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.ItemName = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.buttonOK = new System.Windows.Forms.Button();
			this.buttonCancel = new System.Windows.Forms.Button();
			((System.ComponentModel.ISupportInitialize)(this.dgvMenuItems)).BeginInit();
			this.SuspendLayout();
			// 
			// dgvMenuItems
			// 
			this.dgvMenuItems.AllowUserToAddRows = false;
			this.dgvMenuItems.AllowUserToDeleteRows = false;
			this.dgvMenuItems.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.dgvMenuItems.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dgvMenuItems.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ItemValue,
            this.ItemName});
			this.dgvMenuItems.Location = new System.Drawing.Point(12, 12);
			this.dgvMenuItems.Name = "dgvMenuItems";
			this.dgvMenuItems.Size = new System.Drawing.Size(480, 288);
			this.dgvMenuItems.TabIndex = 0;
			this.dgvMenuItems.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvMenuItems_CellEndEdit);
			// 
			// ItemValue
			// 
			this.ItemValue.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
			this.ItemValue.FillWeight = 25F;
			this.ItemValue.HeaderText = " Value";
			this.ItemValue.MaxInputLength = 3;
			this.ItemValue.Name = "ItemValue";
			// 
			// ItemName
			// 
			this.ItemName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
			this.ItemName.FillWeight = 75F;
			this.ItemName.HeaderText = "Name";
			this.ItemName.Name = "ItemName";
			// 
			// buttonOK
			// 
			this.buttonOK.Location = new System.Drawing.Point(336, 310);
			this.buttonOK.Name = "buttonOK";
			this.buttonOK.Size = new System.Drawing.Size(75, 23);
			this.buttonOK.TabIndex = 1;
			this.buttonOK.Text = "&OK";
			this.buttonOK.UseVisualStyleBackColor = true;
			this.buttonOK.Click += new System.EventHandler(this.buttonOK_Click);
			// 
			// buttonCancel
			// 
			this.buttonCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.buttonCancel.Location = new System.Drawing.Point(417, 310);
			this.buttonCancel.Name = "buttonCancel";
			this.buttonCancel.Size = new System.Drawing.Size(75, 23);
			this.buttonCancel.TabIndex = 2;
			this.buttonCancel.Text = "&Cancel";
			this.buttonCancel.UseVisualStyleBackColor = true;
			this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
			// 
			// MenuItemsNoGroup_NoMercy
			// 
			this.AcceptButton = this.buttonOK;
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.CancelButton = this.buttonCancel;
			this.ClientSize = new System.Drawing.Size(504, 345);
			this.Controls.Add(this.buttonCancel);
			this.Controls.Add(this.buttonOK);
			this.Controls.Add(this.dgvMenuItems);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "MenuItemsNoGroup_NoMercy";
			this.ShowInTaskbar = false;
			this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "Menu Item Editor - Groupless";
			((System.ComponentModel.ISupportInitialize)(this.dgvMenuItems)).EndInit();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.DataGridView dgvMenuItems;
		private System.Windows.Forms.Button buttonOK;
		private System.Windows.Forms.Button buttonCancel;
		private System.Windows.Forms.DataGridViewTextBoxColumn ItemValue;
		private System.Windows.Forms.DataGridViewTextBoxColumn ItemName;
	}
}