using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IncidentCS
{
	public interface IGeoRandomizer
	{
		string FullAddress { get; }
		string Address { get; }
		string Street { get; }
		string ZIP { get; }
		string PostalCode { get; }

		string City { get; }
		string State { get; }
		string Country { get; }
		string ImaginaryCountry { get; }

		double Altitude { get; }
		double CustomAltitude(int precision);
		double Depth { get; }
		double CustomDepth(int precision);
		double Latitude { get; }
		double CustomLatitude(int precision);
		double Longitude { get; }
		double CustomLongitude(int precision);

		string Coordinates { get; }
		string CustomCoordinates(int precision);

		string GeoHash { get; }
	}
}
