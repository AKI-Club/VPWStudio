using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace VPWStudio.GameSpecific.Revenge
{
	public class ChampionshipDefinition
	{
		// [byte] championship number?
		public byte Identifier;

		// [byte] ??? always 7

		// [byte] Initial Champion 1 ID2
		public byte ID2_Champion1;

		// [byte] Initial Champion 2 ID2 (leave as 0 if not Tag Team)
		public byte ID2_Champion2;

		// [byte] unknown
		// [byte] flags 1 (cruiserweight; others?)
		// [byte] flags 2 (number of wrestlers; others?)
		// [byte] unknown (this and the below may be a halfword)
		// [byte] unknown (this and the above may be a halfword)
		// [half] assumed halfword 1
		// [half] assumed halfword 2
		// [half] assumed halfword 3
		// [word] Pointer to some ID2 list

		public void ReadData(BinaryReader br)
		{
			// why'd you write this when you don't even have a towel
		}
	}
}
