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
		public uint ModelFileID = 0;
		public uint TextureFileID = 0;
		public uint PaletteFileID = 0;

		private List<int> ModelFileIDs;
		private List<int> Ci4TexFileIDs;
		private List<int> Ci4PalFileIDs;

		public TestScene3D_AddEditDialog(int mID = 0, int tID = 0, int pID = 0)
		{
			InitializeComponent();
			GenerateTextureLists();
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

		private void GenerateTextureLists()
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
		}

		private void UpdateComboBoxLists()
		{
			cbModelFileID.BeginUpdate();
			cbModelFileID.Items.Clear();
			foreach (int id in ModelFileIDs)
			{
				cbModelFileID.Items.Add(String.Format("{0:X4}", id));
			}
			cbModelFileID.EndUpdate();
			

			cbTextureFileID.BeginUpdate();
			cbTextureFileID.Items.Clear();
			foreach (int id in Ci4TexFileIDs)
			{
				cbTextureFileID.Items.Add(String.Format("{0:X4}", id));
			}
			cbTextureFileID.EndUpdate();

			cbPaletteFileID.BeginUpdate();
			cbPaletteFileID.Items.Clear();
			foreach (int id in Ci4PalFileIDs)
			{
				cbPaletteFileID.Items.Add(String.Format("{0:X4}", id));
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
	}
}
