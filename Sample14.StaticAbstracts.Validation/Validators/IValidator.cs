namespace Sample14.StaticAbstracts.Validation.Validators;

public interface IValidator<out TSelf, in T>
	where TSelf : IValidator<TSelf, T>
{
	static abstract TSelf Construct(Action handler);

	void Validate(T obj);
}
