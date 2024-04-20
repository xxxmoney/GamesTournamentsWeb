using AutoMapper;
using GamesTournamentsWeb.DataAccess.Repositories;
using GamesTournamentsWeb.Infrastructure.Dto.Dashboard;
using GamesTournamentsWeb.Infrastructure.Operations.Users;
using GamesTournamentsWeb.Infrastructure.ViewModels.Dashboard;

namespace GamesTournamentsWeb.Infrastructure.Operations.Dashboard;

public interface IModulesOperation : IOperation
{
    Task<ModuleWinLossRatioData> GetModuleWinLossRatioDataAsync(ModuleWinLossRatioRequest request);
}

public class ModulesOperation(IAccountOperation accountOperation) : IModulesOperation
{
    public async Task<ModuleWinLossRatioData> GetModuleWinLossRatioDataAsync(ModuleWinLossRatioRequest request)
    {
        var info = await accountOperation.GetAccountInfoByIdAsync(request.AccountId);
        return new ModuleWinLossRatioData
        {
            WinCount = info.WinCount,
            LossCount = info.LossCount
        };
    }
}