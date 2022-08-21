using Application.Models;
using Application.Repository;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Application.Clients.Commands.UpdateClientInformation
{
    public class UpdateClientInformationCommandHandler : IRequestHandler<UpdateClientInformationCommand, string>
    {
        private readonly IClientRepository _clientRepository;
        private readonly ILogger<UpdateClientInformationCommandHandler> _logger;

        public UpdateClientInformationCommandHandler(IClientRepository clientRepository, ILogger<UpdateClientInformationCommandHandler>  logger)
        {
            _clientRepository = clientRepository;
            _logger = logger;
        }

        public async Task<string> Handle(UpdateClientInformationCommand request, CancellationToken cancellationToken)
        {
            var getClientDetails = _clientRepository.GetById(request.Id);

            if (getClientDetails.IsFaulted || getClientDetails == null)
            {
                throw new Exception("Update Error");
            }

            var clientInformation = new Client()
            {
                Email = request.Email,
                PhoneNumber = request.PhoneNumber,
                FirstName = request.FirstName,
                LastName = request.LastName
            };

            var result = _clientRepository.Update(clientInformation);

            if (result.IsFaulted)
            {
                _logger.LogError($"UpdateErrorMessage {result.Exception?.Message}");
                throw new Exception(result.Exception?.Message);
            }

            return result.Result.ToString();
        }
    }
}
