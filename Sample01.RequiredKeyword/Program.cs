User user = new()
{
	Name = "Noah",
};

Console.WriteLine(user.Name);

public record User
{
	public required string Name { get; init; }
}
