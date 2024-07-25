using System;

namespace VPWStudio
{
	/// <summary>
	/// Network (client/server) commands
	/// </summary>
	public static class NetCommands
	{
		/// <summary>
		/// Available commands for the client and server.
		/// </summary>
		public enum Commands
		{
			/// <summary>
			/// no operation
			/// </summary>
			Nop = 0,

			// undefined range 0x01-0xBF

			// reserved range 0xC0-0xCD
			Reserved_C0 = 0xC0,
			Reserved_C1 = 0xC1,
			Reserved_C2 = 0xC2,
			Reserved_C3 = 0xC3,
			Reserved_C4 = 0xC4,
			Reserved_C5 = 0xC5,
			Reserved_C6 = 0xC6,
			Reserved_C7 = 0xC7,
			Reserved_C8 = 0xC8,
			Reserved_C9 = 0xC9,
			Reserved_CA = 0xCA,
			Reserved_CB = 0xCB,
			Reserved_CC = 0xCC,
			Reserved_CD = 0xCD,

			/// <summary>
			/// [0xCE] Information, Client to Emulator
			/// </summary>
			Info_Client2Emu = 0xCE,

			// reserved range 0xCF-0xD9
			Reserved_CF = 0xCF,
			Reserved_D0 = 0xD0,
			Reserved_D1 = 0xD1,
			Reserved_D2 = 0xD2,
			Reserved_D3 = 0xD3,
			Reserved_D4 = 0xD4,
			Reserved_D5 = 0xD5,
			Reserved_D6 = 0xD6,
			Reserved_D7 = 0xD7,
			Reserved_D8 = 0xD8,
			Reserved_D9 = 0xD9,

			/// <summary>
			/// [0xDA] Dump Data, arbitrary range
			/// </summary>
			DumpData_Arbitrary = 0xDA,

			/// <summary>
			/// [0xDB] Dump Data, preset range
			/// </summary>
			DumpData_Preset = 0xDB,

			/// <summary>
			/// [0xDC] Write Data once
			/// </summary>
			Data_Write = 0xDC,

			/// <summary>
			/// [0xDD] Read Data
			/// </summary>
			Data_Read = 0xDD,

			Reserved_DE = 0xDE,

			/// <summary>
			/// [0xDF] Force data (essentially, a standard Gameshark code)
			/// </summary>
			Data_Force = 0xDF,

			// reserved range 0xE0-0xEB
			Reserved_E0 = 0xE0,
			Reserved_E1 = 0xE1,
			Reserved_E2 = 0xE2,
			Reserved_E3 = 0xE3,
			Reserved_E4 = 0xE4,
			Reserved_E5 = 0xE5,
			Reserved_E6 = 0xE6,
			Reserved_E7 = 0xE7,
			Reserved_E8 = 0xE8,
			Reserved_E9 = 0xE9,
			Reserved_EA = 0xEA,
			Reserved_EB = 0xEB,

			/// <summary>
			/// [0xEC] Information, Emulator to Client
			/// </summary>
			Info_Emu2Client = 0xEC,

			// reserved range 0xED-0xFF, not bothering to define them yet
		};

		/// <summary>
		/// When the top bit of the sub-command is set, it's a response to a command.
		/// </summary>
		public static readonly byte ResponseMask = 0x80;

		// todo: various sub-commands
		// 0xCE
		public enum InfoCommand_CE
		{
			ServerID = 0
		};

		// 0xEC
		public enum InfoCommand_EC
		{
			ClientID = 1,

			/// <summary>
			/// Game identification (product code and version byte)
			/// </summary>
			GameID = 2,

			/// <summary>
			/// Internal ROM Name
			/// </summary>
			IntRomName = 3,
		};

		// 0xDB dump data preset
	}
}
