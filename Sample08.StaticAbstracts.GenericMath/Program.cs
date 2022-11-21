namespace Sample08.StaticAbstracts.GenericMath;

public static class Program
{
	public static void Main()
	{
		Console.WriteLine(SumInt(new[] { 1, 2, 3, 4 }));
		Console.WriteLine(SumDouble(new[] { 1, 2, 3, 4.5 }));
	}
	
	private static int SumInt(IEnumerable<int> arr)
	{
		int result = 0;
		foreach (int i in arr)
			result += i;

		return result;
	}

	private static double SumDouble(IEnumerable<double> arr)
	{
		double result = 0;
		foreach (double d in arr)
			result += d;

		return result;
	}
}
