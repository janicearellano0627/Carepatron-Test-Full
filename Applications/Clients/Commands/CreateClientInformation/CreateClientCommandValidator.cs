using FluentValidation;

namespace Application.Clients.Commands.CreateClientInformation
{
    public class CreateClientCommandValidator: AbstractValidator<CreateClientInformationCommand>
    {
        public CreateClientCommandValidator()
        {
            RuleFor(x => x.FirstName).NotEmpty();
            RuleFor(x => x.LastName).NotEmpty();
            RuleFor(x => x.Email).NotEmpty();
            RuleFor(x => x.PhoneNumber).NotEmpty();
        }
    }
}
