IEnumerable<int> ints = ParseAll<int>(new[] { "1", "2", "3" }, null);
IEnumerable<float> floats = ParseAll<float>(new[] { "1.5", "2.25", "3.125" }, null);

Console.WriteLine(string.Join(' ', ints));
Console.WriteLine(string.Join(' ', floats));

static IEnumerable<T> ParseAll<T>(IEnumerable<string> input, IFormatProvider? formatProvider)
	where T : IParsable<T>
{
	return input.Select(str => T.Parse(str, formatProvider));
}
