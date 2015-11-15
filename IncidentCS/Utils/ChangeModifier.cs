using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IncidentCS.RandomWheel
{
	public class ChangeModifier
	{
		public ChangeModifier(double multiplier = 1, double addend = 0, ChangeModifierOrder order = ChangeModifierOrder.MuliplyThenAdd)
		{
			Multiplier = multiplier;
			Addend = addend;
			Order = order;
		}

		public ChangeModifier()
			: this(1, 0)
		{
		}

		public double GetNewValue(double oldValue)
		{
			return Order == ChangeModifierOrder.AddThenMultiply 
				? (oldValue + Addend) * Multiplier 
				: oldValue * Multiplier + Addend;
		}

		public bool Ischanging
		{
			get
			{
				return Multiplier != 1 || Addend != 0;
			}
		}

		public double Multiplier { get; set; }
		public double Addend { get; set; }
		public ChangeModifierOrder Order { get; set; }
	}
}
