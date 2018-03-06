using CQRS.Results;

namespace CQRS.Queries
{
	public interface IQueryHandler<TQuery>
		where TQuery : IQuery
	{
		QueryResult Handle(TQuery query);
	}
}
