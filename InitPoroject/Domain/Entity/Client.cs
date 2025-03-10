using System.ComponentModel.DataAnnotations;

namespace InitPoroject.Domain.Entity;

public class Client
{
    [Key]
    public string CIN { get; set; }
    public string Nom { get; set; } = string.Empty;  
    public string Prenom { get; set; }  = string.Empty;
    public string Adresse { get; set; }  = string.Empty;
    public string Telephone { get; set; }  = string.Empty;
    public List<Voiture> Voitures { get; set; } = [];
}