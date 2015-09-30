using System;
using System.Linq;

namespace KornelijePetak.IncidentCS
{
	public static partial class Incident
	{
		internal static Random Rand { get; private set; }

		public static IPrimitiveRandomizer Primitive { get; private set; }
		public static ITextRandomizer Text { get; private set; }
		public static IHumanRandomizer Human { get; private set; }

		static Incident()
		{
			Rand = new Random();
			setupConcreteRandomizers();
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
