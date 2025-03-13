using InitPoroject.Domain.Entity.VoitureM;

namespace InitPoroject.Interface;

public interface ICouleurRepository
{
    Task<Couleur?> GetCouleurById(int id);
    Task<bool> CheckCouleurIdExist(int id);
}