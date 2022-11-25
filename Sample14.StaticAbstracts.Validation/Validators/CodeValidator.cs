using Sample14.StaticAbstracts.Validation.Data;
using System.ComponentModel.DataAnnotations;

namespace Sample14.StaticAbstracts.Validation.Validators;

public sealed class CodeValidator : IValidator<TradeItem>
{
	public void Validate(TradeItem obj)
	{
		if (obj.Code.Length != 4)
			throw new ValidationException();
	}
}
