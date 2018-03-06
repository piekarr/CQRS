using CQRS.Results;

namespace CQRS
{
	public interface ICQRSObjectValidator<TCQRSValidable>
		where TCQRSValidable : ICQRSValidable
	{
		ValidationResult ValidateObject(TCQRSValidable cqrsValidable);
	}
}
