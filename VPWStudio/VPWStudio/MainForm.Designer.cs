namespace VPWStudio
{
	partial class MainForm
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
			this.menuStrip1 = new System.Windows.Forms.MenuStrip();
			this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.newProjectToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.openProjectToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
			this.saveProjectToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.saveProjectAsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
			this.closeProjectToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
			this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.projectToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.projectPropertiesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
			this.arenasToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.championshipsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.costumesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.fileTableToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.movesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.stablesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.wrestlersToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
			this.buildROMToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.playROMToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.toolsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.modelDataToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.packedFileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripSeparator7 = new System.Windows.Forms.ToolStripSeparator();
			this.sharkTestToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripSeparator6 = new System.Windows.Forms.ToolStripSeparator();
			this.programOptionsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.windowToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.nothingToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.aboutVPWStudioToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.dangerZoneToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.asmikLzssTestToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.lzssDecompressTestToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.akiTextToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.statusStrip1 = new System.Windows.Forms.StatusStrip();
			this.tssLabelCurFile = new System.Windows.Forms.ToolStripStatusLabel();
			this.tssLabelGameType = new System.Windows.Forms.ToolStripStatusLabel();
			this.menuStrip1.SuspendLayout();
			this.statusStrip1.SuspendLayout();
			this.SuspendLayout();
			// 
			// menuStrip1
			// 
			this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.projectToolStripMenuItem,
            this.toolsToolStripMenuItem,
            this.windowToolStripMenuItem,
            this.helpToolStripMenuItem,
            this.dangerZoneToolStripMenuItem});
			resources.ApplyResources(this.menuStrip1, "menuStrip1");
			this.menuStrip1.Name = "menuStrip1";
			// 
			// fileToolStripMenuItem
			// 
			this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newProjectToolStripMenuItem,
            this.openProjectToolStripMenuItem,
            this.toolStripSeparator5,
            this.saveProjectToolStripMenuItem,
            this.saveProjectAsToolStripMenuItem,
            this.toolStripSeparator4,
            this.closeProjectToolStripMenuItem,
            this.toolStripSeparator1,
            this.exitToolStripMenuItem});
			this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
			resources.ApplyResources(this.fileToolStripMenuItem, "fileToolStripMenuItem");
			// 
			// newProjectToolStripMenuItem
			// 
			this.newProjectToolStripMenuItem.Image = global::VPWStudio.Properties.Resources.MenuIcon16_New;
			this.newProjectToolStripMenuItem.Name = "newProjectToolStripMenuItem";
			resources.ApplyResources(this.newProjectToolStripMenuItem, "newProjectToolStripMenuItem");
			this.newProjectToolStripMenuItem.Click += new System.EventHandler(this.newProjectToolStripMenuItem_Click);
			// 
			// openProjectToolStripMenuItem
			// 
			this.openProjectToolStripMenuItem.Image = global::VPWStudio.Properties.Resources.MenuIcon16_Open;
			this.openProjectToolStripMenuItem.Name = "openProjectToolStripMenuItem";
			resources.ApplyResources(this.openProjectToolStripMenuItem, "openProjectToolStripMenuItem");
			this.openProjectToolStripMenuItem.Click += new System.EventHandler(this.openProjectToolStripMenuItem_Click);
			// 
			// toolStripSeparator5
			// 
			this.toolStripSeparator5.Name = "toolStripSeparator5";
			resources.ApplyResources(this.toolStripSeparator5, "toolStripSeparator5");
			// 
			// saveProjectToolStripMenuItem
			// 
			this.saveProjectToolStripMenuItem.Image = global::VPWStudio.Properties.Resources.MenuIcon16_Save;
			this.saveProjectToolStripMenuItem.Name = "saveProjectToolStripMenuItem";
			resources.ApplyResources(this.saveProjectToolStripMenuItem, "saveProjectToolStripMenuItem");
			this.saveProjectToolStripMenuItem.Click += new System.EventHandler(this.saveProjectToolStripMenuItem_Click);
			// 
			// saveProjectAsToolStripMenuItem
			// 
			this.saveProjectAsToolStripMenuItem.Image = global::VPWStudio.Properties.Resources.MenuIcon16_SaveAs;
			this.saveProjectAsToolStripMenuItem.Name = "saveProjectAsToolStripMenuItem";
			resources.ApplyResources(this.saveProjectAsToolStripMenuItem, "saveProjectAsToolStripMenuItem");
			this.saveProjectAsToolStripMenuItem.Click += new System.EventHandler(this.saveProjectAsToolStripMenuItem_Click);
			// 
			// toolStripSeparator4
			// 
			this.toolStripSeparator4.Name = "toolStripSeparator4";
			resources.ApplyResources(this.toolStripSeparator4, "toolStripSeparator4");
			// 
			// closeProjectToolStripMenuItem
			// 
			this.closeProjectToolStripMenuItem.Name = "closeProjectToolStripMenuItem";
			resources.ApplyResources(this.closeProjectToolStripMenuItem, "closeProjectToolStripMenuItem");
			this.closeProjectToolStripMenuItem.Click += new System.EventHandler(this.closeProjectToolStripMenuItem_Click);
			// 
			// toolStripSeparator1
			// 
			this.toolStripSeparator1.Name = "toolStripSeparator1";
			resources.ApplyResources(this.toolStripSeparator1, "toolStripSeparator1");
			// 
			// exitToolStripMenuItem
			// 
			this.exitToolStripMenuItem.Image = global::VPWStudio.Properties.Resources.MenuIcon16_Exit;
			this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
			resources.ApplyResources(this.exitToolStripMenuItem, "exitToolStripMenuItem");
			this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
			// 
			// projectToolStripMenuItem
			// 
			this.projectToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.projectPropertiesToolStripMenuItem,
            this.toolStripSeparator2,
            this.arenasToolStripMenuItem,
            this.championshipsToolStripMenuItem,
            this.costumesToolStripMenuItem,
            this.fileTableToolStripMenuItem,
            this.movesToolStripMenuItem,
            this.stablesToolStripMenuItem,
            this.wrestlersToolStripMenuItem,
            this.toolStripSeparator3,
            this.buildROMToolStripMenuItem,
            this.playROMToolStripMenuItem});
			this.projectToolStripMenuItem.Name = "projectToolStripMenuItem";
			resources.ApplyResources(this.projectToolStripMenuItem, "projectToolStripMenuItem");
			// 
			// projectPropertiesToolStripMenuItem
			// 
			this.projectPropertiesToolStripMenuItem.Image = global::VPWStudio.Properties.Resources.MenuIcon16_ProjectProperties;
			this.projectPropertiesToolStripMenuItem.Name = "projectPropertiesToolStripMenuItem";
			resources.ApplyResources(this.projectPropertiesToolStripMenuItem, "projectPropertiesToolStripMenuItem");
			this.projectPropertiesToolStripMenuItem.Click += new System.EventHandler(this.projectPropertiesToolStripMenuItem_Click);
			// 
			// toolStripSeparator2
			// 
			this.toolStripSeparator2.Name = "toolStripSeparator2";
			resources.ApplyResources(this.toolStripSeparator2, "toolStripSeparator2");
			// 
			// arenasToolStripMenuItem
			// 
			this.arenasToolStripMenuItem.Name = "arenasToolStripMenuItem";
			resources.ApplyResources(this.arenasToolStripMenuItem, "arenasToolStripMenuItem");
			this.arenasToolStripMenuItem.Click += new System.EventHandler(this.arenasToolStripMenuItem_Click);
			// 
			// championshipsToolStripMenuItem
			// 
			this.championshipsToolStripMenuItem.Image = global::VPWStudio.Properties.Resources.MenuIcon16_Championship;
			this.championshipsToolStripMenuItem.Name = "championshipsToolStripMenuItem";
			resources.ApplyResources(this.championshipsToolStripMenuItem, "championshipsToolStripMenuItem");
			this.championshipsToolStripMenuItem.Click += new System.EventHandler(this.championshipsToolStripMenuItem_Click);
			// 
			// costumesToolStripMenuItem
			// 
			this.costumesToolStripMenuItem.Image = global::VPWStudio.Properties.Resources.MenuIcon16_Costumes;
			this.costumesToolStripMenuItem.Name = "costumesToolStripMenuItem";
			resources.ApplyResources(this.costumesToolStripMenuItem, "costumesToolStripMenuItem");
			this.costumesToolStripMenuItem.Click += new System.EventHandler(this.costumesToolStripMenuItem_Click);
			// 
			// fileTableToolStripMenuItem
			// 
			this.fileTableToolStripMenuItem.Image = global::VPWStudio.Properties.Resources.MenuIcon16_FileTable;
			this.fileTableToolStripMenuItem.Name = "fileTableToolStripMenuItem";
			resources.ApplyResources(this.fileTableToolStripMenuItem, "fileTableToolStripMenuItem");
			this.fileTableToolStripMenuItem.Click += new System.EventHandler(this.fileTableToolStripMenuItem_Click);
			// 
			// movesToolStripMenuItem
			// 
			this.movesToolStripMenuItem.Name = "movesToolStripMenuItem";
			resources.ApplyResources(this.movesToolStripMenuItem, "movesToolStripMenuItem");
			this.movesToolStripMenuItem.Click += new System.EventHandler(this.movesToolStripMenuItem_Click);
			// 
			// stablesToolStripMenuItem
			// 
			this.stablesToolStripMenuItem.Image = global::VPWStudio.Properties.Resources.MenuIcon16_Stables;
			this.stablesToolStripMenuItem.Name = "stablesToolStripMenuItem";
			resources.ApplyResources(this.stablesToolStripMenuItem, "stablesToolStripMenuItem");
			this.stablesToolStripMenuItem.Click += new System.EventHandler(this.stablesToolStripMenuItem_Click);
			// 
			// wrestlersToolStripMenuItem
			// 
			this.wrestlersToolStripMenuItem.Image = global::VPWStudio.Properties.Resources.MenuIcon16_Wrestlers;
			this.wrestlersToolStripMenuItem.Name = "wrestlersToolStripMenuItem";
			resources.ApplyResources(this.wrestlersToolStripMenuItem, "wrestlersToolStripMenuItem");
			this.wrestlersToolStripMenuItem.Click += new System.EventHandler(this.wrestlersToolStripMenuItem_Click);
			// 
			// toolStripSeparator3
			// 
			this.toolStripSeparator3.Name = "toolStripSeparator3";
			resources.ApplyResources(this.toolStripSeparator3, "toolStripSeparator3");
			// 
			// buildROMToolStripMenuItem
			// 
			this.buildROMToolStripMenuItem.Image = global::VPWStudio.Properties.Resources.MenuIcon16_BuildROM;
			this.buildROMToolStripMenuItem.Name = "buildROMToolStripMenuItem";
			resources.ApplyResources(this.buildROMToolStripMenuItem, "buildROMToolStripMenuItem");
			this.buildROMToolStripMenuItem.Click += new System.EventHandler(this.buildROMToolStripMenuItem_Click);
			// 
			// playROMToolStripMenuItem
			// 
			this.playROMToolStripMenuItem.Image = global::VPWStudio.Properties.Resources.MenuIcon16_PlayROM;
			this.playROMToolStripMenuItem.Name = "playROMToolStripMenuItem";
			resources.ApplyResources(this.playROMToolStripMenuItem, "playROMToolStripMenuItem");
			this.playROMToolStripMenuItem.Click += new System.EventHandler(this.playROMToolStripMenuItem_Click);
			// 
			// toolsToolStripMenuItem
			// 
			this.toolsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.modelDataToolStripMenuItem,
            this.packedFileToolStripMenuItem,
            this.toolStripSeparator7,
            this.sharkTestToolStripMenuItem,
            this.toolStripSeparator6,
            this.programOptionsToolStripMenuItem});
			this.toolsToolStripMenuItem.Name = "toolsToolStripMenuItem";
			resources.ApplyResources(this.toolsToolStripMenuItem, "toolsToolStripMenuItem");
			// 
			// modelDataToolStripMenuItem
			// 
			this.modelDataToolStripMenuItem.Image = global::VPWStudio.Properties.Resources.MenuIcon16_ModelTool;
			this.modelDataToolStripMenuItem.Name = "modelDataToolStripMenuItem";
			resources.ApplyResources(this.modelDataToolStripMenuItem, "modelDataToolStripMenuItem");
			this.modelDataToolStripMenuItem.Click += new System.EventHandler(this.modelDataToolStripMenuItem_Click);
			// 
			// packedFileToolStripMenuItem
			// 
			this.packedFileToolStripMenuItem.Name = "packedFileToolStripMenuItem";
			resources.ApplyResources(this.packedFileToolStripMenuItem, "packedFileToolStripMenuItem");
			this.packedFileToolStripMenuItem.Click += new System.EventHandler(this.packedFileToolStripMenuItem_Click);
			// 
			// toolStripSeparator7
			// 
			this.toolStripSeparator7.Name = "toolStripSeparator7";
			resources.ApplyResources(this.toolStripSeparator7, "toolStripSeparator7");
			// 
			// sharkTestToolStripMenuItem
			// 
			this.sharkTestToolStripMenuItem.Image = global::VPWStudio.Properties.Resources.MenuIcon16_GameShark;
			this.sharkTestToolStripMenuItem.Name = "sharkTestToolStripMenuItem";
			resources.ApplyResources(this.sharkTestToolStripMenuItem, "sharkTestToolStripMenuItem");
			this.sharkTestToolStripMenuItem.Click += new System.EventHandler(this.sharkTestToolStripMenuItem_Click);
			// 
			// toolStripSeparator6
			// 
			this.toolStripSeparator6.Name = "toolStripSeparator6";
			resources.ApplyResources(this.toolStripSeparator6, "toolStripSeparator6");
			// 
			// programOptionsToolStripMenuItem
			// 
			this.programOptionsToolStripMenuItem.Image = global::VPWStudio.Properties.Resources.MenuIcon16_ProgramOptions;
			this.programOptionsToolStripMenuItem.Name = "programOptionsToolStripMenuItem";
			resources.ApplyResources(this.programOptionsToolStripMenuItem, "programOptionsToolStripMenuItem");
			this.programOptionsToolStripMenuItem.Click += new System.EventHandler(this.programOptionsToolStripMenuItem_Click);
			// 
			// windowToolStripMenuItem
			// 
			this.windowToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.nothingToolStripMenuItem});
			this.windowToolStripMenuItem.Name = "windowToolStripMenuItem";
			resources.ApplyResources(this.windowToolStripMenuItem, "windowToolStripMenuItem");
			// 
			// nothingToolStripMenuItem
			// 
			this.nothingToolStripMenuItem.Name = "nothingToolStripMenuItem";
			resources.ApplyResources(this.nothingToolStripMenuItem, "nothingToolStripMenuItem");
			// 
			// helpToolStripMenuItem
			// 
			this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.aboutVPWStudioToolStripMenuItem});
			this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
			resources.ApplyResources(this.helpToolStripMenuItem, "helpToolStripMenuItem");
			// 
			// aboutVPWStudioToolStripMenuItem
			// 
			this.aboutVPWStudioToolStripMenuItem.Image = global::VPWStudio.Properties.Resources.MenuIcon16_VPWStudio;
			this.aboutVPWStudioToolStripMenuItem.Name = "aboutVPWStudioToolStripMenuItem";
			resources.ApplyResources(this.aboutVPWStudioToolStripMenuItem, "aboutVPWStudioToolStripMenuItem");
			this.aboutVPWStudioToolStripMenuItem.Click += new System.EventHandler(this.aboutVPWStudioToolStripMenuItem_Click);
			// 
			// dangerZoneToolStripMenuItem
			// 
			this.dangerZoneToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.asmikLzssTestToolStripMenuItem,
            this.lzssDecompressTestToolStripMenuItem,
            this.akiTextToolStripMenuItem});
			this.dangerZoneToolStripMenuItem.Name = "dangerZoneToolStripMenuItem";
			resources.ApplyResources(this.dangerZoneToolStripMenuItem, "dangerZoneToolStripMenuItem");
			// 
			// asmikLzssTestToolStripMenuItem
			// 
			this.asmikLzssTestToolStripMenuItem.Name = "asmikLzssTestToolStripMenuItem";
			resources.ApplyResources(this.asmikLzssTestToolStripMenuItem, "asmikLzssTestToolStripMenuItem");
			this.asmikLzssTestToolStripMenuItem.Click += new System.EventHandler(this.asmikLzssTestToolStripMenuItem_Click);
			// 
			// lzssDecompressTestToolStripMenuItem
			// 
			this.lzssDecompressTestToolStripMenuItem.Name = "lzssDecompressTestToolStripMenuItem";
			resources.ApplyResources(this.lzssDecompressTestToolStripMenuItem, "lzssDecompressTestToolStripMenuItem");
			this.lzssDecompressTestToolStripMenuItem.Click += new System.EventHandler(this.lzssDecompressTestToolStripMenuItem_Click);
			// 
			// akiTextToolStripMenuItem
			// 
			this.akiTextToolStripMenuItem.Name = "akiTextToolStripMenuItem";
			resources.ApplyResources(this.akiTextToolStripMenuItem, "akiTextToolStripMenuItem");
			this.akiTextToolStripMenuItem.Click += new System.EventHandler(this.akiTextToolStripMenuItem_Click);
			// 
			// statusStrip1
			// 
			this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tssLabelCurFile,
            this.tssLabelGameType});
			resources.ApplyResources(this.statusStrip1, "statusStrip1");
			this.statusStrip1.Name = "statusStrip1";
			// 
			// tssLabelCurFile
			// 
			this.tssLabelCurFile.BorderStyle = System.Windows.Forms.Border3DStyle.Etched;
			this.tssLabelCurFile.Margin = new System.Windows.Forms.Padding(0, 2, 0, 2);
			this.tssLabelCurFile.Name = "tssLabelCurFile";
			this.tssLabelCurFile.Padding = new System.Windows.Forms.Padding(0, 2, 0, 3);
			resources.ApplyResources(this.tssLabelCurFile, "tssLabelCurFile");
			this.tssLabelCurFile.Spring = true;
			// 
			// tssLabelGameType
			// 
			this.tssLabelGameType.BorderSides = ((System.Windows.Forms.ToolStripStatusLabelBorderSides)((((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left | System.Windows.Forms.ToolStripStatusLabelBorderSides.Top) 
            | System.Windows.Forms.ToolStripStatusLabelBorderSides.Right) 
            | System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom)));
			this.tssLabelGameType.BorderStyle = System.Windows.Forms.Border3DStyle.Etched;
			resources.ApplyResources(this.tssLabelGameType, "tssLabelGameType");
			this.tssLabelGameType.Name = "tssLabelGameType";
			this.tssLabelGameType.Padding = new System.Windows.Forms.Padding(4, 2, 2, 3);
			// 
			// MainForm
			// 
			resources.ApplyResources(this, "$this");
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add(this.statusStrip1);
			this.Controls.Add(this.menuStrip1);
			this.IsMdiContainer = true;
			this.MainMenuStrip = this.menuStrip1;
			this.Name = "MainForm";
			this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
			this.menuStrip1.ResumeLayout(false);
			this.menuStrip1.PerformLayout();
			this.statusStrip1.ResumeLayout(false);
			this.statusStrip1.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.MenuStrip menuStrip1;
		private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem newProjectToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem openProjectToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem saveProjectToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem saveProjectAsToolStripMenuItem;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
		private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem aboutVPWStudioToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem projectToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem toolsToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem modelDataToolStripMenuItem;
		private System.Windows.Forms.StatusStrip statusStrip1;
		private System.Windows.Forms.ToolStripStatusLabel tssLabelCurFile;
		private System.Windows.Forms.ToolStripMenuItem projectPropertiesToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem closeProjectToolStripMenuItem;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
		private System.Windows.Forms.ToolStripMenuItem windowToolStripMenuItem;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator5;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
		private System.Windows.Forms.ToolStripMenuItem arenasToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem movesToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem wrestlersToolStripMenuItem;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
		private System.Windows.Forms.ToolStripMenuItem buildROMToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem fileTableToolStripMenuItem;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator6;
		private System.Windows.Forms.ToolStripMenuItem programOptionsToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem costumesToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem packedFileToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem sharkTestToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem nothingToolStripMenuItem;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator7;
		private System.Windows.Forms.ToolStripStatusLabel tssLabelGameType;
		private System.Windows.Forms.ToolStripMenuItem playROMToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem asmikLzssTestToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem lzssDecompressTestToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem stablesToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem dangerZoneToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem akiTextToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem championshipsToolStripMenuItem;
	}
}

