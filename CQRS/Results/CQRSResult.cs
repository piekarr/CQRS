namespace CQRS.Results
{
	public abstract class CQRSResult
	{
		private bool _isValid;

		public bool IsValid => _isValid && string.IsNullOrEmpty(ErrorMessage);

		public string ErrorMessage { get; }

		public ErrorCode ErrorCode { get; }

		protected CQRSResult()
		{
			_isValid = true;
		}

		protected CQRSResult(ErrorCode errorCode, string errorMessage) : this()
		{
			_isValid = false;
			ErrorCode = errorCode;
			ErrorMessage = errorMessage;
		}
	}
}
