using System.ComponentModel.DataAnnotations;

namespace GamesTournamentsWeb.Infrastructure.Dto.Auth;

public class Login
{
    [Required]
    public string Email { get; set; }
    [Required]
    public string Password { get; set; }
}