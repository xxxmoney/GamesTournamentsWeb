using GamesTournamentsWeb.Infrastructure.Dto.Auth;
using GamesTournamentsWeb.Infrastructure.Exceptions;
using GamesTournamentsWeb.Infrastructure.Operations.Auth;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace GamesTournamentsWeb.Web.Controllers;

public class AuthController(IAuthOperation authOperation) : BaseController
{
    [AllowAnonymous]
    [HttpPost("register")]
    public async Task<IActionResult> Register(Register register)
    {
        var result = await authOperation.RegisterAsync(register);
        return Ok(result);
    }
    
    [AllowAnonymous]
    [HttpPost("login")]
    public async Task<IActionResult> Login(Login login)
    {
        try
        {
            var result = await authOperation.LoginAsync(login);
            return Ok(result);
        }
        catch (AccountNotFoundException)
        {
            return Unauthorized();
        }
        catch (AccountAuthenticationInvalid)
        {
            return Unauthorized(); 
        }
    }
    
    [HttpGet("test")]
    public IActionResult Test()
    {
        return Ok("Nice");
    }
    
    [HttpPut("changePassword")]
    public async Task<IActionResult> ChangePassword(ChangePassword changePassword)
    {
        try
        {
            if (!this.AccountId.HasValue)
            {
                return Unauthorized();
            }
            
            await authOperation.ChangePasswordAsync(this.AccountId.Value, changePassword);
            return Ok();
        }
        catch (AccountNotFoundException)
        {
            return NotFound();
        }
    }
    
}