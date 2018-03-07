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

		public CommandResult<TResult> ToCommandResult<TResult>()
		{
			return IsValid ? CommandResult<TResult>.Success(default(TResult)) : CommandResult<TResult>.Error(ErrorCode, ErrorMessage);
		}

		public QueryResult<TResult> ToQueryResult<TResult>()
		{
			return IsValid ? QueryResult<TResult>.Success(default(TResult)) : QueryResult<TResult>.Error(ErrorCode, ErrorMessage);
		}
	}
}
