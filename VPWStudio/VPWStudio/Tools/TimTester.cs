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
		public TimFile CurrentTim;

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
			}
		}

		private void nextPaletteToolStripMenuItem_Click(object sender, EventArgs e)
		{

		}

		private void previousPaletteToolStripMenuItem_Click(object sender, EventArgs e)
		{

		}
	}
}
