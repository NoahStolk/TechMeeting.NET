using Sample13.RateLimiting.CustomPolicy;

const string fixedRateLimiterPolicy = nameof(fixedRateLimiterPolicy);

WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddRateLimiter(limiterOptions => limiterOptions.AddPolicy<string, CustomRateLimiterPolicy>(fixedRateLimiterPolicy));

WebApplication app = builder.Build();

app.UseRateLimiter();

app.MapGet("/", () => Results.Ok($"Time: {DateTime.Now:T}")).RequireRateLimiting(fixedRateLimiterPolicy);

app.UseSwagger();
app.UseSwaggerUI();

app.UseHttpsRedirection();

app.Run();
