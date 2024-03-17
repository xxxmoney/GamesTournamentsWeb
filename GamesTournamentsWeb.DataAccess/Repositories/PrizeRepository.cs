using GamesTournamentsWeb.DataAccess.Contexts;
using GamesTournamentsWeb.DataAccess.Models.Tournaments;
using Microsoft.EntityFrameworkCore;

namespace GamesTournamentsWeb.DataAccess.Repositories;

public interface IPrizeRepository : IRepository
{
    Task<List<Prize>> GetCurrenciesAsync();
}

public class PrizeRepository(WebContext context) : IPrizeRepository
{
    public Task<List<Prize>> GetCurrenciesAsync()
    {
        return context.Prizes.ToListAsync();
    }
}