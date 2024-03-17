using GamesTournamentsWeb.DataAccess.Contexts;
using GamesTournamentsWeb.DataAccess.Models.Tournaments;
using Microsoft.EntityFrameworkCore;

namespace GamesTournamentsWeb.DataAccess.Repositories;

public interface ICurrencyRepository : IRepository
{
    Task<List<Currency>> GetCurrenciesAsync();
}

public class CurrencyRepository(WebContext context) : ICurrencyRepository
{
    public Task<List<Currency>> GetCurrenciesAsync()
    {
        return context.Currencies.ToListAsync();
    }
}