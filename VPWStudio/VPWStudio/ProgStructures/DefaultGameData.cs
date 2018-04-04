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
		#region Offsets
		/// <summary>
		/// An entry in DefaultLocationData.
		/// </summary>
		public class DefaultLocationDataEntry
		{
			public UInt32 Offset;
			public UInt32 Length;

			public DefaultLocationDataEntry()
			{
				this.Offset = 0;
				this.Length = 0;
			}

			public DefaultLocationDataEntry(UInt32 _off, UInt32 _len)
			{
				this.Offset = _off;
				this.Length = _len;
			}
		}

		/// <summary>
		/// Default location data.
		/// </summary>
		public class DefaultLocationData
		{
			public Dictionary<string, DefaultLocationDataEntry> Locations;

			public DefaultLocationData()
			{
				this.Locations = new Dictionary<string, DefaultLocationDataEntry>();
			}

			public DefaultLocationData(Dictionary<string, DefaultLocationDataEntry> _entry)
			{
				this.Locations = _entry;
			}
		}

		/// <summary>
		/// Fallback LocationData for each SpecificGame.
		/// </summary>
		/// This primarily exists so the program can still be useful without the LocationFiles directory.
		public static Dictionary<SpecificGame, DefaultLocationData> DefaultLocations = new Dictionary<SpecificGame, DefaultLocationData>()
		{
			{
				SpecificGame.WorldTour_NTSC_U_10,
				new DefaultLocationData(new Dictionary<string, DefaultLocationDataEntry>(){
					{ "StableDefs", new DefaultLocationDataEntry(0x37EC8, 96) },
					{ "FirstFile", new DefaultLocationDataEntry(0x39490, 0) },
					{ "FileTable", new DefaultLocationDataEntry(0x7C1A78, 21996) },
					{ "BodyTypeDefs", new DefaultLocationDataEntry(0x2F100, 176) },
					//{ "CostumeDefs", new DefaultLocationDataEntry(0x3368C, ?) },
				})
			},
			{
				SpecificGame.WorldTour_NTSC_U_11,
				new DefaultLocationData(new Dictionary<string, DefaultLocationDataEntry>(){
					{ "StableDefs", new DefaultLocationDataEntry(0x37F38, 96) },
					{ "FirstFile", new DefaultLocationDataEntry(0x39500, 0) },
					{ "FileTable", new DefaultLocationDataEntry(0x7C1C70, 21996) },
					{ "BodyTypeDefs", new DefaultLocationDataEntry(0x2F170, 176) },
					//{ "CostumeDefs", new DefaultLocationDataEntry(0x336FC, ?) },
				})
			},
			{
				SpecificGame.WorldTour_PAL,
				new DefaultLocationData(new Dictionary<string, DefaultLocationDataEntry>(){
					{ "StableDefs", new DefaultLocationDataEntry(0x37EC8, 96) },
					{ "FirstFile", new DefaultLocationDataEntry(0x39490, 0) },
					{ "FileTable", new DefaultLocationDataEntry(0x7C1C00, 21996) },
					{ "BodyTypeDefs", new DefaultLocationDataEntry(0x2F150, 176) },
					//{ "CostumeDefs", new DefaultLocationDataEntry(0x336DC, ?) },
				})
			},
			{
				SpecificGame.VPW64_NTSC_J,
				new DefaultLocationData(new Dictionary<string, DefaultLocationDataEntry>(){
					{ "StableDefs", new DefaultLocationDataEntry(0x4989C, 176) },
					{ "FirstFile", new DefaultLocationDataEntry(0x4AD00, 0) },
					{ "FileTable", new DefaultLocationDataEntry(0xC7B578, 37432) },
					{ "BodyTypeDefs", new DefaultLocationDataEntry(0x2FCE4, 176) },
				})
			},
			{
				SpecificGame.Revenge_NTSC_U,
				new DefaultLocationData(new Dictionary<string, DefaultLocationDataEntry>(){
					{ "StableDefs", new DefaultLocationDataEntry(0x3B0F8, 104) },
					{ "FirstFile", new DefaultLocationDataEntry(0xDAC50, 0) },
					{ "FileTable", new DefaultLocationDataEntry(0xCE2752, 30632) },
					{ "BodyTypeDefs", new DefaultLocationDataEntry(0x323F0, 208) },
					{ "CostumeDefs", new DefaultLocationDataEntry(0x36AA4, 592) },
				})
			},
			{
				SpecificGame.Revenge_PAL,
				new DefaultLocationData(new Dictionary<string, DefaultLocationDataEntry>(){
					{ "StableDefs", new DefaultLocationDataEntry(0x38548, 104) },
					{ "FirstFile", new DefaultLocationDataEntry(0xD81E0, 0) },
					{ "FileTable", new DefaultLocationDataEntry(0xCDFCE2, 30632) },
					{ "BodyTypeDefs", new DefaultLocationDataEntry(0x2FB40, 208) },
					{ "CostumeDefs", new DefaultLocationDataEntry(0x341F4, 592) },
				})
			},
			{
				SpecificGame.WM2K_NTSC_U,
				new DefaultLocationData(new Dictionary<string, DefaultLocationDataEntry>(){
					{ "StableDefs", new DefaultLocationDataEntry(0x41EE0, 132) },
					{ "FirstFile", new DefaultLocationDataEntry(0x144AA0, 0) },
					{ "FileTable", new DefaultLocationDataEntry(0x11778BE, 41248) },
				})
			},
			{
				SpecificGame.WM2K_NTSC_J,
				new DefaultLocationData(new Dictionary<string, DefaultLocationDataEntry>(){
					{ "StableDefs", new DefaultLocationDataEntry(0x3F980, 132) },
					{ "FirstFile", new DefaultLocationDataEntry(0x12C070, 0) },
					{ "FileTable", new DefaultLocationDataEntry(0x116F3C2, 41480) },
				})
			},
			{
				SpecificGame.WM2K_PAL,
				new DefaultLocationData(new Dictionary<string, DefaultLocationDataEntry>(){
					// todo: StableDefs
					{ "FirstFile", new DefaultLocationDataEntry(0x144AC0, 0) },
					{ "FileTable", new DefaultLocationDataEntry(0x11778BE, 41248) },
				})
			},
			{
				SpecificGame.VPW2_NTSC_J,
				new DefaultLocationData(new Dictionary<string, DefaultLocationDataEntry>(){
					{ "FirstFile", new DefaultLocationDataEntry(0x152DF0, 0) },
					{ "FileTable", new DefaultLocationDataEntry(0x1310F40, 52364) },
				})
			},
			{
				SpecificGame.NoMercy_NTSC_U_10,
				new DefaultLocationData(new Dictionary<string, DefaultLocationDataEntry>(){
					{ "WrestlerDefs", new DefaultLocationDataEntry(0x46658, 0) },
					{ "FirstFile", new DefaultLocationDataEntry(0x1BD1B0, 0) },
					{ "FileTable", new DefaultLocationDataEntry(0x16C3238, 77848) },
				})
			},
			{
				SpecificGame.NoMercy_NTSC_U_11,
				new DefaultLocationData(new Dictionary<string, DefaultLocationDataEntry>(){
					{ "WrestlerDefs", new DefaultLocationDataEntry(0x465B8, 0) },
					{ "FirstFile", new DefaultLocationDataEntry(0x1BD150, 0) },
					{ "FileTable", new DefaultLocationDataEntry(0x16C31D8, 77848) },
				})
			},
			{
				SpecificGame.NoMercy_PAL_10,
				new DefaultLocationData(new Dictionary<string, DefaultLocationDataEntry>(){
					{ "WrestlerDefs", new DefaultLocationDataEntry(0x46658, 0) },
					{ "FirstFile", new DefaultLocationDataEntry(0x1BD220, 0) },
					{ "FileTable", new DefaultLocationDataEntry(0x16C32A8, 77848) },
				})
			},
			{
				SpecificGame.NoMercy_PAL_11,
				new DefaultLocationData(new Dictionary<string, DefaultLocationDataEntry>(){
					{ "WrestlerDefs", new DefaultLocationDataEntry(0x464B8, 0) },
					{ "FirstFile", new DefaultLocationDataEntry(0x1BD0C0, 0) },
					{ "FileTable", new DefaultLocationDataEntry(0x16C3148, 77848) },
				})
			},
		};
		#endregion

		// rethink how you want to handle the rest of this.
	}
}
