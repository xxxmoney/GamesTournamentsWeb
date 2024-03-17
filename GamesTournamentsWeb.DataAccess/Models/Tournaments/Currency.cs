namespace GamesTournamentsWeb.DataAccess.Models.Tournaments;

public class Currency
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Code { get; set; }
    public string Locale { get; set; }
    public string Symbol { get; set; }
    public ICollection<Prize> Prizes { get; set; }
}