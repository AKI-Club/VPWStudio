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
		public void ReadCsv(StreamReader sr)
		{
			// zoinkity's original code
			/*
			def CSVtoVPW2(data, * args):
				from array import array

				# Split at tabs, then strip the last newlines off.
				l = data.split(b'\t')[1:]
				# Create an array with len(lst) entries, each 2 bytes long.
				sz = len(l) << 1

				a, b, t = array('H'), bytearray(), []
				for i in l:
				    a.append(sz + len(b))
				    # This is a bit convoluted for python, but screw it.
				    s = b''.join((i.rsplit(b'\n', 1)[0].rstrip(), b'\x00'))
				    b.extend(s)
					t.append(s)
				# Condense the list, which should have been done before...
				for c, i in enumerate(t) :

					p = b.rfind(i)
					q = a[c] - sz
				    if p == q:
				        p = b.rfind(i, 0, q)
				    if p<0: continue
				    # On a hit, set new index and delete the old reference.
				    l = len(i)
					del b[q:q + l]
					q = a[c]

					a[c] = p + sz
				    for j in range(len(a)) :
				        if a[j] > q:
				            a[j]-=l
				a.byteswap()
				return b''.join((a.tobytes(), b))
				*/

			// each entry is (number)\t(string)
			// the challenging part is that strings can contain newlines (\n),
			// so we have to be careful.
			string csvText = sr.ReadToEnd();
			string[] entries = csvText.Split('\t', '\n');

			int curEntry = 0;
			bool parsingString = false;
			SortedList<int, string> outEntries = new SortedList<int, string>();

			for (int i = 0; i < entries.Length; i++)
			{
				if (parsingString)
				{
					if (!int.TryParse(entries[i], out _))
					{
						if (outEntries.ContainsKey(curEntry))
						{
							outEntries[curEntry] += entries[i];
							parsingString = false;
						}
						else
						{
							outEntries.Add(curEntry, entries[i]);
						}
					}
				}

				if (int.TryParse(entries[i], out curEntry))
				{
					parsingString = true;
				}
			}

			foreach (KeyValuePair<int, string> p in outEntries)
			{
				Console.WriteLine(String.Format("{0} = {1}", p.Key, p.Value));
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
	}
}
