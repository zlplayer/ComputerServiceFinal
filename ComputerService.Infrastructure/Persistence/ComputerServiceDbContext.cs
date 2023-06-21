using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComputerService.Infrastructure.Persistence
{
    public class ComputerServiceDbContext:IdentityDbContext
    {
        public ComputerServiceDbContext(DbContextOptions<ComputerServiceDbContext>options):base(options)
        {

        }
        public DbSet<Domain.Entities.ComputerService> ComputerServices { get; set; }

        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Domain.Entities.ComputerService>().OwnsOne(c => c.ContactDetails);
        }
    }
}
