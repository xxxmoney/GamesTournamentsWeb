using GamesTournamentsWeb.Infrastructure.Operations.Tournaments;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace GamesTournamentsWeb.Web.Controllers;

public class PlatformsController(IPlatformOperation platformOperation) : BaseController
{
    [AllowAnonymous]
    [HttpGet("")]
    public async Task<IActionResult> GetPlatforms()
    {
        return Ok(await platformOperation.GetPlatformsAsync());
    }
}