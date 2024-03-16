using GamesTournamentsWeb.Common.Models;
using GamesTournamentsWeb.DataAccess.Extensions;
using GamesTournamentsWeb.DataAccess.Models.Tournaments;
using Microsoft.EntityFrameworkCore;

namespace GamesTournamentsWeb.DataAccess.Repositories;

public interface ITournamentRepository : IRepository
{
    Task<PagedResult<TournamentOverview>> GetTournamentOverviewsAsync(int page, int count);
    
    ValueTask<Tournament> GetTournamentByIdAsync(int id);
}

public class TournamentRepository(DbSet<Tournament> tournaments) : ITournamentRepository
{
    public Task<PagedResult<TournamentOverview>> GetTournamentOverviewsAsync(int page, int count)
    {
        return tournaments.Select(t => new TournamentOverview
        {
            Id = t.Id,
            Name = t.Name
        }).ToPagedAsync(page, count);
    }

    public ValueTask<Tournament> GetTournamentByIdAsync(int id)
    {
        return tournaments.FindAsync(id);
    }
}