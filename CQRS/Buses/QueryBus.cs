using CQRS.Results;

namespace CQRS.Queries
{
	public class QueryBus : IQueryBus
	{
		private readonly IQueryHandlerFactory _queryHandlerFactory;

		public QueryBus(IQueryHandlerFactory queryHandlerFactory)
		{
			_queryHandlerFactory = queryHandlerFactory;
		}

		public QueryResult<TResult> Execute<TQuery, TResult>(TQuery query)
			where TQuery : IQuery<TResult>
		{
			var commandHandler = _queryHandlerFactory.Create<TQuery, TResult>();
			return commandHandler.Handle(query);
		}
	}
}
