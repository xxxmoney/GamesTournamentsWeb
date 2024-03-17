using AutoMapper;
using GamesTournamentsWeb.DataAccess.Repositories;
using GamesTournamentsWeb.Infrastructure.Dto.Tournaments;

namespace GamesTournamentsWeb.Infrastructure.Operations.Tournaments;

public interface IPlatformOperation : IOperation
{
    Task<ICollection<Platform>> GetPlatformsAsync();
}

public class PlatformOperation(IRepositoryProvider repositoryProvider, IMapper mapper) : IPlatformOperation
{
    public async Task<ICollection<Platform>> GetPlatformsAsync()
    {
        using var scope = repositoryProvider.CreateScope();
        var platformRepository = scope.Provide<IPlatformRepository>();
        
        var models = await platformRepository.GetPlatformsAsync();
        return mapper.Map<List<Platform>>(models);
    }
}