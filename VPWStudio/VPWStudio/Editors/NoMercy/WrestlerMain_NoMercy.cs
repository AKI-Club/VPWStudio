using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using VPWStudio.GameSpecific.NoMercy;

namespace VPWStudio.Editors.NoMercy
{
	public partial class WrestlerMain_NoMercy : Form
	{
		public SortedList<int, WrestlerDefinition> WrestlerDefs = new SortedList<int, WrestlerDefinition>();

		private AkiText DefaultNames;

		public WrestlerMain_NoMercy()
		{
			InitializeComponent();

			LoadDefaultNames();
			LoadDefs_Rom(); // temporary
			PopulateList(); // not so temporary
		}

		/// <summary>
		/// Load default names AkiText entry
		/// </summary>
		private void LoadDefaultNames()
		{
			// default names are in file 0002
			MemoryStream romStream = new MemoryStream(Program.CurrentInputROM.Data);
			BinaryReader romReader = new BinaryReader(romStream);

			MemoryStream outStream = new MemoryStream();
			BinaryWriter outWriter = new BinaryWriter(outStream);

			Program.CurrentProject.ProjectFileTable.ExtractFile(romReader, outWriter, 0x0002);
			romReader.Close();

			outStream.Seek(0, SeekOrigin.Begin);
			BinaryReader outReader = new BinaryReader(outStream);
			DefaultNames = new AkiText(outReader);

			outReader.Close();
			outWriter.Close();
		}

		#region Load Wrestler Definitions
		private void LoadDefs_Rom()
		{
			// load from rom
			MemoryStream ms = new MemoryStream(Program.CurrentInputROM.Data);
			BinaryReader br = new BinaryReader(ms);

			bool hasLocation = false;
			if (Program.CurLocationFile != null)
			{
				LocationFileEntry wdEntry = Program.CurLocationFile.GetEntryFromComment(LocationFile.SpecialEntryStrings["WrestlerDefs"]);
				if (wdEntry != null)
				{
					br.BaseStream.Seek(wdEntry.Address, SeekOrigin.Begin);
					hasLocation = true;
				}
			}
			if (!hasLocation)
			{
				// fallback to hardedcoded offset
				Program.InfoMessageBox("Wrestler Definition location not found; using hardcoded offset instead.");
				// depends on game
				long offset = DefaultGameData.DefaultLocations[Program.CurrentProject.Settings.GameType].Locations["WrestlerDefs"].Offset;
				br.BaseStream.Seek(offset, SeekOrigin.Begin);
			}

			// xxx: default number of wrestler defs
			for (int i = 0; i < (0x40 * 4) + 0x25; i++)
			{
				WrestlerDefinition wdef = new WrestlerDefinition(br);
				WrestlerDefs.Add(i, wdef);
				//Program.CurrentProject.WrestlerDefs.Entries.Add(wdef);
			}

			br.Close();
		}

		private void LoadDefs_Project()
		{
			// load from project file
		}
		#endregion

		/// <summary>
		/// Populate the list of wrestler definitions
		/// </summary>
		private void PopulateList()
		{
			lbWrestlers.BeginUpdate();
			for (int i = 0; i < WrestlerDefs.Count; i++)
			{
				WrestlerDefinition wd = WrestlerDefs[i];
				if (wd.WrestlerID2 <= 0x40)
				{
					int costume = i % 4;
					lbWrestlers.Items.Add(String.Format("{0:X4}-{1} {2}", wd.WrestlerID4, costume, DefaultNames.Entries[wd.ProfileIndex + 1].Text));
				}
				else
				{
					lbWrestlers.Items.Add(String.Format("{0:X4}", wd.WrestlerID4));
				}
			}
			lbWrestlers.EndUpdate();
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="wdef"></param>
		private void LoadEntryData(WrestlerDefinition wdef)
		{
			tbWrestlerID4.Text = String.Format("{0:X4}", wdef.WrestlerID4);
			tbWrestlerID2.Text = String.Format("{0:X2}", wdef.WrestlerID2);
			cbThemeMusic.SelectedIndex = wdef.ThemeSong;
			cbEntranceVideo.SelectedIndex = wdef.EntranceVideo;
			tbHeight.Text = String.Format("{0:X2}", wdef.Height);
			tbUnknown.Text = String.Format("{0:X2}", wdef.Unknown);
			tbWeight.Text = String.Format("{0:X4}", wdef.Weight);
			tbMovesetIndex.Text = String.Format("{0:X4}", wdef.MovesetFileIndex);
			tbParamsIndex.Text = String.Format("{0:X4}", wdef.ParamsFileIndex);
			tbAppearanceIndex.Text = String.Format("{0:X4}", wdef.AppearanceIndex);
			tbProfileIndex.Text = String.Format("{0:X4}", wdef.ProfileIndex);
		}

		/// <summary>
		/// 
		/// </summary>
		private void lbWrestlers_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (lbWrestlers.SelectedIndex < 0)
			{
				return;
			}

			// load data
			LoadEntryData(WrestlerDefs[lbWrestlers.SelectedIndex]);
		}

		private void buttonMoveset_Click(object sender, EventArgs e)
		{
			if (lbWrestlers.SelectedIndex < 0)
			{
				return;
			}

			((MainForm)(MdiParent)).RequestHexViewer(this.WrestlerDefs[lbWrestlers.SelectedIndex].MovesetFileIndex);
		}

		private void buttonParams_Click(object sender, EventArgs e)
		{
			if (lbWrestlers.SelectedIndex < 0)
			{
				return;
			}

			((MainForm)(MdiParent)).RequestHexViewer(WrestlerDefs[lbWrestlers.SelectedIndex].ParamsFileIndex);
		}

		private void buttonAppearance_Click(object sender, EventArgs e)
		{
			if (lbWrestlers.SelectedIndex < 0)
			{
				return;
			}

			DefaultCostume_NoMercy dced = new DefaultCostume_NoMercy(WrestlerDefs[lbWrestlers.SelectedIndex].AppearanceIndex);
			dced.ShowDialog();
		}

		private void buttonProfile_Click(object sender, EventArgs e)
		{
			if (lbWrestlers.SelectedIndex < 0)
			{
				return;
			}

			// request AkiText viewer, index 2
			AkiTextEditor ate = new AkiTextEditor(2, WrestlerDefs[lbWrestlers.SelectedIndex].ProfileIndex);
			ate.ShowDialog();
		}
	}
}
