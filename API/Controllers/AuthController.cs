using BusinessLogicLayer.Dtos.Auth;
using BusinessLogicLayer.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;
[Route("api/[controller]")]
[ApiController]
public class AuthController(IUserService userService) 
    : ControllerBase
{
    private readonly IUserService _userService = userService;

    [HttpPost("register")]
    public async Task<IActionResult> RegisterAsync(RegisterUserDto dto)
    {
        var result = await _userService.RegisterAsync(dto);
        if (!result.IsSuccess)
        {
            return BadRequest(result.ErrorMessages);
        }

        return Ok();
    }

    [HttpPost("login")]
    public async Task<IActionResult> LoginAsync(LoginUserDto dto)
    {
        var result = await _userService.LoginAsync(dto);
        if (!result.IsSuccess)
        {
            return BadRequest(result.ErrorMessages);
        }

        return Ok();
    }
}
