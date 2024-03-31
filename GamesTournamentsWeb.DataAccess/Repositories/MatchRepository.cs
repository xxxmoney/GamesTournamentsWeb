using GamesTournamentsWeb.DataAccess.Contexts;
using GamesTournamentsWeb.DataAccess.Models.Tournaments;
using Microsoft.EntityFrameworkCore;

namespace GamesTournamentsWeb.DataAccess.Repositories;

public interface IMatchRepository : IRepository
{
    Task<List<Match>> GetMatchesAsync();
    
    Task<List<Match>> GetMatchesByAccountIdAsync(int accountId);
    
    ValueTask<Match> GetMatchByIdAsync(int matchId);
    
    void UpdateMatch(Match match);
}

public class MatchRepository(WebContext context) : IMatchRepository
{
    public Task<List<Match>> GetMatchesAsync()
    {
        return context.Matches.ToListAsync();
    }

    public Task<List<Match>> GetMatchesByAccountIdAsync(int accountId)
    {
        var teamIds = context.Teams.Include(team => team.Players)
            .Where(team => team.Players.Any(player => player.AccountId == accountId))
            .Select(team => team.Id)
            .ToArray();

        return context.Matches.Include(match => match.Tournament).Include(match => match.Tournament.Game).Where(match =>
            teamIds.Contains(match.FirstTeamId ?? -1) || teamIds.Contains(match.SecondTeamId ?? -1)).ToListAsync();
    }

    public ValueTask<Match> GetMatchByIdAsync(int matchId)
    {
        return context.Matches.FindAsync(matchId);
    }

    public void UpdateMatch(Match match)
    {
        context.Matches.Update(match);
    }
}