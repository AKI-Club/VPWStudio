using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace VPWStudio
{
	/// <summary>
	/// Target console type.
	/// </summary>
	public enum PlatformType
	{
		Invalid = -1,
		Nintendo64 = 0,
		PlayStation1 = 1
	}

	/// <summary>
	/// Base VPW series game list.
	/// </summary>
	public enum VPWGames
	{
		/// <summary>
		/// invalid entry
		/// </summary>
		Invalid = -1,
		#region Nintendo 64
		/// <summary>
		/// WCW vs. nWo World Tour
		/// </summary>
		WorldTour = 0,
		/// <summary>
		/// Virtual Pro-Wrestling 64
		/// </summary>
		VPW64,
		/// <summary>
		/// WCW/nWo Revenge
		/// </summary>
		Revenge,
		/// <summary>
		/// WWF WrestleMania 2000
		/// </summary>
		WM2K,
		/// <summary>
		/// Virtual Pro-Wrestling 2
		/// </summary>
		VPW2,
		/// <summary>
		/// WWF No Mercy
		/// </summary>
		NoMercy,
		#endregion

		#region PlayStation
		/// <summary>
		/// Virtual Pro-Wrestling
		/// </summary>
		VPW,
		/// <summary>
		/// WCW vs. the World
		/// </summary>
		WCWvsWorld,
		#endregion
	}

	/// <summary>
	/// Specific Game Versions.
	/// </summary>
	public enum SpecificGame
	{
		/// <summary>
		/// invalid entry
		/// </summary>
		Invalid = -1,

		#region Nintendo 64
		/// <summary>
		/// WCW vs. nWo World Tour (NTSC-U v1.0) [NWNE]
		/// </summary>
		WorldTour_NTSC_U_10 = 0,
		/// <summary>
		/// WCW vs. nWo World Tour (NTSC-U v1.1) [NWNE-1]
		/// </summary>
		WorldTour_NTSC_U_11,
		/// <summary>
		/// WCW vs. nWo World Tour (PAL) [NWNP]
		/// </summary>
		WorldTour_PAL,
		/// <summary>
		/// Virtual Pro-Wrestling 64 (NTSC-J) [NVPJ]
		/// </summary>
		VPW64_NTSC_J,
		/// <summary>
		/// WCW/nWo Revenge (NTSC-U) [NW2E]
		/// </summary>
		Revenge_NTSC_U,
		/// <summary>
		/// WCW/nWo Revenge (PAL) [NW2P]
		/// </summary>
		Revenge_PAL,
		/// <summary>
		/// WWF WrestleMania 2000 (NTSC-U) [NWXE]
		/// </summary>
		WM2K_NTSC_U,
		/// <summary>
		/// WWF WrestleMania 2000 (NTSC-J) [NWXJ]
		/// </summary>
		WM2K_NTSC_J,
		/// <summary>
		/// WWF WrestleMania 2000 (PAL) [NWXP]
		/// </summary>
		WM2K_PAL,
		/// <summary>
		/// Virtual Pro-Wrestling 2 (NTSC-J) [NA2J]
		/// </summary>
		VPW2_NTSC_J,
		/// <summary>
		/// WWF No Mercy (NTSC-U v1.0) [NW4E]
		/// </summary>
		NoMercy_NTSC_U_10,
		/// <summary>
		/// WWF No Mercy (NTSC-U v1.1) [NW4E-1]
		/// </summary>
		NoMercy_NTSC_U_11,
		/// <summary>
		/// WWF No Mercy (PAL v1.0) [NW4P]
		/// </summary>
		NoMercy_PAL_10,
		/// <summary>
		/// WWF No Mercy (PAL v1.1) [NW4P-1]
		/// </summary>
		NoMercy_PAL_11,
		#endregion

		#region PlayStation
		/// <summary>
		/// Virtual Pro-Wrestling (NTSC-J); SLPS-00449
		/// </summary>
		VPW_NTSC_J,
		/// <summary>
		/// WCW vs. the World (NTSC-U); SLUS-00455
		/// </summary>
		WCWvsWorld_NTSC_U,
		/// <summary>
		/// WCW vs. the World (PAL); SLES-00763
		/// </summary>
		WCWvsWorld_PAL,
		#endregion
	}

	/// <summary>
	/// VPW Game Definition class
	/// </summary>
	public class GameDefinition
	{
		#region Members
		/// <summary>
		/// Base game type.
		/// </summary>
		public VPWGames BaseGame;

		/// <summary>
		/// Specific game instance.
		/// </summary>
		public SpecificGame GameType;

		/// <summary>
		/// Target console for this game.
		/// </summary>
		public PlatformType TargetConsole;

		/// <summary>
		/// Game version; 1.0 in most instances.
		/// </summary>
		/// todo: perhaps this should be a byte so it can be written in the mask rom version field.
		public float GameVersion;

		/// <summary>
		/// Game/program code name.
		/// N64 game format: "Nxxy" (xx = program code, y = region)
		/// PS1 game format: typically "SxyS-00000" (x = release type ('L' for third-party games), y = region, 00000 = release number or something like that)
		/// </summary>
		public string GameCode;

		/// <summary>
		/// Region of game release.
		/// </summary>
		public GameRegion Region;
		#endregion

		public GameDefinition(VPWGames _baseGame, SpecificGame _specific, PlatformType _console, string _codeName, GameRegion _region)
		{
			BaseGame = _baseGame;
			GameType = _specific;
			TargetConsole = _console;
			GameVersion = 1.0f;
			GameCode = _codeName;
			Region = _region;
		}

		public GameDefinition(VPWGames _baseGame, SpecificGame _specific, PlatformType _console, float _ver, string _codeName, GameRegion _region){
			BaseGame = _baseGame;
			GameType = _specific;
			TargetConsole = _console;
			GameVersion = _ver;
			GameCode = _codeName;
			Region = _region;
		}
	}

	public static class GameInformation
	{
		/// <summary>
		/// Dictionary mapping SpecificGame to GameDefinition.
		/// </summary>
		public static Dictionary<SpecificGame, GameDefinition> GameDefs = new Dictionary<SpecificGame, GameDefinition>()
		{
			#region Nintendo 64
			{
				SpecificGame.WorldTour_NTSC_U_10,
				new GameDefinition(VPWGames.WorldTour, SpecificGame.WorldTour_NTSC_U_10, PlatformType.Nintendo64, 1.0f, "NWNE", GameRegion.NorthAmerica)
			},
			{
				SpecificGame.WorldTour_NTSC_U_11,
				new GameDefinition(VPWGames.WorldTour, SpecificGame.WorldTour_NTSC_U_11, PlatformType.Nintendo64, 1.1f, "NWNE-1", GameRegion.NorthAmerica)
			},
			{
				SpecificGame.WorldTour_PAL,
				new GameDefinition(VPWGames.WorldTour, SpecificGame.WorldTour_PAL, PlatformType.Nintendo64, 1.0f, "NWNP", GameRegion.Europe)
			},
			{
				SpecificGame.VPW64_NTSC_J,
				new GameDefinition(VPWGames.VPW64, SpecificGame.VPW64_NTSC_J, PlatformType.Nintendo64, 1.0f, "NVPJ", GameRegion.Japan)
			},
			{
				SpecificGame.Revenge_NTSC_U,
				new GameDefinition(VPWGames.Revenge, SpecificGame.Revenge_NTSC_U, PlatformType.Nintendo64, 1.0f, "NW2E", GameRegion.NorthAmerica)
			},
			{
				SpecificGame.Revenge_PAL,
				new GameDefinition(VPWGames.Revenge, SpecificGame.Revenge_PAL, PlatformType.Nintendo64, 1.0f, "NW2P", GameRegion.Europe)
			},
			{
				SpecificGame.WM2K_NTSC_U,
				new GameDefinition(VPWGames.WM2K, SpecificGame.WM2K_NTSC_U, PlatformType.Nintendo64, 1.0f, "NWXE", GameRegion.NorthAmerica)
			},
			{
				SpecificGame.WM2K_NTSC_J,
				new GameDefinition(VPWGames.WM2K, SpecificGame.WM2K_NTSC_J, PlatformType.Nintendo64, 1.0f, "NWXJ", GameRegion.Japan)
			},
			{
				SpecificGame.WM2K_PAL,
				new GameDefinition(VPWGames.WM2K, SpecificGame.WM2K_PAL, PlatformType.Nintendo64, 1.0f, "NWXP", GameRegion.Europe)
			},
			{
				SpecificGame.VPW2_NTSC_J,
				new GameDefinition(VPWGames.VPW2, SpecificGame.VPW2_NTSC_J, PlatformType.Nintendo64, 1.0f, "NA2J", GameRegion.Japan)
			},
			{
				SpecificGame.NoMercy_NTSC_U_10,
				new GameDefinition(VPWGames.NoMercy, SpecificGame.NoMercy_NTSC_U_10, PlatformType.Nintendo64, 1.0f, "NW4E", GameRegion.NorthAmerica)
			},
			{
				SpecificGame.NoMercy_NTSC_U_11,
				new GameDefinition(VPWGames.NoMercy, SpecificGame.NoMercy_NTSC_U_11, PlatformType.Nintendo64, 1.1f, "NW4E-1", GameRegion.NorthAmerica)
			},
			{
				SpecificGame.NoMercy_PAL_10,
				new GameDefinition(VPWGames.NoMercy, SpecificGame.NoMercy_PAL_10, PlatformType.Nintendo64, 1.0f, "NW4P", GameRegion.Europe)
			},
			{
				SpecificGame.NoMercy_PAL_11,
				new GameDefinition(VPWGames.NoMercy, SpecificGame.NoMercy_PAL_11, PlatformType.Nintendo64, 1.1f, "NW4P-1", GameRegion.Europe)
			},
			#endregion

			#region PlayStation
			{
				SpecificGame.VPW_NTSC_J,
				new GameDefinition(VPWGames.VPW, SpecificGame.VPW_NTSC_J, PlatformType.PlayStation1, 1.0f, "SLPS-00449", GameRegion.Japan)
			},
			{
				SpecificGame.WCWvsWorld_NTSC_U,
				new GameDefinition(VPWGames.WCWvsWorld, SpecificGame.WCWvsWorld_NTSC_U, PlatformType.PlayStation1, 1.0f, "SLUS-00455", GameRegion.NorthAmerica)
			},
			{
				SpecificGame.WCWvsWorld_PAL,
				new GameDefinition(VPWGames.WCWvsWorld, SpecificGame.WCWvsWorld_PAL, PlatformType.PlayStation1, 1.0f, "SLES-00763", GameRegion.Europe)
			}
			#endregion
		};

		/// <summary>
		/// Get a string representing the base game name.
		/// </summary>
		/// <param name="bg">VPWGames value to get the name of.</param>
		/// <returns>String with the base game name.</returns>
		public static string GetBaseGameName(VPWGames bg)
		{
			switch (bg)
			{
				#region Nintendo 64
				case VPWGames.WorldTour: return "WCW vs. nWo World Tour";
				case VPWGames.VPW64: return "Virtual Pro-Wrestling 64";
				case VPWGames.Revenge: return "WCW/nWo Revenge";
				case VPWGames.WM2K: return "WWF WrestleMania 2000";
				case VPWGames.VPW2: return "Virtual Pro-Wrestling 2";
				case VPWGames.NoMercy: return "WWF No Mercy";
				#endregion

				#region PlayStation
				case VPWGames.VPW: return "Virtual Pro-Wrestling";
				case VPWGames.WCWvsWorld: return "WCW vs. the World";
				#endregion
			}
			return "(unknown game)";
		}

		/// <summary>
		/// Get a string representing the specific game name.
		/// </summary>
		/// <param name="sg">SpecificGame value to get the name of.</param>
		/// <returns>String with the specific game name.</returns>
		public static string GetSpecificGameName(SpecificGame sg)
		{
			switch (sg)
			{
				#region Nintendo 64
				case SpecificGame.WorldTour_NTSC_U_10: return GetBaseGameName(VPWGames.WorldTour) + String.Format(" NTSC-U ({0})", GameDefs[sg].GameCode);
				case SpecificGame.WorldTour_NTSC_U_11: return GetBaseGameName(VPWGames.WorldTour) + String.Format(" NTSC-U ({0})", GameDefs[sg].GameCode);
				case SpecificGame.WorldTour_PAL:       return GetBaseGameName(VPWGames.WorldTour) + String.Format(" PAL ({0})", GameDefs[sg].GameCode);
				case SpecificGame.VPW64_NTSC_J:        return GetBaseGameName(VPWGames.VPW64) + String.Format(" ({0})", GameDefs[sg].GameCode);
				case SpecificGame.Revenge_NTSC_U:      return GetBaseGameName(VPWGames.Revenge) + String.Format(" NTSC-U ({0})", GameDefs[sg].GameCode);
				case SpecificGame.Revenge_PAL:         return GetBaseGameName(VPWGames.Revenge) + String.Format(" PAL ({0})", GameDefs[sg].GameCode);
				case SpecificGame.WM2K_NTSC_U:         return GetBaseGameName(VPWGames.WM2K) + String.Format(" NTSC-U ({0})", GameDefs[sg].GameCode);
				case SpecificGame.WM2K_NTSC_J:         return GetBaseGameName(VPWGames.WM2K) + String.Format(" NTSC-J ({0})", GameDefs[sg].GameCode);
				case SpecificGame.WM2K_PAL:            return GetBaseGameName(VPWGames.WM2K) + String.Format(" PAL ({0})", GameDefs[sg].GameCode);
				case SpecificGame.VPW2_NTSC_J:         return GetBaseGameName(VPWGames.VPW2) + String.Format(" NTSC-J ({0})", GameDefs[sg].GameCode);
				case SpecificGame.NoMercy_NTSC_U_10:   return GetBaseGameName(VPWGames.NoMercy) + String.Format(" NTSC-U v1.0 ({0})", GameDefs[sg].GameCode);
				case SpecificGame.NoMercy_NTSC_U_11:   return GetBaseGameName(VPWGames.NoMercy) + String.Format(" NTSC-U v1.1 ({0})", GameDefs[sg].GameCode);
				case SpecificGame.NoMercy_PAL_10:      return GetBaseGameName(VPWGames.NoMercy) + String.Format(" PAL v1.0 ({0})", GameDefs[sg].GameCode);
				case SpecificGame.NoMercy_PAL_11:      return GetBaseGameName(VPWGames.NoMercy) + String.Format(" PAL v1.1 ({0})", GameDefs[sg].GameCode);
				#endregion

				#region PlayStation
				case SpecificGame.VPW_NTSC_J:          return GetBaseGameName(VPWGames.VPW) + String.Format(" NTSC-J ({0})", GameDefs[sg].GameCode);
				case SpecificGame.WCWvsWorld_NTSC_U:   return GetBaseGameName(VPWGames.WCWvsWorld) + String.Format(" NTSC-U ({0})", GameDefs[sg].GameCode);
				case SpecificGame.WCWvsWorld_PAL:      return GetBaseGameName(VPWGames.WCWvsWorld) + String.Format(" PAL ({0})", GameDefs[sg].GameCode);
				#endregion
			}
			return "(unknown game)";
		}

		/// <summary>
		/// Get the base game from a specific game variant.
		/// </summary>
		/// <param name="sg">SpecificGame to get the base game value for.</param>
		/// <returns>VPWGames value representing the base game.</returns>
		public static VPWGames GetBaseGameFromSpecificGame(SpecificGame sg)
		{
			switch (sg) {
				#region Nintendo 64
				case SpecificGame.WorldTour_NTSC_U_10:
				case SpecificGame.WorldTour_NTSC_U_11:
				case SpecificGame.WorldTour_PAL:
					return VPWGames.WorldTour;

				case SpecificGame.VPW64_NTSC_J:
					return VPWGames.VPW64;

				case SpecificGame.Revenge_NTSC_U:
				case SpecificGame.Revenge_PAL:
					return VPWGames.Revenge;

				case SpecificGame.WM2K_NTSC_U:
				case SpecificGame.WM2K_NTSC_J:
				case SpecificGame.WM2K_PAL:
					return VPWGames.WM2K;

				case SpecificGame.VPW2_NTSC_J:
					return VPWGames.VPW2;

				case SpecificGame.NoMercy_NTSC_U_10:
				case SpecificGame.NoMercy_NTSC_U_11:
				case SpecificGame.NoMercy_PAL_10:
				case SpecificGame.NoMercy_PAL_11:
					return VPWGames.NoMercy;
				#endregion

				#region PlayStation
				case SpecificGame.VPW_NTSC_J:
					return VPWGames.VPW;

				case SpecificGame.WCWvsWorld_NTSC_U:
				case SpecificGame.WCWvsWorld_PAL:
					return VPWGames.WCWvsWorld;
				#endregion
			}
			return VPWGames.Invalid;
		}
	}
}
