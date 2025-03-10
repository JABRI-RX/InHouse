using Microsoft.Build.Framework;

namespace InitPoroject.Dto;

public class ReadProductDto
{
    public string Name { get; set; } = string.Empty;
    public double Price { get; set; }
    public int Quantity { get; set; }
    public string Category { get; set; } = string.Empty;
    public IList<string> Colors { get; set; } = [];
    public DateTime CreatedAt { get; } = DateTime.Now;
    public DateTime UpdatedAt { get; set; }
}