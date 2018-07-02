using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using VPWStudio.GameSpecific.VPW2;

namespace VPWStudio.Editors.VPW2
{
	public partial class WrestlerMain_VPW2 : Form
	{
		public SortedList<int, WrestlerDefinition> WrestlerDefs = new SortedList<int, WrestlerDefinition>();
		public const int DefaultWrestlerDefOffset = 0x3FBE4;

		private AkiText DefaultNames;

		public WrestlerMain_VPW2()
		{
			InitializeComponent();

			LoadDefaultNames();
			LoadDefs_Rom(); // temporary
			PopulateList();
		}

		/// <summary>
		/// Load default names AkiText entry
		/// </summary>
		private void LoadDefaultNames()
		{
			// default names are in file 006C
			MemoryStream romStream = new MemoryStream(Program.CurrentInputROM.Data);
			BinaryReader romReader = new BinaryReader(romStream);

			MemoryStream outStream = new MemoryStream();
			BinaryWriter outWriter = new BinaryWriter(outStream);

			Program.CurrentProject.ProjectFileTable.ExtractFile(romReader, outWriter, 0x006C);
			romReader.Close();

			outStream.Seek(0, SeekOrigin.Begin);
			BinaryReader outReader = new BinaryReader(outStream);
			DefaultNames = new AkiText();
			DefaultNames.ReadData(outReader);

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
				br.BaseStream.Seek(DefaultWrestlerDefOffset, SeekOrigin.Begin);
			}

			// xxx: default number of wrestler defs
			for (int i = 0; i < 0x82; i++)
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
				// profile index + 1 = short name entry
				lbWrestlers.Items.Add(String.Format("{0:X4} {1}", wd.WrestlerID4, DefaultNames.Entries[wd.ProfileIndex+1].Text));
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
			// name call
			tbHeight.Text = String.Format("{0:X2}", wdef.Height);
			tbWeight.Text = String.Format("{0:X2}", wdef.Weight);
			cbVoiceA.SelectedIndex = wdef.Voice1;
			cbVoiceB.SelectedIndex = wdef.Voice2;
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

		private void buttonProfile_Click(object sender, EventArgs e)
		{
			if (lbWrestlers.SelectedIndex < 0)
			{
				return;
			}

			// request AkiText viewer, index 0x006C
			AkiTextEditor ate = new AkiTextEditor(0x006C, WrestlerDefs[lbWrestlers.SelectedIndex].ProfileIndex);
			ate.ShowDialog();
		}
	}
}
