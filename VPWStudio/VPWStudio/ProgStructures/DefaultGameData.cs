using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace VPWStudio
{
	public class DefaultGameData
	{
		#region FileTable
		/// <summary>
		/// Default FileTable Data entry.
		/// </summary>
		public class DefaultFileTableData
		{
			/// <summary>
			/// FileTable offset in ROM.
			/// </summary>
			public Int32 FileTableOffset;

			/// <summary>
			/// FileTable length, in bytes.
			/// </summary>
			public Int32 FileTableLength;

			/// <summary>
			/// ROM offset of the first file in the FileTable.
			/// </summary>
			public UInt32 FirstFileOffset;

			/// <summary>
			/// Default constructor
			/// </summary>
			public DefaultFileTableData()
			{
				this.FileTableOffset = 0;
				this.FileTableLength = 0;
				this.FirstFileOffset = 0;
			}

			/// <summary>
			/// Specific constructor
			/// </summary>
			/// <param name="_fto">FileTable offset in ROM.</param>
			/// <param name="_ftl">FileTable length/size in bytes.</param>
			/// <param name="_firstFile">Location of first file in ROM.</param>
			public DefaultFileTableData(Int32 _fto, Int32 _ftl, UInt32 _firstFile)
			{
				this.FileTableOffset = _fto;
				this.FileTableLength = _ftl;
				this.FirstFileOffset = _firstFile;
			}
		}

		/// <summary>
		/// Default FileTable data for each game.
		/// </summary>
		public static Dictionary<SpecificGame, DefaultFileTableData> DefaultFileTables = new Dictionary<SpecificGame, DefaultFileTableData>()
		{
			{ SpecificGame.WorldTour_NTSC_U_10, new DefaultFileTableData(0x7C1A78, 21996, 0x39490) },
			{ SpecificGame.WorldTour_NTSC_U_11, new DefaultFileTableData(0x7C1C70, 21996, 0x39500) },
			{ SpecificGame.WorldTour_PAL, new DefaultFileTableData(0x7C1C00, 21996, 0x39490) },
			{ SpecificGame.VPW64_NTSC_J, new DefaultFileTableData(0xC7B578, 37432, 0x4AD00) },
			{ SpecificGame.Revenge_NTSC_U, new DefaultFileTableData(0xCE2752, 30632, 0xDAC50) },
			{ SpecificGame.Revenge_PAL, new DefaultFileTableData(0xCDFCE2, 30632, 0xD81E0) },
			{ SpecificGame.WM2K_NTSC_U, new DefaultFileTableData(0x11778BE, 41248, 0x144AA0) },
			{ SpecificGame.WM2K_NTSC_J, new DefaultFileTableData(0x116F3C2, 41480, 0x12C070) },
			{ SpecificGame.WM2K_PAL, new DefaultFileTableData(0x11778BE, 41248, 0x144AC0) },
			{ SpecificGame.VPW2_NTSC_J, new DefaultFileTableData(0x1310F40, 52364, 0x152DF0) },
			{ SpecificGame.NoMercy_NTSC_U_10, new DefaultFileTableData(0x16C3238, 77848, 0x1BD1B0) },
			{ SpecificGame.NoMercy_NTSC_U_11, new DefaultFileTableData(0x16C31D8, 77848, 0x1BD150) },
			{ SpecificGame.NoMercy_PAL_10, new DefaultFileTableData(0x16C32A8, 77848, 0x1BD220) },
			{ SpecificGame.NoMercy_PAL_11, new DefaultFileTableData(0x16C3148, 77848, 0x1BD0C0) },
		};
		#endregion

		// rethink how you want to handle the rest of this.
	}
}
