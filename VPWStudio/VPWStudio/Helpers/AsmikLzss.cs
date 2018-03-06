using System;
using System.Collections.Generic;
using System.IO;

namespace VPWStudio
{
	public class AsmikLzss
	{
		#region Decoding
		// "default filesize is 3-bytes, skipping first which is compression indicator"
		// 0x00 | 1 byte  | 0x00 if compressed
		// 0x01 | 3 bytes | filesize, big-endian

		/// <summary>
		/// Decode/decompress data using "Asmik" LZSS variant.
		/// </summary>
		/// <param name="inData">BinaryReader with the data to decompress.</param>
		/// <param name="outData">BinaryWriter pointing to an output stream.</param>
		/// Based off of Zoinkity's code from Midwaydec.
		public static void Decode(BinaryReader inData, BinaryWriter outData)
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

					for (int i = 0; i < l + 3; i++)
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
		#endregion

		// WARNING THIS PART IS UGLY, OPEN IT AT YOUR OWN RISK!!!!!
		// I literally got it working and decided to move on to
		// other things instead of trying to clean it up.
		#region Encoding
		private class LzssMatchData
		{
			public int Position;
			public int Length;

			public LzssMatchData()
			{
				Position = 0;
				Length = 0;
			}

			public LzssMatchData(int _pos, int _len)
			{
				Position = _pos;
				Length = _len;
			}
		}

		#region Constants and Members
		/// <summary>
		/// "N"/size of ring buffer
		/// </summary>
		private static int BUFFER_SIZE = 4096;

		/// <summary>
		/// encode string into position and length if match_length is greater than this
		/// </summary>
		/// a.k.a. MAX_UNCODED
		private static int THRESHOLD = 2;

		/// <summary>
		/// "F"/upper limit for match_length
		/// </summary>
		/// a.k.a. MAX_CODED
		private static int MATCH_LIMIT = (15 + THRESHOLD + 1);

		// idx = 4078; "idx is typically ring - limit."
		private static int BufferIndex = BUFFER_SIZE - MATCH_LIMIT;

		private static int NIL_VALUE = BUFFER_SIZE;

		/// <summary>
		/// Left child
		/// </summary>
		/// fill with 0
		private static int[] lson = new int[BUFFER_SIZE + 1];

		/// <summary>
		/// Right child
		/// </summary>
		/// fill with 0 for the first BUFFER_SIZE+1 entries, then NIL_VALUE for the remaining 256
		private static int[] rson = new int[BUFFER_SIZE + 257];

		/// <summary>
		/// Parent
		/// </summary>
		/// fill with NIL_VALUE
		private static int[] dad = new int[BUFFER_SIZE + 1];

		private static byte[] RingBuffer = new byte[BUFFER_SIZE + MATCH_LIMIT];

		/// <summary>
		/// Shared match data.
		/// </summary>
		private static LzssMatchData MatchData;
		#endregion

		/// <summary>
		/// Insert a node
		/// </summary>
		/// <param name="n"></param>
		// broken code
		/*
		private static void InsertNode(int n)
		{
			int cmp = 1;

			// key and pos are a pain
			MemoryStream ms = new MemoryStream(RingBuffer);
			ms.Seek(n, SeekOrigin.Begin);
			int key = ms.ReadByte();
			int pos = BUFFER_SIZE + 1 + key;

			rson[n] = NIL_VALUE;
			lson[n] = NIL_VALUE;

			while (true)
			{
				if (cmp >= 0)
				{
					if (rson[pos] == NIL_VALUE)
					{
						pos = rson[pos];
					}
					else
					{
						rson[pos] = n;
						dad[n] = pos;
						ms.Close();
						return;
					}
				}
				else
				{
					if (lson[pos] != NIL_VALUE)
					{
						pos = lson[pos];
					}
					else
					{
						lson[pos] = n;
						dad[n] = pos;
						ms.Close();
						return;
					}
				}

				int i = 1;
				for (i = 1; i < MATCH_LIMIT + 1; i++)
				{
					cmp = ms.ReadByte() - RingBuffer[pos + i];
					if (cmp != 0)
					{
						break;
					}
				}
				if (i > MatchData.Length)
				{
					MatchData.Position = pos;
					MatchData.Length = i;
					if (MatchData.Length >= MATCH_LIMIT)
					{
						break;
					}
				}
			}

			dad[n] = dad[pos];
			lson[n] = lson[pos];
			rson[n] = rson[pos];
			dad[lson[pos]] = n;
			dad[rson[pos]] = n;

			if (rson[dad[pos]] == pos)
			{
				rson[dad[pos]] = n;
			}
			else
			{
				lson[dad[pos]] = n;
			}
			dad[pos] = NIL_VALUE;
		}
		*/

