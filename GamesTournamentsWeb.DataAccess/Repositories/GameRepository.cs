using GamesTournamentsWeb.Common.Models;
using GamesTournamentsWeb.DataAccess.Extensions;
using GamesTournamentsWeb.DataAccess.Models.Games;
using Microsoft.EntityFrameworkCore;

namespace GamesTournamentsWeb.DataAccess.Repositories;

public interface IGameRepository
{
    Task<PagedResult<GameOverview>> GetGameOverviewsAsync(int page, int count);
    
    Task<Game> GetGameByIdAsync(int id);
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

    public async Task<Game> GetGameByIdAsync(int id)
    {
        return await games.FindAsync(id);
    }
}