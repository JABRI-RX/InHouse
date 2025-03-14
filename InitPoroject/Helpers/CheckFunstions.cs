using InitPoroject.Dto.Voiture;

namespace InitPoroject.Helpers;

public static class CheckFunctions
{
    public static string CheckCreateVoitureDto(CreateVoitureDto voitureDto)
    {
        string result = string.Empty;
        if (!Int32.TryParse(voitureDto.CouleurId, out int i))
            result += "Couleur Id Doit Etre Un Entier";

        return result;
    }
}