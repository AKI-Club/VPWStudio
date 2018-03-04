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

		public GameSharkCodeFile()
		{
			this.AllCodes = new List<GameSharkCodeSet>();
		}

		#region Load/Save
		/// <summary>
		/// Load codes from XML file.
		/// </summary>
		/// <param name="xr"></param>
		public void LoadFile(XmlReader xr)
		{
			while (!xr.EOF)
			{
				xr.Read();

				if (xr.NodeType == XmlNodeType.Element && xr.Name == "GameSharkCodeSet")
				{
					GameSharkCodeSet gscs = new GameSharkCodeSet();
					gscs.ReadXml(xr);
					this.AllCodes.Add(gscs);
				}
			}
		}

		/// <summary>
		/// Save codes to XML file.
		/// </summary>
		/// <param name="xw"></param>
		public void SaveFile(XmlWriter xw)
		{
			xw.WriteStartDocument();
			xw.WriteStartElement("GameSharkCodeFile");

			foreach (GameSharkCodeSet cs in this.AllCodes)
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
			FileStream fs = new FileStream(_path, FileMode.Create);
			StreamWriter sw = new StreamWriter(fs);

			// section header is dumb; relies on ROM.
			sw.WriteLine(String.Format("[{0}]", _section));
			sw.WriteLine(String.Format("Name={0}", _gameName));

			// Write codes in PJ64 format
			for (int i = 0; i < this.AllCodes.Count; i++)
			{
				this.AllCodes[i].WriteCode_PJ64(i, sw);
			}

			sw.Flush();
			sw.Close();
			fs.Close();
		}
	}
}
