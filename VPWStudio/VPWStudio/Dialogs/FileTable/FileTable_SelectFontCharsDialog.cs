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
	public partial class FileTable_SelectFontCharsDialog : Form
	{
		private List<int> FontCharsFiles = new List<int>();
		public int SelectedFileID = 0;

		public FileTable_SelectFontCharsDialog(List<int> fontChars)
		{
			InitializeComponent();

			foreach (int i in fontChars)
			{
				FontCharsFiles.Add(i);
			}
			cbFontCharsFile.BeginUpdate();
			foreach (int j in FontCharsFiles)
			{
				cbFontCharsFile.Items.Add(j);
			}
			cbFontCharsFile.EndUpdate();
			cbFontCharsFile.SelectedIndex = 0;
		}

		private void buttonCancel_Click(object sender, EventArgs e)
		{
			DialogResult = DialogResult.Cancel;
			Close();
		}

		private void buttonOK_Click(object sender, EventArgs e)
		{
			DialogResult = DialogResult.OK;
			SelectedFileID = FontCharsFiles[cbFontCharsFile.SelectedIndex];
			Close();
		}
	}
}