		// not zoinkity's code
		protected static void InsertNode(int r)
		{
			// pain in the ass because "lol pointers, lol C#"
			int i;
			int cmp = 1;

			byte[] key = new byte[RingBuffer.Length];
			for (int j = 0; r + j < RingBuffer.Length; j++)
			{
				key[j] = RingBuffer[r + j];
			}

			int p = BUFFER_SIZE + 1 + key[0];

			rson[r] = NIL_VALUE;
			lson[r] = NIL_VALUE;

			MatchData = new LzssMatchData();

			while (true)
			{
				if (cmp >= 0)
				{
					if (rson[p] != NIL_VALUE)
					{
						p = rson[p];
					}
					else
					{
						rson[p] = r;
						dad[r] = p;
						return;
					}
				}
				else
				{
					if (lson[p] != NIL_VALUE)
					{
						p = lson[p];
					}
					else
					{
						lson[p] = r;
						dad[r] = p;
						return;
					}
				}

				for (i = 1; i < MATCH_LIMIT; i++)
				{
					// this involves key
					cmp = key[i] - RingBuffer[p + i];
					if (cmp != 0)
					{
						break;
					}
				}

				if (i > MatchData.Length)
				{
					// set position
					MatchData.Position = p;
					MatchData.Length = i;
					if (MatchData.Length >= MATCH_LIMIT)
					{
						break;
					}
				}
			}

			dad[r] = dad[p];
			lson[r] = lson[p];
			rson[r] = rson[p];
			dad[lson[p]] = r;
			dad[rson[p]] = r;

			if (rson[dad[p]] == p)
			{
				rson[dad[p]] = r;
			}
			else
			{
				lson[dad[p]] = r;
			}

			// remove p
			dad[p] = NIL_VALUE;
		}

		/// <summary>
		/// Delete a node
		/// </summary>
		/// <param name="n"></param>
		private static void DeleteNode(int n)
		{
			if (dad[n] == NIL_VALUE)
			{
				return;
			}

			int q;
			if (rson[n] == NIL_VALUE)
			{
				q = lson[n];
			}
			else if (lson[n] == NIL_VALUE)
			{
				q = rson[n];
			}
			else
			{
				q = lson[n];
				if (rson[q] != NIL_VALUE)
				{
					do
					{
						q = rson[q];
					} while (rson[q] != NIL_VALUE);
					rson[dad[q]] = lson[q];
					dad[lson[q]] = dad[q];
					lson[q] = lson[n];
					dad[lson[n]] = q;
				}
				rson[q] = rson[n];
				dad[rson[n]] = q;
			}
			dad[q] = dad[n];
			if (rson[dad[n]] == n)
			{
				rson[dad[n]] = q;
			}
			else
			{
				lson[dad[n]] = q;
			}

			dad[n] = NIL_VALUE;
		}

