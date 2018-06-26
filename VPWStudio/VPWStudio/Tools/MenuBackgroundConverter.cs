using System;
using System.IO;
using System.Windows.Forms;

namespace VPWStudio
{
	public partial class MenuBackgroundConverter : Form
	{
		/// <summary>
		/// Path to input image file
		/// </summary>
		public string InputFile;

		/// <summary>
		/// Path for output binary files
		/// </summary>
		public string OutputDirectory;

		/// <summary>
		/// Game type for background conversion.
		/// </summary>
		public VPWGames GameType;

		public MenuBackgroundConverter()
		{
			InitializeComponent();
			cbTargetGame.SelectedIndex = 0;
			GameType = VPWGames.WM2K;
		}

		private void buttonOK_Click(object sender, EventArgs e)
		{
			// sanity checks
			if (tbImage.Equals(String.Empty))
			{
				Program.ErrorMessageBox("Must select an image to convert.");
				return;
			}

			if (tbOutputDir.Equals(String.Empty))
			{
				Program.ErrorMessageBox("Must select an output directory.");
				return;
			}

			if (cbTargetGame.SelectedIndex == 1)
			{
				GameType = VPWGames.VPW2;
			}
			InputFile = tbImage.Text;
			OutputDirectory = tbOutputDir.Text;

			DialogResult = DialogResult.OK;
			Close();
		}

		private void buttonCancel_Click(object sender, EventArgs e)
		{
			DialogResult = DialogResult.Cancel;
			Close();
		}

		private void buttonBrowseImage_Click(object sender, EventArgs e)
		{
			// browse for input image
			OpenFileDialog ofd = new OpenFileDialog();
			ofd.Title = "Select Input Image";
			if (ofd.ShowDialog() == DialogResult.OK)
			{
				InputFile = ofd.FileName;
				tbImage.Text = InputFile;
			}
		}

		private void buttonBrowseOutput_Click(object sender, EventArgs e)
		{
			// browse for output directory
			SaveFileDialog sfd = new SaveFileDialog();
			sfd.Title = "Select Output Directory";
			sfd.CheckFileExists = false;
			sfd.FileName = "(select directory)";
			if (sfd.ShowDialog() == DialogResult.OK)
			{
				OutputDirectory = Path.GetDirectoryName(sfd.FileName);
				tbOutputDir.Text = OutputDirectory;
			}
		}
	}
}
