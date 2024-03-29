namespace GamesTournamentsWeb.Infrastructure.Dto.Auth;

public class ChangePassword
{
    public string CurrentPassword { get; set; }
    public string NewPassword { get; set; }
}