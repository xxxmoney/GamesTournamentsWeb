using GamesTournamentsWeb.DataAccess.Repositories;
using GamesTournamentsWeb.Infrastructure.Dtos;

namespace GamesTournamentsWeb.Infrastructure.Operations;

public interface IGenreOperation
{
    Task<ICollection<Genre>> GetGenresAsync();
}

public class GenreOperation(IRepositoryProvider repoProvider) : IGenreOperation
{
    public async Task<ICollection<Genre>> GetGenresAsync()
    {
        using var scope = repoProvider.CreateScope();
        var genreRepo = scope.Provide<IGenreRepository>();
        var models = await genreRepo.GetGenresAsync();
        
        // TODO: mapping and caching
        return Array.Empty<Genre>();
    }
}