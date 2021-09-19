using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;

namespace VPWStudio
{
	/// <summary>
	/// Wrestler Definition File.
	/// </summary>
	public class WrestlerDefFile
	{
		#region Class Members
		/// <summary>
		/// Game Type (defines what wrestler defs are read/written)
		/// </summary>
		public VPWGames GameType;

		#region Game-Specific
		public SortedList<int, GameSpecific.WrestlerDefinition_Early> WrestlerDefs_Early;

		/// <summary>
		/// WCW/nWo Revenge Wrestler Definitions
		/// </summary>
		public SortedList<int, GameSpecific.Revenge.WrestlerDefinition> WrestlerDefs_Revenge;

		/// <summary>
		/// WWF WrestleMania 2000 Wrestler Definitions
		/// </summary>
		public SortedList<int, GameSpecific.WM2K.WrestlerDefinition> WrestlerDefs_WM2K;

		/// <summary>
		/// Virtual Pro-Wrestling 2 Wrestler Definitions
		/// </summary>
		public SortedList<int, GameSpecific.VPW2.WrestlerDefinition> WrestlerDefs_VPW2;

		/// <summary>
		/// WWF No Mercy Wrestler Definitions
		/// </summary>
		public SortedList<int, GameSpecific.NoMercy.WrestlerDefinition> WrestlerDefs_NoMercy;
		#endregion
		#endregion

		#region Constructors
		public WrestlerDefFile()
		{
			GameType = VPWGames.Invalid;
		}

		public WrestlerDefFile(VPWGames _game)
		{
			GameType = _game;
		}
		#endregion

		#region Helpers
		/// <summary>
		/// Check if this WrestlerDefFile is compatible with a specific game.
		/// </summary>
		/// <param name="_gt">VPWGames value to check</param>
		/// <returns>True if the passed in value matches the WrestlerDefFile's GameType.</returns>
		public bool IsGameType(VPWGames _gt)
		{
			return _gt == GameType;
		}

		#endregion

		#region Read Data
		/// <summary>
		/// Read WrestlerDef file.
		/// </summary>
		/// <param name="sr">StreamReader with WrestlerDef file loaded.</param>
		public void ReadFile(StreamReader sr)
		{
			// first line is GameType, which determines how the rest of the file is handled.
			GameType = (VPWGames)Enum.Parse(typeof(VPWGames), sr.ReadLine());

			int wrestlerNum = 0;
			switch (GameType)
			{
				case VPWGames.WorldTour:
				case VPWGames.VPW64:
					WrestlerDefs_Early = new SortedList<int, GameSpecific.WrestlerDefinition_Early>();

					break;

				case VPWGames.Revenge:
					WrestlerDefs_Revenge = new SortedList<int, GameSpecific.Revenge.WrestlerDefinition>();
					while (!sr.EndOfStream)
					{
						string line = sr.ReadLine();
						if (!line.Equals(String.Empty))
						{
							GameSpecific.Revenge.WrestlerDefinition wd = ReadData_Revenge(line);
							WrestlerDefs_Revenge.Add(wrestlerNum, wd);
							wrestlerNum++;
						}
					}
					break;

				case VPWGames.WM2K:
					WrestlerDefs_WM2K = new SortedList<int, GameSpecific.WM2K.WrestlerDefinition>();
					while (!sr.EndOfStream)
					{
						string line = sr.ReadLine();
						if (!line.Equals(String.Empty))
						{
							GameSpecific.WM2K.WrestlerDefinition wd = ReadData_WM2K(line);
							WrestlerDefs_WM2K.Add(wrestlerNum, wd);
							wrestlerNum++;
						}
					}
					break;

				case VPWGames.VPW2:
					WrestlerDefs_VPW2 = new SortedList<int, GameSpecific.VPW2.WrestlerDefinition>();
					while (!sr.EndOfStream)
					{
						string line = sr.ReadLine();
						if (!line.Equals(String.Empty))
						{
							GameSpecific.VPW2.WrestlerDefinition wd = ReadData_VPW2(line);
							WrestlerDefs_VPW2.Add(wrestlerNum, wd);
							wrestlerNum++;
						}
					}
					break;

				case VPWGames.NoMercy:
					WrestlerDefs_NoMercy = new SortedList<int, GameSpecific.NoMercy.WrestlerDefinition>();
					while (!sr.EndOfStream)
					{
						string line = sr.ReadLine();
						if (!line.Equals(String.Empty))
						{
							GameSpecific.NoMercy.WrestlerDefinition wd = ReadData_NoMercy(line);
							WrestlerDefs_NoMercy.Add(wrestlerNum, wd);
							wrestlerNum++;
						}
					}
					break;

				default:
					WrestlerDefs_Early = null;
					WrestlerDefs_Revenge = null;
					WrestlerDefs_WM2K = null;
					WrestlerDefs_VPW2 = null;
					WrestlerDefs_NoMercy = null;
					break;
			}
		}

