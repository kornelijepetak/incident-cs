using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using KornelijePetak.IncidentCS;

namespace IncidentTests
{
	[TestClass]
	public class Primitives
	{
		/*
		 * This parameter must be at least 1E+8 in order for distributions to approach 
		 * satisfying uniformity. If the sample is too small, the standard deviation is 
		 * too large.
		 */
		private const int DefaultTestIterationCount = 100000000;

		#region Boolean

		[TestMethod]
		public void BooleanDistribution()
		{
			Test(() => Incident.Primitive.Boolean ? 1 : 0, 2);
		}

		#endregion

		#region Byte

		[TestMethod]
		public void ByteDistribution()
		{
			Test(() => Incident.Primitive.Byte, 256);
		}

		[TestMethod]
		public void ByteBetweenDistribution()
		{
			// Test different areas of distribution
			Test(() => Incident.Primitive.ByteBetween(15, 25) - 15, 10);
			Test(() => Incident.Primitive.ByteBetween(0, 5), 5);
			Test(() => Incident.Primitive.ByteBetween(200, 256) - 200, 56);
			Test(() => Incident.Primitive.ByteBetween(15, 15) - 15, 1);
		}

		[TestMethod]
		public void ByteBetweenOutOfInterval()
		{
			// Test that there are no numbers outside the interval
			for (int i = 0; i < DefaultTestIterationCount; i++)
			{
				var rnd = Incident.Primitive.ByteBetween(15, 25);
				Assert.IsTrue(15 <= rnd && rnd < 25);
			}
		}

		[TestMethod]
		[ExpectedException(typeof(ArgumentException))]
		public void ByteBetweenStartGreaterThanEnd()
		{
			Incident.Primitive.ByteBetween(25, 15);
		}

		[TestMethod]
		[ExpectedException(typeof(ArgumentOutOfRangeException))]
		public void ByteBetweenStartTooSmall()
		{
			Incident.Primitive.ByteBetween(-1, 0);
		}

		[TestMethod]
		[ExpectedException(typeof(ArgumentOutOfRangeException))]
		public void ByteBetweenEndTooBig()
		{
			Incident.Primitive.ByteBetween(0, 257);
		}

		#endregion

		#region Signed Byte

		[TestMethod]
		public void SignedByteDistribution()
		{
			Test(() => Incident.Primitive.SignedByte + 128, byte.MaxValue + 1);
		}

		[TestMethod]
		public void SignedByteBetweenOutOfInterval()
		{
			// Test that there are no numbers outside the interval
			for (int i = 0; i < DefaultTestIterationCount; i++)
			{
				var rnd = Incident.Primitive.SignedByteBetween(-15, 25);
				Assert.IsTrue(-15 <= rnd && rnd < 25);
			}
		}

		[TestMethod]
		public void SignedByteBetweenDistribution()
		{
			// Test different areas of distribution
			Test(() => Incident.Primitive.SignedByteBetween(15, 25) - 15, 10);
			Test(() => Incident.Primitive.SignedByteBetween(0, 5), 5);
			Test(() => Incident.Primitive.SignedByteBetween(125, 127) - 125, 2);
			Test(() => Incident.Primitive.SignedByteBetween(15, 15) - 15, 1);
			Test(() => Incident.Primitive.SignedByteBetween(-100, -90) + 100, 10);
			Test(() => Incident.Primitive.SignedByteBetween(-128, -127) + 128, 1);
		}

		[TestMethod]
		[ExpectedException(typeof(ArgumentException))]
		public void SignedByteBetweenStartGreaterThanEnd()
		{
			Incident.Primitive.SignedByteBetween(128, 0);
		}

		[TestMethod]
		[ExpectedException(typeof(ArgumentOutOfRangeException))]
		public void SignedByteBetweenStartTooSmall()
		{
			Incident.Primitive.SignedByteBetween(-129, 0);
		}

		[TestMethod]
		[ExpectedException(typeof(ArgumentOutOfRangeException))]
		public void SignedByteBetweenEndTooBig()
		{
			Incident.Primitive.SignedByteBetween(0, 129);
		}

		#endregion

		#region Short

		[TestMethod]
		public void ShortDistribution()
		{
			Test(() => Incident.Primitive.Short + short.MaxValue + 1, ushort.MaxValue + 1);
		}

