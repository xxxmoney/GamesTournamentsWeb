namespace GamesTournamentsWeb.Infrastructure.Exceptions;

public class AccountAlreadyExistsException(string email) : Exception($"Account with email '{email} already exists'")
{
    public string Email { get; } = email;
}