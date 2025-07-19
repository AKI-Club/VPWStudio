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

        #region Data Pointer Values
        /// <summary>
        /// Pointer to X values
        /// </summary>
        public UInt32 ValuePointerX;

        /// <summary>
        /// Pointer to Y values
        /// </summary>
        public UInt32 ValuePointerY;

        /// <summary>
        /// Pointer to Z values
        /// </summary>
        public UInt32 ValuePointerZ;

        /// <summary>
        /// Pointer to Pitch values
        /// </summary>
        public UInt32 ValuePointerPitch;

        /// <summary>
        /// Pointer to Pan values
        /// </summary>
        public UInt32 ValuePointerPan;

        /// <summary>
        /// Pointer to Roll values
        /// </summary>
        public UInt32 ValuePointerRoll;
        #endregion

        #region Value Lists
        public List<CameraValuePair> X;

        public List<CameraValuePair> Y;

        public List<CameraValuePair> Z;

        public List<CameraValuePair> Pitch;

        public List<CameraValuePair> Pan;

        public List<CameraValuePair> Roll;
        #endregion

        /// <summary>
        /// Default constructor.
        /// </summary>
        public CameraDef()
        {
            DataPointer = 0;
            UnknownValue = 0;
            ID = 0;
            ValuePointerX = 0;
            ValuePointerY = 0;
            ValuePointerZ = 0;
            ValuePointerPitch = 0;
            ValuePointerPan = 0;
            ValuePointerRoll = 0;
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

            // these will need to be set by the caller
            ValuePointerX = 0;
            ValuePointerY = 0;
            ValuePointerZ = 0;
            ValuePointerPitch = 0;
            ValuePointerPan = 0;
            ValuePointerRoll = 0;

            X = new List<CameraValuePair>();
            Y = new List<CameraValuePair>();
            Z = new List<CameraValuePair>();
            Pitch = new List<CameraValuePair>();
            Pan = new List<CameraValuePair>();
            Roll = new List<CameraValuePair>();
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

            // save current position and read CameraValuePairs
            long prevAddress = br.BaseStream.Position;
            br.BaseStream.Seek(Program.PointerToRomAddr(DataPointer, 1), SeekOrigin.Begin);

            // read in pointers
            b = br.ReadBytes(4);
            if (BitConverter.IsLittleEndian)
            {
                Array.Reverse(b);
            }
            ValuePointerX = BitConverter.ToUInt32(b, 0);
            
            b = br.ReadBytes(4);
            if (BitConverter.IsLittleEndian)
            {
                Array.Reverse(b);
            }
            ValuePointerY = BitConverter.ToUInt32(b, 0);

            b = br.ReadBytes(4);
            if (BitConverter.IsLittleEndian)
            {
                Array.Reverse(b);
            }
            ValuePointerZ = BitConverter.ToUInt32(b, 0);

            b = br.ReadBytes(4);
            if (BitConverter.IsLittleEndian)
            {
                Array.Reverse(b);
            }
            ValuePointerPitch = BitConverter.ToUInt32(b, 0);

            b = br.ReadBytes(4);
            if (BitConverter.IsLittleEndian)
            {
                Array.Reverse(b);
            }
            ValuePointerPan = BitConverter.ToUInt32(b, 0);

            b = br.ReadBytes(4);
            if (BitConverter.IsLittleEndian)
            {
                Array.Reverse(b);
            }
            ValuePointerRoll = BitConverter.ToUInt32(b, 0);

            bool TerminatorFound = false;
            br.BaseStream.Seek(Program.PointerToRomAddr(ValuePointerX, 1), SeekOrigin.Begin);
            while (!TerminatorFound)
            {
                CameraValuePair cvp = new CameraValuePair(br);
                X.Add(cvp);
                if (cvp.FrameNumber == CameraValuePair.CAMERA_FRAME_TERMINATOR)
                {
                    TerminatorFound = true;
                }
            }

            TerminatorFound = false;
            br.BaseStream.Seek(Program.PointerToRomAddr(ValuePointerY, 1), SeekOrigin.Begin);
            while (!TerminatorFound)
            {
                CameraValuePair cvp = new CameraValuePair(br);
                Y.Add(cvp);
                if (cvp.FrameNumber == CameraValuePair.CAMERA_FRAME_TERMINATOR)
                {
                    TerminatorFound = true;
                }
            }

            TerminatorFound = false;
            br.BaseStream.Seek(Program.PointerToRomAddr(ValuePointerZ, 1), SeekOrigin.Begin);
            while (!TerminatorFound)
            {
                CameraValuePair cvp = new CameraValuePair(br);
                Z.Add(cvp);
                if (cvp.FrameNumber == CameraValuePair.CAMERA_FRAME_TERMINATOR)
                {
                    TerminatorFound = true;
                }
            }

            TerminatorFound = false;
            br.BaseStream.Seek(Program.PointerToRomAddr(ValuePointerPitch, 1), SeekOrigin.Begin);
            while (!TerminatorFound)
            {
                CameraValuePair cvp = new CameraValuePair(br);
                Pitch.Add(cvp);
                if (cvp.FrameNumber == CameraValuePair.CAMERA_FRAME_TERMINATOR)
                {
                    TerminatorFound = true;
                }
            }

            TerminatorFound = false;
            br.BaseStream.Seek(Program.PointerToRomAddr(ValuePointerPan, 1), SeekOrigin.Begin);
            while (!TerminatorFound)
            {
                CameraValuePair cvp = new CameraValuePair(br);
                Pan.Add(cvp);
                if (cvp.FrameNumber == CameraValuePair.CAMERA_FRAME_TERMINATOR)
                {
                    TerminatorFound = true;
                }
            }

            TerminatorFound = false;
            br.BaseStream.Seek(Program.PointerToRomAddr(ValuePointerRoll, 1), SeekOrigin.Begin);
            while (!TerminatorFound)
            {
                CameraValuePair cvp = new CameraValuePair(br);
                Roll.Add(cvp);
                if (cvp.FrameNumber == CameraValuePair.CAMERA_FRAME_TERMINATOR)
                {
                    TerminatorFound = true;
                }
            }

            // restore location before next read
            br.BaseStream.Seek(prevAddress, SeekOrigin.Begin);
        }

        public void WriteData(BinaryWriter bw)
        {
            byte[] b = BitConverter.GetBytes(DataPointer);
            if (BitConverter.IsLittleEndian)
            {
                Array.Reverse(b);
            }
            bw.Write(b);

            b = BitConverter.GetBytes(UnknownValue);
            if (BitConverter.IsLittleEndian)
            {
                Array.Reverse(b);
            }
            bw.Write(b);

            b = BitConverter.GetBytes(ID);
            if (BitConverter.IsLittleEndian)
            {
                Array.Reverse(b);
            }
            bw.Write(b);

            // save write location

            // write CameraValuePairs

            // restore write location
        }
    }
}
