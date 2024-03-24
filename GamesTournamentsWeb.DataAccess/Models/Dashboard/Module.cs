namespace GamesTournamentsWeb.DataAccess.Models.Dashboard;

public class Module
{
    public int Id { get; set; }
    public string Name { get; set; }
    public ICollection<LayoutItem> LayoutItems { get; set; }
}