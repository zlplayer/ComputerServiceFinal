using AutoMapper;
using ComputerService.Application.ApplicationUser;
using ComputerService.Domain.Interfaces;
using MediatR;

namespace ComputerService.Application.ComputerService.Commands.CreateComputerService
{
    public class CreateCarWorkshopCommandHandler : IRequestHandler<CreateComputerServiceCommand>
    {
        private readonly IComputerServiceRepository _carWorkshopRepository;
        private readonly IMapper _mapper;
        private readonly IUserContext _userContext;

        public CreateCarWorkshopCommandHandler(IComputerServiceRepository carWorkshopRepository, IMapper mapper, IUserContext userContext)
        {
            _carWorkshopRepository = carWorkshopRepository;
            _mapper = mapper;
            _userContext = userContext;
        }

        public async Task<Unit> Handle(CreateComputerServiceCommand request, CancellationToken cancellationToken)
        {
            var currentUser = _userContext.GetCurrentUser();
            if (currentUser == null || !currentUser.IsInRole("Owner"))
            {
                return Unit.Value;
            }
            var carWorkshop = _mapper.Map<Domain.Entities.ComputerService>(request);
            carWorkshop.EncodeName();

            carWorkshop.CreatedById = currentUser.Id;

            await _carWorkshopRepository.Create(carWorkshop);

            return Unit.Value;
        }
    }
}
