using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
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

		/// <summary>
		/// Default constructor.
		/// </summary>
		public GameSharkCodeSet()
		{
			this.Name = "Untitled Codeset";
			this.Codes = new SortedList<int, GameSharkCode>();
		}

		/// <summary>
		/// Named constructor.
		/// </summary>
		/// <param name="_name"></param>
		public GameSharkCodeSet(string _name)
		{
			this.Name = _name;
			this.Codes = new SortedList<int, GameSharkCode>();
		}

		#region Things to re-consider
		/// <summary>
		/// Add a GameSharkCode at the end of this CodeSet.
		/// </summary>
		/// <param name="gsc">GameSharkCode object to add.</param>
		public void AddCode(GameSharkCode gsc)
		{
			this.Codes.Add(this.Codes.Count, gsc);
		}

		/// <summary>
		/// Add a GameSharkCode at the specified index of the CodeSet.
		/// </summary>
		/// <param name="gsc">GameSharkCode object to add.</param>
		/// <param name="index">Index to add code at.</param>
		/// <returns></returns>
		public bool AddCodeAt(GameSharkCode gsc, int index)
		{
			if (index > (this.Codes.Count + 1) || index < 0)
			{
				return false;
			}

			this.Codes.Add(index, gsc);
			return true;
		}

		/// <summary>
		/// Removes the GameSharkCode at the specified index.
		/// </summary>
		/// <param name="index">Index of code to remove.</param>
		/// <returns></returns>
		public bool RemoveCodeAt(int index)
		{
			if (index > this.Codes.Count || index < 0)
			{
				return false;
			}

			this.Codes.Remove(index);
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
			for (int i = 0; i < this.Codes.Count; i++)
			{
				sb.AppendLine(this.Codes[i].ToString());
			}
			return sb.ToString();
		}

		/// <summary>
		/// Create a deep copy of the specified GameSharkCodeSet.
		/// </summary>
		/// <param name="_src"></param>
		public void DeepCopy(GameSharkCodeSet _src)
		{
			this.Name = _src.Name;
			this.Codes = new SortedList<int, GameSharkCode>();
			for (int i = 0; i < _src.Codes.Count; i++)
			{
				this.AddCodeAt((GameSharkCode)_src.Codes[i], i);
			}
		}

		#region File Routines, which might be outdated now
		/// <summary>
		/// Load GameSharkCodeSet from an XML file.
		/// </summary>
		/// <param name="_path">Path to XML file with GameSharkCodeSet data.</param>
		public void LoadFile(XmlReader xr)
		{
			this.Codes.Clear();
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

			this.WriteXml(xw);

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
			xw.WriteValue(this.Name);
			xw.WriteEndElement();

			xw.WriteElementString("NumCodes", this.Codes.Count.ToString());

			for (int i = 0; i < this.Codes.Count; i++)
			{
				xw.WriteElementString(
					String.Format("Code{0}", i),
					this.Codes[i].ToString()
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
			bool reading = true;
			int numCodes = 0;

			while (reading)
			{
				xr.Read();

				if (xr.NodeType == XmlNodeType.EndElement && xr.Name == "GameSharkCodeSet")
				{
					reading = false;
				}

				if (xr.Name == "Name")
				{
					this.Name = xr.ReadElementContentAsString();
				}

				if (xr.Name == "NumCodes")
				{
					numCodes = xr.ReadElementContentAsInt();
				}

				if (xr.Name.StartsWith("Code"))
				{
					int codeNum = int.Parse(xr.Name.Substring(4));
					string code = xr.ReadElementContentAsString();
					this.Codes.Add(codeNum, new GameSharkCode(code));
				}
			}
		}
		#endregion

		#region Project64 Code Format Read/Write Routines

		#endregion
	}
}
