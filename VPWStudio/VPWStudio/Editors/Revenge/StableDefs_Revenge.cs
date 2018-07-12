using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;
using VPWStudio.GameSpecific.Revenge;

namespace VPWStudio.Editors.Revenge
{
	public partial class StableDefs_Revenge : Form
	{
		private SortedList<int, StableDefinition> StableDefs = new SortedList<int, StableDefinition>();

		public StableDefs_Revenge()
		{
			InitializeComponent();

			// load stable definitions from Revenge ROM
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
			for (int i = 0; i < 13; i++)
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

		/// <summary>
		/// Load stable data.
		/// </summary>
		/// <param name="_sdef"></param>
		public void LoadData(StableDefinition _sdef)
		{
			tbWrestlerDefPointer.Text = String.Format("{0:X8}", _sdef.WrestlerPointerStart);
			tbNumWrestlers.Text = _sdef.NumWrestlers.ToString();
			tbHeaderGraphic.Text = String.Format("{0:X4}", _sdef.HeaderGraphicFile);

			lbWresPointers.Items.Clear();
			lbWresPointers.BeginUpdate();
			for (int i = 0; i < _sdef.NumWrestlers; i++)
			{
				lbWresPointers.Items.Add(String.Format("{0:X8}", _sdef.WrestlerPointers[i]));
			}
			lbWresPointers.EndUpdate();

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
			// handle both invalid index and "already at top of list"
			if (lbWresPointers.SelectedIndex <= 0)
			{
				return;
			}

			MessageBox.Show("not implemented yet");
		}

		/// <summary>
		/// Move wrestler down one slot
		/// </summary>
		private void buttonMoveDown_Click(object sender, EventArgs e)
		{
			if (lbWresPointers.SelectedIndex < 0)
			{
				return;
			}
			// xxx: should this compare use the current stable's wrestler amount instead?
			if (lbWresPointers.SelectedIndex == lbWresPointers.Items.Count - 1)
			{
				return;
			}

			MessageBox.Show("not implemented yet");
		}

		/// <summary>
		/// Switch a wrestler to another group.
		/// </summary>
		private void buttonSwitchGroup_Click(object sender, EventArgs e)
		{
			if (lbWresPointers.SelectedIndex < 0)
			{
				return;
			}

			MessageBox.Show("not implemented yet");
		}
		#endregion


	}
}
