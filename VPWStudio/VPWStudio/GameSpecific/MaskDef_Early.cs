using System;
using System.IO;

namespace VPWStudio.GameSpecific
{
	/// <summary>
	/// Shared Mask definition for World Tour, VPW64, and Revenge.
	/// </summary>
	public class MaskDef_Early
	{
		#region Class Members
		/// <summary>
		/// File ID of Neck Model
		/// </summary>
		public UInt16 NeckModel;

		/// <summary>
		/// File ID of Head Model
		/// </summary>
		public UInt16 HeadModel;

		/// <summary>
		/// File ID of Extra Model
		/// </summary>
		public UInt16 ExtraModel;

		/// <summary>
		/// File ID of Neck Palette
		/// </summary>
		public UInt16 NeckPalette;

		/// <summary>
		/// File ID of Neck Texture
		/// </summary>
		public UInt16 NeckTexture;

		/// <summary>
		/// File ID of Head Palette
		/// </summary>
		public UInt16 HeadPalette;

		/// <summary>
		/// File ID of Head Texture
		/// </summary>
		public UInt16 HeadTexture;

		/// <summary>
		/// File ID of Extra Palette
		/// </summary>
		public UInt16 ExtraPalette;

		/// <summary>
		/// File ID of Extra Texture
		/// </summary>
		public UInt16 ExtraTexture;

		/// <summary>
		/// File ID of Ripped Mask Palette
		/// </summary>
		public UInt16 RippedMaskPalette;

		/// <summary>
		/// File ID of Ripped Mask Texture
		/// </summary>
		public UInt16 RippedMaskTexture;

		/// <summary>
		/// Value for Skin Color. (Not always used?)
		/// </summary>
		public UInt16 SkinColor;
		#endregion

		/// <summary>
		/// Default constructor.
		/// </summary>
		public MaskDef_Early()
		{
			NeckModel = 0;
			HeadModel = 0;
			ExtraModel = 0;
			NeckPalette = 0;
			NeckTexture = 0;
			HeadPalette = 0;
			HeadTexture = 0;
			ExtraPalette = 0;
			ExtraTexture = 0;
			RippedMaskPalette = 0;
			RippedMaskTexture = 0;
			SkinColor = 0;
		}

		/// <summary>
		/// Constructor using a BinaryReader.
		/// </summary>
		/// <param name="br">BinaryReader instance to use.</param>
		public MaskDef_Early(BinaryReader br)
		{
			ReadData(br);
		}

		/// <summary>
		/// Deep copy an existing MaskDef_Early instance.
		/// </summary>
		/// <param name="_src"></param>
		public void DeepCopy(MaskDef_Early _src)
		{
			NeckModel = _src.NeckModel;
			HeadModel = _src.HeadModel;
			ExtraModel = _src.ExtraModel;
			NeckPalette = _src.NeckPalette;
			NeckTexture = _src.NeckTexture;
			HeadPalette = _src.HeadPalette;
			HeadTexture = _src.HeadTexture;
			ExtraPalette = _src.ExtraPalette;
			ExtraTexture = _src.ExtraTexture;
			RippedMaskPalette = _src.RippedMaskPalette;
			RippedMaskTexture = _src.RippedMaskTexture;
			SkinColor = _src.SkinColor;
		}

		#region Binary Read/Write
		/// <summary>
		/// Read helper.
		/// </summary>
		/// <param name="br"></param>
		/// <returns></returns>
		private UInt16 ReadElement(BinaryReader br)
		{
			byte[] rByte = br.ReadBytes(2);
			if (BitConverter.IsLittleEndian)
			{
				Array.Reverse(rByte);
			}
			return BitConverter.ToUInt16(rByte, 0);
		}

		/// <summary>
		/// Read MaskDef_Early data using a BinaryReader.
		/// </summary>
		/// <param name="br"></param>
		public void ReadData(BinaryReader br)
		{
			NeckModel = ReadElement(br);
			HeadModel = ReadElement(br);
			ExtraModel = ReadElement(br);
			NeckPalette = ReadElement(br);
			NeckTexture = ReadElement(br);
			HeadPalette = ReadElement(br);
			HeadTexture = ReadElement(br);
			ExtraPalette = ReadElement(br);
			ExtraTexture = ReadElement(br);
			RippedMaskPalette = ReadElement(br);
			RippedMaskTexture = ReadElement(br);
			SkinColor = ReadElement(br);
		}

		/// <summary>
		/// Write helper.
		/// </summary>
		/// <param name="bw"></param>
		/// <param name="val"></param>
		private void WriteElement(BinaryWriter bw, UInt16 val)
		{
			byte[] wByte = BitConverter.GetBytes(val);
			if (BitConverter.IsLittleEndian)
			{
				Array.Reverse(wByte);
			}
			bw.Write(wByte);
		}

		public void WriteData(BinaryWriter bw)
		{
			WriteElement(bw, NeckModel);
			WriteElement(bw, HeadModel);
			WriteElement(bw, ExtraModel);
			WriteElement(bw, NeckPalette);
			WriteElement(bw, NeckTexture);
			WriteElement(bw, HeadPalette);
			WriteElement(bw, HeadTexture);
			WriteElement(bw, ExtraPalette);
			WriteElement(bw, ExtraTexture);
			WriteElement(bw, RippedMaskPalette);
			WriteElement(bw, RippedMaskTexture);
			WriteElement(bw, SkinColor);
		}
		#endregion
	}
}
