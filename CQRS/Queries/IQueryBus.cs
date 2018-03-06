namespace CQRS.Queries
{
	public interface IQueryBus
	{
		void Execute<TQuery>(TQuery query) where TQuery : IQuery;
	}
}