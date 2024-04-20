using GamesTournamentsWeb.DataAccess.Contexts;
using GamesTournamentsWeb.DataAccess.Models.Tournaments;
using Microsoft.EntityFrameworkCore;

namespace GamesTournamentsWeb.DataAccess.Repositories;

public interface ITeamRepository : IRepository
{
    Task<List<Team>> GetTeamsAsync();
    
    Task<List<Team>> GetTeamsByIdsAsync(int[] teamIds);
    Task<List<Team>> GetTeamsWithPlayersByIdsAsync(int[] teamIds);
    
    void RemoveTeams(ICollection<Team> teams);
    
    Task AddTeamAsync(Team team);
}

public class TeamRepository(WebContext context) : ITeamRepository
{
    public Task<List<Team>> GetTeamsAsync()
    {
        return context.Teams.ToListAsync();
    }

    public Task<List<Team>> GetTeamsByIdsAsync(int[] teamIds)
    {
        return context.Teams.Where(t => teamIds.Contains(t.Id)).ToListAsync();
    }

    public Task<List<Team>> GetTeamsWithPlayersByIdsAsync(int[] teamIds)
    {
        return context.Teams.Include(t => t.Players).Where(t => teamIds.Contains(t.Id)).ToListAsync();
    }

    public void RemoveTeams(ICollection<Team> teams)
    {
        context.Teams.RemoveRange(teams);
    }

    public Task AddTeamAsync(Team team)
    {
        return context.Teams.AddAsync(team).AsTask();
    }
}