using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Windows.Forms;

namespace VPWStudio
{
	public partial class ITexturePreviewDialog : Form
	{
		#region Members
		/// <summary>
		/// Current I4 texture file
		/// </summary>
		private I4Texture CurrentI4Tex;

		/// <summary>
		/// Current Bitmap
		/// </summary>
		private Bitmap CurrentBitmap;

		/// <summary>
		/// Default image size
		/// </summary>
		private Size DefaultImageSize;
		#endregion

		public ITexturePreviewDialog(int fileID)
		{
			InitializeComponent();
			LoadFileID(fileID);
		}

		public ITexturePreviewDialog(byte[] data)
		{
			InitializeComponent();
			LoadData(data);
		}

		/// <summary>
		/// Load ITexture from a File ID.
		/// </summary>
		/// <param name="fileID">File ID to load.</param>
		private void LoadFileID(int fileID)
		{
			if (Program.CurrentProject.ProjectFileTable.Entries[fileID].Comment != String.Empty)
			{
				Text = String.Format("Preview [0x{0:X4} - {1}]", fileID, Program.CurrentProject.ProjectFileTable.Entries[fileID].Comment);
			}
			else
			{
				Text = String.Format("Preview [0x{0:X4}]", fileID);
			}

			MemoryStream romStream = new MemoryStream(Program.CurrentInputROM.Data);
			BinaryReader romReader = new BinaryReader(romStream);

			MemoryStream outStream = new MemoryStream();
			BinaryWriter outWriter = new BinaryWriter(outStream);

			Program.CurrentProject.ProjectFileTable.ExtractFile(romReader, outWriter, fileID);
			romReader.Close();

			BinaryReader outReader = new BinaryReader(outStream);
			outStream.Seek(0, SeekOrigin.Begin);

			CurrentI4Tex = new I4Texture(outReader);
			pbPreview.Width = 16;
			pbPreview.Height = 16;
			DefaultImageSize = new Size(16, 16);

			pbPreview.Image = null;

			outReader.Close();
			outWriter.Close();

			if (Program.CurrentProject.ProjectFileTable.Entries[fileID].ExtraData.ImageWidth != -1 &&
				Program.CurrentProject.ProjectFileTable.Entries[fileID].ExtraData.ImageHeight != -1)
			{
				DefaultImageSize = new Size(
					Program.CurrentProject.ProjectFileTable.Entries[fileID].ExtraData.ImageWidth,
					Program.CurrentProject.ProjectFileTable.Entries[fileID].ExtraData.ImageHeight
				);
				nudWidth.Value = Program.CurrentProject.ProjectFileTable.Entries[fileID].ExtraData.ImageWidth;
				nudHeight.Value = Program.CurrentProject.ProjectFileTable.Entries[fileID].ExtraData.ImageHeight;
				buttonRedraw_Click(this, null);
			}
		}

		/// <summary>
		/// Load ITexture from data.
		/// </summary>
		/// <param name="data">Array of bytes to be treated as an ITexture.</param>
		private void LoadData(byte[] data)
		{
			MemoryStream ms = new MemoryStream(data);
			BinaryReader br = new BinaryReader(ms);

			CurrentI4Tex = new I4Texture(br);
			pbPreview.Width = 16;
			pbPreview.Height = 16;
			DefaultImageSize = new Size(16, 16);

			pbPreview.Image = null;
			br.Close();
		}

		/// <summary>
		/// allow escape to exit.
		/// </summary>
		private void FileTable_ITexturePreviewDialog_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Escape)
			{
				Close();
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
				CurrentBitmap.Save(sfd.FileName);
			}
		}

		/// <summary>
		/// Change background color.
		/// </summary>
		private void backgroundColorToolStripMenuItem_Click(object sender, EventArgs e)
		{
			ColorDialog cd = new ColorDialog();
			if (cd.ShowDialog() == DialogResult.OK)
			{
				pbPreview.BackColor = cd.Color;
				DrawImage();
			}
		}

		private void DrawImage()
		{
			Bitmap zoomed = new Bitmap(DefaultImageSize.Width, DefaultImageSize.Height);

			Graphics g = Graphics.FromImage(zoomed);
			g.InterpolationMode = InterpolationMode.NearestNeighbor;
			g.Clear(pbPreview.BackColor);

			g.DrawImage(
				CurrentBitmap,
				new Rectangle(0, 0, DefaultImageSize.Width, DefaultImageSize.Height),
				new Rectangle(0, 0, DefaultImageSize.Width, DefaultImageSize.Height),
				GraphicsUnit.Pixel
			);
			g.Dispose();
			pbPreview.Image = zoomed;
		}

		private void buttonRedraw_Click(object sender, EventArgs e)
		{
			DefaultImageSize = new Size((int)nudWidth.Value, (int)nudHeight.Value);
			try
			{
				// todo: resize window if texture is too big for the current preview
				CurrentBitmap = CurrentI4Tex.ToBitmap(DefaultImageSize.Width, DefaultImageSize.Height);
				DrawImage();
			}
			catch (Exception ex)
			{
				MessageBox.Show(String.Format("Error attempting to draw texture:\n{0}", ex.Message));
			}
		}

		private void nudWidth_Enter(object sender, EventArgs e)
		{
			nudWidth.Select(0, nudWidth.Value.ToString().Length);
		}

		private void nudHeight_Enter(object sender, EventArgs e)
		{
			nudHeight.Select(0, nudHeight.Value.ToString().Length);
		}
	}
}
