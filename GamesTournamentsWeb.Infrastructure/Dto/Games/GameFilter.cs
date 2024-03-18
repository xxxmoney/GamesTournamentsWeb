namespace GamesTournamentsWeb.Infrastructure.Dto.Games;

public class GameFilter
{
    public string Name { get; set; }
    public int[] GenreIds { get; set; }
    public bool WithMyTournaments { get; set; }
    public int Page { get; set; }
}