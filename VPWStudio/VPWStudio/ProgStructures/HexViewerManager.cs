using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;

namespace VPWStudio
{
	/// <summary>
	/// Manager class for the HexViewer.
	/// </summary>
	public class HexViewerManager
	{
		// the goal of this class is to handle multiple hexviewers while not summoning more views than needed.
		// the implied key for each entry is a hash of the data.
		public Dictionary<string, HexViewer> ActiveHexViewers;

		public HexViewerManager()
		{
			ActiveHexViewers = new Dictionary<string, HexViewer>();
		}
	}
}
