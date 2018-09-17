using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using VPWStudio.GameSpecific;

namespace VPWStudio.Editors.VPW2
{
	public partial class StoryMode_VPW2 : Form
	{
		/// <summary>
		/// Story Mode teams
		/// </summary>
		public List<StoryModeTeam_Modern> StoryTeams;

		/// <summary>
		/// Default Champions
		/// </summary>
		public byte[] DefaultChampions = new byte[5];

		public StoryMode_VPW2()
		{
			InitializeComponent();

			// 18x teams (Z64 0xDB4F0)

			// 5x champions (Z64 0xDB544)
			// XXX: extremely hardcoded
			DefaultChampions[0] = Program.CurrentInputROM.Data[0xDB544];
			DefaultChampions[1] = Program.CurrentInputROM.Data[0xDB545];
			DefaultChampions[2] = Program.CurrentInputROM.Data[0xDB546];
			DefaultChampions[3] = Program.CurrentInputROM.Data[0xDB547];
			DefaultChampions[4] = Program.CurrentInputROM.Data[0xDB548];

			tbTripleCrown.Text = String.Format("0x{0:X2}", DefaultChampions[0]);
			tbWorldTag1.Text = String.Format("0x{0:X2}", DefaultChampions[1]);
			tbAsiaTag1.Text = String.Format("0x{0:X2}", DefaultChampions[2]);
			tbWorldTag2.Text = String.Format("0x{0:X2}", DefaultChampions[3]);
			tbAsiaTag2.Text = String.Format("0x{0:X2}", DefaultChampions[4]);
		}

		private void lbTeams_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (lbTeams.SelectedIndex < 0)
			{
				return;
			}

			// update values
		}
	}
}
