using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;
using System.Windows.Forms;

namespace VPWStudio
{
	public partial class RomSliceDialog : Form
	{
		/// <summary>
		/// Starting offset
		/// </summary>
		public int StartOffset;

		/// <summary>
		/// Either the length to grab or the endpoint.
		/// </summary>
		public int EndValue;

		/// <summary>
		/// True if the end value is an offset instead of length.
		/// </summary>
		public bool EndValueIsOffset = true;

		public RomSliceDialog()
		{
			InitializeComponent();
		}

		private void buttonOK_Click(object sender, EventArgs e)
		{
			// try some shit
			if (tbStartAddr.Text == String.Empty)
			{
				Program.ErrorMessageBox("How do you expect me to work without a start point?");
				return;
			}

			if (tbStartAddr.Text == String.Empty)
			{
				Program.ErrorMessageBox("I'm also going to need either an endpoint or length.");
				return;
			}

			if (!int.TryParse(tbStartAddr.Text, NumberStyles.HexNumber, null, out StartOffset))
			{
				Program.ErrorMessageBox("Couldn't parse the start offset as a hex value.");
				return;
			}

			if (!int.TryParse(tbEndValue.Text, NumberStyles.HexNumber, null, out EndValue))
			{
				Program.ErrorMessageBox("Couldn't parse the end offset/length as a hex value.");
				return;
			}

			EndValueIsOffset = rbEndOffset.Checked;

			DialogResult = DialogResult.OK;
			Close();
		}

		private void buttonCancel_Click(object sender, EventArgs e)
		{
			DialogResult = DialogResult.Cancel;
			Close();
		}
	}
}
