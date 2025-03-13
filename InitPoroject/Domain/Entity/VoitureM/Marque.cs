using System.ComponentModel.DataAnnotations;

namespace InitPoroject.Domain.Entity.VoitureM;

public class Marque
{
    public int Id { get; set; }
    [MaxLength(100)] public string NomMarque { get; set; } = string.Empty;
    public IList<Voiture> Voitures { get; set; } = [];
}