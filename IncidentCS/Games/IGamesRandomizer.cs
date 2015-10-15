using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IncidentCS
{
	public interface IGamesRandomizer
	{
		/// <summary>
		/// A random result of a d2 die throw
		/// </summary>
		int D2 { get; }
		
		/// <summary>
		/// A random result of a d3 die throw
		/// </summary>
		int D3 { get; }
		
		/// <summary>
		/// A random result of a d4 die throw
		/// </summary>
		int D4 { get; }
		
		/// <summary>
		/// A random result of a d6 die throw
		/// </summary>
		int D6 { get; }
		
		/// <summary>
		/// A random result of a d8 die throw
		/// </summary>
		int D8 { get; }
		
		/// <summary>
		/// A random result of a d10 die throw
		/// </summary>
		int D10 { get;}
		
		/// <summary>
		/// A random result of a d12 die throw
		/// </summary>
		int D12 { get; }
		
		/// <summary>
		/// A random result of a d20 die throw
		/// </summary>
		int D20 { get; }
		
		/// <summary>
		/// A random result of a d100 die throw
		/// </summary>
		int D100 { get; }
	
		/// <summary>
		/// A random result of a custom die throw
		/// </summary>
		int Dice(int sideCount);

		/// <summary>
		/// A random poker card suit
		/// </summary>
		PokerSuit PokerSuit { get; }

		/// <summary>
		/// A random poker card rank
		/// </summary>
		PokerRank PokerRank { get; }
	}
}
