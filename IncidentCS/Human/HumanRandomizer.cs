using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace KornelijePetak.IncidentCS
{
	internal class HumanRandomizer : IHumanRandomizer
	{
		public int Age(HumanAgeCategory ageCategory = HumanAgeCategory.Adult)
		{
			switch (ageCategory)
			{
				case HumanAgeCategory.Any:
					return Incident.Primitive.IntegerBetween(1, 101);
				case HumanAgeCategory.Child:
					return Incident.Primitive.IntegerBetween(1, 13);
				case HumanAgeCategory.Teen:
					return Incident.Primitive.IntegerBetween(13, 20);
				case HumanAgeCategory.Senior:
					return Incident.Primitive.IntegerBetween(65, 101);
				default:
					// Adult is default
					return Incident.Primitive.IntegerBetween(18, 66);
			}
		}

		public DateTime Birthday(HumanAgeCategory ageCategory = HumanAgeCategory.Adult)
		{
			var newDate = new DateTime(DateTime.Now.Year - Age(ageCategory), 1, 1);

			var daysInYear = DateTime.IsLeapYear(newDate.Year) ? 366 : 365;

			return newDate.AddDays(Incident.Primitive.IntegerBetween(0, daysInYear)).Date;
		}

		private String[] firstNames = null;
		private String[] lastNames = null;

		public string FirstName
		{
			get
			{
				if (firstNames == null)
					firstNames = "Localization.FirstNames.txt".LinesFromResource().ToArray();

				return firstNames.ChooseAtRandom();
			}
		}

		public string LastName
		{
			get
			{
				if (lastNames == null)
					lastNames = "Localization.LastNames.txt".LinesFromResource().ToArray();

				return lastNames.ChooseAtRandom();
			}
		}

		public string FullName
		{
			get
			{
				return string.Format("{0} {1}", FirstName, LastName);
			}
		}

		public string GenderString
		{
			get
			{
				return Gender.ToString();
			}
		}

		public HumanGender Gender
		{
			get
			{
				return
					Incident.Primitive.Boolean
					? HumanGender.Male
					: HumanGender.Female;
			}
		}

		public string Prefix(bool shortPrefix = true, HumanGender gender = HumanGender.Unspecified)
		{
			List<string> prefixes = new List<string>();

			if (shortPrefix)
			{
				prefixes.Add("Dr.");

				if (gender == HumanGender.Unspecified || gender == HumanGender.Male)
					prefixes.Add("Mr.");

				if (gender == HumanGender.Unspecified || gender == HumanGender.Female)
					prefixes.AddRange(new[] { "Miss.", "Mrs." });
			}
			else
			{
				prefixes.Add("Doctor");

				if (gender == HumanGender.Unspecified || gender == HumanGender.Male)
					prefixes.Add("Mister");

				if (gender == HumanGender.Unspecified || gender == HumanGender.Female)
					prefixes.AddRange(new[] { "Missis", "Miss" });
			}

			return prefixes.ChooseAtRandom();
		}

		private string[] shortSuffixes = null;
		private string[] longSuffixes = null;

		public string Suffix(bool shortSuffix = true)
		{
			if (shortSuffix)
			{
				if (shortSuffixes == null)
					shortSuffixes = "Localization.ShortSuffixes.txt".LinesFromResource().ToArray();

				return shortSuffixes.ChooseAtRandom();
			}
			else
			{
				if (longSuffixes == null)
					longSuffixes = "Localization.LongSuffixes.txt".LinesFromResource().ToArray();

				return longSuffixes.ChooseAtRandom();
			}
		}
	}
}
