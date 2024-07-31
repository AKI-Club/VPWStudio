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
	public partial class SplitModelTest : Form
	{
		public SplitModelTest()
		{
			InitializeComponent();
		}

		private void btnVertexFile_Click(object sender, EventArgs e)
		{
			OpenFileDialog ofd = new OpenFileDialog();
			ofd.Title = "Select Vertex File";
			if (ofd.ShowDialog() == DialogResult.OK)
			{
				tbVertexFile.Text = ofd.FileName;
			}
		}

		private void btnFaceFile_Click(object sender, EventArgs e)
		{
			OpenFileDialog ofd = new OpenFileDialog();
			ofd.Title = "Select Face File";
			if (ofd.ShowDialog() == DialogResult.OK)
			{
				tbFaceFile.Text = ofd.FileName;
			}
		}

		private void btnConvert_Click(object sender, EventArgs e)
		{
			// validate file entries
			if (!File.Exists(tbVertexFile.Text))
			{
				Program.ErrorMessageBox("Vertex file must exist");
				return;
			}

			if (!File.Exists(tbFaceFile.Text))
			{
				Program.ErrorMessageBox("Face file must exist");
				return;
			}

			SaveFileDialog sfd = new SaveFileDialog();
			sfd.Title = "Export Wavefront OBJ";
			sfd.Filter = "Wavefront OBJ Files (*.obj)|*.obj|All Files (*.*)|*.*";
			if (sfd.ShowDialog() == DialogResult.OK)
			{
				SplitModel model = new SplitModel(tbVertexFile.Text, tbFaceFile.Text);
				StreamWriter sw = new StreamWriter(sfd.FileName);
				model.WriteWavefrontObj(sw);
				sw.Close();
			}
		}
	}
}
