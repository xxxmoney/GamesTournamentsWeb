using GamesTournamentsWeb.DataAccess.Models.Tournaments;
using Microsoft.EntityFrameworkCore;

namespace GamesTournamentsWeb.DataAccess.Repositories;

public interface IMatchRepository : IRepository
{
    Task<List<Match>> GetCurrenciesAsync();
}

public class MatchRepository(DbSet<Match> matches) : IMatchRepository
{
    public Task<List<Match>> GetCurrenciesAsync()
    {
        return matches.ToListAsync();
    }
}