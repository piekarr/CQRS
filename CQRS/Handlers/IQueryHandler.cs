using CQRS.Results;

namespace CQRS.Queries
{
	public interface IQueryHandler<TQuery,TResult>
		where TQuery : IQuery<TResult>
	{
		QueryResult<TResult> Handle(TQuery query);
	}
}
