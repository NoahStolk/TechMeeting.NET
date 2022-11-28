namespace Sample14.StaticAbstracts.Validation.Validators;

public interface IValidator<in T>
{
	static abstract void Validate(T obj);
}
