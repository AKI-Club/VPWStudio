using System;
using System.Data.SqlTypes;
using System.IO;

namespace VPWStudio
{
    public class CameraValuePair
    {
        /// <summary>
        /// Frame number used for list termination.
        /// </summary>
        public const short CAMERA_FRAME_TERMINATOR = 0x7FFF;

        /// <summary>
        /// Camera value.
        /// </summary>
        public short Value;

        /// <summary>
        /// Frame number.
        /// </summary>
        public short FrameNumber;

        /// <summary>
        /// Default constructor.
        /// </summary>
        public CameraValuePair()
        {
            Value = 0;
            FrameNumber = 0;
        }

        /// <summary>
        /// Specific constructor.
        /// </summary>
        /// <param name="v">Value</param>
        /// <param name="frame">Frame Number</param>
        public CameraValuePair(short v, short frame)
        {
            Value = v;
            FrameNumber = frame;
        }

        /// <summary>
        /// Read CameraValuePair data using a BinaryReader.
        /// </summary>
        /// <param name="br">BinaryReader instance to use.</param>
        public void ReadData(BinaryReader br)
        {
            byte[] valBytes = br.ReadBytes(2);
            if (BitConverter.IsLittleEndian)
            {
                Array.Reverse(valBytes);
            }
            Value = BitConverter.ToInt16(valBytes, 0);

            valBytes = br.ReadBytes(2);
            if (BitConverter.IsLittleEndian)
            {
                Array.Reverse(valBytes);
            }
            FrameNumber = BitConverter.ToInt16(valBytes, 0);
        }

        /// <summary>
        /// Write CameraValuePair data using a BinaryWriter.
        /// </summary>
        /// <param name="bw">BinaryWriter instance to use.</param>
        public void WriteData(BinaryWriter bw)
        {
            byte[] v = BitConverter.GetBytes(Value);
            if (BitConverter.IsLittleEndian)
            {
                Array.Reverse(v);
            }
            bw.Write(v);

            v = BitConverter.GetBytes(FrameNumber);
            if (BitConverter.IsLittleEndian)
            {
                Array.Reverse(v);
            }
            bw.Write(v);
        }
    }
}
