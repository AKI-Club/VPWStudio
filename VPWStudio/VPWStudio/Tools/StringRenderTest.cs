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
	// technically testing StringParser as well
	public partial class StringRenderTest : Form
	{
		/// <summary>
		/// Text preview, using the same internal framebuffer size as the games.
		/// </summary>
		public Bitmap StringPreview = new Bitmap(480, 240);

		public StringRenderTest()
		{
			InitializeComponent();
			pbStringPreview.Image = StringPreview;
		}

		/// <summary>
		/// despite the name, the actual rendering takes place in DataStructures/AKI/AkiFont.cs
		/// </summary>
		public void RenderString()
		{
			// parse the text and get the spans
			List<Helpers.StringSpan> Spans = new List<Helpers.StringSpan>();
			Spans = Helpers.StringParser.Parse(tbPreviewText.Text);

			// render each span

			// update StringPreview

			// update display
			pbStringPreview.Image = StringPreview;
		}

		/// <summary>
		/// you mean you're doing this on EVERY change?
		/// </summary>
		private void tbPreviewText_TextChanged(object sender, EventArgs e)
		{
			RenderString(); // re-render
		}

		private void StringRenderTest_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Escape)
			{
				Close();
			}
		}
	}
}
