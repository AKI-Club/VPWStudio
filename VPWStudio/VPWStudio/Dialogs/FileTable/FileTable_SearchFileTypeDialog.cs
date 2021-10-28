using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VPWStudio.Dialogs.FileTable
{
	public partial class FileTable_SearchFileTypeDialog : Form
	{
		/// <summary>
		/// FileType to search for.
		/// </summary>
		public FileTypes SelectedFileType;

		/// <summary>
		/// List of valid FileTypes for the current game.
		/// </summary>
		private List<FileTypes> ValidTypes = FileTypeInfo.GetValidFileTypesForGame(Program.CurrentProject.Settings.BaseGame);

		public FileTable_SearchFileTypeDialog()
		{
			InitializeComponent();

			cbFileTypes.BeginUpdate();
			for (int i = 0; i < ValidTypes.Count; i++)
			{
				cbFileTypes.Items.Add(Enum.GetName(typeof(FileTypes), ValidTypes[i]));
			}
			cbFileTypes.EndUpdate();
			cbFileTypes.SelectedIndex = 0;
		}

		private void buttonCancel_Click(object sender, EventArgs e)
		{
			DialogResult = DialogResult.Cancel;
			Close();
		}

		private void buttonOK_Click(object sender, EventArgs e)
		{
			SelectedFileType = ValidTypes[cbFileTypes.SelectedIndex];
			DialogResult = DialogResult.OK;
			Close();
		}
	}
}
