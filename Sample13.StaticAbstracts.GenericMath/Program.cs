using Sample13.StaticAbstracts.GenericMath;
using System.Numerics;

Console.WriteLine(Sum(new[] { 1, 2, 3, 4 }));
Console.WriteLine(Sum(new[] { 1, 2, 3, 4.5m }));

static T Sum<T>(IEnumerable<T> numbers)
	where T : INumber<T>
{
	T result = T.Zero;
	foreach (T i in numbers)
		result += i;

	return result;
}

IEnumerable<int> ints = ParseAll<int>(new[] { "1", "2", "3" });
IEnumerable<decimal> decimals = ParseAll<decimal>(new[] { "1.5", "2.25", "3.125" });

Console.WriteLine(string.Join(' ', Sum(ints)));
Console.WriteLine(string.Join(' ', Sum(decimals)));

static IEnumerable<T> ParseAll<T>(IEnumerable<string> input)
	where T : IParsable<T>
{
	return input.Select(str => T.Parse(str, null));
}

Console.WriteLine(new Vector2i<int>(1, 3));
Console.WriteLine(new Vector2i<int>(1, 3) + new Vector2i<int>(3, 1));
Console.WriteLine(new Vector2i<short>(1, short.MaxValue));
Console.WriteLine(Vector2i<short>.Zero);
Console.WriteLine(Vector2i<short>.One);
PrintMaxVector<int>();
PrintMaxVector<short>();
PrintMaxVector<ushort>();
PrintMaxVector<byte>();

void PrintMaxVector<T>()
	where T : IBinaryInteger<T>, IMinMaxValue<T>
{
	Console.WriteLine(new Vector2i<T>(T.MaxValue));
}
