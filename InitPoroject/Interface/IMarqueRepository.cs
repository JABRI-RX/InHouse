using InitPoroject.Domain.Entity.VoitureM;

namespace InitPoroject.Interface;

public interface IMarqueRepository
{
    Task<IList<Marque>?> GetAllMarques();
    Task<Marque?> GetMarqueById(int id);
    Task<bool> CheckMarqueIdExist(int id);
}