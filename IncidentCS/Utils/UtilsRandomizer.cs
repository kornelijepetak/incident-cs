using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace IncidentCS
{
	public class UtilsRandomizer : IUtilsRandomizer
	{
		public virtual IRandomWheel<T> CreateWheel<T>(Dictionary<T, double> chances, bool saveChances = true)
		{
			return new RandomWheel<T>(chances, saveChances);
		}

		public class RandomWheel<T> : IRandomWheel<T>
		{
			/// <summary>
			/// Returns a random element from the wheel
			/// </summary>
			public T RandomElement
			{
				get
				{
					return getRandomElement(Incident.Primitive.DoubleUnit, 0, Count - 1);
				}
			}

			/// <summary>
			/// Returns a number of items in the wheel
			/// </summary>
			public int Count { get { return items.Length; } }

			/// <summary>
			/// Returns the chance assigned to the <paramref name="element"/>
			/// </summary>
			/// <param name="element"></param>
			/// <returns>The chance assigned to the <paramref name="element"/></returns>
			public double ChanceOf(T element)
			{
				if(dictionary == null)
					throw new ArgumentException("To be able to get the chances later, set saveChances to true on Wheel construction.");

				return dictionary[element];
			}

			private double[] chanceRanges;
			private T[] items;

			private Dictionary<T, double> dictionary;

			internal RandomWheel(Dictionary<T, double> dictionary, bool saveChances)
			{
				if (saveChances)
				{
					this.dictionary = new Dictionary<T, double>(dictionary);
					dictionary = this.dictionary;
				}

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

			private T getRandomElement(double val, int min, int max)
			{
				int mid = (min + max) / 2;

				if (val < chanceRanges[mid])
					return getRandomElement(val, min, mid - 1);

				if (val > chanceRanges[mid + 1])
					return getRandomElement(val, mid + 1, max);

				return items[mid];
			}

		}

		/// <summary>
		/// Creates a string created by repeating a string.
		/// </summary>
		/// <param name="itemGenerator">A function that gives the original string</param>
		/// <param name="count">Number of times to repeat</param>
		/// <returns>A string created by repeating a string</returns>
		public string Repeat(Func<string> itemGenerator, int count)
		{
			StringBuilder result = new StringBuilder();

			for (int i = 0; i < count; i++)
				result.Append(itemGenerator());

			return result.ToString();
		}
	}

}
