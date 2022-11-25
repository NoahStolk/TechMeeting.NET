namespace Sample03.RequiredKeyword.WebApi.NSwag.Models;

public record User
{
	public required string Name { get; init; }
	
	public required int Age { get; init; }
}
