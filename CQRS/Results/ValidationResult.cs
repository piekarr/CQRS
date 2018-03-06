using System;

namespace CQRS.Results
{
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

		public QueryResult ToQueryResult()
		{
			return IsValid ? QueryResult.Success() : QueryResult.Error(ErrorCode, ErrorMessage);
		}
	}
}
