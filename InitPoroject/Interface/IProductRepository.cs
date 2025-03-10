using InitPoroject.Domain.Entity;
using InitPoroject.Dto;
using InitPoroject.Helpers;

namespace InitPoroject.Interface;

public interface IProductRepository
{
    Task<Product> AddProductAsync(Product product);
    Task<IList<Product>> GetAllProductsAsync(QueryObjectProuct queryObject);
    Task<Product?> GetProductById(int id);
    Task<IList<Product>?> GetProductsByName(string name);
    Task<IList<Product>?> GetProductsByCategory(string category);
    Task<Product?> UpdateProduct(int productId,Product productDto);
    Task<bool> DeleteProductById(int id);
}