using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComputerService.Domain.Interfaces
{
    public interface IComputerServiceRepository
    {
        Task Create(Domain.Entities.ComputerService computerService);
        Task <IEnumerable<Domain.Entities.ComputerService>> GetAll();
        Task<Domain.Entities.ComputerService> GetByEncodedName (string encodedName);
        Task Commit();
    }
}
