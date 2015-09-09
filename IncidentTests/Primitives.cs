using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using KornelijePetak.IncidentCS;

namespace IncidentTests
{
	[TestClass]
	public class Primitives
	{
		public const int DefaultTestIterationCount = 10000000;

		[TestMethod]
		public void BooleanDistribution()
		{
			Test(() => Incident.Primitive.Boolean ? 1 : 0, 2);
		}

		[TestMethod]
		public void ByteDistribution()
		{
			Test(() => Incident.Primitive.Byte, 256);
		}

		[TestMethod]
		public void ByteBetweenDistribution()
		{
			// Test distribution
			Test(() => Incident.Primitive.ByteBetween(15, 25) - 15, 10);

			// Test that there are no numbers outside the interval
			for (int i = 0; i < DefaultTestIterationCount; i++)
			{
				var rnd = Incident.Primitive.ByteBetween(15, 25);
				Assert.IsTrue(15 <= rnd && rnd < 25);
			}

			// Test inversion
			for (int i = 0; i < DefaultTestIterationCount; i++)
			{
				var rnd = Incident.Primitive.ByteBetween(25, 15);
				Assert.IsTrue(15 <= rnd && rnd < 25);
			}
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
		public void ByteBetweenInversion()
		{
			for (int i = 0; i < DefaultTestIterationCount; i++)
			{
				var rnd = Incident.Primitive.ByteBetween(25, 15);
				Assert.IsTrue(15 <= rnd && rnd < 25);
			}
		}

		[TestMethod]
		[ExpectedException(typeof(ArgumentOutOfRangeException))]
		public void ByteBetweenThrows()
		{
			Incident.Primitive.ByteBetween(256, 300);
		}

		[TestMethod]
		public void SignedByteDistribution()
		{
			Test(() => Incident.Primitive.SignedByte + 128, byte.MaxValue + 1);
		}

		[TestMethod]
		public void ShortDistribution()
		{
			Test(() => Incident.Primitive.Short + 32768, ushort.MaxValue + 1, 100000000);
		}

		[TestMethod]
		public void PositiveShortDistribution()
		{
			Test(() => Incident.Primitive.PositiveShort, short.MaxValue + 1, 100000000);
		}

		[TestMethod]
		public void UnsignedShortDistribution()
		{
			Test(() => Incident.Primitive.UnsignedShort, ushort.MaxValue + 1, 100000000);
		}

		[TestMethod]
		public void IntegerDistribution()
		{
			/* 
				Test runs a rather small number of iterations, so testing
				all buckets is infeasible. Instead, take a smaller number of
				buckets and distribute the randomized numbers into those.
			*/
			int bucketCount = 256;

			Test(() => (Incident.Primitive.Integer % bucketCount) + bucketCount - 1, 2 * bucketCount - 1, 100000000);
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

			Test(() => (Incident.Primitive.PositiveInteger % bucketCount), bucketCount, 100000000);
		}

		[TestMethod]
		public void UnsignedIntegerDistribution()
		{
			/* 
				Test runs a rather small number of iterations, so testing
				all buckets is infeasible. Instead, take a smaller number of
				buckets and distribute the randomized numbers into those.
			*/
			int bucketCount = 256;

			Test(() => (int)(Incident.Primitive.UnsignedInteger % bucketCount), bucketCount, 100000000);
		}

		public void Test(Func<int> nextRandomElement, int arraySize, int numberCount = DefaultTestIterationCount, double expectedPercentage = 5)
		{
			int[] counts = new int[arraySize];

			for (int i = 0; i < numberCount; i++)
				counts[nextRandomElement()]++;

			// Expect that standard deviation is less than expectedPercentage% of the expected bucket size
			Assert.IsTrue(counts.Validate(numberCount, expectedPercentage));
		}
	}
}
