namespace GamesTournamentsWeb.Infrastructure.ViewModels.Tournaments;

public class PrizeEdit
{
    public int? Id { get; set; }
    public int Place { get; set; }
    public decimal Amount { get; set; }
    public int CurrencyId { get; set; }
    public int TournamentId { get; set; }
}