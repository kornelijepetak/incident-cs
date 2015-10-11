using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace KornelijePetak.IncidentCS
{
	public class UtilsRandomizer : IUtilsRandomizer
	{
		public IRandomWheel<T> CreateWheel<T>(Dictionary<T, double> chances)
		{
			return new RandomWheel<T>(chances);
		}

		public class RandomWheel<T> : IRandomWheel<T>
		{
			public double[] Ranges { get { return chanceRanges; } }

			public double[] chanceRanges;
			private T[] items;

			internal RandomWheel(Dictionary<T, double> dictionary)
			{
				chanceRanges = new double[dictionary.Count + 1];
				items = new T[dictionary.Count];

				double sum = dictionary.Values.Sum();

				double cummulativeChance = 0;

				int index = 0;
				foreach (var item in dictionary)
				{
					items[index] = item.Key;

					cummulativeChance += item.Value / sum;
					chanceRanges[index + 1] = cummulativeChance;

					index++;
				}
			}

			public int Count { get { return items.Length; } }

			public T RandomElement
			{
				get
				{
					return getRandomElement(Incident.Primitive.DoubleUnit, 0, Count - 1);
				}
			}

			internal T getRandomElement(double val, int min, int max)
			{
				int mid = (min + max) / 2;

				if (val < chanceRanges[mid])
					return getRandomElement(val, min, mid - 1);

				if (val > chanceRanges[mid + 1])
					return getRandomElement(val, mid + 1, max);

				return items[mid];
            }

		}
	}

}
