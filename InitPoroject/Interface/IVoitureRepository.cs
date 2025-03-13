using InitPoroject.Domain.Entity;
using InitPoroject.Domain.Entity.VoitureM;
using InitPoroject.Dto.Voiture;
using InitPoroject.ErrorHandling.VoitureHandling;
using InitPoroject.Helpers;

namespace InitPoroject.Interface;

public interface IVoitureRepository
{
    Task<VoitureResponse> CreateCarAsync(Voiture voiture);
    Task<IList<Voiture>?> GetAllVoituressasync(QueryObjectVoiture queryObjectVoiture);
    Task<Voiture?> GetCarByImmatriculationAsync(string immatriculation);
    Task<IList<Voiture>?> GetVoituresByAnneAsync(int anne);
    Task<IList<Voiture>?> GetVoituresByModelAsync(string model);
    Task<IList<Voiture>?> GetVoitureMarkquequeAsync(string marque);
    Task<VoitureResponse> UpdateVoitureAsync(string immatriculation, UpdateVoitureDto voitureDto);
    Task<bool> DeleteVoitureAsync(string immatriculation);
}