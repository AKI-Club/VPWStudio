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
	public partial class TimTester : Form
	{
		/// <summary>
		/// List of TIM files.
		/// </summary>
		public List<TimFile> TimFiles;

		private int CurTimIndex = 0;

		/// <summary>
		/// Current TIM file being previewed.
		/// </summary>
		public TimFile CurrentTim;

		public ClutData ExternalClut = null;

		/// <summary>
		/// Current active palette number (only useful in 4bpp)
		/// </summary>
		public int CurPaletteNumber = 0;

		public int NumPalettes = 0;

		private StringBuilder InfoStringBuilder = new StringBuilder();

		public TimTester()
		{
			InitializeComponent();
			TimFiles = new List<TimFile>();
			CurTimIndex = 0;
		}

		private void loadTIMToolStripMenuItem_Click(object sender, EventArgs e)
		{
			OpenFileDialog ofd = new OpenFileDialog();
			ofd.Title = "Select TIM File";
			ofd.Filter = SharedStrings.FileLoadFilter_TextureTim;
			if (ofd.ShowDialog() == DialogResult.OK)
			{
				FileStream fs = new FileStream(ofd.FileName, FileMode.Open);
				BinaryReader br = new BinaryReader(fs);
				TimFiles = new List<TimFile>();
				CurTimIndex = 0;
				while (br.BaseStream.Position != br.BaseStream.Length)
				{
					TimFiles.Add(new TimFile(br));
				}
				br.Close();

				CurrentTim = TimFiles[CurTimIndex];
				pictureBox1.Image = CurrentTim.ToBitmap();

				nextPaletteToolStripMenuItem.Enabled = (TimFile.ImageFormat)(CurrentTim.Flags & TimFile.TIM_IMAGEFORMAT_MASK) == TimFile.ImageFormat.Clut4;
				previousPaletteToolStripMenuItem.Enabled = (TimFile.ImageFormat)(CurrentTim.Flags & TimFile.TIM_IMAGEFORMAT_MASK) == TimFile.ImageFormat.Clut4;
				if ((TimFile.ImageFormat)(CurrentTim.Flags & TimFile.TIM_IMAGEFORMAT_MASK) == TimFile.ImageFormat.Clut4)
				{
					if (ExternalClut != null)
					{
						NumPalettes = ExternalClut.DataHeight;
					}
					else
					{
						NumPalettes = CurrentTim.CLUT.DataHeight;
					}
				}

				nextTIMToolStripMenuItem.Enabled = TimFiles.Count > 1;
				previousTIMToolStripMenuItem.Enabled = TimFiles.Count > 1;
				UpdateStatusBar();
			}
		}

		private void UpdateStatusBar()
		{
			timStatusLabel.Text = String.Format("TIM {0}/{1}; Palette {2}/{3}", CurTimIndex+1,TimFiles.Count, CurPaletteNumber+1,NumPalettes);
		}

		private void UpdateTimPreview(int palNum = -1)
		{
			if (palNum != -1)
			{
				pictureBox1.Image = CurrentTim.ToBitmap(CurPaletteNumber);
			}
			else
			{
				pictureBox1.Image = CurrentTim.ToBitmap();
			}
		}

		#region CLUT/Palette menu
		private void nextPaletteToolStripMenuItem_Click(object sender, EventArgs e)
		{
			if (CurrentTim == null)
			{
				return;
			}

			CurPaletteNumber++;
			if (CurPaletteNumber >= NumPalettes)
			{
				CurPaletteNumber = 0;
			}
			UpdateTimPreview(CurPaletteNumber);
			UpdateStatusBar();
		}

		private void previousPaletteToolStripMenuItem_Click(object sender, EventArgs e)
		{
			if (CurrentTim == null)
			{
				return;
			}

			CurPaletteNumber--;
			if (CurPaletteNumber < 0)
			{
				CurPaletteNumber = NumPalettes-1;
			}
			UpdateTimPreview(CurPaletteNumber);
			UpdateStatusBar();
		}

		private void exportPaletteToolStripMenuItem_Click(object sender, EventArgs e)
		{
			if (CurrentTim == null)
			{
				return;
			}

			SaveFileDialog sfd = new SaveFileDialog();
			sfd.Title = "Export CLUT Palette";
			sfd.Filter = "VPW Studio Palette File (*.vpwspal)|*.vpwspal|All Files (*.*)|*.*";
			if (sfd.ShowDialog() == DialogResult.OK)
			{
				StreamWriter sw = new StreamWriter(sfd.FileName);
				CurrentTim.CLUT.ExportVpwsPal(sw);
				sw.Flush();
				sw.Close();
			}
		}
		#endregion

		private void TimTester_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Escape)
			{
				Close();
			}
		}

		private void infoToolStripMenuItem_Click(object sender, EventArgs e)
		{
			// show message box with TIM information
			if (CurrentTim == null)
			{
				Program.ErrorMessageBox("No TIM file loaded.");
				return;
			}

			InfoStringBuilder.Clear();

			InfoStringBuilder.AppendLine(String.Format("TIM image {0}/{1} information:",CurTimIndex+1,TimFiles.Count));

			TimFile.ImageFormat curFormat = (TimFile.ImageFormat)(CurrentTim.Flags & TimFile.TIM_IMAGEFORMAT_MASK);
			InfoStringBuilder.AppendLine(String.Format("  Texture Format: {0}", Enum.GetName(typeof(TimFile.ImageFormat), curFormat)));

			int pixWidth = 0;
			if (curFormat == TimFile.ImageFormat.Clut4)
			{
				pixWidth = CurrentTim.PixelWidth * 4;
			}
			else if (curFormat == TimFile.ImageFormat.Clut8)
			{
				pixWidth = CurrentTim.PixelWidth * 2;
			}
			else
			{
				// we're just going to ignore Direct24 here? ok
				pixWidth = CurrentTim.PixelWidth;
			}

			InfoStringBuilder.AppendLine(String.Format("  Texture Size: {0} x {1}", pixWidth, CurrentTim.PixelHeight));
			InfoStringBuilder.AppendLine(String.Format("  VRAM Position: {0} x {1}", CurrentTim.PixelXCoordinate, CurrentTim.PixelYCoordinate));

			if (CurrentTim.CLUT != null)
			{
				InfoStringBuilder.AppendLine();
				InfoStringBuilder.AppendLine("CLUT information:");
				InfoStringBuilder.AppendLine(String.Format("  Number of Palettes: {0}", NumPalettes));
				InfoStringBuilder.AppendLine(String.Format("  Colors in Palette: {0}", CurrentTim.CLUT.GetColors().Count));
				InfoStringBuilder.AppendLine(String.Format("  CLUT pixel size: {0} x {1}", CurrentTim.CLUT.DataWidth, CurrentTim.CLUT.DataHeight));
				InfoStringBuilder.Append(String.Format("  VRAM Position: {0} x {1}", CurrentTim.CLUT.XCoordinate, CurrentTim.CLUT.YCoordinate));
			}

			Program.InfoMessageBox(InfoStringBuilder.ToString());
		}

		/// <summary>
		/// View next TIM image in file
		/// </summary>
		private void nextTIMToolStripMenuItem_Click(object sender, EventArgs e)
		{
			CurTimIndex = CurTimIndex + 1;
			if (CurTimIndex > TimFiles.Count-1)
			{
				CurTimIndex = 0;
			}
			CurrentTim = TimFiles[CurTimIndex];
			CurPaletteNumber = 0;
			NumPalettes = CurrentTim.CLUT.DataHeight;
			UpdateTimPreview();
			UpdateStatusBar();
		}

		/// <summary>
		/// View previous TIM image in file
		/// </summary>
		private void previousTIMToolStripMenuItem_Click(object sender, EventArgs e)
		{

			CurTimIndex = CurTimIndex - 1;
			if (CurTimIndex < 0)
			{
				CurTimIndex = TimFiles.Count-1;
			}
			CurrentTim = TimFiles[CurTimIndex];
			CurPaletteNumber = 0;
			NumPalettes = CurrentTim.CLUT.DataHeight;
			UpdateTimPreview();
			UpdateStatusBar();
		}

		private void savePNGToolStripMenuItem_Click(object sender, EventArgs e)
		{
			if (CurrentTim == null)
			{
				Program.ErrorMessageBox("Nothing to save!");
				return;
			}

			SaveFileDialog sfd = new SaveFileDialog();
			sfd.Title = "Save PNG";
			sfd.Filter = "PNG Files (*.png)|*.png|All Files(*.*)|*.*";
			sfd.FileName = "tim_export.png";
			if (sfd.ShowDialog() == DialogResult.OK)
			{
				pictureBox1.Image.Save(sfd.FileName);
			}
		}

		private void exportToolStripMenuItem_Click(object sender, EventArgs e)
		{
			savePNGToolStripMenuItem_Click(sender, e);
		}
	}
}
