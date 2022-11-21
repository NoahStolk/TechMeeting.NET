using Sample07.StaticAbstracts.Data;
using System.ComponentModel.DataAnnotations;

namespace Sample07.StaticAbstracts.Validators;

public sealed class TradeItemCodeValidator : IValidator<TradeItem>
{
	public void Validate(TradeItem obj)
	{
		if (obj.Code.Length != 4)
			throw new ValidationException();
	}
}
