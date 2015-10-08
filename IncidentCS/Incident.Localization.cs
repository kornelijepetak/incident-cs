using System;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Reflection;

namespace KornelijePetak.IncidentCS
{
	public static partial class Incident
	{
		private static CultureInfo culture;

		public static CultureInfo Culture
		{
			get
			{
				if (culture == null)
					Culture = CultureInfo.CurrentCulture;

				return culture;
			}
			set
			{
				culture = value;
				setupLocalizedRandomizers();
			}
		}

		private static void setupLocalizedRandomizers()
		{
			var langCode = Culture.TwoLetterISOLanguageName.ToUpper();
			var cultureName = Culture.Name;

			if (langCode == "EN")
			{
				Text = new TextRandomizerEN();
			}
		}

	}
}
