using System.ComponentModel.DataAnnotations;

namespace InitPoroject.Dto.Voiture;

public class UpdateVoitureDto
{
    [Required] public int MarqueId { get; set; }   
    [Required] public string Modele { get; set; } = string.Empty;
    [Required] public int Annee { get; set; }

    [Required] public int CouleurId { get; set; }
    [Required] public bool Importe { get; set; }
    [Required] public List<string> Accessories { get; set; } = [];
    [Required] public List<string> Transmission { get; set; } = [];
    [Required] public string ClientCIN { get; set; } = string.Empty;
}