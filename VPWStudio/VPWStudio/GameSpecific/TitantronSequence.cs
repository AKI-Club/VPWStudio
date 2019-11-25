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

		/// <summary>
		/// Pointer to Titantron frames.
		/// </summary>
		/// (arguably the only thing common between the two formats)
		public UInt32 Pointer;

		/// <summary>
		/// Music associated with this TitantronSequence.
		/// </summary>
		public ushort Music;

		/// <summary>
		/// Text associated with this TitantronSequence.
		/// </summary>
		public ushort Text;

		/// <summary>
		/// Lighting and delay values.
		/// </summary>
		public ushort LightingDelay;

		/// <summary>
		/// List of Titantron frames in this TitantronSequence.
		/// </summary>
		/// (program-specific)
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
			TronFrames = new List<TitantronFrame>();

			long curPos = br.BaseStream.Position;

			// pointer values are going to be different for WM2K and No Mercy, aren't they... shit.
			// I guess I could just throw the shit in the location file
			//br.BaseStream.Seek(curPos, SeekOrigin.Begin);

			// stop reading when the TronFrame.ReadData(br) returns false
			/*
			bool done = false;
			while (!done)
			{
				TitantronFrame f = new TitantronFrame();
				TronFrames.Add(f);
				if (f.ReadData(br) == false)
				{
					done = true;
				}
			}
			*/

			br.BaseStream.Seek(curPos, SeekOrigin.Begin);
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

			// something about following the pointer and writing the TronFrames
		}
		#endregion
	}
}
