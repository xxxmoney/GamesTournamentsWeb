namespace GamesTournamentsWeb.DataAccess.Models.Tournaments;

public class Genre
{
    public int Id { get; set; }
    public string Name { get; set; }
    public ICollection<Game> Games { get; set; }
}