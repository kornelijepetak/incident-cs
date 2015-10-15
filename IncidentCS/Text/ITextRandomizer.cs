using System;
using System.Collections.Generic;
using System.Linq;

namespace IncidentCS
{
	public interface ITextRandomizer
	{
		/// <summary>
		/// Returns a random consonant character
		/// Different cultures may define different consonants.
		/// </summary>
		char ConsonantCharacter { get; }

		/// <summary>
		/// Returns a random consonant
		/// Different cultures may define different consonants.
		/// </summary>
		string Consonant { get; }

		/// <summary>
		/// Returns a random vowel character
		/// Different cultures may define different vowel.
		/// </summary>
		char VowelCharacter { get; }

		/// <summary>
		/// Returns a random vowel 
		/// Different cultures may define different vowel.
		/// </summary>
		string Vowel { get; }

		/// <summary>
		/// Returns a random syllable 
		/// </summary>
		string Syllable { get; }

		/// <summary>
		/// Returns a random word 
		/// </summary>
		string Word { get; }

		/// <summary>
		/// Returns a random sentence
		/// </summary>
		string Sentence { get; }

		/// <summary>
		/// Returns a random paragraph
		/// </summary>
		string Paragraph { get; }
	}
}
