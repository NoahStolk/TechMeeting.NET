using Sample16.StaticAbstracts.MinimalApi.Endpoints;

namespace Sample16.StaticAbstracts.MinimalApi;

public static class EndpointExtensions
{
	public static void MapEndpoint(this IEndpointRouteBuilder builder, IEndpoint endpoint)
	{
		builder.MapMethods(
			endpoint.Path,
			new[] { endpoint.Method.ToString() },
			endpoint.Handler);
	}
}
