using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Windows.Forms;

namespace VPWStudio
{
	public partial class TexPreviewDialog : Form
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

		/// <summary>
		/// File ID; only used for making a friendly filename on saving a PNG.
		/// </summary>
		private int FileID = 0;
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

		public TexPreviewDialog(int fileID)
		{
			InitializeComponent();
			LoadFileID(fileID);
		}

		/// <summary>
		/// Load TEX file from a File ID.
		/// </summary>
		/// <param name="fileID">File ID to load.</param>
		private void LoadFileID(int fileID)
		{
			FileID = fileID;
			Text = String.Format("Preview [0x{0:X4}]", FileID);

			MemoryStream romStream = new MemoryStream(Program.CurrentInputROM.Data);
			BinaryReader romReader = new BinaryReader(romStream);

			MemoryStream outStream = new MemoryStream();
			BinaryWriter outWriter = new BinaryWriter(outStream);

			Program.CurrentProject.ProjectFileTable.ExtractFile(romReader, outWriter, fileID);
			romReader.Close();

			BinaryReader outReader = new BinaryReader(outStream);
			outStream.Seek(0, SeekOrigin.Begin);

			CurrentTEX = new AkiTexture(outReader);
			pbPreview.Width = CurrentTEX.Width;
			pbPreview.Height = CurrentTEX.Height;
			DefaultImageSize = new Size(CurrentTEX.Width, CurrentTEX.Height);

			CurrentBitmap = CurrentTEX.ToBitmap();
			pbPreview.Image = CurrentBitmap;

			outReader.Close();
			outWriter.Close();
		}

		/// <summary>
		/// Load TEX file from data.
		/// </summary>
		/// <param name="data">Array of bytes to be treated as TEX file.</param>
		private void LoadData(byte[] data)
		{
			MemoryStream ms = new MemoryStream(data);
			BinaryReader br = new BinaryReader(ms);

			CurrentTEX = new AkiTexture(br);
			pbPreview.Width = CurrentTEX.Width;
			pbPreview.Height = CurrentTEX.Height;
			DefaultImageSize = new Size(CurrentTEX.Width, CurrentTEX.Height);

			CurrentBitmap = CurrentTEX.ToBitmap();
			pbPreview.Image = CurrentBitmap;

			br.Close();
		}

		/// <summary>
		/// allow escape to exit.
		/// </summary>
		private void FileTable_TexPreviewDialog_KeyDown(object sender, KeyEventArgs e)
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
			// suggest a filename based on FileID
			sfd.FileName = String.Format("{0:X4}.png", FileID);
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

		/// <summary>
		/// Zoom image.
		/// </summary>
		private void pbPreview_MouseWheel(object sender, MouseEventArgs e)
		{
			// e.Delta * SystemInformation.MouseWheelScrollLines / 120

			if (e.Delta == 120)
			{
				if (CurrentZoom < MaxZoom)
				{
					CurrentZoom++;
				}
				else
				{
					CurrentZoom = MaxZoom;
				}
			}
			else if (e.Delta == -120)
			{
				if (CurrentZoom > MinZoom)
				{
					CurrentZoom--;
				}
				else
				{
					CurrentZoom = MinZoom;
				}
			}
			DrawImage();
		}

		private void DrawImage()
		{
			Bitmap zoomed = new Bitmap(DefaultImageSize.Width * CurrentZoom, DefaultImageSize.Height * CurrentZoom);

			Graphics g = Graphics.FromImage(zoomed);
			g.InterpolationMode = InterpolationMode.NearestNeighbor;
			g.Clear(pbPreview.BackColor);

			g.DrawImage(
				CurrentBitmap,
				new Rectangle(0, 0, DefaultImageSize.Width * CurrentZoom, DefaultImageSize.Height * CurrentZoom),
				new Rectangle(0, 0, DefaultImageSize.Width, DefaultImageSize.Height),
				GraphicsUnit.Pixel
			);
			g.Dispose();
			pbPreview.Image = zoomed;
		}
	}
}
