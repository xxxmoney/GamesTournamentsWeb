using GamesTournamentsWeb.Common.Enums.Tournament;
using GamesTournamentsWeb.Infrastructure.Dto.Auth;
using GamesTournamentsWeb.Infrastructure.Dto.Users;
using GamesTournamentsWeb.Infrastructure.Operations.Auth;
using GamesTournamentsWeb.Infrastructure.Operations.Tournaments;
using GamesTournamentsWeb.Infrastructure.Operations.Users;
using GamesTournamentsWeb.Infrastructure.ViewModels.Tournaments;
using GamesTournamentsWeb.Tests.Helpers;

namespace GamesTournamentsWeb.Tests.Tests.Infrastructure.Operations.Tournaments;

public class TournamentOperationTests
{
    private const bool ShouldClean = true;
    
    [Test]
    [TestCase(5, 1, 5, 5)]
    [TestCase(6, 1, 6, 5)]
    [TestCase(6, 2, 3, 3)]
    [TestCase(8, 1, 8, 7)]
    public async Task UpdateTournamentMatchesAsync_IntegrationTest(int playersCount, int teamSize, int expectedTeamsCount, int expectedMatchesCount)
    {
        // Arrange
        var tournamentOperation = DependencyResolverHelper.GetService<ITournamentOperation>();
        var authOperation = DependencyResolverHelper.GetService<IAuthOperation>();
        var accountOperation = DependencyResolverHelper.GetService<IAccountOperation>();
        var accounts = new List<Account>();
        for (var i = 0; i < playersCount; i++)
        {
            var registerResult = await authOperation.RegisterAsync(new Register
            {
                Email = $"TEST_{i}",
                Password = "TEST",
                Username = $"TEST_{i}"
            });
            accounts.Add(registerResult.Account);
        }
        
        var tournamentEdit = new TournamentEdit
        {
            Name = "Test",
            TeamSize = teamSize,
            GameId = 1,
            PlatformId = 1,
            RegionIds = [1],
            StartDate = DateTime.Now,
            Info = "Info",
            Rules = "Rules",
            Prizes = [new PrizeEdit { Amount = 10, CurrencyId = 1, Place = 1 }],
            Players = accounts.Select(a => new TournamentPlayerEdit { AccountId = a.Id, GameUsername = $"NICK_{a.Username}", StatusId = (int)TournamentPlayerStatusEnum.Accepted }).ToList(),
            MinimumPlayers = playersCount,
            MaximumPlayers = playersCount,
            AnyoneCanJoin = false
        };
        var tournament = await tournamentOperation.UpsertTournamentAsync(tournamentEdit);
        
        // Act
        try
        {
            var result = await tournamentOperation.SetBracketsFromTournamentMatchesAsync(tournament.Id);
            
            // Assert
            Assert.That(result, Is.Not.Null);
            Assert.That(result.Matches, Has.Count.EqualTo(expectedMatchesCount));
            Assert.That(result.Matches.SelectMany(m => new [] { m.FirstTeam?.Id, m.SecondTeam?.Id }).Distinct().Count(id => id.HasValue), Is.EqualTo(expectedTeamsCount));
        }
        finally
        {
            if (ShouldClean)
            {
                // Cleanup
                await tournamentOperation.DeleteTournamentByIdAsync(tournament.Id);
                foreach (var account in accounts)
                {
                    await accountOperation.DeleteAccountByIdAsync(account.Id);
                }
            }
        }

    }
}