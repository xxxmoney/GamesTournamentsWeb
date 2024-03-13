namespace GamesTournamentsWeb.DataAccess.Models.Tournaments;

public class Game
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public int GenreId { get; set; }
    public Genre Genre { get; set; }
    public string ImageUrl { get; set; }
    
}

