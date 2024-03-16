using GamesTournamentsWeb.Common.Models;
using GamesTournamentsWeb.DataAccess.Extensions;
using GamesTournamentsWeb.DataAccess.Models.Games;
using Microsoft.EntityFrameworkCore;

namespace GamesTournamentsWeb.DataAccess.Repositories;

public interface IGameRepository : IRepository
{
    Task<PagedResult<GameOverview>> GetGameOverviewsAsync(int page, int count);
    
    ValueTask<Game> GetGameByIdAsync(int id);
}

public class GameRepository(DbSet<Game> games) : IGameRepository
{
    public async Task<PagedResult<GameOverview>> GetGameOverviewsAsync(int page, int count)
    {
        return await games.Select(g => new GameOverview
        {
            Id = g.Id,
            Name = g.Name
        }).ToPagedAsync(page, count);
    }

    public ValueTask<Game> GetGameByIdAsync(int id)
    {
        return games.FindAsync(id);
    }
}