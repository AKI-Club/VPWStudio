using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VPWStudio
{
	public partial class PackedFileTool : Form
	{
		public AkiArchive pf = new AkiArchive();

		public PackedFileTool()
		{
			InitializeComponent();
		}

		private void buttonOpen_Click(object sender, EventArgs e)
		{
			OpenFileDialog ofd = new OpenFileDialog();
			ofd.Title = "Open Packed File";
			ofd.Filter = SharedStrings.FileFilter_None;
			if (ofd.ShowDialog() == DialogResult.OK)
			{
				this.pf = new AkiArchive();
				this.pf.ReadFile(ofd.FileName);
				tbCurFile.Text = ofd.FileName;

				lbFileEntries.Items.Clear();
				lbFileEntries.BeginUpdate();
				for (int i = 0; i < this.pf.FileEntries.Count; i++)
				{
					lbFileEntries.Items.Add(String.Format("Entry {0}",i));
				}
				lbFileEntries.EndUpdate();
			}
		}

		private void buttonResave_Click(object sender, EventArgs e)
		{
			// BAD IDEA JEANS
			SaveFileDialog sfd = new SaveFileDialog();
			sfd.Title = "You really want to test incomplete code, huh?";
			sfd.Filter = SharedStrings.FileFilter_None;
			if (sfd.ShowDialog() == DialogResult.OK)
			{
				this.pf.WriteFile(sfd.FileName);
			}
		}

		private void lbFileEntries_SelectedIndexChanged(object sender, EventArgs e)
		{
			tbSelectedFileInfo.Clear();
			if (lbFileEntries.SelectedIndex < 0)
			{
				return;
			}

			AkiArchiveEntry pae = this.pf.FileEntries[lbFileEntries.SelectedIndex];

			tbSelectedFileInfo.Text = String.Format(
				"File Index {0}:\r\nStart Offset: 0x{1:X8}\r\nFile Size: 0x{2:X8}\r\n\r\n",
				lbFileEntries.SelectedIndex,
				pae.StartAddr,
				pae.Size
			);
		}

		private void buttonExtractFile_Click(object sender, EventArgs e)
		{
			if (lbFileEntries.SelectedIndex < 0)
			{
				return;
			}

			SaveFileDialog sfd = new SaveFileDialog();
			sfd.Title = "Export File";
			sfd.Filter = SharedStrings.FileFilter_None;
			if (sfd.ShowDialog() == DialogResult.OK)
			{
				pf.ExtractSingleFile(lbFileEntries.SelectedIndex, sfd.FileName);
			}
		}
	}
}
