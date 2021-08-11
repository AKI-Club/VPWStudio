using System;
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
	public partial class MoveDamageTestDialog : Form
	{
		private SortedList<int, MoveDamageEntry> MoveDamageEntries = new SortedList<int, MoveDamageEntry>();

		/// <summary>
		/// Length of Move Damage data per game.
		/// </summary>
		private Dictionary<VPWGames, int> MoveDamageDataLength = new Dictionary<VPWGames, int>()
		{
			{ VPWGames.WM2K, 0x20 },
			{ VPWGames.VPW2, 0x20 },
			{ VPWGames.NoMercy, 0x24 }
		};

		/// <summary>
		/// File ID of (main) Move Damage data.
		/// </summary>
		private Dictionary<VPWGames, int> MoveDamageFileIDs = new Dictionary<VPWGames, int>()
		{
			{ VPWGames.WM2K, 0x03AD },
			{ VPWGames.VPW2, 0x0277 },
			{ VPWGames.NoMercy, 0x01EF }
		};

		public MoveDamageTestDialog()
		{
			InitializeComponent();

			if (Program.CurrentProject != null)
			{
				if (MoveDamageFileIDs.ContainsKey(Program.CurrentProject.Settings.BaseGame))
				{
					LoadDamageData(MoveDamageFileIDs[Program.CurrentProject.Settings.BaseGame], MoveDamageDataLength[Program.CurrentProject.Settings.BaseGame]);
					PopulateEntries();
				}
				else
				{
					Program.ErrorMessageBox(String.Format("Move Damage dialog not implemented for {0}.", Program.CurrentProject.Settings.BaseGame));
					Close();
				}
			}
		}

		private void LoadDamageData(int fileID, int dataLength)
		{
			MemoryStream romStream = new MemoryStream(Program.CurrentInputROM.Data);
			BinaryReader romReader = new BinaryReader(romStream);

			MemoryStream extractStream = new MemoryStream();
			BinaryWriter extractWriter = new BinaryWriter(extractStream);

			Program.CurrentProject.ProjectFileTable.ExtractFile(romReader, extractWriter, fileID);
			romReader.Close();

			int fileSize = (int)extractStream.Position;
			extractStream.Seek(0, SeekOrigin.Begin);
			int numEntries = fileSize / dataLength;

			BinaryReader br = new BinaryReader(extractStream);
			for (int i = 0; i < numEntries; i++)
			{
				MoveDamageEntries.Add(i, new MoveDamageEntry(br, dataLength));
			}
			br.Close();
		}

		private void PopulateEntries()
		{
			cbMoveDamageEntries.Items.Clear();
			cbMoveDamageEntries.BeginUpdate();
			foreach (KeyValuePair<int, MoveDamageEntry> mde in MoveDamageEntries)
			{
				cbMoveDamageEntries.Items.Add(String.Format("{0:X4}", mde.Key));
			}
			cbMoveDamageEntries.EndUpdate();
		}

		private void cbMoveDamageEntries_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (cbMoveDamageEntries.SelectedIndex < 0)
			{
				return;
			}

			ShowData(cbMoveDamageEntries.SelectedIndex);
		}

		private void ShowData(int index)
		{
			switch (Program.CurrentProject.Settings.BaseGame)
			{
				case VPWGames.WM2K:
				case VPWGames.VPW2:
					ShowData_VPW2(index);
					break;
				case VPWGames.NoMercy:
					ShowData_NoMercy(index);
					break;
			}
		}

		// xxx: works for VPW2 and WM2K, assumed.
		private void ShowData_VPW2(int index)
		{
			MoveDamageEntry mde = MoveDamageEntries[index];
			StringBuilder sb = new StringBuilder();

			// A4AE0
			sb.AppendLine(String.Format("+00: {0:X2}", mde.Data[0]));
			sb.AppendLine(String.Format("+01: {0:X2}", mde.Data[1]));
			// A4AE2
			sb.AppendLine(String.Format("+02: {0:X2}", mde.Data[2]));
			sb.AppendLine(String.Format("+03: {0:X2}", mde.Data[3]));
			// A4AE4(Link)
			sb.AppendLine(String.Format("+04: Link {0:X2}{1:X2}", mde.Data[4], mde.Data[5]));
			// A4AE6(Damage / Spirit Gained)
			sb.AppendLine(String.Format("+06: Damage {0:X2}", mde.Data[6]));
			sb.AppendLine(String.Format("+07: Spirit Gain {0:X2}", mde.Data[7]));
			// A4AE8(Spirit Drained / Blood)
			sb.AppendLine(String.Format("+08: Spirit Drain {0:X2} ({1})", mde.Data[8], (sbyte)mde.Data[8]));
			sb.AppendLine(String.Format("+09: Blood Chance {0:X2}", mde.Data[9]));
			// A4AEA(KO / Off.Parameter)
			sb.AppendLine(String.Format("+0A: KO Chance {0:X2}", mde.Data[10]));
			sb.AppendLine(String.Format("+0B: Offensive Param. {0:X2}", mde.Data[11]));
			// A4AEC(Def.Parameter / Attack With)
			sb.AppendLine(String.Format("+0C: Defensive Param. {0:X2}", mde.Data[12]));
			sb.AppendLine(String.Format("+0D: {0:X2}", mde.Data[13]));
			// A4AEE
			sb.AppendLine(String.Format("+0E: {0:X2}", mde.Data[14]));
			sb.AppendLine(String.Format("+0F: {0:X2}", mde.Data[15]));
			// A4AF0(Attack to /)
			sb.AppendLine(String.Format("+10: {0:X2}", mde.Data[16]));
			sb.AppendLine(String.Format("+11: {0:X2}", mde.Data[17]));
			// A4AF2(Head Damage / Body Damage)
			sb.AppendLine(String.Format("+12: Head Damage {0:X2}", mde.Data[18]));
			sb.AppendLine(String.Format("+13: Body Damage {0:X2}", mde.Data[19]));
			// A4AF4(Arm Damage / Leg Damage)
			sb.AppendLine(String.Format("+14: Arm Damage {0:X2}", mde.Data[20]));
			sb.AppendLine(String.Format("+15: Leg Damage {0:X2}", mde.Data[21]));
			// A4AF6(Speed Damage / Sell)
			sb.AppendLine(String.Format("+16: Speed/Flying Damage {0:X2}", mde.Data[22]));
			sb.AppendLine(String.Format("+17: {0:X2}", mde.Data[23]));
			// A4AF8
			sb.AppendLine(String.Format("+18: {0:X2}", mde.Data[24]));
			sb.AppendLine(String.Format("+19: {0:X2}", mde.Data[25]));
			// A4AFA / ?
			sb.AppendLine(String.Format("+1A: {0:X2}", mde.Data[26]));
			sb.AppendLine(String.Format("+1B: {0:X2}", mde.Data[27]));
			// A4AFC
			sb.AppendLine(String.Format("+1C: {0:X2}", mde.Data[28]));
			sb.AppendLine(String.Format("+1D: {0:X2}", mde.Data[29]));
			// A4AFE(Favorite / Pin / Submission)
			sb.AppendLine(String.Format("+1E: {0:X2}", mde.Data[30]));
			sb.AppendLine(String.Format("+1F: {0:X2}", mde.Data[31]));

			tbOutput.Text = sb.ToString();
		}

		private void ShowData_NoMercy(int index)
		{
			MoveDamageEntry mde = MoveDamageEntries[index];
			StringBuilder sb = new StringBuilder();

			// mostly like VPW2 but with new entries
			sb.AppendLine(String.Format("+00: {0:X2}", mde.Data[0]));
			sb.AppendLine(String.Format("+01: {0:X2}", mde.Data[1]));
			sb.AppendLine(String.Format("+02: {0:X2}", mde.Data[2]));
			sb.AppendLine(String.Format("+03: {0:X2}", mde.Data[3]));
			sb.AppendLine(String.Format("+04: Link {0:X2}{1:X2}", mde.Data[4], mde.Data[5]));
			sb.AppendLine(String.Format("+06: Damage {0:X2}", mde.Data[6]));
			sb.AppendLine(String.Format("+07: Spirit Gain {0:X2}", mde.Data[7]));
			sb.AppendLine(String.Format("+08: Spirit Drain {0:X2} ({1})", mde.Data[8], (sbyte)mde.Data[8]));
			sb.AppendLine(String.Format("+09: Blood Chance {0:X2}", mde.Data[9]));
			sb.AppendLine(String.Format("+0A: KO Chance {0:X2}", mde.Data[10]));
			sb.AppendLine(String.Format("+0B: Offensive Param. {0:X2}", mde.Data[11]));
			sb.AppendLine(String.Format("+0C: Defensive Param. {0:X2}", mde.Data[12]));
			sb.AppendLine(String.Format("+0D: {0:X2}", mde.Data[13]));
			sb.AppendLine(String.Format("+0E: {0:X2}", mde.Data[14]));
			sb.AppendLine(String.Format("+0F: {0:X2}", mde.Data[15]));
			sb.AppendLine(String.Format("+10: {0:X2}", mde.Data[16]));
			sb.AppendLine(String.Format("+11: {0:X2}", mde.Data[17]));
			sb.AppendLine(String.Format("+12: Head Damage {0:X2}", mde.Data[18]));
			sb.AppendLine(String.Format("+13: Body Damage {0:X2}", mde.Data[19]));
			sb.AppendLine(String.Format("+14: Arm Damage {0:X2}", mde.Data[20]));
			sb.AppendLine(String.Format("+15: Leg Damage {0:X2}", mde.Data[21]));
			sb.AppendLine(String.Format("+16: Speed/Flying Damage {0:X2}", mde.Data[22]));
			sb.AppendLine(String.Format("+17: Strike Reaction {0:X2}", mde.Data[23]));
			sb.AppendLine(String.Format("+18: {0:X2}", mde.Data[24]));
			sb.AppendLine(String.Format("+19: {0:X2}", mde.Data[25]));
			sb.AppendLine(String.Format("+1A: {0:X2}", mde.Data[26]));
			sb.AppendLine(String.Format("+1B: Special Damage {0:X2}", mde.Data[27]));
			sb.AppendLine(String.Format("+1C: Previous Move {0:X2}", mde.Data[28]));
			sb.AppendLine(String.Format("+1D: {0:X2}", mde.Data[29]));
			sb.AppendLine(String.Format("+1E: {0:X2}", mde.Data[30]));
			sb.AppendLine(String.Format("+1F: {0:X2}", mde.Data[31]));
			sb.AppendLine(String.Format("+20: Move Type {0:X2}", mde.Data[32]));
			sb.AppendLine(String.Format("+21: Additional Properties {0:X2}", mde.Data[33]));
			sb.AppendLine(String.Format("+22: {0:X2}", mde.Data[34]));
			sb.AppendLine(String.Format("+23: {0:X2}", mde.Data[35]));

			tbOutput.Text = sb.ToString();
		}
	}

	public class MoveDamageEntry
	{
		public byte[] Data;
		public int DataLength;

		public MoveDamageEntry(BinaryReader br, int dataLength)
		{
			DataLength = dataLength;
			ReadEntry(br);
		}

		public void ReadEntry(BinaryReader br)
		{
			Data = br.ReadBytes(DataLength);
		}
	}
}
