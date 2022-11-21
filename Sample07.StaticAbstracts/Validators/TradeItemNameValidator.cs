using Sample07.StaticAbstracts.Data;
using System.ComponentModel.DataAnnotations;

namespace Sample07.StaticAbstracts.Validators;

public sealed class TradeItemNameValidator : IValidator<TradeItem>
{
	public void Validate(TradeItem obj)
	{
		if (obj.Name.Length is < 3 or > 12)
			throw new ValidationException();
	}
}
