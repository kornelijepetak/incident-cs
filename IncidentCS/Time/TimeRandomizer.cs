using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace KornelijePetak.IncidentCS
{
	public class TimeRandomizer : ITimeRandomizer
	{
		private static DateTime unixEpoch = new DateTime(1970, 1, 1);
		private static IRandomWheel<Func<int>> dayWheel;
		private static int[] leapYears;

		public virtual string AmPm
		{
			get
			{
				return new[] { "am", "pm" }.ChooseAtRandom();
			}
		}

		public virtual DateTime Time(DateTime from, DateTime to)
		{
			return from.AddMilliseconds(
				Incident.Primitive.DoubleBetween(0, (to - from).TotalMilliseconds));
		}

		public virtual long Hammertime
		{
			get
			{
				return UnixTimestamp * 1000L + Millisecond;
			}
		}

		public virtual int UnixTimestamp
		{
			get
			{
				return (int)(Time(unixEpoch, DateTime.Now) - unixEpoch).TotalSeconds;
			}
		}

		public virtual int Hour
		{
			get
			{
				return Incident.Primitive.IntegerBetween(0, 24);
			}
		}

		public virtual int Minute
		{
			get
			{
				return Incident.Primitive.IntegerBetween(0, 60);
			}
		}

		public virtual int Second
		{
			get
			{
				return Incident.Primitive.IntegerBetween(0, 60);
			}
		}

		public virtual int Millisecond
		{
			get
			{
				return Incident.Primitive.IntegerBetween(0, 1000);
			}
		}

		public virtual int Day
		{
			get
			{
				if (dayWheel == null)
				{
					/* 
					 * Chance ratios are derived from a number of occurences in 4-year period (that includes leap years).
					 * This way, a date is randomized depending on the true chance of occurence.
					 * 
					 * 48*28 because all 48 months have days 1 through 28
					 * 45 because only 45 out of 48 months have 29 days
					 * 44 because only 44 out of 48 months have 30 days
					 * 28 because only 28 out of 48 months have 31 days (jan, mar, may, jul, aug, oct, dec over 4 years)
					*/
					dayWheel = Incident.Utils.CreateWheel<Func<int>>(new Dictionary<Func<int>, double>() { 
						{ () => Incident.Primitive.IntegerBetween(1, 29), 48 * 28 }, 
						{ () => 29, 45 },	
						{ () => 30, 44 },	
						{ () => 31, 28 },	
					});
				}

				return dayWheel.RandomElement();
			}
		}

		public virtual int Month
		{
			get
			{
				return Incident.Primitive.IntegerBetween(1, 13);
			}
		}

		public virtual int Year
		{
			get
			{
				return Incident.Primitive.IntegerBetween(DateTime.MinValue.Year, DateTime.MaxValue.Year);
			}
		}

		public virtual int LeapYear
		{
			get
			{
				lazyInitLeapYears();

				return leapYears.ChooseAtRandom();
			}
		}

		public virtual int CustomYear(int min, int max, bool onlyLeapYears = false)
		{
			lazyInitLeapYears();

			if (onlyLeapYears)
			{
				int left = leapYears.IndexOf(x => x >= min);
				int right = leapYears.LastIndexOf(x => x < max);

				if (left > right || left == -1 || right == -1)
					throw new ArgumentException("The constraints are too limited, there are no leap years in a given range.");

				var randomIndex = Incident.Primitive.IntegerBetween(left, right + 1);
				return leapYears[randomIndex];
			}
			else
			{
				return Incident.Primitive.IntegerBetween(min, max);
			}
		}

		private void lazyInitLeapYears()
		{
			if (leapYears == null)
			{
				leapYears =
					Enumerable.Range(DateTime.MinValue.Year, DateTime.MaxValue.Year)
					.Where(DateTime.IsLeapYear)
					.ToArray();

				Console.WriteLine(string.Join(" ", leapYears.Where(y => y > 1900 && y < 2450)));
			}
		}
	}
}
