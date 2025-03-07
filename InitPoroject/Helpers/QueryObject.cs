namespace InitPoroject.Helpers;

public class QueryObject
{
    public string? SortBy { get; set; }
    public bool IsDescending { get; set; } = true;
    public int PageNumber { get; set; }
    public int PageSize { get; set; }
}