		[TestMethod]
		public void PositiveShortDistribution()
		{
			Test(() => Incident.Primitive.PositiveShort, short.MaxValue + 1);
		}

		[TestMethod]
		public void ShortBetweenOutOfInterval()
		{
			// Test that there are no numbers outside the interval
			for (int i = 0; i < DefaultTestIterationCount; i++)
			{
				var rnd = Incident.Primitive.ShortBetween(-4500, 5000);
				Assert.IsTrue(-4500 <= rnd && rnd < 5000);
			}
		}

		[TestMethod]
		public void ShortBetweenDistribution()
		{
			// Test different areas of distribution
			Test(() => Incident.Primitive.ShortBetween(150, 250) - 150, 100);
			Test(() => Incident.Primitive.ShortBetween(0, 5), 5);
			Test(() => Incident.Primitive.ShortBetween(1250, 1252) - 1250, 2);
			Test(() => Incident.Primitive.ShortBetween(150, 150) - 150, 1);
			Test(() => Incident.Primitive.ShortBetween(-1000, -900) + 1000, 100);
			Test(() => Incident.Primitive.ShortBetween(-1280, -1270) + 1280, 10);
		}

		[TestMethod]
		[ExpectedException(typeof(ArgumentException))]
		public void ShortBetweenStartGreaterThanEnd()
		{
			Incident.Primitive.ShortBetween(4560, 2100);
		}

		[TestMethod]
		[ExpectedException(typeof(ArgumentOutOfRangeException))]
		public void ShortBetweenStartTooSmall()
		{
			Incident.Primitive.ShortBetween(-32769, 0);
		}

		[TestMethod]
		[ExpectedException(typeof(ArgumentOutOfRangeException))]
		public void ShortBetweenEndTooBig()
		{
			Incident.Primitive.ShortBetween(0, 32769);
		}

		#endregion

		#region Unsigned short

		[TestMethod]
		public void UnsignedShortDistribution()
		{
			Test(() => Incident.Primitive.UnsignedShort, ushort.MaxValue + 1);
		}

		[TestMethod]
		public void UnsignedShortBetweenOutOfInterval()
		{
			// Test that there are no numbers outside the interval
			for (int i = 0; i < DefaultTestIterationCount; i++)
			{
				var rnd = Incident.Primitive.UnsignedShortBetween(20000, 21000);
				Assert.IsTrue(20000 <= rnd && rnd < 21000);
			}
		}

		[TestMethod]
		public void UnsignedShortBetweenDistribution()
		{
			// Test different areas of distribution
			Test(() => Incident.Primitive.UnsignedShortBetween(65532, 65535) - 65532, 3);
			Test(() => Incident.Primitive.UnsignedShortBetween(0, 5), 5);
			Test(() => Incident.Primitive.UnsignedShortBetween(1250, 1252) - 1250, 2);
			Test(() => Incident.Primitive.UnsignedShortBetween(150, 150) - 150, 1);
		}

		[TestMethod]
		[ExpectedException(typeof(ArgumentException))]
		public void UnsignedShortBetweenStartGreaterThanEnd()
		{
			Incident.Primitive.UnsignedShortBetween(1000, 500);
		}

		[TestMethod]
		[ExpectedException(typeof(ArgumentOutOfRangeException))]
		public void UnsignedShortBetweenStartTooSmall()
		{
			Incident.Primitive.UnsignedShortBetween(-1, 0);
		}

		[TestMethod]
		[ExpectedException(typeof(ArgumentOutOfRangeException))]
		public void UnsignedShortBetweenEndTooBig()
		{
			Incident.Primitive.UnsignedShortBetween(0, 65537);
		}

		#endregion

		#region Integer

		[TestMethod]
		public void IntegerDistribution()
		{
			/* 
				Test runs a rather small number of iterations, so testing
				all buckets is infeasible. Instead, take a smaller number of
				buckets and distribute the randomized numbers into those.
			*/
			int bucketCount = 256;

			Test(() => (Incident.Primitive.Integer % bucketCount) + bucketCount - 1, 2 * bucketCount - 1);
		}

