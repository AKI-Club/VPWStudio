using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace VPWStudio
{
	/// <summary>
	/// A single entry in an AkiText archive.
	/// </summary>
	public class AkiTextEntry
	{
		public UInt16 Location;
		public string Text;

		public AkiTextEntry(UInt16 _l, string _s)
		{
			Location = _l;
			Text = _s;
		}
	}

	/// <summary>
	/// AkiText archive.
	/// </summary>
	public class AkiText
	{
		/// <summary>
		/// Entries in this AkiText archive.
		/// </summary>
		public SortedList<int, AkiTextEntry> Entries;

		/// <summary>
		/// Default constructor.
		/// </summary>
		public AkiText()
		{
			Entries = new SortedList<int, AkiTextEntry>();
		}

		/// <summary>
		/// Create from a BinaryReader instance.
		/// </summary>
		/// <param name="br">BinaryReader instance to use.</param>
		public AkiText(BinaryReader br)
		{
			Entries = new SortedList<int, AkiTextEntry>();
			ReadData(br);
		}

		/// <summary>
		/// Deep copy an existing AkiText instance.
		/// </summary>
		/// <param name="_src">AkiText instance to copy.</param>
		public void DeepCopy(AkiText _src)
		{
			Entries = new SortedList<int, AkiTextEntry>();
			foreach (KeyValuePair<int, AkiTextEntry> e in _src.Entries)
			{
				Entries.Add(e.Key, new AkiTextEntry(e.Value.Location, e.Value.Text));
			}
		}

		/// <summary>
		/// Get the string for a specific entry.
		/// </summary>
		/// <param name="id">String ID to get.</param>
		/// <returns>String for the specified entry, or String.Empty if invalid.</returns>
		public string GetEntry(int id)
		{
			if (id < 0 || id >= Entries.Count)
			{
				return String.Empty;
			}
			return Entries[id].Text;
		}

		#region Binary Read/Write
		/// <summary>
		/// Encode AkiText binary format.
		/// </summary>
		/// <param name="bw">BinaryWriter instance to use.</param>
		public void WriteData(BinaryWriter bw)
		{
			// the pointers themselves need to be calculated based on the string lengths.
			int startLoc = (Entries.Count * 2);

			// adjust for terminator if needed
			if (Entries.Count % 2 != 0)
			{
				startLoc += 2;
			}

			int curLoc = startLoc;
			for (int i = 0; i < Entries.Count; i++)
			{
				Entries[i].Location = (UInt16)curLoc;
				curLoc += (Encoding.GetEncoding("shift_jis").GetBytes(Entries[i].Text).Length + 1);
			}

			// write out the pointer table
			for (int i = 0; i < Entries.Count; i++)
			{
				byte[] l = BitConverter.GetBytes(Entries[i].Location);
				if (BitConverter.IsLittleEndian)
				{
					Array.Reverse(l);
				}
				bw.Write(l);
			}

			// insert alignment/terminator as needed
			if (Entries.Count % 2 != 0)
			{
				bw.Write((UInt16)0);
			}

			// then write out the strings
			for (int i = 0; i < Entries.Count; i++)
			{
				bw.Write(Encoding.GetEncoding("shift_jis").GetBytes(Entries[i].Text));
				bw.Write((byte)0);
			}
		}

		/// <summary>
		/// Decode AkiText binary format.
		/// </summary>
		/// <param name="br">BinaryReader instance to use.</param>
		public void ReadData(BinaryReader br)
		{
			// figure out file size, because some files don't end on an 0x00 byte; they just implicitly end...
			br.BaseStream.Seek(0, SeekOrigin.End);
			int fileSize = 0;
			fileSize = (int)br.BaseStream.Position;
			br.BaseStream.Seek(0, SeekOrigin.Begin);

			// Figure out table size
			byte[] tsb = br.ReadBytes(2);
			if (BitConverter.IsLittleEndian)
			{
				Array.Reverse(tsb);
			}
			UInt16 tableSize = BitConverter.ToUInt16(tsb, 0);
			// rewind
			br.BaseStream.Seek(-2, SeekOrigin.Current);

			// grab list of locations
			List<UInt16> Locations = new List<UInt16>();
			UInt16 entryPointer = 0;
			int entry = 0;
			do
			{
				byte[] epb = br.ReadBytes(2);
				if (BitConverter.IsLittleEndian)
				{
					Array.Reverse(epb);
				}
				entryPointer = BitConverter.ToUInt16(epb, 0);

				if (entryPointer != 0)
				{
					Locations.Add(entryPointer);
				}
				entry+=2;

			} while (entry < tableSize);

			// add entries
			int i = 0;
			foreach (UInt16 l in Locations)
			{
				// handle "pointer at end of file" awkwardness
				if (l >= fileSize)
				{
					continue;
				}

				br.BaseStream.Seek(l, SeekOrigin.Begin);

				int strLen = 0;
				while (br.ReadByte() != 0)
				{
					strLen++;
					// if we're at the end of the file, that also counts as the end of the string.
					if (br.BaseStream.Position == fileSize)
					{
						break;
					}
				}
				br.BaseStream.Seek(l, SeekOrigin.Begin);
				byte[] strBytes = br.ReadBytes(strLen);
				this.Entries.Add(i, new AkiTextEntry(l, Encoding.GetEncoding("shift_jis").GetString(strBytes, 0, strLen)));
				i++;
			}
		}
		#endregion

		#region CSV Read/Write
		/// <summary>
		/// Read AkiText from a tab-delimited CSV file.
		/// </summary>
		/// <param name="sr">StreamReader instance to use.</param>
		public void ReadCsv(StreamReader sr)
		{
			// each entry is (number)\t(string)
			// the challenging part is that strings can contain newlines (\n), so we have to be careful.

			int curEntry = 0;
			while (!sr.EndOfStream)
			{
				string curLine = sr.ReadLine();
				if (curLine.Contains("\t"))
				{
					string[] tok = curLine.Split('\t');
					if (int.TryParse(tok[0], out curEntry))
					{
						Entries.Add(curEntry, new AkiTextEntry(0, tok[1]));
					}
				}
				else
				{
					// continued from previous entry
					Entries[curEntry].Text += "\n" + curLine;
				}
			}

			// fix up locations
			int startLoc = (Entries.Count * 2);

			// adjust for terminator if needed
			if (Entries.Count % 2 != 0)
			{
				startLoc += 2;
			}

			int curLoc = startLoc;
			for (int i = 0; i < Entries.Count; i++)
			{
				Entries[i].Location = (UInt16)curLoc;
				curLoc += (Encoding.GetEncoding("shift_jis").GetBytes(Entries[i].Text).Length + 1);
			}
		}

		/// <summary>
		/// Write out AkiText to a tab-delimited CSV file.
		/// </summary>
		/// <param name="sw">StreamWriter instance to use.</param>
		public void WriteCsv(StreamWriter sw)
		{
			for (int i = 0; i < Entries.Count; i++)
			{
				sw.WriteLine(String.Format("{0}\t{1}", i, Entries[i].Text));
			}
		}
		#endregion

		#region akitext Command Line Tool Import/Export
		/// <summary>
		/// Parsing mode for akitext Command Line Tool format import
		/// </summary>
		private enum ToolParseMode
		{
			CheckOpenBracket,
			GetString,
			CheckCloseBracket
		};

		/// <summary>
		/// Read AkiText from a format compatible with the "akitext" command line tool.
		/// </summary>
		/// <param name="sr">StreamReader instance to use.</param>
		public void ReadToolImport(StreamReader sr)
		{
			ToolParseMode parseMode = ToolParseMode.CheckOpenBracket;
			int curEntry = 0;
			string outString = "";

			while (!sr.EndOfStream)
			{
				char c = (char)sr.Read();
				switch (parseMode)
				{
					case ToolParseMode.CheckOpenBracket:
						if (c == '{')
						{
							if ((char)sr.Peek() == '\"')
							{
								parseMode = ToolParseMode.GetString;
								outString = String.Empty;
								sr.Read();
							}
						}
						break;

					case ToolParseMode.GetString:
						if (c == '\"')
						{
							parseMode = ToolParseMode.CheckCloseBracket;
						}
						else
						{
							outString += (char)c;
						}
						break;

					case ToolParseMode.CheckCloseBracket:
						if (c == '}')
						{
							parseMode = ToolParseMode.CheckOpenBracket;
							Entries.Add(curEntry++, new AkiTextEntry(0, outString));
						}
						else if (c == '\"')
						{
							// ends in double quote
							outString += (char)c;
						}
						else
						{
							outString += '\"' + (char)c;
							parseMode = ToolParseMode.GetString;
						}
						break;
				}
			}

			// generate location table
			int startLoc = (Entries.Count * 2);

			// adjust for terminator if needed
			if (Entries.Count % 2 != 0)
			{
				startLoc += 2;
			}

			int curLoc = startLoc;
			for (int i = 0; i < Entries.Count; i++)
			{
				Entries[i].Location = (UInt16)curLoc;
				curLoc += (Encoding.GetEncoding("shift_jis").GetBytes(Entries[i].Text).Length + 1);
			}
		}

		/// <summary>
		/// Write out AkiText to a format compatible with the "akitext" command line tool.
		/// </summary>
		/// <param name="sw">StreamWriter instance to use.</param>
		public void WriteToolExport(StreamWriter sw)
		{
			// entry format: {"string"}
			for (int i = 0; i < Entries.Count; i++)
			{
				sw.Write("{\"");
				sw.Write(Entries[i].Text);
				sw.WriteLine("\"}");
			}
		}
		#endregion
	}
}
