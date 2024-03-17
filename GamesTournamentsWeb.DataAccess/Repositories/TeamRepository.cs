using GamesTournamentsWeb.DataAccess.Contexts;
using GamesTournamentsWeb.DataAccess.Models.Tournaments;
using Microsoft.EntityFrameworkCore;

namespace GamesTournamentsWeb.DataAccess.Repositories;

public interface ITeamRepository : IRepository
{
    Task<List<Team>> GetCurrenciesAsync();
}

public class TeamRepository(WebContext context) : ITeamRepository
{
    public Task<List<Team>> GetCurrenciesAsync()
    {
        return context.Teams.ToListAsync();
    }
}