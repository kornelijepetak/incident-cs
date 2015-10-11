using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace KornelijePetak.IncidentCS
{
	internal class WebRandomizer : IWebRandomizer
	{
		private static string[] ccTLDs = null;
		private static IRandomWheel<string> standardTLDs = null;
		private static IRandomWheel<int> hashtagWordsCountWheel;
		private static IRandomWheel<Func<string>> emailLocalPartWheel;
		private static IRandomWheel<Func<string>> emailLocalPartNamesOnlyWheel;
		private static IRandomWheel<Func<string>> domainWheel;
		private static IRandomWheel<Func<string>> customUrlWheel;
		private static IRandomWheel<string> customUrlExtensions;
		private static IRandomWheel<Func<string>> twitterWheel;

		public string CountryCodeTLD
		{
			get
			{
				if (ccTLDs == null)
					ccTLDs = "ccTLD.txt".LinesFromResource().ToArray();

				return ccTLDs.ChooseAtRandom();
			}
		}

		public string StandardTLD
		{
			get
			{
				if (standardTLDs == null)
					standardTLDs = Incident.Utils.CreateWheel(new Dictionary<string, double> {
						{ "com", 100 }, { "net", 50 }, { "org", 40 }, { "info", 30 }, { "edu", 20 }, { "gov", 5 }, { "mil", 2 }
					});

				return standardTLDs.RandomElement;
			}
		}

		public string TLD
		{
			get
			{
				return Incident.Primitive.DoubleUnit < 0.75 ? StandardTLD : CountryCodeTLD;
			}
		}

		public string Hashtag
		{
			get
			{
				if (hashtagWordsCountWheel == null)
				{
					hashtagWordsCountWheel = Incident.Utils.CreateWheel(new Dictionary<int, double> {
						{ 1, 100 }, { 2, 10 }, { 3, 5}
					});
				}

				return "#" + Incident.Utils.Repeat(() => Incident.Text.Word, hashtagWordsCountWheel.RandomElement);
			}
		}

		public string Email
		{
			get
			{
				return CustomEmail();
			}
		}

		public string CustomEmail(string tld = null, bool namesOnly = false)
		{
			if (emailLocalPartWheel == null)
			{
				emailLocalPartWheel = Incident.Utils.CreateWheel(new Dictionary<Func<string>, double> {
						{ () => Incident.Human.FirstName, 2 },
						{ () => string.Format("{0}.{1}", Incident.Human.FirstName, Incident.Human.LastName), 2 },
						{ () => string.Format("{0}{1}", Incident.Human.FirstName.Substring(0, 1), Incident.Human.LastName), 2 },
						{ () => Incident.Text.Word, 2 },
						{ () => Incident.Text.Word + Incident.Text.Word, 1 },
						{ () => string.Format("{0}.{1}", Incident.Text.Word, Incident.Text.Word), 1 }
					});
			}

			if (emailLocalPartNamesOnlyWheel == null)
			{
				emailLocalPartNamesOnlyWheel = Incident.Utils.CreateWheel(new Dictionary<Func<string>, double> {
						{ () => Incident.Human.FirstName, 1 },
						{ () => string.Format("{0}.{1}", Incident.Human.FirstName, Incident.Human.LastName), 2 },
						{ () => string.Format("{0}{1}", Incident.Human.FirstName.Substring(0, 1), Incident.Human.LastName), 1 }
					});
			}

			if (string.IsNullOrEmpty(tld))
				tld = StandardTLD;

			tld = string.Join("", tld.Where(c => char.IsLetterOrDigit(c)));

			var localPartSource = namesOnly ? emailLocalPartNamesOnlyWheel : emailLocalPartWheel;
			var domain = CustomDomain(tld, false);

			return string.Format("{0}@{1}", localPartSource.RandomElement(), domain).ToLower();
		}

		public string Domain
		{
			get
			{
				return CustomDomain();
			}
		}

		public string CustomDomain(string tld = null, bool includeWWW = true)
		{
			if (domainWheel == null)
			{
				// TODO: add company domain generation after implementing Incident.Business.Company

				domainWheel = Incident.Utils.CreateWheel(new Dictionary<Func<string>, double> {
						{ () => Incident.Text.Word, 3 },
						{ () => string.Format("{0}-{1}", Incident.Text.Word, Incident.Text.Word), 2 },
						{ () => string.Format("www.{0}", Incident.Text.Word), 6 },
						{ () => string.Format("{0}.{1}", Incident.Text.Word, Incident.Text.Word), 3 },
						{ () => Incident.Human.LastName, 2 },
						{ () => string.Format("{0}.{1}", Incident.Human.FirstName, Incident.Human.LastName), 1 },
					});
			}

			if (string.IsNullOrEmpty(tld))
				tld = TLD;

			var domainName = domainWheel.RandomElement();

			if (!includeWWW && domainName.StartsWith("www."))
				domainName = domainName.Substring("www.".Length);

			return string.Format("{0}.{1}", domainName, tld).ToLower();
		}

		public string Url
		{
			get
			{
				return CustomUrl();
			}
		}

		public string CustomUrl(string protocol = "http", string extension = null)
		{
			if (customUrlExtensions == null)
			{
				customUrlExtensions = Incident.Utils.CreateWheel(new Dictionary<string, double> {
						{ "", 200 },
						{ "php", 80 }, { "html", 100 }, { "htm", 20 }, { "asp", 20 }, { "aspx", 40 }, { "cgi", 10 }, { "pl", 5 },
						{ "gif", 10 }, { "jpg", 25 }, { "png", 20 }, { "swf", 5 }, { "json", 5 }, { "js", 5 }, { "css", 5 }
					});
			}

			if (customUrlWheel == null)
			{
				customUrlWheel = Incident.Utils.CreateWheel(new Dictionary<Func<string>, double> {
						{ () => Incident.Text.Word, 30 },
						{ () => string.Format("{0}/{1}", Incident.Text.Word, Incident.Text.Word), 8 },
						{ () => string.Format("{0}-{1}", Incident.Text.Word, Incident.Text.Word), 4 },
						{ () => string.Format("{0}/{1}",  Incident.Text.Word, Incident.Primitive.IntegerBetween(1, 1000)), 2 },
						{ () => string.Format("{0}/{1}/{2}", Incident.Text.Word, Incident.Text.Word, Incident.Primitive.IntegerBetween(1, 1000)), 1 },
					});
			}

			extension = extension ?? customUrlExtensions.RandomElement;

			if (!extension.StartsWith(".") && !string.IsNullOrEmpty(extension))
				extension = "." + extension;

			return string.Format("{0}://{1}/{2}{3}", protocol, Domain, customUrlWheel.RandomElement(), extension);
		}

		public string IPv4
		{
			get
			{
				return string.Format("{0}.{1}.{2}.{3}",
					Incident.Primitive.Byte, Incident.Primitive.Byte, Incident.Primitive.Byte, Incident.Primitive.Byte);
			}
		}

		public string LocalIPv4
		{
			get
			{
				return string.Format("192.168.{0}.{1}", Incident.Primitive.Byte, Incident.Primitive.Byte);
			}
		}

		public string CustomIPv4(byte? A = null, byte? B = null, byte? C = null)
		{
			A = A ?? Incident.Primitive.Byte;
			B = B ?? Incident.Primitive.Byte;
			C = C ?? Incident.Primitive.Byte;

			return string.Format("{0}.{1}.{2}.{3}", A, B, C, Incident.Primitive.Byte);
		}

		public string IPv6
		{
			get
			{
				return string.Join(":",
					Enumerable.Range(0, 8).Select(_ => Incident.Primitive.UnsignedShort.ToString("x4")));
			}
		}

		public string Twitter
		{
			get
			{
				if (twitterWheel == null)
				{
					// TODO: add company twitter generation after implementing Incident.Business.Company

					twitterWheel = Incident.Utils.CreateWheel(new Dictionary<Func<string>, double> {
						{ () => Incident.Text.Word, 5 },
						{ () => Incident.Text.Word + Incident.Text.Word, 2 },
						{ () => Incident.Human.FirstName.Substring(0, 1) + Incident.Human.LastName, 1 },
						{ () => Incident.Human.FirstName + Incident.Human.LastName, 3 },
					});
				}

				return "@" + twitterWheel.RandomElement().ToLower();
			}
		}

		public string HexColor
		{
			get
			{
				return string.Format("{0:x2}{1:x2}{2:x2}", 
					Incident.Primitive.Byte, Incident.Primitive.Byte, Incident.Primitive.Byte);
			}
		}

		public string RgbColor
		{
			get
			{
				return string.Format("rgb({0}, {1}, {2})", 
					Incident.Primitive.Byte, Incident.Primitive.Byte, Incident.Primitive.Byte);
			}
		}

		public string RgbaColor
		{
			get
			{
				return string.Format("rgba({0}, {1}, {2}, {3})", 
					Incident.Primitive.Byte, Incident.Primitive.Byte, Incident.Primitive.Byte, Math.Round(Incident.Primitive.DoubleUnit, 2));
			}
		}

		public string GoogleAnalyticsId
		{
			get
			{
				return string.Format("UA-{0:000000}-{1:00}", 
					Incident.Primitive.IntegerBetween(0, 1000000), 
					Incident.Primitive.IntegerBetween(0, 100));
			}
		}

		public int Port
		{
			get
			{
				return Incident.Primitive.IntegerBetween(1, 65536);
			}
		}
	}
}
