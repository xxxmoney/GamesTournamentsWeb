using AutoMapper;
using GamesTournamentsWeb.Common.Models;
using GamesTournamentsWeb.DataAccess.Repositories;
using GamesTournamentsWeb.Infrastructure.Dto.Tournaments;

namespace GamesTournamentsWeb.Infrastructure.Operations.Tournaments;

public interface ITournamentOperation : IOperation
{
    Task<PagedResult<TournamentOverview>> GetTournamentOverviewsPagedAsync(int page);
    
    Task<Tournament> GetTournamentByIdAsync(int tournamentId);
}

public class TournamentOperation(IRepositoryProvider repositoryProvider, IMapper mapper) : ITournamentOperation
{
    public async Task<PagedResult<TournamentOverview>> GetTournamentOverviewsPagedAsync(int page)
    {
        using var scope = repositoryProvider.CreateScope();
        var tournamentRepository = scope.Provide<ITournamentRepository>();
        var pagedModels = await tournamentRepository.GetTournamentOverviewsPagedAsync(page, Constants.PageCount);
        
        return pagedModels.WithData(mapper.Map<List<TournamentOverview>>(pagedModels.Results));
    }

    public async Task<Tournament> GetTournamentByIdAsync(int tournamentId)
    {
        using var scope = repositoryProvider.CreateScope();
        var tournamentRepository = scope.Provide<ITournamentRepository>();
        
        var model = await tournamentRepository.GetTournamentByIdAsync(tournamentId);
        return mapper.Map<Tournament>(model);
    }
}