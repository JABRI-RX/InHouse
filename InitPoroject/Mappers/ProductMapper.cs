using InitPoroject.Domain.Entity;
using InitPoroject.Dto;
using InitPoroject.Dto.product;

namespace InitPoroject.Mappers;

public static class ProductMapper
{
    public static ReadProductDto ToReadProduct( this Product product)
    {
        return new ReadProductDto
        {
            Name = product.Name,
            Category = product.Category,
            Colors = product.Colors,
            Price = product.Price,
            Quantity = product.Quantity,
            UpdatedAt = product.UpdatedAt
        };
    }
    public static Product ToProduct(this CreateProductDto product)
    {
        return new Product
        {
            Name = product.Name,
            Category = product.Category,
            Colors = product.Colors,
            Price = product.Price,
            Quantity = product.Quantity,
            UpdatedAt = product.UpdatedAt
        };
    }
    public static Product ToProduct(this UpdateProductDto product)
    {
        return new Product
        {
            Name = product.Name,
            Category = product.Category,
            Colors = product.Colors,
            Price = product.Price,
            Quantity = product.Quantity,
            UpdatedAt = product.UpdatedAt
        };
    }
}