using AutoPassAPI.Models;

namespace AutoPassAPI.Repositories.Interfaces
{
    public interface IClientRepository
    {
        Task<Client> Create(Client client);
        Task<Client> GetById(ulong clientId);
        Task<IEnumerable<Client>> GetAll();
        Task<Client> Update(Client client);
        Task Delete(ulong clientId);
    }
}
