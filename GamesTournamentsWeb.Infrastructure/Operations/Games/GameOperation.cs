using AutoMapper;
using GamesTournamentsWeb.Common.Models;
using GamesTournamentsWeb.DataAccess.Repositories;
using GamesTournamentsWeb.Infrastructure.Dto.Games;

namespace GamesTournamentsWeb.Infrastructure.Operations.Games;

public interface IGameOperation : IOperation
{
    Task<PagedResult<GameOverview>> GetGameOverviewsPagedAsync(int page);

    Task<Game> GetGameByIdAsync(int gameId);
}

public class GameOperation(IRepositoryProvider repositoryProvider, IMapper mapper) : IGameOperation
{
    public async Task<PagedResult<GameOverview>> GetGameOverviewsPagedAsync(int page)
    {
        using var scope = repositoryProvider.CreateScope();
        var gameRepository = scope.Provide<IGameRepository>();

        var pagedModels = await gameRepository.GetGameOverviewsPagedAsync(page, Constants.PageCount);

        return pagedModels.WithData(mapper.Map<List<GameOverview>>(pagedModels.Results));
    }

    public async Task<Game> GetGameByIdAsync(int gameId)
    {
        using var scope = repositoryProvider.CreateScope();
        var gameRepository = scope.Provide<IGameRepository>();

        var model = await gameRepository.GetGameByIdAsync(gameId);
        return mapper.Map<Game>(model);
    }
}