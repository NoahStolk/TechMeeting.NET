namespace Sample16.StaticAbstracts.MinimalApi.Endpoints;

public class AddKeyToStoreEndpoint : IEndpoint
{
	public string Path => "store";
	
	public HttpMethod Method => HttpMethod.Post;
	
	public Delegate Handler => Execute;

	private static IResult Execute(StorageService storage, string key, string value)
	{
		storage.Add(key, value);
		return Results.Ok();
	}
}
