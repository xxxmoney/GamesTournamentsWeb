using GamesTournamentsWeb.DataAccess.Models.Tournaments;
using Microsoft.EntityFrameworkCore;

namespace GamesTournamentsWeb.DataAccess.Repositories;

public interface IPrizeRepository : IRepository
{
    Task<List<Prize>> GetCurrenciesAsync();
}

public class PrizeRepository(DbSet<Prize> prizes) : IPrizeRepository
{
    public Task<List<Prize>> GetCurrenciesAsync()
    {
        return prizes.ToListAsync();
    }
}