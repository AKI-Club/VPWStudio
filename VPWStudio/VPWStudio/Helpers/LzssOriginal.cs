using System;
using System.Collections.Generic;
using System.IO;

// General Notice:
// This is a mess. My primary goal is to get it working,
// then clean it up once I know the output is good.
namespace VPWStudio
{
	public class LzssOriginal
	{
		#region LzssMatchData
		protected class LzssMatchData
		{
			public int Position;
			public int Length;

			public LzssMatchData()
			{
				this.Position = 0;
				this.Length = 0;
			}

			public LzssMatchData(int _offset, int _length)
			{
				this.Position = _offset;
				this.Length = _length;
			}
		}
		#endregion

		#region Constants
		/// <summary>
		/// "N"/size of ring buffer
		/// </summary>
		protected static int BUFFER_SIZE = 4096;

		/// <summary>
		/// encode string into position and length if match_length is greater than this
		/// </summary>
		/// a.k.a. MAX_UNCODED
		protected static int THRESHOLD = 2;

		/// <summary>
		/// "F"/upper limit for match_length
		/// </summary>
		/// a.k.a. MAX_CODED
		protected static int MATCH_LIMIT = (15 + THRESHOLD + 1);

		/// <summary>
		/// index for root of binary search trees
		/// </summary>
		protected static int ROOT_TREE_INDEX = BUFFER_SIZE;
		#endregion

		#region Shared
		/// <summary>
		/// Left child
		/// </summary>
		protected static int[] lson = new int[BUFFER_SIZE + 1];

		/// <summary>
		/// Right child
		/// </summary>
		protected static int[] rson = new int[BUFFER_SIZE + 257];

		/// <summary>
		/// Parent
		/// </summary>
		protected static int[] dad = new int[BUFFER_SIZE + 1];

		/// <summary>
		/// 
		/// </summary>
		/// a.k.a. "LookaheadBuf"
		protected static byte[] code_buf = new byte[MATCH_LIMIT];

		/// <summary>
		/// Ring buffer
		/// </summary>
		protected static byte[] text_buf = new byte[BUFFER_SIZE + MATCH_LIMIT - 1];

		/// <summary>
		/// global bullshit volume 7
		/// </summary>
		protected static LzssMatchData MatchData = new LzssMatchData();
		#endregion

