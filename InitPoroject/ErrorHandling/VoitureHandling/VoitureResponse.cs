using InitPoroject.Domain.Entity.VoitureM;

namespace InitPoroject.ErrorHandling.VoitureHandling;

public class VoitureResponse
{
    public Voiture Voiture { get; set; } = null!;
    public string Message { get; set; } = string.Empty;
}