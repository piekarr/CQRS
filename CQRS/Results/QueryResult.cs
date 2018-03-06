namespace CQRS.Results
{
	public sealed class QueryResult : CQRSResult
	{
		public QueryResult()
		{
		}

		public QueryResult(ErrorCode errorCode, string errorMessage) : base(errorCode, errorMessage)
		{
		}

		public static QueryResult Success()
		{
			return new QueryResult();
		}

		public static QueryResult Error(ErrorCode errorCode, string errorMessage)
		{
			return new QueryResult(errorCode, errorMessage);
		}
	}
}
