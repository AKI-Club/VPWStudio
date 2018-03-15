using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VPWStudio.Editors
{
	public partial class FontDialog : Form
	{
		public AkiFont CurFont = new AkiFont();

		public FontDialog()
		{
			InitializeComponent();
		}

		private void PopulateCharacterList()
		{
			// todo: see if an AkiFontChars entry exists and use it
			// otherwise, we have to fall back. (this is OK for the non-japanese games...)

			lbCharacters.Items.Clear();
			lbCharacters.BeginUpdate();
			
			lbCharacters.EndUpdate();
		}

		private void lbCharacters_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (lbCharacters.SelectedIndex < 0)
			{
				return;
			}
		}
	}
}
