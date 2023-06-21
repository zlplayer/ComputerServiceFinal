using ComputerService.Infrastructure.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComputerService.Infrastructure.Seeders
{
    public class ComputerServiceSeeder
    {
        private readonly ComputerServiceDbContext _dbContext;

        public ComputerServiceSeeder(ComputerServiceDbContext dbContext) 
        {
            _dbContext=dbContext;
        }
        public async Task Seed()
        {
            if (await _dbContext.Database.CanConnectAsync())
            {
                if(!_dbContext.ComputerServices.Any())
                {
                    var computerService=new Domain.Entities.ComputerService()
                    {
                        Name="Computer Service",
                        Description="Serwis komputerowy",
                        ContactDetails = new()
                        {
                            City="Rzeszów",
                            Street="Szewska 2",
                            PostalCode="30-001",
                            PhoneNumber="+48699111453"
                        }
                    };
                    computerService.EncodeName();
                    _dbContext.ComputerServices.Add(computerService);
                    await _dbContext.SaveChangesAsync();
                }
            }
        }
    }
}
