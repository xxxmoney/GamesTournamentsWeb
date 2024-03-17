using AutoMapper;
using GamesTournamentsWeb.DataAccess.Repositories;
using GamesTournamentsWeb.Infrastructure.Dto.Users;

namespace GamesTournamentsWeb.Infrastructure.Operations.Accounts;

public interface IAccountOperation : IOperation
{
    Task<ICollection<Account>> GetAccounts();
    
    Task<AccountInfo> GetAccountInfoByIdAsync(int accountId);
    
    Task<ICollection<HistoryItem>> GetHistoryItemsByIdAsync(int accountId);
}

public class AccountOperation(IRepositoryProvider repositoryProvider, IMapper mapper) : IAccountOperation
{
    public async Task<ICollection<Account>> GetAccounts()
    {
        using var scope = repositoryProvider.CreateScope();
        var accountRepository = scope.Provide<IAccountRepository>();
        
        var models = await accountRepository.GetAccountsAsync();
        return mapper.Map<List<Account>>(models);
    }

    public async Task<AccountInfo> GetAccountInfoByIdAsync(int accountId)
    {
        using var scope = repositoryProvider.CreateScope();
        var matchRepository = scope.Provide<IMatchRepository>();
        
        var matches = await matchRepository.GetMatchesByAccountIdAsync(accountId);
        
        return new AccountInfo
        {
            MatchesPlayed = matches.Count,
            WinRateRatio = matches.Count == 0 ? 0 : (decimal) matches.Count(match => match.WinnerId == accountId) / matches.Count
        };
    }

    public async Task<ICollection<HistoryItem>> GetHistoryItemsByIdAsync(int accountId)
    {
        using var scope = repositoryProvider.CreateScope();
        var matchRepository = scope.Provide<IMatchRepository>();
        
        var matches = await matchRepository.GetMatchesByAccountIdAsync(accountId);
        
        return matches.Select(match => new HistoryItem
        {
            AccountId = accountId,
            GameId = match.Tournament.GameId,
            GameName = match.Tournament.Game.Name,
            TournamentId = match.TournamentId
        }).ToList();
    }
}