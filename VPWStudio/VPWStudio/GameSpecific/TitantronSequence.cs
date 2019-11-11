using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace VPWStudio.GameSpecific
{
	public class TitantronSequence
	{
		// note: some of these values only make sense in WM2K because of course they changed EVERYTHING in no mercy
		public UInt32 Pointer;
		public ushort Music;
		public ushort Text;
		public ushort LightingDelay;

		public List<TitantronFrame> TronFrames;

		public TitantronSequence()
		{
			Pointer = 0;
			Music = 0xFFFF; // "none"
			Text = 0;
			LightingDelay = 0;
			TronFrames = new List<TitantronFrame>();
		}

		public TitantronSequence(BinaryReader br)
		{
			ReadData(br);
		}

		#region Binary Read/Write
		/// <summary>
		/// Read TitantronSequence data using a BinaryReader.
		/// </summary>
		/// <param name="br">BinaryReader instance to use.</param>
		public void ReadData(BinaryReader br)
		{
			byte[] ptr = br.ReadBytes(4);
			if (BitConverter.IsLittleEndian)
			{
				Array.Reverse(ptr);
			}
			Pointer = BitConverter.ToUInt32(ptr, 0);

			byte[] music = br.ReadBytes(2);
			if (BitConverter.IsLittleEndian)
			{
				Array.Reverse(music);
			}
			Music = BitConverter.ToUInt16(music,0);

			byte[] text = br.ReadBytes(2);
			if (BitConverter.IsLittleEndian)
			{
				Array.Reverse(text);
			}
			Text = BitConverter.ToUInt16(text, 0);

			byte[] lighting = br.ReadBytes(2);
			if (BitConverter.IsLittleEndian)
			{
				Array.Reverse(lighting);
			}
			LightingDelay = BitConverter.ToUInt16(lighting, 0);

			// fill TronFrames after following the pointer
		}

		/// <summary>
		/// Write TitantronSequence data using a BinaryWriter.
		/// </summary>
		/// <param name="bw">BinaryWriter instance to use.</param>
		public void WriteData(BinaryWriter bw)
		{
			byte[] ptr = BitConverter.GetBytes(Pointer);
			if (BitConverter.IsLittleEndian)
			{
				Array.Reverse(ptr);
			}
			bw.Write(ptr);

			byte[] music = BitConverter.GetBytes(Music);
			if (BitConverter.IsLittleEndian)
			{
				Array.Reverse(music);
			}
			bw.Write(music);

			byte[] text = BitConverter.GetBytes(Text);
			if (BitConverter.IsLittleEndian)
			{
				Array.Reverse(text);
			}
			bw.Write(text);

			byte[] lighting = BitConverter.GetBytes(LightingDelay);
			if (BitConverter.IsLittleEndian)
			{
				Array.Reverse(lighting);
			}
			bw.Write(lighting);
		}
		#endregion
	}
}
