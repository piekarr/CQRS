using CQRS.Results;

namespace CQRS.Queries
{
	public abstract class QueryHandler<TQuery> : IQueryHandler<TQuery>
		where TQuery : IQuery
	{
		private readonly ICQRSObjectValidator<TQuery> _validator;

		protected QueryHandler(ICQRSObjectValidator<TQuery> validator)
		{
			_validator = validator;
		}

		public QueryResult Handle(TQuery query)
		{
			var validationResult = _validator.ValidateObject(query);
			if (!validationResult.IsValid)
			{
				return validationResult.ToQueryResult();
			}
			return ExecuteQuery(query);
		}

		protected abstract QueryResult ExecuteQuery(TQuery query);
	}
}
