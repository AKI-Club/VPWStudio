using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Drawing;
using System.Text;
using System.Threading.Tasks;
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

			MemoryStream romStream = new MemoryStream(Program.CurrentInputROM.Data);
			BinaryReader romReader = new BinaryReader(romStream);

			MenuBG = Program.CurrentProject.ProjectFileTable.ExtractMenuBackground(romReader, FileID);
			romReader.Close();
			pbMenuBG.Image = MenuBG.ToBitmap();
		}

		private void exportPNGToolStripMenuItem_Click(object sender, EventArgs e)
		{
			SaveFileDialog sfd = new SaveFileDialog();
			sfd.Title = "Export PNG";
			sfd.Filter = "PNG Files (*.png)|*.png|All Files (*.*)|*.*";
			if (sfd.ShowDialog() == DialogResult.OK)
			{
				pbMenuBG.Image.Save(sfd.FileName);
			}
		}
	}
}
