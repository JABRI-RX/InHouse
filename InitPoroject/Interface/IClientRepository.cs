using InitPoroject.Dfto.Client;
using InitPoroject.Domain.Entity;

namespace InitPoroject.Interface;

public interface IClientRepository
{
    Task<Client?> CreateClientAsync(Client client);
    Task<Client?> GetClientByCINAsync(string cin);
    Task<IList<Client>?> GetAllCLientAsync();
    Task<Client?> UpdateClientAsync(string cin, UpdateClientDto clientDto);
    Task<bool> DeleteClientByCINAsync(string cin);
}