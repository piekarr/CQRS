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

	public sealed class ValidationResult : CQRSResult
	{
		private ValidationResult()
		{
		}

		private ValidationResult(ErrorCode errorCode, string errorMessage) : base(errorCode, errorMessage)
		{
		}

		public static ValidationResult Success()
		{
			return new ValidationResult();
		}

		public static ValidationResult Error(ErrorCode errorCode, string errorMessage)
		{
			return new ValidationResult(errorCode, errorMessage);
		}

		public CommandResult ToCommandResult()
		{
			return IsValid ? CommandResult.Success() : CommandResult.Error(ErrorCode, ErrorMessage);
		}
	}
}
