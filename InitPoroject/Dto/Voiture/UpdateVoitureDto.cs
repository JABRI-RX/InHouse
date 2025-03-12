using System.ComponentModel.DataAnnotations;

namespace InitPoroject.Dto.Voiture;

public class UpdateVoitureDto
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
    public List<string> Accessories { get; set; } = [];
    [Required]
    public List<string> Transmission { get; set; } = [];
    [Required]
    [Required] public string ClientCIN { get; set; } = string.Empty;
}