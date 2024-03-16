namespace GamesTournamentsWeb.Infrastructure.Dtos;

public class Error(Exception ex)
{
    public string Type { get; set; } = ex.GetType().Name;
    public string Message { get; set; } = ex.Message;
    public string StackTrace { get; set; } = ex.ToString();
}
