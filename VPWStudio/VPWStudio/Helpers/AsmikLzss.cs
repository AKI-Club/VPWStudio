using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace VPWStudio
{
	public static class AsmikLzss
	{
		// "default filesize is 3-bytes, skipping first which is compression indicator"
		// 0x00 | 1 byte  | 0x00 if compressed
		// 0x01 | 3 bytes | filesize, big-endian

		/// <summary>
		/// Decompress data using "Asmik" LZSS variant.
		/// </summary>
		/// <param name="inData">BinaryReader with the data to decompress.</param>
		/// <param name="outData">BinaryWriter pointing to an output stream.</param>
		/// Based off of Zoinkity's code from Midwaydec.
		public static void Decompress(BinaryReader inData, BinaryWriter outData)
		{
			byte[] header = inData.ReadBytes(4);
			// check if this file is really compressed
			if (header[0] != 0x00)
			{
				return;
			}
			UInt32 fileLength = 0;
			if (BitConverter.IsLittleEndian)
			{
				Array.Reverse(header);
			}
			fileLength = BitConverter.ToUInt32(header, 0);

			int command = 0;
			while (outData.BaseStream.Position < fileLength)
			{
				command >>= 1;
				if (command < 2)
				{
					command = inData.ReadByte() | 0x0100;
				}

				if ((command & 1) != 0)
				{
					outData.Write(inData.ReadByte());
				}
				else
				{
					int p = inData.ReadByte(); // position
					int l = inData.ReadByte(); // length
					p |= ((l << 4) & 0x0F00);
					l &= 0x0F;
					p += 0x12;
					p &= 0x0FFF;

					// "funky correction here"
					int c = ((int)(outData.BaseStream.Position) & 0x0FFF);
					p -= c;
					if (p >= 0)
					{
						p -= 0x1000;
					}
					p += (int)(outData.BaseStream.Position);

					for (int i = 0; i < l+3; i++)
					{
						int v = 0;
						if (p < 0)
						{
							v = 0;
						}
						else
						{
							long tempLoc = outData.BaseStream.Position;
							outData.Seek(p, SeekOrigin.Begin);
							v = outData.BaseStream.ReadByte();

							// fix
							outData.Seek((int)tempLoc, SeekOrigin.Begin);
						}
						outData.Write((byte)v);
						p += 1;
					}
				}
			}
		}

		// freem why are you trying this
		public static void Compress(BinaryReader inData, BinaryWriter outData)
		{
			// write header
			inData.BaseStream.Seek(0, SeekOrigin.End);
			UInt32 inFileSize = (UInt32)inData.BaseStream.Position;
			inData.BaseStream.Seek(0, SeekOrigin.Begin);

			byte[] fileSize = BitConverter.GetBytes(inFileSize);
			if (BitConverter.IsLittleEndian)
			{
				Array.Reverse(fileSize);
			}

			fileSize[0] = 0x00;
			outData.Write(fileSize);

			// now the hard part begins because lol what the fuck is any of this supposed to mean
		}
	}
}
