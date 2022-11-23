namespace Sample09.StaticAbstracts.Factory;

public record RectangleCommand(int Width, int Height) : ICommand<RectangleCommand>
{
	private const int Min = 1;
	private const int Max = 100;
	
	public static RectangleCommand Parse(string[] arguments)
	{
		if (arguments.Length != 2)
			throw new ArgumentException("Usage: rectangle <width> <height>");

		if (!int.TryParse(arguments[0], out int width) || width is < Min or > Max)
			throw new ArgumentException($"Width must be between {Min} and {Max}");

		if (!int.TryParse(arguments[1], out int height) || height is < Min or > Max)
			throw new ArgumentException($"Height must be between {Min} and {Max}");

		return new(width, height);
	}
	
	public void Execute()
	{
		for (int i = 0; i < Width; i++)
		{
			for (int j = 0; j < Height; j++)
			{
				bool isFilled = i == 0 || j == 0 || i == Width - 1 || j == Height - 1;
				Console.Write(isFilled ? "O" : ".");
			}
			
			Console.WriteLine();
		}
	}
}
