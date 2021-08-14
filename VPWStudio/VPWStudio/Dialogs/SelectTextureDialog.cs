using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
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
			AkiTexture
		}

		public uint TextureFileID = 0;

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

		/// <summary>
		/// Default image size
		/// </summary>
		private Size DefaultImageSize;

		public SelectTextureDialog()
		{
			InitializeComponent();

			GenerateTextureLists();

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

			if (CurTextureType == ValidTextureTypes.AkiTexture)
			{

			}
			else
			{

			}
		}

		private void cbTextureType_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (cbTextureType.SelectedIndex < 0)
			{
				return;
			}
			CurTextureType = (ValidTextureTypes)cbTextureType.SelectedIndex;

			// update boxes for texture and palette
			UpdateComboBoxLists();
			cbTextureFileIDs.SelectedIndex = 0;
			cbPaletteFileIDs.SelectedIndex = 0;

			// update preview display
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
			if (cbTextureType.SelectedIndex <= 0)
			{
				return;
			}
			if (cbPaletteFileIDs.SelectedIndex < 0)
			{
				return;
			}
		}
	}
}
