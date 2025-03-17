using System.Collections.ObjectModel;
using InitPoroject.Dto.Voiture;

namespace InitPoroject.Helpers;

public static class CheckFunctions
{
    public static IList<string> CheckCreateVoitureDto(CreateVoitureDto voitureDto)
    {
        IList<string> results = [];
        if (!int.TryParse(voitureDto.CouleurId, out int CouleurId))
             results.Add("Couleur Id Doit Etre Un Entier ");
        if (!int.TryParse(voitureDto.MarqueId, out int MarqueId))
            results.Add("Marque Id Doit Etre Un Entier");
        return results;
    }
}