		[TestMethod]
		public void PositiveIntegerDistribution()
		{
			/* 
				Test runs a rather small number of iterations, so testing
				all buckets is infeasible. Instead, take a smaller number of
				buckets and distribute the randomized numbers into those.
			*/
			int bucketCount = 256;

			Test(() => (Incident.Primitive.PositiveInteger % bucketCount), bucketCount);
		}

		[TestMethod]
		public void IntegerBetweenOutOfInterval()
		{
			// Test that there are no numbers outside the interval
			for (int i = 0; i < DefaultTestIterationCount; i++)
			{
				var rnd = Incident.Primitive.IntegerBetween(10000000, 10000100);
				Assert.IsTrue(10000000 <= rnd && rnd < 10000100);
			}
		}

		[TestMethod]
		public void IntegerBetweenBetweenDistribution()
		{
			// Test different areas of distribution
			Test(() => Incident.Primitive.IntegerBetween(65532, 65535) - 65532, 3);
			Test(() => Incident.Primitive.IntegerBetween(0, 5), 5);
			Test(() => Incident.Primitive.IntegerBetween(125000, 125200) - 125000, 200);
			Test(() => Incident.Primitive.IntegerBetween(1500000, 1500100) - 1500000, 100);
			Test(() => Incident.Primitive.IntegerBetween(-15000, 15000) + 15000, 30000);
		}

		[TestMethod]
		[ExpectedException(typeof(ArgumentException))]
		public void IntegerBetweenStartGreaterThanEnd()
		{
			Incident.Primitive.IntegerBetween(500000, 400000);
		}

		#endregion

		#region Unsigned Integer

		[TestMethod]
		public void UnsignedIntegerDistribution()
		{
			/* 
				Test runs a rather small number of iterations, so testing
				all buckets is infeasible. Instead, take a smaller number of
				buckets and distribute the randomized numbers into those.
			*/
			int bucketCount = 256;

			Test(() => (int)(Incident.Primitive.UnsignedInteger % bucketCount), bucketCount);
		}

		[TestMethod]
		public void UnsignedIntegerBetweenOutOfInterval()
		{
			// Test that there are no numbers outside the interval
			for (int i = 0; i < DefaultTestIterationCount; i++)
			{
				var rnd = Incident.Primitive.IntegerBetween(10000000, 10000100);
				Assert.IsTrue(10000000 <= rnd && rnd < 10000100);
			}
		}

		[TestMethod]
		public void UnsignedIntegerBetweenBetweenDistribution()
		{
			// Test different areas of distribution
			Test(() => Incident.Primitive.IntegerBetween(65532, 65535) - 65532, 3);
			Test(() => Incident.Primitive.IntegerBetween(0, 5), 5);
			Test(() => Incident.Primitive.IntegerBetween(125000, 125200) - 125000, 200);
			Test(() => Incident.Primitive.IntegerBetween(1500000, 1500100) - 1500000, 100);
		}

		[TestMethod]
		[ExpectedException(typeof(ArgumentException))]
		public void UnsignedIntegerBetweenStartGreaterThanEnd()
		{
			Incident.Primitive.IntegerBetween(500000, 400000);
		}

		#endregion

		#region Float

		[TestMethod]
		public void FloatDistribution()
		{
			// TODO: Find a way to test the float distribution uniformity across the whole domain
		}

		[TestMethod]
		public void FloatUnitDistribution()
		{
			int bucketCount = 100000;
			Test(() => (int)(Incident.Primitive.FloatUnit * bucketCount), bucketCount);
		}

		[TestMethod]
		public void FloatBetweenOutOfInterval()
		{
			// Test that there are no numbers outside the interval
			for (int i = 0; i < DefaultTestIterationCount; i++)
			{
				var rnd = Incident.Primitive.FloatBetween(5.85f, 5.92f);
				Assert.IsTrue(5.85f <= rnd && rnd <= 5.92f);
			}
		}

		[TestMethod]
		public void FloatBetweenDistribution()
		{
			int bucketCount = 100000;

			Test(() =>
				getFloatRandomBucketFromRange(0.2f, 0.5f, Incident.Primitive.FloatBetween, bucketCount), bucketCount);

			Test(() =>
				getFloatRandomBucketFromRange(0.02f, 0.03f, Incident.Primitive.FloatBetween, bucketCount), bucketCount);

			Test(() =>
				getFloatRandomBucketFromRange(0.002f, 0.003f, Incident.Primitive.FloatBetween, bucketCount), bucketCount);
			
			Test(() =>
				getFloatRandomBucketFromRange(123456f, 1234567f, Incident.Primitive.FloatBetween, bucketCount), bucketCount);
		}

