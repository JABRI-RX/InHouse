using InitPoroject.Data;
using InitPoroject.Domain.Entity;
using InitPoroject.Dto.Voiture;
using InitPoroject.Helpers;
using InitPoroject.Interface;
using Microsoft.EntityFrameworkCore;

namespace InitPoroject.Repository;

public class VoitureRepository : IVoitureRepository
{
    private readonly AppDbContext _context;

    public VoitureRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<Voiture?> CreateCarAsync(Voiture voiture)
    {
        var getvoiture = await GetCarByImmatriculationAsync(voiture.Immatriculation);
        if (getvoiture is not null)//return null indicates that it exists
            return null;
        await _context.Voitures.AddAsync(voiture);
        await _context.SaveChangesAsync();
        return voiture;
    }

    public async Task<IList<Voiture>?> GetAllVoituressasync(QueryObjectVoiture queryObjectVoiture)
    {
        var voitures = _context.Voitures.AsQueryable();
        if (queryObjectVoiture is null)
            return await voitures.ToListAsync();
        if (!string.IsNullOrWhiteSpace(queryObjectVoiture.Marque))
            voitures = voitures.Where(v => v.Marque.ToLower().Equals(queryObjectVoiture.Marque.ToLower()));
        
        if (!string.IsNullOrWhiteSpace(queryObjectVoiture.Couleur))
            voitures = voitures.Where(v => v.Couleur.ToLower().Equals(queryObjectVoiture.Couleur.ToLower()));
        
        if (!string.IsNullOrWhiteSpace(queryObjectVoiture.Annee))
            voitures = voitures.Where(v => v.Annee.ToString().ToLower().Equals(queryObjectVoiture.Annee.ToLower()));
       
        if (!string.IsNullOrWhiteSpace(queryObjectVoiture.Immatriculation))
            voitures = voitures.Where(v => v.Immatriculation.ToLower().Equals(queryObjectVoiture.Immatriculation.ToLower()));
        
        if (!string.IsNullOrWhiteSpace(queryObjectVoiture.Modele))
            voitures = voitures.Where(v => v.Modele.ToLower().Equals(queryObjectVoiture.Modele.ToLower()));
        
        if (!string.IsNullOrWhiteSpace(queryObjectVoiture.ClientCIN))
            voitures = voitures.Where(v => v.ClientCIN.ToLower().Equals(queryObjectVoiture.ClientCIN.ToLower()));
        
        return await voitures.ToListAsync();
    }

    public async Task<Voiture?> GetCarByImmatriculationAsync(string immatriculation)
    {
        return  await _context.Voitures
            .FirstOrDefaultAsync(v => v.Immatriculation.Equals(immatriculation));
    }

    public async Task<IList<Voiture>?> GetVoituresByAnneAsync(int anne)
    {
        return await _context.Voitures.Where(v => v.Annee.Equals(anne)).ToListAsync();
    }

    public async Task<IList<Voiture>?> GetVoituresByModelAsync(string model)
    {
        return await _context.Voitures.Where(v => v.Modele.Equals(model)).ToListAsync();
    }

    public async Task<IList<Voiture>?> GetVoitureMarkquequeAsync(string marque)
    {
        return await _context.Voitures.Where(v => v.Modele.Equals(marque)).ToListAsync();

    }

    public async Task<Voiture?> UpdateVoitureAsync(string immatriculation, UpdateVoitureDto voitureDto)
    {
        var voiture = await GetCarByImmatriculationAsync(immatriculation);
        if (voiture is null)
            return null;
        voiture.Marque = voitureDto.Marque;
        voiture.Annee = voitureDto.Annee;
        voiture.ClientCIN = voitureDto.ClientCIN;
        voiture.Couleur = voitureDto.Couleur;
        voiture.Modele = voitureDto.Modele;
        await _context.SaveChangesAsync();
        return voiture;
    }

    public async Task<bool> DeleteVoitureAsync(string immatriculation)
    {
        var voiture = await GetCarByImmatriculationAsync(immatriculation);
        if (voiture is null)
            return false;
        _context.Voitures.Remove(voiture);
        await _context.SaveChangesAsync();
        return true;
    }
}