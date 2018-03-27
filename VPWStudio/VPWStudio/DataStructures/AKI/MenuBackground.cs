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
		#region Constants
		/// <summary>
		/// Number of horizontal chunks in the background image.
		/// </summary>
		private const int MENUBG_NUMCHUNKS_WIDE = 5;

		/// <summary>
		/// Number of vertical chunks in the background image.
		/// </summary>
		private const int MENUBG_NUMCHUNKS_TALL = 8;

		/// <summary>
		/// Total number of chunks in the menu background image.
		/// </summary>
		private const int MENUBG_NUMCHUNKS = MENUBG_NUMCHUNKS_WIDE * MENUBG_NUMCHUNKS_TALL;

		/// <summary>
		/// Width of each background chunk.
		/// </summary>
		private const int MENUBG_CHUNK_WIDTH = 64;

		/// <summary>
		/// Height of each background chunk.
		/// </summary>
		private const int MENUBG_CHUNK_HEIGHT = 30;

		/// <summary>
		/// Width of the full background.
		/// </summary>
		private const int MENUBG_WIDTH = MENUBG_CHUNK_WIDTH * MENUBG_NUMCHUNKS_WIDE;

		/// <summary>
		/// Height of the full background.
		/// </summary>
		private const int MENUBG_HEIGHT = MENUBG_CHUNK_HEIGHT * MENUBG_NUMCHUNKS_TALL;

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
		#endregion

		#region Constructors
		/// <summary>
		/// Default constructor.
		/// </summary>
		public MenuBackground()
		{
			FirstFileID = 0;
			Palette = new Ci4Palette();
			Textures = new Ci4Texture[MENUBG_NUMCHUNKS];
			InitTextures();
			Data = new byte[32 + ((MENUBG_CHUNK_WIDTH/2) * MENUBG_NUMCHUNKS_WIDE) + (MENUBG_CHUNK_HEIGHT * MENUBG_NUMCHUNKS_TALL)];
		}

		/// <summary>
		/// Specific constructor.
		/// </summary>
		/// <param name="_fileID">Beginning file ID.</param>
		public MenuBackground(int _fileID)
		{
			FirstFileID = _fileID;
			Palette = new Ci4Palette();
			Textures = new Ci4Texture[MENUBG_NUMCHUNKS];
			InitTextures();
			Data = new byte[32 + ((MENUBG_CHUNK_WIDTH / 2) * MENUBG_NUMCHUNKS_WIDE) + (MENUBG_CHUNK_HEIGHT * MENUBG_NUMCHUNKS_TALL)];
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
				Textures[i].ReadRawData(MENUBG_CHUNK_WIDTH, MENUBG_CHUNK_HEIGHT, br);
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
			for (int y = 0; y < MENUBG_NUMCHUNKS_TALL; y++)
			{
				for (int x = 0; x < MENUBG_NUMCHUNKS_WIDE; x++)
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
			for (int y = 0; y < MENUBG_NUMCHUNKS_TALL; y++)
			{
				for (int x = 0; x < MENUBG_NUMCHUNKS_WIDE; x++)
				{
					// draw each 64x30 chunk
					g.DrawImage(Textures[texNum].ToBitmap(Palette), new Point(x * MENUBG_CHUNK_WIDTH, y * MENUBG_CHUNK_HEIGHT));
					texNum++;
				}
			}
			g.Dispose();
			return outBmp;
		}
		#endregion

	}
}
