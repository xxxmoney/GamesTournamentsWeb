using GamesTournamentsWeb.Infrastructure.Operations.Tournaments;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace GamesTournamentsWeb.Web.Controllers;

public class RegionsController(IRegionOperation regionOperation) : BaseController
{
    [AllowAnonymous]
    [HttpGet("")]
    public async Task<IActionResult> GetRegions()
    {
        return Ok(await regionOperation.GetRegionsAsync());
    }
}