using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;
using VPWStudio.GameSpecific.Revenge;

namespace VPWStudio.Editors.Revenge
{
	public partial class StableDefs_Revenge : Form
	{
		public SortedList<int, StableDefinition> StableDefs = new SortedList<int, StableDefinition>();

		public StableDefs_Revenge()
		{
			InitializeComponent();

			// stable def file
			if (!String.IsNullOrEmpty(Program.CurrentProject.Settings.StableDefinitionFilePath) &&
				File.Exists(Program.ConvertRelativePath(Program.CurrentProject.Settings.StableDefinitionFilePath))
			)
			{
				// load stable definitions from external file
				LoadData_File(Program.CurrentProject.Settings.StableDefinitionFilePath);
			}
			else
			{
				// load stable definitions from Revenge ROM
				LoadData_ROM();
			}

			PopulateList();
		}

		private void LoadData_File(string _path)
		{
			StableDefFile sdf = new StableDefFile(VPWGames.Revenge);
			FileStream fs = new FileStream(Program.ConvertRelativePath(_path), FileMode.Open);
			StreamReader sr = new StreamReader(fs);
			sdf.ReadFile(sr);
			sr.Close();
			StableDefs = sdf.StableDefs_Revenge;
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

			for (int i = 0; i < DefaultGameData.StableCount[VPWGames.Revenge]; i++)
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
			tbWrestlerDefPointer.Text = String.Format("{0:X8}", _sdef.WrestlerPointerStart);
			tbNumWrestlers.Text = _sdef.NumWrestlers.ToString();
			tbHeaderGraphic.Text = String.Format("{0:X4}", _sdef.HeaderGraphicFile);

			PopulateWrestlerList(_sdef);

			// try loading stable header graphic
			MemoryStream romStream = new MemoryStream(Program.CurrentInputROM.Data);
			BinaryReader romReader = new BinaryReader(romStream);

			MemoryStream outStream = new MemoryStream();
			BinaryWriter outWriter = new BinaryWriter(outStream);

			Program.CurrentProject.ProjectFileTable.ExtractFile(romReader, outWriter, _sdef.HeaderGraphicFile);
			romReader.Close();

			BinaryReader outReader = new BinaryReader(outStream);
			outStream.Seek(0, SeekOrigin.Begin);

			AkiTexture stableHeader = new AkiTexture(outReader);
			outReader.Close();
			outWriter.Close();

			pbHeaderGraphic.Image = stableHeader.ToBitmap();
		}

		/// <summary>
		/// Selected new stable
		/// </summary>
		private void lbStables_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (lbStables.SelectedIndex < 0)
			{
				return;
			}

			LoadData(StableDefs[lbStables.SelectedIndex]);
		}

		#region Buttons
		/// <summary>
		/// View WrestlerDefinition data
		/// </summary>
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

			MessageBox.Show("not implemented yet");
		}

		/// <summary>
		/// Move wrestler up one slot
		/// </summary>
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

		/// <summary>
		/// Move wrestler down one slot
		/// </summary>
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

		/// <summary>
		/// Switch a wrestler to another group.
		/// </summary>
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

			/*
			int oldGroupNum = lbStables.SelectedIndex;
			int oldIndex = lbWresPointers.SelectedIndex;
			uint wresPtr = StableDefs[oldGroupNum].WrestlerPointers[oldIndex];
			SwitchGroup_Revenge sg = new SwitchGroup_Revenge(wresPtr, oldGroupNum, StableDefs);
			if (sg.ShowDialog() == DialogResult.OK)
			{
				// add the wrestler to the first empty slot of the new stable
				int newIndex = StableDefs[sg.NewStableNum].GetFirstEmptySlot();
				StableDefs[sg.NewStableNum].WrestlerPointers[newIndex] = wresPtr;

				// increment the wrestler count in the new stable
				StableDefs[sg.NewStableNum].NumWrestlers++;

				// 3: remove the wrestler from the old stable and re-order list to remove the gap
				StableDefs[oldGroupNum].WrestlerPointers[oldIndex] = 0;

				// if the old index is the last item, we don't need to do anything
				if (oldIndex != StableDefs[oldGroupNum].WrestlerPointers.Length - 1)
				{
					// otherwise, we need to shift up all the entries after the old index
					for (int i = oldIndex; i < StableDefs[oldGroupNum].WrestlerPointers.Length - 1; i++)
					{
						uint nextWres = StableDefs[oldGroupNum].WrestlerPointers[i + 1];
						StableDefs[oldGroupNum].WrestlerPointers[i] = nextWres;
						StableDefs[oldGroupNum].WrestlerPointers[i + 1] = 0;
					}
				}

				// decrement the wrestler count in the old stable.
				StableDefs[oldGroupNum].NumWrestlers--;

				PopulateWrestlerList(StableDefs[lbStables.SelectedIndex]);
			}
			*/

			MessageBox.Show("not implemented yet");
		}

		/// <summary>
		/// Swap two wrestlers.
		/// </summary>
		private void buttonSwapWres_Click(object sender, EventArgs e)
		{
			if (lbStables.SelectedIndex < 0)
			{
				return;
			}

			if (lbWresPointers.SelectedIndex < 0)
			{
				return;
			}

			// we need the first wrestler's stable and first wrestler's index within stable
			int stable1 = lbStables.SelectedIndex;
			int index1 = lbWresPointers.SelectedIndex;
			SwapWrestler_Revenge sw = new SwapWrestler_Revenge(StableDefs, stable1, index1);
			if (sw.ShowDialog() == DialogResult.OK)
			{
				// swap wrestlers at stable1[index1] and stable2[index2]
				uint ptr_first = StableDefs[stable1].WrestlerPointers[index1];
				StableDefs[stable1].WrestlerPointers[index1] = StableDefs[sw.Wrestler2_CurStable].WrestlerPointers[sw.Wrestler2_CurIndex];
				StableDefs[sw.Wrestler2_CurStable].WrestlerPointers[sw.Wrestler2_CurIndex] = ptr_first;
				PopulateWrestlerList(StableDefs[lbStables.SelectedIndex]);
			}
		}
		#endregion

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
