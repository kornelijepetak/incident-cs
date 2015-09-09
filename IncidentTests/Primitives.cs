using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using KornelijePetak.IncidentCS;

namespace IncidentTests
{
	[TestClass]
	public class Primitives
	{
		/*
		 * This parameter must be at least 1E+8 in order for 
		 * distributions to approach satisfying uniformitys
		 */
		public const int DefaultTestIterationCount = 100000000;
		
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
			// Test distribution
			Test(() => Incident.Primitive.ByteBetween(15, 25) - 15, 10);
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

		[TestMethod]
		public void ShortDistribution()
		{
			Test(() => Incident.Primitive.Short + 32768, ushort.MaxValue + 1);
		}

		[TestMethod]
		public void PositiveShortDistribution()
		{
			Test(() => Incident.Primitive.PositiveShort, short.MaxValue + 1);
		}

		[TestMethod]
		public void UnsignedShortDistribution()
		{
			Test(() => Incident.Primitive.UnsignedShort, ushort.MaxValue + 1);
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
		public void FloatDistribution()
		{
			// TODO: Find a way to test the floats across the whole domain
		}

		[TestMethod]
		public void FloatUnitDistribution()
		{
			int bucketCount = 100000;
			Test(() => (int)(Incident.Primitive.FloatUnit * bucketCount), bucketCount);
		}

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

		public void Test(Func<int> nextRandomElement, int arraySize, int numberCount = DefaultTestIterationCount, double expectedPercentage = 5)
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
	}
}
