using GamesTournamentsWeb.DataAccess.Contexts;
using GamesTournamentsWeb.DataAccess.Models.Tournaments;
using Microsoft.EntityFrameworkCore;

namespace GamesTournamentsWeb.DataAccess.Repositories;

public interface IMatchRepository : IRepository
{
    Task<List<Match>> GetMatchesAsync();
    
    Task<List<MatchWithPlayers>> GetMatchesWithPlayersByAccountIdAsync(int accountId);
    
    ValueTask<Match> GetMatchByIdAsync(int matchId);
    
    void UpdateMatch(Match match);
}

public class MatchRepository(WebContext context) : IMatchRepository
{
    public Task<List<Match>> GetMatchesAsync()
    {
        return context.Matches.ToListAsync();
    }

    public async Task<List<MatchWithPlayers>> GetMatchesWithPlayersByAccountIdAsync(int accountId)
    {
        var teams = await context.Teams.Include(team => team.Players)
            .Where(team => team.Players.Any(player => player.AccountId == accountId))
            .ToListAsync();
        var teamIds = teams.Select(team => team.Id)
            .ToArray();

        var matches = await context.Matches.Include(match => match.Tournament).Include(match => match.Tournament.Game).Where(match =>
            teamIds.Contains(match.FirstTeamId ?? -1) || teamIds.Contains(match.SecondTeamId ?? -1)).ToListAsync();

        return matches.Select(m => new MatchWithPlayers
        {
            Match = m,
            Players = teams.Where(t => m.FirstTeamId == t.Id || m.SecondTeamId == t.Id).SelectMany(t => t.Players).ToList()
        }).ToList();
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