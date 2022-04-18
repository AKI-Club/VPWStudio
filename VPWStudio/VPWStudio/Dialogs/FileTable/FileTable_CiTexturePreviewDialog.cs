using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
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

		private int CurSubPalette = -1;

		private int PreviewImageFileID = 0;

		public FileTable_CiTexturePreviewDialog(int fileID)
		{
			PreviewImageFileID = fileID;
			InitializeComponent();

			string imgComment = Program.CurrentProject.ProjectFileTable.Entries[PreviewImageFileID].Comment;
			if (imgComment != null)
			{
				if (imgComment != String.Empty)
				{
					Text = String.Format("Preview [0x{0:X4} - {1}]", PreviewImageFileID, imgComment);
				}
				else
				{
					Text = String.Format("Preview [0x{0:X4}]", PreviewImageFileID);
				}
			}
			else
			{
				Text = String.Format("Preview [0x{0:X4}]", PreviewImageFileID);
			}

			MemoryStream romStream = new MemoryStream(Program.CurrentInputROM.Data);
			BinaryReader romReader = new BinaryReader(romStream);

			MemoryStream imgStream = new MemoryStream();
			BinaryWriter imgWriter = new BinaryWriter(imgStream);

			// CurViewMode depends on item type.
			BinaryReader fr;
			switch (Program.CurrentProject.ProjectFileTable.Entries[PreviewImageFileID].FileType)
			{
				case FileTypes.Ci4Texture:
					CurViewMode = CiViewerModes.Ci4;
					CurCI8Palette = null;
					CurCI8Texture = null;

					paletteIDs = Program.CurrentProject.ProjectFileTable.GetFilesOfType(FileTypes.Ci4Palette);
					CurCI4Palette = new Ci4Palette();
					CurCI4Texture = new Ci4Texture();

					Program.CurrentProject.ProjectFileTable.ExtractFile(romReader, imgWriter, PreviewImageFileID);
					imgStream.Seek(0, SeekOrigin.Begin);
					fr = new BinaryReader(imgStream);
					CurCI4Texture.ReadData(fr);
					fr.Close();

					CurBitmap = new Bitmap(CurCI4Texture.Width, CurCI4Texture.Height, PixelFormat.Format4bppIndexed);
					break;

				case FileTypes.Ci8Texture:
					CurViewMode = CiViewerModes.Ci8;
					CurCI4Palette = null;
					CurCI4Texture = null;

					paletteIDs = Program.CurrentProject.ProjectFileTable.GetFilesOfType(FileTypes.Ci8Palette);
					CurCI8Palette = new Ci8Palette();
					CurCI8Texture = new Ci8Texture();

					Program.CurrentProject.ProjectFileTable.ExtractFile(romReader, imgWriter, PreviewImageFileID);
					imgStream.Seek(0, SeekOrigin.Begin);
					fr = new BinaryReader(imgStream);
					CurCI8Texture.ReadData(fr);
					fr.Close();

					CurBitmap = new Bitmap(CurCI8Texture.Width, CurCI8Texture.Height, PixelFormat.Format8bppIndexed);
					break;

				case FileTypes.Ci4Background:
					// special WWF No Mercy background case
					CurViewMode = CiViewerModes.Ci4;
					CurCI8Palette = null;
					CurCI8Texture = null;

					paletteIDs = Program.CurrentProject.ProjectFileTable.GetFilesOfType(FileTypes.Ci4Palette);
					CurCI4Palette = new Ci4Palette();
					CurCI4Texture = new Ci4Texture();

					Program.CurrentProject.ProjectFileTable.ExtractFile(romReader, imgWriter, PreviewImageFileID);
					imgStream.Seek(8, SeekOrigin.Begin);
					fr = new BinaryReader(imgStream);
					CurCI4Texture.ReadRawData(320, 240, fr);
					fr.Close();

					CurBitmap = new Bitmap(CurCI4Texture.Width, CurCI4Texture.Height, PixelFormat.Format4bppIndexed);
					break;

				case FileTypes.RawCi8Texture:
					if (Program.CurrentProject.ProjectFileTable.Entries[PreviewImageFileID].ExtraData == null)
					{
						Program.ErrorMessageBox("Previewing a RawCi8Texture requires ExtraData to be set.");
						Close();
					}

					CurViewMode = CiViewerModes.Ci8;
					CurCI4Palette = null;
					CurCI4Texture = null;

					paletteIDs = Program.CurrentProject.ProjectFileTable.GetFilesOfType(FileTypes.Ci8Palette);
					CurCI8Palette = new Ci8Palette();
					CurCI8Texture = new Ci8Texture();

					Program.CurrentProject.ProjectFileTable.ExtractFile(romReader, imgWriter, PreviewImageFileID);
					imgStream.Seek(0, SeekOrigin.Begin);
					fr = new BinaryReader(imgStream);

					if (Program.CurrentProject.ProjectFileTable.Entries[PreviewImageFileID].ExtraData.ImageWidth <= 0
						|| Program.CurrentProject.ProjectFileTable.Entries[PreviewImageFileID].ExtraData.ImageHeight <= 0)
					{
						fr.Close();
						Program.ErrorMessageBox("Previewing a RawCi8Texture requires Image Width and Height to be greater than 0.");
						Close();
					}

					int w = Program.CurrentProject.ProjectFileTable.Entries[PreviewImageFileID].ExtraData.ImageWidth;
					int h = Program.CurrentProject.ProjectFileTable.Entries[PreviewImageFileID].ExtraData.ImageHeight;
					CurCI8Texture.ReadRawData(w, h, fr);
					fr.Close();

					CurBitmap = new Bitmap(CurCI8Texture.Width, CurCI8Texture.Height, PixelFormat.Format8bppIndexed);
					break;
			}

			imgWriter.Close();
			romReader.Close();

			// load palettes
			cbPalettes.Items.Clear();
			cbPalettes.BeginUpdate();
			foreach (int i in paletteIDs)
			{
				string palComment = Program.CurrentProject.ProjectFileTable.Entries[i].Comment;
				if (palComment != null)
				{
					if (!palComment.Equals(String.Empty))
					{
						cbPalettes.Items.Add(String.Format("{0:X4} ({1})", i, palComment));
					}
					else
					{
						cbPalettes.Items.Add(String.Format("{0:X4}", i));
					}
				}
				else
				{
					cbPalettes.Items.Add(String.Format("{0:X4}", i));
				}
			}
			cbPalettes.EndUpdate();

			if (Program.CurrentProject.ProjectFileTable.Entries[PreviewImageFileID].ExtraData != null)
			{
				int intendedPal = Program.CurrentProject.ProjectFileTable.Entries[PreviewImageFileID].ExtraData.IntendedPaletteFileID;
				bool foundPal = false;
				for (int i = 0; i < cbPalettes.Items.Count; i++)
				{
					if (!foundPal)
					{
						if (cbPalettes.Items[i].ToString().StartsWith(string.Format("{0:X4}", intendedPal)))
						{
							cbPalettes.SelectedIndex = i;
							foundPal = true;
						}
					}
				}
			}
		}

		/// <summary>
		/// Update image preview
		/// </summary>
		/// <param name="palID">File ID of palette to use.</param>
		private void UpdateImage(int palID)
		{
			MemoryStream romStream = new MemoryStream(Program.CurrentInputROM.Data);
			BinaryReader romReader = new BinaryReader(romStream);

			MemoryStream palStream = new MemoryStream();
			BinaryWriter palWriter = new BinaryWriter(palStream);

			Program.CurrentProject.ProjectFileTable.ExtractFile(romReader, palWriter, palID);
			palStream.Seek(0, SeekOrigin.Begin);
			BinaryReader fr = new BinaryReader(palStream);

			switch (CurViewMode)
			{
				case CiViewerModes.Ci4:
					{
						CurCI4Palette = new Ci4Palette();
						CurCI4Palette.ReadData(fr, true);
						if (CurSubPalette == -1)
						{
							CurBitmap = CurCI4Texture.ToBitmap(CurCI4Palette);
						}
						else
						{
							CurBitmap = CurCI4Texture.ToBitmap(CurCI4Palette, CurSubPalette);
						}
					}
					break;
				case CiViewerModes.Ci8:
					{
						CurCI8Palette = new Ci8Palette(fr);
						CurBitmap = CurCI8Texture.ToBitmap(CurCI8Palette);
					}
					break;
			}

			fr.Close();
			palWriter.Close();
			romReader.Close();

			pbPreview.Image = CurBitmap;
		}

		/// <summary>
		/// Set new palette and update Sub-Palette list.
		/// </summary>
		private void cbPalettes_SelectedValueChanged(object sender, EventArgs e)
		{
			UpdateImage(paletteIDs[cbPalettes.SelectedIndex]);
			UpdateSubPaletteList();
		}

		/// <summary>
		/// Update sub-palette list.
		/// </summary>
		private void UpdateSubPaletteList()
		{
			if (CurViewMode == CiViewerModes.Ci8)
			{
				cbSubPalettes.Items.Clear();
				cbSubPalettes.Enabled = false;
			}
			else
			{
				if (CurCI4Palette.SubPalettes.Count == 0)
				{
					cbSubPalettes.Items.Clear();
					cbSubPalettes.Enabled = false;
				}
				else
				{
					cbSubPalettes.Items.Clear();
					cbSubPalettes.BeginUpdate();

					cbSubPalettes.Items.Add("None");
					for (int i = 0; i < CurCI4Palette.SubPalettes.Count; i++)
					{
						cbSubPalettes.Items.Add(i);
					}

					cbSubPalettes.EndUpdate();
					cbSubPalettes.Enabled = true;
					cbSubPalettes.SelectedIndex = 0;
				}
			}
		}

		/// <summary>
		/// Selected new sub-palette
		/// </summary>
		private void cbSubPalettes_SelectionChangeCommitted(object sender, EventArgs e)
		{
			if (cbSubPalettes.SelectedIndex < 0)
			{
				return;
			}

			if (CurViewMode == CiViewerModes.Ci4)
			{
				if (cbSubPalettes.SelectedIndex == 0)
				{
					CurSubPalette = -1;
				}
				else
				{
					CurSubPalette = cbSubPalettes.SelectedIndex;
				}
				UpdateImage(paletteIDs[cbPalettes.SelectedIndex]);
			}
		}

		#region Keyboard Shortcuts
		private void FileTable_CiTexturePreviewDialog_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Escape)
			{
				this.Close();
			}
		}
		#endregion

		#region Context Menu
		private void savePNGToolStripMenuItem_Click(object sender, EventArgs e)
		{
			SaveFileDialog sfd = new SaveFileDialog();
			sfd.Title = "Save PNG";
			sfd.Filter = "PNG Files (*.png)|*.png|All Files(*.*)|*.*";
			sfd.FileName = String.Format("{0:X4}.png", PreviewImageFileID);
			if (sfd.ShowDialog() == DialogResult.OK)
			{
				this.CurBitmap.Save(sfd.FileName);
			}
		}

		#endregion

		private void backgroundColorToolStripMenuItem_Click(object sender, EventArgs e)
		{
			ColorDialog cd = new ColorDialog();
			if (cd.ShowDialog() == DialogResult.OK)
			{
				pbPreview.BackColor = cd.Color;
				UpdateImage(paletteIDs[cbPalettes.SelectedIndex]);
			}
		}
	}
}
