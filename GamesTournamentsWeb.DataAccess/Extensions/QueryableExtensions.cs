using GamesTournamentsWeb.Common.Models;
using Microsoft.EntityFrameworkCore;
using Z.EntityFramework.Plus;

namespace GamesTournamentsWeb.DataAccess.Extensions;

public static class QueryableExtensions
{
    public static async Task<PagedResult<T>> ToPagedAsync<T>(this IQueryable<T> query, int page, int pageSize) 
        where T : class, new()
    {
        var result = new PagedResult<T>();
        result.CurrentPage = page;
        result.PageSize = pageSize;
        result.RowCount = query.Count();
    
        var pageCount = (double)result.RowCount / pageSize;
        result.PageCount = (int)Math.Ceiling(pageCount);
    
        var skip = (page - 1) * pageSize;
        result.Results = await query.Skip(skip).Take(pageSize).ToListAsync();
    
        return result;
    }
}
