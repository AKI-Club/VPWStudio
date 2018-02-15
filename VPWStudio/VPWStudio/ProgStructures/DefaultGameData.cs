using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace VPWStudio
{
	/*
	 * Each of the games have shared elements...
	 * - wrestlers
	 * - stables
	 * - arenas
	 * - moves
	 * - costumes, though this differs heavily by game
	 * probably more things I'm forgetting
	 */

	public class DefaultWrestlerEntry
	{
		/// <summary>
		/// ID2 value of wrestler.
		/// </summary>
		public byte ID2;

		/// <summary>
		/// ID4 value of wrestler.
		/// </summary>
		public UInt16 ID4;

		/// <summary>
		/// Wrestler Name
		/// </summary>
		public string Name;

		/// <summary>
		/// Default constructor.
		/// </summary>
		public DefaultWrestlerEntry()
		{
			this.ID2 = 0x00;
			this.ID4 = 0x0000;
			this.Name = "(fallback data)";
		}

		/// <summary>
		/// Specific constructor.
		/// </summary>
		/// <param name="_id2">Wrestler ID2 value</param>
		/// <param name="_id4">Wrestler ID4 value</param>
		/// <param name="_name">Wrestler Name</param>
		public DefaultWrestlerEntry(byte _id2, UInt16 _id4, string _name)
		{
			this.ID2 = _id2;
			this.ID4 = _id4;
			this.Name = _name;
		}
	}

	public class DefaultStableEntry
	{
		/// <summary>
		/// Stable Name
		/// </summary>
		public string Name;

		/// <summary>
		/// Number of wrestlers in this stable.
		/// </summary>
		public int NumWrestlers;

		/// <summary>
		/// List of wrestler ID2s.
		/// </summary>
		/// Maximum length depends on game.
		/// - WT: a lot
		/// - VPW64: two columns worth
		/// - VPW2, WM2K, Revenge?: 8
		/// - No Mercy: 9.
		public byte[] Roster;
	}

	// only one of these exists per base game type
	public class DefaultGameData
	{
		/// <summary>
		/// Base game type.
		/// </summary>
		public VPWGames BaseGame;
	}
}
