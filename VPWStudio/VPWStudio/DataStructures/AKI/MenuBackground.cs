using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
//using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace VPWStudio
{
	/// <summary>
	/// Menu Background image.
	/// </summary>
	public class MenuBackground
	{
		/*
		 * Known Sizes
		 * - WM2K: 320x24 chunks, 320x240 final image, 1 column 10 rows
		 * - VPW2, No Mercy: 64x30  chunks, 320x240 final image, 5 columns 8 rows
		 */

		#region Constants
		/// <summary>
		/// Width of the full background.
		/// </summary>
		private const int MENUBG_WIDTH = 320;

		/// <summary>
		/// Height of the full background.
		/// </summary>
		private const int MENUBG_HEIGHT = 240;

		/// <summary>
		/// Number of chunk columns in one row of the MenuBackground.
		/// </summary>
		private static Dictionary<VPWGames, int> MenuChunkColumns = new Dictionary<VPWGames, int>(){
			{ VPWGames.WorldTour, -1 },
			{ VPWGames.VPW64, -1 },
			{ VPWGames.Revenge, -1 },
			{ VPWGames.WM2K, 1 },
			{ VPWGames.VPW2, 5 },
			{ VPWGames.NoMercy, 5 },
		};

		/// <summary>
		/// Number of chunk rows in one column of the MenuBackground.
		/// </summary>
		private static Dictionary<VPWGames, int> MenuChunkRows = new Dictionary<VPWGames, int>(){
			{ VPWGames.WorldTour, -1 },
			{ VPWGames.VPW64, -1 },
			{ VPWGames.Revenge, -1 },
			{ VPWGames.WM2K, 10 },
			{ VPWGames.VPW2, 8 },
			{ VPWGames.NoMercy, 8 },
		};

		/// <summary>
		/// Width of each MenuBackground chunk.
		/// </summary>
		private static Dictionary<VPWGames, int> MenuChunkWidth = new Dictionary<VPWGames, int>(){
			{ VPWGames.WorldTour, -1 },
			{ VPWGames.VPW64, -1 },
			{ VPWGames.Revenge, -1 },
			{ VPWGames.WM2K, MENUBG_WIDTH },
			{ VPWGames.VPW2, MENUBG_WIDTH/MenuChunkColumns[VPWGames.VPW2] },
			{ VPWGames.NoMercy, MENUBG_WIDTH/MenuChunkColumns[VPWGames.NoMercy] },
		};

		/// <summary>
		/// Height of each MenuBackground chunk.
		/// </summary>
		private static Dictionary<VPWGames, int> MenuChunkHeight = new Dictionary<VPWGames, int>(){
			{ VPWGames.WorldTour, -1 },
			{ VPWGames.VPW64, -1 },
			{ VPWGames.Revenge, -1 },
			{ VPWGames.WM2K, MENUBG_HEIGHT/MenuChunkRows[VPWGames.WM2K] },
			{ VPWGames.VPW2, MENUBG_HEIGHT/MenuChunkRows[VPWGames.VPW2] },
			{ VPWGames.NoMercy, MENUBG_HEIGHT/MenuChunkRows[VPWGames.NoMercy] },
		};
		#endregion

		#region Class Members
		/// <summary>
		/// Palette shared between all textures.
		/// </summary>
		public Ci4Palette Palette;

		/// <summary>
		/// Textures making up the background.
		/// </summary>
		public Ci4Texture[] Textures;

		/// <summary>
		/// The first file ID of this background.
		/// </summary>
		public int FirstFileID;

		/// <summary>
		/// All background data.
		/// </summary>
		public byte[] Data;

		/// <summary>
		/// Width of each chunk making up the background image.
		/// </summary>
		public int ChunkWidth;

		/// <summary>
		/// Height of each chunk making up the background image.
		/// </summary>
		public int ChunkHeight;

		/// <summary>
		/// Number of columns of chunks to write.
		/// </summary>
		public int ChunkColumns;

		/// <summary>
		/// Number of rows of chunks to write.
		/// </summary>
		public int ChunkRows;
		#endregion

		#region Constructors
		/// <summary>
		/// Default constructor.
		/// </summary>
		public MenuBackground()
		{
			FirstFileID = 0;
			Palette = new Ci4Palette();

			// default to VPW2
			ChunkWidth = 64;
			ChunkHeight = 30;
			ChunkColumns = 5;
			ChunkRows = 8;
			Textures = new Ci4Texture[ChunkColumns * ChunkRows];
			InitTextures();
			Data = new byte[32 + ((ChunkWidth / 2) * ChunkColumns) + (ChunkHeight * ChunkRows)];
		}

		/// <summary>
		/// Specific constructor.
		/// </summary>
		/// <param name="_fileID">Beginning file ID.</param>
		public MenuBackground(int _fileID)
		{
			FirstFileID = _fileID;
			Palette = new Ci4Palette();

			// default to VPW2
			ChunkWidth = 64;
			ChunkHeight = 30;
			ChunkColumns = 5;
			ChunkRows = 8;
			Textures = new Ci4Texture[ChunkColumns * ChunkRows];
			InitTextures();
			Data = new byte[32 + ((ChunkWidth / 2) * ChunkColumns) + (ChunkHeight * ChunkRows)];
		}

		/// <summary>
		/// Specific constructor using a specified game type.
		/// </summary>
		/// <param name="_fileID">Beginning file ID.</param>
		/// <param name="baseGame">Game Type to use.</param>
		public MenuBackground(int _fileID, VPWGames baseGame)
		{
			FirstFileID = _fileID;
			Palette = new Ci4Palette();

			// get values from game
			ChunkWidth = MenuChunkWidth[baseGame];
			ChunkHeight = MenuChunkHeight[baseGame];
			ChunkColumns = MenuChunkColumns[baseGame];
			ChunkRows = MenuChunkRows[baseGame];
			Textures = new Ci4Texture[ChunkColumns * ChunkRows];
			InitTextures();
			Data = new byte[32 + ((ChunkWidth / 2) * ChunkColumns) + (ChunkHeight * ChunkRows)];
		}

		/// <summary>
		/// Specific constructor using specific values.
		/// </summary>
		/// <param name="_fileID">Beginning file ID.</param>
		/// <param name="width">Chunk Width</param>
		/// <param name="height">Chunk Height</param>
		/// <param name="cols">Number of Chunks per Column</param>
		/// <param name="rows">Number of Chunks per Row</param>
		public MenuBackground(int _fileID, int width, int height, int cols, int rows)
		{
			FirstFileID = _fileID;
			Palette = new Ci4Palette();
			ChunkWidth = width;
			ChunkHeight = height;
			ChunkColumns = cols;
			ChunkRows = rows;
			Textures = new Ci4Texture[ChunkColumns * ChunkRows];
			InitTextures();
			Data = new byte[32 + ((ChunkWidth / 2) * ChunkColumns) + (ChunkHeight * ChunkRows)];
		}

		/// <summary>
		/// Helper used to set up the Textures array.
		/// </summary>
		private void InitTextures()
		{
			for (int i = 0; i < Textures.Length; i++) {
				Textures[i] = new Ci4Texture();
			}
		}
		#endregion

		/// <summary>
		/// Get the chunk data for a part of the background.
		/// </summary>
		/// <param name="chunkNum">Background chunk number to get data for</param>
		/// <returns>Background chunk data as byte array</returns>
		public byte[] GetChunkBytes(int chunkNum)
		{
			if (chunkNum == 0)
			{
				// special case: palette and first chunk
				List<byte> firstChunk = new List<byte>();

				MemoryStream pms = new MemoryStream();
				BinaryWriter pbw = new BinaryWriter(pms);
				Palette.WriteData(pbw);
				firstChunk.AddRange(pms.ToArray());
				firstChunk.AddRange(Textures[chunkNum].Data);
				pbw.Close();

				return firstChunk.ToArray();
			}
			else
			{
				// normal case: chunk
				return Textures[chunkNum].Data;
			}
		}

		// The main issue with the MenuBackground concept is that each menu
		// background consists of 40 files. These files are typically LZSS'd
		// as well, making our job harder.

		#region Binary Read/Write
		/// <summary>
		/// Read MenuBackground data.
		/// FileTable.ExtractMenuBackground *MUST BE* called before this.
		/// </summary>
		public void ReadData()
		{
			MemoryStream ms = new MemoryStream(Data);
			BinaryReader br = new BinaryReader(ms);

			// palette
			Palette.ReadData(br);

			// textures
			for (int i = 0; i < Textures.Length; i++)
			{
				Textures[i].ReadRawData(ChunkWidth, ChunkHeight, br);
			}

			br.Close();
		}

		/// <summary>
		/// Write MenuBackground data.
		/// </summary>
		/// <returns>Array of bytes with the MenuBackground data.</returns>
		public byte[] WriteData()
		{
			using (MemoryStream outStream = new MemoryStream())
			{
				using (BinaryWriter bw = new BinaryWriter(outStream))
				{
					// palette
					Palette.WriteData(bw);

					// textures; only write the pixels
					for (int i = 0; i < Textures.Length; i++)
					{
						bw.Write(Textures[i].Data);
					}

					return outStream.ToArray();
				}
			}
		}
		#endregion

		#region Bitmap Read/Write
		/// <summary>
		/// Convert the specified Bitmap into a MenuBackground.
		/// </summary>
		/// <param name="b">Bitmap to convert</param>
		/// <returns>Returns true if conversion was successful; false otherwise.</returns>
		public bool FromBitmap(Bitmap b)
		{
			// check for invalid size
			if (b.Width != 320 || b.Height != 240)
			{
				return false;
			}
			// check for invalid palette
			if (b.PixelFormat != PixelFormat.Format4bppIndexed)
			{
				return false;
			}

			// obtain palette
			Ci4Palette newPal = new Ci4Palette();
			SortedList<int, Color> BitmapColors = new SortedList<int, Color>();
			for (int i = 0; i < b.Palette.Entries.Length; i++)
			{
				BitmapColors.Add(i, b.Palette.Entries[i]);
				newPal.Entries[i] = N64Colors.ColorToValue5551(b.Palette.Entries[i]);
			}
			Palette = newPal;

			// convert textures, one chunk at a time
			int texNum = 0;
			for (int curRow = 0; curRow < ChunkRows; curRow++)
			{
				for (int curCol = 0; curCol < ChunkColumns; curCol++)
				{
					Bitmap curChunk = b.Clone(new Rectangle(curCol * ChunkWidth, curRow * ChunkHeight, ChunkWidth, ChunkHeight), PixelFormat.Format4bppIndexed);
					curChunk.Palette = b.Palette;
					Textures[texNum].FromBitmap(curChunk);
					texNum++;
				}
			}

			return true;
		}

		/// <summary>
		/// Convert this MenuBackground to a Bitmap.
		/// </summary>
		/// <returns>Bitmap with the MenuBackground data.</returns>
		public Bitmap ToBitmap()
		{
			Bitmap outBmp = new Bitmap(MENUBG_WIDTH, MENUBG_HEIGHT);
			Graphics g = Graphics.FromImage(outBmp);

			// go through and convert each Ci4Texture using the Ci4Palette.
			int texNum = 0;
			for (int y = 0; y < ChunkRows; y++)
			{
				for (int x = 0; x < ChunkColumns; x++)
				{
					// draw each chunk
					g.DrawImage(Textures[texNum].ToBitmap(Palette), new Point(x * ChunkWidth, y * ChunkHeight));
					texNum++;
				}
			}
			g.Dispose();
			return outBmp;
		}
		#endregion

	}
}
