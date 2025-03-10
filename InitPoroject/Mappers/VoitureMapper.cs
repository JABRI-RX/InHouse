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
            Id = voiture.Id,
            Annee = voiture.Annee,
            Immatriculation = voiture.Immatriculation,
            Marque = voiture.Marque,
            Modele = voiture.Modele,
            Couleur = voiture.Couleur,
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
            ClientCIN = voiture.ClientCIN
        };
    }
    public static Voiture FromUpdateToNormal(this UpdateVoitureDto voiture)
    {
        return new Voiture
        {
            Annee = voiture.Annee,
            Immatriculation = voiture.Immatriculation,
            Marque = voiture.Marque,
            Modele = voiture.Modele,
            ClientCIN = voiture.ClientCIN
        };
    }
}