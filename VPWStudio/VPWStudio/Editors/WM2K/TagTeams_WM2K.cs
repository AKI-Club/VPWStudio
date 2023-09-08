using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using VPWStudio.GameSpecific.WM2K;

namespace VPWStudio.Editors.WM2K
{
	/// <summary>
	/// WrestleMania 2000 Tag Team Defintiions editor
	/// </summary>
	public partial class TagTeams_WM2K : Form
	{
		private readonly int EDIT_MODE_TEXT_FILE_ID = 0x0004;

		/// <summary>
		/// List of tag teams.
		/// </summary>
		public List<TagTeamDefinition> TagTeams;

		protected AkiText EditModeText;

		public TagTeams_WM2K()
		{
			InitializeComponent();
			TagTeams = new List<TagTeamDefinition>();

			LoadText();
			LoadData_ROM();
			cbTeamList.BeginUpdate();
			for (int i = 0; i < TagTeams.Count; i++)
			{
				cbTeamList.Items.Add(String.Format("Team Number {0}",i));
			}
			cbTeamList.EndUpdate();
			cbTeamList.SelectedIndex = 0;
		}

		public void LoadText()
		{
			MemoryStream romStream = new MemoryStream(Program.CurrentInputROM.Data);
			BinaryReader romReader = new BinaryReader(romStream);

			FileTableEntry editModeText = Program.CurrentProject.ProjectFileTable.Entries[EDIT_MODE_TEXT_FILE_ID];
			if (!String.IsNullOrEmpty(editModeText.ReplaceFilePath))
			{
				FileStream fs = new FileStream(Program.ConvertRelativePath(editModeText.ReplaceFilePath), FileMode.Open);
				BinaryReader br = new BinaryReader(fs);
				EditModeText = new AkiText(br);
				br.Close();
			}
			else
			{
				MemoryStream outStream = new MemoryStream();
				BinaryWriter outWriter = new BinaryWriter(outStream);

				Program.CurrentProject.ProjectFileTable.ExtractFile(romReader, outWriter, EDIT_MODE_TEXT_FILE_ID);

				outStream.Seek(0, SeekOrigin.Begin);
				BinaryReader outReader = new BinaryReader(outStream);
				EditModeText = new AkiText(outReader);
				outReader.Close();
				outWriter.Close();
			}

			romReader.Close();
		}

		public void LoadData_ROM()
		{
			MemoryStream ms = new MemoryStream(Program.CurrentInputROM.Data);
			BinaryReader br = new BinaryReader(ms);

			bool hasLocation = false;
			if (Program.CurLocationFile != null)
			{
				LocationFileEntry sdEntry = Program.CurLocationFile.GetEntryFromComment(LocationFile.SpecialEntryStrings["TagTeamDefs"]);
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
				br.BaseStream.Seek(DefaultGameData.DefaultLocations[Program.CurrentProject.Settings.GameType].Locations["TagTeamDefs"].Offset, SeekOrigin.Begin);
			}

			// xxx: default number of tag team defs
			for (int i = 0; i < 32; i++)
			{
				TagTeamDefinition tagDef = new TagTeamDefinition(br);
				TagTeams.Add(tagDef);
			}
			br.Close();
		}

		private void cbTeamList_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (cbTeamList.SelectedIndex < 0)
			{
				return;
			}

			TagTeamDefinition curTeam = TagTeams[cbTeamList.SelectedIndex];
			StringBuilder sb = new StringBuilder();
			tbOutput.Clear();
			sb.AppendLine(String.Format("Wrestler ID2 values: 0x{0:X2}, 0x{1:X2}", curTeam.Wrestler1, curTeam.Wrestler2));
			sb.AppendLine(String.Format("Team Music: 0x{0:X2} ({1})", curTeam.TeamMusic, EditModeText.GetEntry(curTeam.TeamMusic + 11)));
			sb.AppendLine(String.Format("Team Video: 0x{0:X2} ({1})", curTeam.TeamVideo, EditModeText.GetEntry(curTeam.TeamVideo + 11)));
			sb.AppendLine(String.Format("Wrestler 1 must have Music 0x{0:X2} ({1}), Video 0x{2:X2} ({3})",
				curTeam.Wrestler1Music, EditModeText.GetEntry(curTeam.Wrestler1Music + 11),
				curTeam.Wrestler1Video, EditModeText.GetEntry(curTeam.Wrestler1Video + 11))
			);
			sb.AppendLine(String.Format("Wrestler 2 must have Music 0x{0:X2} ({1}), Video 0x{2:X2} ({3})",
				curTeam.Wrestler2Music, EditModeText.GetEntry(curTeam.Wrestler2Music + 11),
				curTeam.Wrestler2Video, EditModeText.GetEntry(curTeam.Wrestler2Video + 11))
			);
			sb.AppendLine(String.Format("Unknown Value: 0x{0:X2}", curTeam.Unknown));
			sb.AppendLine(String.Format("Wrestler Entrance values: 0x{0:X2}, 0x{1:X2}", curTeam.Wrestler1Entrance, curTeam.Wrestler2Entrance));
			sb.AppendLine(String.Format("Flags? and Team Name Index: 0x{0:X2}", curTeam.Flags_NameIndex));
			if ((curTeam.Flags_NameIndex & 0x0F) != 0)
			{
				sb.AppendLine(String.Format("Team Name: {0}", EditModeText.GetEntry((curTeam.Flags_NameIndex & 0x0F)-1)));
			}
			tbOutput.Text = sb.ToString();
		}
	}
}
