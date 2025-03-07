using System.ComponentModel.DataAnnotations;

namespace InitPoroject.Domain.Entity;

public class Product
{
    public int Id { get; set; }
    [MaxLength(200)]
    public string Name { get; set; } = string.Empty;
    public double Price { get; set; }
    public int Quantity { get; set; }
    [MaxLength(100)]
    public string Category { get; set; } = string.Empty;
    public IList<string> Colors { get; set; } = [];
    public DateTime CreatedAt { get; } = DateTime.Now;
    public DateTime UpdatedAt { get; set; }
}