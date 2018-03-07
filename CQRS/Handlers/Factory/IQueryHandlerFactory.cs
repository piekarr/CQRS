namespace CQRS.Queries
{
	public interface IQueryHandlerFactory
	{
		QueryHandler<TQuery, TResult> Create<TQuery, TResult>() where TQuery : IQuery<TResult>;
	}
}
