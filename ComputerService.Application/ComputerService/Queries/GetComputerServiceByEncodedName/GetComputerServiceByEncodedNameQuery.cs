using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComputerService.Application.ComputerService.Queries.GetComputerServiceByEncodedName
{
    public class GetComputerServiceByEncodedNameQuery : IRequest<ComputerServiceDto>
    {
        public string EncodedName { get; set; }

        public GetComputerServiceByEncodedNameQuery(string encodedName)
        {
            EncodedName = encodedName;
        }
    }
}
