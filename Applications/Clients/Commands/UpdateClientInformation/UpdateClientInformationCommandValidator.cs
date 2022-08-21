using Application.Clients.Commands.CreateClientInformation;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Clients.Commands.UpdateClientInformation
{
    public class UpdateClientInformationCommandValidator : AbstractValidator<UpdateClientInformationCommand>
    {
        public UpdateClientInformationCommandValidator()
        {
            RuleFor(x => x.FirstName).NotEmpty();
            RuleFor(x => x.LastName).NotEmpty();
            RuleFor(x => x.Email).NotEmpty();
            RuleFor(x => x.PhoneNumber).NotEmpty();
        }
    }
}
