
namespace VPWStudio.Editors.VPW64
{
	partial class GameIntroEditor_VPW64
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
			this.tbOutput = new System.Windows.Forms.TextBox();
			this.label1 = new System.Windows.Forms.Label();
			this.cbIntroEntries = new System.Windows.Forms.ComboBox();
			this.SuspendLayout();
			// 
			// tbOutput
			// 
			this.tbOutput.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.tbOutput.Font = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.tbOutput.Location = new System.Drawing.Point(12, 39);
			this.tbOutput.MaxLength = 65535;
			this.tbOutput.Multiline = true;
			this.tbOutput.Name = "tbOutput";
			this.tbOutput.ReadOnly = true;
			this.tbOutput.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			this.tbOutput.Size = new System.Drawing.Size(472, 270);
			this.tbOutput.TabIndex = 0;
			// 
			// label1
			// 
			this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(12, 15);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(31, 13);
			this.label1.TabIndex = 1;
			this.label1.Text = "&Entry";
			// 
			// cbIntroEntries
			// 
			this.cbIntroEntries.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.cbIntroEntries.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cbIntroEntries.FormattingEnabled = true;
			this.cbIntroEntries.Location = new System.Drawing.Point(49, 12);
			this.cbIntroEntries.Name = "cbIntroEntries";
			this.cbIntroEntries.Size = new System.Drawing.Size(435, 21);
			this.cbIntroEntries.TabIndex = 2;
			this.cbIntroEntries.SelectedIndexChanged += new System.EventHandler(this.cbIntroEntries_SelectedIndexChanged);
			// 
			// GameIntroEditor_VPW64
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(496, 321);
			this.Controls.Add(this.cbIntroEntries);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.tbOutput);
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "GameIntroEditor_VPW64";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "VPW64 Game Intro Editor";
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.TextBox tbOutput;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.ComboBox cbIntroEntries;
	}
}