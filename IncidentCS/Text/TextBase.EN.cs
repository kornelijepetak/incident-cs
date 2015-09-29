using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace KornelijePetak.IncidentCS
{
	public class TextRandomizerEN : TextRandomizerBase
	{
		private string[] englishWords;

		internal TextRandomizerEN()
		{
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
