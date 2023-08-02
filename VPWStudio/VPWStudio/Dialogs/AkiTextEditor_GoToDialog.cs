using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VPWStudio
{
	/// <summary>
	/// Simple dialog for jumping to a specific entry in the AkiTextEditor form.
	/// </summary>
	public partial class AkiTextEditor_GoToDialog : Form
	{
		/// <summary>
		/// Destination index to jump to.
		/// </summary>
		public int DestinationEntry;

		public AkiTextEditor_GoToDialog(int maxEntryNum)
		{
			InitializeComponent();
			nudTextEntryID.Maximum = maxEntryNum;
		}

		private void buttonOK_Click(object sender, EventArgs e)
		{
			DestinationEntry = (int)nudTextEntryID.Value;
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
