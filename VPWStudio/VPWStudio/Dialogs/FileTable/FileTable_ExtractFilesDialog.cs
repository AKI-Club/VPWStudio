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
	/// <summary>
	/// Extract multiple files
	/// </summary>
	public partial class FileTable_ExtractFilesDialog : Form
	{
		/// <summary>
		/// Initial list of File IDs to extract.
		/// </summary>
		private List<int> FileIDs;

		/// <summary>
		/// Final list of File IDs to extract.
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
		/// Populate list with files to export.
		/// </summary>
		private void PopulateList()
		{
			dgvFiles.Rows.Clear();
			dgvFiles.Rows.Add(FileIDs.Count);
			for (int i = 0; i < FileIDs.Count; i++)
			{
				dgvFiles.Rows[i].Cells[0].Value = true;
				dgvFiles.Rows[i].Cells[1].Value = String.Format("{0:X4}", FileIDs[i]);
				dgvFiles.Rows[i].Cells[2].Value = Program.CurrentProject.ProjectFileTable.Entries[FileIDs[i]].Comment;
				dgvFiles.Rows[i].Cells[3].Value = String.Empty;
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
				if ((bool)dgvFiles.Rows[i].Cells[0].Value == true)
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
				if ((bool)dgvFiles.Rows[i].Cells[0].Value == false)
				{
					continue;
				}

				// add entry to ExtractFiles
			}

			this.DialogResult = DialogResult.OK;
			this.Close();
		}
	}
}
