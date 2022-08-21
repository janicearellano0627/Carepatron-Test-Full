using MediatR;
using System.Net;

namespace Application.Clients.Commands.CreateClientInformation
{
    public class CreateClientInformationCommand : IRequest<string>
    {
        public string FirstName { get; set; } 
        public string LastName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
    }
}
