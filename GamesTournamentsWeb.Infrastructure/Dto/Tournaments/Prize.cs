namespace GamesTournamentsWeb.Infrastructure.Dto.Tournaments;

public class Prize
{
    public int Id { get; set; }
    public int Place { get; set; }
    public int Amount { get; set; }
    public Currency Currency { get; set; }
    public int TournamentId { get; set; }
}
