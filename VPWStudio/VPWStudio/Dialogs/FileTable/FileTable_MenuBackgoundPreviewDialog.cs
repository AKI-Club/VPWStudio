using System;
using System.IO;
using System.Windows.Forms;

namespace VPWStudio
{
	public partial class FileTable_MenuBackgoundPreviewDialog : Form
	{
		public int FileID;
		public MenuBackground MenuBG;

		public FileTable_MenuBackgoundPreviewDialog(int _fileID)
		{
			InitializeComponent();
			FileID = _fileID;
			Text = String.Format("Background Preview - File {0:X4}", FileID);

			MemoryStream romStream = new MemoryStream(Program.CurrentInputROM.Data);
			BinaryReader romReader = new BinaryReader(romStream);

			MenuBG = Program.CurrentProject.ProjectFileTable.ExtractMenuBackground(romReader, FileID, Program.CurrentProject.Settings.BaseGame);
			romReader.Close();
			pbMenuBG.Image = MenuBG.ToBitmap();
		}

		private void exportPNGToolStripMenuItem_Click(object sender, EventArgs e)
		{
			SaveFileDialog sfd = new SaveFileDialog();
			sfd.Title = "Export PNG";
			sfd.Filter = "PNG Files (*.png)|*.png|All Files (*.*)|*.*";
			sfd.FileName = String.Format("{0:X4}.png", FileID);
			if (sfd.ShowDialog() == DialogResult.OK)
			{
				pbMenuBG.Image.Save(sfd.FileName);
			}
		}
	}
}
