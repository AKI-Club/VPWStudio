using System;
using System.IO;

namespace VPWStudio.GameSpecific.WM2K
{
	/// <summary>
	/// WrestleMania 2000 Tag Team Definition
	/// </summary>
	public class TagTeamDefinition
	{
		#region Class Members
		/// <summary>
		/// ID2 value of first wrestler in team.
		/// </summary>
		public byte Wrestler1;

		/// <summary>
		/// ID2 value of second wrestler in team.
		/// </summary>
		public byte Wrestler2;

		/// <summary>
		/// Music to use for team.
		/// </summary>
		public byte TeamMusic;

		/// <summary>
		/// Titantron video to use for team.
		/// </summary>
		public byte TeamVideo;

		/// <summary>
		/// Wrestler 1 must have this theme song for this team entry to be used.
		/// </summary>
		public byte Wrestler1Music;

		/// <summary>
		/// Wrestler 2 must have this theme song for this team entry to be used.
		/// </summary>
		public byte Wrestler2Music;

		/// <summary>
		/// Wrestler 1 must have this Titantron video for this team entry to be used.
		/// </summary>
		public byte Wrestler1Video;

		/// <summary>
		/// Wrestler 2 must have this Titantron video for this team entry to be used.
		/// </summary>
		public byte Wrestler2Video;

		/// <summary>
		/// Unknown byte; always 0x00 in existing data.
		/// </summary>
		public byte Unknown;

		/// <summary>
		/// Wrestler 1 entrance value (??)
		/// </summary>
		public byte Wrestler1Entrance;

		/// <summary>
		/// Wrestler 2 entrance value (??)
		/// </summary>
		public byte Wrestler2Entrance;

		/// <summary>
		/// Defines team name index (lower 4 bits) and flags? (upper 4 bits)
		/// </summary>
		public byte Flags_NameIndex;
		#endregion

		#region Constructors
		/// <summary>
		/// Default constructor.
		/// </summary>
		public TagTeamDefinition()
		{
			Wrestler1 = 0;
			Wrestler2 = 0;
			TeamMusic = 0;
			TeamVideo = 0;
			Wrestler1Music = 0;
			Wrestler2Music = 0;
			Wrestler1Video = 0;
			Wrestler2Video = 0;
			Unknown = 0;
			Wrestler1Entrance = 0;
			Wrestler2Entrance = 0;
			Flags_NameIndex = 0;
		}

		/// <summary>
		/// Constructor using a BinaryReader.
		/// </summary>
		/// <param name="br">BinaryReader instance to use.</param>
		public TagTeamDefinition(BinaryReader br)
		{
			ReadData(br);
		}
		#endregion

		#region Binary Read/Write
		/// <summary>
		/// Read tag team data using a BinaryReader.
		/// </summary>
		/// <param name="br">BinaryReader instance to use.</param>
		public void ReadData(BinaryReader br)
		{
			Wrestler1 = br.ReadByte();
			Wrestler2 = br.ReadByte();
			TeamMusic = br.ReadByte();
			TeamVideo = br.ReadByte();
			Wrestler1Music = br.ReadByte();
			Wrestler2Music = br.ReadByte();
			Wrestler1Video = br.ReadByte();
			Wrestler2Video = br.ReadByte();
			Unknown = br.ReadByte();
			Wrestler1Entrance = br.ReadByte();
			Wrestler2Entrance = br.ReadByte();
			Flags_NameIndex = br.ReadByte();
		}

		/// <summary>
		/// Write tag team data using a BinaryWriter.
		/// </summary>
		/// <param name="bw">BinaryWriter instance to use.</param>
		/// <returns>True if successful.</returns>
		public bool WriteData(BinaryWriter bw)
		{
			bw.Write(Wrestler1);
			bw.Write(Wrestler2);
			bw.Write(TeamMusic);
			bw.Write(TeamVideo);
			bw.Write(Wrestler1Music);
			bw.Write(Wrestler2Music);
			bw.Write(Wrestler1Video);
			bw.Write(Wrestler2Video);
			bw.Write(Unknown);
			bw.Write(Wrestler1Entrance);
			bw.Write(Wrestler2Entrance);
			bw.Write(Flags_NameIndex);
			return true;
		}
		#endregion
	}
}
