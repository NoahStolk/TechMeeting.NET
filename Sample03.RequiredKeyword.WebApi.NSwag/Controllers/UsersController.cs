using Microsoft.AspNetCore.Mvc;
using Sample03.RequiredKeyword.WebApi.NSwag.Models;

namespace Sample03.RequiredKeyword.WebApi.NSwag.Controllers;

[ApiController]
[Route("[controller]")]
public class UsersController : ControllerBase
{
	[HttpPost]
	public void Post(User user)
	{
		Console.WriteLine(user);
	}
}
