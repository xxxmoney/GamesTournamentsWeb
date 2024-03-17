using GamesTournamentsWeb.Common.Models;
using GamesTournamentsWeb.DataAccess.Contexts;
using GamesTournamentsWeb.DataAccess.Extensions;
using GamesTournamentsWeb.DataAccess.Models.Games;
using Microsoft.EntityFrameworkCore;

namespace GamesTournamentsWeb.DataAccess.Repositories;

public interface IGameRepository : IRepository
{
    Task<PagedResult<GameOverview>> GetGameOverviewsAsync(int page, int count);
    
    ValueTask<Game> GetGameByIdAsync(int id);
}

public class GameRepository(WebContext context) : IGameRepository
{
    public async Task<PagedResult<GameOverview>> GetGameOverviewsAsync(int page, int count)
    {
        return await context.Games.Select(g => new GameOverview
        {
            Id = g.Id,
            Name = g.Name
        }).ToPagedAsync(page, count);
    }

    public ValueTask<Game> GetGameByIdAsync(int id)
    {
        return context.Games.FindAsync(id);
    }
}