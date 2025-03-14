namespace InitPoroject.Dto.Voiture;

public class ReadVoitureDto
{
    public string Marque { get; set; } = string.Empty;
    public string Modele { get; set; } = string.Empty;
    public int Annee { get; set; }
    public int CouleurId { get; set; } 
    public string Couleur { get; set; } = string.Empty;
    public List<string> Accessories { get; set; } = [];
    public List<string> Transmission { get; set; } = [];
    public string Immatriculation { get; set; } = string.Empty;
    public string ClientCIN { get; set; }
}