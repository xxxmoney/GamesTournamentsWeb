using System.Linq.Expressions;
using AutoMapper;
using GamesTournamentsWeb.Common.Models;
using GamesTournamentsWeb.DataAccess.Repositories;
using GamesTournamentsWeb.Infrastructure.Dto.Games;

namespace GamesTournamentsWeb.Infrastructure.Operations.Games;

public interface IGameOperation : IOperation
{
    Task<PagedResult<Game>> GetGamesPagedAsync(GameFilter filter);
    Task<ICollection<GameOverview>> GetGameOverviewsAsync();

    Task<Game> GetGameByIdAsync(int gameId);
}

public class GameOperation(IRepositoryProvider repositoryProvider, IMapper mapper) : IGameOperation
{
    public async Task<PagedResult<Game>> GetGamesPagedAsync(GameFilter filter)
    {
        using var scope = repositoryProvider.CreateScope();
        var gameRepository = scope.Provide<IGameRepository>();

        var pagedModels = await gameRepository.GetGamesFilteredPagedAsync(FilterGames(filter), 
            filter.Page, Constants.PerPageCount);

        return pagedModels.WithData(mapper.Map<List<Game>>(pagedModels.Results));
    }

    public async Task<ICollection<GameOverview>> GetGameOverviewsAsync()
    {
        using var scope = repositoryProvider.CreateScope();
        var gameRepository = scope.Provide<IGameRepository>();

        var models = await gameRepository.GetGameOverviewsAsync();
        return mapper.Map<List<GameOverview>>(models);
    }

    private static Expression<Func<DataAccess.Models.Games.Game, bool>> FilterGames(GameFilter filter)
    {
        return game => (string.IsNullOrWhiteSpace(filter.Name) || game.Name.Contains(filter.Name))
            && (filter.GenreIds == null || !filter.GenreIds.Any() || filter.GenreIds.Contains(game.GenreId));
    }

    public async Task<Game> GetGameByIdAsync(int gameId)
    {
        using var scope = repositoryProvider.CreateScope();
        var gameRepository = scope.Provide<IGameRepository>();

        var model = await gameRepository.GetGameByIdAsync(gameId);
        return mapper.Map<Game>(model);
    }
}