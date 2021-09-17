using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;
using VPWStudio.GameSpecific.VPW2;

namespace VPWStudio.Editors.VPW2
{
	/// <summary>
	/// VPW2 Stable Definitions editor
	/// </summary>
	public partial class StableDefs_VPW2 : Form
	{
		public SortedList<int, StableDefinition> StableDefs = new SortedList<int, StableDefinition>();

		private AkiText DefaultNames;

		private const UInt16 VPW2_DEFAULT_NAMES_FILE = 0x006C;

		public StableDefs_VPW2()
		{
			InitializeComponent();

			MemoryStream romStream = new MemoryStream(Program.CurrentInputROM.Data);
			BinaryReader romReader = new BinaryReader(romStream);

			// stable def file
			if (!String.IsNullOrEmpty(Program.CurrentProject.Settings.StableDefinitionFilePath) &&
				File.Exists(Program.ConvertRelativePath(Program.CurrentProject.Settings.StableDefinitionFilePath))
			){
				// load stable definitions from external file
				LoadData_File(Program.CurrentProject.Settings.StableDefinitionFilePath);
			}
			else
			{
				// load stable definitions from VPW2 ROM
				LoadData_ROM(romReader);
			}

			// default names
			string defNameReplacePath = Program.CurrentProject.ProjectFileTable.Entries[VPW2_DEFAULT_NAMES_FILE].ReplaceFilePath;
			if (!String.IsNullOrEmpty(defNameReplacePath))
			{
				// load from external file
				LoadDefaultNames_File(Program.ConvertRelativePath(defNameReplacePath));
			}
			else
			{
				// load from ROM
				LoadDefaultNames_ROM(romReader);
			}
			romReader.Close();
			PopulateList();
		}

		private void LoadData_File(string _path)
		{
			StableDefFile sdf = new StableDefFile(VPWGames.VPW2);
			FileStream fs = new FileStream(Program.ConvertRelativePath(_path), FileMode.Open);
			StreamReader sr = new StreamReader(fs);
			sdf.ReadFile(sr);
			sr.Close();
			StableDefs = sdf.StableDefs_VPW2;
		}

		private void LoadData_ROM(BinaryReader romReader)
		{
			bool hasLocation = false;
			if (Program.CurLocationFile != null)
			{
				LocationFileEntry sdEntry = Program.CurLocationFile.GetEntryFromComment(LocationFile.SpecialEntryStrings["StableDefs"]);
				if (sdEntry != null)
				{
					romReader.BaseStream.Seek(sdEntry.Address, SeekOrigin.Begin);
					hasLocation = true;
				}
			}
			if (!hasLocation)
			{
				// fallback to hardcoded offset
				Program.InfoMessageBox("Stable Definition location not found; using hardcoded offset instead.");
				romReader.BaseStream.Seek(DefaultGameData.DefaultLocations[SpecificGame.VPW2_NTSC_J].Locations["StableDefs"].Offset, SeekOrigin.Begin);
			}

			// xxx: default number of stable defs
			for (int i = 0; i < 17; i++)
			{
				StableDefinition sdef = new StableDefinition(romReader);
				StableDefs.Add(i, sdef);
			}
		}

		/// <summary>
		/// Load default names from external AkiText file.
		/// </summary>
		private void LoadDefaultNames_File(string _path)
		{
			FileStream fs = new FileStream(_path, FileMode.Open);
			BinaryReader br = new BinaryReader(fs);

			DefaultNames = new AkiText(br);

			br.Close();
		}

		/// <summary>
		/// Load default names from AkiText in ROM.
		/// </summary>
		private void LoadDefaultNames_ROM(BinaryReader romReader)
		{
			// default names are in file 006C
			MemoryStream outStream = new MemoryStream();
			BinaryWriter outWriter = new BinaryWriter(outStream);

			Program.CurrentProject.ProjectFileTable.ExtractFile(romReader, outWriter, VPW2_DEFAULT_NAMES_FILE);
			romReader.Close();

			outStream.Seek(0, SeekOrigin.Begin);
			BinaryReader outReader = new BinaryReader(outStream);
			DefaultNames = new AkiText(outReader);

			outReader.Close();
			outWriter.Close();
		}

