namespace Sample08.StaticAbstracts.Validation.Validators;

public interface IValidator<in T>
{
	// TODO: static abstract
	void Validate(T obj);
}