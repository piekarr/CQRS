namespace CQRS.Results
{
	public sealed class CommandResult : CQRSResult
	{
		public CommandResult()
		{
		}

		public CommandResult(ErrorCode errorCode, string errorMessage) : base(errorCode, errorMessage)
		{
		}

		public static CommandResult Success()
		{
			return new CommandResult();
		}

		public static CommandResult Error(ErrorCode errorCode, string errorMessage)
		{
			return new CommandResult(errorCode, errorMessage);
		}
	}
}
