using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VPWStudio
{
	/// <summary>
	/// Handles "encoded" names, used from World Tour to WrestleMania 2000.
	/// </summary>
	/// todo: VPW64 may need to handle strings as EUC-JP
	public class NameHandler
	{
		/// <summary>
		/// Parse mode for decoding names.
		/// </summary>
		private enum ParseMode
		{
			/// <summary>
			/// output as-is (long name only)
			/// </summary>
			Normal,
			/// <summary>
			/// output between &lt;&gt; chars (short and long name)
			/// </summary>
			ShortLong,
			/// <summary>
			/// output between {} chars (short name only)
			/// </summary>
			ShortOnly
		}

		/// <summary>
		/// Encode a long and short name into a full name.
		/// </summary>
		/// <param name="_long">Long name to encode.</param>
		/// <param name="_short">Short name to encode.</param>
		/// <returns>Encoded name.</returns>
		public static string EncodeName(string _long, string _short)
		{
			string result = String.Empty;

			// this is a lot tricker than decoding.
			// general idea: search for the longest substring of the short name within the long name.

			// the easiest case is when the short name is found within the long name
			if (_long.Contains(_short))
			{
				// well gee we have it easy, don't we
				// <John> Cena (short name "John"), or John <Cena> (short name "Cena")

				// figure out where the short name is within the long name
				if (_long.StartsWith(_short))
				{
					// well that's even EASIER.
					result = String.Format("<{0}>{1}", _short, _long.Substring(_short.Length));
				}
				else
				{
					// need to do some work, but not as bad as the other case below...
					int shortPos = _long.IndexOf(_short);
					result = string.Format("{0}<{1}>", _long.Substring(0, shortPos), _long.Substring(shortPos));
				}
			}
			else
			{
				// a bit more work on our hands.

				// sometimes, the short name is a hack of the long name
				// * "<R>ick{.}< Steiner>"; long = "Rick Steiner", short = "R. Steiner"
				// * "<S>tevie{.}< Ray>"; long = "Stevie Ray", short = "S. Ray"
				// * "<M>aya <I>nca <B>oy"; long = "Maya Inca Boy", short = "MIB" (human intervention version: "Maya Inca Boy{MIB}" uses one less byte)

				// sometimes, the short and long names differ so much, they can't be reconciled.
				// Some examples:
				// * "Diamond Dallas Page{DDP}" (human intervention version: "<D>iamond <D>allas <P>age" uses more bytes)
				// * "Konnan{K-Dawg}" (human intervention version: "<K>onnan{-Dawg}" uses more bytes)
				// * "Juventud Guerrera{Juvi}" (human intervention version: "<Juv>entud Guerrera{i}" uses one less byte)
				result = String.Format("{0}{{{1}}}", _long, _short);
			}

			return result;
		}

		/// <summary>
		/// Decode a wrestler name string into long and short names.
		/// </summary>
		/// <param name="_in">Input name string</param>
		/// <returns>String array with long (index 0) and short (index 1) names.</returns>
		public static string[] DecodeName(string _in)
		{
			string[] result = new string[2];
			ParseMode CurParseMode = ParseMode.Normal;

			bool ignore = false;
			foreach (char c in _in.ToCharArray())
			{
				if (c.Equals('<'))
				{
					CurParseMode = ParseMode.ShortLong;
					ignore = true;
				}
				if (c.Equals('{'))
				{
					CurParseMode = ParseMode.ShortOnly;
					ignore = true;
				}

				if (c.Equals('>') || c.Equals('}'))
				{
					CurParseMode = ParseMode.Normal;
					ignore = true;
				}

				if (!ignore)
				{
					switch (CurParseMode)
					{
						case ParseMode.ShortLong:
							result[1] += c;
							result[0] += c;
							break;
						case ParseMode.ShortOnly:
							result[1] += c;
							break;
						case ParseMode.Normal:
						default:
							result[0] += c;
							break;
					}
				}
				ignore = false; // reset
			}

			return result;
		}
	}
}
