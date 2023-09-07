using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;
using VPWStudio.GameSpecific;

namespace VPWStudio.Editors
{
	/// <summary>
	/// Stable Definition editor for WCW vs. nWo World Tour and Virtual Pro-Wrestling 64
	/// </summary>
	public partial class StableDefs_Early : Form
	{
		public SortedList<int, StableDef_Early> StableDefs = new SortedList<int, StableDef_Early>();

		private Dictionary<VPWGames, int> NumStables = new Dictionary<VPWGames, int>()
		{
			{ VPWGames.WorldTour, 6 },
			{ VPWGames.VPW64, 11 }
		};

		public StableDefs_Early()
		{
			InitializeComponent();

			if (!String.IsNullOrEmpty(Program.CurrentProject.Settings.StableDefinitionFilePath) &&
				File.Exists(Program.ConvertRelativePath(Program.CurrentProject.Settings.StableDefinitionFilePath))
			)
			{
				LoadData_File(Program.CurrentProject.Settings.StableDefinitionFilePath);
			}
			else
			{
				LoadData_ROM();
			}

			PopulateList();
		}

		private void LoadData_File(string _path)
		{
			StableDefFile sdf = new StableDefFile(Program.CurrentProject.Settings.BaseGame);
			FileStream fs = new FileStream(Program.ConvertRelativePath(_path), FileMode.Open);
			StreamReader sr = new StreamReader(fs);
			sdf.ReadFile(sr);
			sr.Close();
			StableDefs = sdf.StableDefs_Early;
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
			for (int i = 0; i < NumStables[Program.CurrentProject.Settings.BaseGame]; i++)
			{
				StableDef_Early sdef = new StableDef_Early(br);
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

		private void PopulateWrestlerList(StableDef_Early _sdef)
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
		public void LoadData(StableDef_Early _sdef)
		{
			tbWrestlerDefPointer.Text = String.Format("{0:X8}", _sdef.WrestlerPointerStart);
			tbWrestlerCount.Text = _sdef.NumWrestlers.ToString();
			tbChampTextPointer.Text = String.Format("{0:X8}", _sdef.ChampionshipPointerStart);
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

		private void buttonViewWrestler_Click(object sender, EventArgs e)
		{
			if (lbStables.SelectedIndex < 0)
			{
				return;
			}

			if (lbWresPointers.SelectedIndex < 0)
			{
				return;
			}
		}

		private void buttonMoveUp_Click(object sender, EventArgs e)
		{
			if (lbStables.SelectedIndex < 0)
			{
				return;
			}

			if (lbWresPointers.SelectedIndex <= 0)
			{
				return;
			}

			int newIndex = lbWresPointers.SelectedIndex - 1;
			uint oldWres = StableDefs[lbStables.SelectedIndex].WrestlerPointers[lbWresPointers.SelectedIndex - 1];
			uint moveWres = StableDefs[lbStables.SelectedIndex].WrestlerPointers[lbWresPointers.SelectedIndex];

			StableDefs[lbStables.SelectedIndex].WrestlerPointers[lbWresPointers.SelectedIndex - 1] = moveWres;
			StableDefs[lbStables.SelectedIndex].WrestlerPointers[lbWresPointers.SelectedIndex] = oldWres;

			PopulateWrestlerList(StableDefs[lbStables.SelectedIndex]);
			lbWresPointers.SelectedIndex = newIndex;
		}

		private void buttonMoveDown_Click(object sender, EventArgs e)
		{
			if (lbStables.SelectedIndex < 0)
			{
				return;
			}

			if (lbWresPointers.SelectedIndex < 0)
			{
				return;
			}

			// xxx: should this compare use the current stable's wrestler amount instead?
			if (lbWresPointers.SelectedIndex == lbWresPointers.Items.Count - 1)
			{
				return;
			}

			int newIndex = lbWresPointers.SelectedIndex + 1;
			uint oldWres = StableDefs[lbStables.SelectedIndex].WrestlerPointers[lbWresPointers.SelectedIndex + 1];
			uint moveWres = StableDefs[lbStables.SelectedIndex].WrestlerPointers[lbWresPointers.SelectedIndex];

			StableDefs[lbStables.SelectedIndex].WrestlerPointers[lbWresPointers.SelectedIndex + 1] = moveWres;
			StableDefs[lbStables.SelectedIndex].WrestlerPointers[lbWresPointers.SelectedIndex] = oldWres;

			PopulateWrestlerList(StableDefs[lbStables.SelectedIndex]);
			lbWresPointers.SelectedIndex = newIndex;
		}

		private void buttonSwitchGroup_Click(object sender, EventArgs e)
		{
			if (lbStables.SelectedIndex < 0)
			{
				return;
			}

			if (lbWresPointers.SelectedIndex < 0)
			{
				return;
			}

			MessageBox.Show("not implemented yet");
		}

		private void buttonSwapWrestler_Click(object sender, EventArgs e)
		{
			if (lbStables.SelectedIndex < 0)
			{
				return;
			}

			if (lbWresPointers.SelectedIndex < 0)
			{
				return;
			}

			MessageBox.Show("not implemented yet");
		}
	}
}
