using InitPoroject.Data;
using InitPoroject.Domain.Entity.VoitureM;
using InitPoroject.Interface;
using Microsoft.EntityFrameworkCore;

namespace InitPoroject.Repository;

public class MarqueRepository : IMarqueRepository
{
    private readonly AppDbContext _context;

    public MarqueRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<IList<Marque>?> GetAllMarques()
    {
        return await _context.Marques.ToListAsync();
    }

    public async Task<Marque?> GetMarqueById(int id)
    {
        return await _context.Marques.FindAsync(id);
    }

    public async Task<bool> CheckMarqueIdExist(int id)
    {
        return await _context.Marques.AnyAsync(m=>m.MarqueId.Equals(id));
    }
}