using GamesTournamentsWeb.DataAccess.Contexts;
using GamesTournamentsWeb.DataAccess.Models.Dashboard;

namespace GamesTournamentsWeb.DataAccess.Repositories;

public interface ILayoutItemRepository : IRepository
{
    Task AddLayoutItemAsync(LayoutItem layoutItem);
    
    void UpdateLayoutItem(LayoutItem layoutItem);
}

public class LayoutItemRepository(WebContext context) : ILayoutItemRepository
{
    public async Task AddLayoutItemAsync(LayoutItem layoutItem)
    {
        await context.LayoutItems.AddAsync(layoutItem);
    }

    public void UpdateLayoutItem(LayoutItem layoutItem)
    {
        context.LayoutItems.Update(layoutItem);
    }
}
