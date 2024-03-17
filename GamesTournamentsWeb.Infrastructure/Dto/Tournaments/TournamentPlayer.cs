using GamesTournamentsWeb.Infrastructure.Dto.Users;

namespace GamesTournamentsWeb.Infrastructure.Dto.Tournaments;

public class TournamentPlayer
{
    public int Id { get; set; }
    public int TournamentId { get; set; }
    public Account Account { get; set; }
    public string GameUsername { get; set; }
    public string Status { get; set; }
}