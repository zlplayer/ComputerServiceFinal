using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComputerService.Domain.Entities
{
    public class ComputerService
    {
        public int Id { get; set; }
        public string Name { get; set; } = default!;
        public string? Description {get;set;}
        public DateTime CreateAt { get; set; } = DateTime.UtcNow;
         public ComputerServiceContactDetails ContactDetails { get; set; }= default!;
        public string? CreatedById { get; set; }
        public IdentityUser? CreatedBy { get; set; }
        public string EncodedName { get; private set; } = default!;

        public void EncodeName()=> EncodedName= Name.ToLower().Replace(" ","-");
    }
}
