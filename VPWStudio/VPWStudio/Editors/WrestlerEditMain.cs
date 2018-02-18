using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VPWStudio
{
	public partial class WrestlerEditMain : Form
	{
		private SortedList<int, GameSpecific.IWrestlerDefinition> WrestlerDefs = new SortedList<int, GameSpecific.IWrestlerDefinition>();

		private UserControl WrestlerEditControl;

		public WrestlerEditMain()
		{
			InitializeComponent();

			if (Program.CurrentProject != null)
			{
				switch (Program.CurrentProject.Settings.BaseGame)
				{
					/*
					case VPWGames.WorldTour:
						LoadDefs_WorldTour();
						break;
					case VPWGames.VPW64:
						LoadDefs_VPW64();
						break;
					case VPWGames.Revenge:
						LoadDefs_Revenge();
						break;
					case VPWGames.WM2K:
						LoadDefs_WM2K();
						break;
					*/
					case VPWGames.VPW2:
						LoadDefs_VPW2();
						InfoDump_VPW2();
						Setup_VPW2();
						break;
					case VPWGames.NoMercy:
						LoadDefs_NoMercy();
						InfoDump_NoMercy();
						Setup_NoMercy();
						break;
					default:
						MessageBox.Show(String.Format("Wrestler Definition loading for {0} not yet implemented.", Program.CurrentProject.Settings.BaseGame));
						break;
				}
				SetControlStatus();
			}
		}

		#region WCW vs. nWo World Tour
		/// <summary>
		/// Load WrestlerDefinition data from WCW vs. nWo World Tour
		/// </summary>
		private void LoadDefs_WorldTour()
		{
			MemoryStream ms = new MemoryStream(Program.CurrentInputROM.Data);
			BinaryReader br = new BinaryReader(ms);

			bool hasLocation = false;
			if (Program.CurLocationFile != null)
			{
				if (Program.CurLocationFile.WrestlerDefs != null)
				{
					br.BaseStream.Seek(Program.CurLocationFile.WrestlerDefs.Address, SeekOrigin.Begin);
					hasLocation = true;
				}
			}
			if (!hasLocation)
			{
				switch (Program.CurrentProject.Settings.GameType)
				{
					case SpecificGame.WorldTour_NTSC_U_10:
						break;
					case SpecificGame.WorldTour_NTSC_U_11:
						break;
					case SpecificGame.WorldTour_PAL:
						break;
				}
			}

			br.Close();
		}
		#endregion

		#region Virtual Pro-Wrestling 64
		/// <summary>
		/// Load WrestlerDefinition data from Virtual Pro-Wrestling 64.
		/// </summary>
		private void LoadDefs_VPW64()
		{
			MemoryStream ms = new MemoryStream(Program.CurrentInputROM.Data);
			BinaryReader br = new BinaryReader(ms);

			bool hasLocation = false;
			if (Program.CurLocationFile != null)
			{
				if (Program.CurLocationFile.WrestlerDefs != null)
				{
					br.BaseStream.Seek(Program.CurLocationFile.WrestlerDefs.Address, SeekOrigin.Begin);
					hasLocation = true;
				}
			}
			if (!hasLocation)
			{
				// only one possible place
			}

			br.Close();
		}
		#endregion

		#region WCW/nWo Revenge
		/// <summary>
		/// Load WrestlerDefinition data from WCW/nWo Revenge.
		/// </summary>
		private void LoadDefs_Revenge()
		{
			MemoryStream ms = new MemoryStream(Program.CurrentInputROM.Data);
			BinaryReader br = new BinaryReader(ms);

			bool hasLocation = false;
			if (Program.CurLocationFile != null)
			{
				if (Program.CurLocationFile.WrestlerDefs != null)
				{
					br.BaseStream.Seek(Program.CurLocationFile.WrestlerDefs.Address, SeekOrigin.Begin);
					hasLocation = true;
				}
			}
			if (!hasLocation)
			{
				switch (Program.CurrentProject.Settings.GameType)
				{
					case SpecificGame.Revenge_NTSC_U:
						break;
					case SpecificGame.Revenge_PAL:
						break;
				}
			}

			br.Close();
		}
		#endregion

		#region WWF WrestleMania 2000
		/// <summary>
		/// Load WrestlerDefinition data from WWF WrestleMania 2000.
		/// </summary>
		private void LoadDefs_WM2K()
		{
			MemoryStream ms = new MemoryStream(Program.CurrentInputROM.Data);
			BinaryReader br = new BinaryReader(ms);

			bool hasLocation = false;
			if (Program.CurLocationFile != null)
			{
				if (Program.CurLocationFile.WrestlerDefs != null)
				{
					br.BaseStream.Seek(Program.CurLocationFile.WrestlerDefs.Address, SeekOrigin.Begin);
					hasLocation = true;
				}
			}
			if (!hasLocation)
			{
				switch (Program.CurrentProject.Settings.GameType)
				{
					case SpecificGame.WM2K_NTSC_U:
						break;
					case SpecificGame.WM2K_NTSC_J:
						break;
					case SpecificGame.WM2K_PAL:
						break;
				}
			}

			br.Close();
		}
		#endregion

		#region Virtual Pro-Wrestling 2
		/// <summary>
		/// Load WrestlerDefinition data from Virtual Pro-Wrestling 2.
		/// </summary>
		private void LoadDefs_VPW2()
		{
			// todo: if the project has valid WrestlerDefs, use those instead of grabbing from ROM

			MemoryStream ms = new MemoryStream(Program.CurrentInputROM.Data);
			BinaryReader br = new BinaryReader(ms);

			bool hasLocation = false;
			if (Program.CurLocationFile != null)
			{
				if (Program.CurLocationFile.WrestlerDefs != null)
				{
					br.BaseStream.Seek(Program.CurLocationFile.WrestlerDefs.Address, SeekOrigin.Begin);
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
				br.BaseStream.Seek(0x3FBE4, SeekOrigin.Begin);
			}

			// xxx: this shouldn't really clobber the wrestlerdefs
			//Program.CurrentProject.WrestlerDefs.Entries.Clear();
			for (int i = 0; i < 0x82; i++)
			{
				GameSpecific.VPW2.WrestlerDefinition wdef = new GameSpecific.VPW2.WrestlerDefinition(br);
				WrestlerDefs.Add(i, wdef);
				//Program.CurrentProject.WrestlerDefs.Entries.Add(wdef);
			}

			br.Close();
		}

		private void Setup_VPW2()
		{
			this.WrestlerEditControl = editControl_VPW2;

			lbWrestlerEntries.Items.Clear();
			lbWrestlerEntries.BeginUpdate();
			for (int i = 0; i < this.WrestlerDefs.Count; i++)
			{
				GameSpecific.VPW2.WrestlerDefinition def = (GameSpecific.VPW2.WrestlerDefinition)this.WrestlerDefs[i];
				lbWrestlerEntries.Items.Add(String.Format("{0:X4}", def.WrestlerID4));
			}
			lbWrestlerEntries.EndUpdate();
		}

		private void SelectWrestler_VPW2()
		{
			editControl_VPW2.LoadData((GameSpecific.VPW2.WrestlerDefinition)this.WrestlerDefs[lbWrestlerEntries.SelectedIndex]);
		}
		#endregion

		#region WWF No Mercy
		/// <summary>
		/// Load WrestlerDefinition data from WWF No Mercy.
		/// </summary>
		private void LoadDefs_NoMercy()
		{
			MemoryStream ms = new MemoryStream(Program.CurrentInputROM.Data);
			BinaryReader br = new BinaryReader(ms);

			bool hasLocation = false;
			if (Program.CurLocationFile != null)
			{
				if (Program.CurLocationFile.WrestlerDefs != null)
				{
					br.BaseStream.Seek(Program.CurLocationFile.WrestlerDefs.Address, SeekOrigin.Begin);
					hasLocation = true;
				}
			}

			if (!hasLocation)
			{
				// fallback to hardcoded offsets for known variants
				MessageBox.Show(
					"Wrestler Definition location not found; using hardcoded offset instead.",
					SharedStrings.MainForm_Title,
					MessageBoxButtons.OK,
					MessageBoxIcon.Information
				);
				switch (Program.CurrentProject.Settings.GameType)
				{
					case SpecificGame.NoMercy_NTSC_U_10:
					case SpecificGame.NoMercy_PAL_10:
						br.BaseStream.Seek(0x46658, SeekOrigin.Begin);
						break;
					case SpecificGame.NoMercy_NTSC_U_11:
						br.BaseStream.Seek(0x465B8, SeekOrigin.Begin);
						break;
					case SpecificGame.NoMercy_PAL_11:
						br.BaseStream.Seek(0x464B8, SeekOrigin.Begin);
						break;
				}
			}

			for (int i = 0; i < (0x40 * 4) + 0x25; i++)
			{
				WrestlerDefs.Add(i, new GameSpecific.NoMercy.WrestlerDefinition(br));
			}

			br.Close();
		}

		private void Setup_NoMercy()
		{
			this.WrestlerEditControl = editControl_NoMercy;

			lbWrestlerEntries.Items.Clear();
			lbWrestlerEntries.BeginUpdate();
			for (int i = 0; i < this.WrestlerDefs.Count; i++)
			{
				GameSpecific.NoMercy.WrestlerDefinition def = (GameSpecific.NoMercy.WrestlerDefinition)this.WrestlerDefs[i];
				if (def.WrestlerID2 <= 0x40)
				{
					int costume = i % 4;
					lbWrestlerEntries.Items.Add(String.Format("{0:X4}-{1}", def.WrestlerID4, costume));
				}
				else
				{
					lbWrestlerEntries.Items.Add(String.Format("{0:X4}", def.WrestlerID4));
				}
			}
			lbWrestlerEntries.EndUpdate();
		}

		private void SelectWrestler_NoMercy()
		{
			editControl_NoMercy.LoadData((GameSpecific.NoMercy.WrestlerDefinition)this.WrestlerDefs[lbWrestlerEntries.SelectedIndex]);
		}
		#endregion


		#region Temporary Info Dumps
		private void InfoDump_VPW2()
		{
			StringBuilder sb = new StringBuilder();
			for (int i = 0; i < this.WrestlerDefs.Count; i++)
			{
				GameSpecific.VPW2.WrestlerDefinition wrestlerDef = (GameSpecific.VPW2.WrestlerDefinition)this.WrestlerDefs[i];
				sb.AppendLine("================================================");
				sb.AppendLine(String.Format("ID4: {0:X4}", wrestlerDef.WrestlerID4));
				sb.AppendLine(String.Format("ID2: {0:X2}", wrestlerDef.WrestlerID2));
				sb.AppendLine(String.Format("Theme: {0:X}", wrestlerDef.ThemeSong));
				sb.AppendLine(String.Format("Name Call: {0:X}", wrestlerDef.NameCall));
				sb.AppendLine(String.Format("Height: {0:X}", wrestlerDef.Height));
				sb.AppendLine(String.Format("Weight: {0:X}", wrestlerDef.Weight));
				sb.AppendLine(String.Format("Voice 1: {0:X}", wrestlerDef.Voice1));
				sb.AppendLine(String.Format("Voice 2: {0:X}", wrestlerDef.Voice2));
				sb.AppendLine(String.Format("Moveset File Index: {0:X4}", wrestlerDef.MovesetFileIndex));
				sb.AppendLine(String.Format("Params File Index: {0:X4}", wrestlerDef.ParamsFileIndex));
				sb.AppendLine(String.Format("Appearance Index: {0:X4}", wrestlerDef.AppearanceIndex));
				sb.AppendLine(String.Format("Profile Index: {0:X4}", wrestlerDef.ProfileIndex));
				sb.AppendLine();
			}
			tbTempInfoDump.Text = sb.ToString();
		}

		private void InfoDump_NoMercy()
		{
			StringBuilder sb = new StringBuilder();
			for (int i = 0; i < this.WrestlerDefs.Count; i++)
			{
				GameSpecific.NoMercy.WrestlerDefinition wrestlerDef = (GameSpecific.NoMercy.WrestlerDefinition)this.WrestlerDefs[i];
				sb.AppendLine("================================================");
				sb.AppendLine(String.Format("ID4: {0:X4}", wrestlerDef.WrestlerID4));
				sb.AppendLine(String.Format("ID2: {0:X2}", wrestlerDef.WrestlerID2));
				sb.AppendLine(String.Format("Theme: {0:X}", wrestlerDef.ThemeSong));
				sb.AppendLine(String.Format("Titantron: {0:X}", wrestlerDef.EntranceVideo));
				sb.AppendLine(String.Format("Height: {0:X}", wrestlerDef.Height));
				sb.AppendLine(String.Format("Unknown: {0:X}", wrestlerDef.Unknown));
				sb.AppendLine(String.Format("Weight: {0:X}", wrestlerDef.Weight));
				sb.AppendLine(String.Format("Moveset File Index: {0:X4}", wrestlerDef.MovesetFileIndex));
				sb.AppendLine(String.Format("Params File Index: {0:X4}", wrestlerDef.ParamsFileIndex));
				sb.AppendLine(String.Format("Appearance Index: {0:X4}", wrestlerDef.AppearanceIndex));
				sb.AppendLine(String.Format("Profile Index: {0:X4}", wrestlerDef.ProfileIndex));
				sb.AppendLine();
			}
			tbTempInfoDump.Text = sb.ToString();
		}
		#endregion

		private void SetControlStatus()
		{
			// world tour
			// vpw64
			// revenge
			// wm2k

			editControl_VPW2.Enabled = (Program.CurrentProject.Settings.BaseGame == VPWGames.VPW2);
			editControl_VPW2.Visible = (Program.CurrentProject.Settings.BaseGame == VPWGames.VPW2);

			editControl_NoMercy.Enabled = (Program.CurrentProject.Settings.BaseGame == VPWGames.NoMercy);
			editControl_NoMercy.Visible = (Program.CurrentProject.Settings.BaseGame == VPWGames.NoMercy);
		}

		private void lbWrestlerEntries_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (lbWrestlerEntries.SelectedIndex < 0)
			{
				return;
			}

			switch (Program.CurrentProject.Settings.BaseGame)
			{
				case VPWGames.VPW2:
					SelectWrestler_VPW2();
					break;
				case VPWGames.NoMercy:
					SelectWrestler_NoMercy();
					break;
			}
		}
	}
}
