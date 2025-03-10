using InitPoroject.Domain.Entity;
using InitPoroject.Dto.Voiture;

namespace InitPoroject.Dfto.Client;

public class ReadClientDto
{
    public string CIN { get; set; }
    public string Nom { get; set; } = string.Empty;  
    public string Prenom { get; set; }  = string.Empty;
    public string Adresse { get; set; }  = string.Empty;
    public string Telephone { get; set; }  = string.Empty;
    public List<ReadVoitureDto> Voitures { get; set; } = [];
}