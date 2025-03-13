using System.ComponentModel.DataAnnotations;

namespace InitPoroject.Domain.Entity.VoitureM;

public class Couleur
{
    public int Id { get; set; }
    [MaxLength(100)] public string NomCouleur { get; set; } = string.Empty;
    public IList<Voiture> Voitures { get; set; } = [];
}