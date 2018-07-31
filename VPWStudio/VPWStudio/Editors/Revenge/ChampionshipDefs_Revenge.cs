using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using VPWStudio.GameSpecific.Revenge;

namespace VPWStudio.Editors.Revenge
{
	public partial class ChampionshipDefs_Revenge : Form
	{
		public List<ChampionshipDefinition> Championships = new List<ChampionshipDefinition>();

		private string[] ChampionshipNames = new string[]
		{
			"US Heavyweight",
			"Cruiserweight",
			"Tag Team",
			"World Heavyweight",
			"TV Title"
		};

		public ChampionshipDefs_Revenge()
		{
			InitializeComponent();
			LoadData();

			cbChampionships.BeginUpdate();
			for (int i = 0; i < Championships.Count; i++)
			{
				cbChampionships.Items.Add(String.Format("Championship {0}: {1}", i+1, ChampionshipNames[i]));
			}
			cbChampionships.EndUpdate();
			cbChampionships.SelectedIndex = 0;
		}

		private void LoadData()
		{
			MemoryStream ms = new MemoryStream(Program.CurrentInputROM.Data);
			BinaryReader br = new BinaryReader(ms);

			bool hasLocation = false;
			if (Program.CurLocationFile != null)
			{
				LocationFileEntry sdEntry = Program.CurLocationFile.GetEntryFromComment(LocationFile.SpecialEntryStrings["ChampionshipDefs"]);
				if (sdEntry != null)
				{
					br.BaseStream.Seek(sdEntry.Address, SeekOrigin.Begin);
					hasLocation = true;
				}
			}
			if (!hasLocation)
			{
				// fallback to hardcoded offset
				Program.InfoMessageBox("Championship Definition location not found; using hardcoded offset instead.");
				br.BaseStream.Seek(DefaultGameData.DefaultLocations[Program.CurrentProject.Settings.GameType].Locations["ChampionshipDefs"].Offset, SeekOrigin.Begin);
			}

			// read data
			// xxx: default number of championship defs
			for (int i = 0; i < 5; i++)
			{
				ChampionshipDefinition cdef = new ChampionshipDefinition(br);
				Championships.Add(cdef);
			}

			br.Close();
		}

		private void UpdateDisplay()
		{
			ChampionshipDefinition cdef = Championships[cbChampionships.SelectedIndex];
			tbIdentifier.Text = String.Format("0x{0:X2}", cdef.Identifier);
			tbUnknown1.Text = String.Format("0x{0:X2}", cdef.Unknown1);
			tbChampID2_1.Text = String.Format("0x{0:X2}", cdef.ID2_Champion1);
			tbChampID2_2.Text = String.Format("0x{0:X2}", cdef.ID2_Champion2);
			tbUnknown2.Text = String.Format("0x{0:X2}", cdef.ID2_Defense1);
			tbUnknown3.Text = String.Format("0x{0:X2}", cdef.ID2_Defense2);
			tbFlags1.Text = String.Format("0x{0:X2}", cdef.Flags1);
			tbFlags2.Text = String.Format("0x{0:X2}", cdef.Flags2);
			tbUnknown4.Text = String.Format("0x{0:X2}", cdef.Unknown4);
			tbUnknown5.Text = String.Format("0x{0:X2}", cdef.Unknown5);
			tbUnknown6.Text = String.Format("0x{0:X4}", cdef.Unknown6);
			tbUnknown7.Text = String.Format("0x{0:X4}", cdef.Unknown7);
			tbUnknown8.Text = String.Format("0x{0:X4}", cdef.Unknown8);
			tbRosterPointer.Text = String.Format("0x{0:X8}", cdef.RosterPointer);

			// roster
			lbRoster.Items.Clear();
			lbRoster.BeginUpdate();
			for (int i = 0; i < cdef.RosterID2s.Count; i++)
			{
				lbRoster.Items.Add(String.Format("{0:X2}", cdef.RosterID2s[i]));
			}
			lbRoster.EndUpdate();
		}

		private void cbChampionships_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (cbChampionships.SelectedIndex < 0)
			{
				return;
			}

			UpdateDisplay();
		}
	}
}
