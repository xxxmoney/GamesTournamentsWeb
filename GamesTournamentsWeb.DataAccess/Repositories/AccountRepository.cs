using GamesTournamentsWeb.DataAccess.Contexts;
using GamesTournamentsWeb.DataAccess.Models.Users;
using Microsoft.EntityFrameworkCore;

namespace GamesTournamentsWeb.DataAccess.Repositories;

public interface IAccountRepository : IRepository
{
    Task<List<Account>> GetAccountsAsync();
    
    ValueTask<Account> GetAccountByIdAsync(int id);
}

public class AccountRepository(WebContext context) : IAccountRepository
{
    public Task<List<Account>> GetAccountsAsync()
    {
        return context.Accounts.ToListAsync();
    }

    public ValueTask<Account> GetAccountByIdAsync(int id)
    {
        return context.Accounts.FindAsync(id);
    }
}