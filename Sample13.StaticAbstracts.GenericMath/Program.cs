using Sample13.StaticAbstracts.GenericMath;
using System.Numerics;

Console.WriteLine(SumInt(new[] { 1, 2, 3, 4 }));
Console.WriteLine(SumDecimal(new[] { 1, 2, 3, 4.5m }));

static int SumInt(IEnumerable<int> ints)
{
	int result = 0;
	foreach (int i in ints)
		result += i;

	return result;
}

static decimal SumDecimal(IEnumerable<decimal> decimals)
{
	decimal result = 0;
	foreach (decimal d in decimals)
		result += d;

	return result;
}

IEnumerable<int> ints = ParseAllInts(new[] { "1", "2", "3" });
IEnumerable<decimal> decimals = ParseAllDecimals(new[] { "1.5", "2.25", "3.125" });

Console.WriteLine(string.Join(' ', SumInt(ints)));
Console.WriteLine(string.Join(' ', SumDecimal(decimals)));

static IEnumerable<int> ParseAllInts(IEnumerable<string> input)
{
	return input.Select(str => int.Parse(str, null));
}

static IEnumerable<decimal> ParseAllDecimals(IEnumerable<string> input)
{
	return input.Select(str => decimal.Parse(str, null));
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