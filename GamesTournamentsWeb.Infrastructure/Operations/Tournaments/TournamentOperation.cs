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
    
    Task<Tournament> UpdateTournamentMatchesAsync(int tournamentId);
    
    Task DeleteTournamentByIdAsync(int tournamentId);
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
        var accountRepository = scope.Provide<IAccountRepository>();
        var regionRepository = scope.Provide<IRegionRepository>();
        
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
        
        // Set admins
        tournament.Admins ??= new List<DataAccess.Models.Users.Account>();
        tournament.Admins.Clear();
        foreach (var adminId in tournamentEdit.AdminIds)
        {
            var admin = await accountRepository.GetAccountByIdAsync(adminId);
            tournament.Admins.Add(admin);
        }
        
        // Set regions
        tournament.Regions ??= new List<DataAccess.Models.Tournaments.Region>();
        tournament.Regions.Clear();
        foreach (var regionId in tournamentEdit.RegionIds)
        {
            var region = await regionRepository.GetRegionByIdAsync(regionId);
            tournament.Regions.Add(region);
        }
        
        mapper.Map(tournamentEdit, tournament);
        
        await scope.SaveChangesAsync();
        
        return mapper.Map<Tournament>(tournament);
    }

    public Task<Tournament> UpdateTournamentMatchesAsync(int tournamentId)
    {
        // TODO: update tournament matches (brackets) based on current accepted tournament players
        
        throw new NotImplementedException();
    }

    public async Task DeleteTournamentByIdAsync(int tournamentId)
    {
        using var scope = repositoryProvider.CreateScope();
        var tournamentRepository = scope.Provide<ITournamentRepository>();
        
        var model = await tournamentRepository.GetTournamentByIdAsync(tournamentId);
        tournamentRepository.DeleteTournament(model);
        
        await scope.SaveChangesAsync();
    }
}