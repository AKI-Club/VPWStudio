using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VPWStudio.Dialogs
{
	public partial class SelectTextureDialog : Form
	{
		public enum ValidTextureTypes
		{
			CI4Texture = 0,
			CI8Texture,
			AkiTexture // not likely, but just in case
		}

		/// <summary>
		/// File ID for the selected Texture.
		/// </summary>
		public uint TextureFileID = 0;

		/// <summary>
		/// File ID for the selected Palette.
		/// Only used if CurTextureType is not AkiTexture.
		/// </summary>
		public uint PaletteFileID = 0;

		private ValidTextureTypes CurTextureType;

		private List<int> AkiTexFileIDs;
		private List<int> Ci4TexFileIDs;
		private List<int> Ci8TexFileIDs;
		private List<int> Ci4PalFileIDs;
		private List<int> Ci8PalFileIDs;

		/// <summary>
		/// Current TEX file
		/// </summary>
		private AkiTexture CurrentTEX;

		private Ci4Texture CurrentCI4Tex;
		private Ci8Texture CurrentCI8Tex;
		private Ci4Palette CurrentCI4Pal;
		private Ci8Palette CurrentCI8Pal;

		/// <summary>
		/// Current Bitmap
		/// </summary>
		private Bitmap CurrentBitmap;

		public Bitmap OutputBitmap
		{
			get { return CurrentBitmap; }
		}

		public SelectTextureDialog()
		{
			InitializeComponent();

			GenerateTextureLists();

			CurTextureType = ValidTextureTypes.CI4Texture;
			UpdateComboBoxLists();
			cbTextureType.SelectedIndex = 0;
		}

		private void GenerateTextureLists()
		{
			AkiTexFileIDs = Program.CurrentProject.ProjectFileTable.GetFilesOfType(FileTypes.AkiTexture);
			Ci4TexFileIDs = Program.CurrentProject.ProjectFileTable.GetFilesOfType(FileTypes.Ci4Texture);
			Ci8TexFileIDs = Program.CurrentProject.ProjectFileTable.GetFilesOfType(FileTypes.Ci8Texture);
			Ci4PalFileIDs = Program.CurrentProject.ProjectFileTable.GetFilesOfType(FileTypes.Ci4Palette);
			Ci8PalFileIDs = Program.CurrentProject.ProjectFileTable.GetFilesOfType(FileTypes.Ci8Palette);
		}

		private void UpdateComboBoxLists()
		{
			cbTextureFileIDs.BeginUpdate();
			cbTextureFileIDs.Items.Clear();
			switch (CurTextureType)
			{
				case ValidTextureTypes.AkiTexture:
					{
						foreach (int id in AkiTexFileIDs)
						{
							cbTextureFileIDs.Items.Add(String.Format("{0:X4}",id));
						}
					}
					break;
				case ValidTextureTypes.CI4Texture:
					{
						foreach (int id in Ci4TexFileIDs)
						{
							cbTextureFileIDs.Items.Add(String.Format("{0:X4}", id));
						}
					}
					break;
				case ValidTextureTypes.CI8Texture:
					{
						foreach (int id in Ci8TexFileIDs)
						{
							cbTextureFileIDs.Items.Add(String.Format("{0:X4}", id));
						}
					}
					break;
			}
			cbTextureFileIDs.EndUpdate();

			cbPaletteFileIDs.BeginUpdate();
			cbPaletteFileIDs.Items.Clear();
			if (CurTextureType != ValidTextureTypes.AkiTexture)
			{
				// load palettes
				cbPaletteFileIDs.Enabled = true;
				if (CurTextureType == ValidTextureTypes.CI4Texture)
				{
					foreach (int id in Ci4PalFileIDs)
					{
						cbPaletteFileIDs.Items.Add(String.Format("{0:X4}", id));
					}
				}

				else if (CurTextureType == ValidTextureTypes.CI8Texture)
				{
					foreach (int id in Ci8PalFileIDs)
					{
						cbPaletteFileIDs.Items.Add(String.Format("{0:X4}", id));
					}
				}
			}
			else
			{
				cbPaletteFileIDs.Enabled = false;
			}
			cbPaletteFileIDs.EndUpdate();
		}

		private void buttonOK_Click(object sender, EventArgs e)
		{
			// set TextureFileID and PaletteFileID as needed
			TextureFileID = Convert.ToUInt32(cbTextureFileIDs.Items[cbTextureFileIDs.SelectedIndex].ToString(), 16);
			if (CurTextureType != ValidTextureTypes.AkiTexture)
			{
				PaletteFileID = Convert.ToUInt32(cbPaletteFileIDs.Items[cbPaletteFileIDs.SelectedIndex].ToString(), 16);
			}

			DialogResult = DialogResult.OK;
			Close();
		}

		private void buttonCancel_Click(object sender, EventArgs e)
		{
			DialogResult = DialogResult.Cancel;
			Close();
		}

		private void UpdatePreview()
		{
			if (cbTextureType.SelectedIndex < 0)
			{
				return;
			}

			if (cbTextureFileIDs.SelectedIndex < 0)
			{
				return;
			}

			int texFileID = Convert.ToInt32(cbTextureFileIDs.Items[cbTextureFileIDs.SelectedIndex].ToString(), 16);
			if (CurTextureType == ValidTextureTypes.AkiTexture)
			{
				MemoryStream romStream = new MemoryStream(Program.CurrentInputROM.Data);
				BinaryReader romReader = new BinaryReader(romStream);

				MemoryStream outStream = new MemoryStream();
				BinaryWriter outWriter = new BinaryWriter(outStream);

				Program.CurrentProject.ProjectFileTable.ExtractFile(romReader, outWriter, texFileID);
				romReader.Close();

				BinaryReader outReader = new BinaryReader(outStream);
				outStream.Seek(0, SeekOrigin.Begin);

				CurrentTEX = new AkiTexture(outReader);
				pbPreview.Width = CurrentTEX.Width;
				pbPreview.Height = CurrentTEX.Height;

				CurrentBitmap = CurrentTEX.ToBitmap();
				pbPreview.Image = CurrentBitmap;

				outReader.Close();
				outWriter.Close();
			}
			else
			{
				// CI*Texture and Palette
				if (cbPaletteFileIDs.SelectedIndex < 0 || cbTextureFileIDs.SelectedIndex < 0)
				{
					return;
				}

				int palFileID = Convert.ToInt32(cbPaletteFileIDs.Items[cbPaletteFileIDs.SelectedIndex].ToString(), 16);

				MemoryStream romStream = new MemoryStream(Program.CurrentInputROM.Data);
				BinaryReader romReader = new BinaryReader(romStream);

				MemoryStream imgStream = new MemoryStream();
				BinaryWriter imgWriter = new BinaryWriter(imgStream);

				if (CurTextureType == ValidTextureTypes.CI4Texture)
				{
					CurrentCI8Pal = null;
					CurrentCI8Tex = null;

					CurrentCI4Pal = new Ci4Palette();
					CurrentCI4Tex = new Ci4Texture();

					Program.CurrentProject.ProjectFileTable.ExtractFile(romReader, imgWriter, texFileID);
					imgStream.Seek(0, SeekOrigin.Begin);
					BinaryReader texfr = new BinaryReader(imgStream);
					CurrentCI4Tex.ReadData(texfr);
					texfr.Close();

					CurrentBitmap = new Bitmap(CurrentCI4Tex.Width, CurrentCI4Tex.Height, PixelFormat.Format4bppIndexed);
				}
				else if (CurTextureType == ValidTextureTypes.CI8Texture)
				{
					CurrentCI4Pal = null;
					CurrentCI4Tex = null;

					CurrentCI8Pal = new Ci8Palette();
					CurrentCI8Tex = new Ci8Texture();

					Program.CurrentProject.ProjectFileTable.ExtractFile(romReader, imgWriter, texFileID);
					imgStream.Seek(0, SeekOrigin.Begin);
					BinaryReader texfr = new BinaryReader(imgStream);
					CurrentCI8Tex.ReadData(texfr);
					texfr.Close();

					CurrentBitmap = new Bitmap(CurrentCI8Tex.Width, CurrentCI8Tex.Height, PixelFormat.Format8bppIndexed);
				}

				imgWriter.Close();
				romReader.Close();

				romStream = new MemoryStream(Program.CurrentInputROM.Data);
				romReader = new BinaryReader(romStream);

				MemoryStream palStream = new MemoryStream();
				BinaryWriter palWriter = new BinaryWriter(palStream);

				Program.CurrentProject.ProjectFileTable.ExtractFile(romReader, palWriter, palFileID);
				palStream.Seek(0, SeekOrigin.Begin);
				BinaryReader palfr = new BinaryReader(palStream);
				if (CurTextureType == ValidTextureTypes.CI4Texture)
				{
					CurrentCI4Pal = new Ci4Palette();
					CurrentCI4Pal.ReadData(palfr, false);
					CurrentBitmap = CurrentCI4Tex.ToBitmap(CurrentCI4Pal);
					pbPreview.Image = CurrentBitmap;
				}
				else if (CurTextureType == ValidTextureTypes.CI8Texture)
				{
					CurrentCI8Pal = new Ci8Palette(palfr);
					CurrentBitmap = CurrentCI8Tex.ToBitmap(CurrentCI8Pal);
					pbPreview.Image = CurrentBitmap;
				}
			}
		}

		private void UpdateTextureType()
		{
			if (cbTextureType.SelectedIndex < 0)
			{
				return;
			}
			CurTextureType = (ValidTextureTypes)cbTextureType.SelectedIndex;

			// update boxes for texture and palette
			UpdateComboBoxLists();
			cbTextureFileIDs.SelectedIndex = 0;
			if (CurTextureType != ValidTextureTypes.AkiTexture)
			{
				cbPaletteFileIDs.SelectedIndex = 0;
			}

			UpdatePreview();
		}

		private void cbTextureType_SelectionChangeCommitted(object sender, EventArgs e)
		{
			UpdateTextureType();
		}

		private void cbTextureType_SelectedIndexChanged(object sender, EventArgs e)
		{
			UpdateTextureType();
		}

		private void cbTextureFileIDs_SelectionChangeCommitted(object sender, EventArgs e)
		{
			if (cbTextureType.SelectedIndex < 0)
			{
				return;
			}
			if (cbTextureFileIDs.SelectedIndex < 0)
			{
				return;
			}

			UpdatePreview();
		}

		private void cbTextureFileIDs_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (cbTextureType.SelectedIndex < 0)
			{
				return;
			}
			if (cbTextureFileIDs.SelectedIndex < 0)
			{
				return;
			}

			UpdatePreview();
		}

		private void cbPaletteFileIDs_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (cbTextureType.SelectedIndex < 0)
			{
				return;
			}
			if (cbPaletteFileIDs.SelectedIndex < 0)
			{
				return;
			}

			UpdatePreview();
		}
	}
}
