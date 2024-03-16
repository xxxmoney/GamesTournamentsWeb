using GamesTournamentsWeb.DataAccess.Models.Tournaments;
using Microsoft.EntityFrameworkCore;

namespace GamesTournamentsWeb.DataAccess.Repositories;

public interface ITeamRepository : IRepository
{
    Task<List<Team>> GetCurrenciesAsync();
}

public class TeamRepository(DbSet<Team> teams) : ITeamRepository
{
    public Task<List<Team>> GetCurrenciesAsync()
    {
        return teams.ToListAsync();
    }
}