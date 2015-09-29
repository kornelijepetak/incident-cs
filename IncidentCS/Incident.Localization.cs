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
				setupConcreteRandomizers();
			}
		}

		private static void setupConcreteRandomizers()
		{
			setupDefaultRandomizers();

			var langCode = Culture.TwoLetterISOLanguageName.ToUpper();
			var cultureName = Culture.Name;

			if (langCode.StartsWith("en"))
			{
				Text = new TextRandomizerEN();
			}
		}

		private static void setupDefaultRandomizers()
		{
			Primitive = new PrimitiveRandomizerBase();
			Text = new TextRandomizerBase();
		}
	}
}
