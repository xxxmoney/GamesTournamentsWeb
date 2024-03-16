using GamesTournamentsWeb.DataAccess.Models.Tournaments;
using Microsoft.EntityFrameworkCore;

namespace GamesTournamentsWeb.DataAccess.Repositories;

public interface ICurrencyRepository : IRepository
{
    Task<List<Currency>> GetCurrenciesAsync();
}

public class CurrencyRepository(DbSet<Currency> currencies) : ICurrencyRepository
{
    public Task<List<Currency>> GetCurrenciesAsync()
    {
        return currencies.ToListAsync();
    }
}