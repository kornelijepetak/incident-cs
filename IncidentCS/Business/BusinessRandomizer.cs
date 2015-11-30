using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IncidentCS
{
	public class BusinessRandomizer : IBusinessRandomizer
	{
		private IRandomWheel<String> companyTypeWheel;
		private IRandomWheel<String> companyNameSuffixWheel;
		private IRandomWheel<Func<string>> companyNameWheel;

		public virtual string Company
		{
			get
			{
				if (companyNameSuffixWheel == null)
				{
					companyNameSuffixWheel = Incident.Utils.CreateWheel(new Dictionary<string, double>() {
						{ "Industries", 8 },
						{ "Technologies", 7 },
						{ "Software", 5 },
						{ "Television", 2 },
						{ "Stores", 5 },
						{ "News", 5 },
						{ "Travel", 5 },
						{ "Games", 5 },
						{ "Tours", 3 },
						{ "Markets", 2 },
						{ "Pharmaceuticals", 2 },
						{ "Automobiles", 2 },
						{ "Electric", 1 },
					});
				}

				if (companyNameWheel == null)
				{
					companyNameWheel = Incident.Utils.CreateWheel(new Dictionary<Func<string>, double>() {
						{ () => Incident.Text.Word.Capitalize(), 20 },
						{ () => string.Format("{0} {1}", Incident.Text.Word, Incident.Text.Word).Capitalize(), 50 },
						{ () => string.Format("{0}'s {1}", Incident.Human.LastName, Incident.Text.Word).Replace("s's", "s'").Capitalize(), 50 },
						{ () => string.Format("{0} and Sons", Incident.Human.FullName, Incident.Text.Word.Capitalize()), 1 },
					});
				}

				List<string> parts = new List<string>();

				parts.Add(companyNameWheel.RandomElement());

				if (Incident.Primitive.DoubleUnit < 0.3)
					parts.Add(" " + companyNameSuffixWheel.RandomElement);
				else if (Incident.Primitive.DoubleUnit < 0.5)
					parts.Add(" " + CompanyType);

				return parts.StringJoin();
			}
		}

		public virtual string CompanyType
		{
			get
			{
				if (companyTypeWheel == null)
				{
					companyTypeWheel = Incident.Utils.CreateWheel(new Dictionary<string, double>() {
						{ "Ltd.", 10 },
						{ "Corp.", 5 },
						{ "Inc.", 5 },
						{ "PLC", 1 },
						{ "LLP", 1 },
						{ "Group", 1 }
					});
				}

				return companyTypeWheel.RandomElement;
			}
		}

		public string Phone
		{
			get
			{
				List<string> parts = new List<string>();

				if (Incident.Primitive.DoubleUnit < 0.2)
					parts.Add("+" + Incident.Primitive.IntegerBetween(1, 1000));

				if (parts.Count == 1)
					parts.Add(string.Format("({0})", Incident.Primitive.IntegerBetween(10, 1000)));
				else
					parts.Add(Incident.Primitive.IntegerBetween(10, 1000).ToString());

				parts.Add(Incident.Primitive.IntegerBetween(0, 10000).ToString().PadLeft(4, '0'));
				parts.Add(Incident.Primitive.IntegerBetween(0, 1000).ToString().PadLeft(3, '0'));

				return parts.StringJoin(" ");
			}
		}
	}
}
