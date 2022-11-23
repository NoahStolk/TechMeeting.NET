using Sample09.StaticAbstracts.Factory;

while (true)
{
	string? input = Console.ReadLine();
	if (input != null)
		ParseAndExecute(input);
}

static void ParseAndExecute(string input)
{
	string[] splitInputs = input.Split(' ');
	string[] arguments = splitInputs[1..];

	Action command = splitInputs[0] switch
	{
		"circle" => Execute<CircleCommand>,
		"rectangle" => Execute<RectangleCommand>,
		_ => Execute<DefaultCommand>,
	};
	
	command();
	
	void Execute<TCommand>()
		where TCommand : ICommand<TCommand>
	{
		TCommand command;
		
		try
		{
			command = TCommand.Parse(arguments);
		}
		catch (ArgumentException ex)
		{
			Console.WriteLine(ex.Message);
			return;
		}
		
		command.Execute();
	}
}
