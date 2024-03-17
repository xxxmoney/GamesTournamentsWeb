using GamesTournamentsWeb.DataAccess.Contexts;
using GamesTournamentsWeb.DataAccess.Models.Users;
using Microsoft.EntityFrameworkCore;

namespace GamesTournamentsWeb.DataAccess.Repositories;

public interface IAccountRepository : IRepository
{
    Task<List<Account>> GetAccountsAsync();
    
    ValueTask<Account> GetAccountByIdAsync(int id);
    
    Task<Account> GetAccountByEmailAsync(string email);

    Task<bool> ExistsAccountWithEmailAsync(string email);

    Task AddAsync(Account account);
    
    void Update(Account account);
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

    public Task<Account> GetAccountByEmailAsync(string email)
    {
        return context.Accounts.SingleAsync(account => account.Email == email);
    }

    public async Task<bool> ExistsAccountWithEmailAsync(string email)
    {
        return await context.Accounts.SingleOrDefaultAsync(account => account.Email == email) != null;
    }

    public async Task AddAsync(Account account)
    {
        await context.Accounts.AddAsync(account);
    }

    public void Update(Account account)
    {
        context.Accounts.Update(account);
    }
}