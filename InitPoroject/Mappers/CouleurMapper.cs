using InitPoroject.Domain.Entity.VoitureM;
using InitPoroject.Dto.Couleur;

namespace InitPoroject.Mappers;

public static class CouleurMapper
{
    public static ReadCouleurDto ToReadCouleurDto(this Couleur couleur)
    {
        return new ReadCouleurDto
        {
            CouleurId = couleur.CouleurId,
            NomCouleur = couleur.NomCouleur
        };
    }
}