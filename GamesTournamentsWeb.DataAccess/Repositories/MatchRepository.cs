using GamesTournamentsWeb.DataAccess.Contexts;
using GamesTournamentsWeb.DataAccess.Models.Tournaments;
using Microsoft.EntityFrameworkCore;

namespace GamesTournamentsWeb.DataAccess.Repositories;

public interface IMatchRepository : IRepository
{
    Task<List<Match>> GetCurrenciesAsync();
}

public class MatchRepository(WebContext context) : IMatchRepository
{
    public Task<List<Match>> GetCurrenciesAsync()
    {
        return context.Matches.ToListAsync();
    }
}