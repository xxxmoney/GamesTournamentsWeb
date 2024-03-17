using AutoMapper;
using GamesTournamentsWeb.DataAccess.Repositories;
using GamesTournamentsWeb.Infrastructure.Dto.Tournaments;

namespace GamesTournamentsWeb.Infrastructure.Operations.Tournaments;

public interface ICurrencyOperation : IOperation
{
    Task<ICollection<Currency>> GetCurrenciesAsync();
}

public class CurrencyOperation(IRepositoryProvider repositoryProvider, IMapper mapper) : ICurrencyOperation
{
    public async Task<ICollection<Currency>> GetCurrenciesAsync()
    {
        using var scope = repositoryProvider.CreateScope();
        var currencyRepository = scope.Provide<ICurrencyRepository>();
        
        var models = await currencyRepository.GetCurrenciesAsync();
        return mapper.Map<List<Currency>>(models);
    }
}