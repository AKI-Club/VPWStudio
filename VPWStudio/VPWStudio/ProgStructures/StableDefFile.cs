using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;

namespace VPWStudio
{
	/// <summary>
	/// Stable Definition File.
	/// </summary>
	public class StableDefFile
	{
		#region Members
		/// <summary>
		/// Game Type (defines what stable defs are read/written)
		/// </summary>
		public VPWGames GameType;

		#region Game-Specific
		/// <summary>
		/// WCW/nWo Revenge Stable Definitions
		/// </summary>
		public SortedList<int, GameSpecific.Revenge.StableDefinition> StableDefs_Revenge;

		/// <summary>
		/// WWF WrestleMania 2000 Stable Definitions
		/// </summary>
		public SortedList<int, GameSpecific.WM2K.StableDefinition> StableDefs_WM2K;

		/// <summary>
		/// Virtual Pro-Wrestling 2 Stable Definitions
		/// </summary>
		public SortedList<int, GameSpecific.VPW2.StableDefinition> StableDefs_VPW2;
		#endregion

		#endregion

		/// <summary>
		/// Generic constuctor.
		/// </summary>
		public StableDefFile()
		{
			GameType = VPWGames.Invalid;
		}

		/// <summary>
		/// Specific constructor.
		/// </summary>
		/// <param name="_game">Stable Definition data to expect.</param>
		public StableDefFile(VPWGames _game)
		{
			GameType = _game;
		}

		/// <summary>
		/// Check if this StableDefFile is compatible with a specific game.
		/// </summary>
		/// <param name="_gt">VPWGames value to check</param>
		/// <returns>True if the passed in value matches the StableDefFile's GameType.</returns>
		public bool IsGameType(VPWGames _gt)
		{
			return _gt == GameType;
		}

		#region Read Data
		/// <summary>
		/// Read StableDef file.
		/// </summary>
		/// <param name="sr">StreamReader with StableDef file loaded.</param>
		public void ReadFile(StreamReader sr)
		{
			// first line is GameType, which determines how the rest of the file is handled.
			GameType = (VPWGames)Enum.Parse(typeof(VPWGames), sr.ReadLine());

			switch (GameType)
			{
				case VPWGames.Revenge:
					{
						StableDefs_Revenge = new SortedList<int, GameSpecific.Revenge.StableDefinition>();
						while (!sr.EndOfStream)
						{
							string line = sr.ReadLine();
							if (!line.Equals(String.Empty))
							{
								GameSpecific.Revenge.StableDefinition sd = ReadData_Revenge(line, out int stableNum);
								StableDefs_Revenge.Add(stableNum, sd);
							}
						}
					}
					break;
				case VPWGames.WM2K:
					{
						StableDefs_WM2K = new SortedList<int, GameSpecific.WM2K.StableDefinition>();
						while (!sr.EndOfStream)
						{
							string line = sr.ReadLine();
							if (!line.Equals(String.Empty))
							{
								GameSpecific.WM2K.StableDefinition sd = ReadData_WM2K(line, out int stableNum);
								StableDefs_WM2K.Add(stableNum, sd);
							}
						}
					}
					break;
				case VPWGames.VPW2:
					{
						StableDefs_VPW2 = new SortedList<int, GameSpecific.VPW2.StableDefinition>();
						while (!sr.EndOfStream)
						{
							string line = sr.ReadLine();
							if (!line.Equals(String.Empty))
							{
								GameSpecific.VPW2.StableDefinition sd = ReadData_VPW2(line, out int stableNum);
								StableDefs_VPW2.Add(stableNum, sd);
							}
						}
					}
					break;
				default:
					StableDefs_Revenge = null;
					StableDefs_WM2K = null;
					StableDefs_VPW2 = null;
					break;
			}
		}

