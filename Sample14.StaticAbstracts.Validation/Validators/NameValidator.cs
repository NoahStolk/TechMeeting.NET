using Sample14.StaticAbstracts.Validation.Data;
using System.ComponentModel.DataAnnotations;

namespace Sample14.StaticAbstracts.Validation.Validators;

public sealed record NameValidator(Action Handler) : IValidator<NameValidator, TradeItem>
{
	public static NameValidator Construct(Action handler)
	{
		return new(handler);
	}
	
	public void Validate(TradeItem obj)
	{
		if (obj.Name.Length is < 3 or > 12)
			Handler();
	}
}
