using System;
using System.Collections.Generic;
using System.IO;
using System.Drawing;

namespace VPWStudio
{
	/// <summary>
	/// CI4 palette; 16 colors.
	/// Can also contain sub-Palettes.
	/// </summary>
	public class Ci4Palette
	{
		#region Class Members
		/// <summary>
		/// Main Palette Entries.
		/// </summary>
		/// 32 bytes
		public UInt16[] Entries;

		/// <summary>
		/// Sub-palettes (only used when the file size is greater than 32 bytes)
		/// </summary>
		public List<Ci4Palette> SubPalettes;
		#endregion

		#region Constructors
		/// <summary>
		/// Default constructor.
		/// </summary>
		public Ci4Palette()
		{
			Entries = new UInt16[16];
			SubPalettes = new List<Ci4Palette>();
		}

		/// <summary>
		/// Constructor from BinaryReader.
		/// </summary>
		/// <param name="br">BinaryReader instance to use.</param>
		public Ci4Palette(BinaryReader br)
		{
			Entries = new UInt16[16];
			SubPalettes = new List<Ci4Palette>();
			ReadData(br);
		}
		#endregion

		#region Helpers
		/// <summary>
		/// Set the transparency value for the specified index.
		/// </summary>
		/// /// <param name="_transparent">New transparent value.</param>
		/// <param name="_index">Palette index to change transparency for.</param>
		/// <param name="_subpalette">Optional subpalette to use.</param>
		public void SetTransparency(bool _transparent, int _index, int _subpalette = 0)
		{
			if (_subpalette > 0)
			{
				_subpalette -= 1; // perform subpalette correction
				SubPalettes[_subpalette].Entries[_index] &= 0xFFFE;
				if (!_transparent)
				{
					SubPalettes[_subpalette].Entries[_index] |= 1;
				}
			}
			else
			{
				Entries[_index] &= 0xFFFE;
				if (!_transparent)
				{
					Entries[_index] |= 1;
				}
			}
		}
		#endregion

		#region Binary Read/Write
		/// <summary>
		/// Read CI4 palette data with a BinaryReader.
		/// </summary>
		/// <param name="br">BinaryReader instance to use.</param>
		/// <param name="handleSubpal">Handle subpalettes? Defaults to false.</param>
		public void ReadData(BinaryReader br, bool handleSubpal = false)
		{
			for (int i = 0; i < 16; i++)
			{
				byte[] b = br.ReadBytes(2);
				if (BitConverter.IsLittleEndian)
				{
					Array.Reverse(b);
				}
				Entries[i] = BitConverter.ToUInt16(b, 0);
			}

			if (handleSubpal)
			{
				int curPos = (int)br.BaseStream.Position;
				br.BaseStream.Seek(0, SeekOrigin.End);
				int endPos = (int)br.BaseStream.Position;

				if (curPos != endPos)
				{
					int numSubPal = (endPos / 32) - 1;
					br.BaseStream.Seek(0x20, SeekOrigin.Begin);
					for (int i = 0; i < numSubPal; i++)
					{
						Ci4Palette subPal = new Ci4Palette();
						for (int j = 0; j < 16; j++)
						{
							byte[] b = br.ReadBytes(2);
							if (BitConverter.IsLittleEndian)
							{
								Array.Reverse(b);
							}
							subPal.Entries[j] = BitConverter.ToUInt16(b, 0);
						}
						SubPalettes.Add(subPal);
					}
				}
			}
		}

		/// <summary>
		/// Write CI4 palette data with a BinaryWriter.
		/// </summary>
		/// <param name="bw">BinaryWriter instance to use.</param>
		public void WriteData(BinaryWriter bw)
		{
			for (int i = 0; i < 16; i++)
			{
				byte[] b = BitConverter.GetBytes(Entries[i]);
				if (BitConverter.IsLittleEndian)
				{
					Array.Reverse(b);
				}
				bw.Write(b);
			}

			// todo: is this correct?
			if (SubPalettes.Count != 0)
			{
				foreach (Ci4Palette p in SubPalettes)
				{
					foreach (UInt16 cv in p.Entries)
					{
						byte[] b = BitConverter.GetBytes(cv);
						if (BitConverter.IsLittleEndian)
						{
							Array.Reverse(b);
						}
						bw.Write(b);
					}
				}
			}
		}
		#endregion

		#region JASC Paint Shop Pro Palette Import/Export
		/// <summary>
		/// Export Ci4Palette as a JASC Paint Shop Pro palette file.
		/// </summary>
		/// <param name="sw">StreamWriter to write Palette data to.</param>
		public void ExportJasc(StreamWriter sw)
		{
			sw.WriteLine("JASC-PAL");
			sw.WriteLine("0100");
			sw.WriteLine("16");
			// write colors as RGB
			for (int i = 0; i < Entries.Length; i++)
			{
				Color c = N64Colors.Value5551ToColor(Entries[i]);
				sw.WriteLine(String.Format("{0} {1} {2}", c.R, c.G, c.B));
			}

			// todo: subpalettes require other files!
		}

		/// <summary>
		/// Import Ci4Palette data from a JASC Paint Shop Pro palette file.
		/// </summary>
		/// <param name="sr">StreamReader to read Palette data from.</param>
		/// <returns>True if successful, false otherwise.</returns>
		public bool ImportJasc(StreamReader sr)
		{
			sr.ReadLine(); // "JASC-PAL"
			sr.ReadLine(); // version number

			// number of colors
			int numColors = int.Parse(sr.ReadLine());
			if (numColors != 16)
			{
				return false;
			}

			// color per line
			for (int i = 0; i < numColors; i++)
			{
				string[] colorDef = sr.ReadLine().Split(' ');
				Entries[i] = N64Colors.ColorToValue5551(Color.FromArgb(int.Parse(colorDef[0]), int.Parse(colorDef[1]), int.Parse(colorDef[2])));
			}

			// todo: subpalettes require other files!

			return true;
		}
		#endregion

	}
}
