using AutoMapper;
using GamesTournamentsWeb.DataAccess.Repositories;
using GamesTournamentsWeb.Infrastructure.Dto.Games;

namespace GamesTournamentsWeb.Infrastructure.Operations.Games;

public interface IGenreOperation : IOperation
{
    Task<ICollection<Genre>> GetGenresAsync();
}

public class GenreOperation(IRepositoryProvider repositoryProvider, IMapper mapper) : IGenreOperation
{
    public async Task<ICollection<Genre>> GetGenresAsync()
    {
        using var scope = repositoryProvider.CreateScope();
        var genreRepository = scope.Provide<IGenreRepository>();
        var models = await genreRepository.GetGenresAsync();

        return mapper.Map<List<Genre>>(models);
    }
}