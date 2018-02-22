using System;
using System.Globalization;

namespace VPWStudio
{
	/// <summary>
	/// GameShark code types.
	/// </summary>
	public enum GSCodeTypes
	{
		/// <summary>
		/// (0x80) Constant value write.
		/// </summary>
		ConstantWrite = 0x80,
		/// <summary>
		/// (0x88) Write on GameShark Button press.
		/// </summary>
		GSButton = 0x88,
		/// <summary>
		/// (0xA0) Uncached write to the specified address.
		/// </summary>
		UncachedWrite = 0xA0,
		/// <summary>
		/// (0xD0) Activator - value equal
		/// </summary>
		ActivatorEqual = 0xD0,
		/// <summary>
		/// (0xD0) Activator - value not equal
		/// </summary>
		ActivatorDiff = 0xD2,
		/// <summary>
		/// (0x50) Patch Code; expands a single code into multiple.
		/// </summary>
		/// <remarks>
		/// Requires special handling.
		/// </remarks>
		PatchCode = 0x50,
	}

	/// <summary>
	/// Representation of a single GameShark code.
	/// </summary>
	public class GameSharkCode
	{
		/// <summary>
		/// Code type.
		/// </summary>
		public GSCodeTypes CodeType;

		/// <summary>
		/// Target address of this code.
		/// </summary>
		public UInt32 TargetAddress;

		/// <summary>
		/// Target value for this code.
		/// </summary>
		public UInt16 TargetValue;

		/// <summary>
		/// Data width of the value to write.
		/// Valid values are 8 and 16.
		/// </summary>
		public int ValueWidth = 8;

		/// <summary>
		/// Default constructor
		/// </summary>
		public GameSharkCode()
		{
			this.CodeType = GSCodeTypes.ConstantWrite;
			this.TargetAddress = 0;
			this.TargetValue = 0;
			this.ValueWidth = 8;
		}

		/// <summary>
		/// Specific constructor.
		/// </summary>
		/// <param name="_type">Code type</param>
		/// <param name="_addr">Code address</param>
		/// <param name="_val">Code value</param>
		/// <param name="_width">Code data width (8 or 16)</param>
		public GameSharkCode(GSCodeTypes _type, UInt32 _addr, UInt16 _val, int _width = 8)
		{
			this.CodeType = _type;
			this.TargetAddress = _addr;
			this.TargetValue = _val;
			this.ValueWidth = _width;
		}

		/// <summary>
		/// Constructor from existing code.
		/// </summary>
		/// <param name="_code">GameShark code in "XXYYYYYY ZZZZ" format</param>
		public GameSharkCode(string _code)
		{
			this.SetFromCode(_code);
		}

		/// <summary>
		/// Get the GameShark code for this object.
		/// </summary>
		/// <returns>Text representation of the GameShark code.</returns>
		public override string ToString()
		{
			byte topByte = (byte)this.CodeType;
			if (this.ValueWidth == 16)
			{
				topByte |= 0x01;
			}

			return String.Format("{0:X2}{1:X6} {2:X4}",
				topByte,
				(this.TargetAddress & 0x00FFFFFF),
				this.TargetValue
			);
		}

		/// <summary>
		/// Set GameSharkCode values from an existing code.
		/// </summary>
		/// <param name="_code">GameShark code in "XXYYYYYY ZZZZ" format</param>
		public void SetFromCode(string _code)
		{
			byte topByte = Byte.Parse(_code.Substring(0, 2), NumberStyles.HexNumber);
			this.CodeType = (GSCodeTypes)(topByte & 0xFE); // mask away lowest bit... might not be useful for some code types, though
			this.ValueWidth = ((topByte & 0x01) != 0) ? 16 : 8;
			this.TargetAddress = UInt32.Parse(_code.Substring(2, 6), NumberStyles.HexNumber);
			this.TargetValue = UInt16.Parse(_code.Substring(9), NumberStyles.HexNumber);
		}
	}
}
