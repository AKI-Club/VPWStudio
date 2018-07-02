using System;
using System.Collections.Generic;

namespace VPWStudio
{
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
		Custom = -1
	}

	public static class GameRegionInfo
	{
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
			{ GameRegion.OtherX, "Other (X)" },
			{ GameRegion.OtherY, "Other (Y)" },
			{ GameRegion.OtherZ, "Other (Z)" },
			{ GameRegion.Custom, "(custom)" }
		};
	}
}
