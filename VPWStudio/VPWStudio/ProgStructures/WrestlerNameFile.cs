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
		/// <summary>
		/// Wrestler ID2
		/// </summary>
		public byte ID2;

		/// <summary>
		/// Wrestler ID4
		/// </summary>
		public UInt16 ID4;

		/// <summary>
		/// Wrestler long name
		/// </summary>
		public string LongName;

		/// <summary>
		/// Wrestler short name
		/// </summary>
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
		/// <param name="_id2">ID2 for this wrestler</param>
		/// <param name="_id4">ID4 for this wrestler</param>
		/// <param name="_longName">Wrestler long name</param>
		/// <param name="_shortName">Wrestler Short Name</param>
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
		/// <summary>
		/// Wrestler names
		/// </summary>
		public List<WrestlerNameEntry> Names;

		/// <summary>
		/// Default constructor.
		/// </summary>
		public WrestlerNameFile()
		{
			Names = new List<WrestlerNameEntry>();
		}

		#region Load/Save
		/// <summary>
		/// Load WrestlerNameEntry data from a file.
		/// </summary>
		/// <param name="path">Path to file with WrestlerNameEntry data.</param>
		public void LoadFile(string path)
		{
			FileStream fs = new FileStream(path, FileMode.Open);
			StreamReader sr = new StreamReader(fs);

			while (!sr.EndOfStream)
			{
				string line = sr.ReadLine();

				// handle comments
				if (line[0] == '#')
				{
					continue;
				}

				WrestlerNameEntry wne = new WrestlerNameEntry(line);
				if (wne.ID2 != 0)
				{
					Names.Add(wne);
				}
			}
			sr.Close();
		}
		#endregion

		#region Helpers
		/// <summary>
		/// Find a WrestlerNameEntry by ID2 value.
		/// </summary>
		/// <param name="id2">ID2 of WrestlerNameEntry to find.</param>
		/// <returns>WrestlerNameEntry with requested ID2, or null if not found.</returns>
		public WrestlerNameEntry FindEntryByID2(byte id2)
		{
			foreach (WrestlerNameEntry name in Names)
			{
				if (name.ID2 == id2)
				{
					return name;
				}
			}
			return null;
		}

		/// <summary>
		/// Find a WrestlerNameEntry by ID4 value.
		/// </summary>
		/// <param name="id4">ID4 of WrestlerNameEntry to find.</param>
		/// <returns>WrestlerNameEntry with requested ID4, or null if not found.</returns>
		public WrestlerNameEntry FindEntryByID4(UInt16 id4)
		{
			foreach (WrestlerNameEntry name in Names)
			{
				if (name.ID4 == id4)
				{
					return name;
				}
			}
			return null;
		}
		#endregion
	}
}
