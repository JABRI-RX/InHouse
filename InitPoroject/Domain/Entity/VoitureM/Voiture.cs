namespace InitPoroject.Domain.Entity.VoitureM;

public class Voiture
{
    
    public int Id { get; set; }
    public string Marque { get; set; } = string.Empty;
    public string Modele { get; set; } = string.Empty;
    public int Annee { get; set; }
    
    public string Couleur { get; set; }
    // public Couleur Couleur { get; set; } 
    public string Immatriculation { get; set; } = string.Empty;
    public List<string> Accessories { get; set; } = [];
    public List<string> Transmission { get; set; } = [];
    public string ClientCIN { get; set; } = string.Empty;
    public Client Client { get; set; }
    public DateTime CreatedAt { get; set; } = DateTime.Now;
}