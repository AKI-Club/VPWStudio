using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VPWStudio
{
	/// <summary>
	/// Extract multiple files
	/// </summary>
	public partial class FileTable_ExtractFilesDialog : Form
	{
		#region Constants
		private const int EXPORT_COLUMN = 0;
		private const int FILEID_COLUMN = 1;
		private const int FILETYPE_COLUMN = 2;
		private const int COMMENT_COLUMN = 3;
		private const int FILENAME_COLUMN = 4;
		#endregion

		/// <summary>
		/// Initial list of File IDs to extract.
		/// </summary>
		private List<int> FileIDs;

		/// <summary>
		/// Final list of File IDs to extract, along with output filename.
		/// </summary>
		public SortedList<int, string> ExtractFiles;

		public FileTable_ExtractFilesDialog(List<int> selectedIDs)
		{
			FileIDs = selectedIDs;
			ExtractFiles = new SortedList<int, string>();
			InitializeComponent();
			PopulateList();
		}

		/// <summary>
		/// Get a suggested filename for the specified FileTableEntry.
		/// </summary>
		/// <param name="fte">FileTableEntry to get suggested filename for.</param>
		/// <returns>A suggested filename based on the FileTableEntry.</returns>
		private string GetSuggestedFilename(FileTableEntry fte)
		{
			if (FileTypeInfo.DefaultFileTypeExtensions.ContainsKey(fte.FileType))
			{
				return String.Format("{0:X4}{1}", fte.FileID, FileTypeInfo.DefaultFileTypeExtensions[fte.FileType]);
			}
			else
			{
				return String.Format("{0:X4}.bin", fte.FileID);
			}
		}

		/// <summary>
		/// Populate list with files to export.
		/// </summary>
		private void PopulateList()
		{
			dgvFiles.Rows.Clear();
			dgvFiles.Rows.Add(FileIDs.Count);
			for (int i = 0; i < FileIDs.Count; i++)
			{
				dgvFiles.Rows[i].Cells[EXPORT_COLUMN].Value = true;
				dgvFiles.Rows[i].Cells[FILEID_COLUMN].Value = String.Format("{0:X4}", FileIDs[i]);
				dgvFiles.Rows[i].Cells[FILETYPE_COLUMN].Value = Program.CurrentProject.ProjectFileTable.Entries[FileIDs[i]].FileType;
				dgvFiles.Rows[i].Cells[COMMENT_COLUMN].Value = Program.CurrentProject.ProjectFileTable.Entries[FileIDs[i]].Comment;
				dgvFiles.Rows[i].Cells[FILENAME_COLUMN].Value = GetSuggestedFilename(Program.CurrentProject.ProjectFileTable.Entries[FileIDs[i]]);
			}
		}

		/// <summary>
		/// Cancel button.
		/// </summary>
		private void buttonCancel_Click(object sender, EventArgs e)
		{
			this.DialogResult = DialogResult.Cancel;
			this.Close();
		}

		/// <summary>
		/// OK button.
		/// </summary>
		private void buttonOK_Click(object sender, EventArgs e)
		{
			// get number of checked files for export.
			int checkedCount = 0;
			for (int i = 0; i < FileIDs.Count; i++)
			{
				if ((bool)dgvFiles.Rows[i].Cells[EXPORT_COLUMN].Value == true)
				{
					checkedCount++;
				}
			}
			if (checkedCount == 0)
			{
				MessageBox.Show("No files selected for export.");
				return;
			}

			// wow we've got a lot to do here.
			// * Make sure every entry that's chosen for export has a filename.
			//   If it doesn't, we have one of two options:
			//   1) Force the user to enter a name.
			//   2) Default to "(fileID).bin" (which may not be the best option...)
			for (int i = 0; i < dgvFiles.Rows.Count; i++)
			{
				if ((bool)dgvFiles.Rows[i].Cells[EXPORT_COLUMN].Value == false)
				{
					continue;
				}

				string outName;
				int outID = UInt16.Parse(dgvFiles.Rows[i].Cells[FILEID_COLUMN].Value.ToString(), NumberStyles.HexNumber);
				if ((string)dgvFiles.Rows[i].Cells[FILENAME_COLUMN].Value == String.Empty)
				{
					outName = GetSuggestedFilename(Program.CurrentProject.ProjectFileTable.Entries[FileIDs[i]]);
				}
				else
				{
					outName = (string)dgvFiles.Rows[i].Cells[FILENAME_COLUMN].Value;
				}

				// add entry to ExtractFiles
				ExtractFiles.Add(UInt16.Parse(dgvFiles.Rows[i].Cells[FILEID_COLUMN].Value.ToString(), NumberStyles.HexNumber), outName);
			}

			this.DialogResult = DialogResult.OK;
			this.Close();
		}
	}
}
