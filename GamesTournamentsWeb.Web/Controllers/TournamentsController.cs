using GamesTournamentsWeb.Infrastructure.Dto.Tournaments;
using GamesTournamentsWeb.Infrastructure.Operations.Tournaments;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace GamesTournamentsWeb.Web.Controllers;

public class TournamentsController(ITournamentOperation tournamentOperation) : BaseController
{
    [AllowAnonymous]
    [HttpPost("overviews")]
    public async Task<IActionResult> GetTournamentOverviews(TournamentFilter filter)
    {
        return Ok(await tournamentOperation.GetTournamentOverviewsPagedAsync(filter));
    }
    
    [AllowAnonymous]
    [HttpGet("{tournamentId}")]
    public async Task<IActionResult> GetTournament(int tournamentId)
    {
        return Ok(await tournamentOperation.GetTournamentByIdAsync(tournamentId));
    }
    
}