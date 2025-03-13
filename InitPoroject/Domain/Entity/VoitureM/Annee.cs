using System.ComponentModel.DataAnnotations;

namespace InitPoroject.Domain.Entity.VoitureM;

public class Annee
{
    public int Id { get; set; }
    [MaxLength(100)] public string NomAnnee { get; set; } = string.Empty;
    public IList<Voiture> Voitures { get; set; }
}