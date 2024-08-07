﻿using System;
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

namespace VPWStudio
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

		/// <summary>
		/// If true, this texture is mirrored horizontally when repeating.
		/// Only valid for Ci4Texture and Ci8Texture.
		/// </summary>
		public bool HorizontalMirror = false;

		/// <summary>
		/// If true, this texture is mirrored vertically when repeating.
		/// Only valid for Ci4Texture and Ci8Texture.
		/// </summary>
		public bool VerticalMirror = false;

		/// <summary>
		/// Only set to true when changing the mirroring values
		/// </summary>
		public bool MirroringValuesSet = false;

		public SelectTextureDialog(uint texFileID, uint palFileID)
		{
			InitializeComponent();

			GenerateTextureLists();
			UpdateComboBoxLists();

			if (texFileID != 0)
			{
				// try finding ID in texture file IDs
				if (Ci4TexFileIDs.Contains((int)texFileID))
				{
					CurTextureType = ValidTextureTypes.CI4Texture;
					cbTextureType.SelectedIndex = (int)CurTextureType;
					cbTextureFileIDs.SelectedIndex = Ci4TexFileIDs.IndexOf((int)texFileID);
				}
				else if (Ci8TexFileIDs.Contains((int)texFileID))
				{
					CurTextureType = ValidTextureTypes.CI8Texture;
					cbTextureType.SelectedIndex = (int)CurTextureType;
					cbTextureFileIDs.SelectedIndex = Ci8TexFileIDs.IndexOf((int)texFileID);
				}
				else if (AkiTexFileIDs.Contains((int)texFileID))
				{
					CurTextureType = ValidTextureTypes.AkiTexture;
					cbTextureType.SelectedIndex = (int)CurTextureType;
					cbTextureFileIDs.SelectedIndex = AkiTexFileIDs.IndexOf((int)texFileID);
				}
			}
			else
			{
				CurTextureType = ValidTextureTypes.CI4Texture;
				cbTextureType.SelectedIndex = 0;
			}

			if (palFileID != 0 && CurTextureType != ValidTextureTypes.AkiTexture)
			{
				if (CurTextureType == ValidTextureTypes.CI4Texture)
				{
					cbPaletteFileIDs.SelectedIndex = Ci4PalFileIDs.IndexOf((int)palFileID);
				}
				else if (CurTextureType == ValidTextureTypes.CI8Texture)
				{
					cbPaletteFileIDs.SelectedIndex = Ci8PalFileIDs.IndexOf((int)palFileID);
				}
			}
		}

		private void GenerateTextureLists()
		{
			AkiTexFileIDs = Program.CurrentProject.ProjectFileTable.GetFilesOfType(FileTypes.AkiTexture, true);
			Ci4TexFileIDs = Program.CurrentProject.ProjectFileTable.GetFilesOfType(FileTypes.Ci4Texture, true);
			Ci8TexFileIDs = Program.CurrentProject.ProjectFileTable.GetFilesOfType(FileTypes.Ci8Texture, true);
			Ci4PalFileIDs = Program.CurrentProject.ProjectFileTable.GetFilesOfType(FileTypes.Ci4Palette, true);
			Ci8PalFileIDs = Program.CurrentProject.ProjectFileTable.GetFilesOfType(FileTypes.Ci8Palette, true);
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

				if (CurTextureType == ValidTextureTypes.CI4Texture)
				{
					HorizontalMirror = CurrentCI4Tex.HorizMirror != 0;
					VerticalMirror = CurrentCI4Tex.VertMirror != 0;
					MirroringValuesSet = true;
				}
				else if (CurTextureType == ValidTextureTypes.CI8Texture)
				{
					HorizontalMirror = CurrentCI8Tex.HorizMirror != 0;
					VerticalMirror = CurrentCI8Tex.VertMirror != 0;
					MirroringValuesSet = true;
				}
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
