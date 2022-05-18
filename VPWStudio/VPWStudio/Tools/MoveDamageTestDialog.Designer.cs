namespace VPWStudio
{
	partial class MoveDamageTestDialog
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
			this.cbMoveDamageEntries = new System.Windows.Forms.ComboBox();
			this.tbOutput = new System.Windows.Forms.TextBox();
			this.SuspendLayout();
			// 
			// cbMoveDamageEntries
			// 
			this.cbMoveDamageEntries.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.cbMoveDamageEntries.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cbMoveDamageEntries.FormattingEnabled = true;
			this.cbMoveDamageEntries.Location = new System.Drawing.Point(12, 12);
			this.cbMoveDamageEntries.Name = "cbMoveDamageEntries";
			this.cbMoveDamageEntries.Size = new System.Drawing.Size(470, 21);
			this.cbMoveDamageEntries.TabIndex = 3;
			this.cbMoveDamageEntries.SelectedIndexChanged += new System.EventHandler(this.cbMoveDamageEntries_SelectedIndexChanged);
			// 
			// tbOutput
			// 
			this.tbOutput.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.tbOutput.Font = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.tbOutput.Location = new System.Drawing.Point(12, 40);
			this.tbOutput.Multiline = true;
			this.tbOutput.Name = "tbOutput";
			this.tbOutput.ReadOnly = true;
			this.tbOutput.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			this.tbOutput.Size = new System.Drawing.Size(470, 242);
			this.tbOutput.TabIndex = 2;
			// 
			// MoveDamageTestDialog
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(494, 295);
			this.Controls.Add(this.cbMoveDamageEntries);
			this.Controls.Add(this.tbOutput);
			this.KeyPreview = true;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.MinimumSize = new System.Drawing.Size(500, 320);
			this.Name = "MoveDamageTestDialog";
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "Move Damage Test";
			this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.MoveDamageTestDialog_KeyDown);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.ComboBox cbMoveDamageEntries;
		private System.Windows.Forms.TextBox tbOutput;
	}
}