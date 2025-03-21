using System.ComponentModel.DataAnnotations;

namespace InitPoroject.Dto.Voiture;

public class CreateVoitureDto
{
    [Required] public string MarqueId { get; set; } = string.Empty;
    [Required] public string Modele { get; set; } = string.Empty;
    [Required] public int Annee { get; set; }

    [Required] public string CouleurId { get; set; } = string.Empty;
    [Required] public bool Importe { get; set; }
    [Required] public string Immatriculation { get; set; } = string.Empty;
    [Required] public List<string> Accessories { get; set; } = [];
    [Required] public List<string> Transmission { get; set; } = [];
    [Required] public string ClientCIN { get; set; } = string.Empty;
}