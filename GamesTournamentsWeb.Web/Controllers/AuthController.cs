using GamesTournamentsWeb.Infrastructure.Dto.Auth;
using GamesTournamentsWeb.Infrastructure.Exceptions;
using GamesTournamentsWeb.Infrastructure.Operations.Auth;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace GamesTournamentsWeb.Web.Controllers;

public class AuthController(IAuthOperation authOperation) : BaseController
{
    [AllowAnonymous]
    [HttpPost(nameof(Register))]
    public async Task<IActionResult> Register(Register register)
    {
        var result = await authOperation.RegisterAsync(register);
        return Ok(result);
    }
    
    [AllowAnonymous]
    [HttpPost(nameof(Login))]
    public async Task<IActionResult> Login(Login login)
    {
        try
        {
            var result = await authOperation.LoginAsync(login);
            return Ok(result);
        }
        catch (AccountNotFoundException e)
        {
            return Unauthorized();
        }
        catch (AccountAuthenticationInvalid e)
        {
            return Unauthorized(); 
        }
    }
    
}