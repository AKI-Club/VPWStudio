namespace VPWStudio
{
	partial class AkiTextDialog
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
			this.lbEntries = new System.Windows.Forms.ListBox();
			this.tbTextValue = new System.Windows.Forms.TextBox();
			this.cbAvailableAkiText = new System.Windows.Forms.ComboBox();
			this.labelCurEntry = new System.Windows.Forms.Label();
			this.SuspendLayout();
			// 
			// lbEntries
			// 
			this.lbEntries.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
			this.lbEntries.FormattingEnabled = true;
			this.lbEntries.Location = new System.Drawing.Point(12, 39);
			this.lbEntries.Name = "lbEntries";
			this.lbEntries.ScrollAlwaysVisible = true;
			this.lbEntries.Size = new System.Drawing.Size(124, 251);
			this.lbEntries.TabIndex = 0;
			this.lbEntries.SelectedIndexChanged += new System.EventHandler(this.lbEntries_SelectedIndexChanged);
			// 
			// tbTextValue
			// 
			this.tbTextValue.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.tbTextValue.Location = new System.Drawing.Point(144, 39);
			this.tbTextValue.MaxLength = 65535;
			this.tbTextValue.Multiline = true;
			this.tbTextValue.Name = "tbTextValue";
			this.tbTextValue.ReadOnly = true;
			this.tbTextValue.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			this.tbTextValue.Size = new System.Drawing.Size(356, 251);
			this.tbTextValue.TabIndex = 1;
			// 
			// cbAvailableAkiText
			// 
			this.cbAvailableAkiText.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.cbAvailableAkiText.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cbAvailableAkiText.FormattingEnabled = true;
			this.cbAvailableAkiText.Location = new System.Drawing.Point(142, 12);
			this.cbAvailableAkiText.Name = "cbAvailableAkiText";
			this.cbAvailableAkiText.Size = new System.Drawing.Size(358, 21);
			this.cbAvailableAkiText.TabIndex = 2;
			this.cbAvailableAkiText.SelectedValueChanged += new System.EventHandler(this.cbAvailableAkiText_SelectedValueChanged);
			// 
			// labelCurEntry
			// 
			this.labelCurEntry.AutoSize = true;
			this.labelCurEntry.Location = new System.Drawing.Point(12, 15);
			this.labelCurEntry.Name = "labelCurEntry";
			this.labelCurEntry.Size = new System.Drawing.Size(124, 13);
			this.labelCurEntry.TabIndex = 3;
			this.labelCurEntry.Text = "Current AKI Text &Archive";
			// 
			// AkiTextDialog
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(512, 302);
			this.Controls.Add(this.labelCurEntry);
			this.Controls.Add(this.cbAvailableAkiText);
			this.Controls.Add(this.tbTextValue);
			this.Controls.Add(this.lbEntries);
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.MinimumSize = new System.Drawing.Size(514, 329);
			this.Name = "AkiTextDialog";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "AKI Text";
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.ListBox lbEntries;
		private System.Windows.Forms.TextBox tbTextValue;
		private System.Windows.Forms.ComboBox cbAvailableAkiText;
		private System.Windows.Forms.Label labelCurEntry;
	}
}