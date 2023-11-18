using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace VPWStudio.GameSpecific.NoMercy
{
	public class MoveMenuEntry
	{
		#region Class Members
		/// <summary>
		/// Damage information
		/// </summary>
		public byte DamageInfo;

		/// <summary>
		/// "Misc preview positions"
		/// </summary>
		public short PreviewPos;

		/// <summary>
		/// Link to move
		/// </summary>
		public short MoveLink;

		/// <summary>
		/// "animation ID (-3322)"; 3322 presumed to be hex
		/// </summary>
		public short AnimID;

		/// <summary>
		/// "animation ID for repeats (-3322)"; 3322 presumed to be hex
		/// </summary>
		public short RepeatAnimID;

		/// <summary>
		/// "Master Move ID"
		/// </summary>
		public short MasterMoveID;

		/// <summary>
		/// Move name for this entry. (null-terminated string)
		/// </summary>
		/// todo: some (unused or otherwise non-visible) move names use Shift-JIS encoding
		public string MoveName;
		#endregion

		#region Constructors
		/// <summary>
		/// Default constructor.
		/// </summary>
		public MoveMenuEntry()
		{
			DamageInfo = 0;
			PreviewPos = 0;
			MoveLink = 0;
			AnimID = 0;
			RepeatAnimID = 0;
			MasterMoveID = 0;
			MoveName = string.Empty;
		}

		/// <summary>
		/// Constructor using a BinaryReader.
		/// </summary>
		/// <param name="br">BinaryReader instance to use.</param>
		public MoveMenuEntry(BinaryReader br)
		{
			ReadData(br);
		}
		#endregion

		#region Binary Read/Write
		/// <summary>
		/// Read data using a BinaryReader.
		/// </summary>
		/// <param name="br">BinaryReader instance to use.</param>
		public void ReadData(BinaryReader br)
		{
			DamageInfo = br.ReadByte();

			byte[] preview = br.ReadBytes(2);
			if (BitConverter.IsLittleEndian)
			{
				Array.Reverse(preview);
			}
			PreviewPos = BitConverter.ToInt16(preview, 0);

			byte[] link = br.ReadBytes(2);
			if (BitConverter.IsLittleEndian)
			{
				Array.Reverse(link);
			}
			MoveLink = BitConverter.ToInt16(link, 0);

			byte[] animID = br.ReadBytes(2);
			if (BitConverter.IsLittleEndian)
			{
				Array.Reverse(animID);
			}
			AnimID = BitConverter.ToInt16(animID, 0);

			byte[] repeatID = br.ReadBytes(2);
			if (BitConverter.IsLittleEndian)
			{
				Array.Reverse(repeatID);
			}
			RepeatAnimID = BitConverter.ToInt16(repeatID, 0);

			byte[] fileID = br.ReadBytes(2);
			if (BitConverter.IsLittleEndian)
			{
				Array.Reverse(fileID);
			}
			MasterMoveID = BitConverter.ToInt16(fileID, 0);

			// strings could be Shift-JIS encoded, hence using a byte array.
			// (not like anyone will see them in-game anyways, for multiple reasons)
			byte[] temp = new byte[128];
			int ti = 0;
			while (br.PeekChar() != 0)
			{
				temp[ti++] = br.ReadByte();
			}
			br.ReadByte();
			MoveName = Encoding.GetEncoding("shift-jis").GetString(temp);
		}

		/// <summary>
		/// Write data using a BinaryWriter.
		/// </summary>
		/// <param name="bw">BinaryWriter instance to use.</param>
		public void WriteData(BinaryWriter bw)
		{
			bw.Write(DamageInfo);

			byte[] preview = BitConverter.GetBytes(PreviewPos);
			if (BitConverter.IsLittleEndian)
			{
				Array.Reverse(preview);
			}
			bw.Write(preview);

			byte[] link = BitConverter.GetBytes(MoveLink);
			if (BitConverter.IsLittleEndian)
			{
				Array.Reverse(link);
			}
			bw.Write(link);

			byte[] animID = BitConverter.GetBytes(AnimID);
			if (BitConverter.IsLittleEndian)
			{
				Array.Reverse(animID);
			}
			bw.Write(animID);

			byte[] repeatID = BitConverter.GetBytes(RepeatAnimID);
			if (BitConverter.IsLittleEndian)
			{
				Array.Reverse(repeatID);
			}
			bw.Write(repeatID);

			byte[] fileID = BitConverter.GetBytes(MasterMoveID);
			if (BitConverter.IsLittleEndian)
			{
				Array.Reverse(fileID);
			}
			bw.Write(fileID);

			bw.Write(MoveName.ToCharArray());
			bw.Write((byte)0);
		}
		#endregion
	}

	public class MenuItems_Moves
	{
		#region Class Members
		/// <summary>
		/// Number of entries in the file.
		/// </summary>
		public byte NumEntries;

		/// <summary>
		/// The actual entries in the file.
		/// </summary>
		public List<MoveMenuEntry> Entries;
		#endregion

		#region Constructors
		/// <summary>
		/// Default constructor.
		/// </summary>
		public MenuItems_Moves()
		{
			NumEntries = 0;
			Entries = new List<MoveMenuEntry>();
		}

		/// <summary>
		/// Constructor using a BinaryReader.
		/// </summary>
		/// <param name="br">BinaryReader instance to use.</param>
		public MenuItems_Moves(BinaryReader br)
		{
			Entries = new List<MoveMenuEntry>();
			ReadData(br);
		}
		#endregion

		#region Binary Read/Write
		/// <summary>
		/// Read data using a BinaryReader.
		/// </summary>
		/// <param name="br">BinaryReader instance to use.</param>
		public void ReadData(BinaryReader br)
		{
			NumEntries = br.ReadByte();
			for (int i = 0; i < NumEntries; i++)
			{
				Entries.Add(new MoveMenuEntry(br));
			}
		}

		/// <summary>
		/// Write data using a BinaryWriter.
		/// </summary>
		/// <param name="bw">BinaryWriter instance to use.</param>
		public void WriteData(BinaryWriter bw)
		{
			bw.Write(NumEntries);
		}
		#endregion
	}
}
