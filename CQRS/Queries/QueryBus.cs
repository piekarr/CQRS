namespace CQRS.Queries
{
	public class QueryBus : IQueryBus
	{
		private readonly IQueryHandlerFactory _queryHandlerFactory;

		public QueryBus(IQueryHandlerFactory queryHandlerFactory)
		{
			_queryHandlerFactory = queryHandlerFactory;
		}

		public void Execute<TQuery>(TQuery query)
			where TQuery : IQuery
		{
			var commandHandler = _queryHandlerFactory.Create<TQuery>();
			commandHandler.Handle(query);
		}
	}
}
