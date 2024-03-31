using System.ComponentModel.DataAnnotations;
using FoolProof.Core;

namespace GamesTournamentsWeb.Infrastructure.ViewModels.Tournaments;

public class MatchEdit
{
    [Required]
    public int MatchId { get; set; }
    public int? WinnerId { get; set; }
    public bool StartMatch { get; set; }
    public bool EndMatch { get; set; }
}
