using CQRS.Results;

namespace CQRS.Queries
{
	public interface IQueryBus
	{
		QueryResult<TResult> Execute<TQuery, TResult>(TQuery query) where TQuery : IQuery<TResult>;
	}
}