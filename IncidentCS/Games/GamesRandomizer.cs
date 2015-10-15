using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IncidentCS
{
	internal class GamesRandomizer : IGamesRandomizer
	{
		public virtual int D2
		{
			get
			{
				return Incident.Primitive.IntegerBetween(1, 3);
			}
		}

		public virtual int D3
		{
			get
			{
				return Incident.Primitive.IntegerBetween(1, 4);
			}
		}

		public virtual int D4
		{
			get
			{
				return Incident.Primitive.IntegerBetween(1, 5);
			}
		}

		public virtual int D6
		{
			get
			{
				return Incident.Primitive.IntegerBetween(1, 7);
			}
		}

		public virtual int D8
		{
			get
			{
				return Incident.Primitive.IntegerBetween(1, 9);
			}
		}

		public virtual int D10
		{
			get
			{
				return Incident.Primitive.IntegerBetween(1, 11);
			}
		}

		public virtual int D12
		{
			get
			{
				return Incident.Primitive.IntegerBetween(1, 13);
			}
		}

		public virtual int D20
		{
			get
			{
				return Incident.Primitive.IntegerBetween(1, 21);
			}
		}

		public virtual int D100
		{
			get
			{
				return Incident.Primitive.IntegerBetween(1, 101);
			}
		}

		public virtual int Dice(int sideCount)
		{
			return Incident.Primitive.IntegerBetween(1, sideCount + 1);
		}

		public virtual PokerSuit PokerSuit
		{
			get
			{
				return typeof(PokerSuit).RandomEnumValue<PokerSuit>();
			}
		}

		public virtual PokerRank PokerRank
		{
			get
			{
				return typeof(PokerRank).RandomEnumValue<PokerRank>();
			}
		}
	}
}
