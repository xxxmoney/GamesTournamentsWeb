namespace GamesTournamentsWeb.Infrastructure.Dto.Dashboard;

public class Layout
{
    public int Id { get; set; }
    public string Name { get; set; }
    public ICollection<LayoutItem> Items { get; set; }
}