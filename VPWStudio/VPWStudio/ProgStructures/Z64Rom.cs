using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace VPWStudio
{
	/// <summary>
	/// N64 CIC chip types.
	/// </summary>
	public enum N64Cic
	{
		/// <summary>
		/// Unknown CIC type
		/// </summary>
		Unknown = -1,

		/// <summary>
		/// Super Mario 64/Standard CIC (NTSC; PAL 7101)
		/// </summary>
		CIC_6102 = 0,

		/// <summary>
		/// StarFox 64 (NTSC; PAL 7102)
		/// </summary>
		CIC_6101,

		/// <summary>
		/// Diddy Kong Racing CIC (NTSC; PAL 7103)
		/// </summary>
		CIC_6103,

		/// <summary>
		/// Legend of Zelda CIC (NTSC; PAL 7105)
		/// </summary>
		CIC_6105,

		/// <summary>
		/// Yoshi's Story (NTSC; PAL 7106)
		/// </summary>
		CIC_6106,
	}

	/// <summary>
	/// Possible region codes for N64 ROMs.
	/// </summary>
	public enum RegionCodes
	{
		/// <summary>
		/// Japan, Japanese
		/// </summary>
		Japanese = 'J',
		/// <summary>
		/// North America, English
		/// </summary>
		NorthAmerica = 'E',
		/// <summary>
		/// European, Generic
		/// </summary>
		European = 'P',
		/// <summary>
		/// French
		/// </summary>
		French = 'F',
		/// <summary>
		/// Canada (English/French?)
		/// </summary>
		Canadian = 'N',
		/// <summary>
		/// Germany, German
		/// </summary>
		German = 'D',
		/// <summary>
		/// Netherlands, Dutch
		/// </summary>
		Dutch = 'H',
		/// <summary>
		/// Italy, Italian
		/// </summary>
		Italian = 'I',
		/// <summary>
		/// Spain, Spanish
		/// </summary>
		Spanish = 'S',
		/// <summary>
		/// Scandinavia, Scandinavian
		/// </summary>
		Scandinavian = 'W',
		/// <summary>
		/// China, Chinese (iQue?)
		/// </summary>
		Chinese = 'C',
		/// <summary>
		/// Korea, Korean
		/// </summary>
		Korean = 'K',
		/// <summary>
		/// Brazil, Brazilian
		/// </summary>
		Brazilian = 'B',
		/// <summary>
		/// Australia, Australian
		/// </summary>
		Australian = 'U',
		OthersX = 'X',
		OthersY = 'Y',
		OthersZ = 'Z',
		/// <summary>
		/// Gateway/Lodgenet NTSC
		/// </summary>
		GatewayNTSC = 'G',
		/// <summary>
		/// Gateway/Lodgenet PAL
		/// </summary>
		GatewayPAL = 'L'
	}

	/// <summary>
	/// Z64 format Nintendo 64 ROM.
	/// </summary>
	public class Z64Rom
	{
		#region Static Junk
		/// <summary>
		/// Convert a pointer value to its location in ROM.
		/// </summary>
		/// <param name="_ptr">Pointer value</param>
		/// <param name="_offset">(optional) Offset to add to value</param>
		/// <returns>ROM location of pointer value.</returns>
		public static UInt32 PointerToRom(UInt32 _ptr, int _offset = 0)
		{
			_ptr &= 0x0FFFFFFF;
			if (_offset != 0)
			{
				_ptr = (UInt32)(_ptr + _offset);
			}
			return (_ptr + 0xC00);
		}

		/// <summary>
		/// Convert a ROM location to a pointer value.
		/// </summary>
		/// <param name="_rom">ROM location of pointer value.</param>
		/// <param name="_offset">(optional) Offset to add to value</param>
		/// <returns>Pointer value</returns>
		public static UInt32 RomToPointer(UInt32 _rom, int _offset = 0)
		{
			_rom |= 0x80000000;
			if (_offset != 0)
			{
				_rom = (UInt32)(_rom + _offset);
			}
			return (_rom - 0xC00);
		}
		#endregion

		#region Constants
		/// <summary>
		/// Start point of checksum 1
		/// </summary>
		public const UInt32 CHECKSUM_START = 0x1000;
		/// <summary>
		/// Length of data for checkum 1
		/// </summary>
		public const UInt32 CHECKSUM_LENGTH = 0x100000;

		#region CIC Identification Checksums
		public const UInt32 CHECKSUM_VALUE_6101 = 0x6170A4A1;
		public const UInt32 CHECKSUM_VALUE_6102 = 0x90BB6CB5;
		public const UInt32 CHECKSUM_VALUE_6103 = 0x0B050EE0;
		public const UInt32 CHECKSUM_VALUE_6105 = 0x98BC2C86;
		public const UInt32 CHECKSUM_VALUE_6106 = 0xACC8580A;
		#endregion

		#region Checksum Seeds
		/// <summary>
		/// Checksum seed for 6102 (and 6101) CIC.
		/// </summary>
		public const UInt32 CHECKSUM_SEED_6102 = 0xF8CA4DDC;

		/// <summary>
		/// Checksum seed for 6103 CIC.
		/// </summary>
		public const UInt32 CHECKSUM_SEED_6103 = 0xA3886759;

		/// <summary>
		/// Checksum seed for 6105 CIC.
		/// </summary>
		public const UInt32 CHECKSUM_SEED_6105 = 0xDF26F436;

		/// <summary>
		/// Checksum seed for 6106 CIC.
		/// </summary>
		public const UInt32 CHECKSUM_SEED_6106 = 0x1FEA617A;
		#endregion

		#endregion

		/// <summary>
		/// Actual ROM representation.
		/// </summary>
		public byte[] Data;

		#region Class Members
		/// <summary>
		/// CIC type used in the cartridge.
		/// </summary>
		public N64Cic CicType;

		/// <summary>
		/// Checksum 1 (offsets 0x10-0x13).
		/// </summary>
		public UInt32 Checksum1;

		/// <summary>
		/// Checksum 2 (offsets 0x14-0x17).
		/// </summary>
		public UInt32 Checksum2;

		// offsets 0x20-0x33 (20 bytes)
		/// <summary>
		/// Internal game title.
		/// </summary>
		public string InternalName;

		// offsets 0x3B-0x3E
		/// <summary>
		/// Game Code. Typically starts with 'N' and ends with a region code.
		/// </summary>
		/// Not sure if I should just make this two characters and use another variable for region/language/whatever
		public string GameCode;

		// offset 0x3F
		/// <summary>
		/// 
		/// </summary>
		/// <remarks>
		/// "Address 0x3F is used to store a character that identifies the
		/// 'mask ROM version' field. Together, the mask ROM version and
		/// 'submission version' (which refers indirectly to the EEPROM) fields
		/// constitute the 'ROM version' field, but only the mask ROM version
		/// is defined in the registration data. The ROM version is of the
		/// format [MASK ROM VERSION].[SUBMISSION VERSION], not the
		/// artificial (V1.[MASK ROM VERSION]) syntax that GoodN64 uses."
		/// - HatCat, http://forum.pj64-emu.com/showthread.php?t=2239
		/// </remarks>
		public byte GameVersion;
		#endregion

		/// <summary>
		/// Default constructor.
		/// </summary>
		public Z64Rom()
		{
			this.Data = null;
			this.CicType = N64Cic.CIC_6102;
			this.Checksum1 = 0;
			this.Checksum2 = 0;
			this.InternalName = String.Empty;
			this.GameCode = String.Empty;
			this.GameVersion = 0;
		}

		/// <summary>
		/// Default constructor using a path to a ROM file.
		/// </summary>
		/// <param name="_path">Path to Z64 ROM file to load.</param>
		public Z64Rom(string _path)
		{
			LoadFile(_path);
		}

		#region Load/Save
		/// <summary>
		/// Read data from a Z64 format ROM.
		/// </summary>
		/// <param name="_path">Path to Z64 format ROM.</param>
		public void LoadFile(string _path)
		{
			FileStream fs = new FileStream(_path, FileMode.Open);
			BinaryReader br = new BinaryReader(fs);

			fs.Seek(0, SeekOrigin.End);
			long length = fs.Position;
			fs.Seek(0, SeekOrigin.Begin);

			this.Data = br.ReadBytes((int)length);

			br.Close();
			fs.Close();

			MemoryStream ms = new MemoryStream(this.Data);
			br = new BinaryReader(ms);

			// get internal checksum 1
			ms.Seek(0x10, SeekOrigin.Begin);
			byte[] csum1 = new byte[4];
			ms.Read(csum1, 0, 4);
			if (BitConverter.IsLittleEndian)
			{
				Array.Reverse(csum1);
			}
			this.Checksum1 = BitConverter.ToUInt32(csum1, 0);

			// get internal checksum 2
			byte[] csum2 = new byte[4];
			ms.Read(csum2, 0, 4);
			if (BitConverter.IsLittleEndian)
			{
				Array.Reverse(csum2);
			}
			this.Checksum2 = BitConverter.ToUInt32(csum2, 0);

			// get internal name (0x20-0x33; 20 bytes)
			ms.Seek(0x20, SeekOrigin.Begin);
			byte[] gameName = new byte[20];
			ms.Read(gameName, 0, 20);
			this.InternalName = Encoding.GetEncoding("Shift-JIS").GetString(gameName);

			// get game code (0x3B)
			ms.Seek(0x3B, SeekOrigin.Begin);
			byte[] gameCode = new byte[4];
			ms.Read(gameCode, 0, 4);
			for (int i = 0; i < gameCode.Length; i++)
			{
				this.GameCode += (char)gameCode[i];
			}

			// get game version (0x3F)
			ms.Seek(0x3F, SeekOrigin.Begin);
			this.GameVersion = (byte)ms.ReadByte();

			// determine CIC type via checksumming
			this.CicType = GetCicType(br);

			ms.Close();
		}
		#endregion

		#region Helpers
		/// <summary>
		/// Get the CIC chip type by checksumming the boot code.
		/// </summary>
		/// <returns>N64Cic type</returns>
		public N64Cic GetCicType(BinaryReader br)
		{
			switch (Crc32.GetCRC32(br, 0x40, (0x1000 - 0x40)))
			{
				case CHECKSUM_VALUE_6101: return N64Cic.CIC_6101;
				case CHECKSUM_VALUE_6102: return N64Cic.CIC_6102;
				case CHECKSUM_VALUE_6103: return N64Cic.CIC_6103;
				case CHECKSUM_VALUE_6105: return N64Cic.CIC_6105;
				case CHECKSUM_VALUE_6106: return N64Cic.CIC_6106;
			}
			return N64Cic.Unknown;
		}
		#endregion

		#region Checksum-Related
		/// <summary>
		/// Determine if the internal checksums match the calculated checksums.
		/// </summary>
		/// <returns>True if internal checksums match calculated checksums; false otherwise.</returns>
		public bool HasValidChecksums()
		{
			UInt32[] calculated = CalculateChecksums();
			if (Checksum1 != calculated[0])
			{
				return false;
			}
			if (Checksum2 != calculated[1])
			{
				return false;
			}

			return true;
		}

		/// <summary>
		/// Re-calculate checksums.
		/// </summary>
		public void FixChecksums()
		{
			UInt32[] calculated = CalculateChecksums();
			Checksum1 = calculated[0];
			Checksum2 = calculated[1];

			byte[] calc1 = BitConverter.GetBytes(Checksum1);
			byte[] calc2 = BitConverter.GetBytes(Checksum2);

			if (BitConverter.IsLittleEndian)
			{
				Array.Reverse(calc1);
				Array.Reverse(calc2);
			}

			for (int i = 0; i < 4; i++)
			{
				Data[0x10 + i] = calc1[i];
				Data[0x14 + i] = calc2[i];
			}
		}

		/// <summary>
		/// Calculate checksums based on the ROM data.
		/// </summary>
		/// <returns></returns>
		public UInt32[] CalculateChecksums()
		{
			UInt32[] results = new UInt32[2];

			MemoryStream ms = new MemoryStream(this.Data);
			BinaryReader br = new BinaryReader(ms);

			UInt32 seed = 0;
			switch (this.CicType)
			{
				case N64Cic.CIC_6101:
				case N64Cic.CIC_6102:
					seed = CHECKSUM_SEED_6102;
					break;
				case N64Cic.CIC_6103:
					seed = CHECKSUM_SEED_6103;
					break;
				case N64Cic.CIC_6105:
					seed = CHECKSUM_SEED_6105;
					break;
				case N64Cic.CIC_6106:
					seed = CHECKSUM_SEED_6106;
					break;
			}

			UInt32 t1 = seed;
			UInt32 t2 = seed;
			UInt32 t3 = seed;
			UInt32 t4 = seed;
			UInt32 t5 = seed;
			UInt32 t6 = seed;
			UInt32 r = 0;
			UInt32 d = 0;

			ms.Seek(CHECKSUM_START, SeekOrigin.Begin);
			while (ms.Position < (CHECKSUM_START + CHECKSUM_LENGTH))
			{
				byte[] dBytes = br.ReadBytes(4);
				if (BitConverter.IsLittleEndian)
				{
					Array.Reverse(dBytes);
				}
				d = BitConverter.ToUInt32(dBytes, 0);

				if ((t6 + d) < t6)
				{
					t4++;
				}

				t6 += d;
				t3 ^= d;
				r = (((d) << (int)(d & 0x1F)) | (d) >> (32 - (int)(d & 0x1F)));

				t5 += r;

				if (t2 > d)
				{
					t2 ^= r;
				}
				else
				{
					t2 ^= t6 ^ d;
				}

				if (this.CicType == N64Cic.CIC_6105)
				{
					// ugh this sucks monkey nuts and idk if it even works
					long curPos = ms.Position;

					//t1 += BYTES2LONG(&data[N64_HEADER_SIZE + 0x0710 + (i & 0xFF)]) ^ d;
					ms.Seek(0x750 + (curPos & 0xFF), SeekOrigin.Begin);
					byte[] mess = br.ReadBytes(4);
					if (BitConverter.IsLittleEndian)
					{
						Array.Reverse(mess);
					}
					t1 += BitConverter.ToUInt32(mess, 0) ^ d;

					ms.Seek(curPos, SeekOrigin.Begin);
				}
				else
				{
					t1 += t5 ^ d;
				}
			}

			if (this.CicType == N64Cic.CIC_6103)
			{
				results[0] = (t6 ^ t4) + t3;
				results[1] = (t5 ^ t2) + t1;
			}
			else if (this.CicType == N64Cic.CIC_6106)
			{
				results[0] = (t6 * t4) + t3;
				results[1] = (t5 * t2) + t1;
			}
			else
			{
				results[0] = t6 ^ t4 ^ t3;
				results[1] = t5 ^ t2 ^ t1;
			}

			br.Close();
			ms.Close();

			return results;
		}
		#endregion

	}
}
