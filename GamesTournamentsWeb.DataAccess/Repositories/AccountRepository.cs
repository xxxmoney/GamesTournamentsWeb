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

    Task AddAccountAsync(Account account);
    
    void UpdateAccount(Account account);
    
    void DeleteAccount(Account account);
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
        return context.Accounts.SingleOrDefaultAsync(account => account.Email == email);
    }

    public async Task<bool> ExistsAccountWithEmailAsync(string email)
    {
        return await this.GetAccountByEmailAsync(email) != null;
    }

    public async Task AddAccountAsync(Account account)
    {
        await context.Accounts.AddAsync(account);
    }

    public void UpdateAccount(Account account)
    {
        context.Accounts.Update(account);
    }

    public void DeleteAccount(Account account)
    {
        context.Accounts.Remove(account);
    }
}