		public GameSpecific.WrestlerDefinition_Early ReadData_Early(string input)
		{
			GameSpecific.WrestlerDefinition_Early wdef = new GameSpecific.WrestlerDefinition_Early();

			// Early games (World Tour and VPW64) line format:
			// ID4/ID2 = unknown1,flags1,unknown2,namePointer,profilePointer,heightPointer,weightPointer

			string[] tokens = input.Split(new char[] { '/', '=' });
			// tokens[0] = ID4
			// tokens[1] = ID2
			// tokens[2] = everything after '='; needs further parsing

			return wdef;
		}

		/// <summary>
		/// Read data as WCW/nWo Revenge Wrestler Definition data.
		/// </summary>
		/// <param name="input">Input string to parse.</param>
		/// <returns>a WCW/nWo Revenge WrestlerDefinition.</returns>
		public GameSpecific.Revenge.WrestlerDefinition ReadData_Revenge(string input)
		{
			GameSpecific.Revenge.WrestlerDefinition wdef = new GameSpecific.Revenge.WrestlerDefinition();

			// Revenge line format:
			// ID4/ID2=unknown1,unknown2,unknown3,namePointer,heightPointer,weightPointer,unknown4,managerID2,unknown5,unknown6

			string[] tokens = input.Split(new char[] { '/', '=' });
			// tokens[0] = ID4
			// tokens[1] = ID2
			// tokens[2] = everything after '='; needs further parsing

			wdef.WrestlerID4 = ushort.Parse(tokens[0], NumberStyles.HexNumber);
			wdef.WrestlerID2 = byte.Parse(tokens[1], NumberStyles.HexNumber);

			string[] wresData = tokens[2].Split(',');
			wdef.Unknown1 = byte.Parse(wresData[0], NumberStyles.HexNumber);
			wdef.Unknown2 = ushort.Parse(wresData[1], NumberStyles.HexNumber);
			wdef.Unknown3 = ushort.Parse(wresData[2], NumberStyles.HexNumber);
			wdef.NamePointer = UInt32.Parse(wresData[3], NumberStyles.HexNumber);
			wdef.HeightPointer = UInt32.Parse(wresData[4], NumberStyles.HexNumber);
			wdef.WeightPointer = UInt32.Parse(wresData[5], NumberStyles.HexNumber);
			wdef.Unknown4 = byte.Parse(wresData[6], NumberStyles.HexNumber);
			wdef.ManagerID2 = byte.Parse(wresData[7], NumberStyles.HexNumber);
			wdef.Unknown5 = byte.Parse(wresData[8], NumberStyles.HexNumber);
			wdef.Unknown6 = byte.Parse(wresData[9], NumberStyles.HexNumber);

			return wdef;
		}

