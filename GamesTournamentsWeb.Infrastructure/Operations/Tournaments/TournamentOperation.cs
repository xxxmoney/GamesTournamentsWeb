using System.Linq.Expressions;
using AutoMapper;
using GamesTournamentsWeb.Common.Models;
using GamesTournamentsWeb.DataAccess.Repositories;
using GamesTournamentsWeb.Infrastructure.Dto.Tournaments;
using GamesTournamentsWeb.Infrastructure.Helpers;
using GamesTournamentsWeb.Infrastructure.ViewModels.Tournaments;

namespace GamesTournamentsWeb.Infrastructure.Operations.Tournaments;

public interface ITournamentOperation : IOperation
{
    Task<PagedResult<TournamentOverview>> GetTournamentOverviewsPagedAsync(TournamentFilter filter);
    
    Task<Tournament> GetTournamentByIdAsync(int tournamentId);
    
    Task<Tournament> UpsertTournamentAsync(TournamentEdit tournamentEdit);
    
}

public class TournamentOperation(IRepositoryProvider repositoryProvider, IMapper mapper) : ITournamentOperation
{
    public async Task<PagedResult<TournamentOverview>> GetTournamentOverviewsPagedAsync(TournamentFilter filter)
    {
        using var scope = repositoryProvider.CreateScope();
        var tournamentRepository = scope.Provide<ITournamentRepository>();
        var pagedModels = await tournamentRepository.GetTournamentOverviewsFilteredPagedAsync(FilterTournaments(filter), filter.Page, Constants.PerPageCount);
        
        return pagedModels.WithData(mapper.Map<List<TournamentOverview>>(pagedModels.Results));
    }

    private static Expression<Func<DataAccess.Models.Tournaments.Tournament, bool>> FilterTournaments(TournamentFilter filter)
    {
        return tournament => (string.IsNullOrWhiteSpace(filter.Name) || tournament.Name.Contains(filter.Name))
            && (filter.GameId == null || tournament.GameId == filter.GameId)
            && (filter.TeamSizes == null || filter.TeamSizes.Length == 0 || filter.TeamSizes.Contains(tournament.TeamSize))
            && (filter.RegionIds == null || filter.RegionIds.Length == 0 || tournament.Regions.Any(region => filter.RegionIds.Contains(region.Id)))
            && (filter.PlatformIds == null || filter.PlatformIds.Length == 0 || filter.PlatformIds.Contains(tournament.PlatformId))
            && (filter.GenreIds == null || filter.GenreIds.Length == 0 || filter.GenreIds.Contains(tournament.Game.GenreId));
    }
    
    public async Task<Tournament> GetTournamentByIdAsync(int tournamentId)
    {
        using var scope = repositoryProvider.CreateScope();
        var tournamentRepository = scope.Provide<ITournamentRepository>();
        
        var model = await tournamentRepository.GetTournamentByIdAsync(tournamentId);
        return mapper.Map<Tournament>(model);
    }

    public async Task<Tournament> UpsertTournamentAsync(TournamentEdit tournamentEdit)
    {
        DataAccess.Models.Tournaments.Tournament tournament;
        
        using var scope = repositoryProvider.CreateScope();
        var tournamentRepository = scope.Provide<ITournamentRepository>();
        
        if (UpsertHelper.EntityExists(tournamentEdit.Id))
        {
            tournament = await tournamentRepository.GetTournamentByIdAsync(tournamentEdit.Id!.Value);
            tournamentRepository.UpdateTournament(tournament);
        }
        else
        {
            tournament = new DataAccess.Models.Tournaments.Tournament();
            await tournamentRepository.AddTournamentAsync(tournament);
        }
        
        mapper.Map(tournamentEdit, tournament);
        
        await scope.SaveChangesAsync();
        
        return mapper.Map<Tournament>(tournament);
    }
}