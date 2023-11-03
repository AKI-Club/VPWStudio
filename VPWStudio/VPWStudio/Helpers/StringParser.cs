using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace VPWStudio.Helpers
{
	/// <summary>
	/// A text string grouped with a color code.
	/// </summary>
	public class StringSpan
	{
		#region Class Members
		/// <summary>
		/// Text to be displayed in this span.
		/// </summary>
		public string Text;

		/// <summary>
		/// Color code for displaying text (see "FontColors" in DataStructures/AKI/AkiFont.cs)
		/// </summary>
		public char ColorCode = 'D';
		#endregion

		#region Constructors
		/// <summary>
		/// Create a StringSpan using the default text color.
		/// </summary>
		/// <param name="text">Text in this StringSpan.</param>
		public StringSpan(string text)
		{
			Text = text;
		}

		/// <summary>
		/// Create a StringSpan using a specific text color.
		/// </summary>
		/// <param name="text">Text in this StringSpan.</param>
		/// <param name="color">Color code for this text.</param>
		public StringSpan(string text, char color)
		{
			Text = text;
			ColorCode = color;
		}
		#endregion
	}

	/// <summary>
	/// Handles parsing strings, focusing on the various control codes.
	/// </summary>
	/// This does NOT handle name strings from WM2K and earlier; see Helpers/NameHandler.cs for that.
	/// Also, needing to deal with different text encodings is a pain.
	public static class StringParser
	{
		/// <summary>
		/// Possible string parsing "modes".
		/// </summary>
		public enum ParseMode
		{
			/// <summary>
			/// Standard text, no need to handle control codes.
			/// </summary>
			Normal,

			/// <summary>
			/// Starting character '@'. Following character represents a color.
			/// </summary>
			Color,

			/// <summary>
			/// Starting character '%'. Next three characters represent a wrestler ID4 (0xxx).
			/// </summary>
			Wrestler,

			/// <summary>
			/// Starting character '$'. Next character represents a controller button/input.
			/// </summary>
			Controller,

			/// <summary>
			/// Starting character '#'. next character is alphanumeric, related to spacing.
			/// </summary>
			/// 1-9 followed by A-Z, supposedly.
			Spacing
		};

		public static List<StringSpan> Parse(string text)
		{
			List<StringSpan> spans = new List<StringSpan>();
			ParseMode CurParseMode = ParseMode.Normal;
			int wresDigitCount = 0;
			string wresID4 = string.Empty;
			text.Normalize();
			Console.WriteLine(string.Format("Input:\n{0}",text));

			foreach (char c in text.ToCharArray())
			{
				if (CurParseMode != ParseMode.Normal)
				{
					switch (CurParseMode) {
						case ParseMode.Color:
							// read one character
							Console.WriteLine("found color code '{0}'", c);
							CurParseMode = ParseMode.Normal;
							break;

						case ParseMode.Wrestler:
							// read 3 characters
							wresID4 += c;
							++wresDigitCount;
							if (wresDigitCount == 3)
							{
								Console.WriteLine("found wrestler ID4 0x0{0}",wresID4);
								CurParseMode = ParseMode.Normal;
								wresDigitCount = 0;
							}
							break;

						case ParseMode.Controller:
							// read one character
							Console.WriteLine("found controller button code '{0}'", c);
							CurParseMode = ParseMode.Normal;
							break;

						case ParseMode.Spacing:
							// read one character
							Console.WriteLine("found spacing code '{0}'", c);
							CurParseMode = ParseMode.Normal;
							break;
					}
				}
				else
				{
					// standard parsing
					if (c == '@')
					{
						CurParseMode = ParseMode.Color;
					}
					else if (c == '%')
					{
						CurParseMode = ParseMode.Wrestler;
						wresDigitCount = 0;
						wresID4 = string.Empty;
					}
					else if (c == '$')
					{
						CurParseMode = ParseMode.Controller;
					}
					else if (c == '#')
					{
						CurParseMode = ParseMode.Spacing;
					}
					else
					{
						// well that's normal isn't it
					}
				}

				
			}


			return spans;
		}
	}
}
