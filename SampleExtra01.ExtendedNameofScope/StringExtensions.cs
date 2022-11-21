using System.Diagnostics.CodeAnalysis;

namespace SampleExtra01.ExtendedNameofScope;

public static class StringExtensions
{
	[return: NotNullIfNotNull(nameof(str))]
	public static string? TrimEnd(string? str, string trim)
	{
		if (str == null)
			return null;

		return str.EndsWith(trim) ? str[..trim.Length] : str;
	}
}
