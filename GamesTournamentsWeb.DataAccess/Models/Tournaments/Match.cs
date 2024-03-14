namespace GamesTournamentsWeb.DataAccess.Models.Tournaments;

public class Match
{
    public int Id { get; set; }
    public int TournamentId { get; set; }
    public Tournament Tournament { get; set; }
    public int? NextMatchId { get; set; }
    public int? PreviousMatchId { get; set; }
    public Match NextMatch { get; set; }
    public Match PreviousMatch { get; set; }
    public int? FirstTeamId { get; set; }
    public Team FirstTeam { get; set; }
    public int? SecondTeamId { get; set; }
    public Team SecondTeam { get; set; }
    public int? WinnerId { get; set; }
    public Team Winner { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime? EndDate { get; set; }
    public bool IsRunning => EndDate == null;
}
