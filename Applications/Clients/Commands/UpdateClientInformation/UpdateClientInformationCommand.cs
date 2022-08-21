using MediatR;
using System.Net;

namespace Application.Clients.Commands.UpdateClientInformation
{
    public class UpdateClientInformationCommand : IRequest<string>
    {
        public string Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
    }
}
