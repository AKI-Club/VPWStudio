using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace VPWStudio
{
	/// <summary>
	/// Build Log Message Types
	/// </summary>
	public enum BuildMessageTypes {
		/// <summary>
		/// A Warning merely notifies the user something was wrong; the ROM will continue building.
		/// </summary>
		Warning = 0,
		/// <summary>
		/// An Error prevents building the ROM.
		/// </summary>
		Error = 1
	}

	/// <summary>
	/// A Build Warning/Error Message tied to a specific File ID.
	/// </summary>
	public class BuildWarnErr
	{
		public int FileID;
		public BuildMessageTypes MessageType;
		public string MessageText;

		public BuildWarnErr()
		{
			FileID = -1;
			MessageType = BuildMessageTypes.Error;
			MessageText = "Uninitialized error message";
		}

		public BuildWarnErr(int _id, BuildMessageTypes _type, string _msg)
		{
			FileID = _id;
			MessageType = _type;
			MessageText = _msg;
		}
	}
}
