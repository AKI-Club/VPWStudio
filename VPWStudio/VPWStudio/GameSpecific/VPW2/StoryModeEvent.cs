using System.IO;

namespace VPWStudio.GameSpecific.VPW2
{
	/// <summary>
	/// Story Mode Event data for Virtual Pro-Wrestling 2.
	/// </summary>
	public class StoryModeEvent
	{
		#region Members
		/// <summary>
		/// Bulletin Board message number.
		/// </summary>
		public byte BulletinBoardMessage;

		/// <summary>
		/// True if promotion/relegation takes place after the event finishes.
		/// </summary>
		public bool HandlePromotionRelegation;

		/// <summary>
		/// True if the tour opening scene should be played before this event.
		/// </summary>
		public bool ShowTourOpeningScene;

		/// <summary>
		/// True if the event has a qualifying requirement.
		/// </summary>
		public bool HasQualifyingRequirement;

		/// <summary>
		/// Event Location (index into event locations)
		/// </summary>
		public byte EventLocation;

		/// <summary>
		/// Arena Type (index into RRS/KRS arenas table)
		/// </summary>
		public byte ArenaType;

		/// <summary>
		/// Player participation.
		/// </summary>
		public byte PlayerParticipation;

		/// <summary>
		/// Show Number (index into show numbers, except for 0x0A)
		/// </summary>
		public byte ShowNumber;

		/// <summary>
		/// Booking Instructions to use (index into main Booking Instructions table)
		/// </summary>
		public byte BookingInstructions;

		/// <summary>
		/// Event name (index into event names)
		/// </summary>
		public byte EventName;

		/// <summary>
		/// Month number.
		/// January = 0, December = 0xB, Finished = 0xC
		/// </summary>
		public byte MonthNumber;
		#endregion

		#region Constructors
		/// <summary>
		/// Default constructor.
		/// </summary>
		public StoryModeEvent()
		{
			BulletinBoardMessage = 0;
			HandlePromotionRelegation = false;
			ShowTourOpeningScene = false;
			HasQualifyingRequirement = false;
			EventLocation = 0;
			ArenaType = 0;
			PlayerParticipation = 0;
			ShowNumber = 0;
			BookingInstructions = 0;
			EventName = 0;
			MonthNumber = 0;
		}

		/// <summary>
		/// Constructor using a BinaryReader.
		/// </summary>
		/// <param name="br">BinaryReader instance to use.</param>
		public StoryModeEvent(BinaryReader br)
		{
			ReadData(br);
		}
		#endregion

		#region Binary Read/Write
		public void ReadData(BinaryReader br)
		{
			byte[] data = br.ReadBytes(4);

			BulletinBoardMessage = (byte)(data[0] >> 4);
			HandlePromotionRelegation = (data[0] & 8) != 0;
			ShowTourOpeningScene = (data[0] & 4) != 0;
			HasQualifyingRequirement = (data[0] & 2) != 0;
			EventLocation = (byte)(((data[0] & 1) << 4) | (data[1] & 0xF0) >> 4);

			ArenaType = (byte)((data[1] & 0xC) >> 2);
			PlayerParticipation = (byte)(data[1] & 3);

			BookingInstructions = (byte)(data[2] >> 4);
			ShowNumber = (byte)(data[2] & 0x0F);

			EventName = (byte)(data[3] >> 4);
			MonthNumber = (byte)(data[3] & 0x0F);
		}

		public void WriteData(BinaryWriter bw)
		{
			// encode data
			byte d0 = (byte)(BulletinBoardMessage << 4);
			d0 |= HandlePromotionRelegation ? (byte)8 : (byte)0;
			d0 |= ShowTourOpeningScene ? (byte)4 : (byte)0;
			d0 |= HasQualifyingRequirement ? (byte)2 : (byte)0;
			d0 |= (byte)((EventLocation & 0x10) >> 4);
			bw.Write(d0);

			byte d1 = (byte)((EventLocation & 0x0F) << 4);
			d1 |= (byte)(ArenaType << 2);
			d1 |= (byte)(PlayerParticipation & 3);
			bw.Write(d1);

			byte d2 = (byte)(BookingInstructions << 4);
			d2 |= (byte)(ShowNumber & 0x0F);
			bw.Write(d2);

			byte d3 = (byte)(EventName << 4);
			d3 |= (byte)(MonthNumber & 0x0F);
			bw.Write(d3);
		}
		#endregion
	}
}
