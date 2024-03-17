using GamesTournamentsWeb.Infrastructure.Operations.Users;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace GamesTournamentsWeb.Web.Controllers;

public class AccountsController(IAccountOperation accountOperation) : BaseController
{
    [HttpGet("{accountId}/info")]
    public async Task<IActionResult> GetAccountInfo([FromQuery] int accountId)
    {
        return Ok(await accountOperation.GetAccountInfoByIdAsync(accountId));
    }
    
    [HttpGet("{accountId}/history")]
    public async Task<IActionResult> GetHistory([FromQuery] int accountId)
    {
        return Ok(await accountOperation.GetHistoryItemsByIdAsync(accountId));
    }
    
    [AllowAnonymous]
    [HttpGet("")]
    public async Task<IActionResult> GetAccounts()
    {
        return Ok(await accountOperation.GetAccountsAsync());
    }
}
