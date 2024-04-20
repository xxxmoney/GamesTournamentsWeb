using AutoMapper;
using GamesTournamentsWeb.DataAccess.Repositories;
using GamesTournamentsWeb.Infrastructure.Dto.Dashboard;
using GamesTournamentsWeb.Infrastructure.Helpers;
using GamesTournamentsWeb.Infrastructure.ViewModels.Dashboard;

namespace GamesTournamentsWeb.Infrastructure.Operations.Dashboard;

public interface ILayoutOperation : IOperation
{
    Task<ICollection<Layout>> GetLayoutsForAccountAsync(int accountId);
    
    Task<LayoutOverview> UpsertLayoutAsync(int accountId, LayoutEdit layoutEdit);
    
    Task RemoveLayoutAsync(int layoutId);

    Task<ICollection<LayoutItem>> UpsertLayoutItemsAsync(LayoutItemsEdit layoutItemEdits);
}

public class LayoutOperation(IRepositoryProvider repositoryProvider, IMapper mapper) : ILayoutOperation
{
    public async Task<ICollection<Layout>> GetLayoutsForAccountAsync(int accountId)
    {
        using var scope = repositoryProvider.CreateScope();
        var layoutRepository = scope.Provide<ILayoutRepository>();

        var models = await layoutRepository.GetLayoutByAccountIdAsync(accountId);
        
        var result = mapper.Map<List<Layout>>(models);
        // Set indexes for layout items
        foreach (var layout in result)
        {
            CalculateIndexesForLayoutItems(layout.Items);
        }
        
        return result;
    }

    public async Task<LayoutOverview> UpsertLayoutAsync(int accountId, LayoutEdit layoutEdit)
    {
        DataAccess.Models.Dashboard.Layout layout;
        using var scope = repositoryProvider.CreateScope();
        var layoutRepository = scope.Provide<ILayoutRepository>();
        
        if (UpsertHelper.EntityExists(layoutEdit.Id))
        {
            layout = await layoutRepository.GetLayoutByIdAsync(layoutEdit.Id!.Value);
            layoutRepository.UpdateLayout(layout);
        }
        else
        {
            layout = new DataAccess.Models.Dashboard.Layout();
            await layoutRepository.AddLayoutAsync(layout);
        }
        
        layout.AccountId = accountId;
        mapper.Map(layoutEdit, layout);
        await scope.SaveChangesAsync();
        
        return mapper.Map<LayoutOverview>(layout);
    }

    public async Task RemoveLayoutAsync(int layoutId)
    {
        using var scope = repositoryProvider.CreateScope();
        var layoutRepository = scope.Provide<ILayoutRepository>();
        
        var model = await layoutRepository.GetLayoutByIdAsync(layoutId);
        layoutRepository.RemoveLayout(model);
        
        await scope.SaveChangesAsync();
    }

    public async Task<ICollection<LayoutItem>> UpsertLayoutItemsAsync(LayoutItemsEdit layoutItemEdits)
    {
        using var scope = repositoryProvider.CreateScope();
        var layoutRepository = scope.Provide<ILayoutRepository>();
        
        var models = await layoutRepository.GetLayoutItemsByLayoutIdAsync(layoutItemEdits.LayoutId);
        layoutRepository.DeleteLayoutItems(models);
        
        var newModels = mapper.Map<List<DataAccess.Models.Dashboard.LayoutItem>>(layoutItemEdits.Items);
        await layoutRepository.AddLayoutItemsAsync(newModels);
        
        await scope.SaveChangesAsync();
        
        var result = mapper.Map<List<LayoutItem>>(newModels);
        CalculateIndexesForLayoutItems(result);
        
        return result;
    }
    
    
    private static void CalculateIndexesForLayoutItems(ICollection<LayoutItem> items)
    {
        for (var i = 0; i < items.Count; i++)
        {
            items.ElementAt(i).Index = i;
        }
    }
}