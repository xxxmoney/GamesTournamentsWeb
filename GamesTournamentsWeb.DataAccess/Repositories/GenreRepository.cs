using System.Collections.ObjectModel;
using GamesTournamentsWeb.DataAccess.Models.Games;
using Microsoft.EntityFrameworkCore;

namespace GamesTournamentsWeb.DataAccess.Repositories;

public interface IGenreRepository : IRepository
{
    Task<List<Genre>> GetGenresAsync();
}

public class GenreRepository(DbSet<Genre> genres) : IGenreRepository
{
    public Task<List<Genre>> GetGenresAsync()
    {
        return genres.ToListAsync();
    }
}