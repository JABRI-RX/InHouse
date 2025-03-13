using InitPoroject.Domain.Entity;
using InitPoroject.Dto.Voiture;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.Blazor;

namespace InitPoroject.Mappers;

public static class VoitureMapper
{
    public static ReadVoitureDto ToReadVoitureDto(this Voiture voiture)
    {
        return new ReadVoitureDto
        {
            Annee = voiture.Annee,
            Immatriculation = voiture.Immatriculation,
            Marque = voiture.Marque,
            Modele = voiture.Modele,
            Couleur = voiture.Couleur,
            Accessories = voiture.Accessories,
            Transmission = voiture.Transmission,
            ClientCIN = voiture.ClientCIN
        };
    }
    public static Voiture FromCreateToNormal(this CreateVoitureDto voiture)
    {
        return new Voiture
        {
            Annee = voiture.Annee,
            Immatriculation = voiture.Immatriculation,
            Marque = voiture.Marque,
            Modele = voiture.Modele,
            Couleur = voiture.Couleur,
            Accessories = voiture.Accessories,
            Transmission = voiture.Transmission,
            ClientCIN = voiture.ClientCIN
        };
    }
    public static Voiture FromUpdateToNormal(this UpdateVoitureDto voiture,string immatriculation )
    {
        return new Voiture
        {
            Marque = voiture.Marque,
            Modele = voiture.Modele,
            Annee = voiture.Annee,
            Couleur = voiture.Couleur,
            Immatriculation = immatriculation,
            Accessories = voiture.Accessories,
            Transmission = voiture.Transmission,
            ClientCIN = voiture.ClientCIN
        };
    }
}