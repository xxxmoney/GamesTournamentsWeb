using GamesTournamentsWeb.DataAccess.Contexts;
using GamesTournamentsWeb.DataAccess.Models.Tournaments;
using Microsoft.EntityFrameworkCore;

namespace GamesTournamentsWeb.DataAccess.Repositories;

public interface ITournamentPlayerRepository : IRepository
{
    Task<List<TournamentPlayer>> GetCurrenciesAsync();
}

public class TournamentPlayerRepository(WebContext context) : ITournamentPlayerRepository
{
    public Task<List<TournamentPlayer>> GetCurrenciesAsync()
    {
        return context.TournamentPlayers.ToListAsync();
    }
}