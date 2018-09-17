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
		public List<StoryModeTeam_Modern> StoryTeams = new List<StoryModeTeam_Modern>();

		/// <summary>
		/// Default Champions
		/// </summary>
		public byte[] DefaultChampions = new byte[5];

		public StoryMode_VPW2()
		{
			InitializeComponent();

			// 18x teams (Z64 0xDB4F0)
			MemoryStream romStream = new MemoryStream(Program.CurrentInputROM.Data);
			BinaryReader romReader = new BinaryReader(romStream);

			// xxx: hardcoded
			romStream.Seek(0xDB4F0, SeekOrigin.Begin);
			lbTeams.BeginUpdate();
			for (int i = 0; i < 18; i++)
			{
				StoryTeams.Add(new StoryModeTeam_Modern(romReader));
				lbTeams.Items.Add(String.Format("Team {0}", i));
			}
			lbTeams.EndUpdate();

			// 5x champions (Z64 0xDB544)
			// XXX: extremely hardcoded
			romStream.Seek(0xDB544, SeekOrigin.Begin);
			DefaultChampions = romReader.ReadBytes(5);

			tbTripleCrown.Text = String.Format("0x{0:X2}", DefaultChampions[0]);
			tbWorldTag1.Text = String.Format("0x{0:X2}", DefaultChampions[1]);
			tbAsiaTag1.Text = String.Format("0x{0:X2}", DefaultChampions[2]);
			tbWorldTag2.Text = String.Format("0x{0:X2}", DefaultChampions[3]);
			tbAsiaTag2.Text = String.Format("0x{0:X2}", DefaultChampions[4]);

			romReader.Close();
		}

		private void UpdateTeamValues()
		{
			StoryModeTeam_Modern curTeam = StoryTeams[lbTeams.SelectedIndex];
			tbWrestler1.Text = String.Format("0x{0:X2}", curTeam.WrestlerID2_1);
			tbWrestler2.Text = String.Format("0x{0:X2}", curTeam.WrestlerID2_2);
			tbUnknown.Text = String.Format("0x{0:X4}", curTeam.Unknown);
		}

		private void lbTeams_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (lbTeams.SelectedIndex < 0)
			{
				return;
			}
			UpdateTeamValues();
		}
	}
}
