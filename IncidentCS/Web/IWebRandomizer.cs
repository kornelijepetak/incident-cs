using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IncidentCS
{
	public interface IWebRandomizer
	{
		/// <summary>
		/// Returns a random port
		/// </summary>
		int Port { get; }

		/// <summary>
		/// Returns a random top level domain which can either be a StandardTLD (75%) or a ccTLD (25%)
		/// </summary>
		string TLD { get; }

		/// <summary>
		/// Returns a random top level domain from the list:
		/// [com, org, net, info, mil, gov, edu]
		/// </summary>
		string StandardTLD { get; }

		/// <summary>
		/// Returns a random country-code top level domain
		/// </summary>
		string CountryCodeTLD { get; }

		/// <summary>
		/// Returns a random hashtag
		/// </summary>
		string Hashtag { get; }

		/// <summary>
		/// Returns a random email address
		/// </summary>
		string Email { get; }

		/// <summary>
		/// Returns a random email address
		/// </summary>
		/// <param name="tld">
		///		If specified, the returned address will have this TLD. 
		///		Note that Incident does not check the provided value,
		///		so it is possible to generate an invalid email address.
		///		For security reasons, this parameter will be stripped of all
		///		non-alpha-numeric characters.
		/// </param>
		/// <param name="namesOnly">Local part of the random address will be only names</param>
		/// <returns>A random email address with specified options</returns>
		string CustomEmail(string tld = null, bool namesOnly = false);

		/// <summary>
		/// Returns a random internet domain
		/// </summary>
		string Domain { get; }

		/// <summary>
		/// Returns a random internet domain with a specified tld
		/// </summary>
		/// <param name="tld">
		///		TLD to use in a generated domain. 
		///		If not provided the operation returns an Incident.Web.Domain.
		/// </param>
		/// <param name="includeWWW">
		///		If true, some of the results will start with www. 
		///		If false, no domain will start with www.
		/// </param>
		/// <returns>A random internet domain</returns>
		string CustomDomain(string tld = null, bool includeWWW = true);

		/// <summary>
		/// Generates a random URL
		/// </summary>
		string Url { get; }

		/// <summary>
		/// Generates a random URL
		/// </summary>
		/// <param name="protocol">Protocol to use instead of HTTP</param>
		/// <param name="extension">File extension</param>
		/// <returns>A random URL</returns>
		string CustomUrl(string protocol = "http", string extension = null);

		/// <summary>
		/// Returns a random IP v4 address
		/// </summary>
		string IPv4 { get; }

		/// <summary>
		/// Returns a random local IP v4 address (starts with 192.168.)
		/// </summary>
		string LocalIPv4 { get; }

		/// <summary>
		/// Returns a random IP v4 address with specified subnet
		/// </summary>
		/// <returns></returns>
		string CustomIPv4(byte? A = null, byte? B = null, byte? C = null);

		/// <summary>
		/// Returns a random IP v4 address
		/// </summary>
		string IPv6 { get; }

		/// <summary>
		/// Returns a random twitter handle
		/// </summary>
		string Twitter { get; }

		/// <summary>
		/// Returns a random color in hex format (#F8CA22)
		/// </summary>
		string HexColor { get; }

		/// <summary>
		/// Returns a random color in rgb format (i.e. rgb(254, 11, 44))
		/// </summary>
		string RgbColor { get; }

		/// <summary>
		/// Returns a random color in rgba format (i.e. rgba(211, 78, 192, 0.3))
		/// </summary>
		string RgbaColor { get; }

		/// <summary>
		/// A random Google Analytics identifier
		/// </summary>
		string GoogleAnalyticsId { get; }
	}
}
