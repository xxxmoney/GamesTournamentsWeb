using AutoMapper;
using GamesTournamentsWeb.DataAccess.Repositories;
using GamesTournamentsWeb.Infrastructure.Dto.Users;

namespace GamesTournamentsWeb.Infrastructure.Operations.Users;

public interface IAccountOperation : IOperation
{
    Task<ICollection<Account>> GetAccountsAsync();
    Task<Account> GetAccountByIdAsync(int accountId);
    
    Task<AccountInfo> GetAccountInfoByIdAsync(int accountId);
    
    Task<ICollection<HistoryItem>> GetHistoryItemsByIdAsync(int accountId);
    
    Task DeleteAccountByIdAsync(int accountId);
}

public class AccountOperation(IRepositoryProvider repositoryProvider, IMapper mapper) : IAccountOperation
{
    public async Task<ICollection<Account>> GetAccountsAsync()
    {
        using var scope = repositoryProvider.CreateScope();
        var accountRepository = scope.Provide<IAccountRepository>();
        
        var models = await accountRepository.GetAccountsAsync();
        return mapper.Map<List<Account>>(models);
    }

    public async Task<Account> GetAccountByIdAsync(int accountId)
    {
        using var scope = repositoryProvider.CreateScope();
        var accountRepository = scope.Provide<IAccountRepository>();
        
        var model = await accountRepository.GetAccountByIdAsync(accountId);
        return mapper.Map<Account>(model);
    }

    public async Task<AccountInfo> GetAccountInfoByIdAsync(int accountId)
    {
        using var scope = repositoryProvider.CreateScope();
        var matchRepository = scope.Provide<IMatchRepository>();

        var matchesWithPlayers = await matchRepository.GetMatchesWithPlayersByAccountIdAsync(accountId);
        var matchesWithWinner = matchesWithPlayers.Select(mp => mp.Match).Where(m => m.WinnerId.HasValue).ToList();
        var playersByMatchId = matchesWithPlayers.ToDictionary(key => key.Match.Id, value => value.Players);
        
        // Get win count of matches where winner team includes the account
        var winCount = matchesWithWinner.Count(m => playersByMatchId[m.WinnerId!.Value].Any(p => p.AccountId == accountId));
        return new AccountInfo
        {
            MatchesPlayed = matchesWithWinner.Count,
            WinRateRatio = matchesWithWinner.Count == 0 ? 0 : (decimal)winCount / matchesWithWinner.Count,
            WinCount = winCount,
            LossCount = matchesWithWinner.Count - winCount
        };
    }

    public async Task<ICollection<HistoryItem>> GetHistoryItemsByIdAsync(int accountId)
    {
        using var scope = repositoryProvider.CreateScope();
        var matchRepository = scope.Provide<IMatchRepository>();
        
        var matches = await matchRepository.GetMatchesWithPlayersByAccountIdAsync(accountId);
        
        return matches.Select(item => new HistoryItem
        {
            AccountId = accountId,
            GameId = item.Match.Tournament.GameId,
            GameName = item.Match.Tournament.Game.Name,
            GameUsername = item.Players.Single(p => p.AccountId == accountId).GameUsername,
            TournamentId = item.Match.TournamentId,
            TournamentName = item.Match.Tournament.Name
        }).DistinctBy(i => i.TournamentId).ToList();
    }

    public async Task DeleteAccountByIdAsync(int accountId)
    {
        using var scope = repositoryProvider.CreateScope();
        var accountRepository = scope.Provide<IAccountRepository>();
        
        var account = await accountRepository.GetAccountByIdAsync(accountId);
        accountRepository.DeleteAccount(account);
        
        await scope.SaveChangesAsync();
    }
}