using System.Linq.Expressions;
using GamesTournamentsWeb.Common.Models;
using GamesTournamentsWeb.DataAccess.Contexts;
using GamesTournamentsWeb.DataAccess.Extensions;
using GamesTournamentsWeb.DataAccess.Models.Games;
using Microsoft.EntityFrameworkCore;

namespace GamesTournamentsWeb.DataAccess.Repositories;

public interface IGameRepository : IRepository
{
    Task<PagedResult<Game>> GetGamesFilteredPagedAsync(Expression<Func<Game, bool>> filter, int page, int count);
    Task<List<GameOverview>> GetGameOverviewsAsync();
    
    ValueTask<Game> GetGameByIdAsync(int id);
    
}

public class GameRepository(WebContext context) : IGameRepository
{
    public async Task<PagedResult<Game>> GetGamesFilteredPagedAsync(Expression<Func<Game, bool>> filter, int page, int count)
    {
        return await context.Games.Where(filter).ToPagedAsync(page, count);
    }

    public Task<List<GameOverview>> GetGameOverviewsAsync()
    {
        return context.Games.Select(game => new GameOverview
        {
            Id = game.Id,
            Name = game.Name,
        }).ToListAsync();
    }

    public ValueTask<Game> GetGameByIdAsync(int id)
    {
        return context.Games.FindAsync(id);
    }
}