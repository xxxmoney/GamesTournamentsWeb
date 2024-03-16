namespace GamesTournamentsWeb.Common.Models;

public class PagedResult<T>
    where T : class, new()
{
    public int CurrentPage { get; set; }
    public int PageSize { get; set; }
    public int RowCount { get; set; }
    public int PageCount { get; set; }
    public List<T> Results { get; set; }
}
