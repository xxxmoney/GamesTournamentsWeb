using GamesTournamentsWeb.DataAccess.Models.Users;

namespace GamesTournamentsWeb.DataAccess.Models.Tournaments;

public class TournamentPlayer
{
    public int Id { get; set; }
    public int TournamentId { get; set; }
    public Tournament Tournament { get; set; }
    public int AccountId { get; set; }
    public Account Account { get; set; }
    public int? ExpectedWinnerId { get; set; }
    public string GameUsername { get; set; }
    public int StatusId { get; set; }
    public TournamentPlayerStatus Status { get; set; }
}