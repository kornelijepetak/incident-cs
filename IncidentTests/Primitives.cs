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

		public void Test(Func<int> nextRandomElement, int arraySize, int numberCount = DefaultTestIterationCount, double expectedPercentage = 1)
		{
			int[] counts = new int[arraySize];

			for (int i = 0; i < numberCount; i++)
				counts[nextRandomElement()]++;

			// Expect that standard deviation is smaller than expectedPercentage% of the expected bucket size
			Assert.IsTrue(counts.Validate(numberCount, expectedPercentage));
		}
	}
}
