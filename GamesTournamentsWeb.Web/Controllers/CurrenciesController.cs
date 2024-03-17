using GamesTournamentsWeb.Infrastructure.Operations.Tournaments;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace GamesTournamentsWeb.Web.Controllers;

public class CurrenciesController(ICurrencyOperation currencyOperation) : BaseController
{     
    [AllowAnonymous]
    [HttpGet("")]
    public async Task<IActionResult> GetCurrencies()
    {
        return Ok(await currencyOperation.GetCurrenciesAsync());
    } 
}