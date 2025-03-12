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

            // SeedProducts(context);
            SeedClient(context);
            // SeedVoitures(context);
            context.SaveChanges();
        }
    }

    private static void SeedProducts(AppDbContext context)
    {
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
    }

    private static void SeedClient(AppDbContext context)
{
    if (context.Clients.Any())
        return;

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
                    Marque = "Renault",
                    Modele = "Clio",
                    Couleur = "Noir",
                    Annee = 2018,
                    Immatriculation = "A-1234-BC",
                    ClientCIN = "A123456",
                    Transmission = new List<string> { "Front-Wheel Drive" },
                    Accessories = new List<string> { "Air Conditioning", "Bluetooth", "Parking Sensors" }
                },
                new Voiture
                {
                    Marque = "Peugeot",
                    Modele = "208",
                    Couleur = "Blanc",
                    Annee = 2020,
                    Immatriculation = "A-5678-DE",
                    ClientCIN = "A123456",
                    Transmission = new List<string> { "Rear-Wheel Drive", "All-Wheel Drive" },
                    Accessories = new List<string> { "Sunroof", "Heated Seats", "Navigation System", "Rearview Camera" }
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
                    Marque = "Dacia",
                    Modele = "Sandero",
                    Couleur = "Blanche",
                    Annee = 2019,
                    Immatriculation = "B-9101-FG",
                    ClientCIN = "B654321",
                    Transmission = new List<string> { "All-Wheel Drive" },
                    Accessories = new List<string> { "Keyless Entry", "Wireless Charging", "Leather Seats" }
                },
                new Voiture
                {
                    Marque = "Hyundai",
                    Modele = "i20",
                    Couleur = "Noir",
                    Annee = 2021,
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
                    Marque = "Toyota",
                    Modele = "Corolla",
                    Couleur = "Rouge",
                    Annee = 2022,
                    Immatriculation = "C-3141-JK",
                    ClientCIN = "C987654",
                    Transmission = new List<string> { "Front-Wheel Drive" },
                    Accessories = new List<string> { "Air Conditioning", "Sunroof", "Heated Seats" }
                },
                new Voiture
                {
                    Marque = "Renault",
                    Modele = "Megane",
                    Couleur = "Gris",
                    Annee = 2020,
                    Immatriculation = "C-4151-LM",
                    ClientCIN = "C987654",
                    Transmission = new List<string> { "Rear-Wheel Drive", "All-Wheel Drive" },
                    Accessories = new List<string> { "Navigation System", "Bluetooth", "Parking Sensors", "Rearview Camera" }
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
                    Marque = "Peugeot",
                    Modele = "3008",
                    Couleur = "Bleu",
                    Annee = 2021,
                    Immatriculation = "D-5161-NO",
                    ClientCIN = "D123789",
                    Transmission = new List<string> { "All-Wheel Drive" },
                    Accessories = new List<string> { "Leather Seats", "Keyless Entry", "Wireless Charging" }
                },
                new Voiture
                {
                    Marque = "Citroën",
                    Modele = "C4",
                    Couleur = "Noir",
                    Annee = 2019,
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
                    Marque = "Ford",
                    Modele = "Focus",
                    Couleur = "Vert",
                    Annee = 2020,
                    Immatriculation = "E-7181-RS",
                    ClientCIN = "E456123",
                    Transmission = new List<string> { "Front-Wheel Drive" },
                    Accessories = new List<string> { "Sunroof", "Heated Seats", "Navigation System" }
                },
                new Voiture
                {
                    Marque = "Kia",
                    Modele = "Sportage",
                    Couleur = "Blanc",
                    Annee = 2022,
                    Immatriculation = "E-8191-TU",
                    ClientCIN = "E456123",
                    Transmission = new List<string> { "Rear-Wheel Drive", "All-Wheel Drive" },
                    Accessories = new List<string> { "Air Conditioning", "Bluetooth", "Parking Sensors", "Rearview Camera" }
                }
            }
        }
    );

}

    // private static void SeedVoitures(AppDbContext context)
    // {
    //     if (context.Voitures.Any())
    //         return;
    //
    //     context.Voitures.AddRange(
    //         new Voiture
    //         {
    //             Id = 1,
    //             Marque = "Renault",
    //             Modele = "Clio",
    //             Couleur = "Noir",
    //             Annee = 2018,
    //             Immatriculation = "A-1234-BC",
    //             ClientCIN = "A123456",
    //         },
    //         new Voiture
    //         {
    //             Id = 2,
    //             Marque = "Peugeot",
    //             Modele = "208",
    //             Annee = 2020,
    //             Couleur = "Noir",
    //             Immatriculation = "B-5678-DE",
    //             ClientCIN = "B654321"
    //         },
    //         new Voiture
    //         {
    //             Id = 3,
    //             Marque = "Dacia",
    //             Modele = "Sandero",
    //             Annee = 2019,
    //             Couleur = "Blanche",
    //             Immatriculation = "C-9101-FG",
    //             ClientCIN = "C987654"
    //         },
    //         new Voiture
    //         {
    //             Id = 4,
    //             Marque = "Hyundai",
    //             Modele = "i20",
    //             Annee = 2021,
    //             Couleur = "Noir",
    //             Immatriculation = "D-1121-HI",
    //             ClientCIN = "D123789"
    //         },
    //         new Voiture
    //         {
    //             Id = 5,
    //             Marque = "Toyota",
    //             Modele = "Corolla",
    //             Annee = 2022,
    //             Couleur = "roughe",
    //             Immatriculation = "E-3141-JK",
    //             ClientCIN = "E456123"
    //         }
    //     );
    // }
}