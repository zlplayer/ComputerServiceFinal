using AutoMapper;
using ComputerService.Domain.Interfaces;
using MediatR;

namespace ComputerService.Application.ComputerService.Queries.GetAllComputerServices
{
    internal class GetAllComputerServicesQueryHandler : IRequestHandler<GetAllComputerServicesQuery, IEnumerable<ComputerServiceDto>>
    {
        private readonly IComputerServiceRepository _carWorkshopRepository;
        private readonly IMapper _mapper;

        public GetAllComputerServicesQueryHandler(IComputerServiceRepository carWorkshopRepository, IMapper mapper)
        {
            _carWorkshopRepository = carWorkshopRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<ComputerServiceDto>> Handle(GetAllComputerServicesQuery request, CancellationToken cancellationToken)
        {
            var carWorkshops = await _carWorkshopRepository.GetAll();
            var dtos = _mapper.Map<IEnumerable<ComputerServiceDto>>(carWorkshops);


            return dtos;
        }
    }
}
