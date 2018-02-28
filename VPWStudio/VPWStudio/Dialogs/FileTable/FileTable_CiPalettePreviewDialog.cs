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
	public partial class FileTable_CiPalettePreviewDialog : Form
	{
		private Ci4Palette CurCI4Palette;
		private Ci8Palette CurCI8Palette;

		private Bitmap PalPreviewBitmap;

		private enum CiViewerModes
		{
			Ci4,
			Ci8
		}
		private CiViewerModes CurViewMode;

		public FileTable_CiPalettePreviewDialog(int fileID)
		{
			InitializeComponent();
			this.Text = String.Format("Preview [0x{0:X4}]", fileID);

			MemoryStream romStream = new MemoryStream(Program.CurrentInputROM.Data);
			BinaryReader romReader = new BinaryReader(romStream);

			MemoryStream palStream = new MemoryStream();
			BinaryWriter palWriter = new BinaryWriter(palStream);

			if (Program.CurrentProject.ProjectFileTable.Entries[fileID].FileType == FileTypes.Ci4Palette)
			{
				CurViewMode = CiViewerModes.Ci4;
				CurCI8Palette = null;

				CurCI4Palette = new Ci4Palette();
				Program.CurrentProject.ProjectFileTable.ExtractFile(romReader, palWriter, fileID);
				palStream.Seek(0, SeekOrigin.Begin);
				BinaryReader fr = new BinaryReader(palStream);
				CurCI4Palette.ReadData(fr);
				fr.Close();
			}
			else if (Program.CurrentProject.ProjectFileTable.Entries[fileID].FileType == FileTypes.Ci8Palette)
			{
				CurViewMode = CiViewerModes.Ci8;
				CurCI4Palette = null;

				CurCI8Palette = new Ci8Palette();
				Program.CurrentProject.ProjectFileTable.ExtractFile(romReader, palWriter, fileID);
				palStream.Seek(0, SeekOrigin.Begin);
				BinaryReader fr = new BinaryReader(palStream);
				CurCI8Palette.ReadData(fr);
				fr.Close();
			}

			palWriter.Close();
			romReader.Close();

			// todo: the part where you draw the palette
			DrawPalettePreview();
		}

		/// <summary>
		/// 
		/// </summary>
		private void DrawPalettePreview()
		{
			// a lot of this depends on CurViewMode.

			PalPreviewBitmap = new Bitmap(256, 256);
			Graphics g = Graphics.FromImage(PalPreviewBitmap);

			int curRow = 0;
			int curCol = 0;
			Pen curPen;
			switch (CurViewMode)
			{
				case CiViewerModes.Ci4:
					{
						// display 4 colors per line, 64x64px blocks
						for (int i = 0; i < CurCI4Palette.Entries.Length; i++)
						{
							curPen = new Pen(N64Colors.Value5551ToColor(CurCI4Palette.Entries[i]));
							g.FillRectangle(curPen.Brush, new Rectangle(curCol*64, curRow*64, (curCol * 64) + 64, (curRow * 64)+ 64));

							curCol++;
							if (curCol >= 4)
							{
								curCol = 0;
								curRow++;
							}
						}
					}
					break;

				case CiViewerModes.Ci8:
					{
						// display 16 colors per line, 16x16px blocks
						for (int i = 0; i < CurCI8Palette.Entries.Length; i++)
						{
							curPen = new Pen(N64Colors.Value5551ToColor(CurCI8Palette.Entries[i]));
							g.FillRectangle(curPen.Brush, new Rectangle(curCol * 16, curRow * 16, (curCol * 16) + 16, (curRow * 16) + 16));

							curCol++;
							if (curCol >= 16)
							{
								curCol = 0;
								curRow++;
							}
						}
					}
					break;
			}
			g.Dispose();
			pbPalettePreview.Image = PalPreviewBitmap;
		}

		private void FileTable_CiPalettePreviewDialog_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Escape)
			{
				this.Close();
			}
		}

		private void exportJASCPaletteToolStripMenuItem_Click(object sender, EventArgs e)
		{
			SaveFileDialog sfd = new SaveFileDialog();
			sfd.Title = "Export JASC Palette";
			sfd.Filter = "JASC Palette (*.pal)|*.pal|All Files (*.*)|*.*";
			if (sfd.ShowDialog() == DialogResult.OK)
			{
				FileStream fs = new FileStream(sfd.FileName, FileMode.Create);
				StreamWriter sw = new StreamWriter(fs);

				switch (CurViewMode)
				{
					case CiViewerModes.Ci4:
						CurCI4Palette.ExportJasc(sw);
						break;
					case CiViewerModes.Ci8:
						CurCI8Palette.ExportJasc(sw);
						break;
				}

				sw.Close();
				fs.Close();
			}
		}
	}
}
