namespace GamesTournamentsWeb.Infrastructure.ViewModels.Tournaments;

public class TournamentPlayerEdit
{
    public int? Id { get; set; }
    public int TournamentId { get; set; }
    public int AccountId { get; set; }
    public string GameUsername { get; set; }
    public int StatusId { get; set; }
}
