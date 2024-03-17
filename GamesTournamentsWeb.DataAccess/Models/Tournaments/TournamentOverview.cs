using GamesTournamentsWeb.DataAccess.Models.Games;

namespace GamesTournamentsWeb.DataAccess.Models.Tournaments;

public class TournamentOverview
{
    public int Id { get; set; }
    public string Name { get; set; }    
    public int TeamSize { get; set; }
    public int GameId { get; set; }
    public Game Game { get; set; }
    public int PlatformId { get; set; }
    public Platform Platform { get; set; }
    public ICollection<Region> Regions { get; set; }
    public DateTimeOffset StartDate { get; set; }
    public DateTimeOffset? EndDate { get; set; }
}
