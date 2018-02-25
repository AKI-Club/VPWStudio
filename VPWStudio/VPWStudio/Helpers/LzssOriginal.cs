using System;
using System.Collections.Generic;
using System.IO;

namespace VPWStudio
{
	public class LzssOriginal
	{
		#region Constants
		/// <summary>
		/// "N"/size of ring buffer
		/// </summary>
		protected static int BUFFER_SIZE = 4096;

		/// <summary>
		/// "F"/upper limit for match_length
		/// </summary>
		protected static int MATCH_LIMIT = 18;

		/// <summary>
		/// encode string into position and length if match_length is greater than this
		/// </summary>
		protected static int THRESHOLD = 2;

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
		/// Ring buffer
		/// </summary>
		protected static byte[] text_buf = new byte[BUFFER_SIZE + MATCH_LIMIT - 1];
		#endregion

		// xxx: what the fuck am I going to do about this?
		// the original code puts these two as global variables
		protected class MatchData
		{
			public int Position;
			public int Length;
		}

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

			MatchData md = new MatchData();

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

				if (i > md.Length)
				{
					// set position
					md.Length = i;
					if (md.Length >= MATCH_LIMIT)
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

		public static void Encode(BinaryReader inFile, BinaryWriter outFile)
		{
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
			//code_buf[0] = 0
			//code_buf_ptr = mask = 1;
			// s = 0; r = N - F;

			// fill buffer
			for (int i = 0; i < (BUFFER_SIZE - MATCH_LIMIT); i++)
			{
				text_buf[i] = 0;
			}
		}
	}
}
