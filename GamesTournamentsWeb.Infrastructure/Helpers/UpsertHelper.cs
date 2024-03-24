namespace GamesTournamentsWeb.Infrastructure.Helpers;

public static class UpsertHelper
{
    public static bool EntityExists(int? id) => id.HasValue && id.Value != 0;
} 