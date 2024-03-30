namespace GamesTournamentsWeb.Infrastructure.Dto.Tournaments;

public class Match
{
    public int Id { get; set; }
    public int TournamentId { get; set; }
    public Match NextMatch { get; set; }
    public Team FirstTeam { get; set; }
    public Team SecondTeam { get; set; }
    public Team Winner { get; set; }
    public DateTimeOffset? StartDate { get; set; }
    public DateTimeOffset? EndDate { get; set; }
    public bool IsRunning { get; set; }
}