		/// <summary>
		/// Read data as WCW/nWo Revenge Stable Definition data.
		/// </summary>
		/// <param name="input">Input string to parse.</param>
		/// <param name="stableNum">(output) Stable number.</param>
		/// <returns>a WCW/nWo Revenge StableDefinition.</returns>
		public GameSpecific.Revenge.StableDefinition ReadData_Revenge(string input, out int stableNum)
		{
			GameSpecific.Revenge.StableDefinition sd = new GameSpecific.Revenge.StableDefinition();

			// Revenge line format:
			// #@P={wrespointers},graphicID
			// # - stable number
			// P - pointer to wrestler ID2s
			// {wrespointers} - list of pointers to wrestler data
			// graphicID - file ID of stable graphic

			string[] tokens = input.Split(new char[] { '@', '=' });
			// tokens[0] = stable num
			// tokens[1] = id2 pointer
			// tokens[2] = everything after '='; needs further parsing

			string[] data = tokens[2].Split(new char[] { '{', '}' });
			// data[0] = fuck all
			// data[1] = wrestlers ID2s
			// data[2] = ',' stable name ID

			string[] wresPointers = data[1].Split(',');

			stableNum = int.Parse(tokens[0]);
			sd.WrestlerPointerStart = UInt32.Parse(tokens[1], NumberStyles.HexNumber);
			sd.HeaderGraphicFile = UInt16.Parse(data[2].Substring(1), NumberStyles.HexNumber);

			// wrestler pointers
			sd.NumWrestlers = (ushort)wresPointers.Length;
			sd.WrestlerPointers = new uint[sd.NumWrestlers];
			for (int w = 0; w < wresPointers.Length; w++)
			{
				sd.WrestlerPointers[w] = uint.Parse(wresPointers[w], NumberStyles.HexNumber);
			}

			return sd;
		}

		/// <summary>
		/// Read data as WWF WrestleMania 2000 Stable Definition data.
		/// </summary>
		/// <param name="input">Input string to parse.</param>
		/// <param name="stableNum">(output) Stable number.</param>
		/// <returns>a WWF WrestleMania 2000 StableDefinition.</returns>
		public GameSpecific.WM2K.StableDefinition ReadData_WM2K(string input, out int stableNum)
		{
			GameSpecific.WM2K.StableDefinition sd = new GameSpecific.WM2K.StableDefinition();

			// WM2K line format:
			// #@P={wrestlers},namePointer
			// # - stable number
			// P - pointer to wrestler ID2s
			// {wrestlers} - list of wrestler ID2s, comma-separated
			// namePointer - pointer to stable name

			string[] tokens = input.Split(new char[] { '@', '=' });
			// tokens[0] = stable num
			// tokens[1] = id2 pointer
			// tokens[2] = everything after '='; needs further parsing

			string[] data = tokens[2].Split(new char[] { '{', '}' });
			// data[0] = fuck all
			// data[1] = wrestlers ID2s
			// data[2] = ',' stable name ID

			string[] id2 = data[1].Split(',');

			stableNum = int.Parse(tokens[0]);
			sd.WrestlerPointerStart = UInt32.Parse(tokens[1], NumberStyles.HexNumber);
			sd.StableNamePointer = UInt32.Parse(data[2].Substring(1), NumberStyles.HexNumber);

			// wrestlers
			sd.WrestlerID2s = new byte[id2.Length];
			sd.NumWrestlers = (byte)id2.Length;
			for (int w = 0; w < sd.WrestlerID2s.Length; w++)
			{
				sd.WrestlerID2s[w] = byte.Parse(id2[w], NumberStyles.HexNumber);
			}

			return sd;
		}