		/// <summary>
		/// Read data as WWF WrestleMania 2000 Wrestler Definition data.
		/// </summary>
		/// <param name="input">Input string to parse.</param>
		/// <returns>a WWF WrestleMania 2000 WrestlerDefinition.</returns>
		public GameSpecific.WM2K.WrestlerDefinition ReadData_WM2K(string input)
		{
			GameSpecific.WM2K.WrestlerDefinition wdef = new GameSpecific.WM2K.WrestlerDefinition();

			// WM2K line format:
			// ID4/ID2=namePointer,height,weight,movesetIndex,paramsIndex,theme,video,unknown,costumePointer1,costumePointer2,costumePointer3,costumePointer4

			string[] tokens = input.Split(new char[] { '/', '=' });
			// tokens[0] = ID4
			// tokens[1] = ID2
			// tokens[2] = everything after '='; needs further parsing

			wdef.WrestlerID4 = ushort.Parse(tokens[0], NumberStyles.HexNumber);
			wdef.WrestlerID2 = byte.Parse(tokens[1], NumberStyles.HexNumber);

			string[] wresData = tokens[2].Split(',');
			wdef.NamePointer = UInt32.Parse(wresData[0], NumberStyles.HexNumber);
			wdef.Height = ushort.Parse(wresData[1], NumberStyles.HexNumber);
			wdef.Weight = ushort.Parse(wresData[2], NumberStyles.HexNumber);
			wdef.MovesetFileIndex = ushort.Parse(wresData[3], NumberStyles.HexNumber);
			wdef.ParamsFileIndex = ushort.Parse(wresData[4], NumberStyles.HexNumber);
			wdef.ThemeSong = byte.Parse(wresData[5], NumberStyles.HexNumber);
			wdef.EntranceVideo = byte.Parse(wresData[6], NumberStyles.HexNumber);
			wdef.Unknown = ushort.Parse(wresData[7], NumberStyles.HexNumber);
			wdef.CostumePointers[0] = UInt32.Parse(wresData[8], NumberStyles.HexNumber);
			wdef.CostumePointers[1] = UInt32.Parse(wresData[9], NumberStyles.HexNumber);
			wdef.CostumePointers[2] = UInt32.Parse(wresData[10], NumberStyles.HexNumber);
			wdef.CostumePointers[3] = UInt32.Parse(wresData[11], NumberStyles.HexNumber);

			return wdef;
		}

		/// <summary>
		/// Read data as Virtual Pro-Wrestling 2 Wrestler Definition data.
		/// </summary>
		/// <param name="input">Input string to parse.</param>
		/// <returns>a Virtual Pro-Wrestling 2 WrestlerDefintion.</returns>
		public GameSpecific.VPW2.WrestlerDefinition ReadData_VPW2(string input)
		{
			GameSpecific.VPW2.WrestlerDefinition wdef = new GameSpecific.VPW2.WrestlerDefinition();

			// VPW2 line format:
			// ID4/ID2=theme,namecall,height,weight,voiceA,voiceB,movesetIndex,paramsIndex,appearanceIndex,profileIndex

			string[] tokens = input.Split(new char[] { '/', '=' });
			// tokens[0] = ID4
			// tokens[1] = ID2
			// tokens[2] = everything after '='; needs further parsing

			wdef.WrestlerID4 = ushort.Parse(tokens[0], NumberStyles.HexNumber);
			wdef.WrestlerID2 = byte.Parse(tokens[1], NumberStyles.HexNumber);

			string[] wresData = tokens[2].Split(',');
			wdef.ThemeSong = byte.Parse(wresData[0], NumberStyles.HexNumber);
			wdef.NameCall = byte.Parse(wresData[1], NumberStyles.HexNumber);
			wdef.Height = byte.Parse(wresData[2], NumberStyles.HexNumber);
			wdef.Weight = byte.Parse(wresData[3], NumberStyles.HexNumber);
			wdef.Voice1 = byte.Parse(wresData[4], NumberStyles.HexNumber);
			wdef.Voice2 = byte.Parse(wresData[5], NumberStyles.HexNumber);
			wdef.MovesetFileIndex = ushort.Parse(wresData[6], NumberStyles.HexNumber);
			wdef.ParamsFileIndex = ushort.Parse(wresData[7], NumberStyles.HexNumber);
			wdef.AppearanceIndex = ushort.Parse(wresData[8], NumberStyles.HexNumber);
			wdef.ProfileIndex = ushort.Parse(wresData[9], NumberStyles.HexNumber);

			return wdef;
		}

