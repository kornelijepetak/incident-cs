using System;
using System.Collections.Generic;
using System.Linq;

namespace KornelijePetak.IncidentCS
{
	public enum HumanAgeCategory
	{
		/// <summary>
		/// Age between 1 and 100
		/// </summary>
		Any,

		/// <summary>
		/// Age between 1 and 12
		/// </summary>
		Child,

		/// <summary>
		/// Age between 13 and 19
		/// </summary>
		Teen,

		/// <summary>
		/// Age between 18 and 65
		/// </summary>
		Adult,

		/// <summary>
		/// Age between 65 and 100
		/// </summary>
		Senior		
	}
}
