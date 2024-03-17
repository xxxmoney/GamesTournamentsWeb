namespace GamesTournamentsWeb.Common.Models;

public class PagedResult<T>
    where T : class, new()
{
    public int CurrentPage { get; set; }
    public int PageSize { get; set; }
    public int RowCount { get; set; }
    public int PageCount { get; set; }
    public ICollection<T> Results { get; set; }
    
    public PagedResult<R> WithData<R>(ICollection<R> data) where R : class, new()
    {
        return new PagedResult<R>
        {
            CurrentPage = this.CurrentPage,
            PageSize = this.PageSize,
            RowCount = this.RowCount,
            PageCount = this.PageCount,
            Results = data
        };
    }
}
