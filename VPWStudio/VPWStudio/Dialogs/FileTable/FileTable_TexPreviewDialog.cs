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

		public FileTable_TexPreviewDialog(int fileID)
		{
			InitializeComponent();

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
			pbPreview.Image = this.CurrentTEX.ToBitmap();
			this.Width = this.CurrentTEX.Width + 8;
			this.Height = this.CurrentTEX.Height + 32;

			outReader.Close();
			outWriter.Close();
		}
	}
}
