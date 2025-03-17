namespace InitPoroject.Dto.Voiture;

public class ReadVoitureDto
{
    //Marque
    public int MarqueId { get; set; }
    public string Marque { get; set; } = string.Empty;
    
    //Modele
    public string Modele { get; set; } = string.Empty;
    
    //Annee
    public int Annee { get; set; }
    
    //Couleur
    public int CouleurId { get; set; } 
    public string Couleur { get; set; } = string.Empty;
    
    //DIspo
    public bool Importe { get; set; }
    public List<string> Accessories { get; set; } = [];
    public List<string> Transmission { get; set; } = [];
    public string Immatriculation { get; set; } = string.Empty;
    public string ClientCIN { get; set; }
}