		/// <summary>
		/// Populate the list of stables.
		/// </summary>
		private void PopulateList()
		{
			lbStables.BeginUpdate();
			for (int i = 0; i < StableDefs.Count; i++)
			{
				lbStables.Items.Add(string.Format("{0:X2} {1}",i,DefaultNames.Entries[(int)StableDefs[i].StableNameIndex].Text));
			}
			lbStables.EndUpdate();
		}

		public void LoadData(StableDefinition _sdef)
		{
			tbWrestlerDefPointer.Text = String.Format("{0:X8}", _sdef.WrestlerPointerStart);
			tbTextIndex.Text = String.Format("{0:X4}", _sdef.StableNameIndex);

			// get default stable name from AkiText
			tbStableName.Text = DefaultNames.Entries[(int)_sdef.StableNameIndex].Text;

			lbWresID2s.Items.Clear();
			lbWresID2s.BeginUpdate();
			for (int i = 0; i < _sdef.WrestlerID2s.Length; i++)
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

			int oldGroupNum = lbStables.SelectedIndex;
			int oldIndex = lbWresID2s.SelectedIndex;
			byte id2 = StableDefs[oldGroupNum].WrestlerID2s[oldIndex];
			SwitchGroup_VPW2 sg = new SwitchGroup_VPW2(id2, oldGroupNum, StableDefs);
			if (sg.ShowDialog() == DialogResult.OK)
			{
				// there are two things that need to be done here:
				// 1/easy: add the wrestler to the first empty slot of the new stable
				int newIndex = StableDefs[sg.NewStableNum].GetFirstEmptySlot();
				StableDefs[sg.NewStableNum].WrestlerID2s[newIndex] = id2;

				// 2/hard: remove the wrestler from the old stable and re-order list to remove the gap
				StableDefs[oldGroupNum].WrestlerID2s[oldIndex] = 0;

				// if the old index is the last item, we don't need to do anything
				if (oldIndex != StableDefs[oldGroupNum].WrestlerID2s.Length - 1)
				{
					// otherwise, we need to shift up all the entries after the old index
					for (int i = oldIndex; i < StableDefs[oldGroupNum].WrestlerID2s.Length-1; i++)
					{
						byte nextWres = StableDefs[oldGroupNum].WrestlerID2s[i + 1];
						StableDefs[oldGroupNum].WrestlerID2s[i] = nextWres;
						StableDefs[oldGroupNum].WrestlerID2s[i + 1] = 0;
					}
				}

				UpdateWrestlerList();
			}
		}

		private void buttonSwapWres_Click(object sender, EventArgs e)
		{
			if (lbStables.SelectedIndex < 0 || lbWresID2s.SelectedIndex < 0)
			{
				return;
			}

			// we need the first wrestler's stable and first wrestler's index within stable
			int stable1 = lbStables.SelectedIndex;
			int index1 = lbWresID2s.SelectedIndex;

			SwapWrestler_VPW2 sw = new SwapWrestler_VPW2(StableDefs, stable1, index1);
			if (sw.ShowDialog() == DialogResult.OK)
			{
				// swap wrestlers at stable1[index1] and stable2[index2]
				byte id2_first = StableDefs[stable1].WrestlerID2s[index1];
				StableDefs[stable1].WrestlerID2s[index1] = StableDefs[sw.Wrestler2_CurStable].WrestlerID2s[sw.Wrestler2_CurIndex];
				StableDefs[sw.Wrestler2_CurStable].WrestlerID2s[sw.Wrestler2_CurIndex] = id2_first;
				UpdateWrestlerList();
			}
		}
	}
}
