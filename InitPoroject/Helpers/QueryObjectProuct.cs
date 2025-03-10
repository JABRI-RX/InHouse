namespace InitPoroject.Helpers;

public class QueryObjectProuct
{
    public string? Name;
    public string? Category;
    public string? SortBy { get; set; }
    public bool IsDescending { get; set; } = true;
    // public int PageNumber { get; set; }
    // public int PageSize { get; set; }
}