namespace GamesTournamentsWeb.DataAccess.Models.Tournaments;

public class MatchWithPlayers
{
    public Match Match { get; init; }
    public ICollection<TournamentPlayer> Players { get; init; }
}