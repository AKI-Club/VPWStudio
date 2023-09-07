using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using VPWStudio.GameSpecific;

namespace VPWStudio.Editors
{
	public partial class ChampionshipDefs_Early : Form
	{
		public SortedList<int, StableDef_Early> StableDefs = new SortedList<int, StableDef_Early>();

		// xxx: this is duplicated from StableDefs_Early editor
		private Dictionary<VPWGames, int> NumStables = new Dictionary<VPWGames, int>()
		{
			{ VPWGames.WorldTour, 6 },
			{ VPWGames.VPW64, 11 }
		};

		public ChampionshipDefs_Early()
		{
			InitializeComponent();
			/*
			if (!String.IsNullOrEmpty(Program.CurrentProject.Settings.StableDefinitionFilePath) &&
				File.Exists(Program.ConvertRelativePath(Program.CurrentProject.Settings.StableDefinitionFilePath))
			)
			{
				LoadData_File(Program.CurrentProject.Settings.StableDefinitionFilePath);
			}
			else
			{
			*/
				LoadData_ROM();
			//}

			foreach (KeyValuePair<int,StableDef_Early> stable in StableDefs)
			{
				cbStables.Items.Add(string.Format("stable {0}",stable.Key));
			}
			cbStables.SelectedIndex = 0;
		}

		private void LoadData_File(string _path)
		{
			StableDefFile sdf = new StableDefFile(Program.CurrentProject.Settings.BaseGame);
			FileStream fs = new FileStream(Program.ConvertRelativePath(_path), FileMode.Open);
			StreamReader sr = new StreamReader(fs);
			sdf.ReadFile(sr);
			sr.Close();
			StableDefs = sdf.StableDefs_Early;
		}

		private void LoadData_ROM()
		{
			MemoryStream ms = new MemoryStream(Program.CurrentInputROM.Data);
			BinaryReader br = new BinaryReader(ms, Encoding.GetEncoding("EUC-JP"));

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
			for (int i = 0; i < NumStables[Program.CurrentProject.Settings.BaseGame]; i++)
			{
				StableDef_Early sdef = new StableDef_Early(br);
				StableDefs.Add(i, sdef);
			}

			br.Close();
		}

		private void cbStables_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (cbStables.SelectedIndex < 0)
			{
				return;
			}
			tbOutput.Clear();
			StableDef_Early curStable = StableDefs[cbStables.SelectedIndex];
			if (curStable.NumChampionships > 0)
			{
				StringBuilder sb = new StringBuilder();
				sb.AppendLine(String.Format("Stable has {0} championship definitions", curStable.NumChampionships));

				if (curStable.ChampionshipData != null)
				{
					for (int c = 0; c < curStable.ChampionshipData.Length; c++)
					{
						ChampionshipDef_Early curChampDef = curStable.ChampionshipData[c];
						sb.AppendLine();
						sb.AppendLine(String.Format("Championship #{0}: {1}", c, curChampDef.ChampionshipName));
						sb.AppendLine(String.Format("offset 0x00: 0x{0:X2}", curChampDef.Unknown0));
						sb.AppendLine(String.Format("offset 0x01: 0x{0:X2}", curChampDef.Unknown1));
						sb.AppendLine(String.Format("offset 0x02: 0x{0:X2}", curChampDef.Unknown2));
						sb.AppendLine(String.Format("offset 0x03: 0x{0:X2}", curChampDef.Unknown3));
						sb.AppendLine(String.Format("offset 0x04: 0x{0:X2}", curChampDef.Unknown4));
						sb.AppendLine(String.Format("offset 0x05: 0x{0:X2}", curChampDef.Unknown5));
						sb.AppendLine(String.Format("offset 0x06: 0x{0:X2}", curChampDef.Unknown6));
						sb.AppendLine(String.Format("offset 0x07: 0x{0:X2}", curChampDef.Unknown7));
						sb.AppendLine(String.Format("offset 0x08: 0x{0:X4}", curChampDef.Unknown8));
						sb.AppendLine(String.Format("offset 0x0A: 0x{0:X4}", curChampDef.Unknown10));
					}
				}
				else
				{
					sb.AppendLine("Unable to read championship data for this stable.");
				}

				tbOutput.Text = sb.ToString();
			}
			else
			{
				tbOutput.Text = "No championship data for this stable.";
			}
		}
	}
}
