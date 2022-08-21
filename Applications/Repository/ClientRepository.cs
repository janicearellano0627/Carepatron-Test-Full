using Application.Data;
using Application.Models;
using Microsoft.EntityFrameworkCore;

namespace Application.Repository
{
    public class ClientRepository : IClientRepository
    {
        private readonly DataContext dataContext;

        public ClientRepository(DataContext dataContext)
        {
            this.dataContext = dataContext;
        }

        public async Task<string> Create(Client client)
        {
            if (client == null)
            {
                throw new Exception("Client Error Message");
            }

            if (string.IsNullOrEmpty(client?.Id))
            {
                client.Id = Guid.NewGuid().ToString();
            }

            var result = await dataContext.AddAsync(client);
            await dataContext.SaveChangesAsync();

            return result.Entity.Id;
        }

        public Task<List<Client>> GetAll()
        {
            return dataContext.Clients.ToListAsync();
        }

        public async Task<List<Client>> GetAllByFilter(string query)
        {
            var result = await dataContext.Clients.Where(x => x.FirstName.Contains(query) || x.LastName.Contains(query)).ToListAsync();

            return result;
        }

        public async Task<List<Client>> GetById(string query)
        {
            var result = await dataContext.Clients.Where(x => x.Id.Contains(query)).ToListAsync();

            return result;
        }

        public async Task<string> Update(Client client)
        {
            var existingClient = await dataContext.Clients.FirstOrDefaultAsync(x => x.Id == client.Id);

            if (existingClient == null)
            {
                throw new Exception("Update Error Message");
            }

            existingClient.FirstName = client.FirstName;
            existingClient.LastName = client.LastName;
            existingClient.Email = client.Email;
            existingClient.PhoneNumber = client.PhoneNumber;

            await dataContext.SaveChangesAsync();

            return client.Id;
        }
    }
}