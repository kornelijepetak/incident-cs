using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;

namespace KornelijePetak.IncidentCS
{
	public static partial class Incident
	{
		/// <summary>
		/// Chooses a random element from the list
		/// </summary>
		/// <typeparam name="T">Collection item type</typeparam>
		/// <param name="collection">[Extended] A collection from which to choose</param>
		/// <returns>A random element from the collection</returns>
		public static T ChooseAtRandom<T>(this IEnumerable<T> collection)
		{
			int index;

			IList<T> collectionAsList = collection as IList<T>;
			if (collectionAsList != null)
			{
				index = Rand.Next(collectionAsList.Count);
				T element = collectionAsList[index];
				return element;
			}

			T[] collectionAsArray = collection as T[];
			if (collectionAsArray != null)
			{
				index = Rand.Next(collectionAsArray.Length);
				T element = collectionAsArray[index];
				return element;
			}

			index = Rand.Next(collection.Count());
			return collection.Skip(index).First();
		}

		/// <summary>
		/// Picks a random element from the list. Removes the element from the list.
		/// </summary>
		/// <typeparam name="T">Collection item type</typeparam>
		/// <param name="collection">[Extended] A collection from which to choose</param>
		/// <returns>A random element from the collection</returns>
		public static T PickAtRandom<T>(this List<T> collection)
		{
			int index = Rand.Next(collection.Count);
			T element = collection[index];
			collection.RemoveAt(index);
			return element;
		}

		/// <summary>
		/// Shuffles a collection in-place
		/// </summary>
		/// <typeparam name="T">Collection item type</typeparam>
		/// <param name="collection">[Extended] A collection which to shuffle</param>
		public static void Shuffle<T>(this IList<T> collection)
		{
			for (int i = collection.Count - 1; i >= 1; i--)
			{
				int j = Incident.Primitive.IntegerBetween(0, i + 1);
				var temp = collection[i];
				collection[i] = collection[j];
				collection[j] = temp;
			}
		}

		/// <summary>
		/// Capitalizes evey word in a string.
		/// Word is every non-empty character string following a non-letter character.
		/// </summary>
		/// <param name="text">[Extended] The text to capitalize</param>
		/// <returns>Capitalized string</returns>
		public static string Capitalize(this string text)
		{
			StringBuilder result = new StringBuilder();

			for (int i = 0; i < text.Length; i++)
			{
				if (i == 0)
				{
					result.Append(text[i].ToString().ToUpper());
					continue;
				}

				if (!char.IsLetter(text[i - 1]) && text[i - 1] != '\'')
					result.Append(text[i].ToString().ToUpper());
				else
					result.Append(text[i]);
			}

			return result.ToString();
		}

		/// <summary>
		/// Generates a new collection by repeating a collection <paramref name="count"/> times.
		/// </summary>
		/// <remarks>
		///		Implemented as a generator.
		///		It does not allocate new memory for the collection.
		/// </remarks>
		/// <typeparam name="T">Collection item type</typeparam>
		/// <param name="collection">[Extended] A collection to repeat</param>
		/// <param name="count">Number of times to repeat</param>
		/// <returns>A new collection created by repeating an original collection <paramref name="count"/> times.</returns>
		public static IEnumerable<T> Repeat<T>(this IEnumerable<T> collection, int count)
		{
			for (int i = 0; i < count; i++)
			{
				foreach (T item in collection)
				{
					yield return item;
				}
			}
		}

		/// <summary>
		/// Returns a random enum value for an enum type
		/// </summary>
		/// <typeparam name="T">Enum type</typeparam>
		/// <param name="enumType">[Extended] Enum type</param>
		/// <returns>A random enum value</returns>
		public static T RandomEnumValue<T>(this Type enumType)
		{
			if (!enumType.IsEnum)
				throw new InvalidOperationException("The type given is not an enum.");

			if (typeof(T) != enumType)
				throw new InvalidOperationException("The type parameter must match a given enum type.");

			return Enum.GetValues(enumType).OfType<T>().ChooseAtRandom();
		}

		internal static string TextFromResource(this string resource)
		{
			Assembly assembly = typeof(Incident).Assembly;
			string resourcePath = "IncidentCS." + resource;
			using (StreamReader reader = new StreamReader(assembly.GetManifestResourceStream(resourcePath)))
			{
				return reader.ReadToEnd();
			}
		}

		internal static IEnumerable<string> LinesFromResource(this string resource)
		{
			Assembly assembly = typeof(Incident).Assembly;

			string incidentNamespace = typeof(Incident).Namespace;

			string resourcePath = string.Format("{0}.Resources.{1}", incidentNamespace, resource);

			using (StreamReader reader =
				new StreamReader(assembly.GetManifestResourceStream(resourcePath)))
			{
				return reader.ReadToEnd().Split(new[] { "\r", "\n" }, StringSplitOptions.RemoveEmptyEntries);
			}
		}
	}
}
