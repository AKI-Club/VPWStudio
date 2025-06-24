using System;
using System.Collections.Generic;

namespace VPWStudio
{
    // todo: restructure this to handle N64 and PS1 games; currently only handles N64

    #region Nintendo 64 regions
    /// <summary>
    /// Possible Nintendo 64 game regions, and their codes.
    /// </summary>
    public enum GameRegion
	{
		Japan = 'J',
		NorthAmerica = 'E',
		Europe = 'P',
		France = 'F',
		Canada = 'N',
		Germany = 'D',
		Dutch = 'H',
		Italy = 'I',
		Spain = 'S',
		Scandanavia = 'W',
		China = 'C',
		Korea = 'K',
		Brazil = 'B',
		Australia = 'U',
		Gateway_NTSC = 'G',
		Gateway_PAL = 'L',
		OtherX = 'X',
		OtherY = 'Y',
		OtherZ = 'Z',
		Unset = ' ',
		Custom = -1
	}

	public static class GameRegionInfo
	{
		#region Nintendo 64 Region Codes
		/// <summary>
		/// Convert a GameRegion value to a Nintendo 64 region code.
		/// </summary>
		/// <param name="_region">GameRegion to get the region code for.</param>
		/// <returns>A character representing the passed in GameRegion. Note: GameRegion.Custom needs to be checked manually.</returns>
		public static char GameRegionToN64(GameRegion _region)
		{
			switch (_region)
			{
				case GameRegion.Japan: return 'J';
				case GameRegion.NorthAmerica: return 'E';
				case GameRegion.Europe: return 'P';
				case GameRegion.France: return 'F';
				case GameRegion.Canada: return 'N';
				case GameRegion.Germany: return 'D';
				case GameRegion.Dutch: return 'H';
				case GameRegion.Italy: return 'I';
				case GameRegion.Spain: return 'S';
				case GameRegion.Scandanavia: return 'W';
				case GameRegion.China: return 'C';
				case GameRegion.Korea: return 'K';
				case GameRegion.Brazil: return 'B';
				case GameRegion.Australia: return 'U';
				case GameRegion.Gateway_NTSC: return 'G';
				case GameRegion.Gateway_PAL: return 'L';
				case GameRegion.OtherX: return 'X';
				case GameRegion.OtherY: return 'Y';
				case GameRegion.OtherZ: return 'Z';
				default: return '?';
			}
		}

		/// <summary>
		/// Convert a Nintendo 64 region code to a GameRegion value.
		/// </summary>
		/// <param name="_region">A character representing the Nintendo 64 region code.</param>
		/// <returns>The corresponding GameRegion value, if found, or GameRegion.Custom if not found.</returns>
		public static GameRegion GameRegionFromN64(char _region)
		{
			switch (_region)
			{
				case 'J': return GameRegion.Japan;
				case 'E': return GameRegion.NorthAmerica;
				case 'P': return GameRegion.Europe;
				case 'F': return GameRegion.France;
				case 'N': return GameRegion.Canada;
				case 'D': return GameRegion.Germany;
				case 'H': return GameRegion.Dutch;
				case 'I': return GameRegion.Italy;
				case 'S': return GameRegion.Spain;
				case 'W': return GameRegion.Scandanavia;
				case 'C': return GameRegion.China;
				case 'K': return GameRegion.Korea;
				case 'B': return GameRegion.Brazil;
				case 'U': return GameRegion.Australia;
				case 'G': return GameRegion.Gateway_NTSC;
				case 'L': return GameRegion.Gateway_PAL;
				case 'X': return GameRegion.OtherX;
				case 'Y': return GameRegion.OtherY;
				case 'Z': return GameRegion.OtherZ;
				default: return GameRegion.Custom;
			}
		}
		#endregion

		/// <summary>
		/// Map GameRegion values to human-readable strings.
		/// </summary>
		/// Note: This is N64-centric
		public static Dictionary<GameRegion, string> GameRegionNames = new Dictionary<GameRegion, string>()
		{
			{ GameRegion.Japan, "Japan" },
			{ GameRegion.NorthAmerica, "North America" },
			{ GameRegion.Europe, "Europe (generic PAL)" },
			{ GameRegion.France, "France" },
			{ GameRegion.Canada, "Canada" },
			{ GameRegion.Germany, "Germany" },
			{ GameRegion.Dutch, "Dutch" },
			{ GameRegion.Italy, "Italy" },
			{ GameRegion.Spain, "Spain" },
			{ GameRegion.Scandanavia, "Scandanavia" },
			{ GameRegion.China, "China" },
			{ GameRegion.Korea, "Korea" },
			{ GameRegion.Brazil, "Brazil" },
			{ GameRegion.Australia, "Australia" },
			{ GameRegion.Gateway_NTSC, "Gateway 64 (NTSC)" },
			{ GameRegion.Gateway_PAL, "Gateway 64 (PAL)" },
			{ GameRegion.OtherX, "Other X" },
			{ GameRegion.OtherY, "Other Y" },
			{ GameRegion.OtherZ, "Other Z" },
			{ GameRegion.Custom, "(custom)" }
		};
	}
    #endregion

    #region PlayStation regions
    // Sony's product code scheme is a bit trickier:
    // SCxx is used for first-party games
    // SLxx is used for licensed games

    // SCPS, SLPS - Japan
    // SCUS, SLUS - North America
    // SCES, SLES - Europe
    // SCKA, SLKA - Korean

    // supposedly {SCPM, SLPM} exists for Japanese games/demos

    // SLPS-00449: Virtual Pro Wrestling
    // SLUS-00455: WCW vs. The World
    // SLES-00763: WCW vs. The World
    #endregion
}
