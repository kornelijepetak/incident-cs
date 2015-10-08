using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace KornelijePetak.IncidentCS
{
	internal class TextRandomizerEN : TextRandomizer
	{
		private static string[] englishWords;

		internal TextRandomizerEN()
		{
			if (englishWords == null)
				englishWords = "Localization.EN.Words.txt".LinesFromResource().ToArray();
		}

		public override string Word
		{
			get
			{
				return englishWords.ChooseAtRandom();
			}
		}

	}
}
