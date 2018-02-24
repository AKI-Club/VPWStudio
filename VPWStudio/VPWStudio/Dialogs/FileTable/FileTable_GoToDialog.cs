using System;
using System.Windows.Forms;

namespace VPWStudio
{
	/// <summary>
	/// Simple dialog for jumping to a specific entry in the FileTable form.
	/// </summary>
	public partial class FileTable_GoToDialog : Form
	{
		public int DestinationFileID;

		public FileTable_GoToDialog()
		{
			InitializeComponent();
			nudFileID.Maximum = Program.CurrentProject.ProjectFileTable.Entries.Count;
			nudFileID.Select(0,1);
		}

		private void buttonCancel_Click(object sender, EventArgs e)
		{
			this.DialogResult = DialogResult.Cancel;
			this.Close();
		}

		private void buttonOK_Click(object sender, EventArgs e)
		{
			DestinationFileID = (int)nudFileID.Value;
			this.DialogResult = DialogResult.OK;
			this.Close();
		}
	}
}
