namespace CQRS.Results
{
	public sealed class CommandResult<TResult> : CQRSResult
	{
		public TResult Result { get;}
		public CommandResult(TResult result)
		{
			Result = result;
		}

		public CommandResult(ErrorCode errorCode, string errorMessage) : base(errorCode, errorMessage)
		{
		}

		public static CommandResult<TResult> Success(TResult result)
		{
			return new CommandResult<TResult>(result);
		}

		public static CommandResult<TResult> Error(ErrorCode errorCode, string errorMessage)
		{
			return new CommandResult<TResult>(errorCode, errorMessage);
		}
	}
}
