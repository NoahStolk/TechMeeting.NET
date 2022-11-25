using System.ComponentModel.DataAnnotations;
using System.Numerics;

GenericAttribute<string> s = new("attribute value");
GenericAttribute<int> i = new(2);

Console.WriteLine(s.Value);
Console.WriteLine(i.Value);

internal sealed class GenericAttribute<T> : Attribute
{
	public GenericAttribute(T value)
	{
		Value = value;
	}

	public T Value { get; }
}

internal record Data
{
	[GenericRange<ulong>(1, 10)]
	public required long A { get; init; }
	
	[GenericRange<sbyte>(2, 100)]
	public required sbyte B { get; init; }
}

[AttributeUsage(AttributeTargets.Property)]
internal sealed class GenericRangeAttribute<TNumber> : ValidationAttribute
	where TNumber : INumber<TNumber>
{
	private readonly TNumber _minValue;
	private readonly TNumber _maxValue;
	
	public GenericRangeAttribute(TNumber minValue, TNumber maxValue)
	{
		_minValue = minValue;
		_maxValue = maxValue;
	}

	public override bool IsValid(object? value)
	{
		if (value is not TNumber number)
			return false;

		return number >= _minValue && number <= _maxValue;
	}
}
