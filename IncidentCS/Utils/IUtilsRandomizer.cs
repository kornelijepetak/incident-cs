using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace KornelijePetak.IncidentCS
{
	public interface IUtilsRandomizer
	{
		IRandomWheel<T> CreateWheel<T>(Dictionary<T, double> chances);
	}
}
