using Microsoft.AspNetCore.Mvc;

namespace AuthenticationDemo;

[ApiController]
[Route("api/auth")]
public class Controller:ControllerBase
{
    [HttpPost]
    [Route("login")]
    public IActionResult Login()
    {
        return Ok();
    }

    [HttpPost]
    [Route("logout")]
    public IActionResult Logout()
    {
        return Ok();
    }
}