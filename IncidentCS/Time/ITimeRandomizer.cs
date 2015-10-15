using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace IncidentCS
{
	public interface ITimeRandomizer
	{
		string AmPm { get; }

		DateTime Time(DateTime from, DateTime to);

		int UnixTimestamp { get; }
		long Hammertime { get; }

		int Hour { get; }
		int Minute { get; }
		int Second { get; }
		int Millisecond { get; }

		int Day { get; }
		int Month { get; }
		int Year { get; }
		int LeapYear { get; }

		int CustomYear(int min, int max, bool onlyLeapYears = false);
	}
}
