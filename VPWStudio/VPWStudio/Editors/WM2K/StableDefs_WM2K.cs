using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;
using VPWStudio.GameSpecific.WM2K;

namespace VPWStudio.Editors.WM2K
{
	/// <summary>
	/// WrestleMania 2000 Stable Defintiions editor
	/// </summary>
	public partial class StableDefs_WM2K : Form
	{
		public SortedList<int, StableDefinition> StableDefs = new SortedList<int, StableDefinition>();

		public StableDefs_WM2K()
		{
			InitializeComponent();

			if (Program.CurrentProject.Settings.StableDefinitionFilePath != null &&
				Program.CurrentProject.Settings.StableDefinitionFilePath != String.Empty &&
				File.Exists(Program.ConvertRelativePath(Program.CurrentProject.Settings.StableDefinitionFilePath))
			)
			{
				// load stable definitions from external file
				StableDefFile sdf = new StableDefFile(VPWGames.WM2K);
				FileStream fs = new FileStream(Program.ConvertRelativePath(Program.CurrentProject.Settings.StableDefinitionFilePath), FileMode.Open);
				StreamReader sr = new StreamReader(fs);
				sdf.ReadFile(sr);
				sr.Close();
				StableDefs = sdf.StableDefs_WM2K;
			}
			else
			{
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
			}

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

		private void UpdateWrestlerList()
		{
			StableDefinition sdef = StableDefs[lbStables.SelectedIndex];

			lbWresID2s.Items.Clear();
			lbWresID2s.BeginUpdate();
			for (int i = 0; i < sdef.WrestlerID2s.Length; i++)
			{
				if (sdef.WrestlerID2s[i] != 0)
				{
					lbWresID2s.Items.Add(String.Format("{0:X2}", sdef.WrestlerID2s[i]));
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

		private void buttonMoveUp_Click(object sender, EventArgs e)
		{
			if (lbStables.SelectedIndex < 0)
			{
				return;
			}

			if (lbWresID2s.SelectedIndex <= 0)
			{
				return;
			}

			// swap 'em if you got 'em
			int newIndex = lbWresID2s.SelectedIndex - 1;
			byte oldWres = StableDefs[lbStables.SelectedIndex].WrestlerID2s[lbWresID2s.SelectedIndex - 1];
			byte moveWres = StableDefs[lbStables.SelectedIndex].WrestlerID2s[lbWresID2s.SelectedIndex];

			StableDefs[lbStables.SelectedIndex].WrestlerID2s[lbWresID2s.SelectedIndex - 1] = moveWres;
			StableDefs[lbStables.SelectedIndex].WrestlerID2s[lbWresID2s.SelectedIndex] = oldWres;

			UpdateWrestlerList();
			lbWresID2s.SelectedIndex = newIndex;
		}

		private void buttonMoveDown_Click(object sender, EventArgs e)
		{
			if (lbStables.SelectedIndex < 0)
			{
				return;
			}

			if (lbWresID2s.SelectedIndex < 0)
			{
				return;
			}

			// bottom of list
			if (lbWresID2s.SelectedIndex == lbWresID2s.Items.Count - 1)
			{
				return;
			}

			// swap 'em if you got 'em
			int newIndex = lbWresID2s.SelectedIndex + 1;
			byte oldWres = StableDefs[lbStables.SelectedIndex].WrestlerID2s[lbWresID2s.SelectedIndex + 1];
			byte moveWres = StableDefs[lbStables.SelectedIndex].WrestlerID2s[lbWresID2s.SelectedIndex];

			StableDefs[lbStables.SelectedIndex].WrestlerID2s[lbWresID2s.SelectedIndex + 1] = moveWres;
			StableDefs[lbStables.SelectedIndex].WrestlerID2s[lbWresID2s.SelectedIndex] = oldWres;

			UpdateWrestlerList();
			lbWresID2s.SelectedIndex = newIndex;
		}

		private void buttonSwitchGroup_Click(object sender, EventArgs e)
		{
			if (lbStables.SelectedIndex < 0 || lbWresID2s.SelectedIndex < 0)
			{
				return;
			}

			Program.ErrorMessageBox("what do you mean freem has to implement the same thing a third time?");
		}

		private void buttonSwapWres_Click(object sender, EventArgs e)
		{
			if (lbStables.SelectedIndex < 0 || lbWresID2s.SelectedIndex < 0)
			{
				return;
			}

			Program.ErrorMessageBox("well, if the other function doesn't work... what makes you think this will?");
		}
	}
}
