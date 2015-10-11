namespace KornelijePetak.IncidentCS
{
	public interface IRandomWheel<T>
	{
		int Count { get; }
		T RandomElement { get; }
	}
}