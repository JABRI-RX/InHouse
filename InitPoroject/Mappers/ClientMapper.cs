using InitPoroject.Dfto.Client;
using InitPoroject.Domain.Entity;

namespace InitPoroject.Mappers;

public static class ClientMapper
{
    public static ReadClientDto ToReadClientDto(this Client client)
    {
        return new ReadClientDto
        {
            CIN = client.CIN,
            Adresse = client.Adresse,
            Nom = client.Nom,
            Prenom = client.Prenom,
            Telephone = client.Telephone,
            Voitures = client.Voitures.Select(v=>v.ToReadVoitureDto()).ToList()
        };
    }
    
    public  static Client FromCreateToNormal(this CreateClientDto client)
    {
        return new Client
        {
            CIN = client.CIN,
            Adresse = client.Adresse,
            Nom = client.Nom,
            Prenom = client.Prenom,
            Telephone = client.Telephone,
            // Voitures = client.
        };
    }
}