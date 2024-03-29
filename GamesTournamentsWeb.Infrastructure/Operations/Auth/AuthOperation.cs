using AutoMapper;
using GamesTournamentsWeb.Common.Enums.Account;
using GamesTournamentsWeb.Common.Helpers;
using GamesTournamentsWeb.DataAccess.Repositories;
using GamesTournamentsWeb.Infrastructure.Dto.Auth;
using GamesTournamentsWeb.Infrastructure.Dto.Users;
using GamesTournamentsWeb.Infrastructure.Exceptions;

namespace GamesTournamentsWeb.Infrastructure.Operations.Auth;

public interface IAuthOperation : IOperation
{
    Task<LoginResult> LoginAsync(Login login);
    Task<RegisterResult> RegisterAsync(Register register);
    
    Task ChangePasswordAsync(int accountId, ChangePassword changePassword);
}

public class AuthOperation(IRepositoryProvider repositoryProvider, TimeProvider timeProvider, IMapper mapper, ITokenOperation tokenOperation) : IAuthOperation
{
    public async Task<LoginResult> LoginAsync(Login login)
    {
        using var scope = repositoryProvider.CreateScope();
        var accountRepository = scope.Provide<IAccountRepository>();

        var account = await accountRepository.GetAccountByEmailAsync(login.Email);
        if (account == null)
        {
            throw new AccountNotFoundException();
        }

        if (!PasswordHashHelper.VerifyPasswordHash(login.Password, account.PasswordHash, account.PasswordSalt))
        {
            throw new AccountAuthenticationInvalid();
        }

        return new LoginResult
        {
            Token = tokenOperation.CreateToken(account.Id, account.RoleId),
            Account = mapper.Map<Account>(account)
        };
    }

    public async Task<RegisterResult> RegisterAsync(Register register)
    {
        using var scope = repositoryProvider.CreateScope();
        var accountRepository = scope.Provide<IAccountRepository>();

        if (await accountRepository.ExistsAccountWithEmailAsync(register.Email))
        {
            throw new AccountAlreadyExistsException(register.Email);
        }

        var hashResult = PasswordHashHelper.CreatePasswordHash(register.Password);
        var account = new DataAccess.Models.Users.Account
        {
            Username = register.Username,
            Email = register.Email,
            RoleId = (int)RoleEnum.User,
            CreatedAt = timeProvider.GetUtcNow(),
            PasswordHash = hashResult.PasswordHash,
            PasswordSalt = hashResult.PasswordSalt
        };

        await accountRepository.AddAccountAsync(account);

        await scope.SaveChangesAsync();

        return new RegisterResult
        {
            Account = mapper.Map<Account>(account)
        };
    }

    public async Task ChangePasswordAsync(int accountId, ChangePassword changePassword)
    {
        using var scope = repositoryProvider.CreateScope();
        var accountRepository = scope.Provide<IAccountRepository>();
        
        var account = await accountRepository.GetAccountByIdAsync(accountId);

        if (account == null)
        {
            throw new AccountNotFoundException();
        }
        
        if (!PasswordHashHelper.VerifyPasswordHash(changePassword.CurrentPassword, account.PasswordHash, account.PasswordSalt))
        {
            throw new AccountAuthenticationInvalid();
        }
        
        var hashResult = PasswordHashHelper.CreatePasswordHash(changePassword.NewPassword);
        
        account.PasswordHash = hashResult.PasswordHash;
        account.PasswordSalt = hashResult.PasswordSalt;
        
        await scope.SaveChangesAsync();
    }
}