using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace VPWStudio
{
	/*
	 * from offsetter by Zoinkity (python code):
	 
		def VPW2toCSV(data, *args):
			from array import array

			# Expects binary data as output, so encode position strings.
			n = int.from_bytes(data[0:2], byteorder='big', signed=False)
			a = array("H", data[0:n])
			a.byteswap()

			out = bytearray()
			for c, i in enumerate(a):
				if i:
					try:
						p = data.index(0, i)
						s = data[i:p]
					except ValueError:
						s = data[i:]
				else:
					s = b''
			##out.extend("{:d}\t".format(c).encode(encoding="shift_jis"))
			##out.extend(b''.join((s, b'\n')))
			out.extend(b''.join(((str(c).encode(encoding='shift_jis'), b'\t', s, b'\n'))))

	 */

	// ok so freem let's talk about this. the files go something like this:
	// first there's a table of two byte pointers into the file, ending with 0x0000.
	// each string is Shift-JIS; I know how much you love that.

	// the first entry doubles as the size of the table.
	public class AkiText
	{
		public SortedList<uint, string> Strings = new SortedList<uint, string>();

		public void Decode(BinaryReader br)
		{
			byte[] tsb = br.ReadBytes(2);
			if (BitConverter.IsLittleEndian)
			{
				Array.Reverse(tsb);
			}
			UInt16 tableSize = BitConverter.ToUInt16(tsb, 0);
			// rewind
			br.BaseStream.Seek(-2, SeekOrigin.Current);

			List<uint> Locations = new List<uint>();

			UInt16 entryPointer = 1;
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

			} while (entryPointer != 0);

			foreach (uint l in Locations)
			{
				br.BaseStream.Seek(l, SeekOrigin.Begin);

				int strLen = 0;
				while (br.ReadByte() != 0)
				{
					strLen++;
				}
				br.BaseStream.Seek(l, SeekOrigin.Begin);
				byte[] strBytes = br.ReadBytes(strLen);

				this.Strings.Add(l, Encoding.GetEncoding("shift_jis").GetString(strBytes, 0, strLen).Normalize(NormalizationForm.FormKC));
			}
		}
	}
}
