using System.ComponentModel.DataAnnotations;

namespace InitPoroject.Dto.Voiture;

public class CreateVoitureDto
{
    [Required]
    public string Marque { get; set; } = string.Empty;
    [Required]
    public string Modele { get; set; } = string.Empty;
    [Required]
    public int Annee { get; set; }
    [Required]
    public string Couleur { get; set; } = string.Empty;
    [Required]
    public string Immatriculation { get; set; } = string.Empty;
    [Required] 
    public string ClientCIN { get; set; } = string.Empty;
}