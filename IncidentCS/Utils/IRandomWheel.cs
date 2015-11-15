using IncidentCS.RandomWheel;

namespace IncidentCS
{
	public interface IRandomWheel<T>
	{
		int Count { get; }
		double ChanceOf(T element);
		ChangeModifier Modifier { get; set; }
		T RandomElement { get; }
	}
}