using System;
using System.Windows.Forms;

namespace VPWStudio
{
	public partial class FileTableEditEntryInfoDialog : Form
	{
		/// <summary>
		/// current entry to edit
		/// </summary>
		public FileTableEntry CurEntry = new FileTableEntry();

		public FileTableEditEntryInfoDialog(FileTableEntry fte)
		{
			CurEntry.DeepCopy(fte);
			InitializeComponent();

			labelEditingEntry.Text = String.Format("Editing File Table Entry ID {0:X4}", fte.FileID);

			cbFileTypes.Items.AddRange(Enum.GetNames(typeof(FileTypes)));
			cbFileTypes.SelectedIndex = (int)CurEntry.FileType;
			tbComment.Text = fte.Comment;

			cbReplaceEncoding.SelectedIndex = (int)CurEntry.ReplaceEncoding;
			tbReplaceFilePath.Text = CurEntry.ReplaceFilePath;
		}

		/// <summary>
		/// OK button
		/// </summary>
		private void buttonOK_Click(object sender, EventArgs e)
		{
			CurEntry.FileType = (FileTypes)cbFileTypes.SelectedIndex;
			CurEntry.Comment = tbComment.Text;

			// Attempt to convert absolute paths to relative, so the project files take up less space.
			string relPath = Program.ShortenAbsolutePath(tbReplaceFilePath.Text);
			if (relPath != null)
			{
				CurEntry.ReplaceFilePath = relPath;
			}
			else
			{
				CurEntry.ReplaceFilePath = tbReplaceFilePath.Text;
			}

			CurEntry.ReplaceEncoding = (FileTableReplaceEncoding)cbReplaceEncoding.SelectedIndex;

			DialogResult = DialogResult.OK;
			Close();
		}

		/// <summary>
		/// Cancel button
		/// </summary>
		private void buttonCancel_Click(object sender, EventArgs e)
		{
			DialogResult = DialogResult.Cancel;
			Close();
		}

		/// <summary>
		/// Browse for a replacement file.
		/// </summary>
		private void buttonReplaceFileBrowse_Click(object sender, EventArgs e)
		{
			OpenFileDialog ofd = new OpenFileDialog();
			ofd.Title = "Select Replacement File";
			ofd.Filter = SharedStrings.FileFilter_None;
			if (ofd.ShowDialog() == DialogResult.OK)
			{
				CurEntry.ReplaceFilePath = ofd.FileName;
				tbReplaceFilePath.Text = ofd.FileName;
			}
		}
	}
}
