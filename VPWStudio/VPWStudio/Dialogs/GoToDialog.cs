using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VPWStudio
{
	/// <summary>
	/// Generic "Go To" dialog
	/// </summary>
	public partial class GoToDialog : Form
	{
		private Font HexFont = new Font("Consolas", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));

		public int TargetEntry = 0;

		public GoToDialog(int curNum, int maxNum, bool showHex)
		{
			InitializeComponent();
			nudEntry.Hexadecimal = showHex;

			if (showHex)
			{
				nudEntry.Font = HexFont;
			}

			nudEntry.Maximum = maxNum;
			if (curNum > maxNum)
			{
				curNum = maxNum;
			}
			nudEntry.Value = curNum;
			nudEntry.Select(0, curNum.ToString().Length);
		}

		private void btnCancel_Click(object sender, EventArgs e)
		{
			DialogResult = DialogResult.Cancel;
			Close();
		}

		private void btnOK_Click(object sender, EventArgs e)
		{
			DialogResult = DialogResult.OK;
			TargetEntry = (int)nudEntry.Value;
			Close();
		}
	}
}
