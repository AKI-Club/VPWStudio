using System;
using System.IO;

// note: doesn't handle the separate per-wrestler body table yet
namespace VPWStudio.GameSpecific.Revenge
{
	/// <summary>
	/// A single costume for a WCW/nWo Revenge wrestler.
	/// </summary>
	/// Similar to VPW64, but only 2 colors are editable.
	public class DefaultCostumeDataEntry
	{
		#region Class Members
		/// <summary>
		/// Head/Mask number used for this costume. Often 0x00.
		/// </summary>
		public byte Head;

		/// <summary>
		/// Costume number used for this costume.
		/// </summary>
		public byte Costume;

		/// <summary>
		/// First color used for this costume.
		/// Format: 0x0_, where _ is the color (0-F).
		/// </summary>
		public byte Color1;

		/// <summary>
		/// Second color used for this costume.
		/// </summary>
		public byte Color2;
		#endregion

		#region Constructors
		/// <summary>
		/// Default constructor.
		/// </summary>
		public DefaultCostumeDataEntry()
		{
			Head = 0;
			Costume = 0;
			Color1 = 0;
			Color2 = 0;
		}

		/// <summary>
		/// Specific constructor using specific values.
		/// </summary>
		/// <param name="head">Head/Mask number. Most often 0x00.</param>
		/// <param name="cos">Costume number.</param>
		/// <param name="color1">Costume color 1.</param>
		/// <param name="color2">Costume colors 2 and 3.</param>
		public DefaultCostumeDataEntry(byte head, byte cos, byte color1, byte color2)
		{
			Head = head;
			Costume = cos;
			Color1 = color1;
			Color2 = color2;
		}

		/// <summary>
		/// Constructor using a BinaryReader.
		/// </summary>
		/// <param name="br">BinaryReader instance to use.</param>
		public DefaultCostumeDataEntry(BinaryReader br)
		{
			ReadData(br);
		}
		#endregion

		#region Binary Read/Write
		/// <summary>
		/// Read a Revenge default costume data slot using a BinaryReader.
		/// </summary>
		/// <param name="br">BinaryReader instance to use.</param>
		public void ReadData(BinaryReader br)
		{
			Head = br.ReadByte();
			Costume = br.ReadByte();
			Color1 = br.ReadByte();
			Color2 = br.ReadByte();
		}

		/// <summary>
		/// Write a Revenge default costume data slot using a BinaryWriter.
		/// </summary>
		/// <param name="bw">BinaryWriter instance to use.</param>
		public void WriteData(BinaryWriter bw)
		{
			bw.Write(Head);
			bw.Write(Costume);
			bw.Write(Color1);
			bw.Write(Color2);
		}
		#endregion
	}

	/// <summary>
	/// WCW/nWo Revenge Default Costume Data.
	/// </summary>
	public class DefaultCostumeData
	{
		/// <summary>
		/// Number of costume entries per wrestler.
		/// </summary>
		public static readonly int NUM_COSTUMES = 4;

		#region Class Members
		/// <summary>
		/// The actual costumes.
		/// </summary>
		public DefaultCostumeDataEntry[] Costumes;
		#endregion

		#region Constructors
		/// <summary>
		/// Default constructor.
		/// </summary>
		public DefaultCostumeData()
		{
			Costumes = new DefaultCostumeDataEntry[NUM_COSTUMES];
		}

		/// <summary>
		/// Constructor using a BinaryReader.
		/// </summary>
		/// <param name="br">BinaryReader instance to use.</param>
		public DefaultCostumeData(BinaryReader br)
		{
			Costumes = new DefaultCostumeDataEntry[NUM_COSTUMES];
			ReadData(br);
		}
		#endregion

		#region Binary Read/Write
		/// <summary>
		/// Read Revenge Default Costume Data using a BinaryReader.
		/// </summary>
		/// <param name="br">BinaryReader instance to use.</param>
		public void ReadData(BinaryReader br)
		{
			for (int i = 0; i < Costumes.Length; i++)
			{
				Costumes[i] = new DefaultCostumeDataEntry(br);
			}
		}

		/// <summary>
		/// Write Revenge Default Costume Data using a BinaryWriter.
		/// </summary>
		/// <param name="bw">BinaryWriter instance to use.</param>
		public void WriteData(BinaryWriter bw)
		{
			for (int i = 0; i < Costumes.Length; i++)
			{
				Costumes[i].WriteData(bw);
			}
		}
		#endregion
	}
}
