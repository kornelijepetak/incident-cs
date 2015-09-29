using System;
using System.Collections.Generic;
using System.Linq;

namespace KornelijePetak.IncidentCS
{
	public interface ITextRandomizer
	{
		char ConsonantCharacter { get; }
		string Consonant { get; }
		char VowelCharacter { get; }
		string Vowel { get; }
		string Syllable { get; }
		string Word { get; }
	}
}
