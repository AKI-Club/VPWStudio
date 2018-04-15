using System;
using System.Windows.Forms;

namespace VPWStudio.Controls
{
	public partial class OptionsControl_Emulator : UserControl
	{
		public OptionsControl_Emulator()
		{
			InitializeComponent();
		}

		private void buttonBrowse_Click(object sender, EventArgs e)
		{
			OpenFileDialog ofd = new OpenFileDialog();
			ofd.Title = "Select Emulator Executable";
			ofd.Filter = "Executable Files (*.exe)|*.exe|All Files (*.*)|*.*";
			if (ofd.ShowDialog() == DialogResult.OK)
			{
				tbEmuPath.Text = ofd.FileName;
			}
		}
	}
}
