namespace InitPoroject.Dto.Voiture;

public class ReadVoitureDto
{
    public int Id { get; set; }
    public string Marque { get; set; } = string.Empty;
    public string Modele { get; set; } = string.Empty;
    public int Annee { get; set; }
    public string Couleur { get; set; } = string.Empty;
    public string Immatriculation { get; set; } = string.Empty;
    public string ClientCIN { get; set; }
}