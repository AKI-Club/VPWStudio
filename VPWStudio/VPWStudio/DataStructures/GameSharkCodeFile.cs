using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
	}
}
