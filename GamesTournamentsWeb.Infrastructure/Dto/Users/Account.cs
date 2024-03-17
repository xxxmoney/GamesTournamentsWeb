using GamesTournamentsWeb.Infrastructure.Dto.Tournaments;
using GamesTournamentsWeb.Infrastructure.Dto.Users;

namespace GamesTournamentsWeb.Infrastructure.Dto.Users;

public class Account
{
    public int Id { get; set; }
    public string Username { get; set; }
    public string Email { get; set; }
    public int RoleId { get; set; }
    public Role Role { get; set; }
    public DateTimeOffset CreatedAt { get; set; }
    public string ImageUrl { get; set; }
}
