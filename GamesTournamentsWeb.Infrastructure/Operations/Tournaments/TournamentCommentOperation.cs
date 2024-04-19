using AutoMapper;
using GamesTournamentsWeb.DataAccess.Repositories;
using GamesTournamentsWeb.Infrastructure.Dto.Tournaments;
using GamesTournamentsWeb.Infrastructure.ViewModels.Tournaments;

namespace GamesTournamentsWeb.Infrastructure.Operations.Tournaments;

public interface ITournamentCommentOperation : IOperation
{
    Task<TournamentComment> CreateTournamentCommentAsync(int accountId, TournamentCommentEdit commentEdit);
}

public class TournamentCommentOperation(IRepositoryProvider repositoryProvider, IMapper mapper, TimeProvider timeProvider) : ITournamentCommentOperation
{
    public async Task<TournamentComment> CreateTournamentCommentAsync(int accountId, TournamentCommentEdit commentEdit)
    {
        using var scope = repositoryProvider.CreateScope();
        var tournamentCommentRepository = scope.Provide<ITournamentCommentRepository>();
        
        var commentModel = new DataAccess.Models.Tournaments.TournamentComment();
        await tournamentCommentRepository.AddTournamentCommentAsync(commentModel);
        
        mapper.Map(commentEdit, commentModel);
        commentModel.AccountId = accountId;
        commentModel.CreateDate = timeProvider.GetUtcNow();

        await scope.SaveChangesAsync();
        
        return mapper.Map<TournamentComment>(commentModel);
    }
}