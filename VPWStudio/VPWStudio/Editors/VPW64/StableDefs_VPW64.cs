using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;
using VPWStudio.GameSpecific.VPW64;

namespace VPWStudio.Editors.VPW64
{
	public partial class StableDefs_VPW64 : Form
	{
		public SortedList<int, StableDefinition> StableDefs = new SortedList<int, StableDefinition>();

		public StableDefs_VPW64()
		{
			InitializeComponent();

			// stable def file not yet handled
			LoadData_ROM();

			PopulateList();
		}

		private void LoadData_ROM()
		{
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

		private void PopulateWrestlerList(StableDefinition _sdef)
		{
			lbWresPointers.Items.Clear();
			lbWresPointers.BeginUpdate();
			for (int i = 0; i < _sdef.NumWrestlers; i++)
			{
				lbWresPointers.Items.Add(String.Format("{0:X8}", _sdef.WrestlerPointers[i]));
			}
			lbWresPointers.EndUpdate();
		}

		/// <summary>
		/// Load stable data.
		/// </summary>
		/// <param name="_sdef"></param>
		public void LoadData(StableDefinition _sdef)
		{
			tbWrestlerCount.Text = _sdef.NumWrestlers.ToString();
			tbChampTextPointer.Text = String.Format("{0:X8}", _sdef.ChampionshipTextPointer);
			tbChampionshipCount.Text = _sdef.NumChampionships.ToString();

			PopulateWrestlerList(_sdef);
		}

		private void lbStables_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (lbStables.SelectedIndex < 0)
			{
				return;
			}

			LoadData(StableDefs[lbStables.SelectedIndex]);
		}

		private void buttonOK_Click(object sender, EventArgs e)
		{
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
