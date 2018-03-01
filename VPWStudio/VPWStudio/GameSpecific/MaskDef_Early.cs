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
			this.NeckModel = 0;
			this.HeadModel = 0;
			this.ExtraModel = 0;
			this.NeckPalette = 0;
			this.NeckTexture = 0;
			this.HeadPalette = 0;
			this.HeadTexture = 0;
			this.ExtraPalette = 0;
			this.ExtraTexture = 0;
			this.RippedMaskPalette = 0;
			this.RippedMaskTexture = 0;
			this.SkinColor = 0;
		}

		/// <summary>
		/// Constructor using BinaryReader
		/// </summary>
		/// <param name="br"></param>
		public MaskDef_Early(BinaryReader br)
		{
			this.ReadData(br);
		}

		/// <summary>
		/// Deep copy an existing MaskDef_Early instance.
		/// </summary>
		/// <param name="_src"></param>
		public void DeepCopy(MaskDef_Early _src)
		{
			this.NeckModel = _src.NeckModel;
			this.HeadModel = _src.HeadModel;
			this.ExtraModel = _src.ExtraModel;
			this.NeckPalette = _src.NeckPalette;
			this.NeckTexture = _src.NeckTexture;
			this.HeadPalette = _src.HeadPalette;
			this.HeadTexture = _src.HeadTexture;
			this.ExtraPalette = _src.ExtraPalette;
			this.ExtraTexture = _src.ExtraTexture;
			this.RippedMaskPalette = _src.RippedMaskPalette;
			this.RippedMaskTexture = _src.RippedMaskTexture;
			this.SkinColor = _src.SkinColor;
		}

		#region Binary Read/Write
		/// <summary>
		/// Read MaskDef_Early data using a BinaryReader.
		/// </summary>
		/// <param name="br"></param>
		public void ReadData(BinaryReader br)
		{
			byte[] nm = br.ReadBytes(2);
			if (BitConverter.IsLittleEndian)
			{
				Array.Reverse(nm);
			}
			this.NeckModel = BitConverter.ToUInt16(nm, 0);

			byte[] hm = br.ReadBytes(2);
			if (BitConverter.IsLittleEndian)
			{
				Array.Reverse(hm);
			}
			this.HeadModel = BitConverter.ToUInt16(hm, 0);

			byte[] em = br.ReadBytes(2);
			if (BitConverter.IsLittleEndian)
			{
				Array.Reverse(em);
			}
			this.ExtraModel = BitConverter.ToUInt16(em, 0);

			byte[] np = br.ReadBytes(2);
			if (BitConverter.IsLittleEndian)
			{
				Array.Reverse(np);
			}
			this.NeckPalette = BitConverter.ToUInt16(np, 0);

			byte[] nt = br.ReadBytes(2);
			if (BitConverter.IsLittleEndian)
			{
				Array.Reverse(nt);
			}
			this.NeckTexture = BitConverter.ToUInt16(nt, 0);

			byte[] hp = br.ReadBytes(2);
			if (BitConverter.IsLittleEndian)
			{
				Array.Reverse(hp);
			}
			this.HeadPalette = BitConverter.ToUInt16(hp, 0);

			byte[] ht = br.ReadBytes(2);
			if (BitConverter.IsLittleEndian)
			{
				Array.Reverse(ht);
			}
			this.HeadTexture = BitConverter.ToUInt16(ht, 0);

			byte[] ep = br.ReadBytes(2);
			if (BitConverter.IsLittleEndian)
			{
				Array.Reverse(ep);
			}
			this.ExtraPalette = BitConverter.ToUInt16(ep, 0);

			byte[] et = br.ReadBytes(2);
			if (BitConverter.IsLittleEndian)
			{
				Array.Reverse(et);
			}
			this.ExtraTexture = BitConverter.ToUInt16(et, 0);

			byte[] rmp = br.ReadBytes(2);
			if (BitConverter.IsLittleEndian)
			{
				Array.Reverse(rmp);
			}
			this.RippedMaskPalette = BitConverter.ToUInt16(rmp, 0);

			byte[] rmt = br.ReadBytes(2);
			if (BitConverter.IsLittleEndian)
			{
				Array.Reverse(rmt);
			}
			this.RippedMaskTexture = BitConverter.ToUInt16(rmt, 0);

			byte[] sc = br.ReadBytes(2);
			if (BitConverter.IsLittleEndian)
			{
				Array.Reverse(sc);
			}
			this.SkinColor = BitConverter.ToUInt16(sc, 0);
		}

		public void WriteData(BinaryWriter bw)
		{
		}
		#endregion
	}
}
