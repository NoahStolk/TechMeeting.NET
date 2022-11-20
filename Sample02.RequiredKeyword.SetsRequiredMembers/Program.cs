using System.Diagnostics.CodeAnalysis;

User user1 = new()
{
	Name = "Noah",
};

Console.WriteLine(user1.Name);

User user2 = new("Noah");
Console.WriteLine(user2.Name);

public record User
{
	public required string Name { get; init; }

	public User()
	{
	}

	[SetsRequiredMembers]
	public User(string name)
	{
		Name = name;
	}
}
