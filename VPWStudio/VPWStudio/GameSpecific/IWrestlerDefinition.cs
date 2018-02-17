using System;
using System.IO;

namespace VPWStudio.GameSpecific
{
	interface IWrestlerDefinition
	{		
		#region I/O
		/// <summary>
		/// Read WrestlerDefinition data from a BinaryReader instance.
		/// </summary>
		/// <param name="br">BinaryReader instance to use.</param>
		void ReadData(BinaryReader br);
		#endregion
	}
}
