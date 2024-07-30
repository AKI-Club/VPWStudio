using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace VPWStudio
{
	public partial class GlobalTextEditor : Form
	{
		/// <summary>
		/// Global String entries.
		/// </summary>
		public List<string> GlobalStrings = new List<string>();

		/// <summary>
		/// Pointers to Global String entries.
		/// </summary>
		public List<UInt32> Pointers = new List<UInt32>();

		/// <summary>
		/// Base ROM address of Global Text entries.
		/// </summary>
		private UInt32 BaseRomAddr = 0;

		/// <summary>
		/// First non-null pointer to a string.
		/// </summary>
		private UInt32 FirstPointer = 0;

		/// <summary>
		/// Global Text Editor
		/// </summary>
		/// <param name="selIndex">Optional index to select.</param>
		public GlobalTextEditor(int selIndex = -1)
		{
			InitializeComponent();
			LoadEntries();
			if (selIndex != -1)
			{
				cbEntriesTemp.SelectedIndex = Math.Min(selIndex,cbEntriesTemp.Items.Count);
			}
			else
			{
				cbEntriesTemp.SelectedIndex = 0;
			}
		}

		private void LoadEntries()
		{
			Program.ReloadBaseRom();
			Encoding sjis = Encoding.GetEncoding("shift_jis");
			MemoryStream ms = new MemoryStream(Program.CurrentInputROM.Data);
			BinaryReader br = new BinaryReader(ms, sjis);

			bool hasMainGT = false;
			bool hasPtrGT = false;
			int numPointers = 0;
			int gtTotalLength = 0;
			if (Program.CurLocationFile != null)
			{
				LocationFileEntry gtStartEntry = Program.CurLocationFile.GetEntryFromComment(LocationFile.SpecialEntryStrings["GlobalText_Start"]);
				if (gtStartEntry != null)
				{
					BaseRomAddr = gtStartEntry.Address;
					br.BaseStream.Seek(gtStartEntry.Address, SeekOrigin.Begin);
					gtTotalLength = gtStartEntry.Length;
					hasMainGT = true;
				}

				LocationFileEntry gtPtrEntry = Program.CurLocationFile.GetEntryFromComment(LocationFile.SpecialEntryStrings["GlobalText_Pointers"]);
				if (gtPtrEntry != null)
				{
					br.BaseStream.Seek(gtPtrEntry.Address, SeekOrigin.Begin);
					numPointers = gtPtrEntry.Length / 4;
					hasPtrGT = true;
				}
			}

			if (!hasMainGT)
			{
				// fallback to hardcoded start offset
				DefaultGameData.DefaultLocationDataEntry startEntry = DefaultGameData.DefaultLocations[Program.CurrentProject.Settings.GameType].Locations["GlobalText_Start"];
				BaseRomAddr = startEntry.Offset;
				br.BaseStream.Seek(startEntry.Offset, SeekOrigin.Begin);
				gtTotalLength = (int)startEntry.Length;
			}
			if (!hasPtrGT)
			{
				// fallback to hardcoded pointer offset
				DefaultGameData.DefaultLocationDataEntry pointerEntry = DefaultGameData.DefaultLocations[Program.CurrentProject.Settings.GameType].Locations["GlobalText_Pointers"];
				br.BaseStream.Seek(pointerEntry.Offset, SeekOrigin.Begin);
				numPointers = (int)(pointerEntry.Length / 4);
			}

			// read pointer list; first entry is often null
			for (int i = 0; i < numPointers; i++)
			{
				byte[] ptrBytes = br.ReadBytes(4);
				if (BitConverter.IsLittleEndian)
				{
					Array.Reverse(ptrBytes);
				}
				Pointers.Add(BitConverter.ToUInt32(ptrBytes,0));
			}

			FirstPointer = Pointers[1];

			// read entries...following the pointers would be "best".
			// Warning: some strings could be Shift-JIS encoded.
			List<byte> tempStr;
			for (int i = 0; i < Pointers.Count; i++)
			{
				if (Pointers[i] == 0)
				{
					// don't bother following null pointers
					GlobalStrings.Add(String.Empty);
				}
				else
				{
					// calculate ROM address
					br.BaseStream.Seek(BaseRomAddr + (Pointers[i] - FirstPointer), SeekOrigin.Begin);

					// read string
					tempStr = new List<byte>();
					while (br.PeekChar() != 0)
					{
						tempStr.Add(br.ReadByte());
					}
					GlobalStrings.Add(sjis.GetString(tempStr.ToArray()));
				}
			}

			br.Close();

			lblDataLength.Text = String.Format("Data must not exceed {0} (0x{0:X}) bytes!", gtTotalLength);

			// populate dropdown list
			cbEntriesTemp.BeginUpdate();
			for (int i = 0; i < Pointers.Count; i++)
			{
				cbEntriesTemp.Items.Add(String.Format("[0x{1:X4}] {0:X8}", Pointers[i], i));
			}
			cbEntriesTemp.EndUpdate();
		}

		private void btnCancel_Click(object sender, EventArgs e)
		{
			DialogResult = DialogResult.Cancel;
			Close();
		}

		private void btnOK_Click(object sender, EventArgs e)
		{
			DialogResult = DialogResult.OK;
			Close();
		}

		private void cbEntriesTemp_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (cbEntriesTemp.SelectedIndex < 0)
			{
				return;
			}

			
			tbOutputTemp.Text = GlobalStrings[cbEntriesTemp.SelectedIndex].Replace("\n",Environment.NewLine);
		}
	}
}
