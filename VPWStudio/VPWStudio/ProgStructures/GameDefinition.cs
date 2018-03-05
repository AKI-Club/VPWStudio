using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace VPWStudio
{
	// currently not used
	public enum GameRegions
	{
		NTSC_U = 0, // 'E'
		NTSC_J,     // 'J'
		PAL         // 'P'
	}

	/// <summary>
	/// Base VPW Game List
	/// </summary>
	public enum VPWGames
	{
		/// <summary>
		/// invalid entry
		/// </summary>
		Invalid = -1,
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
		NoMercy
	}

	/// <summary>
	/// Specific Game Versions
	/// </summary>
	public enum SpecificGame
	{
		/// <summary>
		/// invalid entry
		/// </summary>
		Invalid = -1,
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
	}

	/// <summary>
	/// VPW Game Definition class
	/// </summary>
	public class GameDefinition
	{
		/// <summary>
		/// Base game type.
		/// </summary>
		public VPWGames BaseGame;

		/// <summary>
		/// Specific game instance.
		/// </summary>
		public SpecificGame GameType;

		/// <summary>
		/// Game version; 1.0 in most instances.
		/// </summary>
		public float GameVersion;

		/// <summary>
		/// Game code,
		/// </summary>
		public string GameCode;

		public GameDefinition(VPWGames _baseGame, SpecificGame _specific, string _codeName)
		{
			this.BaseGame = _baseGame;
			this.GameType = _specific;
			this.GameVersion = 1.0f;
			this.GameCode = _codeName;
		}

		public GameDefinition(VPWGames _baseGame, SpecificGame _specific, float _ver, string _codeName){
			this.BaseGame = _baseGame;
			this.GameType = _specific;
			this.GameVersion = _ver;
			this.GameCode = _codeName;
		}
	}

	public static class GameInformation
	{
		/// <summary>
		/// Dictionary mapping SpecificGame to GameDefinition.
		/// </summary>
		public static Dictionary<SpecificGame, GameDefinition> GameDefs = new Dictionary<SpecificGame, GameDefinition>()
		{
			{
				SpecificGame.WorldTour_NTSC_U_10,
				new GameDefinition(VPWGames.WorldTour, SpecificGame.WorldTour_NTSC_U_10, 1.0f, "NWNE")
			},
			{
				SpecificGame.WorldTour_NTSC_U_11,
				new GameDefinition(VPWGames.WorldTour, SpecificGame.WorldTour_NTSC_U_11, 1.1f, "NWNE-1")
			},
			{
				SpecificGame.WorldTour_PAL,
				new GameDefinition(VPWGames.WorldTour, SpecificGame.WorldTour_PAL, 1.0f, "NWNP")
			},
			{
				SpecificGame.VPW64_NTSC_J,
				new GameDefinition(VPWGames.VPW64, SpecificGame.VPW64_NTSC_J, 1.0f, "NVPJ")
			},
			{
				SpecificGame.Revenge_NTSC_U,
				new GameDefinition(VPWGames.Revenge, SpecificGame.Revenge_NTSC_U, 1.0f, "NW2E")
			},
			{
				SpecificGame.Revenge_PAL,
				new GameDefinition(VPWGames.Revenge, SpecificGame.Revenge_PAL, 1.0f, "NW2P")
			},
			{
				SpecificGame.WM2K_NTSC_U,
				new GameDefinition(VPWGames.WM2K, SpecificGame.WM2K_NTSC_U, 1.0f, "NWXE")
			},
			{
				SpecificGame.WM2K_NTSC_J,
				new GameDefinition(VPWGames.WM2K, SpecificGame.WM2K_NTSC_J, 1.0f, "NWXJ")
			},
			{
				SpecificGame.WM2K_PAL,
				new GameDefinition(VPWGames.WM2K, SpecificGame.WM2K_PAL, 1.0f, "NWXP")
			},
			{
				SpecificGame.VPW2_NTSC_J,
				new GameDefinition(VPWGames.VPW2, SpecificGame.VPW2_NTSC_J, 1.0f, "NA2J")
			},
			{
				SpecificGame.NoMercy_NTSC_U_10,
				new GameDefinition(VPWGames.NoMercy, SpecificGame.NoMercy_NTSC_U_10, 1.0f, "NW4E")
			},
			{
				SpecificGame.NoMercy_NTSC_U_11,
				new GameDefinition(VPWGames.NoMercy, SpecificGame.NoMercy_NTSC_U_11, 1.1f, "NW4E-1")
			},
			{
				SpecificGame.NoMercy_PAL_10,
				new GameDefinition(VPWGames.NoMercy, SpecificGame.NoMercy_PAL_10, 1.0f, "NW4P")
			},
			{
				SpecificGame.NoMercy_PAL_11,
				new GameDefinition(VPWGames.NoMercy, SpecificGame.NoMercy_PAL_11, 1.1f, "NW4P-1")
			}
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
				case VPWGames.WorldTour: return "WCW vs. nWo World Tour";
				case VPWGames.VPW64: return "Virtual Pro-Wrestling 64";
				case VPWGames.Revenge: return "WCW/nWo Revenge";
				case VPWGames.WM2K: return "WWF WrestleMania 2000";
				case VPWGames.VPW2: return "Virtual Pro-Wrestling 2";
				case VPWGames.NoMercy: return "WWF No Mercy";
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
			}
			return "(unknown game)";
		}

		/// <summary>
		/// if you are a lazy asshole... idk.
		/// </summary>
		/// <param name="sg">SpecificGame to get the base game value for.</param>
		/// <returns>VPWGames value representing the base game.</returns>
		public static VPWGames GetBaseGameFromSpecificGame(SpecificGame sg)
		{
			switch (sg) {
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
			}
			return VPWGames.Invalid;
		}
	}
}
