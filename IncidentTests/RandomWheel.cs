using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using IncidentCS;
using System.Collections.Generic;
using IncidentCS.RandomWheel;

namespace IncidentTests
{
	[TestClass]
	public class RandomWheel
	{
		/*
		 * This parameter must be at least 1E+8 in order for distributions to approach 
		 * satisfying uniformity. If the sample is too small, the standard deviation is 
		 * too large. Note that with 1E+8 tests can take up to 10 minutes.
		 */
		private const int DefaultTestIterationCount = 100000000;

		private Dictionary<int, double> NewDictionary
		{
			get
			{
				return new Dictionary<int, double>() { { 1, 0.1 }, { 2, 0.2 }, { 3, 0.3 }, { 4, 0.4 } };
			}
		}

		[TestMethod]
		public void CreateWheelCorrectlyCreates()
		{
			IRandomWheel<int> wheel = Incident.Utils.CreateWheel<int>(NewDictionary);
			Assert.IsNotNull(wheel);
			Assert.IsInstanceOfType(wheel, typeof(IRandomWheel<int>));
		}

		[TestMethod]
		public void CreateWheelPreservesChances()
		{
			var dictionary = NewDictionary; // this dictionary should be modified
			var check = new Dictionary<int, double>(dictionary); // create copy to enable comparison

			IRandomWheel<int> wheel = Incident.Utils.CreateWheel<int>(dictionary);

			foreach (var item in dictionary)
				Assert.AreEqual(item.Value, check[item.Key]);
		}

		[TestMethod]
		public void DefaultChangingModifier()
		{
			IRandomWheel<int> wheel = Incident.Utils.CreateWheel<int>(NewDictionary);
			Assert.AreEqual(1, wheel.Modifier.Multiplier);
			Assert.AreEqual(0, wheel.Modifier.Addend);
			Assert.AreEqual(ChangeModifierOrder.MuliplyThenAdd, wheel.Modifier.Order);
		}

		[TestMethod]
		public void SettingChangingModifierInConstructor()
		{
			for (int i = 0; i < 100; i++)
			{
				for (int j = 0; j < 100; j++)
				{
					for (int k = 0; k < 2; k++)
					{
						IRandomWheel<int> wheel = Incident.Utils.CreateWheel<int>(
							NewDictionary,
							new ChangeModifier(i, j, (ChangeModifierOrder)k));

						Assert.AreEqual(i, wheel.Modifier.Multiplier);
						Assert.AreEqual(j, wheel.Modifier.Addend);
						Assert.AreEqual(k, (int)wheel.Modifier.Order);
					}
				}
			}

		}

		[TestMethod]
		public void ItemsAreCorrectlyChosenByChances()
		{
			int attempts = 10000000;
			int error = attempts / 100; // allow 1% error

			IRandomWheel<int> wheel = Incident.Utils.CreateWheel<int>(NewDictionary);
			int[] counts = new int[wheel.Count];

			for (int i = 0; i < attempts; i++)
				counts[wheel.RandomElement - 1]++;

			Assert.IsTrue(counts[0].AlmostAs((int)(0.1 * attempts), error));
			Assert.IsTrue(counts[1].AlmostAs((int)(0.2 * attempts), error));
			Assert.IsTrue(counts[2].AlmostAs((int)(0.3 * attempts), error));
			Assert.IsTrue(counts[3].AlmostAs((int)(0.4 * attempts), error));
		}

		[TestMethod]
		public void ChanceOfGivesValidChances()
		{
			var dictionary = NewDictionary; // this dictionary should be modified
			IRandomWheel<int> wheel = Incident.Utils.CreateWheel<int>(dictionary);

			foreach (int key in dictionary.Keys)
				Assert.AreEqual(dictionary[key], wheel.ChanceOf(key));
		}

		[TestMethod]
		public void ChangeModifier()
		{
			var dictionary = NewDictionary;

			for (int i = 0; i < 1000; i++)
			{
				IRandomWheel<int> wheel = Incident.Utils.CreateWheel<int>(dictionary, new ChangeModifier(2));

				var index = wheel.RandomElement;

				switch (index)
				{
					case 1:
						Assert.IsTrue(wheel.ChanceOf(1).AlmostAs(0.2 / 1.1));
						Assert.IsTrue(wheel.ChanceOf(2).AlmostAs(0.2 / 1.1));
						Assert.IsTrue(wheel.ChanceOf(3).AlmostAs(0.3 / 1.1));
						Assert.IsTrue(wheel.ChanceOf(4).AlmostAs(0.4 / 1.1));
						break;
					case 2:
						Assert.IsTrue(wheel.ChanceOf(1).AlmostAs(0.1 / 1.2));
						Assert.IsTrue(wheel.ChanceOf(2).AlmostAs(0.4 / 1.2));
						Assert.IsTrue(wheel.ChanceOf(3).AlmostAs(0.3 / 1.2));
						Assert.IsTrue(wheel.ChanceOf(4).AlmostAs(0.4 / 1.2));
						break;
					case 3:
						Assert.IsTrue(wheel.ChanceOf(1).AlmostAs(0.1 / 1.3));
						Assert.IsTrue(wheel.ChanceOf(2).AlmostAs(0.2 / 1.3));
						Assert.IsTrue(wheel.ChanceOf(3).AlmostAs(0.6 / 1.3));
						Assert.IsTrue(wheel.ChanceOf(4).AlmostAs(0.4 / 1.3));
						break;
					case 4:
						Assert.IsTrue(wheel.ChanceOf(1).AlmostAs(0.1 / 1.4));
						Assert.IsTrue(wheel.ChanceOf(2).AlmostAs(0.2 / 1.4));
						Assert.IsTrue(wheel.ChanceOf(3).AlmostAs(0.3 / 1.4));
						Assert.IsTrue(wheel.ChanceOf(4).AlmostAs(0.8 / 1.4));
						break;
					default:
						Assert.Fail("Default branch should never happen.");
						break;
				}
			}

		}
	}
}
