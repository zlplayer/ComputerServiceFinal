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
        private readonly IComputerServiceRepository _computerServiceRepository;
        private readonly IMapper _mapper;

        public GetCarWorkshopByEncodedNameQueryHandler(IComputerServiceRepository computerServiceRepository, IMapper mapper)
        {
            _computerServiceRepository = computerServiceRepository;
            _mapper = mapper;
        }
        public async Task<ComputerServiceDto> Handle(GetComputerServiceByEncodedNameQuery request, CancellationToken cancellationToken)
        {
            var carWorkshop = await _computerServiceRepository.GetByEncodedName(request.EncodedName);

            var dto = _mapper.Map<ComputerServiceDto>(carWorkshop);

            return dto;
        }
    }
}
