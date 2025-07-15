using System;
using System.Collections.Generic;
using System.IO;

namespace VPWStudio
{
    public class CameraDef
    {
        /// <summary>
        /// Pointer to list of pointers for camera values.
        /// </summary>
        public UInt32 DataPointer;

        /// <summary>
        /// Currently unknown value.
        /// </summary>
        public UInt16 UnknownValue;

        /// <summary>
        /// Camera definition ID.
        /// </summary>
        public UInt16 ID;

        
        public List<CameraValuePair> X;

        public List<CameraValuePair> Y;

        public List<CameraValuePair> Z;

        public List<CameraValuePair> Pitch;

        public List<CameraValuePair> Pan;

        public List<CameraValuePair> Roll;

        /// <summary>
        /// Default constructor.
        /// </summary>
        public CameraDef()
        {
            DataPointer = 0;
            UnknownValue = 0;
            ID = 0;
            X = new List<CameraValuePair>();
            Y = new List<CameraValuePair>();
            Z = new List<CameraValuePair>();
            Pitch = new List<CameraValuePair>();
            Pan = new List<CameraValuePair>();
            Roll = new List<CameraValuePair>();
        }

        /// <summary>
        /// Specific constructor.
        /// </summary>
        /// <param name="ptr">Pointer to camera data</param>
        /// <param name="unk">Unknown value</param>
        /// <param name="id">Camera data ID</param>
        public CameraDef(UInt32 ptr, UInt16 unk, UInt16 id)
        {
            DataPointer = ptr;
            UnknownValue = unk;
            ID = id;

            X = new List<CameraValuePair>();
            Y = new List<CameraValuePair>();
            Z = new List<CameraValuePair>();
            Pitch = new List<CameraValuePair>();
            Pan = new List<CameraValuePair>();
            Roll = new List<CameraValuePair>();
            // todo: read values?
        }

        /// <summary>
        /// Constructor using a BinaryReader.
        /// </summary>
        /// <param name="br">BinaryReader instance to use.</param>
        public CameraDef(BinaryReader br)
        {
            X = new List<CameraValuePair>();
            Y = new List<CameraValuePair>();
            Z = new List<CameraValuePair>();
            Pitch = new List<CameraValuePair>();
            Pan = new List<CameraValuePair>();
            Roll = new List<CameraValuePair>();

            ReadData(br);
        }

        public void ReadData(BinaryReader br)
        {
            byte[] b = br.ReadBytes(4);
            if (BitConverter.IsLittleEndian)
            {
                Array.Reverse(b);
            }
            DataPointer = BitConverter.ToUInt32(b,0);

            b = br.ReadBytes(2);
            if (BitConverter.IsLittleEndian)
            {
                Array.Reverse(b);
            }
            UnknownValue = BitConverter.ToUInt16(b,0);

            b = br.ReadBytes(2);
            if (BitConverter.IsLittleEndian)
            {
                Array.Reverse(b);
            }
            ID = BitConverter.ToUInt16(b, 0);

            // read CameraValuePairs
        }

        public void WriteData(BinaryWriter bw)
        {
            byte[] b = BitConverter.GetBytes(DataPointer);
            if (BitConverter.IsLittleEndian)
            {
                Array.Reverse(b);
            }
            bw.Write(b);

            byte[] b = BitConverter.GetBytes(UnknownValue);
            if (BitConverter.IsLittleEndian)
            {
                Array.Reverse(b);
            }
            bw.Write(b);

            byte[] b = BitConverter.GetBytes(ID);
            if (BitConverter.IsLittleEndian)
            {
                Array.Reverse(b);
            }
            bw.Write(b);

            // write CameraValuePairs
        }
    }
}
