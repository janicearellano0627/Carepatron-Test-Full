using Application.Models;

namespace Application.Repository
{
    public interface IClientRepository
    {
        Task<string> Create(Client client);
        Task<List<Client>> GetAll();
        Task<List<Client>> GetAllByFilter(string query);
        Task<string> Update(Client client);
        Task<List<Client>> GetById(string query);
    }
}