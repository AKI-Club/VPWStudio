using System;
using System.IO;
using System.Runtime.Serialization;
using System.Xml;
using System.Xml.Schema;
using System.Xml.Serialization;

namespace VPWStudio.GameSpecific.NoMercy
{
	/// <summary>
	/// WWF No Mercy Wrestler Definition.
	/// </summary>
	[Serializable]
	public class WrestlerDefinition : IXmlSerializable
	{
		#region Class Members
		/// <summary>
		/// Wrestler ID4 (e.g. 0x0A01)
		/// </summary>
		public UInt16 WrestlerID4;

		/// <summary>
		/// Wrestler ID2
		/// </summary>
		public UInt16 WrestlerID2;

		/// <summary>
		/// Theme Music
		/// </summary>
		public byte ThemeSong;

		/// <summary>
		/// Entrance/"TitanTron" Video
		/// </summary>
		public byte EntranceVideo;

		// height (byte)
		public byte Height;

		// byte with unknown purpose
		public byte Unknown;

		// weight (word)
		public UInt16 Weight;

		// todo: missing items between here and there

		/// <summary>
		/// Moveset file index
		/// </summary>
		public UInt16 MovesetFileIndex;

		/// <summary>
		/// Parameters file index
		/// </summary>
		public UInt16 ParamsFileIndex;

		/// <summary>
		/// Index into appearances table?
		/// </summary>
		public UInt16 AppearanceIndex;

		/// <summary>
		/// Index into profile/default names table?
		/// </summary>
		public UInt16 ProfileIndex;
		#endregion

		/// <summary>
		/// Default constructor.
		/// </summary>
		public WrestlerDefinition()
		{
			this.WrestlerID4 = 0;
			this.WrestlerID2 = 0;
			this.ThemeSong = 0;
			this.EntranceVideo = 0;
			this.Height = 0;
			this.Unknown = 0;
			this.Weight = 0;
			this.MovesetFileIndex = 0;
			this.ParamsFileIndex = 0;
			this.AppearanceIndex = 0;
			this.ProfileIndex = 0;
		}

		/// <summary>
		/// Constructor from loaded data.
		/// </summary>
		/// <param name="br">BinaryReader instance to use.</param>
		public WrestlerDefinition(BinaryReader br)
		{
			this.ReadData(br);
		}

		/// <summary>
		/// Read WrestlerDefinition data using a BinaryReader.
		/// </summary>
		/// <param name="br">BinaryReader instance to use.</param>
		public void ReadData(BinaryReader br)
		{
			byte[] id4 = br.ReadBytes(2);
			if (BitConverter.IsLittleEndian)
			{
				Array.Reverse(id4);
			}
			this.WrestlerID4 = BitConverter.ToUInt16(id4, 0);

			byte[] id2 = br.ReadBytes(2);
			if (BitConverter.IsLittleEndian)
			{
				Array.Reverse(id2);
			}
			this.WrestlerID2 = BitConverter.ToUInt16(id2, 0);

			this.ThemeSong = br.ReadByte();
			this.EntranceVideo = br.ReadByte();
			this.Height = br.ReadByte();
			this.Unknown = br.ReadByte();

			byte[] w = br.ReadBytes(2);
			if (BitConverter.IsLittleEndian)
			{
				Array.Reverse(w);
			}
			this.Weight = BitConverter.ToUInt16(w, 0);

			byte[] moveIdx = br.ReadBytes(2);
			if (BitConverter.IsLittleEndian)
			{
				Array.Reverse(moveIdx);
			}
			this.MovesetFileIndex = BitConverter.ToUInt16(moveIdx, 0);

			byte[] paramIdx = br.ReadBytes(2);
			if (BitConverter.IsLittleEndian)
			{
				Array.Reverse(paramIdx);
			}
			this.ParamsFileIndex = BitConverter.ToUInt16(paramIdx, 0);

			byte[] appearIdx = br.ReadBytes(2);
			if (BitConverter.IsLittleEndian)
			{
				Array.Reverse(appearIdx);
			}
			this.AppearanceIndex = BitConverter.ToUInt16(appearIdx, 0);

			byte[] profileIdx = br.ReadBytes(2);
			if (BitConverter.IsLittleEndian)
			{
				Array.Reverse(profileIdx);
			}
			this.ProfileIndex = BitConverter.ToUInt16(profileIdx, 0);

			// prepare for another possible read
			br.ReadBytes(2);
		}

		#region XML Read/Write
		public XmlSchema GetSchema()
		{
			return null;
		}

		public void ReadXml(XmlReader xr)
		{
		}

		public void WriteXml(XmlWriter xr)
		{
		}
		#endregion
	}
}
