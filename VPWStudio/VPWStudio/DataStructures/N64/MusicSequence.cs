using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace VPWStudio
{
	public enum MusicSequenceType
	{
		// todo: figure out World Tour and VPW64; songs are not in the filetable
		OldSng, // WCW/nWo Revenge
		Binary  // WM2K and later; files start with 0x00,0x00,0x02,0x15
	};

	public class MusicSequence
	{
		public MusicSequenceType SeqType;

		public MusicSequence()
		{
		}
	}
}
