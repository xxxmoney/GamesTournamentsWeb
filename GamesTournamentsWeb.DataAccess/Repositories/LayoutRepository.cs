using GamesTournamentsWeb.DataAccess.Contexts;
using GamesTournamentsWeb.DataAccess.Models.Dashboard;
using Microsoft.EntityFrameworkCore;

namespace GamesTournamentsWeb.DataAccess.Repositories;

public interface ILayoutRepository : IRepository
{
    Task<List<Layout>> GetLayoutsAsync();
    
    void UpdateLayout(Layout layout);
}

public class LayoutRepository(WebContext context) : ILayoutRepository
{
    public Task<List<Layout>> GetLayoutsAsync()
    {
        return context.Layouts.ToListAsync();
    }

    public void UpdateLayout(Layout layout)
    {
        context.Layouts.Update(layout);
    }
}