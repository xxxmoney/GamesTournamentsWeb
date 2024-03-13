namespace GamesTournamentsWeb.DataAccess.Models.Tournaments;

public class Team
{
    public int Id { get; set; }
    public string Name { get; set; }
    public ICollection<TournamentPlayer> Players { get; set; }
    public ICollection<Match> FirstTeamMatches { get; set; }
    public ICollection<Match> SecondTeamMatches { get; set; }
    public ICollection<Match> WinnerMatches { get; set; }
}