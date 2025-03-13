using InitPoroject.Domain.Entity;
using InitPoroject.Domain.Entity.VoitureM;
using InitPoroject.Dto.Voiture;
using InitPoroject.Helpers;

namespace InitPoroject.Interface;

public interface IVoitureRepository
{
    Task<Voiture?> CreateCarAsync(Voiture voiture);
    Task<IList<Voiture>?> GetAllVoituressasync(QueryObjectVoiture queryObjectVoiture);
    Task<Voiture?> GetCarByImmatriculationAsync(string immatriculation);
    Task<IList<Voiture>?> GetVoituresByAnneAsync(int anne);
    Task<IList<Voiture>?> GetVoituresByModelAsync(string model);
    Task<IList<Voiture>?> GetVoitureMarkquequeAsync(string marque);
    Task<Voiture?> UpdateVoitureAsync(string immatriculation, UpdateVoitureDto voitureDto);
    Task<bool> DeleteVoitureAsync(string immatriculation);
}