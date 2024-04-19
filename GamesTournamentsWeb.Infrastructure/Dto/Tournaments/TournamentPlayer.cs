using GamesTournamentsWeb.Infrastructure.Dto.Users;

namespace GamesTournamentsWeb.Infrastructure.Dto.Tournaments;

public class TournamentPlayer
{
    public int Id { get; set; }
    public int TournamentId { get; set; }
    public string TournamentName { get; set; }
    public Account Account { get; set; }
    public int AccountId { get; set; }
    public string GameUsername { get; set; }
    public int StatusId { get; set; }
    public int? ExpectedWinnerId { get; set; }
}