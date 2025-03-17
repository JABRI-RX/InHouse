using InitPoroject.Domain.Entity;
using InitPoroject.Domain.Entity.VoitureM;
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

            SeedCouleurs(context);
            SeedMarque(context);
            SeedClient(context);
            context.SaveChanges();
        }
    }

    private static void SeedMarque(AppDbContext context)
    {
        if (context.Marques.Any())
            return;
        context.Marques.AddRange(
            new Marque { NomMarque = "Renault" },
            new Marque { NomMarque = "Dacia" },
            new Marque { NomMarque = "Peugeot" },
            new Marque { NomMarque = "Citroën" },
            new Marque { NomMarque = "Toyota" },
            new Marque { NomMarque = "Hyundai" },
            new Marque { NomMarque = "Kia" },
            new Marque { NomMarque = "Ford" },
            new Marque { NomMarque = "Volkswagen" },
            new Marque { NomMarque = "Mercedes-Benz" },
            new Marque { NomMarque = "BMW" },
            new Marque { NomMarque = "Nissan" },
            new Marque { NomMarque = "Opel" },
            new Marque { NomMarque = "Fiat" },
            new Marque { NomMarque = "Chevrolet" },
            new Marque { NomMarque = "Audi" },
            new Marque { NomMarque = "Suzuki" },
            new Marque { NomMarque = "Mitsubishi" },
            new Marque { NomMarque = "Seat" },
            new Marque { NomMarque = "Skoda" }
        );
    }

    private static void SeedCouleurs(AppDbContext context)
    {
        if (context.Couleurs.Any())
            return;
        context.Couleurs.AddRange(
            new Couleur
            {
                NomCouleur = "Noir",
                Voitures = []
            },
            new Couleur
            {
                NomCouleur = "Blanc",
                Voitures = []
            },
            new Couleur
            {
                NomCouleur = "Gris",
                Voitures = []
            },
            new Couleur
            {
                NomCouleur = "Argent",
                Voitures = []
            },
            new Couleur
            {
                NomCouleur = "Bleu",
                Voitures = []
            },
            new Couleur
            {
                NomCouleur = "Rouge",
                Voitures = []
            },
            new Couleur
            {
                NomCouleur = "Vert",
                Voitures = []
            },
            new Couleur
            {
                NomCouleur = "Jaune",
                Voitures = []
            },
            new Couleur
            {
                NomCouleur = "Orange",
                Voitures = []
            },
            new Couleur
            {
                NomCouleur = "Marron",
                Voitures = []
            },
            new Couleur
            {
                NomCouleur = "Beige",
                Voitures = []
            },
            new Couleur
            {
                NomCouleur = "Rose",
                Voitures = []
            },
            new Couleur
            {
                NomCouleur = "Violet",
                Voitures = []
            },
            new Couleur
            {
                NomCouleur = "Or",
                Voitures = []
            },
            new Couleur
            {
                NomCouleur = "Bronze",
                Voitures = []
            },
            new Couleur
            {
                NomCouleur = "Turquoise",
                Voitures = []
            },
            new Couleur
            {
                NomCouleur = "Bordeaux",
                Voitures = []
            },
            new Couleur
            {
                NomCouleur = "Mauve",
                Voitures = []
            },
            new Couleur
            {
                NomCouleur = "Corail",
                Voitures = []
            },
            new Couleur
            {
                NomCouleur = "Indigo",
                Voitures = []
            }
        );
    }

    private static void SeedClient(AppDbContext context)
{
    if (context.Clients.Any())
        return;

    // Toggle for Importe (alternates between true and false)
    bool importeToggle = true;

    // Possible accessories and transmission types
    var possibleAccessories = new List<string>
    {
        "Air Conditioning",
        "Sunroof",
        "Heated Seats",
        "Navigation System",
        "Bluetooth",
        "Parking Sensors",
        "Rearview Camera",
        "Leather Seats",
        "Keyless Entry",
        "Wireless Charging"
    };

    var possibleTransmissions = new List<string>
    {
        "Front-Wheel Drive",
        "Rear-Wheel Drive",
        "All-Wheel Drive",
        "4x4"
    };

    context.Clients.AddRange(
        new Client
        {
            CIN = "A123456",
            Nom = "El Amrani",
            Prenom = "Mohamed",
            Adresse = "12 Rue Mohammed V, Casablanca",
            Telephone = "0612345678",
            Voitures = new List<Voiture>
            {
                new Voiture
                {
                    MarqueId = 1, // Renault
                    Modele = "Clio",
                    CouleurId = 1, // Noir (Black)
                    Annee = 2018,
                    Importe = importeToggle, // true
                    Immatriculation = "A-1234-BC",
                    ClientCIN = "A123456",
                    Transmission = new List<string> { "Front-Wheel Drive" },
                    Accessories = new List<string> { "Air Conditioning", "Bluetooth", "Parking Sensors" }
                },
                new Voiture
                {
                    MarqueId = 3, // Peugeot
                    Modele = "208",
                    CouleurId = 2, // Blanc (White)
                    Annee = 2020,
                    Importe = !importeToggle, // false
                    Immatriculation = "A-5678-DE",
                    ClientCIN = "A123456",
                    Transmission = new List<string> { "Rear-Wheel Drive", "All-Wheel Drive" },
                    Accessories = new List<string>
                        { "Sunroof", "Heated Seats", "Navigation System", "Rearview Camera" }
                }
            }
        },
        new Client
        {
            CIN = "B654321",
            Nom = "Bennani",
            Prenom = "Fatima",
            Adresse = "45 Avenue Hassan II, Rabat",
            Telephone = "0623456789",
            Voitures = new List<Voiture>
            {
                new Voiture
                {
                    MarqueId = 2, // Dacia
                    Modele = "Sandero",
                    CouleurId = 2, // Blanc (White)
                    Annee = 2019,
                    Importe = importeToggle, // true
                    Immatriculation = "B-9101-FG",
                    ClientCIN = "B654321",
                    Transmission = new List<string> { "All-Wheel Drive" },
                    Accessories = new List<string> { "Keyless Entry", "Wireless Charging", "Leather Seats" }
                },
                new Voiture
                {
                    MarqueId = 6, // Hyundai
                    Modele = "i20",
                    CouleurId = 1, // Noir (Black)
                    Annee = 2021,
                    Importe = !importeToggle, // false
                    Immatriculation = "B-1121-HI",
                    ClientCIN = "B654321",
                    Transmission = new List<string> { "Front-Wheel Drive", "4x4" },
                    Accessories = new List<string> { "Air Conditioning", "Bluetooth", "Parking Sensors" }
                }
            }
        },
        new Client
        {
            CIN = "C987654",
            Nom = "Cherkaoui",
            Prenom = "Karim",
            Adresse = "8 Boulevard Mohammed VI, Marrakech",
            Telephone = "0634567890",
            Voitures = new List<Voiture>
            {
                new Voiture
                {
                    MarqueId = 5, // Toyota
                    Modele = "Corolla",
                    CouleurId = 6, // Rouge (Red)
                    Annee = 2022,
                    Importe = importeToggle, // true
                    Immatriculation = "C-3141-JK",
                    ClientCIN = "C987654",
                    Transmission = new List<string> { "Front-Wheel Drive" },
                    Accessories = new List<string> { "Air Conditioning", "Sunroof", "Heated Seats" }
                },
                new Voiture
                {
                    MarqueId = 1, // Renault
                    Modele = "Megane",
                    CouleurId = 3, // Gris (Gray)
                    Annee = 2020,
                    Importe = !importeToggle, // false
                    Immatriculation = "C-4151-LM",
                    ClientCIN = "C987654",
                    Transmission = new List<string> { "Rear-Wheel Drive", "All-Wheel Drive" },
                    Accessories = new List<string>
                        { "Navigation System", "Bluetooth", "Parking Sensors", "Rearview Camera" }
                }
            }
        },
        new Client
        {
            CIN = "D123789",
            Nom = "Rhouzlane",
            Prenom = "Amina",
            Adresse = "22 Rue Ibn Battuta, Tanger",
            Telephone = "0645678901",
            Voitures = new List<Voiture>
            {
                new Voiture
                {
                    MarqueId = 3, // Peugeot
                    Modele = "3008",
                    CouleurId = 5, // Bleu (Blue)
                    Annee = 2021,
                    Importe = importeToggle, // true
                    Immatriculation = "D-5161-NO",
                    ClientCIN = "D123789",
                    Transmission = new List<string> { "All-Wheel Drive" },
                    Accessories = new List<string> { "Leather Seats", "Keyless Entry", "Wireless Charging" }
                },
                new Voiture
                {
                    MarqueId = 4, // Citroën
                    Modele = "C4",
                    CouleurId = 1, // Noir (Black)
                    Annee = 2019,
                    Importe = !importeToggle, // false
                    Immatriculation = "D-6171-PQ",
                    ClientCIN = "D123789",
                    Transmission = new List<string> { "Front-Wheel Drive", "4x4" },
                    Accessories = new List<string> { "Air Conditioning", "Bluetooth", "Parking Sensors" }
                }
            }
        },
        new Client
        {
            CIN = "E456123",
            Nom = "Zouhairi",
            Prenom = "Youssef",
            Adresse = "10 Rue Al Massira, Fès",
            Telephone = "0656789012",
            Voitures = new List<Voiture>
            {
                new Voiture
                {
                    MarqueId = 8, // Ford
                    Modele = "Focus",
                    CouleurId = 7, // Vert (Green)
                    Annee = 2020,
                    Importe = importeToggle, // true
                    Immatriculation = "E-7181-RS",
                    ClientCIN = "E456123",
                    Transmission = new List<string> { "Front-Wheel Drive" },
                    Accessories = new List<string> { "Sunroof", "Heated Seats", "Navigation System" }
                },
                new Voiture
                {
                    MarqueId = 7, // Kia
                    Modele = "Sportage",
                    CouleurId = 2, // Blanc (White)
                    Annee = 2022,
                    Importe = !importeToggle, // false
                    Immatriculation = "E-8191-TU",
                    ClientCIN = "E456123",
                    Transmission = new List<string> { "Rear-Wheel Drive", "All-Wheel Drive" },
                    Accessories = new List<string>
                        { "Air Conditioning", "Bluetooth", "Parking Sensors", "Rearview Camera" }
                }
            }
        }
    );
}
}