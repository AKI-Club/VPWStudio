
namespace VPWStudio.Editors.NoMercy
{
	partial class StoryMode_NoMercy
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
			this.cbStoryPath = new System.Windows.Forms.ComboBox();
			this.lblStoryPath = new System.Windows.Forms.Label();
			this.SuspendLayout();
			// 
			// cbStoryPath
			// 
			this.cbStoryPath.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.cbStoryPath.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cbStoryPath.FormattingEnabled = true;
			this.cbStoryPath.Items.AddRange(new object[] {
            "World Heavyweight",
            "Tag Team",
            "Intercontinental",
            "European",
            "Hardcore",
            "Light Heavyweight",
            "Women\'s",
            "No Mercy GBC"});
			this.cbStoryPath.Location = new System.Drawing.Point(74, 12);
			this.cbStoryPath.Name = "cbStoryPath";
			this.cbStoryPath.Size = new System.Drawing.Size(538, 21);
			this.cbStoryPath.TabIndex = 0;
			this.cbStoryPath.SelectedIndexChanged += new System.EventHandler(this.cbStoryPath_SelectedIndexChanged);
			// 
			// lblStoryPath
			// 
			this.lblStoryPath.AutoSize = true;
			this.lblStoryPath.Location = new System.Drawing.Point(12, 15);
			this.lblStoryPath.Name = "lblStoryPath";
			this.lblStoryPath.Size = new System.Drawing.Size(56, 13);
			this.lblStoryPath.TabIndex = 1;
			this.lblStoryPath.Text = "Story &Path";
			// 
			// StoryMode_NoMercy
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(624, 361);
			this.Controls.Add(this.lblStoryPath);
			this.Controls.Add(this.cbStoryPath);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.MinimizeBox = false;
			this.Name = "StoryMode_NoMercy";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "No Mercy Story Mode";
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.ComboBox cbStoryPath;
		private System.Windows.Forms.Label lblStoryPath;
	}
}