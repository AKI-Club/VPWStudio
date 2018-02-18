using System;
using System.IO;
using System.Runtime.Serialization;
using System.Globalization;
using System.Xml;
using System.Xml.Schema;
using System.Xml.Serialization;

namespace VPWStudio.GameSpecific.VPW2
{
	/// <summary>
	/// Virtual Pro-Wrestling 2 Wrestler Definition.
	/// </summary>
	[Serializable]
	public class WrestlerDefinition : IWrestlerDefinition
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
		/// Announcment name
		/// </summary>
		public byte NameCall;

		/// <summary>
		/// Height value (in cm; add 0x23 (35) for real value)
		/// </summary>
		public byte Height;

		/// <summary>
		/// Weight value (in kg; add 0x2D (45) for real value)
		/// </summary>
		public byte Weight;

		/// <summary>
		/// Voice sample 1
		/// </summary>
		public byte Voice1;

		/// <summary>
		/// Voice sample 2
		/// </summary>
		public byte Voice2;

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
			this.NameCall = 0;
			this.Height = 0;
			this.Weight = 0;
			this.Voice1 = 0;
			this.Voice2 = 0;
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
			this.NameCall = br.ReadByte();
			this.Height = br.ReadByte();
			this.Weight = br.ReadByte();
			this.Voice1 = br.ReadByte();
			this.Voice2 = br.ReadByte();

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

		public XmlSchema GetSchema()
		{
			return null;
		}

		public void ReadXml(XmlReader xr)
		{
			System.Windows.Forms.MessageBox.Show(xr.Name);

			string id4 = xr.ReadElementContentAsString();
			this.WrestlerID4 = ushort.Parse(id4, NumberStyles.HexNumber);

			string id2 = xr.ReadElementContentAsString();
			this.WrestlerID2 = ushort.Parse(id2, NumberStyles.HexNumber);

			this.ThemeSong = (byte)xr.ReadContentAsInt();
			this.NameCall = (byte)xr.ReadContentAsInt();
			this.Height = (byte)xr.ReadContentAsInt();
			this.Weight = (byte)xr.ReadContentAsInt();
			this.Voice1 = (byte)xr.ReadContentAsInt();
			this.Voice2 = (byte)xr.ReadContentAsInt();

			string moveIndex = xr.ReadElementContentAsString();
			string paramIndex = xr.ReadElementContentAsString();
			string costumeIndex = xr.ReadElementContentAsString();
			string profileIndex = xr.ReadElementContentAsString();
		}

		public void WriteXml(XmlWriter xr)
		{
			xr.WriteStartElement("WrestlerDefinition");

			xr.WriteElementString("WrestlerID4", String.Format("{0:X4}", this.WrestlerID4));
			xr.WriteElementString("WrestlerID2", String.Format("{0:X2}", this.WrestlerID2));
			xr.WriteElementString("ThemeSong", this.ThemeSong.ToString());
			xr.WriteElementString("NameCall", this.NameCall.ToString());
			xr.WriteElementString("Height", this.Height.ToString());
			xr.WriteElementString("Weight", this.Weight.ToString());
			xr.WriteElementString("Voice1", this.Voice1.ToString());
			xr.WriteElementString("Voice2", this.Voice2.ToString());
			xr.WriteElementString("MovesetFileIndex", String.Format("{0:X4}", this.MovesetFileIndex));
			xr.WriteElementString("ParamsFileIndex", String.Format("{0:X4}", this.ParamsFileIndex));
			xr.WriteElementString("AppearanceIndex", String.Format("{0:X4}", this.AppearanceIndex));
			xr.WriteElementString("ProfileIndex", String.Format("{0:X4}", this.ProfileIndex));

			xr.WriteEndElement();
		}
	}
}
