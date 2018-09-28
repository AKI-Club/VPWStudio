using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VPWStudio.Editors.WM2K
{
	public partial class Entrance_WM2K : Form
	{


		public Entrance_WM2K()
		{
			InitializeComponent();
		}

		private void LoadData()
		{
		}

		private void cbEntrances_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (cbEntrances.SelectedIndex < 0)
			{
				return;
			}
		}

		private void UpdateDisplay()
		{
		}
	}
}
