using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace VPWStudio.GameSpecific.VPW64
{
	/// <summary>
	/// Virtual Pro-Wrestling 64 Wrestler Parameters
	/// </summary>
	public class WrestlerParams
	{
		// 40 bytes

		// 0x00-0x04 currently unknown
		public byte Offset00;
		public byte Offset01;
		public byte Offset02;
		public byte Offset03;
		public byte Offset04;

		/// <summary>
		/// Attack parameters. (Offsets 0x05-0x09 inclusive)
		/// </summary>
		public byte[] OffenseValues;

		/// <summary>
		/// Defense parameters. (Offsets 0x0A-0x0E inclusive)
		/// </summary>
		public byte[] DefenseValues;
	}
}
