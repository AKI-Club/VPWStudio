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
	public partial class Toki1TestDialog : Form
	{
		private SortedList<int, Toki1Entry> Toki1Entries = new SortedList<int, Toki1Entry>();

		/// <summary>
		/// Length of Toki1 data per game.
		/// </summary>
		private Dictionary<VPWGames, int> Toki1DataLength = new Dictionary<VPWGames, int>()
		{
			{ VPWGames.WorldTour, 0x20 },
			{ VPWGames.VPW64, 0x20 },
			{ VPWGames.Revenge, 0x24 },
			{ VPWGames.WM2K, 0x24 },
			{ VPWGames.VPW2, 0x24 },
			{ VPWGames.NoMercy, 0x24 }
		};

		readonly int firstAnimNumber = DefaultGameData.DefaultFileTableIDs["FirstAnimationFileID"][Program.CurrentProject.Settings.GameType];

		public Toki1TestDialog(int _entry = 0)
		{
			InitializeComponent();

			if (Program.CurrentProject != null)
			{
				LoadToki1();
				PopulateEntries();
			}

			cbToki1Entries.SelectedIndex = _entry;
			ShowData(cbToki1Entries.SelectedIndex);
		}

		private void LoadToki1()
		{
			MemoryStream romStream = new MemoryStream(Program.CurrentInputROM.Data);
			BinaryReader romReader = new BinaryReader(romStream);

			MemoryStream extractStream = new MemoryStream();
			BinaryWriter extractWriter = new BinaryWriter(extractStream);

			int fileID = DefaultGameData.DefaultFileTableIDs["Toki1FileID"][Program.CurrentProject.Settings.GameType];
			int dataLength = Toki1DataLength[Program.CurrentProject.Settings.BaseGame];

			Program.CurrentProject.ProjectFileTable.ExtractFile(romReader, extractWriter, fileID);
			romReader.Close();

			int fileSize = (int)extractStream.Position;
			extractStream.Seek(0, SeekOrigin.Begin);
			int numEntries = fileSize / dataLength;

			BinaryReader br = new BinaryReader(extractStream);
			for (int i = 0; i < numEntries; i++)
			{
				Toki1Entries.Add(i, new Toki1Entry(br, dataLength));
			}
			br.Close();
		}

		private void PopulateEntries()
		{
			cbToki1Entries.Items.Clear();
			cbToki1Entries.BeginUpdate();
			foreach (KeyValuePair<int, Toki1Entry> t1e in Toki1Entries)
			{
				cbToki1Entries.Items.Add(String.Format("{0:X4} [Anim. {1:X4}]", t1e.Key, t1e.Key + firstAnimNumber));
			}
			cbToki1Entries.EndUpdate();
		}

		private void ShowData(int index)
		{
			switch (Program.CurrentProject.Settings.BaseGame)
			{
				case VPWGames.WorldTour:
				case VPWGames.VPW64:
					ShowDataEarly(index);
					break;
				case VPWGames.Revenge:
				case VPWGames.WM2K:
				case VPWGames.VPW2:
				case VPWGames.NoMercy:
					ShowDataModern(index);
					break;
			}
		}

		/// <summary>
		/// Show Toki1 data for early games.
		/// </summary>
		/// <param name="index">Index into Toki1 entries.</param>
		private void ShowDataEarly(int index)
		{
			Toki1Entry t = Toki1Entries[index];
			StringBuilder sb = new StringBuilder();

			sb.AppendLine(String.Format("[0x00] Camera, End of Animation status: 0x{0:X2}", t.Data[0]));
			sb.AppendLine(String.Format("[0x01]: 0x{0:X2}", t.Data[1]));
			sb.AppendLine(String.Format("[0x02]: 0x{0:X2}", t.Data[2]));
			sb.AppendLine(String.Format("[0x03]: 0x{0:X2}", t.Data[3]));
			sb.AppendLine(String.Format("[0x04]: 0x{0:X2}", t.Data[4]));
			sb.AppendLine(String.Format("[0x05]: 0x{0:X2}", t.Data[5]));
			sb.AppendLine(String.Format("[0x06]: 0x{0:X2}", t.Data[6]));
			sb.AppendLine(String.Format("[0x07]: 0x{0:X2}", t.Data[7]));
			sb.AppendLine(String.Format("[0x08]: 0x{0:X2}", t.Data[8]));
			sb.AppendLine(String.Format("[0x09]: 0x{0:X2}", t.Data[9]));
			sb.AppendLine(String.Format("[0x0A]: 0x{0:X2}", t.Data[10]));
			sb.AppendLine(String.Format("[0x0B]: 0x{0:X2}", t.Data[11]));
			sb.AppendLine(String.Format("[0x0C]: 0x{0:X2}", t.Data[12]));
			sb.AppendLine(String.Format("[0x0D]: 0x{0:X2}", t.Data[13]));
			sb.AppendLine(String.Format("[0x0E]: 0x{0:X2}", t.Data[14]));
			sb.AppendLine(String.Format("[0x0F]: 0x{0:X2}", t.Data[15]));
			sb.AppendLine(String.Format("[0x10] Effect 1: frame {0} (0x{0:X2}), value 0x{1:X2}", t.Data[16], t.Data[17]));
			sb.AppendLine(String.Format("[0x12] Effect 2: frame {0} (0x{0:X2}), value 0x{1:X2}", t.Data[18], t.Data[19]));
			sb.AppendLine(String.Format("[0x14] Effect 3: frame {0} (0x{0:X2}), value 0x{1:X2}", t.Data[20], t.Data[21]));
			sb.AppendLine(String.Format("[0x16] Effect 4: frame {0} (0x{0:X2}), value 0x{1:X2}", t.Data[22], t.Data[23]));
			sb.AppendLine(String.Format("[0x18] Effect 5: frame {0} (0x{0:X2}), value 0x{1:X2}", t.Data[24], t.Data[25]));
			sb.AppendLine(String.Format("[0x1A] Effect 6: frame {0} (0x{0:X2}), value 0x{1:X2}", t.Data[26], t.Data[27]));
			sb.AppendLine(String.Format("[0x1C] Effect 7: frame {0} (0x{0:X2}), value 0x{1:X2}", t.Data[28], t.Data[29]));
			sb.AppendLine(String.Format("[0x1E] Effect 8: frame {0} (0x{0:X2}), value 0x{1:X2}", t.Data[30], t.Data[31]));

			tbOutput.Text = sb.ToString();
		}

		/// <summary>
		/// Show Toki1 data for modern games.
		/// </summary>
		/// <param name="index">Index into Toki1 entries.</param>
		private void ShowDataModern(int index)
		{
			Toki1Entry t = Toki1Entries[index];
			StringBuilder sb = new StringBuilder();

			sb.AppendLine(String.Format("[0x00] Camera, End of Animation status: 0x{0:X2}", t.Data[0]));
			sb.AppendLine(String.Format("[0x01] Single/Repeating: 0x{0:X2}", t.Data[1]));
			sb.AppendLine(String.Format("[0x02] 0x{0:X2}", t.Data[2]));
			sb.AppendLine(String.Format("[0x03] Beginning Damage Frame (Striking Moves) 0x{0:X2}", t.Data[3]));
			sb.AppendLine(String.Format("[0x04] Ending Damage Frame (Striking Moves) 0x{0:X2}", t.Data[4]));
			sb.AppendLine(String.Format("[0x05] Mist/Fire Type: 0x{0:X2}", t.Data[5]));
			sb.AppendLine(String.Format("[0x06] Mist/Fire Frame: 0x{0:X2}", t.Data[6]));
			sb.AppendLine(String.Format("[0x07] Beginning Frame for Reversal Only: 0x{0:X2}", t.Data[7]));
			sb.AppendLine(String.Format("[0x08] First Vulnerable Frame: 0x{0:X2}", t.Data[8]));
			sb.AppendLine(String.Format("[0x09] Reversal Frame (Front Grapples?) 0x{0:X2}", t.Data[9]));
			sb.AppendLine(String.Format("[0x0A] Breakway Frame (Grapple Moves) 0x{0:X2}", t.Data[10]));
			sb.AppendLine(String.Format("[0x0B] Motion Effect: frame {0}, value 0x{1:X2}", t.Data[11], t.Data[12]));
			sb.AppendLine(String.Format("[0x0D] Camera Effect: frame {0}, value 0x{1:X2}", t.Data[13], t.Data[14]));
			sb.AppendLine(String.Format("[0x0F] Replay Frame: 0x{0:X2}", t.Data[15]));
			sb.AppendLine(String.Format("[0x10] (WWF No Mercy: Table Break Frame; others: ???) 0x{0:X2}", t.Data[16]));
			sb.AppendLine(String.Format("[0x11] Ground Hold Interrupt Frame 0x{0:X2}", t.Data[17]));
			sb.AppendLine(String.Format("[0x12] 0x{0:X2}", t.Data[18]));
			sb.AppendLine(String.Format("[0x13] 0x{0:X2}", t.Data[19]));
			sb.AppendLine(String.Format("[0x14] Effect 1: frame {0} (0x{0:X2}), value 0x{1:X2}", t.Data[20], t.Data[21]));
			sb.AppendLine(String.Format("[0x16] Effect 2: frame {0} (0x{0:X2}), value 0x{1:X2}", t.Data[22], t.Data[23]));
			sb.AppendLine(String.Format("[0x18] Effect 3: frame {0} (0x{0:X2}), value 0x{1:X2}", t.Data[24], t.Data[25]));
			sb.AppendLine(String.Format("[0x1A] Effect 4: frame {0} (0x{0:X2}), value 0x{1:X2}", t.Data[26], t.Data[27]));
			sb.AppendLine(String.Format("[0x1C] Effect 5: frame {0} (0x{0:X2}), value 0x{1:X2}", t.Data[28], t.Data[29]));
			sb.AppendLine(String.Format("[0x1E] Effect 6: frame {0} (0x{0:X2}), value 0x{1:X2}", t.Data[30], t.Data[31]));
			sb.AppendLine(String.Format("[0x20] Effect 7: frame {0} (0x{0:X2}), value 0x{1:X2}", t.Data[32], t.Data[33]));
			sb.AppendLine(String.Format("[0x22] Effect 8: frame {0} (0x{0:X2}), value 0x{1:X2}", t.Data[34], t.Data[35]));
			tbOutput.Text = sb.ToString();
		}

		private void cbToki1Entries_SelectionChangeCommitted(object sender, EventArgs e)
		{
			if (cbToki1Entries.SelectedIndex < 0)
			{
				return;
			}

			ShowData(cbToki1Entries.SelectedIndex);
		}

		private void Toki1TestDialog_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Escape)
			{
				Close();
			}
		}
	}

	/// <summary>
	/// A single Animation Mods 1/Toki 1 entry.
	/// </summary>
	/// This should probably exist elsewhere...
	public class Toki1Entry
	{
		/// <summary>
		/// Data for this Toki 1 entry.
		/// </summary>
		public byte[] Data;

		/// <summary>
		/// Data length of this Toki 1 entry.
		/// Has to exist since the Toki 1 values changed through the games.
		/// </summary>
		public int DataLength;

		/// <summary>
		/// Default constructor.
		/// </summary>
		/// <param name="br">BinaryReader instance to use.</param>
		/// <param name="dataLength">Length of data to read.</param>
		public Toki1Entry(BinaryReader br, int dataLength)
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
