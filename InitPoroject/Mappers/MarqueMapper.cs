using InitPoroject.Domain.Entity.VoitureM;
using InitPoroject.Dto.Marque;

namespace InitPoroject.Mappers;

public static class MarqueMapper
{
    public static ReadMarqueDto ToReadMarqueDto(this Marque marque)
    {
        return new ReadMarqueDto
        {
            MarqueId = marque.MarqueId,
            NomMarque = marque.NomMarque
        };
    }
}