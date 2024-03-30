using GamesTournamentsWeb.Common.Enums.Tournament;
using GamesTournamentsWeb.Infrastructure.Exceptions;
using GamesTournamentsWeb.Infrastructure.Operations.Tournaments;
using GamesTournamentsWeb.Infrastructure.Operations.Users;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace GamesTournamentsWeb.Web.Controllers;

public class AccountsController(IAccountOperation accountOperation, ITournamentPlayerOperation tournamentPlayerOperation, ITournamentOperation tournamentOperation) : BaseController
{
    [HttpGet("mine/info")]
    public async Task<IActionResult> GetAccountInfo()
    {
        if (!this.AccountId.HasValue)
        {
            return Unauthorized();
        }
        
        return Ok(await accountOperation.GetAccountInfoByIdAsync(this.AccountId.Value));
    }
    
    [HttpGet("mine/history")]
    public async Task<IActionResult> GetHistory()
    {
        if (!this.AccountId.HasValue)
        {
            return Unauthorized();
        }   
        
        return Ok(await accountOperation.GetHistoryItemsByIdAsync(this.AccountId.Value));
    }
    
    [HttpGet("mine/invitations")]
    public async Task<IActionResult> GetTournamentInvitations()
    {
        if (!this.AccountId.HasValue)
        {
            return Unauthorized();
        }
        
        return Ok(await tournamentPlayerOperation.GetTournamentPlayersForAccountAsync(this.AccountId.Value));
    }
    
    [HttpPut("mine/invitations/{invitationId}/accept/{gameUsername}")]
    public async Task<IActionResult> AcceptTournamentInvitation(int invitationId, string gameUsername)
    {
        if (!this.AccountId.HasValue)
        {
            return Unauthorized();
        }

        var result = await tournamentPlayerOperation.ChangeTournamentPlayerStatusAsync(invitationId,
            this.AccountId.Value, TournamentPlayerStatusEnum.Accepted, gameUsername);
        // Tournament player accepted, update matches
        await tournamentOperation.UpdateTournamentMatchesAsync(result.TournamentId);
        
        return Ok();
    }
    
    [HttpPut("mine/invitations/{invitationId}/reject")]
    public async Task<IActionResult> RejectTournamentInvitation(int invitationId)
    {
        if (!this.AccountId.HasValue)
        {
            return Unauthorized();
        }
        
        return Ok(await tournamentPlayerOperation.ChangeTournamentPlayerStatusAsync(invitationId, this.AccountId.Value, TournamentPlayerStatusEnum.Rejected));
    }
    
    [AllowAnonymous]
    [HttpGet("")]
    public async Task<IActionResult> GetAccounts()
    {
        return Ok(await accountOperation.GetAccountsAsync());
    }
}
