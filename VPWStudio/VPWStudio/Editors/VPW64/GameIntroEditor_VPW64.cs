using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using VPWStudio.GameSpecific.VPW64;

namespace VPWStudio.Editors.VPW64
{
	public partial class GameIntroEditor_VPW64 : Form
	{
		/// <summary>
		/// introduction sequence entries.
		/// </summary>
		public List<IntroSequenceEntry> Entries;

		private StringBuilder OutBuilder = new StringBuilder();

		public GameIntroEditor_VPW64()
		{
			InitializeComponent();

			// get data from rom
			Entries = new List<IntroSequenceEntry>();
			LoadData();

			// populate list
			cbIntroEntries.BeginUpdate();
			for (int i = 0; i < Entries.Count; i++)
			{
				cbIntroEntries.Items.Add(String.Format("Entry {0}",i));
			}
			cbIntroEntries.EndUpdate();
			cbIntroEntries.SelectedIndex = 0;
		}

		private void LoadData()
		{
			// load data from ROM
			bool hasIntroLocation = false;
			uint introDataLocation = 0;
			int numAnims = 0;

			MemoryStream ms = new MemoryStream(Program.CurrentInputROM.Data);
			BinaryReader br = new BinaryReader(ms);

			if (Program.CurLocationFile != null)
			{
				LocationFileEntry animEntry = Program.CurLocationFile.GetEntryFromComment(LocationFile.SpecialEntryStrings["IntroDefs_VPW64_Anims"]);
				if (animEntry != null)
				{
					introDataLocation = animEntry.Address;
					numAnims = animEntry.Length / 40;
					hasIntroLocation = true;
				}
			}

			// if no values were found in the location file, use hardcoded values
			if (!hasIntroLocation)
			{
				DefaultGameData.DefaultLocationDataEntry anims = DefaultGameData.GetEntry(Program.CurrentProject.Settings.GameType, "IntroDefs_VPW64_Anims");
				if (anims != null)
				{
					introDataLocation = anims.Offset;
					numAnims = (int)(anims.Length / 40);
					hasIntroLocation = true;
				}
			}

			if (hasIntroLocation)
			{
				ms.Seek(introDataLocation, SeekOrigin.Begin);
				for (int i = 0; i < numAnims; i++)
				{
					Entries.Add(new IntroSequenceEntry(br));
				}

			}
			br.Close();
		}

		private void cbIntroEntries_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (cbIntroEntries.SelectedIndex < 0)
			{
				return;
			}

			tbOutput.Clear();
			OutBuilder.Clear();

			IntroSequenceEntry curEntry = Entries[cbIntroEntries.SelectedIndex];
			OutBuilder.AppendLine("[Slot 1]");
			OutBuilder.AppendLine(String.Format("Wrestler ID4 0x{0:X4}", curEntry.Wrestler1.WrestlerID4));
			OutBuilder.AppendLine(String.Format("Animation ID 0x{0:X4}", curEntry.Wrestler1.AnimationID));
			OutBuilder.AppendLine(String.Format("Unknown1 0x{0:X4}", curEntry.Wrestler1.Unknown1));
			OutBuilder.AppendLine(String.Format("Timing 0x{0:X4}", curEntry.Wrestler1.Timing));
			OutBuilder.AppendLine(String.Format("X Position 0x{0:X4}", curEntry.Wrestler1.XPosition));
			OutBuilder.AppendLine(String.Format("Z Position 0x{0:X4}", curEntry.Wrestler1.ZPosition));
			OutBuilder.AppendLine(String.Format("Rotation 0x{0:X4}", curEntry.Wrestler1.Rotation));
			OutBuilder.AppendLine(String.Format("Move Speed 0x{0:X4}", curEntry.Wrestler1.MoveSpeed));
			OutBuilder.AppendLine();

			OutBuilder.AppendLine("[Slot 2]");
			OutBuilder.AppendLine(String.Format("Wrestler ID4 0x{0:X4}", curEntry.Wrestler2.WrestlerID4));
			OutBuilder.AppendLine(String.Format("Animation ID 0x{0:X4}", curEntry.Wrestler2.AnimationID));
			OutBuilder.AppendLine(String.Format("Unknown1 0x{0:X4}", curEntry.Wrestler2.Unknown1));
			OutBuilder.AppendLine(String.Format("Timing 0x{0:X4}", curEntry.Wrestler2.Timing));
			OutBuilder.AppendLine(String.Format("X Position 0x{0:X4}", curEntry.Wrestler2.XPosition));
			OutBuilder.AppendLine(String.Format("Z Position 0x{0:X4}", curEntry.Wrestler2.ZPosition));
			OutBuilder.AppendLine(String.Format("Rotation 0x{0:X4}", curEntry.Wrestler2.Rotation));
			OutBuilder.AppendLine(String.Format("Move Speed 0x{0:X4}", curEntry.Wrestler2.MoveSpeed));
			OutBuilder.AppendLine();

			OutBuilder.AppendLine("[Other Data]");
			OutBuilder.AppendLine(String.Format("Unknown1 0x{0:X4}", curEntry.Unknown1));
			OutBuilder.AppendLine(String.Format("Camera Movement 0x{0:X4}", curEntry.CameraMovement));
			OutBuilder.AppendLine(String.Format("Unknown2 0x{0:X4}", curEntry.Unknown2));
			OutBuilder.AppendLine(String.Format("Unknown3 0x{0:X4}", curEntry.Unknown3));

			tbOutput.Text = OutBuilder.ToString();
		}
	}
}
