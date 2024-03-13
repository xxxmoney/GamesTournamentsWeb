namespace GamesTournamentsWeb.DataAccess.Models.Tournaments;

public class Stream
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Url { get; set; }
    public int TournamentId { get; set; }
    public Tournament Tournament { get; set; }
}