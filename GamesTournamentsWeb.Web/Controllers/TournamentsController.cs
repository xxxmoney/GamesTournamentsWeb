using GamesTournamentsWeb.Common.Enums.Tournament;
using GamesTournamentsWeb.Infrastructure.Dto.Tournaments;
using GamesTournamentsWeb.Infrastructure.Operations.Tournaments;
using GamesTournamentsWeb.Infrastructure.ViewModels.Tournaments;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace GamesTournamentsWeb.Web.Controllers;

public class TournamentsController(ITournamentOperation tournamentOperation, ITournamentPlayerOperation tournamentPlayerOperation, ITournamentCommentOperation tournamentCommentOperation) : BaseController
{
    [AllowAnonymous]
    [HttpPost("overviews")]
    public async Task<IActionResult> GetTournamentOverviews(TournamentFilter filter)
    {
        return Ok(await tournamentOperation.GetTournamentOverviewsPagedAsync(this.AccountId, filter));
    }
    
    [AllowAnonymous]
    [HttpGet("{tournamentId:int}")]
    public async Task<IActionResult> GetTournament(int tournamentId)
    {
        return Ok(await tournamentOperation.GetTournamentByIdAsync(tournamentId));
    }
    
    [AllowAnonymous]
    [HttpGet("{tournamentId:int}/players")]
    public async Task<IActionResult> GetTournamentPlayers(int tournamentId)
    {
        return Ok(await tournamentPlayerOperation.GetTournamentPlayersForTournamentAsync(tournamentId));
    }
    
    [AllowAnonymous]
    [HttpPost("{tournamentId:int}/join/{gameUsername}")]
    public async Task<IActionResult> JoinTournament(int tournamentId, string gameUsername)
    {
        await tournamentPlayerOperation.UpsertTournamentPlayerStatusAsync(null, this.AccountId!.Value,
            TournamentPlayerStatusEnum.Accepted, Uri.UnescapeDataString(gameUsername), tournamentId);
        var tournament = await tournamentOperation.SetBracketsFromTournamentMatchesAsync(tournamentId);
        return Ok(tournament);
    }
    
    [HttpPost("upsert")]
    public async Task<IActionResult> UpsertTournament(TournamentEdit tournamentEdit)
    {
        return Ok(await tournamentOperation.UpsertTournamentAsync(tournamentEdit));
    }
    
    [HttpDelete("{tournamentId:int}/delete")]
    public async Task<IActionResult> DeleteTournament(int tournamentId)
    {
        await tournamentOperation.DeleteTournamentByIdAsync(tournamentId);
        return Ok();
    }
    
    [HttpPut("match/update")]
    public async Task<IActionResult> UpdateTournamentMatch(MatchEdit matchEdit)
    { 
        return Ok(await tournamentOperation.UpdateTournamentMatchAsync(matchEdit));
    }
    
    [HttpPost("comment/create")]
    public async Task<IActionResult> CreateTournamentComment(TournamentCommentEdit commentEdit)
    {
        if (!this.AccountId.HasValue)
        {
            return Unauthorized();
        }
        
        return Ok(await tournamentCommentOperation.CreateTournamentCommentAsync(this.AccountId.Value, commentEdit));
    }
    
    
}