using CQRS.Results;

namespace CQRS.Queries
{
	public abstract class QueryHandler<TQuery,TResult> : IQueryHandler<TQuery, TResult>
		where TQuery : IQuery<TResult>
	{
		private readonly ICQRSObjectValidator<TQuery> _validator;

		protected QueryHandler(ICQRSObjectValidator<TQuery> validator)
		{
			_validator = validator;
		}

		public QueryResult<TResult> Handle(TQuery query)
		{
			var validationResult = _validator.ValidateObject(query);
			if (!validationResult.IsValid)
			{
				return validationResult.ToQueryResult<TResult>();
			}
			return ExecuteQuery(query);
		}

		protected abstract QueryResult<TResult> ExecuteQuery(TQuery query);
	}
}
