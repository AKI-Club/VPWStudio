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
		/// Current TIM file being previewed.
		/// </summary>
		public TimFile CurrentTim;

		public ClutData ExternalClut = null;

		/// <summary>
		/// Current active palette number (only useful in 4bpp)
		/// </summary>
		public int CurPaletteNumber = 0;

		public int NumPalettes = 0;

		public TimTester()
		{
			InitializeComponent();
		}

		private void loadTIMToolStripMenuItem_Click(object sender, EventArgs e)
		{
			OpenFileDialog ofd = new OpenFileDialog();
			ofd.Title = "Select TIM File";
			ofd.Filter = "TIM File (*.tim)|*.tim|All Files (*.*)|*.*";
			if (ofd.ShowDialog() == DialogResult.OK)
			{
				FileStream fs = new FileStream(ofd.FileName, FileMode.Open);
				BinaryReader br = new BinaryReader(fs);
				CurrentTim = new TimFile(br);
				pictureBox1.Image = CurrentTim.ToBitmap();

				nextPaletteToolStripMenuItem.Enabled = (TimFile.ImageFormat)(CurrentTim.Flags & 7) == TimFile.ImageFormat.Clut4;
				previousPaletteToolStripMenuItem.Enabled = (TimFile.ImageFormat)(CurrentTim.Flags & 7) == TimFile.ImageFormat.Clut4;
				if ((TimFile.ImageFormat)(CurrentTim.Flags & 7) == TimFile.ImageFormat.Clut4)
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
			}
		}

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
			pictureBox1.Image = CurrentTim.ToBitmap(CurPaletteNumber);
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
			pictureBox1.Image = CurrentTim.ToBitmap(CurPaletteNumber);
		}
	}
}
