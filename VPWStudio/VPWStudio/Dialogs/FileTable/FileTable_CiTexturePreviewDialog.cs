using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VPWStudio
{
	public partial class FileTable_CiTexturePreviewDialog : Form
	{
		private Ci4Palette CurCI4Palette;
		private Ci4Texture CurCI4Texture;

		private Ci8Palette CurCI8Palette;
		private Ci8Texture CurCI8Texture;

		private Bitmap CurBitmap;

		private List<int> paletteIDs;

		private enum CiViewerModes
		{
			Ci4,
			Ci8
		}
		private CiViewerModes CurViewMode;

		public FileTable_CiTexturePreviewDialog(int fileID)
		{
			InitializeComponent();
			this.Text = String.Format("Preview [0x{0:X4}]", fileID);

			MemoryStream romStream = new MemoryStream(Program.CurrentInputROM.Data);
			BinaryReader romReader = new BinaryReader(romStream);

			MemoryStream imgStream = new MemoryStream();
			BinaryWriter imgWriter = new BinaryWriter(imgStream);

			// CurViewMode depends on item type.
			if (Program.CurrentProject.ProjectFileTable.Entries[fileID].FileType == FileTypes.Ci4Texture)
			{
				CurViewMode = CiViewerModes.Ci4;
				CurCI8Palette = null;
				CurCI8Texture = null;

				paletteIDs = Program.CurrentProject.ProjectFileTable.GetFilesOfType(FileTypes.Ci4Palette);
				CurCI4Palette = new Ci4Palette();
				CurCI4Texture = new Ci4Texture();

				Program.CurrentProject.ProjectFileTable.ExtractFile(romReader, imgWriter, fileID);
				imgStream.Seek(0, SeekOrigin.Begin);
				BinaryReader fr = new BinaryReader(imgStream);
				CurCI4Texture.ReadData(fr);
				fr.Close();

				CurBitmap = new Bitmap(CurCI4Texture.Width, CurCI4Texture.Height);
			}
			else if(Program.CurrentProject.ProjectFileTable.Entries[fileID].FileType == FileTypes.Ci8Texture)
			{
				CurViewMode = CiViewerModes.Ci8;
				CurCI4Palette = null;
				CurCI4Texture = null;

				paletteIDs = Program.CurrentProject.ProjectFileTable.GetFilesOfType(FileTypes.Ci8Palette);
				CurCI8Palette = new Ci8Palette();
				CurCI8Texture = new Ci8Texture();

				Program.CurrentProject.ProjectFileTable.ExtractFile(romReader, imgWriter, fileID);
				imgStream.Seek(0, SeekOrigin.Begin);
				BinaryReader fr = new BinaryReader(imgStream);
				CurCI8Texture.ReadData(fr);
				fr.Close();

				CurBitmap = new Bitmap(CurCI8Texture.Width, CurCI8Texture.Height);
			}

			imgWriter.Close();
			romReader.Close();

			// load palettes
			cbPalettes.Items.Clear();
			cbPalettes.BeginUpdate();
			foreach (int i in paletteIDs)
			{
				cbPalettes.Items.Add(String.Format("{0:X4}",i));
			}
			cbPalettes.EndUpdate();
		}

		private void cbPalettes_SelectedValueChanged(object sender, EventArgs e)
		{
			int curID = paletteIDs[cbPalettes.SelectedIndex];

			MemoryStream romStream = new MemoryStream(Program.CurrentInputROM.Data);
			BinaryReader romReader = new BinaryReader(romStream);

			MemoryStream palStream = new MemoryStream();
			BinaryWriter palWriter = new BinaryWriter(palStream);

			Program.CurrentProject.ProjectFileTable.ExtractFile(romReader, palWriter, curID);
			palStream.Seek(0, SeekOrigin.Begin);
			BinaryReader fr = new BinaryReader(palStream);

			switch (CurViewMode)
			{
				case CiViewerModes.Ci4:
					{
						CurCI4Palette.ReadData(fr);
						CurBitmap = CurCI4Texture.GetBitmap(CurCI4Palette);
					}
					break;
				case CiViewerModes.Ci8:
					{
						CurCI8Palette.ReadData(fr);
						CurBitmap = CurCI8Texture.GetBitmap(CurCI8Palette);
					}
					break;
			}

			fr.Close();
			palWriter.Close();
			romReader.Close();

			pbPreview.Image = CurBitmap;
		}
	}
}
