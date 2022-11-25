using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.RateLimiting;

namespace Sample12.RateLimiting.Controllers.Controllers;

[ApiController]
[Route("[controller]")]
[EnableRateLimiting(PolicyNames.Fixed3Sec)]
public class Controller : ControllerBase
{
	[HttpGet]
	public string Get()
	{
		return $"Time: {DateTime.Now:T}";
	}

	[HttpGet("10-sec")]
	[EnableRateLimiting(PolicyNames.Fixed10Sec)]
	public string Fixed10Sec()
	{
		return $"Time: {DateTime.Now:T}";
	}

	[HttpGet("no-limit")]
	[DisableRateLimiting]
	public string NoLimit()
	{
		return $"Time: {DateTime.Now:T}";
	}
}
