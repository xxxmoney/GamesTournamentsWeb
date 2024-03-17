using System.ComponentModel.DataAnnotations;

namespace GamesTournamentsWeb.Infrastructure.Dto.Auth;

public class Register
{
    [Required]
    public string Username { get; set; }
    [Required]
    public string Email { get; set; }
    [Required]
    public string Password { get; set; }
}