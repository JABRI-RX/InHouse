using System.ComponentModel.DataAnnotations;

namespace InitPoroject.Domain.Entity.VoitureM;

public class Marque
{
    [Key]
    public int MarqueId { get; set; }
    [MaxLength(100)] public string NomMarque { get; set; } = string.Empty;
    public IList<Voiture> Voitures { get; set; } = [];
}