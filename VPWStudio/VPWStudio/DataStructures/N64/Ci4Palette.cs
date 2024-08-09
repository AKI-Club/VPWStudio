using System;
using System.Collections.Generic;
using System.IO;
using System.Drawing;
using System.Globalization;
using System.Text.RegularExpressions;

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

		/// <summary>
		/// Import color data from a List of UInt16 values.
		/// </summary>
		/// <param name="colors">List of UInt16 values to import.</param>
		public void ImportList(List<UInt16> colors)
		{
			if (colors.Count > 16)
			{
				// hard mode
				Entries = colors.GetRange(0, 16).ToArray();

				// handle subpalettes
				SubPalettes = new List<Ci4Palette>();
				int numSubPal = (colors.Count / 16) - 1;
				for (int i = 0; i < numSubPal; i++)
				{
					Ci4Palette newSub = new Ci4Palette();
					newSub.Entries = colors.GetRange(16 * (i + 1), 16).ToArray();
					SubPalettes.Add(newSub);
				}
			}
			else
			{
				// easy mode
				Entries = colors.ToArray();
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

			if (SubPalettes.Count != 0)
			{
				// todo: is this correct, or should I be using a regular for loop?
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

		#region Normal JASC Paint Shop Pro Palette Import/Export
		/// <summary>
		/// Write header data for a JASC Paint Shop Pro palette file.
		/// </summary>
		/// <param name="sw">StreamWriter to write header to.</param>
		private void WriteJascHeader(StreamWriter sw)
		{
			sw.WriteLine("JASC-PAL");
			sw.WriteLine("0100");
			sw.WriteLine("16");
		}

		/// <summary>
		/// Helper for writing a Color to a JASC Paint Shop Pro palette file.
		/// </summary>
		/// <param name="c">Color to write.</param>
		/// <returns>Palette data string</returns>
		private string ColorToJascPalEntry(Color c)
		{
			return String.Format("{0} {1} {2}", c.R, c.G, c.B);
		}

		/// <summary>
		/// Export (main) Ci4Palette as a JASC Paint Shop Pro palette file.
		/// </summary>
		/// <param name="sw">StreamWriter to write Palette data to.</param>
		public void ExportJasc(StreamWriter sw)
		{
			WriteJascHeader(sw);
			for (int i = 0; i < Entries.Length; i++)
			{
				sw.WriteLine(ColorToJascPalEntry(N64Colors.Value5551ToColor(Entries[i])));
			}
		}

		/// <summary>
		/// Export a SubPalette as a JASC Paint Shop Pro palette file.
		/// </summary>
		/// <param name="sw">StreamWriter to write sub-palette data to.</param>
		/// <param name="subPalNum">Sub-palette number to write.</param>
		/// <returns>True if successful, false otherwise.</returns>
		public bool ExportJascSubPal(StreamWriter sw, int subPalNum)
		{
			if (SubPalettes.Count == 0 || subPalNum < 0 || ((subPalNum + 1) > SubPalettes.Count))
			{
				// unable to deal with subpalette
				return false;
			}

			WriteJascHeader(sw);
			Ci4Palette subpalette = SubPalettes[subPalNum];
			for (int i = 0; i < subpalette.Entries.Length; i++)
			{
				sw.WriteLine(ColorToJascPalEntry(N64Colors.Value5551ToColor(subpalette.Entries[i])));
			}

			return true;
		}

		/// <summary>
		/// Import (main) Ci4Palette data from a regular JASC Paint Shop Pro palette file.
		/// </summary>
		/// <param name="sr">StreamReader to read Palette data from.</param>
		/// <returns>True if successful, false otherwise.</returns>
		public bool ImportJasc(StreamReader sr)
		{
			string palType = sr.ReadLine();
			if (!palType.Equals("JASC-PAL"))
			{
				// not JASC PAL
				return false;
			}

			// version number
			string version = sr.ReadLine();
			if (!version.Equals("0100"))
			{
				// unsupported format
				return false;
			}

			// number of colors
			int numColors = int.Parse(sr.ReadLine());
			if (numColors != 16)
			{
				// not valid for CI4
				return false;
			}

			// one color per line
			for (int i = 0; i < numColors; i++)
			{
				string[] colorDef = sr.ReadLine().Split(' ');
				Entries[i] = N64Colors.ColorToValue5551(Color.FromArgb(int.Parse(colorDef[0]), int.Parse(colorDef[1]), int.Parse(colorDef[2])));
			}

			return true;
		}

		/// <summary>
		/// Import SubPalette data from a JASC Paint Shop Pro palette file.
		/// </summary>
		/// <param name="sr"></param>
		/// <param name="subPalNum"></param>
		/// <returns></returns>
		public bool ImportJascSubPal(StreamReader sr, int subPalNum)
		{
			if (SubPalettes.Count == 0 || subPalNum < 0 || ((subPalNum + 1) > SubPalettes.Count))
			{
				// unable to deal with subpalette
				return false;
			}

			string palType = sr.ReadLine();
			if (!palType.Equals("JASC-PAL"))
			{
				// not JASC PAL
				return false;
			}

			// version number
			string version = sr.ReadLine();
			if (!version.Equals("0100"))
			{
				// unsupported format
				return false;
			}

			// number of colors
			int numColors = int.Parse(sr.ReadLine());
			if (numColors != 16)
			{
				// not valid for CI4
				return false;
			}

			if (SubPalettes[subPalNum] == null)
			{
				SubPalettes[subPalNum] = new Ci4Palette();
			}
			// color per line
			for (int i = 0; i < numColors; i++)
			{
				string[] colorDef = sr.ReadLine().Split(' ');
				SubPalettes[subPalNum].Entries[i] = N64Colors.ColorToValue5551(Color.FromArgb(int.Parse(colorDef[0]), int.Parse(colorDef[1]), int.Parse(colorDef[2])));
			}

			return true;
		}
		#endregion

		#region VPW Studio Palette Import/Export
		/*
		 * Notes on modifications to the JASC Paint Shop Pro Palette format:
		 * - Header is now "VPWStudio-PAL"
		 * - Version line is now "0100" for regular CI4 palettes, or "01[num subpals]" for sub-palette support.
		 * - Colors are defined as RGBA instead of RGB.
		 */

		/// <summary>
		/// Write header data for our variant of the JASC Paint Shop Pro palette file.
		/// </summary>
		/// <param name="sw"></param>
		private void WriteVpwsPalHeader(StreamWriter sw)
		{
			sw.WriteLine("VPWStudio-PAL");
			sw.WriteLine(String.Format("01{0:D2}", SubPalettes.Count));
			sw.WriteLine("16");
		}

		/// <summary>
		/// Helper for writing a Color to our variant of the JASC Paint Shop Pro palette file.
		/// </summary>
		/// <param name="c"></param>
		/// <returns></returns>
		private string ColorToCustomVpwsPalEntry(Color c)
		{
			return String.Format("{0} {1} {2} {3}", c.R, c.G, c.B, c.A);
		}

		/// <summary>
		/// Export Ci4Palette to our variant of the JASC Paint Shop Pro palette file.
		/// </summary>
		/// <param name="sw"></param>
		public void ExportVpwsPal(StreamWriter sw)
		{
			WriteVpwsPalHeader(sw);
			for (int i = 0; i < Entries.Length; i++)
			{
				sw.WriteLine(ColorToCustomVpwsPalEntry(N64Colors.Value5551ToColor(Entries[i])));
			}

			// write subpalettes as needed
			if (SubPalettes.Count > 0)
			{
				foreach (Ci4Palette s in SubPalettes)
				{
					for (int i = 0; i < s.Entries.Length; i++)
					{
						sw.WriteLine(ColorToCustomVpwsPalEntry(N64Colors.Value5551ToColor(s.Entries[i])));
					}
				}
			}
		}

		/// <summary>
		/// Import Ci4Palette data from our variant of the JASC Paint Shop Pro palette file.
		/// </summary>
		/// <param name="sr"></param>
		/// <returns></returns>
		public bool ImportVpwsPal(StreamReader sr)
		{
			// header
			string palType = sr.ReadLine();
			if (!palType.Equals("VPWStudio-PAL"))
			{
				return false;
			}

			// version, number of subpalettes
			string version = sr.ReadLine();
			int numSubPal = int.Parse(version.Substring(2));

			// number of colors
			int numColors = int.Parse(sr.ReadLine());
			if (numColors != 16)
			{
				return false;
			}

			// color per line
			for (int i = 0; i < numColors; i++)
			{
				string line = sr.ReadLine();
				if (!line.Equals(string.Empty))
				{
					string[] colorDef = line.Split(' ');
					Entries[i] = N64Colors.ColorToValue5551(Color.FromArgb(int.Parse(colorDef[3]), int.Parse(colorDef[0]), int.Parse(colorDef[1]), int.Parse(colorDef[2])));
				}
			}

			// subpalettes
			if (numSubPal > 0)
			{
				SubPalettes = new List<Ci4Palette>();
				for (int i = 0; i < numSubPal; i++)
				{
					Ci4Palette sub = new Ci4Palette();
					for (int j = 0; j < numColors; j++)
					{
						string line = sr.ReadLine();
						if (!line.Equals(string.Empty))
						{
							string[] colorDef = line.Split(' ');
							sub.Entries[j] = N64Colors.ColorToValue5551(Color.FromArgb(int.Parse(colorDef[3]), int.Parse(colorDef[0]), int.Parse(colorDef[1]), int.Parse(colorDef[2])));
						}
					}
					SubPalettes.Add(sub);
				}
			}

			return true;
		}
		#endregion

		#region GIMP Palette (.gpl file) Import/Export
		/// <summary>
		/// Write header data for a GIMP palette file.
		/// </summary>
		/// <param name="sw">StreamWriter to write header to.</param>
		private void WriteGimpHeader(StreamWriter sw, string _name)
		{
			sw.WriteLine("GIMP Palette");
			sw.WriteLine(String.Format("Name: {0}", _name));
			sw.WriteLine("Columns: 16");
			sw.WriteLine("#");
		}

		/// <summary>
		/// Check header data for a GIMP palette file.
		/// </summary>
		/// <param name="sr"></param>
		/// <returns></returns>
		private bool CheckGimpHeader(StreamReader sr)
		{
			// check for "GIMP Palette"
			string palType = sr.ReadLine();
			if (!palType.Equals("GIMP Palette"))
			{
				// not GIMP Palette
				return false;
			}

			// "Name: " name
			string nameLine = sr.ReadLine();
			if (!nameLine.StartsWith("Name:"))
			{
				return false;
			}

			// "Columns: " number of columns
			string columnsLine = sr.ReadLine();
			if (!columnsLine.StartsWith("Columns:"))
			{
				return false;
			}

			// #
			string separator = sr.ReadLine();
			if (!separator.Equals("#"))
			{
				return false;
			}

			return true;
		}

		/// <summary>
		/// Export (main) Ci4Palette as a GIMP palette file.
		/// </summary>
		/// <param name="sw">StreamWriter to write Palette data to.</param>
		public void ExportGimp(StreamWriter sw, string _name)
		{
			WriteGimpHeader(sw, _name);
			for (int i = 0; i < Entries.Length; i++)
			{
				sw.WriteLine( String.Format("{0}\tUntitled", ColorToJascPalEntry(N64Colors.Value5551ToColor(Entries[i]))) );
			}
		}

		/// <summary>
		/// Export a SubPalette as a GIMP palette file.
		/// </summary>
		/// <param name="sw">StreamWriter to write sub-palette data to.</param>
		/// <param name="subPalNum">Sub-palette number to write.</param>
		/// <returns>True if successful, false otherwise.</returns>
		public bool ExportGimpSubPal(StreamWriter sw, int subPalNum, string _name)
		{
			if (SubPalettes.Count == 0 || subPalNum < 0 || ((subPalNum + 1) > SubPalettes.Count))
			{
				// unable to deal with subpalette
				return false;
			}

			WriteGimpHeader(sw, string.Format("File ID 0x{0} subpal {1}", _name, subPalNum));
			Ci4Palette subpalette = SubPalettes[subPalNum];
			for (int i = 0; i < subpalette.Entries.Length; i++)
			{
				sw.WriteLine( String.Format("{0}\tUntitled", ColorToJascPalEntry(N64Colors.Value5551ToColor(subpalette.Entries[i]))) );
			}

			return true;
		}

		/// <summary>
		/// Import (main) Ci4Palette data from a GIMP palette file.
		/// </summary>
		/// <param name="sr">StreamReader to read Palette data from.</param>
		/// <returns>True if successful, false otherwise.</returns>
		public bool ImportGimp(StreamReader sr)
		{
			if (!CheckGimpHeader(sr))
			{
				return false;
			}

			// color entries
			// normally, read until end of file; however, we only want 16 colors.
			// also, the numbers might be spaced out for formatting purposes,
			// so we want to ignore that.

			int palEntry = 0;
			while(!sr.EndOfStream){
				string colorLine = sr.ReadLine().Trim(new char[] { ' ' });

				// deal with possible color names
				int tabLoc = colorLine.IndexOf('\t');
				if (tabLoc > -1)
				{
					colorLine = colorLine.Substring(0, tabLoc);
				}

				// deal with extra spaces
				colorLine = Regex.Replace(colorLine, @"\s{2,}", " ");

				string[] colorDef = colorLine.Split(' ');
				Entries[palEntry] = N64Colors.ColorToValue5551(Color.FromArgb(int.Parse(colorDef[0]), int.Parse(colorDef[1]), int.Parse(colorDef[2])));
				palEntry++;
			}

			return true;
		}

		/// <summary>
		/// Import SubPalette data from a GIMP palette file.
		/// </summary>
		/// <param name="sr"></param>
		/// <param name="subPalNum"></param>
		/// <returns></returns>
		public bool ImportGimpSubPal(StreamReader sr, int subPalNum)
		{
			if (!CheckGimpHeader(sr))
			{
				return false;
			}

			// color entries
			// kind of like the above, but with subpalettes

			if (SubPalettes[subPalNum] == null)
			{
				SubPalettes[subPalNum] = new Ci4Palette();
			}

			int palEntry = (subPalNum * 16);
			while (!sr.EndOfStream)
			{
				string colorLine = sr.ReadLine().Trim(new char[] { ' ' });

				// deal with possible color names
				int tabLoc = colorLine.IndexOf('\t');
				if (tabLoc > -1)
				{
					colorLine = colorLine.Substring(0, tabLoc);
				}

				// deal with extra spaces
				colorLine = Regex.Replace(colorLine, @"\s{2,}", " ");

				string[] colorDef = colorLine.Split(' ');
				SubPalettes[subPalNum].Entries[palEntry] = N64Colors.ColorToValue5551(Color.FromArgb(int.Parse(colorDef[0]), int.Parse(colorDef[1]), int.Parse(colorDef[2])));
				palEntry++;
			}

			return true;
		}
		#endregion

		#region Photoshop ACT Palette Import/Export
		// If the file is 772 bytes long, there are 4 additional bytes remaining.
		// Two bytes for the number of colors to use.
		// Two bytes for the color index with the transparency color to use.

		/// <summary>
		/// Exports main palette as Adobe ACT format.
		/// </summary>
		/// <param name="bw">BinaryWriter instance to use.</param>
		public void ExportAct(BinaryWriter bw)
		{
			// dump out the main colors
			for (int i = 0; i < Entries.Length; i++)
			{
				Color c = N64Colors.Value5551ToColor(Entries[i]);
				bw.Write(c.R);
				bw.Write(c.G);
				bw.Write(c.B);
			}

			// todo: subpalettes?
			// todo: number of colors, transparent index
		}

		/// <summary>
		/// Imports main palette from an Adobe ACT format palette.
		/// </summary>
		/// <param name="br">BinaryReader instance to use.</param>
		/// <returns>true</returns>
		public bool ImportAct(BinaryReader br)
		{
			// xxx: shitty assumption that doesn't take subpalettes into account
			int numColors = 16;

			int transparentIndex = -1;

			// figure out file size first, 768 for generic or 772 for numcolors+transparency
			if (br.BaseStream.Length == 772)
			{
				br.BaseStream.Seek(768, SeekOrigin.Begin);

				// read number of colors, transparency index
				numColors = br.ReadInt16();
				transparentIndex = br.ReadInt16();

				br.BaseStream.Seek(0, SeekOrigin.Begin);
			}

			// read colors as normal
			for (int i = 0; i < numColors; i++)
			{
				byte r = br.ReadByte();
				byte g = br.ReadByte();
				byte b = br.ReadByte();
				// check for transparent index
				if (transparentIndex != -1 && i == transparentIndex)
				{
					Entries[i] = N64Colors.ColorToValue5551(Color.FromArgb(0, r, g, b));
				}
				else
				{
					Entries[i] = N64Colors.ColorToValue5551(Color.FromArgb(255, r, g, b));
				}
			}

			return true;
		}
		#endregion

		#region GIMP Text Palette Import/Export
		/// <summary>
		/// Export a CI4 palette to GIMP's .txt palette format.
		/// </summary>
		/// <param name="sw">StreamWriter instance to use.</param>
		public void ExportGimpText(StreamWriter sw)
		{
			sw.NewLine = "\n";
			foreach (ushort c in Entries)
			{
				Color curColor = N64Colors.Value5551ToColor(c);
				sw.WriteLine(String.Format("#{0:x2}{1:x2}{2:x2}", curColor.R, curColor.G, curColor.B));
			}
		}

		/// <summary>
		/// Export a CI4 sub-palette to GIMP's .txt palette format.
		/// </summary>
		/// <param name="sw">StreamWriter instance to use.</param>
		/// <param name="subPalNum">Sub-palette number to write.</param>
		/// <returns>True if successful, false otherwise.</returns>
		public bool ExportGimpTextSubPal(StreamWriter sw, int subPalNum)
		{
			if (SubPalettes.Count == 0 || subPalNum < 0 || ((subPalNum + 1) > SubPalettes.Count))
			{
				// unable to deal with subpalette
				return false;
			}

			sw.NewLine = "\n";
			Ci4Palette subpalette = SubPalettes[subPalNum];
			for (int i = 0; i < subpalette.Entries.Length; i++)
			{
				Color curColor = N64Colors.Value5551ToColor(subpalette.Entries[i]);
				sw.WriteLine(String.Format("#{0:x2}{1:x2}{2:x2}", curColor.R, curColor.G, curColor.B));
			}

			return true;
		}

		/// <summary>
		/// Import a CI4 palette from GIMP's .txt palette format.
		/// </summary>
		/// <param name="sr">StreamReader instance to use.</param>
		/// <returns>True if successful (or even if not...)</returns>
		public bool ImportGimpText(StreamReader sr)
		{
			int numEntries = 0;
			while (!sr.EndOfStream)
			{
				string colString = sr.ReadLine();
				if (string.IsNullOrEmpty(colString))
				{
					continue;
				}

				// #rrggbb
				int r = int.Parse(colString.Substring(1, 2), NumberStyles.HexNumber);
				int g = int.Parse(colString.Substring(3, 2), NumberStyles.HexNumber);
				int b = int.Parse(colString.Substring(5, 2), NumberStyles.HexNumber);

				// handle ad-hoc transparency if available (not an official part of the GIMP format)
				bool hasTransparency = colString.Length > 7;

				if (hasTransparency)
				{
					int a = int.Parse(colString.Substring(7, 2), NumberStyles.HexNumber);
					Entries[numEntries] = N64Colors.ColorToValue5551(Color.FromArgb(a > 0 ? 255 : 0, r, g, b));
				}
				else
				{
					Entries[numEntries] = N64Colors.ColorToValue5551(Color.FromArgb(r, g, b));
				}

				++numEntries;
			}

			// handle files with fewer than 16 colors by forcing missing entries to transparent
			if (numEntries < 16)
			{
				int diff = 16 - numEntries;
				for (int i = 0; i < diff; i++)
				{
					Entries[numEntries + i] = 0;
				}
			}

			return true;
		}

		/// <summary>
		/// Import a CI4 sub-palette from GIMP's .txt palette format.
		/// </summary>
		/// <param name="sr">StreamReader instance to use.</param>
		/// <param name="subPalNum">Sub-palette number to import to.</param>
		/// <returns>True if successful (or even if not...)</returns>
		public bool ImportGimpTextSubPal(StreamReader sr, int subPalNum)
		{
			int numEntries = 0;
			while (!sr.EndOfStream)
			{
				string colString = sr.ReadLine();
				if (string.IsNullOrEmpty(colString))
				{
					continue;
				}

				// #rrggbb
				int r = int.Parse(colString.Substring(1, 2), NumberStyles.HexNumber);
				int g = int.Parse(colString.Substring(3, 2), NumberStyles.HexNumber);
				int b = int.Parse(colString.Substring(5, 2), NumberStyles.HexNumber);

				// handle ad-hoc transparency if available (not an official part of the GIMP format)
				bool hasTransparency = colString.Length > 7;

				if (hasTransparency)
				{
					int a = int.Parse(colString.Substring(7, 2), NumberStyles.HexNumber);
					SubPalettes[subPalNum].Entries[numEntries] = N64Colors.ColorToValue5551(Color.FromArgb(a > 0 ? 255 : 0, r, g, b));
				}
				else
				{
					SubPalettes[subPalNum].Entries[numEntries] = N64Colors.ColorToValue5551(Color.FromArgb(r, g, b));
				}

				++numEntries;
			}

			// handle files with fewer than 16 colors by forcing missing entries to transparent
			if (numEntries < 16)
			{
				int diff = 16 - numEntries;
				for (int i = 0; i < diff; i++)
				{
					SubPalettes[subPalNum].Entries[numEntries + i] = 0;
				}
			}

			return true;
		}
		#endregion
	}
}
