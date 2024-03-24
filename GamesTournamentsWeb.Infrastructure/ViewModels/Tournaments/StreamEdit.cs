namespace GamesTournamentsWeb.Infrastructure.ViewModels.Tournaments;

public class StreamEdit
{
    public int? Id { get; set; }
    public string Name { get; set; }
    public string Url { get; set; }
    public int TournamentId { get; set; }
}