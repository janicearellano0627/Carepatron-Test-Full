using Application.Repository;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Application.Clients.Queries.GetAllClientInformation
{
    public class GetAllClientInformationQueryHandler : IRequestHandler<GetAllClientInformationQuery, List<ClientLookUpDto>>
    {
        private readonly IClientRepository _clientRepository;
        private readonly ILogger<GetAllClientInformationQueryHandler> _logger;

        public GetAllClientInformationQueryHandler(IClientRepository clientRepository, ILogger<GetAllClientInformationQueryHandler> logger)
        {
            _clientRepository = clientRepository;
            _logger = logger;
        }

        public async Task<List<ClientLookUpDto>> Handle(GetAllClientInformationQuery request,CancellationToken cancellationToken)
        {
            var clientViewModel = new List<ClientLookUpDto>();
            var clientInformations = _clientRepository.GetAll();

            if (clientInformations.IsFaulted)
            {
                throw new Exception(clientInformations.Exception.Message);
            }

            foreach (var items in clientInformations.Result)
            {
                var clientDto = new ClientLookUpDto
                { 
                     Id = items.Id,
                     FirstName = items.FirstName,
                     LastName = items.LastName,
                     Email = items.Email,
                     Phone = items.PhoneNumber
                };

                clientViewModel.Add(clientDto);
            }

            if (string.IsNullOrEmpty(request.Filter.SearchQuery))
            {
                return clientViewModel.OrderBy(x => x.FirstName).ThenBy(x => x.LastName).ToList();
            }
            else
            {
                var searchQuery = request.Filter.SearchQuery?.ToLower().Trim();

                var result= clientViewModel.Where(x => x.FirstName.ToLower().Contains(searchQuery) || x.LastName.ToLower().Contains(searchQuery))
                    .OrderBy(x => x.FirstName).ThenBy(x => x.LastName).ToList();

                return result;
            }
        }
    }
}
