using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VPWStudio.Tools
{
	public partial class TimEditor : Form
	{
		/// <summary>
		/// The "TIM Project" is just a bunch of TIM files in a single container.
		/// </summary>
		public SortedList<int,TimFile> ProjectTimFiles;

		public TimEditor()
		{
			InitializeComponent();
			ProjectTimFiles = new SortedList<int, TimFile>();
		}

		private void UpdateTextureList()
		{
			lbTextures.BeginUpdate();
			lbTextures.Items.Clear();
			foreach (KeyValuePair<int,TimFile> e in ProjectTimFiles)
			{
				lbTextures.Items.Add(String.Format("Texture {0}",e.Key));
			}
			lbTextures.EndUpdate();
		}

		/// <summary>
		/// Create a new project.
		/// </summary>
		private void newProjectToolStripMenuItem_Click(object sender, EventArgs e)
		{
			timStatusLabel.Text = "New project file";
			ProjectTimFiles = new SortedList<int, TimFile>();
			lbTextures.BeginUpdate();
			lbTextures.Items.Clear();
			lbTextures.EndUpdate();
		}

		/// <summary>
		/// Open an existing TIM file to be used as a project base.
		/// </summary>
		private void openTIMToolStripMenuItem_Click(object sender, EventArgs e)
		{
			OpenFileDialog ofd = new OpenFileDialog();
			ofd.Title = "Select TIM File";
			ofd.Filter = SharedStrings.FileLoadFilter_TextureTim;
			if (ofd.ShowDialog() == DialogResult.OK)
			{
				timStatusLabel.Text = String.Format("Existing TIM file at {0}", Path.GetFullPath(ofd.FileName));
				ProjectTimFiles = new SortedList<int, TimFile>();
			}
		}

		/// <summary>
		/// Export project as a multi-TIM file.
		/// </summary>
		private void exportTIMToolStripMenuItem_Click(object sender, EventArgs e)
		{
			SaveFileDialog sfd = new SaveFileDialog();
			sfd.Title = "Export TIM File";
			sfd.Filter = SharedStrings.FileLoadFilter_TextureTim;
			if (sfd.ShowDialog() == DialogResult.OK)
			{
				Program.ErrorMessageBox("export not yet implemented, sorry");
			}
		}

		private void btnTextureMoveUp_Click(object sender, EventArgs e)
		{
			if (lbTextures.SelectedIndex <= 0)
			{
				return;
			}

			UpdateTextureList();
		}

		private void btnTextureMoveDown_Click(object sender, EventArgs e)
		{
			// todo: don't do this at end of list either
			if (lbTextures.SelectedIndex < 0)
			{
				return;
			}

			UpdateTextureList();
		}

		private void btnTextureAdd_Click(object sender, EventArgs e)
		{

		}

		private void btnTextureRemove_Click(object sender, EventArgs e)
		{
			if (lbTextures.SelectedIndex < 0)
			{
				return;
			}

			ProjectTimFiles.Remove(lbTextures.SelectedIndex);
			UpdateTextureList();
		}
	}
}
