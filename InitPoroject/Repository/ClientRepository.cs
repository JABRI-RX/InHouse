using InitPoroject.Data;
using InitPoroject.Dfto.Client;
using InitPoroject.Domain.Entity;
using InitPoroject.Interface;
using InitPoroject.Mappers;
using Microsoft.EntityFrameworkCore;

namespace InitPoroject.Repository;

public class ClientRepository : IClientRepository
{
    private readonly AppDbContext _context;

    public ClientRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<Client?> CreateClientAsync(Client client)
    {
        var getclient =  await GetClientByCINAsync(client.CIN);
        if (getclient is not null)
            return null;
        await _context.Clients.AddAsync(client);
        await _context.SaveChangesAsync();
        return client;
    }

    public async Task<Client?> GetClientByCINAsync(string cin)
    {
        return  await _context.Clients
            .Include(c=>c.Voitures)
            .FirstOrDefaultAsync(c=>c.CIN.Equals(cin));
    }

    public async Task<IList<Client>?> GetAllCLientAsync()
    {
        return await _context.Clients
            .Include(c=>c.Voitures)
            .ToListAsync();
    }
    // TODO I dont know why it doesn't update the voitures 
    public async Task<Client?> UpdateClientAsync(string cin, UpdateClientDto clientDto)
    {
        var client = await GetClientByCINAsync(cin);
        if (client is null)
            return null;
        // _context.Entry(client).State = EntityState.Modified;
        client.Telephone = clientDto.Telephone;
        client.Adresse = clientDto.Adresse;
        client.Nom = clientDto.Nom;
        client.Prenom = clientDto.Prenom;
        client.Voitures = [];
        Console.WriteLine(clientDto.Voitures.Count);
        // foreach (var voiture in clientDto.Voitures)
        // {
        //     client.Voitures.Add(voiture.FromUpdateToNormal());
        // }
        var gclient = await _context.Clients.FirstOrDefaultAsync(c => c.CIN.Equals(cin));
        Console.WriteLine(gclient.Voitures.Count);
        await _context.SaveChangesAsync();
        return gclient;
    }

    public async Task<bool> DeleteClientByCINAsync(string cin)
    {
        var client = await GetClientByCINAsync(cin);
        if (client is null)
            return false;
        _context.Clients.Remove(client);
        await _context.SaveChangesAsync();
        return true;
    }
}