using GamesTournamentsWeb.Infrastructure.Dto.Games;
using GamesTournamentsWeb.Infrastructure.Operations.Games;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace GamesTournamentsWeb.Web.Controllers;

public class GamesController(IGameOperation gameOperation) : BaseController
{
    [AllowAnonymous]
    [HttpPost("")]
    public async Task<IActionResult> GetGames([FromBody] GameFilter filter)
    {
        return Ok(await gameOperation.GetGamesPagedAsync(filter));
    }
    
    [AllowAnonymous]
    [HttpPost("overviews")]
    public async Task<IActionResult> GetGameOverviews()
    {
        return Ok(await gameOperation.GetGameOverviewsAsync());
    }
}