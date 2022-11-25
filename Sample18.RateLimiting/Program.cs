using Microsoft.AspNetCore.RateLimiting;
using System.Threading.RateLimiting;

const string fixedRateLimiterPolicy = nameof(fixedRateLimiterPolicy);

WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Add a fixed window limiter. Other limiters are: sliding window, token bucket, concurrency.
builder.Services.AddRateLimiter(_ => _
	.AddFixedWindowLimiter(policyName: fixedRateLimiterPolicy, options =>
	{
		options.PermitLimit = 4;
		options.Window = TimeSpan.FromSeconds(5);
		options.QueueProcessingOrder = QueueProcessingOrder.OldestFirst;
		options.QueueLimit = 2;
	}));

WebApplication app = builder.Build();

app.UseRateLimiter();

app.MapGet("/", () => Results.Ok($"Time: {DateTime.Now:T}")).RequireRateLimiting(fixedRateLimiterPolicy);

app.UseSwagger();
app.UseSwaggerUI();

app.UseHttpsRedirection();

app.Run();
