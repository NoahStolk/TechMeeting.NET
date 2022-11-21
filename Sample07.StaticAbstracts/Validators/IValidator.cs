namespace Sample07.StaticAbstracts.Validators;

public interface IValidator<in T>
{
	// TODO: static abstract
	void Validate(T obj);
}
