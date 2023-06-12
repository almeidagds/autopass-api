using AutoPassAPI.Models;
using AutoPassAPI.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace AutoPassAPI.Repositories
{
    public class ClientRepository : IClientRepository
    {
        private readonly AppSettingsDbContext _context;

        public ClientRepository(AppSettingsDbContext context)
        {
            _context = context;
        }
        public async Task<Client> Create(Client client)
        {
            client.Created = DateTime.UtcNow;
            _context.Clients.Add(client);
            await _context.SaveChangesAsync();
            return client;
        }

        public async Task<Client> GetById(ulong clientId)
        {
            return await _context.Clients.FindAsync(clientId);
        }

        public async Task<IEnumerable<Client>> GetAll()
        {
            return await _context.Clients.ToListAsync<Client>();
        }

        public async Task<Client> Update(Client client)
        {
            client.Modified = DateTime.UtcNow;
            _context.Entry(client).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return client;
        }

        public async Task Delete(ulong clientId)
        {
            Client clientToDelete = await _context.Clients.FindAsync(clientId);
            if (clientToDelete != null)
            {
                _context.Clients.Remove(clientToDelete);
                await _context.SaveChangesAsync();
            }
        }
    }
}
