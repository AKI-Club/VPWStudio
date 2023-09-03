using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VPWStudio
{
	public partial class TestScene3D_AddEditDialog : Form
	{
		#region Return Values
		public uint ModelFileID = 0;
		public uint TextureFileID = 0;
		public uint PaletteFileID = 0;
		#endregion

		#region File ID Lists
		/// <summary>
		/// List of FileTable entries marked as AkiModel.
		/// </summary>
		private List<int> ModelFileIDs;

		/// <summary>
		/// List of FileTable entries marked as Ci4Texture.
		/// </summary>
		private List<int> Ci4TexFileIDs;

		/// <summary>
		/// List of FileTable entries marked as Ci4Palette.
		/// </summary>
		private List<int> Ci4PalFileIDs;

		/// <summary>
		/// List of FileTable entries marked as Ci8Texture.
		/// </summary>
		private List<int> Ci8TexFileIDs;

		/// <summary>
		/// List of FileTable entries marked as Ci8Palette.
		/// </summary>
		private List<int> Ci8PalFileIDs;
		#endregion

		public TestScene3D_AddEditDialog(int mID = 0, int tID = 0, int pID = 0)
		{
			InitializeComponent();
			GenerateLists();

			// model list only needs to be generated once
			cbModelFileID.BeginUpdate();
			cbModelFileID.Items.Clear();
			foreach (int id in ModelFileIDs)
			{
				cbModelFileID.Items.Add(String.Format("{0:X4}", id));
			}
			cbModelFileID.EndUpdate();

			// default to CI4 (todo: don't assume this, and check based on passed in file IDs)
			cbCiType.SelectedIndex = 0;
			UpdateComboBoxLists();

			if (mID != 0 && tID != 0 && pID != 0)
			{
				Text = "Edit Object";
			}

			if (mID != 0)
			{
				int idx = ModelFileIDs.IndexOf(mID);
				if (idx != -1)
				{
					cbModelFileID.SelectedIndex = idx;
				}
				else
				{
					cbModelFileID.SelectedIndex = 0;
				}
			}
			else
			{
				cbModelFileID.SelectedIndex = 0;
			}

			// todo: CI8 support
			if (tID != 0)
			{
				int idx = Ci4TexFileIDs.IndexOf(tID);
				if (idx != -1)
				{
					cbTextureFileID.SelectedIndex = idx;
				}
				else
				{
					cbTextureFileID.SelectedIndex = 0;
				}
			}
			else
			{
				cbTextureFileID.SelectedIndex = 0;
			}

			if (pID != 0)
			{
				int idx = Ci4PalFileIDs.IndexOf(pID);
				if (idx != -1)
				{
					cbPaletteFileID.SelectedIndex = idx;
				}
				else
				{
					cbPaletteFileID.SelectedIndex = 0;
				}
			}
			else
			{
				cbPaletteFileID.SelectedIndex = 0;
			}
		}

		private void GenerateLists()
		{
			List<int> Remove = new List<int>();

			ModelFileIDs = Program.CurrentProject.ProjectFileTable.GetFilesOfType(FileTypes.AkiModel);
			foreach (int mID in ModelFileIDs)
			{
				if (Program.CurrentProject.ProjectFileTable.Entries[mID].OverrideFileType)
				{
					Remove.Add(mID);
				}
			}
			foreach (int mID in Remove)
			{
				ModelFileIDs.Remove(mID);
			}

			// CI4 textures
			Remove.Clear();
			Ci4TexFileIDs = Program.CurrentProject.ProjectFileTable.GetFilesOfType(FileTypes.Ci4Texture);
			foreach (int tID in Ci4TexFileIDs)
			{
				if (Program.CurrentProject.ProjectFileTable.Entries[tID].OverrideFileType)
				{
					Remove.Add(tID);
				}
			}
			foreach (int tID in Remove)
			{
				Ci4TexFileIDs.Remove(tID);
			}

			// CI4 palettes
			Remove.Clear();
			Ci4PalFileIDs = Program.CurrentProject.ProjectFileTable.GetFilesOfType(FileTypes.Ci4Palette);
			foreach (int pID in Ci4PalFileIDs)
			{
				if (Program.CurrentProject.ProjectFileTable.Entries[pID].OverrideFileType)
				{
					Remove.Add(pID);
				}
			}
			foreach (int pID in Remove)
			{
				Ci4PalFileIDs.Remove(pID);
			}

			// CI8 textures
			Remove.Clear();
			Ci8TexFileIDs = Program.CurrentProject.ProjectFileTable.GetFilesOfType(FileTypes.Ci8Texture);
			foreach (int tID in Ci8TexFileIDs)
			{
				if (Program.CurrentProject.ProjectFileTable.Entries[tID].OverrideFileType)
				{
					Remove.Add(tID);
				}
			}
			foreach (int tID in Remove)
			{
				Ci8TexFileIDs.Remove(tID);
			}

			// CI8 palettes
			Remove.Clear();
			Ci8PalFileIDs = Program.CurrentProject.ProjectFileTable.GetFilesOfType(FileTypes.Ci8Palette);
			foreach (int pID in Ci8PalFileIDs)
			{
				if (Program.CurrentProject.ProjectFileTable.Entries[pID].OverrideFileType)
				{
					Remove.Add(pID);
				}
			}
			foreach (int pID in Remove)
			{
				Ci8PalFileIDs.Remove(pID);
			}
		}

		private void UpdateComboBoxLists()
		{
			cbTextureFileID.BeginUpdate();
			cbTextureFileID.Items.Clear();
			if (cbCiType.SelectedIndex == 0)
			{
				// CI4
				foreach (int id in Ci4TexFileIDs)
				{
					cbTextureFileID.Items.Add(String.Format("{0:X4}", id));
				}
			}
			else
			{
				// CI8
				foreach (int id in Ci8TexFileIDs)
				{
					cbTextureFileID.Items.Add(String.Format("{0:X4}", id));
				}
			}
			cbTextureFileID.EndUpdate();

			cbPaletteFileID.BeginUpdate();
			cbPaletteFileID.Items.Clear();
			if (cbCiType.SelectedIndex == 0)
			{
				// CI4
				foreach (int id in Ci4PalFileIDs)
				{
					cbPaletteFileID.Items.Add(String.Format("{0:X4}", id));
				}
			}
			else
			{
				// CI8
				foreach (int id in Ci8PalFileIDs)
				{
					cbPaletteFileID.Items.Add(String.Format("{0:X4}", id));
				}
			}
			cbPaletteFileID.EndUpdate();
		}

		private void btnOK_Click(object sender, EventArgs e)
		{
			ModelFileID = Convert.ToUInt32(cbModelFileID.Items[cbModelFileID.SelectedIndex].ToString(), 16);
			TextureFileID = Convert.ToUInt32(cbTextureFileID.Items[cbTextureFileID.SelectedIndex].ToString(), 16);
			PaletteFileID = Convert.ToUInt32(cbPaletteFileID.Items[cbPaletteFileID.SelectedIndex].ToString(), 16);

			DialogResult = DialogResult.OK;
			Close();
		}

		private void btnCancel_Click(object sender, EventArgs e)
		{
			DialogResult = DialogResult.Cancel;
			Close();
		}

		private void cbModelFileID_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (cbModelFileID.SelectedIndex < 0)
			{
				return;
			}

			int modelID = Convert.ToInt32(cbModelFileID.Items[cbModelFileID.SelectedIndex].ToString(), 16);
			tbModelComment.Text = Program.CurrentProject.ProjectFileTable.Entries[modelID].Comment;
		}

		private void cbPaletteFileID_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (cbPaletteFileID.SelectedIndex < 0)
			{
				return;
			}

			int palID = Convert.ToInt32(cbPaletteFileID.Items[cbPaletteFileID.SelectedIndex].ToString(), 16);
			tbPaletteComment.Text = Program.CurrentProject.ProjectFileTable.Entries[palID].Comment;
		}

		private void cbTextureFileID_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (cbTextureFileID.SelectedIndex < 0)
			{
				return;
			}

			int texID = Convert.ToInt32(cbTextureFileID.Items[cbTextureFileID.SelectedIndex].ToString(), 16);
			tbTextureComment.Text = Program.CurrentProject.ProjectFileTable.Entries[texID].Comment;
		}

		private void cbCiType_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (cbCiType.SelectedIndex < 0)
			{
				return;
			}
			UpdateComboBoxLists();
		}
	}
}
