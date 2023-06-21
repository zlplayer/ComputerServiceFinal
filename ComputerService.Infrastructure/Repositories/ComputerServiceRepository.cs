using ComputerService.Domain.Interfaces;
using ComputerService.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComputerService.Infrastructure.Repositories
{
    internal class ComputerServiceRepository: IComputerServiceRepository
    {
        private readonly ComputerServiceDbContext _dbContext;

        public ComputerServiceRepository(ComputerServiceDbContext dbContext)
        {
            _dbContext= dbContext;
        }

        public Task Commit()
         => _dbContext.SaveChangesAsync();

        public async Task Create(Domain.Entities.ComputerService computerService)
        {
            _dbContext.Add(computerService);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<IEnumerable<Domain.Entities.ComputerService>> GetAll() => await _dbContext.ComputerServices.ToListAsync();

        public async Task<Domain.Entities.ComputerService> GetByEncodedName(string encodedName) => await _dbContext.ComputerServices.FirstAsync(c=>c.EncodedName == encodedName);
        public Task<Domain.Entities.ComputerService?> GetByName(string name)
         => _dbContext.ComputerServices.FirstOrDefaultAsync(cw => cw.Name.ToLower() == name.ToLower());
    }
}
