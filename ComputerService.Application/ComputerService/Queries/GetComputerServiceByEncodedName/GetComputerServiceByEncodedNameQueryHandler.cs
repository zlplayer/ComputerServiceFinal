using AutoMapper;
using ComputerService.Domain.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComputerService.Application.ComputerService.Queries.GetComputerServiceByEncodedName
{
    public class GetCarWorkshopByEncodedNameQueryHandler : IRequestHandler<GetComputerServiceByEncodedNameQuery, ComputerServiceDto>
    {
        private readonly IComputerServiceRepository _carWorkshopRepository;
        private readonly IMapper _mapper;

        public GetCarWorkshopByEncodedNameQueryHandler(IComputerServiceRepository carWorkshopRepository, IMapper mapper)
        {
            _carWorkshopRepository = carWorkshopRepository;
            _mapper = mapper;
        }
        public async Task<ComputerServiceDto> Handle(GetComputerServiceByEncodedNameQuery request, CancellationToken cancellationToken)
        {
            var carWorkshop = await _carWorkshopRepository.GetByEncodedName(request.EncodedName);

            var dto = _mapper.Map<ComputerServiceDto>(carWorkshop);

            return dto;
        }
    }
}
