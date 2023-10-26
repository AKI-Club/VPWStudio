
namespace VPWStudio.Editors
{
	partial class ChampionshipDefs_Early
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
			this.cbStables = new System.Windows.Forms.ComboBox();
			this.tbOutput = new System.Windows.Forms.TextBox();
			this.SuspendLayout();
			// 
			// cbStables
			// 
			this.cbStables.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.cbStables.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cbStables.FormattingEnabled = true;
			this.cbStables.Location = new System.Drawing.Point(12, 12);
			this.cbStables.Name = "cbStables";
			this.cbStables.Size = new System.Drawing.Size(560, 21);
			this.cbStables.TabIndex = 0;
			this.cbStables.SelectedIndexChanged += new System.EventHandler(this.cbStables_SelectedIndexChanged);
			// 
			// tbOutput
			// 
			this.tbOutput.Font = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.tbOutput.Location = new System.Drawing.Point(12, 39);
			this.tbOutput.Multiline = true;
			this.tbOutput.Name = "tbOutput";
			this.tbOutput.ReadOnly = true;
			this.tbOutput.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			this.tbOutput.Size = new System.Drawing.Size(560, 390);
			this.tbOutput.TabIndex = 1;
			// 
			// ChampionshipDefs_Early
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(584, 441);
			this.Controls.Add(this.tbOutput);
			this.Controls.Add(this.cbStables);
			this.KeyPreview = true;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "ChampionshipDefs_Early";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "Championships (Early)";
			this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.ChampionshipDefs_Early_KeyDown);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.ComboBox cbStables;
		private System.Windows.Forms.TextBox tbOutput;
	}
}