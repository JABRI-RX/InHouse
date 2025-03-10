using System.ComponentModel.DataAnnotations;

namespace InitPoroject.Dto.product;

public class CreateProductDto
{
    [Required]
    public string Name { get; set; } = string.Empty;
    [Required]
    public double Price { get; set; }
    [Required]
    public int Quantity { get; set; }
    [Required]
    public string Category { get; set; } = string.Empty;
    [Required]
    public IList<string> Colors { get; set; } = [];
    [Required]
    public DateTime UpdatedAt { get; set; }
}