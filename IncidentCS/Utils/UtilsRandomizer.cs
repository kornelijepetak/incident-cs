using IncidentCS.RandomWheel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace IncidentCS
{
	public class UtilsRandomizer : IUtilsRandomizer
	{
		public virtual IRandomWheel<T> CreateWheel<T>(Dictionary<T, double> chances, ChangeModifier changeModifier = null)
		{
			changeModifier = changeModifier ?? new ChangeModifier();
			return new RandomWheel<T>(chances, changeModifier);
		}

		internal class RandomWheel<T> : IRandomWheel<T>
		{
			/// <summary>
			/// Gets or sets the modifier that is applied to the chosen item's chance. 
			/// </summary>
			/// <remarks>
			///		The chance of a chosen item is modified by the ChangeModifier after being chosen.
			///		There are two ways to modify the value. Increasing the chance by an absolute amount or
			///		multiplying the chance by a multiplier. Both ways can be used in a chosen order,
			///		making an item more or less likely to be chosen in future. 
			/// 
			///		If multiplier is set to 1, and addend to 0, no change to chances is made when an item is selected. 
			/// 
			///		For negative values of the multiplier, an absolute positive value is used.
			///		If addend is a negative value, it will decrease the chosen value, but not lower than 0.
			///	
			/// 	Special case: 
			///			Note what happens if a modifier sets the chance to 0 (or a very 
			///			small number). When an item is then chosen, its chance to be 
			///			chosen in the next attempt is 0. That means that another item 
			///			will be selected. When this happens for every item in the
			///			collection, the sum of chances will be 0. In that case,
			///			retrieving a random item will throw an InvalidOperation exception.
			///			Be careful when setting a change modifier to avoid situations like these.
			/// </remarks>
			public ChangeModifier Modifier
			{
				get { return modifier; }
				set
				{
					value.Multiplier = Math.Abs(value.Multiplier);
					modifier = value;
				}
			}

			/// <summary>
			/// Returns a random element from the wheel
			/// </summary>
			public virtual T RandomElement
			{
				get
				{
					var chosenElement = getRandomElement(Incident.Primitive.DoubleUnit, 0, Count - 1);

					if (modifier.Ischanging)
					{
						storedChances[chosenElement] = modifier.GetNewValue(storedChances[chosenElement]);
						recalculateChances();
					}

					return chosenElement;
				}
			}

			/// <summary>
			/// Returns a number of items in the wheel
			/// </summary>
			public int Count
			{
				get
				{
					return items.Length;
				}
			}

			/// <summary>
			/// Constructor
			/// </summary>
			/// <param name="chances">Dictionary mapping items to chances. Original dictionary is preserved.</param>
			/// <param name="saveChances">Determines whether to preserve</param>
			internal RandomWheel(Dictionary<T, double> chances, ChangeModifier changeModifier)
			{
				this.modifier = changeModifier;

				storedChances = new Dictionary<T, double>(chances);
				chances = storedChances;

				chanceRanges = new double[chances.Count + 1];
				items = new T[chances.Count];

				recalculateChances();
			}

			/// <summary>
			/// Returns the chance assigned to the <paramref name="element"/>
			/// </summary>
			/// <param name="element"></param>
			/// <returns>The chance assigned to the <paramref name="element"/></returns>
			public double ChanceOf(T element)
			{
				if (storedChances == null)
					throw new ArgumentException("To be able to get the chances later, set saveChances to true on Wheel construction.");

				return storedChances[element];
			}

			protected void recalculateChances()
			{
				double sum = storedChances.Values.Sum();

				if (sum == 0)
					throw new InvalidOperationException("Sum of all chances is 0");

				double cummulativeChance = 0;

				int index = 0;

				foreach (var item in storedChances.ToList())
				{
					if (item.Value < 0)
						throw new InvalidOperationException(string.Format("A chance is a negative number for key '{0}'.", item.Key));

					items[index] = item.Key;

					cummulativeChance += item.Value / sum;
					storedChances[item.Key] /= sum;
					chanceRanges[index + 1] = cummulativeChance;

					index++;
				}
			}

			protected T getRandomElement(double val, int min, int max)
			{
				// Uses recursive binary-search to find the interval.
				// ...

				int mid = (min + max) / 2;

				if (val < chanceRanges[mid])
					return getRandomElement(val, min, mid - 1);

				if (val > chanceRanges[mid + 1])
					return getRandomElement(val, mid + 1, max);

				return items[mid];
			}

			protected double[] chanceRanges;
			protected T[] items;
			protected Dictionary<T, double> storedChances;
			private ChangeModifier modifier;
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
