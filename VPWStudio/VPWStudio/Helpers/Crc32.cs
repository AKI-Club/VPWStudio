using System;
using System.IO;

namespace VPWStudio
{
	/// <summary>
	/// CRC32 checksum generator.
	/// </summary>
	public class Crc32
	{
		/// <summary>
		/// Default CRC32 polynomial.
		/// </summary>
		public const uint DefaultPolynomial = 0xEDB88320;

		/// <summary>
		/// CRC table, generated at runtime. (See Crc32.GenerateTable)
		/// </summary>
		public static uint[] CrcTable = new uint[256];

		/// <summary>
		/// Generate CRC table.
		/// </summary>
		public static void GenerateTable()
		{
			uint polynomial = Crc32.DefaultPolynomial;
			for (int i = 0; i < Crc32.CrcTable.Length; i++)
			{
				uint crc = (uint)i;
				for (int j = 8; j > 0; j--)
				{
					if ((crc & 1) != 0)
					{
						crc = (crc >> 1) ^ polynomial;
					}
					else
					{
						crc >>= 1;
					}
				}
				Crc32.CrcTable[i] = crc;
			}
		}

		/// <summary>
		/// Get the CRC32 value for a specific portion of data from a BinaryReader.
		/// </summary>
		/// <param name="br">BinaryReader instance to use.</param>
		/// <param name="startPos">Start position for checksumming.</param>
		/// <param name="length">Length of data to checksum.</param>
		/// <returns>CRC32 as uint</returns>
		public static uint GetCRC32(BinaryReader br, long startPos, long length)
		{
			// calculate CRC32
			uint crc = 0xFFFFFFFFu;
			br.BaseStream.Seek(startPos, SeekOrigin.Begin);

			for (int i = 0; i < length; i++)
			{
				crc = (crc >> 8) ^ Crc32.CrcTable[(crc ^ br.ReadByte()) & 0xFF];
			}

			// convert result to expected format
			byte[] result = BitConverter.GetBytes(~crc);
			if (!BitConverter.IsLittleEndian)
			{
				Array.Reverse(result);
			}
			return BitConverter.ToUInt32(result, 0);
		}
	}
}
