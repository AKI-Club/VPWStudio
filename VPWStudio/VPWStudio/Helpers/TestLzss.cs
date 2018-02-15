using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace VPWStudio
{
	// generic LZSS test code; not particularly used in the program

	/*
	 * todo:
	 * it would seem that runs of 0 values are encoded using 0xL0,
	 * where L is the number of 0 bytes to output...
	 */
	
	public class TestLzss
	{
		#region Constants
		protected const int WINDOW_SIZE = 4096;
		protected const int MAX_UNCODED = 2;
		protected const int MAX_CODED = (15 + MAX_UNCODED + 1);
		#endregion

		protected static byte[] SlidingWindow = new byte[TestLzss.WINDOW_SIZE];
		protected static byte[] LookaheadBuf = new byte[MAX_CODED];

		private class LzssMatchData
		{
			/// <summary>
			/// Offset for this match.
			/// </summary>
			public int Offset;
			/// <summary>
			/// Length of this match.
			/// </summary>
			public int Length;

			public LzssMatchData()
			{
				this.Offset = 0;
				this.Length = 0;
			}

			public LzssMatchData(int _offset, int _length)
			{
				this.Offset = _offset;
				this.Length = _length;
			}
		}

		/// <summary>
		/// Brute-force match finding.
		/// </summary>
		/// <param name="windowPos"></param>
		/// <param name="uncodedPos"></param>
		/// <returns></returns>
		private static LzssMatchData FindMatch(int windowPos, int uncodedPos)
		{
			LzssMatchData md = new LzssMatchData();
			int i = windowPos;
			int j = 0;

			while (true)
			{
				if (SlidingWindow[i] == LookaheadBuf[uncodedPos])
				{
					j = 1;

					while (SlidingWindow[(i+j) % WINDOW_SIZE] == LookaheadBuf[(uncodedPos + j) % MAX_CODED])
					{
						if (j >= MAX_CODED)
						{
							break;
						}
						j++;
					}

					if (j > md.Length)
					{
						md.Length = j;
						md.Offset = i;
					}
				}

				if (j >= MAX_CODED)
				{
					md.Length = MAX_CODED;
					break;
				}
				i = (i + 1) % WINDOW_SIZE;
				if (i == windowPos)
				{
					break;
				}
			}

			return md;
		}

		public static void Compress(BinaryReader inData, BinaryWriter outData)
		{
			// Asmik LZSS header (decompressed file size)
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

			int windowHead = 0;
			int uncodedHead = 0;

			for (int i = 0; i < SlidingWindow.Length; i++)
			{
				SlidingWindow[i] = (byte)'\0';
			}

			int length;
			for (length = 0; length < MAX_CODED; length++)
			{
				byte b = inData.ReadByte();
				LookaheadBuf[length] = b;
			}

			LzssMatchData md = FindMatch(windowHead, uncodedHead);

			int flags = 0;
			int flagPos = 1;
			byte[] encodedData = new byte[16];
			int nextEncode = 0;

			// encode until eof
			while (length > 0)
			{
				if (md.Length > length)
				{
					// garbage beyond data extended match length; fix
					md.Length = length;
				}

				if (md.Length <= MAX_UNCODED)
				{
					// uncoded character
					md.Length = 1;

					flags |= flagPos;
					encodedData[nextEncode] = LookaheadBuf[uncodedHead];
					nextEncode++;
				}
				else
				{
					// coded character
					// (no mercy 0x1BD150) first control byte should be 0xE0, but is 0x00
					encodedData[nextEncode] = (byte)((md.Offset & 0x0FFF) >> 4);
					nextEncode++;

					// (no mercy 0x1BD150) second control byte should be 0xFB, but is 0x3B
					encodedData[nextEncode] = (byte)(((md.Offset & 0x000F) << 4) | (md.Length - (MAX_UNCODED + 1)));
					nextEncode++;
				}

				if (flagPos == 0x80)
				{
					// write flags
					outData.Write((byte)flags);
					// write encoded data
					for (int i = 0; i < nextEncode; i++)
					{
						outData.Write(encodedData[i]);
					}

					// reset
					flags = 0;
					flagPos = 1;
					nextEncode = 0;
				}
				else
				{
					flagPos <<= 1;
				}

				int replaceCount = 0;
				while (replaceCount < md.Length)
				{
					int r = inData.Read();
					if (r == -1)
					{
						break;
					}

					SlidingWindow[windowHead] = LookaheadBuf[uncodedHead];
					LookaheadBuf[uncodedHead] = (byte)r;

					windowHead = (windowHead + 1) % WINDOW_SIZE;
					uncodedHead = (uncodedHead + 1) % MAX_CODED;
					replaceCount++;
				}

				while (replaceCount < md.Length)
				{
					SlidingWindow[windowHead] = LookaheadBuf[uncodedHead];

					windowHead = (windowHead + 1) % WINDOW_SIZE;
					uncodedHead = (uncodedHead + 1) % MAX_CODED;
					length--;
					replaceCount++;
				}

				// next match
				md = FindMatch(windowHead, uncodedHead);
			}
		}
	}
}
