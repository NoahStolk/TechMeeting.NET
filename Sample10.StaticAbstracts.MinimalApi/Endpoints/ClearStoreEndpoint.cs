namespace Sample10.StaticAbstracts.MinimalApi.Endpoints;

public class ClearStoreEndpoint : IEndpoint
{
	public string Path => "store/clear";
	
	public HttpMethod Method => HttpMethod.Post;

	public Delegate Handler => Execute;

	private static IResult Execute(StorageService storage)
	{
		storage.Clear();
		return Results.Ok();
	}
}
