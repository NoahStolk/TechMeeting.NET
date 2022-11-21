using Sample07.StaticAbstracts.Data;
using Sample07.StaticAbstracts.Validators;

TradeItem tradeItem = new("Flower", "1234");

Validate<TradeItemCodeValidator, TradeItem>(tradeItem);
Validate<TradeItemNameValidator, TradeItem>(tradeItem);

static void Validate<TValidator, TData>(TData data)
	where TValidator : IValidator<TData>, new() // TODO: Allow ctor with parameters
{
	TValidator validator = new(); // TODO: Prevent allocating instances
	validator.Validate(data);
}

/*
 * static abstracts:
 *   - only for interfaces
 *   - allows calling static methods on type parameters
 *
 * pros:
 *   - allows for cleaner code (e.g. no reflection)
 *   - instantiating a class using the 'new()' constraint is no longer necessary;
 *     - allows for generic "constructor" methods on interfaces
 *     - prevents allocating memory
 *   - allows for generic math and many other things
*/
