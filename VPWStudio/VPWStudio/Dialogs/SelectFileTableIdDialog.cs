using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VPWStudio
{
	/// <summary>
	/// Dialog for selecting an entry from the FileTable
	/// </summary>
	public partial class SelectFileTableIdDialog : Form
	{
		/// <summary>
		/// The file ID of the requested file table entry.
		/// </summary>
		public uint SelectedFileID;

		/// <summary>
		/// Valid file types for the loaded game.
		/// </summary>
		private List<FileTypes> ValidFileTypes;

		/// <summary>
		/// Available File IDs based on the current filter.
		/// </summary>
		private List<int> AvailableFileIDs = new List<int>();

		/// <summary>
		/// Select File Table ID dialog.
		/// </summary>
		/// <param name="_forceFilter">Set to true if the user should not be able to set a file type filter. Should be used with _forceFT.</param>
		/// <param name="_forceFT">A specific File Type to filter for. Used when _forceFilter is set to true.</param>
		public SelectFileTableIdDialog(bool _forceFilter = false, FileTypes _forceFT = default(FileTypes))
		{
			InitializeComponent();

			cbFileTypeFilter.Items.Add("All Entries"); // must be first entry/index 0, even when forcing a filetype!
			ValidFileTypes = FileTypeInfo.GetValidFileTypesForGame(Program.CurrentProject.Settings.BaseGame);
			foreach (FileTypes ft in ValidFileTypes)
			{
				cbFileTypeFilter.Items.Add(ft.ToString());
			}

			if (_forceFilter)
			{
				cbFileTypeFilter.SelectedIndex = ValidFileTypes.IndexOf(_forceFT);
				cbFileTypeFilter.Enabled = false;
			}
			else
			{
				cbFileTypeFilter.SelectedIndex = 0;
			}
		}

		private void UpdateItemList()
		{
			lvFileTableEntries.BeginUpdate();
			lvFileTableEntries.Items.Clear();

			// filter will determine what we display
			if (cbFileTypeFilter.SelectedIndex == 0)
			{
				// "all files" option
				AvailableFileIDs.Clear();
				AvailableFileIDs.AddRange(Program.CurrentProject.ProjectFileTable.Entries.Keys);
			}
			else
			{
				AvailableFileIDs = Program.CurrentProject.ProjectFileTable.GetFilesOfType(ValidFileTypes[cbFileTypeFilter.SelectedIndex - 1]);
			}

			foreach (int fileID in AvailableFileIDs)
			{
				ListViewItem lvi = new ListViewItem(String.Format("{0:X4}",fileID));
				lvi.SubItems.Add(Program.CurrentProject.ProjectFileTable.Entries[fileID].FileType.ToString());
				lvi.SubItems.Add(Program.CurrentProject.ProjectFileTable.Entries[fileID].Comment);
				lvFileTableEntries.Items.Add(lvi);
			}

			lvFileTableEntries.EndUpdate();
		}
		private void cbFileTypeFilter_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (cbFileTypeFilter.SelectedIndex < 0)
			{
				return;
			}

			UpdateItemList();
		}

		private void buttonSelect_Click(object sender, EventArgs e)
		{
			if (lvFileTableEntries.SelectedItems.Count <= 0)
			{
				return;
			}

			SelectedFileID = uint.Parse(lvFileTableEntries.SelectedItems[0].Text, NumberStyles.HexNumber);

			DialogResult = DialogResult.OK;
			Close();
		}

		private void buttonCancel_Click(object sender, EventArgs e)
		{
			DialogResult = DialogResult.Cancel;
			Close();
		}
	}
}
