using System;
using System.Collections.Generic;
using System.IO;
using System.Xml;

namespace VPWStudio
{
	/// <summary>
	/// A collection of GameSharkCodeSet objects in an XML file.
	/// </summary>
	public class GameSharkCodeFile
	{
		/// <summary>
		/// All of the codes in this GameSharkCodeFile.
		/// </summary>
		public List<GameSharkCodeSet> AllCodes;

		#region Constructors
		/// <summary>
		/// Default constructor.
		/// </summary>
		public GameSharkCodeFile()
		{
			AllCodes = new List<GameSharkCodeSet>();
		}

		/// <summary>
		/// Constructor from file path.
		/// </summary>
		/// <param name="_path">Path to XML file to load.</param>
		public GameSharkCodeFile(string _path)
		{
			using (FileStream fs = new FileStream(_path, FileMode.Open))
			{
				using (XmlReader xr = XmlReader.Create(fs))
				{
					LoadFile(xr);
				}
			}
		}
		#endregion

		#region Load/Save
		/// <summary>
		/// Load codes from XML file.
		/// </summary>
		/// <param name="xr">XmlReader instance to use.</param>
		public void LoadFile(XmlReader xr)
		{
			while (!xr.EOF)
			{
				xr.Read();

				if (xr.NodeType == XmlNodeType.Element && xr.Name == "GameSharkCodeSet")
				{
					GameSharkCodeSet gscs = new GameSharkCodeSet();
					gscs.ReadXml(xr);
					AllCodes.Add(gscs);
				}
			}
		}

		/// <summary>
		/// Save codes to XML file.
		/// </summary>
		/// <param name="xw">XmlWriter instance to use.</param>
		public void SaveFile(XmlWriter xw)
		{
			xw.WriteStartDocument();
			xw.WriteStartElement("GameSharkCodeFile");

			foreach (GameSharkCodeSet cs in AllCodes)
			{
				cs.WriteXml(xw);
			}

			xw.WriteEndElement();
			xw.WriteEndDocument();
			xw.Close();
		}
		#endregion

		/// <summary>
		/// Export GameSharkCodeFile as Project64 cheats file section.
		/// </summary>
		/// <param name="_path">Path to output cheats.</param>
		public void ExportPJ64(string _path, string _section, string _gameName)
		{
			using (FileStream fs = new FileStream(_path, FileMode.Create))
			{
				using (StreamWriter sw = new StreamWriter(fs))
				{
					// section header is dumb; relies on ROM.
					sw.WriteLine(String.Format("[{0}]", _section));
					sw.WriteLine(String.Format("Name={0}", _gameName));

					// Write codes in PJ64 format
					for (int i = 0; i < AllCodes.Count; i++)
					{
						AllCodes[i].WriteCode_PJ64(i, sw);
					}

					sw.Flush();
				}
			}
		}
	}
}
