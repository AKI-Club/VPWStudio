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
	public partial class FileTableEditEntryInfoDialog : Form
	{
		/// <summary>
		/// current entry to edit
		/// </summary>
		public FileTableEntry CurEntry = new FileTableEntry();

		public FileTableEditEntryInfoDialog(FileTableEntry fte)
		{
			this.CurEntry.DeepCopy(fte);
			InitializeComponent();

			labelEditingEntry.Text = String.Format("Editing File Table Entry ID {0:X4}", fte.FileID);

			cbFileTypes.Items.AddRange(Enum.GetNames(typeof(FileTypes)));
			cbFileTypes.SelectedIndex = (int)this.CurEntry.FileType;
			tbComment.Text = fte.Comment;

			cbReplaceEncoding.SelectedIndex = (int)this.CurEntry.ReplaceEncoding;
			tbReplaceFilePath.Text = this.CurEntry.ReplaceFilePath;
		}

		/// <summary>
		/// OK button
		/// </summary>
		private void buttonOK_Click(object sender, EventArgs e)
		{
			this.CurEntry.Comment = tbComment.Text;
			this.CurEntry.ReplaceFilePath = tbReplaceFilePath.Text;

			this.DialogResult = DialogResult.OK;
			this.Close();
		}

		/// <summary>
		/// Cancel button
		/// </summary>
		private void buttonCancel_Click(object sender, EventArgs e)
		{
			this.DialogResult = DialogResult.Cancel;
			this.Close();
		}

		/// <summary>
		/// Update selected file type.
		/// </summary>
		private void cbFileTypes_SelectionChangeCommitted(object sender, EventArgs e)
		{
			this.CurEntry.FileType = (FileTypes)cbFileTypes.SelectedIndex;
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
				this.CurEntry.ReplaceFilePath = ofd.FileName;
				tbReplaceFilePath.Text = ofd.FileName;
			}
		}

		private void cbReplaceEncoding_SelectedValueChanged(object sender, EventArgs e)
		{
			this.CurEntry.ReplaceEncoding = (FileTableReplaceEncoding)cbReplaceEncoding.SelectedIndex;
		}
	}
}
