using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Text;

namespace IncidentCS
{
	internal class TextRandomizer : ITextRandomizer
	{
		private static IRandomWheel<int> wordSyllablesCountWheel;
		private static IRandomWheel<int> paragrapSentencesCountWheel;

		public virtual char ConsonantCharacter
		{
			get
			{
				return "bcdfghjklmnpqrstvwxyz".ChooseAtRandom();
			}
		}

		public virtual string Consonant
		{
			get
			{
				return ConsonantCharacter.ToString();
			}
		}

		public virtual char VowelCharacter
		{
			get
			{
				return "aeiou".ChooseAtRandom();
			}
		}

		public virtual string Vowel
		{
			get
			{
				return VowelCharacter.ToString();
			}
		}

		public virtual string Syllable
		{
			get
			{
				// Using 21/26 because there are 21 consonants in the english alphabet.
				// This way, every letter has the same chance of being chosen
				bool startsWithConsonant = Incident.Primitive.DoubleUnit < (21.0 / 26.0);

				if (startsWithConsonant)
				{
					return Consonant + Vowel + (Incident.Primitive.Boolean ? Consonant : string.Empty);
				}
				else
				{
					return Vowel + Consonant + (Incident.Primitive.Boolean ? Vowel : string.Empty);
				}
			}
		}

		public virtual string Word
		{
			get
			{
				if (wordSyllablesCountWheel == null)
				{
					// Words with fewer syllables should have higher chance to be selected
					wordSyllablesCountWheel = Incident.Utils.CreateWheel(
						new Dictionary<int, double> { { 1, 8 }, { 2, 5 }, { 3, 3 }, { 4, 2 }, });
				}

				return string.Join("",
					Enumerable.Range(0, wordSyllablesCountWheel.RandomElement)
					.Select(x => Syllable)
				);
			}
		}

		public string Sentence
		{
			get
			{
				StringBuilder builder = new StringBuilder();

				int numberOfWords = Incident.Primitive.IntegerBetween(2, 12);

				builder.Append(Word.Capitalize() + " ");

				for (int i = 0; i < numberOfWords; i++)
				{
					builder.Append(Word);

					if (i < numberOfWords - 1)
					{
						if (Incident.Primitive.DoubleUnit < 0.05)
							builder.Append(",");

						builder.Append(" ");
					}
				}

				builder.Append(new[] { ".", "!", "?" }.ChooseAtRandom());

				return builder.ToString();
			}
		}

		public string Paragraph
		{
			get
			{
				if (paragrapSentencesCountWheel == null)
				{
					// Paragraphs with fewer sentences should have higher chance to be selected
					paragrapSentencesCountWheel = Incident.Utils.CreateWheel(
						new Dictionary<int, double> { { 3, 3 }, { 4, 3 }, { 5, 2 }, { 6, 2 }, { 7, 1 }, { 8, 1 }, { 9, 1 } });
				}

				return string.Join(" ", Enumerable.Range(0, paragrapSentencesCountWheel.RandomElement).Select(_ => Sentence));
			}
		}
	}
}
