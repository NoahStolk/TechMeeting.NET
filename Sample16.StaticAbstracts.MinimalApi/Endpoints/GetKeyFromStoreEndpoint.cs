namespace Sample16.StaticAbstracts.MinimalApi.Endpoints;

public class GetKeyFromStoreEndpoint : IEndpoint
{
	public string Path => "store/{key}";
	
	public HttpMethod Method => HttpMethod.Get;

	public Delegate Handler => Execute;

	private static IResult Execute(StorageService storage, string key)
	{
		return Results.Ok(storage.GetByKey(key));
	}
}
