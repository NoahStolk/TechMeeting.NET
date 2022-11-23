namespace Sample09.StaticAbstracts.Factory;

public class DefaultCommand : ICommand<DefaultCommand>
{
	public static DefaultCommand Parse(string[] arguments)
	{
		return new();
	}
	
	public void Execute()
	{
		Console.WriteLine("Available commands: circle, rectangle");
	}
}
