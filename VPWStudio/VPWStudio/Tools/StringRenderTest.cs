using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VPWStudio
{
	public partial class StringRenderTest : Form
	{
		public Bitmap StringPreview = new Bitmap(480, 240);

		public StringRenderTest()
		{
			InitializeComponent();
			pbStringPreview.Image = StringPreview;
		}

		public void RenderString()
		{
			// do stuff with tbPreviewText.Text

			// update StringPreview

			// update display
			pbStringPreview.Image = StringPreview;
		}

		private void tbPreviewText_TextChanged(object sender, EventArgs e)
		{
			RenderString(); // re-render
		}
	}
}
