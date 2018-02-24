using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Windows.Forms;

namespace VPWStudio
{
	public partial class FileTable_TexPreviewDialog : Form
	{
		#region Members
		/// <summary>
		/// Current TEX file
		/// </summary>
		private AkiTexture CurrentTEX;

		/// <summary>
		/// Current Bitmap
		/// </summary>
		private Bitmap CurrentBitmap;

		/// <summary>
		/// Default image size
		/// </summary>
		private Size DefaultImageSize;

		/// <summary>
		/// Current zoom level
		/// </summary>
		private int CurrentZoom = 1;
		#endregion

		#region Constants
		/// <summary>
		/// Minimum possible zoom level
		/// </summary>
		private const int MinZoom = 1;

		/// <summary>
		/// Maximum possible zoom level
		/// </summary>
		private const int MaxZoom = 3;
		#endregion

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
			this.DefaultImageSize = new Size(this.CurrentTEX.Width, this.CurrentTEX.Height);

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

		/// <summary>
		/// Zoom image.
		/// </summary>
		private void pbPreview_MouseWheel(object sender, MouseEventArgs e)
		{
			// e.Delta * SystemInformation.MouseWheelScrollLines / 120

			if (e.Delta == 120)
			{
				if (this.CurrentZoom < MaxZoom)
				{
					this.CurrentZoom++;
				}
				else
				{
					this.CurrentZoom = MaxZoom;
				}
			}
			else if (e.Delta == -120)
			{
				if (this.CurrentZoom > MinZoom)
				{
					this.CurrentZoom--;
				}
				else
				{
					this.CurrentZoom = MinZoom;
				}
			}
			DrawImage();
		}

		private void DrawImage()
		{
			Bitmap zoomed = new Bitmap(this.DefaultImageSize.Width * this.CurrentZoom, this.DefaultImageSize.Height * this.CurrentZoom);

			Graphics g = Graphics.FromImage(zoomed);
			g.InterpolationMode = InterpolationMode.NearestNeighbor;
			g.Clear(pbPreview.BackColor);

			g.DrawImage(
				CurrentBitmap,
				new Rectangle(0, 0, this.DefaultImageSize.Width * this.CurrentZoom, this.DefaultImageSize.Height * this.CurrentZoom),
				new Rectangle(0, 0, this.DefaultImageSize.Width, this.DefaultImageSize.Height),
				GraphicsUnit.Pixel
			);
			g.Dispose();
			pbPreview.Image = zoomed;
		}
	}
}
