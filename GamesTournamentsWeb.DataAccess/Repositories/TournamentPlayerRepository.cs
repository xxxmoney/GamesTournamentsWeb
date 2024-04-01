using GamesTournamentsWeb.DataAccess.Contexts;
using GamesTournamentsWeb.DataAccess.Models.Tournaments;
using Microsoft.EntityFrameworkCore;

namespace GamesTournamentsWeb.DataAccess.Repositories;

public interface ITournamentPlayerRepository : IRepository
{
    ValueTask<TournamentPlayer> GetTournamentPlayerByIdAsync(int tournamentPlayerId);
    
    Task<List<TournamentPlayer>> GetTournamentPlayersForTournamentAsync(int tournamentId);
    
    Task<List<TournamentPlayer>> GetTournamentPlayersForAccountAsync(int accountId);

    Task<TournamentPlayer> GetTournamentPlayerByAccountAndTournamentAsync(int accountId, int tournamentId);
    
    void UpdateTournamentPlayer(TournamentPlayer tournamentPlayer);
}

public class TournamentPlayerRepository(WebContext context) : ITournamentPlayerRepository
{
    public Task<List<TournamentPlayer>> GetTournamentPlayersForTournamentAsync()
    {
        return context.TournamentPlayers.ToListAsync();
    }

    public ValueTask<TournamentPlayer> GetTournamentPlayerByIdAsync(int tournamentPlayerId)
    {
        return context.TournamentPlayers.FindAsync(tournamentPlayerId);
    }

    public Task<List<TournamentPlayer>> GetTournamentPlayersForTournamentAsync(int tournamentId)
    {
        return context.TournamentPlayers.Include(tp => tp.Tournament).Where(tp => tp.TournamentId == tournamentId).ToListAsync();
    }

    public Task<List<TournamentPlayer>> GetTournamentPlayersForAccountAsync(int accountId)
    {
        return context.TournamentPlayers.Include(tp => tp.Tournament).Where(tp => tp.AccountId == accountId).ToListAsync();
    }

    public Task<TournamentPlayer> GetTournamentPlayerByAccountAndTournamentAsync(int accountId, int tournamentId)
    {
        return context.TournamentPlayers.Include(tp => tp.Tournament).SingleOrDefaultAsync(tp => tp.AccountId == accountId && tp.TournamentId == tournamentId);
    }

    public void UpdateTournamentPlayer(TournamentPlayer tournamentPlayer)
    {
        context.TournamentPlayers.Update(tournamentPlayer);
    }
}