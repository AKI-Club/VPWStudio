
namespace VPWStudio
{
	partial class ClientTest
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
			this.menuStrip1 = new System.Windows.Forms.MenuStrip();
			this.connectionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.connectToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.portNumberToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.editToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.clearOutputToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.whatToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.statusStrip1 = new System.Windows.Forms.StatusStrip();
			this.tsslblConStatus = new System.Windows.Forms.ToolStripStatusLabel();
			this.tbOutput = new System.Windows.Forms.TextBox();
			this.gbOutput = new System.Windows.Forms.GroupBox();
			this.btnSendCommand = new System.Windows.Forms.Button();
			this.lblCommand = new System.Windows.Forms.Label();
			this.tbCommand = new System.Windows.Forms.TextBox();
			this.menuStrip1.SuspendLayout();
			this.statusStrip1.SuspendLayout();
			this.gbOutput.SuspendLayout();
			this.SuspendLayout();
			// 
			// menuStrip1
			// 
			this.menuStrip1.AllowMerge = false;
			this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.connectionToolStripMenuItem,
            this.editToolStripMenuItem,
            this.whatToolStripMenuItem});
			this.menuStrip1.Location = new System.Drawing.Point(0, 0);
			this.menuStrip1.Name = "menuStrip1";
			this.menuStrip1.Size = new System.Drawing.Size(496, 24);
			this.menuStrip1.TabIndex = 0;
			this.menuStrip1.Text = "menuStrip1";
			// 
			// connectionToolStripMenuItem
			// 
			this.connectionToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.connectToolStripMenuItem,
            this.portNumberToolStripMenuItem});
			this.connectionToolStripMenuItem.Name = "connectionToolStripMenuItem";
			this.connectionToolStripMenuItem.Size = new System.Drawing.Size(81, 20);
			this.connectionToolStripMenuItem.Text = "&Connection";
			// 
			// connectToolStripMenuItem
			// 
			this.connectToolStripMenuItem.Name = "connectToolStripMenuItem";
			this.connectToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
			this.connectToolStripMenuItem.Text = "&Connect";
			this.connectToolStripMenuItem.Click += new System.EventHandler(this.connectToolStripMenuItem_Click);
			// 
			// portNumberToolStripMenuItem
			// 
			this.portNumberToolStripMenuItem.Name = "portNumberToolStripMenuItem";
			this.portNumberToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
			this.portNumberToolStripMenuItem.Text = "&Port Number...";
			this.portNumberToolStripMenuItem.Click += new System.EventHandler(this.portNumberToolStripMenuItem_Click);
			// 
			// editToolStripMenuItem
			// 
			this.editToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.clearOutputToolStripMenuItem});
			this.editToolStripMenuItem.Name = "editToolStripMenuItem";
			this.editToolStripMenuItem.Size = new System.Drawing.Size(39, 20);
			this.editToolStripMenuItem.Text = "&Edit";
			// 
			// clearOutputToolStripMenuItem
			// 
			this.clearOutputToolStripMenuItem.Name = "clearOutputToolStripMenuItem";
			this.clearOutputToolStripMenuItem.Size = new System.Drawing.Size(142, 22);
			this.clearOutputToolStripMenuItem.Text = "&Clear Output";
			this.clearOutputToolStripMenuItem.Click += new System.EventHandler(this.clearOutputToolStripMenuItem_Click);
			// 
			// whatToolStripMenuItem
			// 
			this.whatToolStripMenuItem.Name = "whatToolStripMenuItem";
			this.whatToolStripMenuItem.Size = new System.Drawing.Size(52, 20);
			this.whatToolStripMenuItem.Text = "&What?";
			this.whatToolStripMenuItem.Click += new System.EventHandler(this.whatToolStripMenuItem_Click);
			// 
			// statusStrip1
			// 
			this.statusStrip1.GripMargin = new System.Windows.Forms.Padding(0);
			this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsslblConStatus});
			this.statusStrip1.Location = new System.Drawing.Point(0, 419);
			this.statusStrip1.Name = "statusStrip1";
			this.statusStrip1.Size = new System.Drawing.Size(496, 22);
			this.statusStrip1.SizingGrip = false;
			this.statusStrip1.TabIndex = 1;
			// 
			// tsslblConStatus
			// 
			this.tsslblConStatus.Name = "tsslblConStatus";
			this.tsslblConStatus.Size = new System.Drawing.Size(86, 17);
			this.tsslblConStatus.Text = "Not connected";
			// 
			// tbOutput
			// 
			this.tbOutput.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tbOutput.Font = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.tbOutput.Location = new System.Drawing.Point(3, 16);
			this.tbOutput.Multiline = true;
			this.tbOutput.Name = "tbOutput";
			this.tbOutput.ReadOnly = true;
			this.tbOutput.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			this.tbOutput.Size = new System.Drawing.Size(466, 297);
			this.tbOutput.TabIndex = 4;
			// 
			// gbOutput
			// 
			this.gbOutput.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.gbOutput.Controls.Add(this.tbOutput);
			this.gbOutput.Location = new System.Drawing.Point(12, 100);
			this.gbOutput.Name = "gbOutput";
			this.gbOutput.Size = new System.Drawing.Size(472, 316);
			this.gbOutput.TabIndex = 3;
			this.gbOutput.TabStop = false;
			this.gbOutput.Text = "&Output";
			// 
			// btnSendCommand
			// 
			this.btnSendCommand.Location = new System.Drawing.Point(12, 71);
			this.btnSendCommand.Name = "btnSendCommand";
			this.btnSendCommand.Size = new System.Drawing.Size(472, 23);
			this.btnSendCommand.TabIndex = 2;
			this.btnSendCommand.Text = "&Send Command";
			this.btnSendCommand.UseVisualStyleBackColor = true;
			this.btnSendCommand.Click += new System.EventHandler(this.btnSendCommand_Click);
			// 
			// lblCommand
			// 
			this.lblCommand.AutoSize = true;
			this.lblCommand.Location = new System.Drawing.Point(12, 30);
			this.lblCommand.Name = "lblCommand";
			this.lblCommand.Size = new System.Drawing.Size(141, 26);
			this.lblCommand.TabIndex = 0;
			this.lblCommand.Text = "Co&mmand\r\n(hex values only, no spaces)";
			// 
			// tbCommand
			// 
			this.tbCommand.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
			this.tbCommand.Font = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.tbCommand.Location = new System.Drawing.Point(168, 36);
			this.tbCommand.Name = "tbCommand";
			this.tbCommand.Size = new System.Drawing.Size(316, 23);
			this.tbCommand.TabIndex = 1;
			// 
			// ClientTest
			// 
			this.AcceptButton = this.btnSendCommand;
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(496, 441);
			this.Controls.Add(this.tbCommand);
			this.Controls.Add(this.lblCommand);
			this.Controls.Add(this.btnSendCommand);
			this.Controls.Add(this.gbOutput);
			this.Controls.Add(this.statusStrip1);
			this.Controls.Add(this.menuStrip1);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.KeyPreview = true;
			this.MainMenuStrip = this.menuStrip1;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "ClientTest";
			this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "Client Test";
			this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ClientTest_FormClosing);
			this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.ClientTest_KeyDown);
			this.menuStrip1.ResumeLayout(false);
			this.menuStrip1.PerformLayout();
			this.statusStrip1.ResumeLayout(false);
			this.statusStrip1.PerformLayout();
			this.gbOutput.ResumeLayout(false);
			this.gbOutput.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.MenuStrip menuStrip1;
		private System.Windows.Forms.ToolStripMenuItem connectionToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem connectToolStripMenuItem;
		private System.Windows.Forms.StatusStrip statusStrip1;
		private System.Windows.Forms.ToolStripStatusLabel tsslblConStatus;
		private System.Windows.Forms.TextBox tbOutput;
		private System.Windows.Forms.GroupBox gbOutput;
		private System.Windows.Forms.ToolStripMenuItem editToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem clearOutputToolStripMenuItem;
		private System.Windows.Forms.Button btnSendCommand;
		private System.Windows.Forms.Label lblCommand;
		private System.Windows.Forms.TextBox tbCommand;
		private System.Windows.Forms.ToolStripMenuItem whatToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem portNumberToolStripMenuItem;
	}
}