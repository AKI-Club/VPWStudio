using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;

namespace VPWStudio
{
	/// <summary>
	/// A single wrestler name entry in a WrestlerNameFile.
	/// </summary>
	public class WrestlerNameEntry
	{
		public byte ID2;
		public UInt16 ID4;
		public string LongName;
		public string ShortName;

		#region Constructors
		/// <summary>
		/// Default constructor.
		/// </summary>
		public WrestlerNameEntry()
		{
			ID2 = 0;
			ID4 = 0;
			LongName = String.Empty;
			ShortName = String.Empty;
		}

		/// <summary>
		/// Specific constructor.
		/// </summary>
		/// <param name="_id2"></param>
		/// <param name="_id4"></param>
		/// <param name="_longName"></param>
		/// <param name="_shortName"></param>
		public WrestlerNameEntry(byte _id2, UInt16 _id4, string _longName, string _shortName)
		{
			ID2 = _id2;
			ID4 = _id4;
			LongName = _longName;
			ShortName = _shortName;
		}

		/// <summary>
		/// Constructor from input string.
		/// </summary>
		/// <param name="input">Input string to convert.</param>
		public WrestlerNameEntry(string input)
		{
			if (!FromString(input))
			{
				// fall back to default data
				ID2 = 0;
				ID4 = 0;
				LongName = String.Empty;
				ShortName = String.Empty;
			}
		}

		/// <summary>
		/// Get string representation of this WrestlerNameEntry.
		/// </summary>
		/// <returns>String representation of this WrestlerNameEntry.</returns>
		public override string ToString()
		{
			// line format: ID2/ID4=LongName|ShortName
			return String.Format("{0:X2}/{1:X4}={2}|{3}", ID2, ID4, LongName, ShortName);
		}

		/// <summary>
		/// Convert a string to a WrestlerNameEntry.
		/// </summary>
		/// <param name="input">Input string to convert.</param>
		public bool FromString(string input)
		{
			string[] tokens = input.Split(new char[] { '/', '=', '|' });

			if (!byte.TryParse(tokens[0], NumberStyles.HexNumber, null, out ID2))
			{
				return false;
			}

			if (!UInt16.TryParse(tokens[1], NumberStyles.HexNumber, null, out ID4))
			{
				return false;
			}

			LongName = tokens[2];
			ShortName = tokens[3];

			return true;
		}
		#endregion
	}

	/// <summary>
	/// Allow for mapping ID2 and ID4s to friendly names.
	/// </summary>
	public class WrestlerNameFile
	{
		public List<WrestlerNameEntry> Names;

		public WrestlerNameFile()
		{
			Names = new List<WrestlerNameEntry>();
		}

		public void LoadFile(string path)
		{
			FileStream fs = new FileStream(path, FileMode.Open);
			StreamReader sr = new StreamReader(fs);

			while (!sr.EndOfStream)
			{
				string line = sr.ReadLine();
				WrestlerNameEntry wne = new WrestlerNameEntry(line);
				if (wne.ID2 != 0)
				{
					Names.Add(wne);
				}
			}

		}
	}
}
