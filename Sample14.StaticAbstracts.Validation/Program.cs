using Sample14.StaticAbstracts.Validation.Data;
using Sample14.StaticAbstracts.Validation.Validators;

TradeItem tradeItem = new("Flower", "1234");

Validate<CodeValidator, TradeItem>(tradeItem);
Validate<NameValidator, TradeItem>(tradeItem);

static void Validate<TValidator, TData>(TData data)
	where TValidator : IValidator<TData>
{
	TValidator.Validate(data);
}

/*
 * static abstracts:
 *   - only for interfaces
 *   - allows calling static methods on type parameters
 *
 * pros:
 *   - allows for cleaner and safer code (no reflection)
 *   - instantiating a class using the 'new()' constraint is no longer necessary;
 *     - allows for generic "constructor" methods on interfaces
 *     - prevents allocating memory
 *   - allows for generic math and many other things
*/
