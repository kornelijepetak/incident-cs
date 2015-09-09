using System;
using System.Globalization;
using System.Linq;

namespace KornelijePetak.IncidentCS
{
	public static partial class Incident
	{
		private static CultureInfo culture;

		public static String Culture
		{
			get
			{
				if (culture == null)
					culture = CultureInfo.CurrentCulture;

				return culture.Name;
			}
			set
			{
				try
				{
					culture = new CultureInfo(value);
				}
				catch 
				{
					culture = null;
				}
			}
		}
	}
}
