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

			// Main page
			// todo: this causes issues if entries are removed
			cbFileTypes.Items.AddRange(FileTypeInfo.GetValidFileTypesForGame(Program.CurrentProject.Settings.BaseGame));
			cbFileTypes.SelectedIndex = (int)CurEntry.FileType;
			cbForceFileType.Checked = CurEntry.OverrideFileType;
			tbComment.Text = fte.Comment;

			cbReplaceEncoding.SelectedIndex = (int)CurEntry.ReplaceEncoding;
			tbReplaceFilePath.Text = CurEntry.ReplaceFilePath;

			// Extra page
			if (CurEntry.ExtraData == null)
			{
				CurEntry.ExtraData = new FileTableEntryExtraData();
			}
			nudImageWidth.Value = CurEntry.ExtraData.ImageWidth;
			nudImageHeight.Value = CurEntry.ExtraData.ImageHeight;
			nudTransparentIndex.Value = CurEntry.ExtraData.TransparentColorIndex;
			nudDefaultPaletteID.Value = CurEntry.ExtraData.IntendedPaletteFileID;
			cbHorizMirror.Checked = CurEntry.ExtraData.HorizMirror;
			cbVertMirror.Checked = CurEntry.ExtraData.VertMirror;
		}

		/// <summary>
		/// OK button
		/// </summary>
		private void buttonOK_Click(object sender, EventArgs e)
		{
			// Main page
			CurEntry.FileType = (FileTypes)cbFileTypes.SelectedIndex;
			CurEntry.OverrideFileType = cbForceFileType.Checked;
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

			// Extra page
			if (nudImageWidth.Value > 0)
			{
				CurEntry.ExtraData.ImageWidth = (int)nudImageWidth.Value;
			}
			if (nudImageHeight.Value > 0)
			{
				CurEntry.ExtraData.ImageHeight = (int)nudImageHeight.Value;
			}
			if (nudTransparentIndex.Value >= 0)
			{
				CurEntry.ExtraData.TransparentColorIndex = (int)nudTransparentIndex.Value;
			}
			if (nudDefaultPaletteID.Value > 0)
			{
				CurEntry.ExtraData.IntendedPaletteFileID = (int)nudDefaultPaletteID.Value;
			}
			CurEntry.ExtraData.HorizMirror = cbHorizMirror.Checked;
			CurEntry.ExtraData.VertMirror = cbVertMirror.Checked;

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

			// Set filter based on (FileTypes)cbFileTypes.SelectedIndex
			switch ((FileTypes)cbFileTypes.SelectedIndex)
			{
				case FileTypes.Ci4Palette: ofd.Filter = SharedStrings.FileLoadFilter_PaletteCi4; break;
				case FileTypes.Ci8Palette: ofd.Filter = SharedStrings.FileLoadFilter_PaletteCi8; break;
				case FileTypes.Ci4Texture: ofd.Filter = SharedStrings.FileLoadFilter_TextureCi4; break;
				case FileTypes.Ci8Texture: ofd.Filter = SharedStrings.FileLoadFilter_TextureCi8; break;
				case FileTypes.AkiTexture: ofd.Filter = SharedStrings.FileLoadFilter_TextureAki; break;
				default: ofd.Filter = SharedStrings.FileFilter_None; break;
			}

			if (ofd.ShowDialog() == DialogResult.OK)
			{
				CurEntry.ReplaceFilePath = ofd.FileName;
				tbReplaceFilePath.Text = ofd.FileName;
			}
		}
	}
}
