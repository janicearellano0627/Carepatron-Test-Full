using Application.Services.Pagination;
using MediatR;

namespace Application.Clients.Queries.GetAllClientInformation
{
    public class GetAllClientInformationQuery : IRequest<List<ClientLookUpDto>>
    {
        public SearchFilter Filter { get; set; } = new SearchFilter();
    }
}
