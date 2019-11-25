using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;

namespace VPWStudio
{
	public class GameIntroDefFile
	{
		#region Members
		/// <summary>
		/// Game Type (defines what game intro defs are read/written)
		/// </summary>
		public VPWGames GameType;

		// todo: the game-specific shit
		#endregion

		public GameIntroDefFile()
		{
			GameType = VPWGames.Invalid;
		}

		public GameIntroDefFile(VPWGames _game)
		{
			GameType = _game;
		}

		// todo: read data, write data
	}
}
