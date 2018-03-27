using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
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
		 * - VPW2: 64x30  chunks, 320x240 final image, 5 columns 8 rows
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

		private static Dictionary<VPWGames, int> MenuChunkWidth = new Dictionary<VPWGames, int>(){
			{ VPWGames.WorldTour, -1 },
			{ VPWGames.VPW64, -1 },
			{ VPWGames.Revenge, -1 },
			{ VPWGames.WM2K, 320 },
			{ VPWGames.VPW2, 64 },
		};

		private static Dictionary<VPWGames, int> MenuChunkHeight = new Dictionary<VPWGames, int>(){
			{ VPWGames.WorldTour, -1 },
			{ VPWGames.VPW64, -1 },
			{ VPWGames.Revenge, -1 },
			{ VPWGames.WM2K, 24 },
			{ VPWGames.VPW2, 30 },
		};

		private static Dictionary<VPWGames, int> MenuChunkColumns = new Dictionary<VPWGames, int>(){
			{ VPWGames.WorldTour, -1 },
			{ VPWGames.VPW64, -1 },
			{ VPWGames.Revenge, -1 },
			{ VPWGames.WM2K, 1 },
			{ VPWGames.VPW2, 5 },
		};

		private static Dictionary<VPWGames, int> MenuChunkRows = new Dictionary<VPWGames, int>(){
			{ VPWGames.WorldTour, -1 },
			{ VPWGames.VPW64, -1 },
			{ VPWGames.Revenge, -1 },
			{ VPWGames.WM2K, 10 },
			{ VPWGames.VPW2, 8 },
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

		// The main issue with the MenuBackground concept is that each menu
		// background consists of 40 files. These files are typically LZSS'd
		// as well, making our job harder.

		#region Binary Read/Write
		public void ReadData()
		{
			// this should be called AFTER FileTable.ExtractMenuBackground
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

		public void WriteData(BinaryWriter bw)
		{
			// todo: this is probably a clusterfuck.
		}
		#endregion

		#region Bitmap Read/Write
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

			Graphics g = Graphics.FromImage(b);

			// obtain palette
			Ci4Palette newPal = new Ci4Palette();
			for (int i = 0; i < b.Palette.Entries.Length; i++)
			{
				newPal.Entries[i] = N64Colors.ColorToValue5551(b.Palette.Entries[i]);
			}
			Palette = newPal;

			// do conversion
			int texNum = 0;
			for (int y = 0; y < ChunkRows; y++)
			{
				for (int x = 0; x < ChunkColumns; x++)
				{
					// convert each 64x30 chunk
					texNum++;
				}

				texNum++;
			}

			g.Dispose();
			return true;
		}

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
					// draw each 64x30 chunk
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
