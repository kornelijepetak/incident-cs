using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KornelijePetak.IncidentCS.Localization
{
	public class LangTypeInfo : IEquatable<LangTypeInfo>
	{
		public String Language { get; private set; }

		public String MyProperty { get; set; }
		public bool Equals(LangTypeInfo other)
		{
			return false;
		}
	}
}
