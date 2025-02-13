﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Drawing;
using System.Globalization;
using System.Text.RegularExpressions;

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

		/// <summary>
		/// Import color data from a List of UInt16 values.
		/// </summary>
		/// <param name="colors">List of UInt16 values to import.</param>
		public void ImportList(List<UInt16> colors)
		{
			Entries = colors.ToArray();
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
		/// Helper for writing a Color to a JASC Paint Shop Pro palette file.
		/// </summary>
		/// <param name="c">Color to write.</param>
		/// <returns>Palette data string</returns>
		private string ColorToJascPalEntry(Color c)
		{
			return String.Format("{0} {1} {2}", c.R, c.G, c.B);
		}

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
				sw.WriteLine(ColorToJascPalEntry(N64Colors.Value5551ToColor(Entries[i])));
			}
		}

		/// <summary>
		/// Import Ci8Palette data from a JASC Paint Shop Pro palette file.
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

		#region VPW Studio Palette Import/Export
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
		/// Export Ci8Palette to our variant of the JASC Paint Shop Pro palette file.
		/// </summary>
		/// <param name="sw"></param>
		public void ExportVpwsPal(StreamWriter sw)
		{
			sw.WriteLine("VPWStudio-PAL");
			sw.WriteLine("0100");
			sw.WriteLine("256");
			for (int i = 0; i < Entries.Length; i++)
			{
				sw.WriteLine(ColorToCustomVpwsPalEntry(N64Colors.Value5551ToColor(Entries[i])));
			}
		}

		/// <summary>
		/// Import Ci8Palette data from our variant of the JASC Paint Shop Pro palette file.
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

			// version
			sr.ReadLine();

			// number of colors
			int numColors = int.Parse(sr.ReadLine());
			if (numColors != 256)
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
		/// Export Ci8Palette as a GIMP palette file.
		/// </summary>
		/// <param name="sw"></param>
		/// <param name="_name"></param>
		public void ExportGimp(StreamWriter sw, string _name)
		{
			WriteGimpHeader(sw, _name);
			for (int i = 0; i < Entries.Length; i++)
			{
				sw.WriteLine( String.Format("{0}\tUntitled", ColorToJascPalEntry(N64Colors.Value5551ToColor(Entries[i]))) );
			}
		}

		/// <summary>
		/// Import Ci8Palette data from a GIMP palette file.
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
			// unlike CI4, we want all the colors. hopefully there are 256 of them in this file.
			int palEntry = 0;
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
				Entries[palEntry] = N64Colors.ColorToValue5551(Color.FromArgb(int.Parse(colorDef[0]), int.Parse(colorDef[1]), int.Parse(colorDef[2])));
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
		/// Exports palette as Adobe ACT format.
		/// </summary>
		/// <param name="bw">BinaryWriter instance to use.</param>
		public void ExportAct(BinaryWriter bw)
		{
			// for the most part, you can dump out the RGB colors.
			for (int i = 0; i < Entries.Length; i++)
			{
				Color c = N64Colors.Value5551ToColor(Entries[i]);
				bw.Write(c.R);
				bw.Write(c.G);
				bw.Write(c.B);
			}

			// something about number of colors and transparent index
		}

		/// <summary>
		/// Import Ci4Palette from Adobe ACT format.
		/// </summary>
		/// <param name="br">BinaryReader instance to use</param>
		/// <returns></returns>
		public bool ImportAct(BinaryReader br)
		{
			int numColors = 256; // dumb assumption but ok
			int transparentIndex = -1; // -1 means "none", but this could just be me making it up

			// figure out file size first, 768 for generic or 772 for numcolors+transparency
			if (br.BaseStream.Length == 772)
			{
				br.BaseStream.Seek(768, SeekOrigin.Begin);

				// read number of colors, transparency index
				numColors = br.ReadUInt16();
				transparentIndex = br.ReadInt16();

				br.BaseStream.Seek(0, SeekOrigin.Begin);
			}

			// read colors as normal
			for (int i = 0; i < numColors; i++)
			{
				byte r = br.ReadByte();
				byte g = br.ReadByte();
				byte b = br.ReadByte();
				if (i == transparentIndex && transparentIndex != -1)
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
		/// Export a CI8 palette to GIMP's .txt palette format.
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
		/// Import GIMP's .txt palette format to a CI8 palette.
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

			// handle files with fewer than 256 colors by forcing missing entries to transparent
			if (numEntries < 256)
			{
				int diff = 256 - numEntries;
				for (int i = 0; i < diff; i++)
				{
					Entries[numEntries + i] = 0;
				}
			}

			return true;
		}
		#endregion
	}
}
