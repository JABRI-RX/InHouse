using System.ComponentModel.DataAnnotations;
using InitPoroject.Dto.Voiture;

namespace InitPoroject.Dfto.Client;

public class UpdateClientDto
{
    [Required]
    public string CIN { get; set; }
    [Required]
    public string Nom { get; set; } = string.Empty;  
    [Required]
    public string Prenom { get; set; }  = string.Empty;
    [Required]
    public string Adresse { get; set; }  = string.Empty;
    [Required]
    public string Telephone { get; set; }  = string.Empty;
    [Required]
    public List<UpdateVoitureDto> Voitures { get; set; }
}