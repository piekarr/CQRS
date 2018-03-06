namespace CQRS.Queries
{
	public interface IQueryHandlerFactory
	{
		QueryHandler<TQuery> Create<TQuery>() where TQuery : IQuery;
	}
}
