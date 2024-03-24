namespace GamesTournamentsWeb.DataAccess.Models.Dashboard;

public class LayoutItem
{
    public int Id { get; set; }
    public int X { get; set; }
    public int Y { get; set; }
    public int Width { get; set; }
    public int Height { get; set; }
    public int ModuleId { get; set; }
    public Module Module { get; set; }
    public int LayoutId { get; set; }
    public Layout Layout { get; set; }
}