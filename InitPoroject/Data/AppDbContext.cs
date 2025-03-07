using InitPoroject.Domain.Entity;
using Microsoft.EntityFrameworkCore;

namespace InitPoroject.Data;

public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
{
    public DbSet<Product> Products { get; set; }
}