using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace KornelijePetak.IncidentCS
{
	public static partial class Incident
	{
		public static class Text
		{
			static Text()
			{
				englishWords = "Lang.EN.Words.txt".LinesFromResource().ToArray();
			}

			public static char ConsonantCharacter
			{
				get
				{
					return "bcdfghjklmnpqrstvwxyz".ChooseAtRandom();
				}
			}

			public static string Consonant
			{
				get
				{
					return ConsonantCharacter.ToString();
				}
			}

			public static char VowelCharacter
			{
				get
				{
					return "aeiou".ChooseAtRandom();
				}
			}

			public static string Vowel
			{
				get
				{
					return VowelCharacter.ToString();
				}
			}

			public static string Syllable
			{
				get
				{
					// Using 21/26 because there are 21 consonants in the english alphabet.
					// This way, every letter has the same chance of being chosen
					bool startsWithConsonant = Primitive.DoubleUnit < (21.0 / 26.0);

					if (startsWithConsonant)
					{
						return Consonant + Vowel + (Primitive.Boolean ? Consonant : string.Empty);
					}
					else
					{
						return Vowel + Consonant + (Primitive.Boolean ? Vowel : string.Empty);
					}
				}
			}

			public static string Word
			{
				get
				{
					if (Culture.StartsWith("en"))
					{
						return englishWords.ChooseAtRandom();
					}
					else
					{
						// One-syllable words have higher chance to be selected
						int[] syllableCountChancePool = new[] { 1, 1, 1, 1, 1, 1, 1, 1, 2, 2, 2, 2, 3, 3, 4 };
						int syllableCount = syllableCountChancePool.ChooseAtRandom();

						IEnumerable<string> syllables = Enumerable.Range(0, syllableCount).Select(x => Syllable);
						return string.Join("", syllables);
					}
				}
			}
			public static string[] englishWords;
		}
	}
}
