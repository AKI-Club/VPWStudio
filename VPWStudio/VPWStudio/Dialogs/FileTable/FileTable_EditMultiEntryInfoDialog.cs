using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
		#endregion

		public List<FileTableEntry> Entries = new List<FileTableEntry>();

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
				//dgvEditEntries.Rows[i].Cells[COLUMN_FILETYPE]
				AddFileTypes((DataGridViewComboBoxCell)dgvEditEntries.Rows[i].Cells[COLUMN_FILETYPE], Entries[i]);

				//dgvEditEntries.Rows[i].Cells[COLUMN_ENCODING]
				dgvEditEntries.Rows[i].Cells[COLUMN_COMMENT].Value = Entries[i].Comment;
				dgvEditEntries.Rows[i].Cells[COLUMN_REPLACEFILE].Value = Entries[i].ReplaceFilePath;
				dgvEditEntries.Rows[i].Cells[COLUMN_BROWSE].Value = "Browse...";
			}
		}

		private void buttonOK_Click(object sender, EventArgs e)
		{
			// update Entries with data from the dgv

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
