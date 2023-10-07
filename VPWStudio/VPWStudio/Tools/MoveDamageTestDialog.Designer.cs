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
			this.tlpSelection = new System.Windows.Forms.TableLayoutPanel();
			this.cbWrestler = new System.Windows.Forms.ComboBox();
			this.lblWrestler = new System.Windows.Forms.Label();
			this.lblMove = new System.Windows.Forms.Label();
			this.tlpSelection.SuspendLayout();
			this.SuspendLayout();
			// 
			// cbMoveDamageEntries
			// 
			this.cbMoveDamageEntries.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
			this.cbMoveDamageEntries.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cbMoveDamageEntries.FormattingEnabled = true;
			this.cbMoveDamageEntries.Location = new System.Drawing.Point(121, 36);
			this.cbMoveDamageEntries.Name = "cbMoveDamageEntries";
			this.cbMoveDamageEntries.Size = new System.Drawing.Size(348, 21);
			this.cbMoveDamageEntries.TabIndex = 3;
			this.cbMoveDamageEntries.SelectedIndexChanged += new System.EventHandler(this.cbMoveDamageEntries_SelectedIndexChanged);
			// 
			// tbOutput
			// 
			this.tbOutput.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.tbOutput.Font = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.tbOutput.Location = new System.Drawing.Point(12, 81);
			this.tbOutput.Multiline = true;
			this.tbOutput.Name = "tbOutput";
			this.tbOutput.ReadOnly = true;
			this.tbOutput.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			this.tbOutput.Size = new System.Drawing.Size(472, 217);
			this.tbOutput.TabIndex = 2;
			// 
			// tlpSelection
			// 
			this.tlpSelection.ColumnCount = 2;
			this.tlpSelection.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
			this.tlpSelection.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 75F));
			this.tlpSelection.Controls.Add(this.cbMoveDamageEntries, 1, 1);
			this.tlpSelection.Controls.Add(this.cbWrestler, 1, 0);
			this.tlpSelection.Controls.Add(this.lblWrestler, 0, 0);
			this.tlpSelection.Controls.Add(this.lblMove, 0, 1);
			this.tlpSelection.Location = new System.Drawing.Point(12, 12);
			this.tlpSelection.Name = "tlpSelection";
			this.tlpSelection.RowCount = 2;
			this.tlpSelection.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
			this.tlpSelection.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
			this.tlpSelection.Size = new System.Drawing.Size(472, 63);
			this.tlpSelection.TabIndex = 4;
			// 
			// cbWrestler
			// 
			this.cbWrestler.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
			this.cbWrestler.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cbWrestler.Font = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.cbWrestler.FormattingEnabled = true;
			this.cbWrestler.Location = new System.Drawing.Point(121, 4);
			this.cbWrestler.Name = "cbWrestler";
			this.cbWrestler.Size = new System.Drawing.Size(348, 23);
			this.cbWrestler.TabIndex = 4;
			this.cbWrestler.SelectedIndexChanged += new System.EventHandler(this.cbWrestler_SelectedIndexChanged);
			// 
			// lblWrestler
			// 
			this.lblWrestler.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
			this.lblWrestler.AutoSize = true;
			this.lblWrestler.Location = new System.Drawing.Point(3, 9);
			this.lblWrestler.Name = "lblWrestler";
			this.lblWrestler.Size = new System.Drawing.Size(112, 13);
			this.lblWrestler.TabIndex = 5;
			this.lblWrestler.Text = "&Wrestler";
			// 
			// lblMove
			// 
			this.lblMove.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
			this.lblMove.AutoSize = true;
			this.lblMove.Location = new System.Drawing.Point(3, 40);
			this.lblMove.Name = "lblMove";
			this.lblMove.Size = new System.Drawing.Size(112, 13);
			this.lblMove.TabIndex = 6;
			this.lblMove.Text = "&Move";
			// 
			// MoveDamageTestDialog
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(496, 311);
			this.Controls.Add(this.tlpSelection);
			this.Controls.Add(this.tbOutput);
			this.KeyPreview = true;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.MinimumSize = new System.Drawing.Size(512, 350);
			this.Name = "MoveDamageTestDialog";
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "Move Damage Test";
			this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.MoveDamageTestDialog_KeyDown);
			this.tlpSelection.ResumeLayout(false);
			this.tlpSelection.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.ComboBox cbMoveDamageEntries;
		private System.Windows.Forms.TextBox tbOutput;
		private System.Windows.Forms.TableLayoutPanel tlpSelection;
		private System.Windows.Forms.ComboBox cbWrestler;
		private System.Windows.Forms.Label lblWrestler;
		private System.Windows.Forms.Label lblMove;
	}
}