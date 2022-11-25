using Microsoft.AspNetCore.RateLimiting;
using System.Threading.RateLimiting;

namespace Sample13.RateLimiting.CustomPolicy;

public class CustomRateLimiterPolicy : IRateLimiterPolicy<string>
{
	private readonly ILogger<CustomRateLimiterPolicy> _logger;
	
	public CustomRateLimiterPolicy(ILogger<CustomRateLimiterPolicy> logger)
	{
		_logger = logger;
	}

	public Func<OnRejectedContext, CancellationToken, ValueTask> OnRejected => (ctx, _) =>
	{
		ctx.HttpContext.Response.StatusCode = StatusCodes.Status429TooManyRequests;
		_logger.LogWarning($"Request rejected by {nameof(CustomRateLimiterPolicy)}");
		return ValueTask.CompletedTask;
	};

	public RateLimitPartition<string> GetPartition(HttpContext httpContext)
	{
		FixedWindowRateLimiterOptions rateLimiterOptions = new()
		{
			PermitLimit = 4,
			QueueProcessingOrder = QueueProcessingOrder.OldestFirst,
			QueueLimit = 0,
			Window = TimeSpan.FromSeconds(5),
		};
		
		return RateLimitPartition.GetFixedWindowLimiter(string.Empty, _ => rateLimiterOptions);
	}
}
