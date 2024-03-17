using GamesTournamentsWeb.DataAccess.Contexts;
using Microsoft.EntityFrameworkCore;
using Stream = GamesTournamentsWeb.DataAccess.Models.Tournaments.Stream;

namespace GamesTournamentsWeb.DataAccess.Repositories;

public interface IStreamRepository : IRepository
{
    Task<List<Stream>> GetCurrenciesAsync();
}

public class StreamRepository(WebContext context) : IStreamRepository
{
    public Task<List<Stream>> GetCurrenciesAsync()
    {
        return context.Streams.ToListAsync();
    }
}