		/// <summary>
		/// Read data as WWF No Mercy Wrestler Definition data.
		/// </summary>
		/// <param name="input">Input string to parse.</param>
		/// <returns>a WWF No Mercy WrestlerDefinition.</returns>
		public GameSpecific.NoMercy.WrestlerDefinition ReadData_NoMercy(string input)
		{
			GameSpecific.NoMercy.WrestlerDefinition wdef = new GameSpecific.NoMercy.WrestlerDefinition();

			// NoMercy line format:
			// ID4/ID2=theme,video,height,unknown,weight,movesetIndex,paramsIndex,appearanceIndex,profileIndex

			string[] tokens = input.Split(new char[] { '/', '=' });
			// tokens[0] = ID4
			// tokens[1] = ID2
			// tokens[2] = everything after '='; needs further parsing

			wdef.WrestlerID4 = ushort.Parse(tokens[0], NumberStyles.HexNumber);
			wdef.WrestlerID2 = byte.Parse(tokens[1], NumberStyles.HexNumber);

			string[] wresData = tokens[2].Split(',');
			wdef.ThemeSong = byte.Parse(wresData[0], NumberStyles.HexNumber);
			wdef.EntranceVideo = byte.Parse(wresData[1], NumberStyles.HexNumber);
			wdef.Height = byte.Parse(wresData[2], NumberStyles.HexNumber);
			wdef.Unknown = byte.Parse(wresData[3], NumberStyles.HexNumber);
			wdef.Weight = ushort.Parse(wresData[4], NumberStyles.HexNumber);
			wdef.MovesetFileIndex = ushort.Parse(wresData[5], NumberStyles.HexNumber);
			wdef.ParamsFileIndex = ushort.Parse(wresData[6], NumberStyles.HexNumber);
			wdef.AppearanceIndex = ushort.Parse(wresData[7], NumberStyles.HexNumber);
			wdef.ProfileIndex = ushort.Parse(wresData[8], NumberStyles.HexNumber);

			return wdef;
		}
		#endregion

		#region Write Data
		/// <summary>
		/// Write data to a WrestlerDef file.
		/// </summary>
		/// <param name="sw">StreamWriter with WrestlerDef output file.</param>
		public void WriteFile(StreamWriter sw)
		{
			sw.WriteLine(GameType.ToString());

			switch (GameType)
			{
				case VPWGames.WorldTour:
				case VPWGames.VPW64:
					foreach (KeyValuePair<int, GameSpecific.WrestlerDefinition_Early> wd in WrestlerDefs_Early)
					{
						sw.WriteLine(WriteData_Early(wd));
					}
					break;

				case VPWGames.Revenge:
					foreach (KeyValuePair<int, GameSpecific.Revenge.WrestlerDefinition> wd in WrestlerDefs_Revenge)
					{
						sw.WriteLine(WriteData_Revenge(wd));
					}
					break;

				case VPWGames.WM2K:
					foreach (KeyValuePair<int, GameSpecific.WM2K.WrestlerDefinition> wd in WrestlerDefs_WM2K)
					{
						sw.WriteLine(WriteData_WM2K(wd));
					}
					break;

				case VPWGames.VPW2:
					foreach (KeyValuePair<int, GameSpecific.VPW2.WrestlerDefinition> wd in WrestlerDefs_VPW2)
					{
						sw.WriteLine(WriteData_VPW2(wd));
					}
					break;

				case VPWGames.NoMercy:
					foreach (KeyValuePair<int, GameSpecific.NoMercy.WrestlerDefinition> wd in WrestlerDefs_NoMercy)
					{
						sw.WriteLine(WriteData_NoMercy(wd));
					}
					break;
			}
			sw.Flush();
		}

		public string WriteData_Early(KeyValuePair<int, GameSpecific.WrestlerDefinition_Early> wd)
		{
			// ID4/ID2 = unknown1,flags1,unknown2,namePointer,profilePointer,heightPointer,weightPointer
			string outData = String.Format("{0:X4}/{1:X2}=", wd.Value.WrestlerID4, wd.Value.WrestlerID2);
			outData += String.Format("{0:X4},{1:X2},{2:X4},{3:X8},{4:X8},{5:X8},{6:X8}",
				wd.Value.Unknown1,
				wd.Value.Flags1,
				wd.Value.Unknown2,
				wd.Value.NamePointer, wd.Value.ProfilePointer, wd.Value.HeightPointer, wd.Value.WeightPointer
			);

			return outData;
		}

