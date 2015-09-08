using System;
using System.Linq;

namespace KornelijePetak.IncidentCS
{
	public static partial class Incident
	{
		internal static Random Rand { get; private set; }

		static Incident()
		{
			Rand = new Random();
		}

		public static int Seed
		{
			set
			{
				Rand = new Random(value);
			}
		}
	}
}
