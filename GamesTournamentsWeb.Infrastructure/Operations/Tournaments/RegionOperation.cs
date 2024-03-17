using System.Collections;
using AutoMapper;
using GamesTournamentsWeb.DataAccess.Repositories;
using GamesTournamentsWeb.Infrastructure.Dto.Tournaments;

namespace GamesTournamentsWeb.Infrastructure.Operations.Tournaments;

public interface IRegionOperation : IOperation
{
    Task<ICollection<Region>> GetRegionsAsync();
}

public class RegionOperation(IRepositoryProvider repositoryProvider, IMapper mapper) : IRegionOperation
{
    public async Task<ICollection<Region>> GetRegionsAsync()
    {
        using var scope = repositoryProvider.CreateScope();
        var regionRepository = scope.Provide<IRegionRepository>();
        
        var models = await regionRepository.GetRegionsAsync();
        return mapper.Map<List<Region>>(models);
    }
}