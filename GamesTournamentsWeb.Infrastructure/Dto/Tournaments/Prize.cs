namespace GamesTournamentsWeb.Infrastructure.Dto.Tournaments;

public class Prize
{
    public int Id { get; set; }
    public int Place { get; set; }
    public decimal Amount { get; set; }
    public Currency Currency { get; set; }
    public int CurrencyId { get; set; }
    public int TournamentId { get; set; }
}
