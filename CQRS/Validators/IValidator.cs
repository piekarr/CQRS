using CQRS.Results;

namespace CQRS
{
	public interface IValidator<TObject>
		where TObject : ICQRSValidable
	{
		ValidationResult Validate(TObject @object);
	}
}
