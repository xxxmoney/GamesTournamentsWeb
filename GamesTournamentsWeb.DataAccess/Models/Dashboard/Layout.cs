using GamesTournamentsWeb.DataAccess.Models.Users;

namespace GamesTournamentsWeb.DataAccess.Models.Dashboard;

public class Layout
{
    public int Id { get; set; }
    public string Name { get; set; }
    public int AccountId { get; set; }
    public Account Account { get; set; }
    public ICollection<LayoutItem> Items { get; set; }
}