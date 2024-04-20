using GamesTournamentsWeb.Infrastructure.Operations.Dashboard;
using GamesTournamentsWeb.Infrastructure.ViewModels.Dashboard;
using Microsoft.AspNetCore.Mvc;

namespace GamesTournamentsWeb.Web.Controllers;

public class ModulesController(IModulesOperation modulesOperation) : BaseController
{
    [HttpPost("win-loss-ratio")]
    public async Task<IActionResult> GetModuleWinLossRatioData(ModuleWinLossRatioRequest request)
    {
        return Ok(await modulesOperation.GetModuleWinLossRatioDataAsync(request));
    }
}