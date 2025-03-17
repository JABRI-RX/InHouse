using InitPoroject.Domain.Entity;
using InitPoroject.Domain.Entity.VoitureM;
using Microsoft.EntityFrameworkCore;

namespace InitPoroject.Data;

public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
{
    public DbSet<Product> Products { get; set; }
    public DbSet<Client> Clients { get; set; }
    public DbSet<Voiture> Voitures { get; set; }
    public DbSet<Couleur> Couleurs { get; set; }
    public DbSet<Marque> Marques { get; set; }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        //jointure voiture -> Client vise versa 
        modelBuilder.Entity<Voiture>()
            .HasOne(v => v.Client)
            .WithMany(c => c.Voitures)
            .HasForeignKey(v => v.ClientCIN);
        //jointure voiture->couleur
        modelBuilder.Entity<Voiture>()
            .HasOne(v => v.Couleur)
            .WithMany(c => c.Voitures)
            .HasForeignKey(v => v.CouleurId);
        //jointure voiture->marque
        modelBuilder.Entity<Voiture>()
            .HasOne(v => v.Marque)
            .WithMany(m => m.Voitures)
            .HasForeignKey(v => v.MarqueId);
    }
}