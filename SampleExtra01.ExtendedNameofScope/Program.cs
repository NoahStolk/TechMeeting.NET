using System.Diagnostics.CodeAnalysis;

UserEntity userEntity = new()
{
	Name = "Noah",
};

UserModel userModel = MapToModel(userEntity);
Console.WriteLine(userModel);

[return: NotNullIfNotNull(nameof(user))]
static UserModel? MapToModel(UserEntity? user)
{
	if (user == null)
		return null;

	return new UserModel
	{
		Id = user.Id,
		Name = user.Name,
	};
}

public record UserEntity
{
	public long Id { get; } = Random.Shared.NextInt64();
	
	public required string Name { get; init; }
}

public record UserModel
{
	public required long Id { get; init; }
	
	public required string Name { get; init; }
}
