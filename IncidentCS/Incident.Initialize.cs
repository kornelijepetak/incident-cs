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
		public static IWebRandomizer Web { get; private set; }
		public static IUtilsRandomizer Utils { get; private set; }
		public static IGamesRandomizer Games { get; private set; }
		public static IBusinessRandomizer Business { get; private set; }
		public static ITimeRandomizer Time { get; private set; }

		static Incident()
		{
			Rand = new Random();

			Primitive = new PrimitiveRandomizer();
			Text = new TextRandomizer();
			Human = new HumanRandomizer();
			Web = new WebRandomizer();
			Utils = new UtilsRandomizer();
			Games = new GamesRandomizer();
			Business = new BusinessRandomizer();
			Time = new TimeRandomizer();

			setupLocalizedRandomizers();
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
