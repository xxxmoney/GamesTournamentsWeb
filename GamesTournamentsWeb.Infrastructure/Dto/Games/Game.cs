using GamesTournamentsWeb.Infrastructure.Dto.Tournaments;

namespace GamesTournamentsWeb.Infrastructure.Dto.Games;

public class Game
{
    public int Id { get; set; }
    public string Name { get; set; }
    public Genre Genre { get; set; }
    public string ImageUrl { get; set; }
}