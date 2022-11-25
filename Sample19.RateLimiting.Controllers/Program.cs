using Microsoft.AspNetCore.RateLimiting;
using Sample12.RateLimiting.Controllers;
using System.Threading.RateLimiting;

WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services
	.AddRateLimiter(_ => _
		.AddFixedWindowLimiter(policyName: PolicyNames.Fixed3Sec, options =>
		{
			options.PermitLimit = 1;
			options.Window = TimeSpan.FromSeconds(3);
			options.QueueProcessingOrder = QueueProcessingOrder.OldestFirst;
			options.QueueLimit = 2;
		}))
	.AddRateLimiter(_ => _
		.AddFixedWindowLimiter(policyName: PolicyNames.Fixed10Sec, options =>
		{
			options.PermitLimit = 5;
			options.Window = TimeSpan.FromSeconds(10);
			options.QueueProcessingOrder = QueueProcessingOrder.OldestFirst;
			options.QueueLimit = 2;
		}));

WebApplication app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();

app.UseHttpsRedirection();

app.UseAuthorization();

app.UseRateLimiter();

app.MapControllers();

app.Run();
