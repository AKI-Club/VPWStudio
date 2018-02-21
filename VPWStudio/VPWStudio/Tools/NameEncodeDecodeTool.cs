using System;
using System.Windows.Forms;

namespace VPWStudio
{
	// this dialog is temporary
	public partial class NameEncodeDecodeTool : Form
	{
		public NameEncodeDecodeTool()
		{
			InitializeComponent();
		}

		/// <summary>
		/// Encode Long and Short names into a full name string.
		/// </summary>
		private void buttonEncode_Click(object sender, EventArgs e)
		{
			tbFull.Text = NameHandler.EncodeName(tbLong.Text, tbShort.Text);
		}

		/// <summary>
		/// Decode a full name string into Long and Short names.
		/// </summary>
		private void buttonDecode_Click(object sender, EventArgs e)
		{
			string[] result = NameHandler.DecodeName(tbFull.Text);
			tbLong.Text = result[0];
			tbShort.Text = result[1];
		}
	}
}
