using System.Security.Principal;
using InitPoroject.Data;
using InitPoroject.Domain.Entity;
using InitPoroject.Dto;
using InitPoroject.Helpers;
using InitPoroject.Interface;
using InitPoroject.Mappers;
using Microsoft.EntityFrameworkCore;

namespace InitPoroject.Repository;

public class ProductRepository : IProductRepository
{
    private readonly AppDbContext _context;

    public ProductRepository(AppDbContext context)
    {
        _context = context;
    }
    

    public async Task<IList<Product>> GetAllProductsAsync(QueryObject queryObject)
    {
        var products = _context.Products.AsQueryable();
        if (queryObject is null)
        {
            throw new ArgumentNullException("queryObject Null");
        }

        if (string.IsNullOrWhiteSpace(queryObject.SortBy))
            return await products.ToListAsync();
        switch (queryObject.SortBy)
        {
            case "Name":
                products = queryObject.IsDescending 
                    ? products.OrderByDescending(p=>p.Name)
                    : products.OrderBy(p=>p.Name);
                break;
            case "Price":
                products = queryObject.IsDescending 
                    ? products.OrderByDescending(p=>p.Price)
                    : products.OrderBy(p=>p.Price);
                break;
            case "Category":
                products = queryObject.IsDescending 
                    ? products.OrderByDescending(p=>p.Category)
                    : products.OrderBy(p=>p.Category);
                break;
            case "Quantity":
                products = queryObject.IsDescending 
                    ? products.OrderByDescending(p=>p.Quantity)
                    : products.OrderBy(p=>p.Quantity);
                break;
            case "CreatedAt":
                products = queryObject.IsDescending 
                    ? products.OrderByDescending(p=>p.CreatedAt)
                    : products.OrderBy(p=>p.CreatedAt);
            break;
        }
        return await products.ToListAsync();
    }

    public async Task<Product> AddProductAsync(Product productDto)
    {
        await _context.Products.AddAsync(productDto);
        await _context.SaveChangesAsync();
        return productDto;
    }


    public async Task<Product?> GetProductById(int id)
    {
        return await _context.Products.FirstOrDefaultAsync(p => p.Id.Equals(id));
    }

    public async Task<IList<Product>?> GetProductsByName(string name)
    {
        return await _context.Products.Where(p=>p.Name.Contains(name))
            .ToListAsync();
    }

    public async Task<IList<Product>?> GetProductsByCategory(string category)
    {
        return await _context.Products.Where(p => p.Category.Equals(category)).ToListAsync();
    }


    public async Task<Product?> UpdateProduct(int productId, Product productDto)
    {
        var product = await _context.Products.FirstOrDefaultAsync(p => p.Id.Equals(productId));
        if (product is null)
            return null;
        product.Name = productDto.Name;
        product.Category = productDto.Category;
        product.Colors = productDto.Colors;
        product.Quantity = productDto.Quantity;
        product.UpdatedAt = productDto.UpdatedAt;
        await _context.SaveChangesAsync();
        return product;
    }

    public async Task<bool> DeleteProductById(int id)
    {
        var product = await _context.Products.FirstOrDefaultAsync(p => p.Id.Equals(id));
        if (product is null)
            return false;
        _context.Products.Remove(product);
        await _context.SaveChangesAsync();
        return true;
    }
}