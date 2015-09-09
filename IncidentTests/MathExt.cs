using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IncidentTests
{
	public static class MathExt
	{
		public static double StdDev(this int[] values)
		{
			var mean = values.Average();

			var variance = values
				.Select(x => Math.Pow(mean - x, 2))
				.Average();

			return Math.Sqrt(variance);
		}

		public static bool Validate(this int[] values, int numbers, double upperBoundForStdDev)
		{
			var stdDev = values.StdDev();

			// Normalize percentage
			upperBoundForStdDev /= 100.0;

			var expectedCountInBucket = 1.0 * numbers / values.Length;

			var relativeStdDev = stdDev / expectedCountInBucket;

			return relativeStdDev < upperBoundForStdDev;
		}

	}
}
