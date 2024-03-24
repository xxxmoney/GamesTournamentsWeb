using GamesTournamentsWeb.Infrastructure.Operations.Dashboard;
using GamesTournamentsWeb.Infrastructure.ViewModels.Dashboard;
using Microsoft.AspNetCore.Mvc;

namespace GamesTournamentsWeb.Web.Controllers;

public class DashboardController(ILayoutOperation layoutOperation) : BaseController
{
    [HttpGet("layouts")]
    public async Task<IActionResult> GetLayouts()
    {
        if (!this.AccountId.HasValue)
        {
            return Unauthorized();
        }
        
        return Ok(await layoutOperation.GetLayoutsForAccountAsync(this.AccountId.Value));
    }
    
    [HttpPost("layouts/upsert")]
    public async Task<IActionResult> UpsertLayout(LayoutEdit layoutEdit)
    {
        return Ok(await layoutOperation.UpsertLayoutAsync(layoutEdit));
    }
    
    [HttpPost("layouts/items/upsert")]
    public async Task<IActionResult> UpsertLayoutItems(LayoutItemsEdit layoutItemEdits)
    {
        return Ok(await layoutOperation.UpsertLayoutItemsAsync(layoutItemEdits));
    }

}