using Application.Models;
using Application.Repository;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Application.Clients.Commands.CreateClientInformation
{
    public class CreateClientInformationHandler : IRequestHandler<CreateClientInformationCommand,string>
    {
        private readonly IClientRepository _clientRepository;
        private readonly ILogger<CreateClientInformationHandler> _logger;

        public CreateClientInformationHandler(IClientRepository clientRepository, ILogger<CreateClientInformationHandler> logger)
        {
            _clientRepository = clientRepository;
            _logger = logger;
        }

        public async Task<string> Handle(CreateClientInformationCommand request,CancellationToken cancellationToken)
        {
            var clientInformation = new Client()
            {
                 Email = request.Email,
                 PhoneNumber = request.PhoneNumber,
                 FirstName = request.FirstName,
                 LastName = request.LastName
            };

            var result = _clientRepository.Create(clientInformation);

            if (result.IsFaulted)
            {
                throw new Exception(result.Exception?.Message);
            }

            return result.Result.ToString();
        }
    }
}
