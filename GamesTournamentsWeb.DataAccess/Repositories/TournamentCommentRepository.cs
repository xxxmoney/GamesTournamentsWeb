using GamesTournamentsWeb.DataAccess.Contexts;
using GamesTournamentsWeb.DataAccess.Models.Tournaments;

namespace GamesTournamentsWeb.DataAccess.Repositories;

public interface ITournamentCommentRepository : IRepository
{
    Task AddTournamentCommentAsync(TournamentComment comment);
}

public class TournamentCommentRepository(WebContext context) : ITournamentCommentRepository
{
    public Task AddTournamentCommentAsync(TournamentComment comment)
    {
        return context.TournamentComments.AddAsync(comment).AsTask();
    }
}