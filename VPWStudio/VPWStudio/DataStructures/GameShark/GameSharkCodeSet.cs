using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Xml;

namespace VPWStudio
{
	/// <summary>
	/// A collection of GameSharkCode objects making up a single code entry.
	/// </summary>
	public class GameSharkCodeSet
	{
		/// <summary>
		/// Name of this codeset.
		/// </summary>
		public string Name;

		/// <summary>
		/// Codes in this GameSharkCodeSet.
		/// </summary>
		public SortedList<int, GameSharkCode> Codes;

		#region Constructors
		/// <summary>
		/// Default constructor.
		/// </summary>
		public GameSharkCodeSet()
		{
			Name = "Untitled Codeset";
			Codes = new SortedList<int, GameSharkCode>();
		}

		/// <summary>
		/// Named constructor.
		/// </summary>
		/// <param name="_name"></param>
		public GameSharkCodeSet(string _name)
		{
			Name = _name;
			Codes = new SortedList<int, GameSharkCode>();
		}
		#endregion

		#region Things to re-consider
		/// <summary>
		/// Add a GameSharkCode at the end of this CodeSet.
		/// </summary>
		/// <param name="gsc">GameSharkCode object to add.</param>
		public void AddCode(GameSharkCode gsc)
		{
			Codes.Add(Codes.Count, gsc);
		}

		/// <summary>
		/// Add a GameSharkCode at the specified index of the CodeSet.
		/// </summary>
		/// <param name="gsc">GameSharkCode object to add.</param>
		/// <param name="index">Index to add code at.</param>
		/// <returns></returns>
		public bool AddCodeAt(GameSharkCode gsc, int index)
		{
			if (index > (Codes.Count + 1) || index < 0)
			{
				return false;
			}

			Codes.Add(index, gsc);
			return true;
		}

		/// <summary>
		/// Removes the GameSharkCode at the specified index.
		/// </summary>
		/// <param name="index">Index of code to remove.</param>
		/// <returns></returns>
		public bool RemoveCodeAt(int index)
		{
			if (index > Codes.Count || index < 0)
			{
				return false;
			}

			Codes.Remove(index);
			return true;
		}
		#endregion

		/// <summary>
		/// Returns the entire set of codes as a string.
		/// </summary>
		/// <returns>A string with the code representation; one code per line.</returns>
		public string GetCodes()
		{
			StringBuilder sb = new StringBuilder();
			for (int i = 0; i < Codes.Count; i++)
			{
				sb.AppendLine(Codes[i].ToString());
			}
			return sb.ToString();
		}

		/// <summary>
		/// Create a deep copy of the specified GameSharkCodeSet.
		/// </summary>
		/// <param name="_src"></param>
		public void DeepCopy(GameSharkCodeSet _src)
		{
			Name = _src.Name;
			Codes = new SortedList<int, GameSharkCode>();
			for (int i = 0; i < _src.Codes.Count; i++)
			{
				AddCodeAt(_src.Codes[i], i);
			}
		}

		#region File Routines, which might be outdated now
		/// <summary>
		/// Load GameSharkCodeSet from an XML file.
		/// </summary>
		/// <param name="_path">Path to XML file with GameSharkCodeSet data.</param>
		public void LoadFile(XmlReader xr)
		{
			Codes.Clear();
			ReadXml(xr);
		}

		/// <summary>
		/// Save GameSharkCodeSet to an XML file.
		/// </summary>
		/// <param name="_path">Path to XML file to save code data to.</param>
		/// <returns></returns>
		/// todo: this should probably be split up further, so that the codeset doesn't require its own document
		public bool SaveFile(XmlWriter xw)
		{
			xw.WriteStartDocument();

			WriteXml(xw);

			xw.WriteEndDocument();
			xw.Flush();
			xw.Close();
			return true;
		}
		#endregion

		#region XML Read/Write Routines
		/// <summary>
		/// Write this GameSharkCodeSet with an XmlWriter.
		/// </summary>
		/// <param name="xw"></param>
		public void WriteXml(XmlWriter xw)
		{
			xw.WriteStartElement("GameSharkCodeSet");

			xw.WriteStartElement("Name");
			xw.WriteValue(Name);
			xw.WriteEndElement();

			xw.WriteElementString("NumCodes", Codes.Count.ToString());

			for (int i = 0; i < Codes.Count; i++)
			{
				xw.WriteElementString(
					String.Format("Code{0}", i),
					Codes[i].ToString()
				);
			}

			xw.WriteEndElement();
		}

		/// <summary>
		/// Read a GameSharkCodeSet with an XmlReader.
		/// </summary>
		/// <param name="xr"></param>
		public void ReadXml(XmlReader xr)
		{
			int numCodes = 0;

			while (true)
			{
				xr.Read();

				if (xr.NodeType == XmlNodeType.EndElement && xr.Name == "GameSharkCodeSet")
				{
					break;
				}

				if (xr.Name == "Name")
				{
					Name = xr.ReadElementContentAsString();
				}

				if (xr.Name == "NumCodes")
				{
					numCodes = xr.ReadElementContentAsInt();
				}

				if (xr.Name.StartsWith("Code"))
				{
					int codeNum = int.Parse(xr.Name.Substring(4));
					string code = xr.ReadElementContentAsString();
					Codes.Add(codeNum, new GameSharkCode(code));
				}
			}
		}
		#endregion

		#region Project64 Code Format Read/Write Routines

		/// <summary>
		/// Convert a GameSharkCodeSet to a Project64 cheat.
		/// </summary>
		/// <param name="codeNum">Number of code in PJ64 cheat file.</param>
		/// <param name="sw">StreamWriter instance</param>
		public void WriteCode_PJ64(int codeNum, StreamWriter sw)
		{
			string cheat = String.Empty;
			for (int i = 0; i < this.Codes.Count; i++)
			{
				cheat += Codes[i].ToString();
				if (i < Codes.Count - 1)
				{
					cheat += ",";
				}
			}
			sw.WriteLine(String.Format("Cheat{0}=\"{1}\",{2}", codeNum, Name, cheat));
		}
		#endregion
	}
}
