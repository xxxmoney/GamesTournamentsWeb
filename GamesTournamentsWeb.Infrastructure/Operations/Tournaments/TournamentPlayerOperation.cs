using AutoMapper;
using GamesTournamentsWeb.Common.Enums.Tournament;
using GamesTournamentsWeb.DataAccess.Repositories;
using GamesTournamentsWeb.Infrastructure.Dto.Tournaments;
using GamesTournamentsWeb.Infrastructure.Exceptions;

namespace GamesTournamentsWeb.Infrastructure.Operations.Tournaments;

public interface ITournamentPlayerOperation : IOperation
{
    Task<TournamentPlayer> ChangeTournamentPlayerStatusAsync(int id, int accountId, TournamentPlayerStatusEnum status, string gameUsername = null);
    
    Task<ICollection<TournamentPlayer>> GetTournamentPlayersForTournamentAsync(int tournamentId);
    
    Task<ICollection<TournamentPlayer>> GetTournamentPlayersForAccountAsync(int accountId);
}

public class TournamentPlayerOperation(IRepositoryProvider repositoryProvider, IMapper mapper) : ITournamentPlayerOperation
{
    public async Task<TournamentPlayer> ChangeTournamentPlayerStatusAsync(int id, int accountId, TournamentPlayerStatusEnum status, string gameUsername = null)
    {
        using var scope = repositoryProvider.CreateScope();
        var repository = scope.Provide<ITournamentPlayerRepository>();
        
        var model = await repository.GetTournamentPlayerByIdAsync(id);
        if (model.AccountId != accountId)
        {
            throw new UnauthorizedUpdateException();
        }
        
        model.StatusId = (int)status;
        if (status == TournamentPlayerStatusEnum.Accepted)
        {
            if (string.IsNullOrWhiteSpace(gameUsername))
            {
                throw new AccountInvitationGameUsernameEmpty();
            }
            
            model.GameUsername = gameUsername;
        }
        repository.UpdateTournamentPlayer(model);

        await scope.SaveChangesAsync();
        
        return mapper.Map<TournamentPlayer>(model);
    }

    public async Task<ICollection<TournamentPlayer>> GetTournamentPlayersForTournamentAsync(int tournamentId)
    {
        using var scope = repositoryProvider.CreateScope();
        var repository = scope.Provide<ITournamentPlayerRepository>();
        
        var models = await repository.GetTournamentPlayersForTournamentAsync(tournamentId);

        return mapper.Map<List<TournamentPlayer>>(models);
    }

    public async Task<ICollection<TournamentPlayer>> GetTournamentPlayersForAccountAsync(int accountId)
    {
        using var scope = repositoryProvider.CreateScope();
        var repository = scope.Provide<ITournamentPlayerRepository>();
        
        var models = await repository.GetTournamentPlayersForAccountAsync(accountId);

        return mapper.Map<List<TournamentPlayer>>(models);
    }
}