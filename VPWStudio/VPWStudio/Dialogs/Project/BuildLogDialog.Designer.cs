namespace VPWStudio
{
	partial class BuildLogDialog
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
			this.tbLogOutput = new System.Windows.Forms.TextBox();
			this.SuspendLayout();
			// 
			// tbLogOutput
			// 
			this.tbLogOutput.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tbLogOutput.Font = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.tbLogOutput.Location = new System.Drawing.Point(0, 0);
			this.tbLogOutput.MaxLength = 65535;
			this.tbLogOutput.Multiline = true;
			this.tbLogOutput.Name = "tbLogOutput";
			this.tbLogOutput.ReadOnly = true;
			this.tbLogOutput.ScrollBars = System.Windows.Forms.ScrollBars.Both;
			this.tbLogOutput.Size = new System.Drawing.Size(506, 103);
			this.tbLogOutput.TabIndex = 0;
			this.tbLogOutput.KeyUp += new System.Windows.Forms.KeyEventHandler(this.tbLogOutput_KeyUp);
			// 
			// BuildLogDialog
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(506, 103);
			this.Controls.Add(this.tbLogOutput);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "BuildLogDialog";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "Build Log";
			this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.BuildLogDialog_KeyDown);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.TextBox tbLogOutput;
	}
}