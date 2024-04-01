namespace GamesTournamentsWeb.Infrastructure.Dto.Users;

public class HistoryItem
{
    public int AccountId { get; set; }
    public int GameId { get; set; }
    public string GameName { get; set; }
    public string GameUsername { get; set; }
    public int TournamentId { get; set; }
    public string TournamentName { get; set; }
}