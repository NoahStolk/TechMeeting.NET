using System.Text.Json;

const string userJson = """
	{
		"Name": "Noah"
	}
	""";

const string invalidUserJson = """
	{
	}
	""";

Console.WriteLine(JsonSerializer.Deserialize<User>(userJson) ?? throw new JsonException());
Console.WriteLine(JsonSerializer.Deserialize<User>(invalidUserJson) ?? throw new JsonException());

public record User
{
	public required string Name { get; init; }
}
