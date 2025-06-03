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

		/// <summary>
		/// Default large font from the currently opened project.
		/// </summary>
		public AkiFont DefaultLargeFont;

		/// <summary>
		/// Default small font from the currently opened project.
		/// </summary>
		public AkiFont DefaultSmallFont;

		/// <summary>
		/// Externally loaded font.
		/// </summary>
		public AkiFont ExternalFont;

		private bool DefaultFontsAvailable;

		public StringRenderTest()
		{
			InitializeComponent();
			pbStringPreview.Image = StringPreview;

			// todo: font situation
			if (Program.CurrentProject == null)
			{
				// open file dialog (must be different from regular open file; if canceled, close form)
				DefaultFontsAvailable = false;
			}
			else
			{
				// load default large and small fonts
				DefaultLargeFont = new AkiFont(AkiFontType.AkiLargeFont, Program.CurrentProject.Settings.BaseGame);
				DefaultSmallFont = new AkiFont(AkiFontType.AkiSmallFont, Program.CurrentProject.Settings.BaseGame);
				ExternalFont = null;
				DefaultFontsAvailable = true;
			}
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

		private void largeFontToolStripMenuItem_Click(object sender, EventArgs e)
		{
			//AkiLargeFont
			if (!largeFontToolStripMenuItem.Checked)
			{
				largeFontToolStripMenuItem.Checked = true;
				smallFontToolStripMenuItem.Checked = false;
				// reload font
				// re-render
			}
		}

		private void smallFontToolStripMenuItem_Click(object sender, EventArgs e)
		{
			//AkiSmallFont
			if (!smallFontToolStripMenuItem.Checked)
			{
				smallFontToolStripMenuItem.Checked = true;
				largeFontToolStripMenuItem.Checked = false;
				// reload font
				// re-render
			}
		}

		private void openFontToolStripMenuItem_Click(object sender, EventArgs e)
		{
			OpenFileDialog ofd = new OpenFileDialog();
			ofd.Title = "Select Font File";
		}

		private void loadedFontToolStripMenuItem_Click(object sender, EventArgs e)
		{
			// if a font has been load it, use it
			// otherwise show the open dialog
		}
	}
}
