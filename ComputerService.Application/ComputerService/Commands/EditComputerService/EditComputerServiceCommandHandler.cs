using ComputerService.Application.ApplicationUser;
using ComputerService.Domain.Entities;
using ComputerService.Domain.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComputerService.Application.ComputerService.Commands.EditComputerService
{
    internal class EditComputerServiceCommandHandler : IRequestHandler<EditComputerServiceCommand>
    {
        private readonly IComputerServiceRepository _repository;
        private readonly IUserContext _userContext;

        public EditComputerServiceCommandHandler(IComputerServiceRepository repository, IUserContext userContext)
        {
            _repository = repository;
            _userContext = userContext;
        }
        public async Task<Unit> Handle(EditComputerServiceCommand request, CancellationToken cancellationToken)
        {
            var computerService = await _repository.GetByEncodedName(request.EncodedName!);

            var user = _userContext.GetCurrentUser();
            var isEdibable = user != null && (computerService.CreatedById == user.Id || user.IsInRole("Moderator"));

            if (!isEdibable)
            {
                return Unit.Value;
            }
            computerService.Name=request.Name;
            computerService.Description = request.Description;

            computerService.ContactDetails.City = request.City;
            computerService.ContactDetails.PhoneNumber = request.PhoneNumber;
            computerService.ContactDetails.PostalCode = request.PostalCode;
            computerService.ContactDetails.Street = request.Street;

            await _repository.Commit();

            return Unit.Value;
        }
    }
}
