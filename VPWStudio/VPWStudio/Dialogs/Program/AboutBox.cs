using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Text;
using System.Windows.Forms;

namespace VPWStudio
{
	public partial class AboutBox : Form
	{
		/// <summary>
		/// AKI wrestling game hackers
		/// </summary>
		private List<String> SpecialThanks = new List<string>()
		{
			"WldFb",           // "the godhand of VPW hacking", as proclaimed by freem
			"Zoinkity",        // world's best N64 hacker (also as proclaimed by freem)
			"Tokidoim",        // he's the "Toki" in Toki1, Toki2, Toki3... among other things.
			"Kryogenics",      // many hacks and discoveries throughout the years
			"JamStubbs",       // created utilities and hosted an influential archive board
			"S.K. Stylez",     // AKI Club founder
			"DOOMSDAY EWF",    // found many values (textures)
			"The Pelican",     // also found many values
			"Keson",           // keeping the future alive with AKI Evo and new tools
			"jordyad",         // pushed me further when I needed it most, providing great info
			"randymanfoo",     // has provided a lot of No Mercy FileTable updates, among other things
			"Melonbread",      // new (circa 2020-2021) VPW2 findings
			"(and others I haven't gotten around to listing yet)"
		};

		/// <summary>
		/// freem greets
		/// </summary>
		private List<String> Greetings = new List<string>()
		{
			"the SSC",
			"the Multitap community",
			"Generation Hex",
			"Old Skool Reunion",
			"AKI Live",
			"RagDas",
			"WldFb",
			"Melly",
			"CurdleGames"
		};

		public AboutBox()
		{
			InitializeComponent();
			this.Text = String.Format("About {0}", AssemblyTitle);

			Stream stream = Assembly.GetExecutingAssembly().GetManifestResourceStream("VPWStudio.githash.txt");
			StreamReader reader = new StreamReader(stream);
			string gitHash = reader.ReadToEnd();
			stream = Assembly.GetExecutingAssembly().GetManifestResourceStream("VPWStudio.builddate.txt");
			reader = new StreamReader(stream);
			string buildDate = reader.ReadToEnd().Substring(0, 19);
			reader.Close();

			labelVersion.Text = String.Format(
				"{0} (indev) v{1} by freem\nbuilt on {2}; Git hash: {3}",
				AssemblyProduct,
				AssemblyVersion,
				buildDate,
				gitHash
			);

			StringBuilder sb = new StringBuilder();
			sb.AppendLine("This is an in-development version of VPW Studio.");
			sb.AppendLine("It is not meant to be used in 'production'; always make backups.");
			sb.AppendLine();
			sb.AppendLine("This program is only meant to be used by the VPW Studio testing group. As of August 2021, this includes:");
			sb.AppendLine();
			sb.AppendLine("- current \"AKI Wrestling Game Hacking\" Discord channel members");
			sb.AppendLine("- RagDas");
			sb.AppendLine("- GameGenie720");
			sb.AppendLine();
			sb.AppendLine("VPW Studio is largely untested and can ruin your data. User discretion is advised.");
			sb.AppendLine();

			sb.AppendLine("This tool is dedicated to the memory of Maximo.");
			sb.AppendLine();

			sb.AppendLine("There are a number of people whose work and research is integral in making this project possible.");
			sb.AppendLine();
			sb.AppendLine("In no particular order:");
			for (int i = 0; i < SpecialThanks.Count; i++)
			{
				sb.Append(SpecialThanks[i]);
				if (i < SpecialThanks.Count - 1)
				{
					sb.Append(", ");
				}
			}
			sb.AppendLine();
			sb.AppendLine();

			sb.AppendLine("freem sends greetings to:");
			for (int i = 0; i < Greetings.Count; i++)
			{
				sb.Append(Greetings[i]);
				if (i < Greetings.Count - 1)
				{
					sb.Append(", ");
				}
			}
			sb.AppendLine();
			sb.AppendLine();

			sb.AppendLine("This program uses the following libraries:");
			sb.AppendLine("- OpenTK (https://opentk.net/)");
			sb.AppendLine("- Be.HexBox (https://sourceforge.net/projects/hexbox/)");
			sb.AppendLine();

			tbInformation.Text = sb.ToString();
		}

		#region Assembly Attribute Accessors

		public string AssemblyTitle
		{
			get
			{
				object[] attributes = Assembly.GetExecutingAssembly().GetCustomAttributes(typeof(AssemblyTitleAttribute), false);
				if (attributes.Length > 0)
				{
					AssemblyTitleAttribute titleAttribute = (AssemblyTitleAttribute)attributes[0];
					if (titleAttribute.Title != "")
					{
						return titleAttribute.Title;
					}
				}
				return System.IO.Path.GetFileNameWithoutExtension(Assembly.GetExecutingAssembly().CodeBase);
			}
		}

		public string AssemblyVersion
		{
			get
			{
				return Assembly.GetExecutingAssembly().GetName().Version.ToString();
			}
		}

		public string AssemblyDescription
		{
			get
			{
				object[] attributes = Assembly.GetExecutingAssembly().GetCustomAttributes(typeof(AssemblyDescriptionAttribute), false);
				if (attributes.Length == 0)
				{
					return "";
				}
				return ((AssemblyDescriptionAttribute)attributes[0]).Description;
			}
		}

		public string AssemblyProduct
		{
			get
			{
				object[] attributes = Assembly.GetExecutingAssembly().GetCustomAttributes(typeof(AssemblyProductAttribute), false);
				if (attributes.Length == 0)
				{
					return "";
				}
				return ((AssemblyProductAttribute)attributes[0]).Product;
			}
		}
		#endregion

		private void linkLabelAJWorld_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
		{
			System.Diagnostics.Process.Start("https://vpw.ajworld.net/");
		}

		private void linkLabelGitHub_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
		{
			System.Diagnostics.Process.Start("https://github.com/AKI-Club/VPWStudio");
		}
	}
}
