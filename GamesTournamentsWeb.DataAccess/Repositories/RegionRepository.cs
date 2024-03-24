using GamesTournamentsWeb.DataAccess.Contexts;
using GamesTournamentsWeb.DataAccess.Models.Tournaments;
using Microsoft.EntityFrameworkCore;

namespace GamesTournamentsWeb.DataAccess.Repositories;

public interface IRegionRepository : IRepository
{
    Task<List<Region>> GetRegionsAsync();
    
    ValueTask<Region> GetRegionByIdAsync(int regionId);    
}

public class RegionRepository(WebContext context) : IRegionRepository
{
    public Task<List<Region>> GetRegionsAsync()
    {
        return context.Regions.ToListAsync();
    }

    public ValueTask<Region> GetRegionByIdAsync(int regionId)
    {
        return context.Regions.FindAsync(regionId);
    }
}