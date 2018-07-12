using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;
using VPWStudio.GameSpecific.WM2K;

namespace VPWStudio.Editors.WM2K
{
	public partial class StableDefs_WM2K : Form
	{
		private SortedList<int, StableDefinition> StableDefs = new SortedList<int, StableDefinition>();

		public StableDefs_WM2K()
		{
			InitializeComponent();

			// load stable definitions from WM2K ROM
			MemoryStream ms = new MemoryStream(Program.CurrentInputROM.Data);
			BinaryReader br = new BinaryReader(ms);

			bool hasLocation = false;
			if (Program.CurLocationFile != null)
			{
				LocationFileEntry sdEntry = Program.CurLocationFile.GetEntryFromComment(LocationFile.SpecialEntryStrings["StableDefs"]);
				if (sdEntry != null)
				{
					br.BaseStream.Seek(sdEntry.Address, SeekOrigin.Begin);
					hasLocation = true;
				}
			}
			if (!hasLocation)
			{
				// fallback to hardcoded offset
				Program.InfoMessageBox("Stable Definition location not found; using hardcoded offset instead.");
				br.BaseStream.Seek(DefaultGameData.DefaultLocations[Program.CurrentProject.Settings.GameType].Locations["StableDefs"].Offset, SeekOrigin.Begin);
			}

			// xxx: default number of stable defs
			for (int i = 0; i < 11; i++)
			{
				StableDefinition sdef = new StableDefinition(br);
				StableDefs.Add(i, sdef);
			}

			br.Close();

			PopulateList();
		}

		/// <summary>
		/// Populate the list of stables.
		/// </summary>
		private void PopulateList()
		{
			lbStables.BeginUpdate();
			for (int i = 0; i < this.StableDefs.Count; i++)
			{
				lbStables.Items.Add(i);
			}
			lbStables.EndUpdate();
		}

		public void LoadData(StableDefinition _sdef)
		{
			tbWrestlerDefPointer.Text = String.Format("{0:X8}", _sdef.WrestlerPointerStart);
			tbNumWrestlers.Text = String.Format("{0}", _sdef.NumWrestlers);
			tbNamePointer.Text = String.Format("{0:X8}", _sdef.StableNamePointer);
			tbStableName.Text = _sdef.StableName;

			lbWresID2s.Items.Clear();
			lbWresID2s.BeginUpdate();
			for (int i = 0; i < _sdef.NumWrestlers; i++)
			{
				if (_sdef.WrestlerID2s[i] != 0)
				{
					lbWresID2s.Items.Add(String.Format("{0:X2}", _sdef.WrestlerID2s[i]));
				}
			}
			lbWresID2s.EndUpdate();
		}

		private void lbStables_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (lbStables.SelectedIndex < 0)
			{
				return;
			}

			LoadData(StableDefs[lbStables.SelectedIndex]);
		}
	}
}
