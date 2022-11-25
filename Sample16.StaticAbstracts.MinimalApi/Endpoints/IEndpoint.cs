namespace Sample16.StaticAbstracts.MinimalApi.Endpoints;

public interface IEndpoint
{
	string Path { get; }
	
	HttpMethod Method { get; }

	Delegate Handler { get; }
}
