using AutoMapper;
using ComputerService.Application.ApplicationUser;
using ComputerService.Domain.Interfaces;
using MediatR;

namespace ComputerService.Application.ComputerService.Commands.CreateComputerService
{
    public class CreateCarWorkshopCommandHandler : IRequestHandler<CreateComputerServiceCommand>
    {
        private readonly IComputerServiceRepository _computerServiceRepository;
        private readonly IMapper _mapper;
        private readonly IUserContext _userContext;

        public CreateCarWorkshopCommandHandler(IComputerServiceRepository computerServiceRepository, IMapper mapper, IUserContext userContext)
        {
            _computerServiceRepository = computerServiceRepository;
            _mapper = mapper;
            _userContext = userContext;
        }

        public async Task<Unit> Handle(CreateComputerServiceCommand request, CancellationToken cancellationToken)
        {
            var currentUser = _userContext.GetCurrentUser();
            if (currentUser == null)
            {
                return Unit.Value;
            }
            var carWorkshop = _mapper.Map<Domain.Entities.ComputerService>(request);
            carWorkshop.EncodeName();

            carWorkshop.CreatedById = currentUser.Id;

            await _computerServiceRepository.Create(carWorkshop);

            return Unit.Value;
        }
    }
}
