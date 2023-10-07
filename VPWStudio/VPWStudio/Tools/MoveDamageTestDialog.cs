using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VPWStudio
{
	public partial class MoveDamageTestDialog : Form
	{
		#region ugly hardcoded tables
		/// <summary>
		/// Per-wrestler Move Damage File IDs in WCW vs. nWo - World Tour.
		/// </summary>
		private Dictionary<int, string> MoveDamageFiles_WorldTour = new Dictionary<int, string>()
		{
			// ID4 00xx - nWo
			{ 0x0177, "(0001/01) Hulk Hogan" },
			// 0002/02 is nWo Sting, which re-uses regular Sting's data
			{ 0x0103, "(0003/03) Buff Bagwell" },
			{ 0x00F7, "(0004/04) Eric Bischoff" },
			{ 0x01CF, "(0005/05) Scott Norton" },
			{ 0x0193, "(0006/06) Kevin Nash" },
			{ 0x0153, "(0007/07) Scott Hall" },
			{ 0x021F, "(0008/08) Syxx" },
			{ 0x0203, "(0009/09) Randy Savage" },

			// ID4 01xx - WCW
			{ 0x01AF, "(0101/0A) Lex Luger" },
			{ 0x0217, "(0102/0B) Sting, nWo Sting" },
			{ 0x0147, "(0103/0C) Giant" },
			{ 0x0207, "(0104/0D) Scott Steiner" },
			{ 0x01E7, "(0105/0E) Rick Steiner" },
			{ 0x0127, "(0106/0F) Ric Flair" },
			{ 0x011B, "(0107/10) Ultimo Dragon" },
			{ 0x01B7, "(0108/11) Dean Malenko" },
			{ 0x00FB, "(0109/12) Eddy Guerrero" },
			{ 0x01CB, "(010A/13) Rey Mysterio Jr." },
			{ 0x010B, "(010B/14) Chris Benoit" },
			{ 0x01AB, "(010C/15) Steven Regal" },
			{ 0x010F, "(010D/16) DDP" },

			// ID4 02xx - DOA
			{ 0x023B, "(0201/17) Sumo Jo" },
			{ 0x0263, "(0202/18) Kim Chee" },
			{ 0x014B, "(0203/19) Blackheart" },
			{ 0x01DB, "(0204/1A) Puchteca" },
			{ 0x016B, "(0205/1B) Hannibal" },
			{ 0x013F, "(0206/1C) Powder Keg" },
			{ 0x0143, "(0207/1D) Dim Sum" },
			{ 0x0107, "(0208/1E) Saladin" },
			{ 0x020F, "(0209/1F) Ali Baba" },
			{ 0x0167, "(020A/20) Wrath" },

			// ID4 03xx - IU
			{ 0x01FF, "(0301/21) Black Ninja" },
			{ 0x017F, "(0302/22) Shaolin" },
			{ 0x0113, "(0303/23) The Unknown" },
			{ 0x014F, "(0304/24) The Claw" },
			{ 0x0223, "(0305/25) Black Belt" },
			{ 0x024F, "(0306/26) PacoLoco" },
			{ 0x022B, "(0307/27) Shaman" },
			{ 0x0133, "(0308/28) Master Fuji" },
			{ 0x015F, "(0309/29) Glacier" },

			// ID4 04xx, 05xx - WWW
			{ 0x00EF, "(0401/2A) Joe Bruiser" },
			{ 0x024B, "(0501/2B) BlackWidow" },

			// early VPW64 data
			{ 0x00DF, "Johnny Ace" },
			{ 0x00E3, "Jun Akiyama" },
			{ 0x00E7, "Andre the Giant" },
			{ 0x00EB, "?" },
			{ 0x00F3, "Giant Baba" },
			{ 0x00FF, "?" },
			{ 0x0117, "The Destroyer?" },
			{ 0x011F, "Dory Funk Jr.?" },
			{ 0x0123, "Dos Caras?" },
			{ 0x012B, "?" },
			{ 0x012F, "?" },
			{ 0x0137, "?" },
			{ 0x013B, "?" },
			{ 0x0157, "Volk Han?" },
			{ 0x015B, "Stan Hansen?" },
			{ 0x0163, "Shin'ya Hashimoto?" },
			{ 0x016F, "?" },
			{ 0x0173, "?" },
			{ 0x017B, "Antonio Inoki?" },
			{ 0x0183, "?" },
			{ 0x0187, "?" },
			{ 0x018B, "?" },
			{ 0x018F, "?" },
			{ 0x0197, "?" },
			{ 0x019B, "?" },
			{ 0x019F, "?" },
			{ 0x01A3, "?" },
			{ 0x01A7, "?" },
			{ 0x01B3, "?" },
			{ 0x01BB, "?" },
			{ 0x01BF, "?" },
			{ 0x01C3, "?" },
			{ 0x01C7, "?" },
			{ 0x01D3, "?" },
			{ 0x01D7, "?" },
			{ 0x01DF, "?" },
			{ 0x01E3, "?" },
			{ 0x01EB, "?" },
			{ 0x01EF, "?" },
			{ 0x01F3, "?" },
			{ 0x01F7, "?" },
			{ 0x01FB, "?" },
			{ 0x020B, "?" },
			{ 0x0213, "?" },
			{ 0x021B, "?" },
			{ 0x0227, "?" },
			{ 0x022F, "?" },
			{ 0x0233, "?" },
			{ 0x0237, "?" },
			{ 0x023F, "?" },
			{ 0x0243, "?" },
			{ 0x0247, "?" },
			{ 0x0253, "?" },
			{ 0x0257, "?" },
			{ 0x025B, "?" },
			{ 0x025F, "?" },
			{ 0x0267, "?" },
		};

		/// <summary>
		/// Per-wrestler Move Damage File IDs in Virtual Pro-Wrestling 64.
		/// </summary>
		private Dictionary<int, string> MoveDamageFiles_VPW64 = new Dictionary<int, string>()
		{
			// ID4 00xx - NSW
			{ 0x01FE, "(0001/01) Riki Choshu" },
			{ 0x0136, "(0002/02) Kensuke Sasaki" },
			{ 0x00D6, "(0003/03) Tatsumi Fujinami" },
			{ 0x014E, "(0004/04) Shiro Koshinaka" },
			{ 0x010A, "(0005/05) Shin'ya Hashimoto" },
			{ 0x011A, "(0006/06) Junji Hirata" },
			{ 0x016E, "(0007/07) Keiji Mutoh" },
			{ 0x020E, "(0008/08) Kazuo Yamazaki" },
			{ 0x0202, "(0009/09) Masahiro Chono" },
			{ 0x01E6, "(000A/0A) Hiroyoshi Tenzan" },
			{ 0x0192, "(000B/0B) Jyushin Liger" },
			{ 0x01A2, "(000C/0C) El Samurai" },
			{ 0x0186, "(000D/0D) Shinjiro Ohtani" },
			{ 0x00A2, "(000E/0E) Eddy Guerrero" },

			// ID4 01xx - EWF
			{ 0x0132, "(0101/0F) Toshiaki Kawada" },
			{ 0x01DE, "(0102/10) Akira Taue" },
			{ 0x0166, "(0103/11) Mitsuharu Misawa" },
			{ 0x008A, "(0104/12) Jun Akiyama" },
			{ 0x0146, "(0105/13) Kenta Kobashi" },
			{ 0x0106, "(0106/14) Hiroshi Hase" },
			{ 0x01FA, "(0107/15) Jumbo Tsuruta" },
			{ 0x00E2, "(0108/16) Masanobu Fuchi" },
			{ 0x0102, "(0109/17) Stan Hansen" },
			{ 0x017A, "(010A/18) Gary Albright" },
			{ 0x020A, "(010B/19) Steve Williams" },
			{ 0x0086, "(010C/1A) Johnny Ace" },

			// ID4 02xx - WOU
			{ 0x01CE, "(0201/1B) Nobuhiko Takada" },
			{ 0x012A, "(0202/1C) Masahito Kakihara" },
			{ 0x0092, "(0203/1D) Yoji Anjoh" },
			{ 0x01D6, "(0204/1E) Yoshihiro Takayama" },
			{ 0x015A, "(0205/1F) Akira Maeda" },
			{ 0x01DA, "(0206/20) Kiyoshi Tamura" },
			{ 0x00FE, "(0207/21) Volk Han" },
			{ 0x00D2, "(0208/22) Dick Vrij" },
			{ 0x00DE, "(0209/23) Masakatsu Funaki" },
			{ 0x01C2, "(020A/24) Minoru Suzuki" },
			{ 0x01B2, "(020B/25) Ken Shamrock" },
			{ 0x019A, "(020C/26) Bas Rutten" },

			// ID4 03xx - DAW
			{ 0x01E2, "(0301/27) Gen'ichiro Tenryu" },
			{ 0x00C2, "(0302/28) Ultimo Dragon" },
			{ 0x0142, "(0303/29) Koji Kitao" },
			{ 0x00F2, "(0304/2A) Tarzan Goto" },
			{ 0x0182, "(0305/2B) Atsushi Onita" },
			{ 0x0112, "(0306/2C) Hayabusa" },
			{ 0x00E6, "(0307/2D) Kodo Fuyuki" },
			{ 0x00EA, "(0308/2E) Gedo" },
			{ 0x00AE, "(0309/2F) Abdullah the Butcher" },
			{ 0x01B6, "(030A/30) Tiger Jeet Singh" },

			// ID4 04xx - Local Pro-Wrestling
			{ 0x01A6, "(0401/31) Great Sasuke" },
			{ 0x0126, "(0402/32) Jinsei Shinzaki" },
			{ 0x00BA, "(0403/33) Super Delfin" },
			{ 0x00F6, "(0404/34) Gran Naniwa" },
			{ 0x01CA, "(0405/35) TAKA Michinoku" },
			{ 0x01F6, "(0406/36) Dick Togo" },
			{ 0x01D2, "(0407/37) Shunji Tanako" },
			{ 0x00DA, "(0408/38) Yoshiaki Fujiwara" },

			// ID4 05xx - MWA
			{ 0x011E, "(0501/39) Hollywood Hogan" },
			{ 0x01BE, "(0502/3A) Sting" },
			{ 0x0206, "(0503/3B) Vader" },
			{ 0x00CE, "(0504/3C) Ric Flair" },
			{ 0x018E, "(0505/3D) Rick Steiner" },
			{ 0x01AE, "(0506/3E) Scott Steiner" },
			{ 0x010E, "(0507/3F) Road Warriors" },
			{ 0x0176, "(0508/40) Scott Norton" },

			// ID4 06xx - Legends
			{ 0x0122, "(0601/41) Antonio Inoki" },
			{ 0x019E, "(0602/42) Seiji Sakaguchi" },
			{ 0x009A, "(0603/43) Giant Baba" },
			{ 0x00A6, "(0604/44) Bruiser Brody" },
			{ 0x0116, "(0605/45) Rickson Gracie" },
			{ 0x01BA, "(0606/46) Maurice Smith" },
			{ 0x01EA, "(0607/47) Terry Funk" },
			{ 0x00C6, "(0608/48) Dory Funk Jr." },
			{ 0x01EE, "(0609/49) Tiger Mask" },
			{ 0x013E, "(060A/4A) Dynamite Kid" },
			{ 0x0162, "(060B/4B) Mil Mascaras" },
			{ 0x00CA, "(060C/4C) Dos Caras" },
			{ 0x0196, "(060D/4D) Rikidozan" },
			{ 0x00BE, "(060E/4E) The Destroyer" },
			{ 0x008E, "(060F/4F) Andre the Giant" },
			{ 0x01F2, "(0610/50) Manami Toyota" },

			// ID4 07xx - originally intended for Z button characters
			// ID4 values 0703, 0704, 0706, 0707, 0709, 070B, 070C all belong to unfinished characters.
			// No wrestler data seems to be available other than heads and default costumes.
			{ 0x018A, "(0701/51) Power Warrior" },
			{ 0x016A, "(0702/52) Great Muta" },
			{ 0x012E, "(0705/53) Koji Kanemoto" },
			{ 0x00B2, "(0708/54) Chris Benoit" },
			{ 0x017E, "(070A/55) Naoya Ogawa" },
			{ 0x0096, "(070D/56) Muhammad Ali" },
			{ 0x014A, "(070E/57) Kuniaki Kobayashi" },

			// ID4 08xx - WCW, nWo (wrestlers not already in VPW64 pre-license)
			{ 0x0156, "(0801/58) Lex Luger" },
			{ 0x00EE, "(0802/59) Giant" },
			{ 0x00B6, "(0803/5A) DDP" },
			{ 0x0152, "(0804/5B) Steven Regal" },
			{ 0x015E, "(0805/5C) Dean Malenko" },
			{ 0x0172, "(0806/5D) Rey Mysterio Jr." },
			{ 0x009E, "(0807/5E) Eric Bischoff" },
			{ 0x013A, "(0808/5F) Kevin Nash" },
			{ 0x00FA, "(0809/60) Scott Hall" },
			{ 0x00AA, "(080A/61) Buff Bagwell" },
			{ 0x01AA, "(080B/62) Randy Savage" },
			{ 0x01C6, "(080C/63) Syxx" },
		};

		/// <summary>
		/// Per-wrestler Move Damage File IDs in WCW/nWo Revenge.
		/// </summary>
		private Dictionary<int, string> MoveDamageFiles_Revenge = new Dictionary<int, string>()
		{
			// ID4 00xx - WCW 1
			{ 0x01F8, "(0001/01) Sting" },
			{ 0x0168, "(0002/02) Giant" },
			{ 0x01AA, "(0003/03) Lex Luger" },
			{ 0x0150, "(0004/04) DDP" },
			{ 0x01DD, "(0005/05) Rick Steiner" },
			{ 0x01D1, "(0007/06) Roddy Piper" },
			{ 0x0144, "(0008/07) Bret Hart" },
			{ 0x0138, "(0009/08) Chris Benoit" },
			{ 0x016E, "(000A/09) Goldberg" },
			{ 0x0141, "(000B/0A) Booker T" },
			{ 0x0156, "(000C/0B) Disco Inferno" },

			// ID4 01xx - WCW 2
			{ 0x0162, "(0101/0C) Fit Finley" },
			{ 0x01B0, "(0105/0D) Meng" },
			{ 0x0135, "(0106/0E) Barbarian" },
			{ 0x020D, "(0107/0F) Larry Zbysko" },
			{ 0x01F5, "(0108/10) Stevie Ray" },
			{ 0x014A, "(010B/11) British Bulldog" },
			{ 0x01BC, "(010D/12) Yuji Nagata" },
			{ 0x01C2, "(010E/13) Jim Neidhart" },
			{ 0x012C, "(010F/14) Alex Wright" },

			// ID4 02xx - nWo
			{ 0x0180, "(0201/15) Hollywood Hogan" },
			{ 0x01EC, "(0202/16) Randy Savage" },
			{ 0x01BF, "(0203/17) Kevin Nash" },
			{ 0x0174, "(0204/18) Scott Hall" },
			{ 0x012F, "(0205/19) Buff Bagwell" },
			{ 0x01EF, "(0206/1A) Scott Steiner" },
			{ 0x017D, "(0207/1B) Curt Hennig" },
			{ 0x01A1, "(0208/1C) Konnan" },
			{ 0x01C5, "(0209/1D) Scott Norton" },
			{ 0x01C8, "(ID4 020A?) ?" },
			{ 0x0147, "(020C/1E) Brian Adams" },
			{ 0x013B, "(020D/1F) Eric Bischoff" },

			// ID4 03xx - Cruiserweights, mostly
			{ 0x0159, "(0301/20) Ultimo Dragon" },
			{ 0x015C, "(0302/21) Eddy Guerrero" },
			{ 0x0186, "(0303/22) Chris Jericho" },
			{ 0x01B9, "(0304/23) Rey Mysterio Jr." },
			{ 0x018F, "(0305/24) Juventud Guerrera" },
			{ 0x01AD, "(0306/25) Dean Malenko" },
			{ 0x014D, "(0307/26) Chavo Guerrero" },
			{ 0x01A4, "(0308/27) La Parka" },
			{ 0x01D4, "(0309/28) Psychosis" },

			// ID4 04xx - "Blood Runs Cold" angle
			{ 0x016B, "(0401/29) Glacier" },
			{ 0x020A, "(0403/2A) Wrath" },
			{ 0x01B6, "(0404/2B) Kanyon" },

			// ID4 05xx - The Flock
			{ 0x01D7, "(0501/2C) Raven" },
			{ 0x01E9, "(0502/2D) Saturn" },
			{ 0x0195, "(0503/2E) Kidman" },
			{ 0x01E0, "(0504/2F) Riggs" },
			{ 0x0177, "(0505/30) Van Hammer" },
			{ 0x01F2, "(0506/31) Sick Boy" },
			{ 0x01A7, "(0507/32) Lodi" },
			{ 0x01DA, "(0508/33) Reese" },

			// ID4 06xx - EWF
			{ 0x01B3, "(0601/34) AKI man" },
			{ 0x0192, "(0602/35) Shogun" },
			{ 0x019E, "(0603/36) Executioner" },
			{ 0x018C, "(0604/37) Dr. Frank" },
			{ 0x0204, "(0605/38) Jekel" },
			{ 0x01FB, "(0606/39) Maya Inca Boy" },

			// ID4 07xx - DAW
			{ 0x01FE, "(0701/3A) Hawk Hana" },
			{ 0x019B, "(0702/3B) Kim Chee" },
			{ 0x01CB, "(0703/3C) Dake Ken" },
			{ 0x0165, "(0704/3D) Brickowski" },
			{ 0x0171, "(0705/3E) Ming Chee" },
			{ 0x017A, "(0706/3F) Han Zo Mon" },

			// ID4 08xx, 09xx - Managers
			{ 0x013E, "(0801/40) Eric Bischoff (Manager)" },
			{ 0x01CE, "(0802/41) Sonny Onoo (Manager)" },
			{ 0x0189, "(0803/42) Jimmy Hart (Manager)" },
			{ 0x01E6, "(0804/43) Rick Rude (Manager)" },
			{ 0x01E3, "(0805/44) Dusty Rhodes (Manager)" },
			{ 0x0153, "(0806/45) Ted Debisas (Manager)" },
			{ 0x0132, "(0807/46) James Bandenberg (Manager)" },
			{ 0x0201, "(0808/47) Vincent (Manager)" },

			{ 0x015F, "(0901/48) Elizabeth (Manager)" },
			{ 0x0198, "(0902/49) Kimberly (Manager)" },
			{ 0x0183, "(0903/4A) Jackreen (Manager)" },
			{ 0x0207, "(0905/4C) Woman (Manager)" },			
		};
		#endregion

		private enum DamageParamBodyTypes
		{
			Head = 0,
			Body,
			Arms,
			Legs,
			Flying
		};

		private SortedList<int, MoveDamageEntry> MoveDamageEntries = new SortedList<int, MoveDamageEntry>();

		/// <summary>
		/// Length of Move Damage data per game.
		/// </summary>
		private Dictionary<VPWGames, int> MoveDamageDataLength = new Dictionary<VPWGames, int>()
		{
			{ VPWGames.WorldTour, 24 },
			{ VPWGames.VPW64, 24 },
			{ VPWGames.Revenge, 24 },

			{ VPWGames.WM2K, 32 },
			{ VPWGames.VPW2, 32 },

			{ VPWGames.NoMercy, 36 }
		};

		public MoveDamageTestDialog()
		{
			InitializeComponent();

			// depends on game type
			if (Program.CurrentProject.Settings.BaseGame >= VPWGames.WM2K)
			{
				// remove and disable unnecessary controls
				lblWrestler.Visible = false;
				cbWrestler.Enabled = false;
				cbWrestler.Visible = false;
				tlpSelection.Controls.Remove(lblWrestler);
				tlpSelection.Controls.Remove(cbWrestler);

				// ugly hacks to make the dialog less ugly (ironic?)
				tlpSelection.SetRow(cbMoveDamageEntries, 0);
				tlpSelection.SetRow(lblMove, 0);
				tlpSelection.RowCount = 1;
				tlpSelection.Height = (int)(tlpSelection.Height*0.5f);
				tbOutput.Top -= 32;
				tbOutput.Height += 32;

				LoadDamageData();
				PopulateMoveDamageEntries();
				cbMoveDamageEntries.SelectedIndex = 0;
			}
			else
			{
				// populate the wrestler dropdown and go from there
				cbWrestler.BeginUpdate();

				switch (Program.CurrentProject.Settings.BaseGame)
				{
					case VPWGames.WorldTour:
						foreach (KeyValuePair<int,string> entry in MoveDamageFiles_WorldTour)
						{
							cbWrestler.Items.Add(string.Format("{0:X4} {1}", entry.Key, entry.Value));
						}
						break;

					case VPWGames.VPW64:
						foreach (KeyValuePair<int, string> entry in MoveDamageFiles_VPW64)
						{
							cbWrestler.Items.Add(string.Format("{0:X4} {1}", entry.Key, entry.Value));
						}
						break;

					case VPWGames.Revenge:
						foreach (KeyValuePair<int, string> entry in MoveDamageFiles_Revenge)
						{
							cbWrestler.Items.Add(string.Format("{0:X4} {1}", entry.Key, entry.Value));
						}
						break;
				}

				cbWrestler.EndUpdate();
				cbWrestler.SelectedIndex = 0;
			}
		}

		/// <summary>
		/// Load move damage data.
		/// </summary>
		/// /// <param name="fileID">File ID to read move damage values from. Only used for Revenge and earlier.</param>
		private void LoadDamageData(int fileID = -1)
		{
			MemoryStream romStream = new MemoryStream(Program.CurrentInputROM.Data);
			BinaryReader romReader = new BinaryReader(romStream);

			MemoryStream extractStream = new MemoryStream();
			BinaryWriter extractWriter = new BinaryWriter(extractStream);

			if (fileID == -1)
			{
				fileID = DefaultGameData.DefaultFileTableIDs["MoveDamageFileID"][Program.CurrentProject.Settings.GameType];
			}
			int dataLength = MoveDamageDataLength[Program.CurrentProject.Settings.BaseGame];

			Program.CurrentProject.ProjectFileTable.ExtractFile(romReader, extractWriter, fileID);
			romReader.Close();

			int fileSize = (int)extractStream.Position;
			extractStream.Seek(0, SeekOrigin.Begin);
			int numEntries = fileSize / dataLength;

			if (fileID != -1)
			{
				MoveDamageEntries.Clear();
			}

			BinaryReader br = new BinaryReader(extractStream);
			for (int i = 0; i < numEntries; i++)
			{
				MoveDamageEntries.Add(i, new MoveDamageEntry(br, dataLength));
			}
			br.Close();
		}

		private void PopulateMoveDamageEntries()
		{
			cbMoveDamageEntries.Items.Clear();
			cbMoveDamageEntries.BeginUpdate();
			foreach (KeyValuePair<int, MoveDamageEntry> mde in MoveDamageEntries)
			{
				cbMoveDamageEntries.Items.Add(String.Format("{0:X4}", mde.Key));
			}
			cbMoveDamageEntries.EndUpdate();
		}

		private void cbMoveDamageEntries_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (cbMoveDamageEntries.SelectedIndex < 0)
			{
				return;
			}

			ShowData(cbMoveDamageEntries.SelectedIndex);
		}

		private void ShowData(int index)
		{
			switch (Program.CurrentProject.Settings.BaseGame)
			{
				case VPWGames.WorldTour:
				case VPWGames.VPW64:
				case VPWGames.Revenge:
					ShowData_Early(index);
					break;

				case VPWGames.WM2K:
				case VPWGames.VPW2:
					ShowData_VPW2(index);
					break;

				case VPWGames.NoMercy:
					ShowData_NoMercy(index);
					break;
			}
		}

		/// <summary>
		/// Display Damage Information for moves from Revenge and earlier.
		/// </summary>
		/// <param name="index">MoveDamageEntries index to get data for.</param>
		private void ShowData_Early(int index)
		{
			MoveDamageEntry mde = MoveDamageEntries[index];
			StringBuilder sb = new StringBuilder();

			// todo: figure it out
			for (int i = 0; i < mde.DataLength; i++)
			{
				sb.AppendLine(string.Format("+0x{0:X2}: 0x{1:X2}", i, mde.Data[i]));
			}
			tbOutput.Text = sb.ToString();
		}

		/// <summary>
		/// Display Damage Information for moves from WM2000 and VPW2.
		/// </summary>
		/// <param name="index">MoveDamageEntries index to get data for.</param>
		private void ShowData_VPW2(int index)
		{
			MoveDamageEntry mde = MoveDamageEntries[index];
			StringBuilder sb = new StringBuilder();

			// A4AE0
			sb.AppendLine(String.Format("+0x00: 0x{0:X2}{1:X2}", mde.Data[0], mde.Data[1]));
			// A4AE2
			sb.AppendLine(String.Format("+0x02: Flying Move Target Body Part 0x{0:X2}{1:X2}", mde.Data[2], mde.Data[3]));
			// A4AE4(Link)
			sb.AppendLine(String.Format("+0x04: Link 0x{0:X2}{1:X2}", mde.Data[4], mde.Data[5]));
			// A4AE6(Damage / Spirit Gained)
			sb.AppendLine(String.Format("+0x06: Damage 0x{0:X2}", mde.Data[6]));
			sb.AppendLine(String.Format("+0x07: Spirit Gain 0x{0:X2}", mde.Data[7]));
			// A4AE8(Spirit Drained / Blood)
			sb.AppendLine(String.Format("+0x08: Spirit Drain 0x{0:X2} ({1})", mde.Data[8], (sbyte)mde.Data[8]));
			sb.AppendLine(String.Format("+0x09: Blood Chance 0x{0:X2}", mde.Data[9]));
			// A4AEA(KO / Off.Parameter)
			sb.AppendLine(String.Format("+0x0A: KO Chance 0x{0:X2}", mde.Data[10]));
			sb.AppendLine(String.Format("+0x0B: Offensive Param. 0x{0:X2} ({1})", mde.Data[11], Enum.GetName(typeof(DamageParamBodyTypes), mde.Data[11])));
			// A4AEC(Def.Parameter / Attack With)
			sb.AppendLine(String.Format("+0x0C: Defensive Param. 0x{0:X2} ({1})", mde.Data[12], Enum.GetName(typeof(DamageParamBodyTypes), mde.Data[12])));
			sb.AppendLine(String.Format("+0x0D: Attack With 0x{0:X2}", mde.Data[13]));
			// A4AEE
			sb.AppendLine(String.Format("+0x0E: (more body part target) 0x{0:X2}", mde.Data[14]));
			sb.AppendLine(String.Format("+0x0F: (more body part target) 0x{0:X2}", mde.Data[15]));
			// A4AF0(Attack to /)
			sb.AppendLine(String.Format("+0x10: Attack To 0x{0:X2}", mde.Data[16]));
			sb.AppendLine(String.Format("+0x11: Strike Reaction 1? 0x{0:X2}", mde.Data[17]));
			// A4AF2(Head Damage / Body Damage)
			sb.AppendLine(String.Format("+0x12: Head Damage 0x{0:X2}", mde.Data[18]));
			sb.AppendLine(String.Format("+0x13: Body Damage 0x{0:X2}", mde.Data[19]));
			// A4AF4(Arm Damage / Leg Damage)
			sb.AppendLine(String.Format("+0x14: Arm Damage 0x{0:X2}", mde.Data[20]));
			sb.AppendLine(String.Format("+0x15: Leg Damage 0x{0:X2}", mde.Data[21]));
			// A4AF6(Speed Damage / Sell)
			sb.AppendLine(String.Format("+0x16: Speed/Flying Damage 0x{0:X2}", mde.Data[22]));
			sb.AppendLine(String.Format("+0x17: Strike Reaction 2? 0x{0:X2}", mde.Data[23]));
			// A4AF8
			sb.AppendLine(String.Format("+0x18: Missed Attack Spirit Drain 0x{0:X2}", mde.Data[24]));
			sb.AppendLine(String.Format("+0x19: 0x{0:X2}", mde.Data[25]));
			// A4AFA / ?
			sb.AppendLine(String.Format("+0x1A: 0x{0:X2}", mde.Data[26]));
			sb.AppendLine(String.Format("+0x1B: unused?? 0x{0:X2}", mde.Data[27]));
			// A4AFC
			sb.AppendLine(String.Format("+0x1C: 0x{0:X2}{1:X2}{2:X2}{3:X2}", mde.Data[28], mde.Data[29], mde.Data[30], mde.Data[31]));

			tbOutput.Text = sb.ToString();
		}

		/// <summary>
		/// Display Damage Information for moves from WWF No Mercy.
		/// </summary>
		/// <param name="index">MoveDamageEntries index to get data for.</param>
		private void ShowData_NoMercy(int index)
		{
			MoveDamageEntry mde = MoveDamageEntries[index];
			StringBuilder sb = new StringBuilder();

			// mostly like VPW2 but with new entries
			sb.AppendLine(String.Format("+0x00: 0x{0:X2}{1:X2}", mde.Data[0], mde.Data[1]));
			sb.AppendLine(String.Format("+0x02: Flying Move Target Body Part 0x{0:X2}{1:X2}", mde.Data[2], mde.Data[3]));
			sb.AppendLine(String.Format("+0x04: Link 0x{0:X2}{1:X2}", mde.Data[4], mde.Data[5]));
			sb.AppendLine(String.Format("+0x06: Damage 0x{0:X2}", mde.Data[6]));
			sb.AppendLine(String.Format("+0x07: Spirit Gain 0x{0:X2}", mde.Data[7]));
			sb.AppendLine(String.Format("+0x08: Spirit Drain 0x{0:X2} ({1})", mde.Data[8], (sbyte)mde.Data[8]));
			sb.AppendLine(String.Format("+0x09: Blood Chance 0x{0:X2}", mde.Data[9]));
			sb.AppendLine(String.Format("+0x0A: KO Chance 0x{0:X2}", mde.Data[10]));
			sb.AppendLine(String.Format("+0x0B: Offensive Param. 0x{0:X2} ({1})", mde.Data[11], Enum.GetName(typeof(DamageParamBodyTypes), mde.Data[11])));
			sb.AppendLine(String.Format("+0x0C: Defensive Param. 0x{0:X2} ({1})", mde.Data[12], Enum.GetName(typeof(DamageParamBodyTypes), mde.Data[12])));
			sb.AppendLine(String.Format("+0x0D: Attack With 0x{0:X2}", mde.Data[13]));
			sb.AppendLine(String.Format("+0x0E: 0x{0:X2}", mde.Data[14]));
			sb.AppendLine(String.Format("+0x0F: 0x{0:X2}", mde.Data[15]));
			sb.AppendLine(String.Format("+0x10: Attack To 0x{0:X2}", mde.Data[16]));
			sb.AppendLine(String.Format("+0x11: 0x{0:X2}", mde.Data[17]));
			sb.AppendLine(String.Format("+0x12: Head Damage 0x{0:X2}", mde.Data[18]));
			sb.AppendLine(String.Format("+0x13: Body Damage 0x{0:X2}", mde.Data[19]));
			sb.AppendLine(String.Format("+0x14: Arm Damage 0x{0:X2}", mde.Data[20]));
			sb.AppendLine(String.Format("+0x15: Leg Damage 0x{0:X2}", mde.Data[21]));
			sb.AppendLine(String.Format("+0x16: Speed/Flying Damage 0x{0:X2}", mde.Data[22]));
			sb.AppendLine(String.Format("+0x17: Strike Reaction 0x{0:X2}", mde.Data[23]));
			sb.AppendLine(String.Format("+0x18: 0x{0:X2}", mde.Data[24]));
			sb.AppendLine(String.Format("+0x19: 0x{0:X2}", mde.Data[25]));
			sb.AppendLine(String.Format("+0x1A: 0x{0:X2}", mde.Data[26]));
			sb.AppendLine(String.Format("+0x1B: Special Damage 0x{0:X2}", mde.Data[27]));
			sb.AppendLine(String.Format("+0x1C: Previous Move 0x{0:X2}", mde.Data[28]));
			sb.AppendLine(String.Format("+0x1D: 0x{0:X2}", mde.Data[29]));
			sb.AppendLine(String.Format("+0x1E: 0x{0:X2}", mde.Data[30]));
			sb.AppendLine(String.Format("+0x1F: 0x{0:X2}", mde.Data[31]));
			sb.AppendLine(String.Format("+0x20: Move Type 0x{0:X2}", mde.Data[32]));
			sb.AppendLine(String.Format("+0x21: Additional Properties 0x{0:X2}", mde.Data[33]));
			sb.AppendLine(String.Format("+0x22: 0x{0:X2}", mde.Data[34]));
			sb.AppendLine(String.Format("+0x23: 0x{0:X2}", mde.Data[35]));

			tbOutput.Text = sb.ToString();
		}

		private void MoveDamageTestDialog_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Escape)
			{
				Close();
			}
		}

		private void cbWrestler_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (cbWrestler.SelectedIndex < 0)
			{
				return;
			}

			// switch move damage file based on new input
			LoadDamageData(int.Parse(cbWrestler.SelectedItem.ToString().Substring(0, 4), NumberStyles.HexNumber));
			PopulateMoveDamageEntries();
			tbOutput.Clear();
			cbMoveDamageEntries.SelectedItem = 0;
		}
	}

	public class MoveDamageEntry
	{
		public byte[] Data;
		public int DataLength;

		public MoveDamageEntry(BinaryReader br, int dataLength)
		{
			DataLength = dataLength;
			ReadEntry(br);
		}

		public void ReadEntry(BinaryReader br)
		{
			Data = br.ReadBytes(DataLength);
		}
	}
}
