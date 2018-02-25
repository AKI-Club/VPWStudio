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

		public Toki1TestDialog()
		{
			InitializeComponent();

			if (Program.CurrentProject != null)
			{
				if (Program.CurrentProject.Settings.BaseGame == VPWGames.VPW2)
				{
					MemoryStream romStream = new MemoryStream(Program.CurrentInputROM.Data);
					BinaryReader romReader = new BinaryReader(romStream);

					MemoryStream extractStream = new MemoryStream();
					BinaryWriter extractWriter = new BinaryWriter(extractStream);

					Program.CurrentProject.ProjectFileTable.ExtractFile(romReader, extractWriter, 0x034B);
					romReader.Close();

					int fileSize = (int)extractStream.Position;
					extractStream.Seek(0, SeekOrigin.Begin);
					int numEntries = fileSize / 36;

					BinaryReader br = new BinaryReader(extractStream);
					for (int i = 0; i < numEntries; i++)
					{
						Toki1Entries.Add(i, new Toki1Entry(br));
					}
					br.Close();

					PopulateEntries();
				}
			}
		}

		private void PopulateEntries()
		{
			cbToki1Entries.Items.Clear();
			cbToki1Entries.BeginUpdate();
			foreach (KeyValuePair<int, Toki1Entry> t1e in Toki1Entries)
			{
				cbToki1Entries.Items.Add(String.Format("{0:X4}", t1e.Key));
			}
			cbToki1Entries.EndUpdate();
		}

		private void ShowData(int index)
		{
			Toki1Entry t = Toki1Entries[index];
			StringBuilder sb = new StringBuilder();

			sb.AppendLine(String.Format("End of Animation status: 0x{0:X2}", t.Data[0]));
			sb.AppendLine(String.Format("[01] 0x{0:X2}", t.Data[1]));
			sb.AppendLine(String.Format("[02] 0x{0:X2}", t.Data[2]));
			sb.AppendLine(String.Format("[03] 0x{0:X2}", t.Data[3]));
			sb.AppendLine(String.Format("[04] 0x{0:X2}", t.Data[4]));
			sb.AppendLine(String.Format("[05] 0x{0:X2}", t.Data[5]));
			sb.AppendLine(String.Format("[06] 0x{0:X2}", t.Data[6]));
			sb.AppendLine(String.Format("[07] 0x{0:X2}", t.Data[7]));
			sb.AppendLine(String.Format("[08] 0x{0:X2}", t.Data[8]));
			sb.AppendLine(String.Format("[09] 0x{0:X2}", t.Data[9]));
			sb.AppendLine(String.Format("[0A] 0x{0:X2}", t.Data[10]));
			sb.AppendLine(String.Format("Motion Effect: frame {0}, value 0x{1:X2}", t.Data[11], t.Data[12]));
			sb.AppendLine(String.Format("Camera Effect: frame {0}, value 0x{1:X2}", t.Data[13], t.Data[14]));
			sb.AppendLine(String.Format("[0F] 0x{0:X2}", t.Data[15]));
			sb.AppendLine(String.Format("[10] 0x{0:X2}", t.Data[16]));
			sb.AppendLine(String.Format("[11] 0x{0:X2}", t.Data[17]));
			sb.AppendLine(String.Format("[12] 0x{0:X2}", t.Data[18]));
			sb.AppendLine(String.Format("[13] 0x{0:X2}", t.Data[19]));
			sb.AppendLine(String.Format("Effect 1: frame {0}, value 0x{1:X2}", t.Data[20], t.Data[21]));
			sb.AppendLine(String.Format("Effect 2: frame {0}, value 0x{1:X2}", t.Data[22], t.Data[23]));
			sb.AppendLine(String.Format("Effect 3: frame {0}, value 0x{1:X2}", t.Data[24], t.Data[25]));
			sb.AppendLine(String.Format("Effect 4: frame {0}, value 0x{1:X2}", t.Data[26], t.Data[27]));
			sb.AppendLine(String.Format("Effect 5: frame {0}, value 0x{1:X2}", t.Data[28], t.Data[29]));
			sb.AppendLine(String.Format("Effect 6: frame {0}, value 0x{1:X2}", t.Data[30], t.Data[31]));
			sb.AppendLine(String.Format("Effect 7: frame {0}, value 0x{1:X2}", t.Data[32], t.Data[33]));
			sb.AppendLine(String.Format("Effect 8: frame {0}, value 0x{1:X2}", t.Data[34], t.Data[35]));
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
	}

	public class Toki1Entry
	{
		public byte[] Data;

		public Toki1Entry(BinaryReader br)
		{
			ReadEntry(br);
		}

		public void ReadEntry(BinaryReader br)
		{
			Data = br.ReadBytes(36);
		}
	}
}
