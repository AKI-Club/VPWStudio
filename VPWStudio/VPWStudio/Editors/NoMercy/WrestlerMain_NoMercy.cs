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

		public Dictionary<SpecificGame, int> DefaultWrestlerDefOffsets = new Dictionary<SpecificGame, int>()
		{
			{ SpecificGame.NoMercy_NTSC_U_10, 0x46658 },
			{ SpecificGame.NoMercy_NTSC_U_11, 0x465B8 },
			{ SpecificGame.NoMercy_PAL_10, 0x46658 },
			{ SpecificGame.NoMercy_PAL_11, 0x464B8 },
		};

		public WrestlerMain_NoMercy()
		{
			InitializeComponent();

			LoadDefs_Rom(); // temporary
			PopulateList(); // not so temporary
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
				MessageBox.Show(
					"Wrestler Definition location not found; using hardcoded offset instead.",
					SharedStrings.MainForm_Title,
					MessageBoxButtons.OK,
					MessageBoxIcon.Information
				);
				// depends on game
				br.BaseStream.Seek(DefaultWrestlerDefOffsets[Program.CurrentProject.Settings.GameType], SeekOrigin.Begin);
			}

			// xxx: default number of wrestler defs
			for (int i = 0; i < (0x40 * 4) + 0x25; i++)
			{
				WrestlerDefinition wdef = new WrestlerDefinition(br);
				this.WrestlerDefs.Add(i, wdef);
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
			for (int i = 0; i < this.WrestlerDefs.Count; i++)
			{
				WrestlerDefinition wd = this.WrestlerDefs[i];
				if (wd.WrestlerID2 <= 0x40)
				{
					int costume = i % 4;
					lbWrestlers.Items.Add(String.Format("{0:X4}-{1}", wd.WrestlerID4, costume));
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
			//cbThemeMusic.SelectedIndex = wdef.ThemeSong;
			//titantron
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
			LoadEntryData(this.WrestlerDefs[lbWrestlers.SelectedIndex]);
		}

		private void buttonMoveset_Click(object sender, EventArgs e)
		{
			if (lbWrestlers.SelectedIndex < 0)
			{
				return;
			}

			((MainForm)(this.MdiParent)).RequestHexViewer(this.WrestlerDefs[lbWrestlers.SelectedIndex].MovesetFileIndex);
		}

		private void buttonParams_Click(object sender, EventArgs e)
		{
			if (lbWrestlers.SelectedIndex < 0)
			{
				return;
			}

			((MainForm)(this.MdiParent)).RequestHexViewer(this.WrestlerDefs[lbWrestlers.SelectedIndex].ParamsFileIndex);
		}
	}
}
