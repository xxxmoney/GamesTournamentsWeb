namespace GamesTournamentsWeb.Infrastructure.Dto.Tournaments;

public class TournamentFilter
{
    public string Name { get; set; }
    public int? GameId { get; set; }
    public int[] TeamSizes { get; set; }
    public int[] RegionIds { get; set; }
    public int[] PlatformIds { get; set; }
    public int[] GenreIds { get; set; }
    public bool WithMyTournaments { get; set; }
    public int Page { get; set; }
}