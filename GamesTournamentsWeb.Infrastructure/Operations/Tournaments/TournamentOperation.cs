using System.Linq.Expressions;
using AutoMapper;
using GamesTournamentsWeb.Common.Enums.Tournament;
using GamesTournamentsWeb.Common.Models;
using GamesTournamentsWeb.DataAccess.Repositories;
using GamesTournamentsWeb.Infrastructure.Dto.Tournaments;
using GamesTournamentsWeb.Infrastructure.Helpers;
using GamesTournamentsWeb.Infrastructure.ViewModels.Tournaments;

namespace GamesTournamentsWeb.Infrastructure.Operations.Tournaments;

public interface ITournamentOperation : IOperation
{
    Task<PagedResult<TournamentOverview>> GetTournamentOverviewsPagedAsync(int? accountId, TournamentFilter filter);
    
    Task<Tournament> GetTournamentByIdAsync(int tournamentId);
    
    Task<Tournament> UpsertTournamentAsync(TournamentEdit tournamentEdit);
    
    Task<Tournament> UpdateTournamentMatchesAsync(int tournamentId);
    
    Task DeleteTournamentByIdAsync(int tournamentId);
}

public class TournamentOperation(IRepositoryProvider repositoryProvider, IMapper mapper) : ITournamentOperation
{
    public async Task<PagedResult<TournamentOverview>> GetTournamentOverviewsPagedAsync(int? accountId, TournamentFilter filter)
    {
        using var scope = repositoryProvider.CreateScope();
        var tournamentRepository = scope.Provide<ITournamentRepository>();
        var pagedModels = await tournamentRepository.GetTournamentOverviewsFilteredPagedAsync(FilterTournaments(accountId, filter), filter.Page, Constants.PerPageCount);
        
        return pagedModels.WithData(mapper.Map<List<TournamentOverview>>(pagedModels.Results));
    }

    private static Expression<Func<DataAccess.Models.Tournaments.Tournament, bool>> FilterTournaments(int? accountId, TournamentFilter filter)
    {
        return tournament => (!accountId.HasValue || !filter.WithMyTournaments || tournament.Admins.Any(admin => admin.Id == accountId.Value))
            && (string.IsNullOrWhiteSpace(filter.Name) || tournament.Name.Contains(filter.Name))
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

    public async Task<Tournament> UpdateTournamentMatchesAsync(int tournamentId)
    {
        using var scope = repositoryProvider.CreateScope();
        var tournamentRepository = scope.Provide<ITournamentRepository>();
        var matchRepository = scope.Provide<IMatchRepository>();
        var teamRepository = scope.Provide<ITeamRepository>();
        
        var tournament = await tournamentRepository.GetTournamentByIdAsync(tournamentId);
        
        // Get current teams
        var currentTeamIds = tournament.Matches.SelectMany(m => new [] { m.FirstTeamId, m.SecondTeamId }).Distinct()
            .Where(id => id.HasValue).Select(id => id.Value).ToArray();
        var currentTeams = await teamRepository.GetTeamsByIdsAsync(currentTeamIds);
        
        // Clear current matches
        tournament.Matches.Clear();
        
        // Clear current teams
        teamRepository.RemoveTeams(currentTeams);
        
        // Save removal of teams and matches
        await scope.SaveChangesAsync();

        // Create teams from players
        var teams = new List<DataAccess.Models.Tournaments.Team>();
        var acceptedPlayers = tournament.Players.Where(player => player.StatusId == (int)TournamentPlayerStatusEnum.Accepted).ToList();
        for (var i = 0; i < acceptedPlayers.Count; i += tournament.TeamSize)
        {
            var players = acceptedPlayers.Skip(i).Take(tournament.TeamSize).ToList();
            var team = new DataAccess.Models.Tournaments.Team
            {
                Name = tournament.TeamSize == 1 ? players.Single().GameUsername : $"Team {i / tournament.TeamSize + 1}",
                Players = players
            };
            teams.Add(team);
            await teamRepository.AddTeamAsync(team);
        }
        
        // Save teams
        await scope.SaveChangesAsync();
        tournamentRepository.UpdateTournament(tournament);
        
        // Create initial matches
        foreach (var teamPair in teams.Chunk(2))
        {
            var firstTeam = teamPair[0];
            var secondTeam = teamPair.Count() == 2 ? teamPair[1] : null;
            tournament.Matches.Add(new DataAccess.Models.Tournaments.Match
            {
                TournamentId = tournament.Id,
                Tournament = tournament,
                FirstTeamId = firstTeam.Id,
                SecondTeamId = secondTeam?.Id
            });
        }
        
        // Create new matches that will be used as subsequent matches
        var subsequentMatchesCount = TournamentHelper.CalculateTotalMatchesCount(tournament.Matches.Count) - tournament.Matches.Count;   
        var subsequentMatches = Enumerable.Range(0, subsequentMatchesCount).Select(_ => new DataAccess.Models.Tournaments.Match
        {
            TournamentId = tournament.Id,
            Tournament = tournament
        }).ToList();
        
        // Create subsequent matches
        foreach (var match in subsequentMatches)
        {
            tournament.Matches.Add(match);
        }
        
        // Save matches
        await scope.SaveChangesAsync();

        // Create subsequent matches for matches that have both teams
        List<DataAccess.Models.Tournaments.Match> previousMatches;
        while ((previousMatches = tournament.Matches.Where(m => m.NextMatchId == null && m.FirstTeamId != null && m.SecondTeamId != null).ToList()).Count != 0)
        {
            // Create subsequent matches - each subsequent match has previous two matches
            foreach (var matchPair in previousMatches.Chunk(2))
            {
                var firstMatch = matchPair[0];
                var secondMatch = matchPair[1];
                
                var nextMatch = new DataAccess.Models.Tournaments.Match
                {
                    TournamentId = tournament.Id,
                    Tournament = tournament,
                };
                tournament.Matches.Add(nextMatch);
                firstMatch.NextMatchId = nextMatch.Id;
                secondMatch.NextMatchId = nextMatch.Id;
            }
        }
        
        // Save matches
        await scope.SaveChangesAsync();
        
        return mapper.Map<Tournament>(tournament);
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