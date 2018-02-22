using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VPWStudio
{
	public partial class FileTable_TexPreviewDialog : Form
	{
		private AkiTexture CurrentTEX;
		private Bitmap CurrentBitmap;

		public FileTable_TexPreviewDialog(int fileID)
		{
			InitializeComponent();
			this.Text = String.Format("Preview [0x{0:X4}]",fileID);

			MemoryStream romStream = new MemoryStream(Program.CurrentInputROM.Data);
			BinaryReader romReader = new BinaryReader(romStream);

			MemoryStream outStream = new MemoryStream();
			BinaryWriter outWriter = new BinaryWriter(outStream);

			bool lzss = Program.CurrentProject.ProjectFileTable.Entries[fileID].IsEncoded;
			Program.CurrentProject.ProjectFileTable.ExtractFile(romReader, outWriter, fileID, lzss);
			romReader.Close();

			BinaryReader outReader = new BinaryReader(outStream);
			outStream.Seek(0, SeekOrigin.Begin);

			this.CurrentTEX = new AkiTexture(outReader);
			pbPreview.Width = this.CurrentTEX.Width;
			pbPreview.Height = this.CurrentTEX.Height;
			this.CurrentBitmap = this.CurrentTEX.ToBitmap();
			pbPreview.Image = this.CurrentBitmap;

			outReader.Close();
			outWriter.Close();
		}

		/// <summary>
		/// allow escape to exit.
		/// </summary>
		private void FileTable_TexPreviewDialog_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Escape)
			{
				this.Close();
			}
		}

		/// <summary>
		/// Save as PNG.
		/// </summary>
		private void savePNGToolStripMenuItem_Click(object sender, EventArgs e)
		{
			SaveFileDialog sfd = new SaveFileDialog();
			sfd.Title = "Save PNG";
			sfd.Filter = "PNG Files (*.png)|*.png|All Files(*.*)|*.*";
			if (sfd.ShowDialog() == DialogResult.OK)
			{
				this.CurrentBitmap.Save(sfd.FileName);
			}
		}
	}
}
