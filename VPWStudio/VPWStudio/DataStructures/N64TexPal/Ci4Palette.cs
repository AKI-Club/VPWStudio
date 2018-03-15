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
		// 32 bytes
		public UInt16[] Entries;

		/// <summary>
		/// Sub-palettes (only used when the file size is greater than 32 bytes)
		/// </summary>
		public List<Ci4Palette> SubPalettes;

		/// <summary>
		/// Default constructor.
		/// </summary>
		public Ci4Palette()
		{
			this.Entries = new UInt16[16];
			this.SubPalettes = new List<Ci4Palette>();
		}

		/// <summary>
		/// Constructor from BinaryReader.
		/// </summary>
		/// <param name="br">BinaryReader instance to use.</param>
		public Ci4Palette(BinaryReader br)
		{
			this.Entries = new UInt16[16];
			this.SubPalettes = new List<Ci4Palette>();
			this.ReadData(br);
		}

		#region Read/Write Data
		/// <summary>
		/// Read CI4 palette data with a BinaryReader.
		/// </summary>
		/// <param name="br">BinaryReader instance to use.</param>
		public void ReadData(BinaryReader br, bool handleSubpal = false)
		{
			for (int i = 0; i < 16; i++)
			{
				byte[] b = br.ReadBytes(2);
				if (BitConverter.IsLittleEndian)
				{
					Array.Reverse(b);
				}
				this.Entries[i] = BitConverter.ToUInt16(b, 0);
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
						this.SubPalettes.Add(subPal);
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
				byte[] b = BitConverter.GetBytes(this.Entries[i]);
				if (BitConverter.IsLittleEndian)
				{
					Array.Reverse(b);
				}
				bw.Write(b);
			}

			// todo: is this correct?
			if (this.SubPalettes.Count != 0)
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

		#region JASC Palette Import/Export
		// xxx: this relies on N64Colors.ValueToColor5551
		public void ExportJasc(StreamWriter sw)
		{
			sw.WriteLine("JASC-PAL");
			sw.WriteLine("0100");
			sw.WriteLine("16");
			// write colors as RGB
			for (int i = 0; i < this.Entries.Length; i++)
			{
				Color c = N64Colors.Value5551ToColor(this.Entries[i]);
				sw.WriteLine(String.Format("{0} {1} {2}", c.R, c.G, c.B));
			}

			// todo: subpalettes require other junk!
		}
		#endregion

	}
}
