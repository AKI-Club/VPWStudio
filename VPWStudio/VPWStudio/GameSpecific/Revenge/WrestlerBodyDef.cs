using System;
using System.IO;

namespace VPWStudio.GameSpecific.Revenge
{
	/// <summary>
	/// WCW/nWo Revenge Wrestler Body Definition.
	/// </summary>
	public class WrestlerBodyDef
	{
		#region Class Members
		/// <summary>
		/// Wrestler height value.
		/// </summary>
		public byte Height;

		/// <summary>
		/// Wrestler body type.
		/// </summary>
		/// 0 = Cruiserweight; 1 = Normal; 2 = Heavy; 3 = Big; 4 = Manager
		public byte BodyType;
		#endregion

		#region Constructors
		/// <summary>
		/// Default constructor.
		/// </summary>
		public WrestlerBodyDef()
		{
			Height = 0;
			BodyType = 0;
		}

		/// <summary>
		/// Constructor with specific values.
		/// </summary>
		/// <param name="height">Wrestler height</param>
		/// <param name="bodyType">Wrestler body type (0-4)</param>
		public WrestlerBodyDef(byte height, byte bodyType)
		{
			Height = height;
			BodyType = bodyType;
		}

		/// <summary>
		/// Constructor using a BinaryReader.
		/// </summary>
		/// <param name="br">BinaryReader instance to use.</param>
		public WrestlerBodyDef(BinaryReader br)
		{
			ReadData(br);
		}
		#endregion

		/// <summary>
		/// Get the height index from the top nibble of the Height byte.
		/// </summary>
		/// <returns>Shifted height index</returns>
		public int GetHeightIndex()
		{
			return (Height & 0xF0) >> 4;
		}

		#region Binary Read/Write
		/// <summary>
		/// Read data using a BinaryReader.
		/// </summary>
		/// <param name="br">BinaryReader instance to use.</param>
		public void ReadData(BinaryReader br)
		{
			Height = br.ReadByte();
			BodyType = br.ReadByte();
		}

		/// <summary>
		/// WriteData using a BinaryWriter.
		/// </summary>
		/// <param name="bw">BinaryWriter instance to use.</param>
		public void WriteData(BinaryWriter bw)
		{
			bw.Write(Height);
			bw.Write(BodyType);
		}
		#endregion
	}
}
