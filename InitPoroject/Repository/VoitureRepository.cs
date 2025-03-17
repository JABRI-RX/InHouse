using InitPoroject.Data;
using InitPoroject.Domain.Entity.VoitureM;
using InitPoroject.Dto.Voiture;
using InitPoroject.ErrorHandling.VoitureHandling;
using InitPoroject.Helpers;
using InitPoroject.Interface;
using Microsoft.EntityFrameworkCore;

namespace InitPoroject.Repository;

public class VoitureRepository : IVoitureRepository
{
    private readonly AppDbContext _context;
    private readonly ICouleurRepository _couleurRepository;
    private readonly IClientRepository _clientRepository;
    private readonly IMarqueRepository _marqueRepository;
    public VoitureRepository(AppDbContext context, ICouleurRepository couleurRepository, IClientRepository clientRepository, IMarqueRepository marqueRepository)
    {
        _context = context;
        _couleurRepository = couleurRepository;
        _clientRepository = clientRepository;
        _marqueRepository = marqueRepository;
    }

    public async Task<VoitureResponse> CreateCarAsync(Voiture voiture) //TODO Implement All Models,Marque,Anne 
    {
        var getvoiture = await GetCarByImmatriculationAsync(voiture.Immatriculation);
        if (getvoiture is not null) //return null indicates that it exists
            return new VoitureResponse { Message = "Voiture Existe Deja" };
        if (!await _clientRepository.CheckClientExists(voiture.ClientCIN))
            return new VoitureResponse { Message = "Client N'existe Pas" };
        if (!await _couleurRepository.CheckCouleurIdExist(voiture.CouleurId))
            return new VoitureResponse { Message = "Couleur N'existe Pas " };
        if (!await _marqueRepository.CheckMarqueIdExist(voiture.MarqueId))
            return new VoitureResponse { Message = "Marque N'existe Pas" };
        //add marq 
        await _context.Voitures.AddAsync(voiture);
        await _context.SaveChangesAsync();
        voiture.Couleur = await _couleurRepository.GetCouleurById(voiture.CouleurId);
        voiture.Marque = await _marqueRepository.GetMarqueById(voiture.MarqueId);
        return new VoitureResponse { Voiture = voiture };
    }

    public async Task<IList<Voiture>?> GetAllVoituressasync(QueryObjectVoiture queryObjectVoiture)
    {
        var voitures = _context.Voitures
            .Include(v => v.Couleur)
            .Include(v=>v.Marque)
            .AsQueryable();

        if (!string.IsNullOrWhiteSpace(queryObjectVoiture.MarqueId.ToString()))
            voitures = voitures.Where(v => v.MarqueId.Equals(queryObjectVoiture.MarqueId));
        if (!string.IsNullOrWhiteSpace(queryObjectVoiture.CouleurId.ToString() ))
            voitures = voitures.Where(v => v.CouleurId.Equals(queryObjectVoiture.CouleurId));
        if (!string.IsNullOrWhiteSpace(queryObjectVoiture.Annee))
            voitures = voitures.Where(v => v.Annee.ToString().ToLower().Equals(queryObjectVoiture.Annee.ToLower()));
        if (!string.IsNullOrWhiteSpace(queryObjectVoiture.Importe.ToString()))
            voitures = voitures.Where(v => v.Importe.Equals(queryObjectVoiture.Importe));
        if (!string.IsNullOrWhiteSpace(queryObjectVoiture.Immatriculation))
            voitures = voitures.Where(v =>
                v.Immatriculation.ToLower().Equals(queryObjectVoiture.Immatriculation.ToLower()));

        if (!string.IsNullOrWhiteSpace(queryObjectVoiture.Modele))
            voitures = voitures.Where(v => v.Modele.ToLower().Equals(queryObjectVoiture.Modele.ToLower()));

        if (!string.IsNullOrWhiteSpace(queryObjectVoiture.ClientCIN))
            voitures = voitures.Where(v => v.ClientCIN.ToLower().Equals(queryObjectVoiture.ClientCIN.ToLower()));

        return await voitures.ToListAsync();
    }

    public async Task<Voiture?> GetCarByImmatriculationAsync(string immatriculation)
    {
        return await _context.Voitures
            .Include(v => v.Couleur)
            .Include(v=>v.Marque)
            .FirstOrDefaultAsync(v => v.Immatriculation.Equals(immatriculation));
    }

    public async Task<IList<Voiture>?> GetVoituresByAnneAsync(int anne)
    {
        return await _context.Voitures
            .Include(v => v.Couleur)
            .Include(v=>v.Marque)
            .Where(v => v.Annee.Equals(anne)).ToListAsync();
    }

    public async Task<IList<Voiture>?> GetVoituresByModelAsync(string model)
    {
        return await _context.Voitures
            .Include(v => v.Couleur)
            .Include(v=>v.Marque)
            .Where(v => v.Modele.Equals(model)).ToListAsync();
    }

    public async Task<IList<Voiture>?> GetVoitureMarkquequeAsync(string marque)
    {
        return await _context.Voitures
            .Include(v => v.Couleur)
            .Include(v=>v.Marque)
            .Where(v => v.Modele.Equals(marque)).ToListAsync();
    }

    public async Task<VoitureResponse> UpdateVoitureAsync(string immatriculation, UpdateVoitureDto voitureDto)
    {
        var voiture = await GetCarByImmatriculationAsync(immatriculation);
        if (voiture is null)
            return new VoitureResponse { Message = "Voiture N'existe Deja" };
        if (!await _clientRepository.CheckClientExists(voitureDto.ClientCIN))
            return new VoitureResponse { Message = "Client N'existe Pas" };
        if (!await _couleurRepository.CheckCouleurIdExist(voitureDto.CouleurId))
            return new VoitureResponse { Message = "Couleur N'exist Pas" };
        if (!await _marqueRepository.CheckMarqueIdExist(voiture.MarqueId))
            return new VoitureResponse { Message = "Marque N'existe Pas" };
        voiture.MarqueId = voitureDto.MarqueId;
        voiture.Marque = await _marqueRepository.GetMarqueById(voitureDto.MarqueId);
        voiture.Annee = voitureDto.Annee;
        voiture.Modele = voitureDto.Modele;
        voiture.CouleurId = voitureDto.CouleurId;
        voiture.ClientCIN = voitureDto.ClientCIN;
        voiture.Importe = voitureDto.Importe;
        voiture.Couleur = await _couleurRepository.GetCouleurById(voitureDto.CouleurId);
        voiture.Accessories = voitureDto.Accessories;
        voiture.Transmission = voitureDto.Transmission;
        await _context.SaveChangesAsync();
        return new VoitureResponse{Voiture = voiture};
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