		[TestMethod]
		[ExpectedException(typeof(ArgumentException))]
		public void FloatBetweenStartGreaterThanEnd()
		{
			Incident.Primitive.FloatBetween(5.45f, 3.22f);
		}

		#endregion

		#region Double

		[TestMethod]
		public void DoubleDistribution()
		{
			// TODO: Find a way to test the doubles across the whole domain
		}

		[TestMethod]
		public void DoubleUnitDistribution()
		{
			int bucketCount = 100000;
			Test(() => (int)(Incident.Primitive.DoubleUnit * bucketCount), bucketCount);
		}

		[TestMethod]
		public void DoubleBetweenOutOfInterval()
		{
			// Test that there are no numbers outside the interval
			for (int i = 0; i < DefaultTestIterationCount; i++)
			{
				var rnd = Incident.Primitive.DoubleBetween(855.2, 912.88);
				Assert.IsTrue(855.2 <= rnd && rnd <= 912.88);
			}
		}

		[TestMethod]
		public void DoubleBetweenDistribution()
		{
			int bucketCount = 100000;

			Test(() =>
				getDoubleRandomBucketFromRange(0.02, 0.05, Incident.Primitive.DoubleBetween, bucketCount), bucketCount);

			Test(() =>
				getDoubleRandomBucketFromRange(0.002, 0.003, Incident.Primitive.DoubleBetween, bucketCount), bucketCount);

			Test(() =>
				getDoubleRandomBucketFromRange(0.0002, 0.0003, Incident.Primitive.DoubleBetween, bucketCount), bucketCount);

			Test(() =>
				getDoubleRandomBucketFromRange(12345600, 123456700, Incident.Primitive.DoubleBetween, bucketCount), bucketCount);
		}

		[TestMethod]
		[ExpectedException(typeof(ArgumentException))]
		public void DoubleBetweenStartGreaterThanEnd()
		{
			Incident.Primitive.DoubleBetween(75.245, 38.242);
		}

		#endregion

		#region Time

		[TestMethod]
		public void DateTimeUnitDistribution()
		{
			// Years distribution
			Test(() => Incident.Primitive.DateTime.Year, 10000);

			// Months distribution
			Test(() => Incident.Primitive.DateTime.Month - 1, 12);
			
			// Hours distribution
			Test(() => Incident.Primitive.DateTime.Hour, 24);

			// Minutes distribution
			Test(() => Incident.Primitive.DateTime.Minute, 60);

			// Seconds distribution
			Test(() => Incident.Primitive.DateTime.Second , 60);
		}

		[TestMethod]
		public void DateTimeBetweenOutOfInterval()
		{
			var lowerBound = new DateTime(2001, 1, 1);
			var upperBound = new DateTime(2005, 1, 1);

			// Test that there are no numbers outside the interval
			for (int i = 0; i < DefaultTestIterationCount; i++)
			{
				var rnd = Incident.Primitive.TimeBetween(lowerBound, upperBound);
				Assert.IsTrue(lowerBound <= rnd && rnd <= upperBound);
			}
		}

		[TestMethod]
		[ExpectedException(typeof(ArgumentException))]
		public void DateTimeBetweenStartGreaterThanEnd()
		{
			Incident.Primitive.TimeBetween(new DateTime(2005, 1, 1), new DateTime(2001, 1, 1));
		}

		#endregion

		protected void Test(Func<int> nextRandomElement, int arraySize, int numberCount = DefaultTestIterationCount, double expectedPercentage = 5)
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

		private int getFloatRandomBucketFromRange(float start, float end, Func<float, float, float> randomValueSelector, int bucketCount)
		{
			var rand = randomValueSelector(start, end);
			rand -= start;
			rand /= (end - start);
			rand *= bucketCount;
			return (int)rand;
		}

		private int getDoubleRandomBucketFromRange(double start, double end, Func<double, double, double> randomValueSelector, int bucketCount)
		{
			var rand = randomValueSelector(start, end);
			rand -= start;
			rand /= (end - start);
			rand *= bucketCount;
			return (int)rand;
		}
	}
}
