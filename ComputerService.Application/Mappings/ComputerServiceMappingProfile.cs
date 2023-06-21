using AutoMapper;
using ComputerService.Application.ApplicationUser;
using ComputerService.Application.ComputerService;
using ComputerService.Application.ComputerService.Commands.EditComputerService;
using ComputerService.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ComputerService.Application.Mappings
{
    public class ComputerServiceMappingProfile : Profile
    {
        public ComputerServiceMappingProfile(IUserContext userContext)
        {
            var user=userContext.GetCurrentUser();
            CreateMap<ComputerServiceDto, Domain.Entities.ComputerService>()
                .ForMember(e => e.ContactDetails, opt => opt.MapFrom(src => new ComputerServiceContactDetails()
                {
                    City = src.City,
                    PhoneNumber = src.PhoneNumber,
                    PostalCode = src.PostalCode,
                    Street = src.Street,
                }));

            CreateMap<Domain.Entities.ComputerService, ComputerServiceDto>()
                 .ForMember(dto => dto.IsEditable, opt => opt.MapFrom(src =>user!=null && (src.CreatedById==user.Id || user.IsInRole("Moderator"))))
                 .ForMember(dto => dto.Street, opt => opt.MapFrom(src => src.ContactDetails.Street))
                 .ForMember(dto => dto.City, opt => opt.MapFrom(src => src.ContactDetails.City))
                 .ForMember(dto => dto.PostalCode, opt => opt.MapFrom(src => src.ContactDetails.PostalCode))
                 .ForMember(dto => dto.PhoneNumber, opt => opt.MapFrom(src => src.ContactDetails.PhoneNumber));
            CreateMap<ComputerServiceDto, EditComputerServiceCommand>();
        }
    }
}
