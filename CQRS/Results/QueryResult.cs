namespace CQRS.Results
{
	public sealed class QueryResult<TResult> : CQRSResult
	{
		public TResult Result { get; }

		public QueryResult(TResult result)
		{
			Result = result;
		}

		public QueryResult(ErrorCode errorCode, string errorMessage) : base(errorCode, errorMessage)
		{
		}

		public static QueryResult<TResult> Success(TResult result)
		{
			return new QueryResult<TResult>(result);
		}

		public static QueryResult<TResult> Error(ErrorCode errorCode, string errorMessage)
		{
			return new QueryResult<TResult>(errorCode, errorMessage);
		}
	}
}
