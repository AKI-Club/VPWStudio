using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace VPWStudio
{
	public partial class FileTable_EditMultiEntryInfoDialog : Form
	{
		#region Column Constants
		private const int COLUMN_FILEID = 0;
		private const int COLUMN_FILETYPE = 1;
		private const int COLUMN_ENCODING = 2;
		private const int COLUMN_COMMENT = 3;
		private const int COLUMN_REPLACEFILE = 4;
		private const int COLUMN_BROWSE = 5;

		private static string BROWSE_TEXT = "Browse...";
		#endregion

		public List<FileTableEntry> Entries = new List<FileTableEntry>();

		public bool AnyChangesSubmitted = false;

		public FileTable_EditMultiEntryInfoDialog(List<FileTableEntry> entries)
		{
			Entries = entries;
			InitializeComponent();
			PopulateEntries();
		}

		private void AddFileTypes(DataGridViewComboBoxCell cb, FileTableEntry entry)
		{
			cb.Items.AddRange(FileTypeInfo.GetValidFileTypesForGame(Program.CurrentProject.Settings.BaseGame));
		}

		private void PopulateEntries()
		{
			dgvEditEntries.Rows.Add(Entries.Count);

			for (int i = 0; i < Entries.Count; i++)
			{
				dgvEditEntries.Rows[i].Cells[COLUMN_FILEID].Value = String.Format("{0:X4}", Entries[i].FileID);

				AddFileTypes((DataGridViewComboBoxCell)dgvEditEntries.Rows[i].Cells[COLUMN_FILETYPE], Entries[i]);
				dgvEditEntries.Rows[i].Cells[COLUMN_FILETYPE].Value = Enum.GetName(typeof(FileTypes), Entries[i].FileType);

				//dgvEditEntries.Rows[i].Cells[COLUMN_ENCODING]

				dgvEditEntries.Rows[i].Cells[COLUMN_COMMENT].Value = Entries[i].Comment;
				dgvEditEntries.Rows[i].Cells[COLUMN_REPLACEFILE].Value = Entries[i].ReplaceFilePath;
				dgvEditEntries.Rows[i].Cells[COLUMN_BROWSE].Value = BROWSE_TEXT;
			}
		}

		private void buttonOK_Click(object sender, EventArgs e)
		{
			// update Entries with data from the dgv
			for (int i = 0; i < Entries.Count; i++)
			{
				// filetype
				FileTypes newFT = (FileTypes)Enum.Parse(typeof(FileTypes), dgvEditEntries.Rows[i].Cells[COLUMN_FILETYPE].Value.ToString());
				if (newFT != Entries[i].FileType)
				{
					AnyChangesSubmitted = true;
					Entries[i].FileType = newFT;
				}

				// encoding

				// replace path
				string newPath = dgvEditEntries.Rows[i].Cells[COLUMN_REPLACEFILE].Value.ToString();
				if (newPath != Entries[i].ReplaceFilePath)
				{
					AnyChangesSubmitted = true;
					// todo: gotta do shit
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

		private void dgvEditEntries_CellContentClick(object sender, DataGridViewCellEventArgs e)
		{
			if (e.ColumnIndex == COLUMN_BROWSE)
			{
				OpenFileDialog ofd = new OpenFileDialog();
				FileTableEntry editing = Entries[e.RowIndex];
				ofd.Title = String.Format("Select Replacement for File ID {0:X4}", editing.FileID);
				if (ofd.ShowDialog() == DialogResult.OK)
				{
					Program.ErrorMessageBox("damnit freem can't you implement ANYTHING on the first try?!");
				}
			}
		}
	}
}
