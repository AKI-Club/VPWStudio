using System;
using System.IO;
using System.Drawing;

namespace VPWStudio
{
	/// <summary>
	/// CI8 palette; 256 colors.
	/// </summary>
	public class Ci8Palette
	{
		#region Class Members
		/// <summary>
		/// Palette entries.
		/// </summary>
		/// 512 bytes
		public UInt16[] Entries;
		#endregion

		#region Constructors
		/// <summary>
		/// Default constructor
		/// </summary>
		public Ci8Palette()
		{
			Entries = new UInt16[256];
		}

		/// <summary>
		/// Constructor from BinaryReader.
		/// </summary>
		/// <param name="br">BinaryReader instance to use.</param>
		public Ci8Palette(BinaryReader br)
		{
			Entries = new UInt16[256];
			ReadData(br);
		}
		#endregion

		#region Helpers
		/// <summary>
		/// Set the transparency value for the specified index.
		/// </summary>
		/// <param name="_index">Palette index to change transparency for.</param>
		/// <param name="_transparent">New transparent value.</param>
		public void SetTransparency(int _index, bool _transparent)
		{
			Entries[_index] &= 0xFFFE;
			if (!_transparent)
			{
				Entries[_index] |= 1;
			}
		}
		#endregion

		#region Binary Read/Write
		/// <summary>
		/// Read CI8 palette data with a BinaryReader.
		/// </summary>
		/// <param name="br">BinaryReader instance to use.</param>
		public void ReadData(BinaryReader br)
		{
			for (int i = 0; i < 256; i++)
			{
				byte[] b = br.ReadBytes(2);
				if (BitConverter.IsLittleEndian)
				{
					Array.Reverse(b);
				}
				Entries[i] = BitConverter.ToUInt16(b, 0);
			}
		}

		/// <summary>
		/// Write CI8 palette data with a BinaryWriter.
		/// </summary>
		/// <param name="bw">BinaryWriter instance to use.</param>
		public void WriteData(BinaryWriter bw)
		{
			for (int i = 0; i < 256; i++)
			{
				byte[] b = BitConverter.GetBytes(Entries[i]);
				if (BitConverter.IsLittleEndian)
				{
					Array.Reverse(b);
				}
				bw.Write(b);
			}
		}
		#endregion

		#region JASC Paint Shop Pro Palette Import/Export
		/// <summary>
		/// Export Ci8Palette as a JASC Paint Shop Pro palette file.
		/// </summary>
		/// <param name="sw">StreamWriter to write Palette data to.</param>
		public void ExportJasc(StreamWriter sw)
		{
			sw.WriteLine("JASC-PAL");
			sw.WriteLine("0100");
			sw.WriteLine("256");
			// write colors as RGB
			for (int i = 0; i < Entries.Length; i++)
			{
				Color c = N64Colors.Value5551ToColor(Entries[i]);
				sw.WriteLine(String.Format("{0} {1} {2}", c.R, c.G, c.B));
			}
		}

		/// <summary>
		/// Import Ci8Palette data from a JASC Paint Shop Pro palette file.
		/// </summary>
		/// <param name="sr">StreamReader to read Palette data from.</param>
		/// <returns>True if successful, false otherwise.</returns>
		public bool ImportJasc(StreamReader sr)
		{
			sr.ReadLine(); // "JASC-PAL"
			sr.ReadLine(); // version number

			// number of colors
			int numColors = int.Parse(sr.ReadLine());
			if (numColors != 256)
			{
				return false;
			}

			// color per line
			for (int i = 0; i < numColors; i++)
			{
				string[] colorDef = sr.ReadLine().Split(' ');
				Entries[i] = N64Colors.ColorToValue5551(Color.FromArgb(int.Parse(colorDef[0]), int.Parse(colorDef[1]), int.Parse(colorDef[2])));
			}

			return true;
		}
		#endregion

	}
}
