namespace GamesTournamentsWeb.Infrastructure.ViewModels.Dashboard;

public class LayoutItemsEdit
{
    public int LayoutId { get; set; }
    public ICollection<LayoutItemEdit> Items { get; set; }
}