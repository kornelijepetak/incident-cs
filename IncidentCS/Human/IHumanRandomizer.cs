using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IncidentCS
{
	public interface IHumanRandomizer
	{
		/// <summary>
		/// Random age of a random human, by its age category.
		/// </summary>
		/// <param name="ageCategory">Optional age category, default is Adult</param>
		/// <returns>Random age</returns>
		int Age(HumanAgeCategory ageCategory = HumanAgeCategory.Adult);

		/// <summary>
		/// Random birthday, determined by the optional age category.
		/// </summary>
		/// <param name="ageCategory"> age category, default is Adult</param>
		/// <returns>Random birthday</returns>
		DateTime Birthday(HumanAgeCategory ageCategory = HumanAgeCategory.Adult);

		/// <summary>
		/// Returns a random first name
		/// </summary>
		string FirstName { get; }

		/// <summary>
		/// Returns a random last name
		/// </summary>
		string LastName { get; }

		/// <summary>
		/// Returns a random full name
		/// </summary>
		string FullName { get; }

		/// <summary>
		/// Returns a random gender as a string
		/// </summary>
		string GenderString { get; }

		/// <summary>
		/// Returns a random gender
		/// </summary>
		HumanGender Gender { get; }

		/// <summary>
		/// Returns a random prefix, like "Mr."
		/// </summary>
		/// <param name="shortPrefix">Determines whether a short prefix should be used</param>
		/// <param name="gender">Random prefix will be generated for this gender.</param>
		/// <returns>A random prefix</returns>
		string Prefix(bool shortPrefix = true, HumanGender gender = HumanGender.Unspecified);

		/// <summary>
		/// Returns a random suffix like "PhD."
		/// </summary>
		/// <param name="shortSuffix">Determines whether a short suffix should be used</param>
		/// <returns>A random suffix</returns>
		string Suffix(bool shortSuffix = true);

	}
}
