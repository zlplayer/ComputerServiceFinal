using AutoMapper;
using ComputerService.Domain.Interfaces;
using MediatR;

namespace ComputerService.Application.ComputerService.Queries.GetAllComputerServices
{
    internal class GetAllComputerServicesQueryHandler : IRequestHandler<GetAllComputerServicesQuery, IEnumerable<ComputerServiceDto>>
    {
        private readonly IComputerServiceRepository _computerServiceRepository;
        private readonly IMapper _mapper;

        public GetAllComputerServicesQueryHandler(IComputerServiceRepository computerServiceRepository, IMapper mapper)
        {
            _computerServiceRepository = computerServiceRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<ComputerServiceDto>> Handle(GetAllComputerServicesQuery request, CancellationToken cancellationToken)
        {
            var computerServices = await _computerServiceRepository.GetAll();
            var dtos = _mapper.Map<IEnumerable<ComputerServiceDto>>(computerServices);


            return dtos;
        }
    }
}
