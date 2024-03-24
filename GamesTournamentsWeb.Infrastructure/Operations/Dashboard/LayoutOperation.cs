using AutoMapper;
using GamesTournamentsWeb.DataAccess.Repositories;
using GamesTournamentsWeb.Infrastructure.Dto.Dashboard;
using GamesTournamentsWeb.Infrastructure.Helpers;
using GamesTournamentsWeb.Infrastructure.ViewModels.Dashboard;

namespace GamesTournamentsWeb.Infrastructure.Operations.Dashboard;

public interface ILayoutOperation : IOperation
{
    Task<ICollection<Layout>> GetLayoutsForAccountAsync(int accountId);
    
    Task<LayoutOverview> UpsertLayoutAsync(LayoutEdit layoutEdit);
    
    Task<LayoutItem> UpsertLayoutItemsAsync(int layoutId, ICollection<LayoutItemEdit> layoutItemEdits);
}

public class LayoutOperation(IRepositoryProvider repositoryProvider, IMapper mapper) : ILayoutOperation
{
    public async Task<ICollection<Layout>> GetLayoutsForAccountAsync(int accountId)
    {
        using var scope = repositoryProvider.CreateScope();
        var layoutRepository = scope.Provide<ILayoutRepository>();

        var models = await layoutRepository.GetLayoutByAccountIdAsync(accountId);
        
        return mapper.Map<List<Layout>>(models);
    }

    public async Task<LayoutOverview> UpsertLayoutAsync(LayoutEdit layoutEdit)
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
        
        mapper.Map(layoutEdit, layout);
        await scope.SaveChangesAsync();
        
        return mapper.Map<LayoutOverview>(layout);
    }

    public async Task<LayoutItem> UpsertLayoutItemsAsync(int layoutId, ICollection<LayoutItemEdit> layoutItemEdits)
    {
        using var scope = repositoryProvider.CreateScope();
        var layoutRepository = scope.Provide<ILayoutRepository>();
        
        var models = await layoutRepository.GetLayoutItemsByLayoutIdAsync(layoutId);
        layoutRepository.DeleteLayoutItems(models);
        
        var newModels = mapper.Map<List<DataAccess.Models.Dashboard.LayoutItem>>(layoutItemEdits);
        await layoutRepository.AddLayoutItemsAsync(newModels);
        
        await scope.SaveChangesAsync();
        
        return mapper.Map<LayoutItem>(newModels);
    }
}