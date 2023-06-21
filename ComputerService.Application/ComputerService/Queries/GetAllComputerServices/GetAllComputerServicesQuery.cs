using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComputerService.Application.ComputerService.Queries.GetAllComputerServices
{
    public class GetAllComputerServicesQuery:IRequest<IEnumerable<ComputerServiceDto>>
    {

    }
}