		public static void Encode(BinaryReader inData, BinaryWriter outData)
		{
			// [AKI/Asmik specific] get decompressed size for the input file
			long curPos = inData.BaseStream.Position;
			UInt32 fileLen = 0;
			inData.BaseStream.Seek(0, SeekOrigin.End);
			fileLen = (UInt32)inData.BaseStream.Position;
			inData.BaseStream.Seek(curPos, SeekOrigin.Begin);
			byte[] fsize = BitConverter.GetBytes(fileLen);
			if (BitConverter.IsLittleEndian)
			{
				Array.Reverse(fsize);
			}
			fsize[0] = 0x00;
			outData.Write(fsize);
			byte[] inBytes = inData.ReadBytes((int)fileLen);
			inData.Close();

			// perform initialization
			for (int i = 0; i < RingBuffer.Length; i++)
			{
				RingBuffer[i] = 0;
			}
			MatchData = new LzssMatchData();

			for (int i = 0; i < lson.Length; i++)
			{
				lson[i] = 0;
			}
			for (int i = 0; i < BUFFER_SIZE + 1; i++)
			{
				rson[i] = 0;
			}
			for (int i = BUFFER_SIZE + 1; i < rson.Length; i++)
			{
				rson[i] = NIL_VALUE;
			}
			for (int i = 0; i < dad.Length; i++)
			{
				dad[i] = NIL_VALUE;
			}

			UInt16 mask = 0xFF00;
			List<byte> codebuf = new List<byte>();

			int s = 0;

			// "read limit bytes into the ring at idx"
			int p = (int)Math.Min(MATCH_LIMIT, inBytes.Length - 1);
			for (int i = 0; i < p; i++)
			{
				RingBuffer[i + BufferIndex] = inBytes[i];
			}
			int cur = p;
			for (int i = 1; i < MATCH_LIMIT + 1; i++)
			{
				InsertNode(BufferIndex - i);
			}
			InsertNode(BufferIndex);

			while (true)
			{
				mask >>= 1;

				// fix possible error
				if (MatchData.Length > p)
				{
					MatchData.Length = p;
				}

				if (MatchData.Length <= THRESHOLD)
				{
					MatchData.Length = 1;
					codebuf.Add((byte)RingBuffer[BufferIndex]);
				}
				else
				{
					mask ^= 128;

					int a = (MatchData.Position >> 4) & 0xF0;
					a |= (MatchData.Length - THRESHOLD - 1);
					int b = MatchData.Position & 0xFF;
					if (BitConverter.IsLittleEndian)
					{
						codebuf.Add((byte)b);
						codebuf.Add((byte)a);
					}
					else
					{
						codebuf.Add((byte)a);
						codebuf.Add((byte)b);
					}
				}

				// flush when mask is full.
				if (mask < 256)
				{
					outData.Write((byte)mask);
					outData.Write(codebuf.ToArray());
					codebuf.Clear();
					mask = 0xFF00;
				}

				int prevMatchLen = MatchData.Length;
				int j = Math.Min(prevMatchLen, (inBytes.Length - cur));
				for (int i = 0; i < j; i++)
				{
					DeleteNode(s);
					RingBuffer[s] = inBytes[cur];
					if (s < MATCH_LIMIT - 1)
					{
						RingBuffer[s + BUFFER_SIZE] = inBytes[cur];
					}
					cur += 1;
					s += 1;
					s &= (BUFFER_SIZE - 1);
					BufferIndex += 1;
					BufferIndex &= (BUFFER_SIZE - 1);
					InsertNode(BufferIndex);
				}

				for (int i = j; i < prevMatchLen; i++)
				{
					DeleteNode(s);
					s += 1;
					s &= (BUFFER_SIZE - 1);
					BufferIndex += 1;
					BufferIndex &= (BUFFER_SIZE - 1);
					p -= 1;
					if (p != 0)
					{
						InsertNode(BufferIndex);
					}
				}

				if (p == 0)
				{
					break;
				}
			}

			// final
			if (codebuf.Count > 0)
			{
				//l = mask.bit_length() - 8
				// bit_length returns the number of bits needed to represent the integer
				int temp = mask;
				int l = 0;
				do
				{
					l++;
				} while ((temp >>= 1) != 0);
				l -= 8;

				mask &= 0xFF;
				outData.Write((byte)(mask >> l));
				outData.Write(codebuf.ToArray());
			}

			// handle alignment (todo: this belongs elsewhere)
			if (outData.BaseStream.Position % 2 != 0)
			{
				outData.Write((byte)0);
			}
		}
		#endregion
	}
}
