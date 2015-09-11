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
		/// Chooses an element from the list
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

		public static T PickAtRandom<T>(this List<T> collection)
		{
			int index = Rand.Next(collection.Count);
			T element = collection[index];
			collection.RemoveAt(index);
			return element;
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

			string resourcePath = string.Format("{0}.{1}", incidentNamespace, resource);

			using (StreamReader reader =
				new StreamReader(assembly.GetManifestResourceStream(resourcePath)))
			{
				return reader.ReadToEnd().Split(new[] { "\r", "\n" }, StringSplitOptions.RemoveEmptyEntries);
			}
		}

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

				if (text[i - 1] == ' ')
					result.Append(text[i].ToString().ToUpper());
				else
					result.Append(text[i]);
			}

			return result.ToString();
		}
	}
}
