using System.ComponentModel.DataAnnotations;

namespace GamesTournamentsWeb.Infrastructure.ViewModels.Tournaments;

public class StreamEdit
{
    public int? Id { get; set; }
    [Required]
    public string Name { get; set; }
    [Required]
    public string Url { get; set; }
    [Required]
    public int TournamentId { get; set; }
}