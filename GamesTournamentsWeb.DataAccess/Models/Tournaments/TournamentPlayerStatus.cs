namespace GamesTournamentsWeb.DataAccess.Models.Tournaments;

public class TournamentPlayerStatus
{
    public int Id { get; set; }
    public string Name { get; set; }
    public ICollection<TournamentPlayer> TournamentPlayers { get; set; }
}
