using System;
using System.IO;
using System.Runtime.Serialization;
using System.Xml;
using System.Xml.Serialization;

namespace VPWStudio.GameSpecific
{
	public interface IWrestlerDefinition : /*ISerializable,*/ IXmlSerializable
	{		
		#region I/O
		/// <summary>
		/// Read WrestlerDefinition data from a BinaryReader instance.
		/// </summary>
		/// <param name="br">BinaryReader instance to use.</param>
		void ReadData(BinaryReader br);
		#endregion
	}
}
