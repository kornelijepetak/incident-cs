using IncidentCS.RandomWheel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace IncidentCS
{
	public interface IUtilsRandomizer
	{
		IRandomWheel<T> CreateWheel<T>(Dictionary<T, double> chances, ChangeModifier changeModifier = null);
		string Repeat(Func<string> itemGenerator, int count);
    }
}
