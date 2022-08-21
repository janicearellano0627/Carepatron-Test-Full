using Application.Mapping;
using Application.Models;
using AutoMapper;

namespace Application.Clients.Queries.GetAllClientInformation
{
    public class ClientLookUpDto
    {
        public string Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Phone  { get; set; }
        public string Email { get; set; }
    }
}
