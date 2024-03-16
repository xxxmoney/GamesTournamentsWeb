using GamesTournamentsWeb.DataAccess.Models.Tournaments;
using Microsoft.EntityFrameworkCore;

namespace GamesTournamentsWeb.DataAccess.Repositories;

public interface ITournamentPlayerRepository : IRepository
{
    Task<List<TournamentPlayer>> GetCurrenciesAsync();
}

public class TournamentPlayerRepository(DbSet<TournamentPlayer> teamPlayers) : ITournamentPlayerRepository
{
    public Task<List<TournamentPlayer>> GetCurrenciesAsync()
    {
        return teamPlayers.ToListAsync();
    }
}