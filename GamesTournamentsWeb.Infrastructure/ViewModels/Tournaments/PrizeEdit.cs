using System.ComponentModel.DataAnnotations;

namespace GamesTournamentsWeb.Infrastructure.ViewModels.Tournaments;

public class PrizeEdit
{
    public int? Id { get; set; }
    [Required]
    public int Place { get; set; }
    [Required]
    public decimal Amount { get; set; }
    [Required]
    public int CurrencyId { get; set; }
    [Required]
    public int TournamentId { get; set; }
}