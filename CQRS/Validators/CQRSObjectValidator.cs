using CQRS.Results;
using System.Collections.Generic;

namespace CQRS
{
	public class CQRSObjectValidator<TCQRSValidable> : ICQRSObjectValidator<TCQRSValidable>
		where TCQRSValidable : ICQRSValidable
	{
		private readonly IEnumerable<IValidator<TCQRSValidable>> _validators;

		public CQRSObjectValidator(IEnumerable<IValidator<TCQRSValidable>> validators)
		{
			_validators = validators;
		}

		public ValidationResult ValidateObject(TCQRSValidable cqrsValidable)
		{
			foreach (var validator in _validators)
			{
				var result = validator.Validate(cqrsValidable);
				if (!result.IsValid)
				{
					return result;
				}
			}
			return ValidationResult.Success();
		}
	}
}
