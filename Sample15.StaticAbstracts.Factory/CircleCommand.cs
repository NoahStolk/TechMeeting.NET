using System.Numerics;

namespace Sample15.StaticAbstracts.Factory;

public record CircleCommand(int Radius) : ICommand<CircleCommand>
{
	private const int Min = 1;
	private const int Max = 100;
	
	public static CircleCommand Parse(string[] arguments)
	{
		if (arguments.Length != 1)
			throw new ArgumentException("Usage: circle <radius>");

		if (!int.TryParse(arguments[0], out int radius) || radius is < Min or > Max)
			throw new ArgumentException($"Radius must be between {Min} and {Max}");

		return new(radius);
	}
	
	public void Execute()
	{
		float lineThickness = 0.5f / Radius;

		for (int i = 0; i <= Radius; i++)
		{
			for (int j = 0; j <= Radius; j++)
			{
				float normalizedX = i / (float)Radius;
				float normalizedY = j / (float)Radius;

				float distance = Vector2.Distance(new(0.5f), new(normalizedX, normalizedY));
				bool isHit = distance > 0.5f - lineThickness && distance < 0.5f + lineThickness;
				Console.Write(isHit ? "O" : ".");
			}
			
			Console.WriteLine();
		}
	}
}
