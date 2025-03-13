using InitPoroject.Data;
using InitPoroject.Domain.Entity.VoitureM;
using InitPoroject.Interface;
using Microsoft.EntityFrameworkCore;

namespace InitPoroject.Repository;

public class CouleurRepository : ICouleurRepository
{
    private readonly AppDbContext _context;

    public CouleurRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<Couleur?> GetCouleurById(int id)
    {
        return await _context.Couleurs.FindAsync(id);
    }

    public async Task<bool> CheckCouleurIdExist(int id)
    {
        return await _context.Couleurs.AnyAsync(c => c.CouleurId.Equals(id));
    }
}