using Microsoft.AspNetCore.Mvc;

namespace GymHelperAPI.Controllers;
[ApiController]
[Route("/")]
public class CommonController : ControllerBase
{
    [HttpGet("ping")]
    public IActionResult Ping()
    {
        return Ok("Gym Helper service. Version 1.0.1");
    }
}