		public string WriteData_Revenge(KeyValuePair<int, GameSpecific.Revenge.WrestlerDefinition> wd)
		{
			// ID4/ID2=unknown1,unknown2,unknown3,namePointer,heightPointer,weightPointer,unknown4,managerID2,unknown5,unknown6
			string outData = String.Format("{0:X4}/{1:X2}=", wd.Value.WrestlerID4, wd.Value.WrestlerID2);
			outData += String.Format("{0:X2},{1:X4},{2:X4},{3:X8},{4:X8},{5:X8},{6:X2},{7:X2},{8:X2},{9:X2}",
				wd.Value.Unknown1,
				wd.Value.Unknown2,wd.Value.Unknown3,
				wd.Value.NamePointer,wd.Value.HeightPointer,wd.Value.WeightPointer,
				wd.Value.Unknown4,wd.Value.ManagerID2,wd.Value.Unknown5,wd.Value.Unknown6
			);

			return outData;
		}

		public string WriteData_WM2K(KeyValuePair<int, GameSpecific.WM2K.WrestlerDefinition> wd)
		{
			// ID4/ID2=namePointer,height,weight,movesetIndex,paramsIndex,theme,video,unknown,costumePointer1,costumePointer2,costumePointer3,costumePointer4
			string outData = String.Format("{0:X4}/{1:X2}=", wd.Value.WrestlerID4, wd.Value.WrestlerID2);
			outData += String.Format("{0:X8},{1:X4},{2:X4},{3:X4},{4:X4},{5:X2},{6:X2},{7:X4},{8:X8},{9:X8},{10:X8},{11:X8}",
				wd.Value.NamePointer,
				wd.Value.Height, wd.Value.Weight,
				wd.Value.MovesetFileIndex, wd.Value.ParamsFileIndex,
				wd.Value.ThemeSong, wd.Value.EntranceVideo,
				wd.Value.Unknown,
				wd.Value.CostumePointers[0],
				wd.Value.CostumePointers[1],
				wd.Value.CostumePointers[2],
				wd.Value.CostumePointers[3]
			);

			return outData;
		}

		public string WriteData_VPW2(KeyValuePair<int, GameSpecific.VPW2.WrestlerDefinition> wd)
		{
			// ID4/ID2=theme,namecall,height,weight,voiceA,voiceB,movesetIndex,paramsIndex,appearanceIndex,profileIndex
			string outData = String.Format("{0:X4}/{1:X2}=", wd.Value.WrestlerID4, wd.Value.WrestlerID2);
			outData += String.Format("{0:X2},{1:X2},{2:X2},{3:X2},{4:X2},{5:X2},{6:X4},{7:X4},{8:X4},{9:X4}",
				wd.Value.ThemeSong, wd.Value.NameCall,
				wd.Value.Height, wd.Value.Weight,
				wd.Value.Voice1, wd.Value.Voice2,
				wd.Value.MovesetFileIndex, wd.Value.ParamsFileIndex,
				wd.Value.AppearanceIndex, wd.Value.ProfileIndex
			);

			return outData;
		}

		public string WriteData_NoMercy(KeyValuePair<int, GameSpecific.NoMercy.WrestlerDefinition> wd)
		{
			// ID4/ID2=theme,video,height,unknown,weight,movesetIndex,paramsIndex,appearanceIndex,profileIndex
			string outData = String.Format("{0:X4}/{1:X2}=", wd.Value.WrestlerID4, wd.Value.WrestlerID2);
			outData += String.Format("{0:X2},{1:X2},{2:X2},{3:X2},{4:X4},{5:X4},{6:X4},{7:X4},{8:X4}",
				wd.Value.ThemeSong, wd.Value.EntranceVideo,
				wd.Value.Height, wd.Value.Unknown,
				wd.Value.Weight,
				wd.Value.MovesetFileIndex, wd.Value.ParamsFileIndex,
				wd.Value.AppearanceIndex, wd.Value.ProfileIndex
			);

			return outData;
		}
		#endregion
	}
}
