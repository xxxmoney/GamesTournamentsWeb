using GamesTournamentsWeb.DataAccess.Models.Dashboard;
using GamesTournamentsWeb.DataAccess.Models.Tournaments;
using GamesTournamentsWeb.DataAccess.Models.Users;

namespace GamesTournamentsWeb.DataAccess.Models.Users;

public class Account
{
    public int Id { get; set; }
    public string Username { get; set; }
    public string Email { get; set; }
    public byte[] PasswordHash { get; set; }
    public byte[] PasswordSalt { get; set; }
    public int RoleId { get; set; }
    public Role Role { get; set; }
    public DateTimeOffset CreatedAt { get; set; }
    public string ImageUrl { get; set; }
    public ICollection<Tournament> AdminTournaments { get; set; }
    public ICollection<TournamentPlayer> TournamentPlayers { get; set; }
    public ICollection<Layout> Layouts { get; set; }
}
