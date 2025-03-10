using InitPoroject.Domain.Entity;
using Microsoft.EntityFrameworkCore;

namespace InitPoroject.Data;

public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
{
    public DbSet<Product> Products { get; set; }
    public DbSet<Client> Clients { get; set; }
    public DbSet<Voiture> Voitures { get; set; }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.Entity<Voiture>()
            .HasOne(c => c.Client)
            .WithMany(v => v.Voitures)
            .HasForeignKey(c => c.ClientCIN);
    }
}