namespace GamesTournamentsWeb.Infrastructure;

public static class Constants
{
    public const int PerPageCount = 3;
    
    public const string AppSettings = "AppSettings";

    public static TimeSpan TokenExpiration = TimeSpan.FromDays(7);
}