		/// <summary>
		/// 
		/// </summary>
		/// <param name="r"></param>
		protected static void InsertNode(int r)
		{
			// pain in the ass because "lol pointers, lol C#"
			int i;
			int cmp = 1;

			// unsigned char *key is meant to be a pointer into text_buf at location r.
			MemoryStream ms = new MemoryStream(text_buf);
			ms.Seek(r, SeekOrigin.Begin);

			int p = BUFFER_SIZE + 1 + ms.ReadByte();

			rson[r] = ROOT_TREE_INDEX;
			lson[r] = ROOT_TREE_INDEX;

			MatchData = new LzssMatchData();

			while (true)
			{
				if (cmp >= 0)
				{
					if (rson[p] != ROOT_TREE_INDEX)
					{
						p = rson[p];
					}
					else
					{
						rson[p] = r;
						dad[r] = p;
						ms.Close();
						return;
					}
				}
				else
				{
					if (lson[p] != ROOT_TREE_INDEX)
					{
						p = lson[p];
					}
					else
					{
						lson[p] = r;
						dad[r] = p;
						ms.Close();
						return;
					}
				}

				for (i = 1; i < MATCH_LIMIT; i++)
				{
					// this involves key
					cmp = ms.ReadByte() - text_buf[p + i];
					if(cmp != 0)
					{
						break;
					}
				}

				if (i > MatchData.Length)
				{
					// set position
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
			dad[p] = ROOT_TREE_INDEX;

			ms.Close();
		}

		/// <summary>
		/// Delete node from tree
		/// </summary>
		/// <param name="node">Node to remove</param>
		protected static void DeleteNode(int node)
		{
			int q = 0;
			if (dad[node] == ROOT_TREE_INDEX)
			{
				return;
			}

			if (rson[node] == ROOT_TREE_INDEX)
			{
				q = lson[node];
			}
			else if (lson[node] == ROOT_TREE_INDEX)
			{
				q = rson[node];
			}
			else
			{
				q = lson[node];
				if (rson[q] != ROOT_TREE_INDEX)
				{
					// do while
					do
					{
						q = rson[q];
					} while (rson[q] != ROOT_TREE_INDEX);

					rson[dad[q]] = lson[q];
					dad[lson[q]] = dad[q];
					lson[q] = lson[node];
					dad[lson[node]] = q;
				}
				rson[q] = rson[node];
				dad[rson[node]] = q;
			}

			dad[q] = dad[node];
			if (rson[dad[node]] == node)
			{
				rson[dad[node]] = q;
			}
			else
			{
				lson[dad[node]] = q;
			}
			dad[node] = ROOT_TREE_INDEX;
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="inFile"></param>
		/// <param name="outFile"></param>
		public static void Encode(BinaryReader inData, BinaryWriter outData)
		{
			// get length of input
			long curPos = inData.BaseStream.Position;
			UInt32 fileLen = 0;
			inData.BaseStream.Seek(0, SeekOrigin.End);
			fileLen = (UInt32)inData.BaseStream.Position;
			inData.BaseStream.Seek(curPos, SeekOrigin.Begin);

			// todo: write decompressed file length in big endian
			// but only after confirming the regular part works

			// init trees
			for (int i = (BUFFER_SIZE+1); i <= (BUFFER_SIZE+256); i++)
			{
				rson[i] = ROOT_TREE_INDEX;
			}
			for (int i = 0; i < BUFFER_SIZE; i++)
			{
				dad[i] = ROOT_TREE_INDEX;
			}

			// set up code buffer and index
			code_buf[0] = 0;
			int code_buf_ptr = 1;
			int mask = 1;
			int s = 0;
			int r = (BUFFER_SIZE - MATCH_LIMIT);
			int len;
			int lastMatchLen = 0;

			// fill buffer
			for (int i = 0; i < r; i++)
			{
				text_buf[i] = 0;
			}

			for (len = 0; len < MATCH_LIMIT && inData.BaseStream.Position != fileLen; len++)
			{
				text_buf[r + len] = inData.ReadByte();
			}

			for (int i = 1; i <= MATCH_LIMIT; i++)
			{
				InsertNode(r - i);
			}

			InsertNode(r);

			// big do/while loop
			do
			{
				// fix possible error
				if (MatchData.Length > len)
				{
					MatchData.Length = len;
				}

				if (code_buf_ptr >= code_buf.Length)
				{
					code_buf_ptr = 1;
				}

				if (MatchData.Length <= THRESHOLD)
				{
					MatchData.Length = 1;
					code_buf[0] |= (byte)mask;
					code_buf[code_buf_ptr++] = text_buf[r];
				}
				else
				{
					code_buf[code_buf_ptr++] = (byte)MatchData.Position;
					code_buf[code_buf_ptr++] = (byte)(((MatchData.Position >> 4) & 0xF0) | (MatchData.Length - (THRESHOLD + 1)));
				}

				if ((mask << 1) == 0)
				{
					for (int i = 0; i < code_buf_ptr; i++)
					{
						outData.Write(code_buf[i]);
					}

					code_buf[0] = 0;
					code_buf_ptr = 1;
					mask = 1;
				}

				lastMatchLen = MatchData.Length;

				int lmlCounter;
				for (lmlCounter = 0; lmlCounter < lastMatchLen && inData.BaseStream.Position != fileLen; lmlCounter++)
				{
					byte b = inData.ReadByte();
					DeleteNode(s);
					text_buf[s] = b;

					if (s < MATCH_LIMIT - 1)
					{
						text_buf[s + BUFFER_SIZE] = b;
					}

					s = (s + 1) % BUFFER_SIZE;
					r = (r + 1) % BUFFER_SIZE;

					InsertNode(r);
				}

				while (lmlCounter++ < lastMatchLen)
				{
					DeleteNode(s);
					s = (s + 1) % BUFFER_SIZE;
					r = (r + 1) % BUFFER_SIZE;
					if (--len != 0)
					{
						InsertNode(r);
					}
				}

			} while (len > 0); // xxx: until remaining string length is 0

			// send remaining code
			if (code_buf_ptr > 1)
			{
				for (int i = 0; i < code_buf_ptr; i++)
				{
					outData.Write(code_buf[i]);
				}
			}
		}
	}
}
