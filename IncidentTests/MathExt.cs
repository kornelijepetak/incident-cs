using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

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

		public static void Test(Func<int> nextRandomElement, int arraySize, int numberCount, double expectedPercentage = 5)
		{
			int[] counts = new int[arraySize];

			for (int i = 0; i < numberCount; i++)
			{
				var next = nextRandomElement();
				counts[next]++;
			}

			// Expect that standard deviation is less than expectedPercentage% of the expected bucket size
			Assert.IsTrue(counts.Validate(numberCount, expectedPercentage));
		}

		public static bool AlmostAs(this double value, double anotherValue, double precision = 0.000001)
		{
			return Math.Abs(value - anotherValue) < precision;
		}

		public static bool AlmostAs(this int value, int anotherValue, double precision = 0.000001)
		{
			return Math.Abs(value - anotherValue) < precision;
		}

	}
}
