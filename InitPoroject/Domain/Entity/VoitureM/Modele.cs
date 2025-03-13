using System.ComponentModel.DataAnnotations;

namespace InitPoroject.Domain.Entity.VoitureM;

public class Modele
{
    public int Id { get; set; }
    [MaxLength(100)] public string NomModele { get; set; } = string.Empty;
    public IList<Voiture> Voitures { get; set; }
}