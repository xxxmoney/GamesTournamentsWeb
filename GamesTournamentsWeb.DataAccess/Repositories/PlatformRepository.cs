using GamesTournamentsWeb.DataAccess.Contexts;
using GamesTournamentsWeb.DataAccess.Models.Tournaments;
using Microsoft.EntityFrameworkCore;

namespace GamesTournamentsWeb.DataAccess.Repositories;

public interface IPlatformRepository : IRepository
{
    Task<List<Platform>> GetPlatformsAsync();
}
 
public class PlatformRepository(WebContext context) : IPlatformRepository
{
    public Task<List<Platform>> GetPlatformsAsync()
    {
        return context.Platforms.ToListAsync();
    }
}