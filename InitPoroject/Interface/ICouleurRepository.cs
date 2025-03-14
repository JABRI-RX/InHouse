using System.Collections;
using InitPoroject.Domain.Entity.VoitureM;

namespace InitPoroject.Interface;

public interface ICouleurRepository
{
    Task<IList<Couleur>?> GetAllCouleurs();
    Task<Couleur?> GetCouleurById(int id);
    Task<bool> CheckCouleurIdExist(int id);
}