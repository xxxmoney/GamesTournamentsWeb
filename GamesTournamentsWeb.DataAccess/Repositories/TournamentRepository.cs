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
    
    Task<Tournament> GetTournamentByIdAsync(int id);
    
    void UpdateTournament(Tournament tournament);
    
    Task AddTournamentAsync(Tournament tournament);
    
}

public class TournamentRepository(WebContext context) : ITournamentRepository
{
    private IQueryable<Tournament> GetTournamentsWithIncludes() => context.Tournaments
        .Include(t => t.Game)
        .Include(t => t.Platform)
        .Include(t => t.Regions)
        .Include(t => t.Prizes)
        .Include(t => t.Players)
        .Include(t => t.Matches)
        .Include(t => t.Streams)
        .Include(t => t.Admins);
    
    public Task<PagedResult<TournamentOverview>> GetTournamentOverviewsFilteredPagedAsync(Expression<Func<Tournament, bool>> filter, int page, int count)
    {
        return context.Tournaments.Where(filter).Select(t => new TournamentOverview
        {
            Id = t.Id,
            Name = t.Name
        }).ToPagedAsync(page, count);
    }

    public Task<Tournament> GetTournamentByIdAsync(int id)
    {
        return this.GetTournamentsWithIncludes().SingleOrDefaultAsync(tournament => tournament.Id == id);
    }

    public void UpdateTournament(Tournament tournament)
    {
        context.Tournaments.Update(tournament);
    }

    public async Task AddTournamentAsync(Tournament tournament)
    {
        await context.Tournaments.AddAsync(tournament);
    }
}