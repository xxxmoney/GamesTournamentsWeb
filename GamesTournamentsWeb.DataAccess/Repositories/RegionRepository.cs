using GamesTournamentsWeb.DataAccess.Contexts;
using GamesTournamentsWeb.DataAccess.Models.Tournaments;
using Microsoft.EntityFrameworkCore;

namespace GamesTournamentsWeb.DataAccess.Repositories;

public interface IRegionRepository : IRepository
{
    Task<List<Region>> GetRegionsAsync();
}

public class RegionRepository(WebContext context) : IRegionRepository
{
    public Task<List<Region>> GetRegionsAsync()
    {
        return context.Regions.ToListAsync();
    }
}