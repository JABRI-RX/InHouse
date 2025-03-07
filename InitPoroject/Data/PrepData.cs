using InitPoroject.Domain.Entity;
using Microsoft.EntityFrameworkCore;

namespace InitPoroject.Data;

public static class PrepData
{
    public static void SeedData(this IServiceProvider serviceProvider)
    {
        using (var context = new AppDbContext(serviceProvider.GetRequiredService<DbContextOptions<AppDbContext>>()))
        {
            if (context is null || context.Products is null)
            {
                throw new ArgumentNullException("DbContext empty");
            }
            if (context.Products.Any())
                return;

            context.Products.AddRange(
                new Product
                {
                    Name = "Car",
                    Category = "AutoMobile",
                    Colors = ["Red", "Green", "White"],
                    Price = 1000,
                    Quantity = 4,
                    UpdatedAt = DateTime.Now
                },
                new Product
                {
                    Name = "Laptop",
                    Category = "Computer",
                    Colors = ["Black", "Green", "White"],
                    Price = 300,
                    Quantity = 40,
                    UpdatedAt = DateTime.Now
                },
                new Product
                {
                    Name = "Notebook",
                    Category = "Books",
                    Colors = ["Red", "Green", "White", "Yellow"],
                    Price = 100,
                    Quantity = 100,
                    UpdatedAt = DateTime.Now
                },
                new Product
                {
                    Name = "Smartphone",
                    Category = "Electronics",
                    Colors = ["Black", "Blue", "Silver"],
                    Price = 700,
                    Quantity = 25,
                    UpdatedAt = DateTime.Now
                },
                new Product
                {
                    Name = "Washing Machine",
                    Category = "Home Appliances",
                    Colors = ["White", "Grey"],
                    Price = 450,
                    Quantity = 15,
                    UpdatedAt = DateTime.Now
                },
                new Product
                {
                    Name = "Table",
                    Category = "Furniture",
                    Colors = ["Brown", "Black"],
                    Price = 150,
                    Quantity = 30,
                    UpdatedAt = DateTime.Now
                },
                new Product
                {
                    Name = "Bicycle",
                    Category = "Sports & Outdoors",
                    Colors = ["Red", "Blue", "Black"],
                    Price = 500,
                    Quantity = 20,
                    UpdatedAt = DateTime.Now
                },
                new Product
                {
                    Name = "Headphones",
                    Category = "Audio",
                    Colors = ["Black", "White"],
                    Price = 120,
                    Quantity = 60,
                    UpdatedAt = DateTime.Now
                },
                new Product
                {
                    Name = "Smartwatch",
                    Category = "Wearables",
                    Colors = ["Black", "Silver", "Gold"],
                    Price = 250,
                    Quantity = 35,
                    UpdatedAt = DateTime.Now
                },
                new Product
                {
                    Name = "Refrigerator",
                    Category = "Home Appliances",
                    Colors = ["Silver", "White"],
                    Price = 900,
                    Quantity = 10,
                    UpdatedAt = DateTime.Now
                }
            );

            context.SaveChanges();
        }
    }
}
