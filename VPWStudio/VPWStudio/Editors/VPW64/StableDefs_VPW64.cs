﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;
using VPWStudio.GameSpecific;

namespace VPWStudio.Editors.VPW64
{
	public partial class StableDefs_VPW64 : Form
	{
		public SortedList<int, StableDef_Early> StableDefs = new SortedList<int, StableDef_Early>();

		public StableDefs_VPW64()
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
			StableDefFile sdf = new StableDefFile(VPWGames.VPW64);
			FileStream fs = new FileStream(Program.ConvertRelativePath(_path), FileMode.Open);
			StreamReader sr = new StreamReader(fs);
			sdf.ReadFile(sr);
			sr.Close();
			StableDefs = sdf.StableDefs_VPW64;
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
	}
}