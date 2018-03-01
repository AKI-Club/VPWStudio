using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Schema;
using System.Xml.Serialization;

namespace VPWStudio.GameSpecific
{
	/// <summary>
	/// Base Wrestler Definition.
	/// Only exists to have a common type for importing/exporting XML.
	/// </summary>
	public partial class BaseWrestlerDefinition : IXmlSerializable
	{
		/// <summary>
		/// We don't need no steenking schema!
		/// </summary>
		/// <returns></returns>
		public XmlSchema GetSchema()
		{
			return null;
		}

		/// <summary>
		/// Read WrestlerDefinition data from XML.
		/// </summary>
		/// <param name="xr">XmlReader instance to use.</param>
		public virtual void ReadXml(XmlReader xr)
		{
			throw new NotImplementedException("Inherited classes must override this.");
		}

		/// <summary>
		/// Write WrestlerDefinition data to XML.
		/// </summary>
		/// <param name="xw">XmlWriter instance to use.</param>
		public virtual void WriteXml(XmlWriter xw)
		{
			throw new NotImplementedException("Inherited classes must override this.");
		}
	}
}
