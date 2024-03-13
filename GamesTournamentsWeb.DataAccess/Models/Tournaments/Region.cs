namespace GamesTournamentsWeb.DataAccess.Models.Tournaments;

public class Region
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Code { get; set; }
    public ICollection<Tournament> Tournaments { get; set; }
}