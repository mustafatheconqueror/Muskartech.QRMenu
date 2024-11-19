using Microsoft.AspNetCore.Mvc;
using Muskartech.QRMenu.Application.Features.Commands.Token;
using Muskartech.QRMenu.Infrastructure.Authentication;

namespace Muskartech.QRMenu.API.Controllers;

[Route("api/token")]
[ApiController]
public class TokenController : ControllerBase
{
    private readonly IAuthenticationService _authenticationService;

    public TokenController(IAuthenticationService authenticationService)
    {
        _authenticationService = authenticationService;
    }

    [HttpPost("new")]
    public IActionResult New([FromBody] NewTokenCommand user)
    {
        var loginResult = _authenticationService.Login(user.UserName, user.Password);

        if (!loginResult.Succeed)
        {
            return Unauthorized();
        }

        var token = _authenticationService.GenerateToken(loginResult.User);
        return Ok(token);
    }
}