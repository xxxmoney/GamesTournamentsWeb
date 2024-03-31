namespace GamesTournamentsWeb.DataAccess.Models.Tournaments;

public class Match
{
    public int Id { get; set; }
    public int TournamentId { get; set; }
    public Tournament Tournament { get; set; }
    public int? NextMatchId { get; set; }
    public int? FirstTeamId { get; set; }
    public int? SecondTeamId { get; set; }
    public int? WinnerId { get; set; }
    public DateTimeOffset? StartDate { get; set; }
    public DateTimeOffset? EndDate { get; set; }
}
