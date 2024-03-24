using System.Text.Json.Serialization;

namespace GamesTournamentsWeb.Infrastructure.ViewModels.Dashboard;

public class LayoutItemEdit
{
    public int? Id { get; set; }
    [JsonPropertyName("i")]
    public int Index { get; set; }
    [JsonPropertyName("x")]
    public int X { get; set; }
    [JsonPropertyName("y")]
    public int Y { get; set; }
    [JsonPropertyName("w")]
    public int Width { get; set; }
    [JsonPropertyName("h")]
    public int Height { get; set; }
    public int ModuleId { get; set; }
    public int LayoutId { get; set; }
}