using GamesTournamentsWeb.Infrastructure.Dto.Users;

namespace GamesTournamentsWeb.Infrastructure.Dto.Auth;

public class LoginResult
{
    public string Token { get; set; }
    public Account Account { get; set; }
}