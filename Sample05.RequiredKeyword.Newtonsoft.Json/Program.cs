using Newtonsoft.Json;

const string userJson = """
	{
		"Name": "Noah"
	}
	""";

const string invalidUserJson = """
	{
	}
	""";

Console.WriteLine(JsonConvert.DeserializeObject<User>(userJson) ?? throw new());
Console.WriteLine(JsonConvert.DeserializeObject<User>(invalidUserJson) ?? throw new());

public record User
{
	public required string Name { get; init; }
}
