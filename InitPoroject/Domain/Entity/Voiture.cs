using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.Identity.Client.Extensions.Msal;

namespace InitPoroject.Domain.Entity;

public class Voiture
{
    
    public int Id { get; set; }
    public string Marque { get; set; } = string.Empty;
    public string Modele { get; set; } = string.Empty;
    public int Annee { get; set; }
    public string Couleur { get; set; } = string.Empty;
    public string Immatriculation { get; set; } = string.Empty;
    public string ClientCIN { get; set; }
    public List<string> Accessories { get; set; } = [];
    public List<string> Transmission { get; set; } = [];
    public Client Client { get; set; }
    public DateTime CreatedAt { get; set; } = DateTime.Now;
}