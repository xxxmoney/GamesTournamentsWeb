namespace GamesTournamentsWeb.Infrastructure;

public static class Constants
{
    public const int PageCount = 9;
    
    public const string AppSettings = "AppSettings";

    public static TimeSpan TokenExpiration = TimeSpan.FromDays(7);
}