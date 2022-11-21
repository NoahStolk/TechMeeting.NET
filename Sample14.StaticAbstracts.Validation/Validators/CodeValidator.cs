using Sample14.StaticAbstracts.Validation.Data;
using System.ComponentModel.DataAnnotations;

namespace Sample14.StaticAbstracts.Validation.Validators;

public sealed record CodeValidator(Action Handler) : IValidator<CodeValidator, TradeItem>
{
	public static CodeValidator Construct(Action handler)
	{
		return new(handler);
	}

	public void Validate(TradeItem obj)
	{
		if (obj.Code.Length != 4)
			Handler();
	}
}
