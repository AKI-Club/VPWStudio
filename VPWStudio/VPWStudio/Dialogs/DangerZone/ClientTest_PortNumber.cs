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
	public partial class ClientTest_PortNumber : Form
	{
		/// <summary>
		/// Port number to use.
		/// </summary>
		public int PortNumber;

		public ClientTest_PortNumber(int port = -1)
		{
			InitializeComponent();
			if (port != -1)
			{
				nudPortNum.Value = port;
			}
			nudPortNum.Select(0, 5);
		}

		private void btnOK_Click(object sender, EventArgs e)
		{
			PortNumber = (int)nudPortNum.Value;
			DialogResult = DialogResult.OK;
			Close();
		}

		private void btnCancel_Click(object sender, EventArgs e)
		{
			DialogResult = DialogResult.Cancel;
			Close();
		}
	}
}
