using Sample14.StaticAbstracts.Validation.Data;
using Sample14.StaticAbstracts.Validation.Validators;

TradeItem tradeItem = new("Flower", "1234");

Validate<CodeValidator, TradeItem>(tradeItem, () => throw new ArgumentException());
Validate<NameValidator, TradeItem>(tradeItem, () => throw new InvalidOperationException());

static void Validate<TValidator, TData>(TData data, Action action)
	where TValidator : IValidator<TValidator, TData>
{
	TValidator validator = TValidator.Construct(action);
	validator.Validate(data);
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
