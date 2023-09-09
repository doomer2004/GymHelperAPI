using Microsoft.AspNetCore.Mvc;
using GymAPI.BLL;
using GymAPI.BLL.Services.Interfaces;
using GymAPI.Common.DTO;

namespace GymHelperAPI.Controllers;
[ApiController]
[Route("[controller]")]
public class AuthController : ControllerBase
{
    private readonly IAuthService _authService;

    public AuthController(IAuthService authService)
    {
        _authService = authService;
    }

    [HttpPost("[action]")]
    public async Task<IActionResult> Register(RegisterUserDTO userDto)
    {
        return Ok(await _authService.RegisterAsync(userDto));
    }

    [HttpPost("[action]")]
    public async Task<IActionResult> Login(LoginUserDTO userDto)
    {
        return Ok(await _authService.LoginAsync(userDto));
    }
}