﻿using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace KornelijePetak.IncidentCS
{
	public class TextRandomizerBase
	{

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
				// One-syllable words have higher chance to be selected
				int[] syllableCountChancePool = new[] { 1, 1, 1, 1, 1, 1, 1, 1, 2, 2, 2, 2, 3, 3, 4 };
				int syllableCount = syllableCountChancePool.ChooseAtRandom();

				IEnumerable<string> syllables = Enumerable.Range(0, syllableCount).Select(x => Syllable);
				return string.Join("", syllables);
			}
		}

	}
}