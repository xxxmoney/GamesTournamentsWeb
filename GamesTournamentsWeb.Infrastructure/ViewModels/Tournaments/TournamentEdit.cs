using System.ComponentModel.DataAnnotations;
using FoolProof.Core;
using GamesTournamentsWeb.Infrastructure.Dto.Tournaments;
using Stream = System.IO.Stream;

namespace GamesTournamentsWeb.Infrastructure.ViewModels.Tournaments;

public class TournamentEdit
{
    public int? Id { get; set; }
    [Required]
    public string Name { get; set; }
    [Required]
    public int TeamSize { get; set; }
    [Required]
    public int GameId { get; set; }
    [Required]
    public int PlatformId { get; set; }
    [Required]
    public List<int> RegionIds { get; set; }
    public DateTime? StartDate { get; set; }
    public DateTime? EndDate { get; set; }
    [Required]
    public string Info { get; set; }
    [Required]
    public string Rules { get; set; }
    public List<PrizeEdit> Prizes { get; set; }
    public List<TournamentPlayerEdit> Players { get; set; }
    public List<StreamEdit> Streams { get; set; }
    [Required]
    [LessThanOrEqualTo(nameof(MaximumPlayers))]
    public int MinimumPlayers { get; set; }
    [Required]
    [GreaterThanOrEqualTo(nameof(MinimumPlayers))]
    public int MaximumPlayers { get; set; }
    [Required]
    public bool AnyoneCanJoin { get; set; }
    [Required]
    public List<int> AdminIds { get; set; }
    
}