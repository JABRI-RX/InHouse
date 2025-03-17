using System.ComponentModel.DataAnnotations;

namespace InitPoroject.Domain.Entity.VoitureM;

public class Voiture
{
    
    public int Id { get; set; }
    
    //maruq Relationship
    public int  MarqueId { get; set; }
    public Marque Marque { get; set; }
    
    public string Modele { get; set; } = string.Empty;
    
    public int Annee { get; set; }
    
    //couleur Relationship
    public int CouleurId { get; set; } 
    public Couleur Couleur { get; set; } 
    //isSolde
    public bool Importe { get; set; } = false;
    //others
    public string Immatriculation { get; set; } = string.Empty;
    public List<string> Accessories { get; set; } = [];
    public List<string> Transmission { get; set; } = [];
    //Client Relationship
    public string ClientCIN { get; set; } = string.Empty;
    public Client Client { get; set; }
    //date
    public DateTime CreatedAt { get; set; } = DateTime.Now;
}