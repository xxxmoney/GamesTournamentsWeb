using GamesTournamentsWeb.DataAccess.Contexts;
using GamesTournamentsWeb.DataAccess.Models.Dashboard;
using Microsoft.EntityFrameworkCore;

namespace GamesTournamentsWeb.DataAccess.Repositories;

public interface ILayoutRepository : IRepository
{
    Task<List<Layout>> GetLayoutByAccountIdAsync(int accountId);
    
    ValueTask<Layout> GetLayoutByIdAsync(int layoutId);
    
    Task<List<LayoutItem>> GetLayoutItemsByLayoutIdAsync(int layoutId);
    
    void UpdateLayout(Layout layout);
   
    
    Task AddLayoutAsync(Layout layout);
    
    void RemoveLayout(Layout layout);
  
    void UpdateLayoutItems(ICollection<LayoutItem> layoutItems);
    
    Task AddLayoutItemsAsync(ICollection<LayoutItem> layoutItem);
    
    void DeleteLayoutItems(ICollection<LayoutItem> layoutItem);
}

public class LayoutRepository(WebContext context) : ILayoutRepository
{
    public Task<List<Layout>> GetLayoutByAccountIdAsync(int accountId)
    {
        return context.Layouts
            .Include(layout => layout.Items).Where(layout => layout.AccountId == accountId)
            .ToListAsync();
    }

    public ValueTask<Layout> GetLayoutByIdAsync(int layoutId)
    {
        return context.Layouts.FindAsync(layoutId);
    }

    public Task<List<LayoutItem>> GetLayoutItemsByLayoutIdAsync(int layoutId)
    {
        return context.LayoutItems.Where(item => item.LayoutId == layoutId).ToListAsync();
    }

    public void UpdateLayout(Layout layout)
    {
        context.Layouts.Update(layout);
    }

 

    public async Task AddLayoutAsync(Layout layout)
    {
        await context.Layouts.AddAsync(layout);
    }

    public void RemoveLayout(Layout layout)
    {
        context.Layouts.Remove(layout);
    }

    public void UpdateLayoutItems(ICollection<LayoutItem> layoutItems)
    {
        context.LayoutItems.UpdateRange(layoutItems);
    }

    public Task AddLayoutItemsAsync(ICollection<LayoutItem> layoutItem)
    {
        return context.LayoutItems.AddRangeAsync(layoutItem);
    }

    public void DeleteLayoutItems(ICollection<LayoutItem> layoutItem)
    {
        context.LayoutItems.RemoveRange(layoutItem);
    }
}