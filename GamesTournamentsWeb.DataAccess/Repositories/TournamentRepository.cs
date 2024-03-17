using System.Linq.Expressions;
using GamesTournamentsWeb.Common.Models;
using GamesTournamentsWeb.DataAccess.Contexts;
using GamesTournamentsWeb.DataAccess.Extensions;
using GamesTournamentsWeb.DataAccess.Models.Tournaments;
using Microsoft.EntityFrameworkCore;

namespace GamesTournamentsWeb.DataAccess.Repositories;

public interface ITournamentRepository : IRepository
{
    Task<PagedResult<TournamentOverview>> GetTournamentOverviewsFilteredPagedAsync(Expression<Func<Tournament, bool>> filter, int page, int count);
    
    ValueTask<Tournament> GetTournamentByIdAsync(int id);
}

public class TournamentRepository(WebContext context) : ITournamentRepository
{
    public Task<PagedResult<TournamentOverview>> GetTournamentOverviewsFilteredPagedAsync(Expression<Func<Tournament, bool>> filter, int page, int count)
    {
        return context.Tournaments.Where(filter).Select(t => new TournamentOverview
        {
            Id = t.Id,
            Name = t.Name
        }).ToPagedAsync(page, count);
    }

    public ValueTask<Tournament> GetTournamentByIdAsync(int id)
    {
        return context.Tournaments.FindAsync(id);
    }
}