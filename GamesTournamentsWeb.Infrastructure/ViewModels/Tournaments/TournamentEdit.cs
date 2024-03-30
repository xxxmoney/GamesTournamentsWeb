using GamesTournamentsWeb.Infrastructure.Dto.Tournaments;
using Stream = System.IO.Stream;

namespace GamesTournamentsWeb.Infrastructure.ViewModels.Tournaments;

public class TournamentEdit
{
    public int? Id { get; set; }
    public string Name { get; set; }
    public int TeamSize { get; set; }
    public int GameId { get; set; }
    public int PlatformId { get; set; }
    public List<int> RegionIds { get; set; }
    public DateTime? StartDate { get; set; }
    public DateTime? EndDate { get; set; }
    public string Info { get; set; }
    public string Rules { get; set; }
    public List<PrizeEdit> Prizes { get; set; }
    public List<TournamentPlayerEdit> Players { get; set; }
    public Match Match { get; set; }
    public List<StreamEdit> Streams { get; set; }
    public int MinimumPlayers { get; set; }
    public int MaximumPlayers { get; set; }
    public bool AnyoneCanJoin { get; set; }
    public List<int> AdminIds { get; set; }
    
}