		/// <summary>
		/// Read data as Virtual Pro-Wrestling 2 Stable Definition data.
		/// </summary>
		/// <param name="input">Input string to parse.</param>
		/// <param name="stableNum">(output) Stable number.</param>
		/// <returns>a Virtual Pro-Wrestling 2 StableDefinition.</returns>
		public GameSpecific.VPW2.StableDefinition ReadData_VPW2(string input, out int stableNum)
		{
			GameSpecific.VPW2.StableDefinition sd = new GameSpecific.VPW2.StableDefinition();

			// VPW2 line format:
			// #@P={wrestlers},nameIndex
			// # - stable number
			// P - pointer to wrestler ID2s
			// {wrestlers} - list of wrestler ID2s, comma-separated
			// nameIndex - stable name index

			string[] tokens = input.Split(new char[] { '@', '=' });
			// tokens[0] = stable num
			// tokens[1] = id2 pointer
			// tokens[2] = everything after '='; needs further parsing

			string[] data = tokens[2].Split(new char[] { '{', '}' });
			// data[0] = fuck all
			// data[1] = wrestlers ID2s
			// data[2] = ',' stable name ID

			string[] id2 = data[1].Split(',');

			stableNum = int.Parse(tokens[0]);
			sd.WrestlerPointerStart = UInt32.Parse(tokens[1], NumberStyles.HexNumber);
			sd.StableNameIndex = UInt16.Parse(data[2].Substring(1), NumberStyles.HexNumber);

			// wrestlers
			sd.WrestlerID2s = new byte[id2.Length];
			for (int w = 0; w < sd.WrestlerID2s.Length; w++)
			{
				sd.WrestlerID2s[w] = byte.Parse(id2[w], NumberStyles.HexNumber);
			}

			return sd;
		}
		#endregion

		#region Write Data
		/// <summary>
		/// Write data to StableDef file.
		/// </summary>
		/// <param name="sw">StreamWriter with StableDef output file.</param>
		public void WriteFile(StreamWriter sw)
		{
			sw.WriteLine(GameType.ToString());

			switch (GameType)
			{
				case VPWGames.Revenge:
					foreach (KeyValuePair<int, GameSpecific.Revenge.StableDefinition> sd in StableDefs_Revenge)
					{
						sw.WriteLine(WriteData_Revenge(sd));
					}
					break;
				case VPWGames.WM2K:
					foreach (KeyValuePair<int, GameSpecific.WM2K.StableDefinition> sd in StableDefs_WM2K)
					{
						sw.WriteLine(WriteData_WM2K(sd));
					}
					break;
				case VPWGames.VPW2:
					foreach (KeyValuePair<int, GameSpecific.VPW2.StableDefinition> sd in StableDefs_VPW2)
					{
						sw.WriteLine(WriteData_VPW2(sd));
					}
					break;
			}

			sw.Flush();
		}

		public string WriteData_Revenge(KeyValuePair<int, GameSpecific.Revenge.StableDefinition> sd)
		{
			string outData = String.Format("{0}@{1:X8}={{", sd.Key, sd.Value.WrestlerPointerStart);

			// wrestlers
			for (int wres = 0; wres < sd.Value.WrestlerPointers.Length; wres++)
			{
				outData += String.Format("{0:X8}", sd.Value.WrestlerPointers[wres]);
				if (wres < sd.Value.WrestlerPointers.Length - 1)
				{
					outData += ',';
				}
			}

			// end wrestlers, stable graphic
			outData += String.Format("}},{0:X4}", sd.Value.HeaderGraphicFile);

			return outData;
		}

		public string WriteData_WM2K(KeyValuePair<int, GameSpecific.WM2K.StableDefinition> sd)
		{
			string outData = String.Format("{0}@{1:X8}={{", sd.Key, sd.Value.WrestlerPointerStart);

			// wrestlers
			for (int wres = 0; wres < sd.Value.WrestlerID2s.Length; wres++)
			{
				outData += String.Format("{0:X2}", sd.Value.WrestlerID2s[wres]);
				if (wres < sd.Value.WrestlerID2s.Length - 1)
				{
					outData += ',';
				}
			}

			// end wrestlers, text pointer
			outData += String.Format("}},{0:X8}", sd.Value.StableNamePointer);

			return outData;
		}

		public string WriteData_VPW2(KeyValuePair<int, GameSpecific.VPW2.StableDefinition> sd)
		{
			string outData = String.Format("{0}@{1:X8}={{", sd.Key, sd.Value.WrestlerPointerStart);

			// wrestlers
			for (int wres = 0; wres < sd.Value.WrestlerID2s.Length; wres++)
			{
				outData += String.Format("{0:X2}", sd.Value.WrestlerID2s[wres]);
				if (wres < sd.Value.WrestlerID2s.Length - 1)
				{
					outData += ',';
				}
			}

			// end wrestlers, text index
			outData += String.Format("}},{0:X4}",sd.Value.StableNameIndex);

			return outData;
		}
		#endregion
	}
}
