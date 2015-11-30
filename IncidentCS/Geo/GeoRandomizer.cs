using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IncidentCS
{
	public class GeoRandomizer : IGeoRandomizer
	{
		private static IRandomWheel<string> countryWheel;
		private static IRandomWheel<string> stateWheel;
		private static IRandomWheel<string> cityWheel;

		private static string[] countries;

		private static string[] streetSuffixes;
		private static string[] shortStreetSuffixes;

		private string base32alphabet = "0123456789bcdefghjkmnpqrstuvwxyz";

		public virtual string Address
		{
			get
			{
				return string.Format("{0} {1}", Incident.Primitive.IntegerBetween(5, 2000), Street).Capitalize();
			}
		}

		public virtual string FullAddress
		{
			get
			{
				return string.Format("{0} {1}, {2} {3}, {4}",
					Incident.Primitive.IntegerBetween(5, 2000), Street, ZIP, City, Country).Capitalize();
			}
		}

		public virtual string Street
		{
			get
			{
				if (streetSuffixes == null)
				{
					streetSuffixes = "StreetSuffixes.txt".LinesFromResource().ToArray();
					shortStreetSuffixes = "ShortStreetSuffixes.txt".LinesFromResource().ToArray();
				}

				string name = Incident.Primitive.DoubleUnit < 0.75
					? Incident.Text.Word
					: string.Format("{0} {1}", Incident.Text.Word, Incident.Text.Word);

				string suffix = Incident.Primitive.Boolean
					? streetSuffixes.ChooseAtRandom()
					: shortStreetSuffixes.ChooseAtRandom();

				return string.Format("{0} {1}", name, suffix).Capitalize();
			}
		}

		public virtual string ZIP
		{
			get
			{
				return Incident.Primitive.IntegerBetween(10000, 100000).ToString();
			}
		}

		public virtual string PostalCode
		{
			get
			{
				return Incident.Primitive.IntegerBetween(1000, 100000).ToString();
			}
		}

		public virtual string City
		{
			get
			{
				if (cityWheel == null)
				{
					cityWheel = Incident.Utils.CreateWheel(new Dictionary<String, double>()
					{
						{ "{0}", 10 },
						{ "City of {0}", 4 },
						{ "{0}ville", 3 },
						{ "New {0}", 1 },
						{ "{0} Town", 1 },
						{ "District of {0}", 1 },
						{ "Old {0}", 1  },
					});
				}

				string name = Incident.Primitive.DoubleUnit < 0.75
					? Incident.Text.Word
					: string.Format("{0} {1}", Incident.Text.Word, Incident.Text.Word);

				return string.Format(cityWheel.RandomElement, name).Capitalize();
			}
		}

		public virtual string State
		{
			get
			{
				if (stateWheel == null)
				{
					stateWheel = Incident.Utils.CreateWheel(new Dictionary<String, double>()
					{
						{ "{0}", 5 },
						{ "{0}ia", 5 },
						{ "{0} State", 2 },
						{ "State of {0}", 2 },
						{ "West {0}", 1 },
						{ "South {0}", 1 },
						{ "North {0}", 1  },
						{ "East {0}", 1 },
					});
				}

				return string.Format(stateWheel.RandomElement, Incident.Text.Word).Capitalize();
			}
		}

		public virtual string Country
		{
			get
			{
				if (countries == null)
					countries = "Countries.txt".LinesFromResource().ToArray();

				return countries.ChooseAtRandom();
			}
		}

		public virtual string ImaginaryCountry
		{
			get
			{
				if (countryWheel == null)
				{
					countryWheel = Incident.Utils.CreateWheel(new Dictionary<String, double>()
					{
						{ "{0}", 5 },
						{ "{0}ia", 5 },
						{ "{0} Republic", 4 },
						{ "Republic of {0}", 4 },
						{ "Land of {0}", 4 },
						{ "{0} Islands", 4 },
						{ "Democratic Republic of {0}", 4 },
						{ "{0} Federation", 3 },
						{ "State of {0}", 3 },
						{ "{0}stan", 2 },
						{ "West {0}", 2 },
						{ "South {0}", 2 },
						{ "North {0}", 2 },
						{ "East {0}", 2 },
						{ "{0} Territory", 2 },
						{ "United States of {0}", 1 },
					});
				}

				return string.Format(countryWheel.RandomElement, Incident.Text.Word).Capitalize();
			}
		}

		public virtual double Altitude
		{
			get
			{
				return CustomAltitude(5);
			}
		}

		public virtual double CustomAltitude(int precision)
		{
			return Math.Round(Incident.Primitive.DoubleBetween(0, 8848), precision);
		}

		public virtual double Depth
		{
			get
			{
				return CustomDepth(5);
			}
		}

		public virtual double CustomDepth(int precision)
		{
			return Math.Round(-1 * Incident.Primitive.DoubleBetween(0, 11034), precision);
		}

		public virtual double Latitude
		{
			get
			{
				return CustomLatitude(5);
			}
		}

		public virtual double CustomLatitude(int precision)
		{
			return Math.Round(Incident.Primitive.DoubleBetween(-90, 90), precision);
		}

		public virtual double Longitude
		{
			get
			{
				return CustomLongitude(5);
			}
		}

		public virtual double CustomLongitude(int precision)
		{
			return Math.Round(Incident.Primitive.DoubleBetween(-180, 180), precision);
		}

		public virtual string Coordinates
		{
			get
			{
				return CustomCoordinates(5);
			}
		}

		public virtual string CustomCoordinates(int precision)
		{
			return string.Format("{0}, {1}", CustomLatitude(precision), CustomLongitude(precision));
		}

		public virtual string GeoHash
		{
			get
			{
				int precision = Incident.Primitive.IntegerBetween(5, 10);
                return Enumerable.Range(0, precision)
                    .Select(_ => base32alphabet.ChooseAtRandom())
                    .StringJoin();
			}
		}
	}
}
