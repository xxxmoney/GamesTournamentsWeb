using GamesTournamentsWeb.DataAccess.Models.Tournaments;

namespace GamesTournamentsWeb.DataAccess.Models.Games;

public class Game
{
    public int Id { get; set; }
    public string Name { get; set; }
    public int GenreId { get; set; }
    public Genre Genre { get; set; }
    public ICollection<Tournament> Tournaments { get; set; }
    public string ImageUrl { get; set; }
}