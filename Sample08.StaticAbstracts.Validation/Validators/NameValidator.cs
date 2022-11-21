using Sample08.StaticAbstracts.Validation.Data;
using System.ComponentModel.DataAnnotations;

namespace Sample08.StaticAbstracts.Validation.Validators;

public sealed class NameValidator : IValidator<TradeItem>
{
	public void Validate(TradeItem obj)
	{
		if (obj.Name.Length is < 3 or > 12)
			throw new ValidationException();
	}
}
